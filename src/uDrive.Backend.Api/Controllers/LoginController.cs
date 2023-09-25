using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Api.Services.Interfaces;
using uDrive.Backend.Model.DTO;
using static Microsoft.AspNetCore.Http.StatusCodes;
using static System.Net.Mime.MediaTypeNames;

namespace uDrive.Backend.Api.Controllers;


/// <summary>
/// Controller to manage Login, need no role
/// </summary>
[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase
{
    /// <summary>
    /// Internal access for the <see cref="ILogger"/>.
    /// </summary>
    private readonly ILogger<LoginController> _logger;

    /// <summary>
    /// internal reference to <see cref="IAuthService"/>
    /// </summary>
    private readonly IAuthService _authService;

    /// <inheritdoc />
    public LoginController(ILogger<LoginController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    /// <summary>
    /// Method to login in a user
    /// </summary>
    /// <param name="login">
    /// <code>
    /// {
    ///  "userName": "TestDriver3@udrive.de",
    /// "password": "password",
    /// "email": "TestDriver3@udrive.de"
    /// } 
    /// </code></param>
    /// <returns>The newly created <see cref="SignInUserDTO"/>
    /// </returns>
    /// <response code="200">
    /// <code>
    /// {
    ///   "success": true,
    ///   "data": {
    ///       "id": "id",
    ///       "userName": "TestDriver3@udrive.de",
    ///       "firstname": "Driver_Firstname_Test3",
    ///       "lastname": "Lastname_Test2",
    ///       "email": "TestDriver3@udrive.de",
    ///       "token": "token",
    ///       "roles": [
    ///           "Driver",
    ///           "Person",
    ///           ...
    ///       ]
    /// },
    ///   "message": "Login Successfull!"
    /// }
    /// </code></response>
    /// <response code="400">Returns, if the Model or the login is invalid</response>
    [HttpPost]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async Task<IActionResult> LoginAsync(SignInUserDTO login)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var response = await _authService.LoginSystemUserAsync(login).ConfigureAwait(false);
        if (!response.Success)
        {
            return BadRequest(response);
        }
        return Ok(response);
    }

}
