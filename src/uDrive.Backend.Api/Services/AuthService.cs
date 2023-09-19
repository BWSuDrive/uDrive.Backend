using Microsoft.AspNetCore.Identity;
using uDrive.Backend.Api.Data.DTO;
using uDrive.Backend.Api.Data.Models;

using uDrive.Backend.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Tools;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace uDrive.Backend.Api.Services;

public class AuthService : IAuthService
{
    private readonly SignInManager<Person> _signInManager;
    private readonly UserManager<Person> _userManager;
    private readonly IConfiguration _configuration;

    public AuthService(SignInManager<Person> signInManager,
        UserManager<Person> userManager,
        IConfiguration configuration)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _configuration = configuration;
    }

    public async Task<Response<LoginResponseDTO>> LoginSystemUserAsync(SignInUserDTO credentials)
    {
        var user = await _userManager.FindByEmailAsync(credentials.Email);
        if (user == null)
        {
            return new()
            {
                Success = false,
                Data = new LoginResponseDTO() { },
                Message = "Email or password is incorrect",
            };
        }
        var result = await _signInManager.PasswordSignInAsync(user.UserName, credentials.Password, false, true);
        if (!result.Succeeded)
        {
            return new()
            {
                Success = false,
                Data = new LoginResponseDTO() { },
                Message = "Email or password is incorrect",
            };
        }
        var token = await GenerateJWTTokenAsync(user).ConfigureAwait(false);
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
    public async Task<string> GenerateJWTTokenAsync(Person person)
    {
        var roles = await _userManager.GetRolesAsync(person).ConfigureAwait(false);
        var role = roles.FirstOrDefault();
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["JWTKey:Secret"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, person.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.Role, role)
        };

        var token = new JwtSecurityToken(
            issuer: null,
            audience: null,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(30),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
