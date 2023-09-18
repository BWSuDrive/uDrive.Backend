using Microsoft.AspNetCore.Identity;
using uDrive.Backend.Model.DTO;
using uDrive.Backend.Model.Entities;

using uDrive.Backend.Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace uDrive.Backend.Api.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<Person> userManager;
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly IConfiguration _configuration;
    public AuthService(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
        _configuration = configuration;

    }
    //public async Task<(int, string)> Registeration(RegistrationModel model, string role)
    //{
    //    var userExists = await userManager.FindByNameAsync(model.Username);
    //    if (userExists != null)
    //        return (0, "User already exists");

    //    Person user = new()
    //    {
    //        Email = model.Email,
    //        SecurityStamp = Guid.NewGuid().ToString(),
    //        UserName = model.Username,
    //        FirstName = model.FirstName,
    //        LastName = model.LastName,
    //    };
    //    var createUserResult = await userManager.CreateAsync(user, model.Password);
    //    if (!createUserResult.Succeeded)
    //        return (0, "User creation failed! Please check user details and try again.");

    //    if (!await roleManager.RoleExistsAsync(role))
    //        await roleManager.CreateAsync(new IdentityRole(role));

    //    if (await roleManager.RoleExistsAsync(role))
    //        await userManager.AddToRoleAsync(user, role);

    //    return (1, "User created successfully!");
    //}
    public async Task<Response<LoginResponseDTO>> LoginSystemUserAsync(SignInUserDTO credentials)
      {
        
        var result = await Login(credentials).ConfigureAwait(false);
        if (result.Item1 != 1)
        {
            return new()
            {
                Success = false,
                Data = new LoginResponseDTO() { },
                Message = "Email or password is incorrect",
            };
        }
        var token = result.Item2;
        var user = result.Item3;
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
                Token = token
            },
        };
    }

    public async Task<(int, string, Person?)> Login(SignInUserDTO model)
    {
        var user = await userManager.FindByNameAsync(model.UserName);
        if (user == null)
            return (0, "Invalid username",null);
        if (!await userManager.CheckPasswordAsync(user, model.Password))
            return (0, "Invalid password",null);

        var userRoles = await userManager.GetRolesAsync(user);
        var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName),
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }
        string token = GenerateToken(authClaims);
        return (1, token,user);
    }


    private string GenerateToken(IEnumerable<Claim> claims)
    {
        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["ApplicationSettings:JWT_Secret"]));
        var _TokenExpiryTimeInHour = Convert.ToInt64(_configuration["JWTKey:TokenExpiryTimeInHour"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            //Issuer = _configuration["JWTKey:ValidIssuer"],
            //Audience = _configuration["JWTKey:ValidAudience"],
            //Expires = DateTime.UtcNow.AddHours(_TokenExpiryTimeInHour),
            Expires = DateTime.UtcNow.AddMinutes(1),
            SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
