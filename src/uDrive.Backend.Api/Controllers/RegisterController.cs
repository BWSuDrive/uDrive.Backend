using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using uDrive.Backend.Api.Services;
using uDrive.Backend.Api.Services.Interfaces;
using uDrive.Backend.Model.DTO;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Api.Controllers;

/// <summary>
/// Helper Controller, to managed Registration
/// </summary>
[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    private readonly ILogger<RegisterController> _logger;
    private readonly IAuthService _authService;

    /// <inheritdoc />
    public RegisterController(ILogger<RegisterController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    /// <summary>
    /// Method to registar a <see cref="Person"/>
    /// </summary>
    /// <param name="register">The <see cref="RegisterDTO"/> entity
    /// <code>
    /// {
    /// "userName": "test@bundestag.de",
    /// "password": "Test1234!",
    /// "email": "test@bundestag.de",
    /// "firstname": "Test",
    /// "lastname": "Test",
    /// "phonenumber" : "0049 619229040"
    /// }
    /// </code>
    /// </param>
    /// <returns></returns>
    [HttpPost]
    public async Task<IActionResult> RegisterAsync(RegisterDTO register)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _authService.RegisterSystemUserAsync(register).ConfigureAwait(false);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

}
