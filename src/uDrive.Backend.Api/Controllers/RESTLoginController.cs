using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using uDrive.Backend.Model.DTO;
using uDrive.Backend.Model.Entities;
using uDrive.Backend.Api.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Microsoft.AspNetCore.Authorization;

namespace uDrive.Backend.Api.Controllers;

[Produces(Application.Json)]
[Consumes(Application.Json)]

[ApiController]
[AllowAnonymous]
[Route("api/[controller]")]
public class RESTLoginController : ControllerBase
{
    private readonly SignInManager<Person> _signInManager;
    private readonly ILogger<RESTLoginController> _logger;
    private readonly IAuthService _authService;

    public RESTLoginController(SignInManager<Person> signInManager, ILogger<RESTLoginController> logger, IAuthService authService)
    {
        _signInManager = signInManager;
        _logger = logger;
        _authService = authService;
    }

    [HttpPost]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]

    public async Task<IActionResult> LogInUser(SignInUserDTO signInUserDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _authService.LoginSystemUserAsync(signInUserDTO).ConfigureAwait(false);

        return Ok(response);
    }
}
