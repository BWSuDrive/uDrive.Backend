using Microsoft.AspNetCore.Identity;
using uDrive.Backend.Model.DTO;
using uDrive.Backend.Model.Entities;

using uDrive.Backend.Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Data;
using Microsoft.Extensions.Primitives;
using uDrive.Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace uDrive.Backend.Api.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<Person> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;

    public AuthService(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, ApplicationDbContext context)
    {
        this._userManager = userManager;
        this._roleManager = roleManager;
        _configuration = configuration;
        _context = context;


    }

    public async Task<Person> GetLogedInPerson(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
        var tokenHandler = new JwtSecurityTokenHandler();
        var SecretKey = _configuration["JWTKey:Secret"];
        var key = Encoding.UTF8.GetBytes(SecretKey);
       // var token = HttpContext.Request.Headers["Authorization"];

        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ClockSkew = TimeSpan.Zero
        }, out SecurityToken validatedToken);

        var jwtToken = (JwtSecurityToken)validatedToken;
        var userId = jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value;
        var user = await _userManager.FindByNameAsync(userId).ConfigureAwait(false);
        if(user is null)
        {
            throw new InvalidOperationException();
        }    
        var dbUser = _context.Persons.Where(x => x.Id == user.Id).AsTracking().Include(driver => driver.Drivers).FirstOrDefault();
        return user;
    }

    public async Task<Response<LoginResponseDTO>> RegisterSystemUserAsync(RegisterDTO registerDTO)
    {
        var result = await RegistrationAsync(registerDTO).ConfigureAwait(false);
        if (result.identifier != 1)
        {
            return new()
            {
                Success = false,
                Data = new LoginResponseDTO() { },
                Message = result.token
            };
        }
        var user = result.user;
        return new Response<LoginResponseDTO>()
        {
            Message = "User created successfully!",
            Data = new()
            {
                Id = user.Id,
                UserName = user.UserName,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Roles = result.roles,
                Token = result.token
            },
        };
    }

    public async Task<(int identifier, string token, Person? user, List<string>? roles)> RegistrationAsync(RegisterDTO model)
    {
        var userExists = await _userManager.FindByNameAsync(model.UserName);
        if (userExists != null)
            return (0, "User already exists", null,null);

        Person user = new()
        {
            Email = model.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.UserName,
            Firstname = model.Firstname,
            Lastname = model.Lastname,
            EmailConfirmed = true,
            NormalizedEmail = model.Email.ToUpper(),
            NormalizedUserName = model.UserName.ToUpper(),
            Verified = true,
            PhoneNumber = model.PhoneNumber,
            PhoneNumberConfirmed = true // TODO : change afterwards
        };
        var createUserResult = await _userManager.CreateAsync(user, model.Password);
        if (!createUserResult.Succeeded)
            return (0, "User creation failed! Please check user details and try again.",null, null);

        await _userManager.AddToRoleAsync(user, "Person");
        var createdUser = await _userManager.FindByIdAsync(user.Id).ConfigureAwait(false);
        var userRoles = new List<string>() { "Person" };
        var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim("id",user.Id)
        };
        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }
        string token = await GenerateJWTTokenAsync(user, authClaims).ConfigureAwait(false);

        return (1, token, createdUser, userRoles);
    }

    public async Task<Response<LoginResponseDTO>> LoginSystemUserAsync(SignInUserDTO credentials)
    {

        var result = await LoginAsync(credentials).ConfigureAwait(false);
        if (result.identifier != 1)
        {
            return new()
            {
                Success = false,
                Data = new LoginResponseDTO() { },
                Message = "Email or password is incorrect",
            };
        }
        var user = result.user;
        return new Response<LoginResponseDTO>()
        {
            Message = "Login Successfull!",
            Data = new()
            {
                Id = user.Id,
                UserName = user.UserName,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Email = user.Email,
                Roles = result.roles,
                Token = result.token
            },
        };
    }

    public async Task<(int identifier, string token, Person? user, List<string>? roles)> LoginAsync(SignInUserDTO model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);
        if (user == null)
            return (0, "Invalid username", null, null);
        if (!await _userManager.CheckPasswordAsync(user, model.Password))
            return (0, "Invalid password", null, null);

        var userRolesIList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
        var userRoles = userRolesIList.ToList();
        var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("id",user.Id)

            };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }
        string token = await GenerateJWTTokenAsync(user, authClaims).ConfigureAwait(false);
        return (1, token, user, userRoles);
    }

    public async Task<bool> AssignPersonToRoleAsync(Person person, string role)
    {
        _ = await _userManager.AddToRoleAsync(person,role).ConfigureAwait(false);
        return true;
    }


    private async Task<string> GenerateJWTTokenAsync(Person person, IEnumerable<Claim> claims)
    {

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTKey:Secret"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
