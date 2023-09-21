﻿using Microsoft.AspNetCore.Identity;
using uDrive.Backend.Model.DTO;
using uDrive.Backend.Model.Entities;

using uDrive.Backend.Api.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Data;

namespace uDrive.Backend.Api.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<Person> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IConfiguration _configuration;
    public AuthService(UserManager<Person> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
    {
        this._userManager = userManager;
        this._roleManager = roleManager;
        _configuration = configuration;

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
            };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }
        string token = await GenerateJWTTokenAsync(user, authClaims).ConfigureAwait(false);
        return (1, token, user, userRoles);
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