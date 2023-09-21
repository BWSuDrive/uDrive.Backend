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

[ApiController]
[Route("[controller]")]
public class RegisterController : ControllerBase
{
    private readonly ILogger<RegisterController> _logger;
    private readonly IAuthService _authService;


    public RegisterController(ILogger<RegisterController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }


    [HttpPost]
    public async Task<IActionResult> RegisterAsync(RegisterDTO register)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _authService.RegisterSystemUserAsync(register).ConfigureAwait(false);
        if(!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

}
