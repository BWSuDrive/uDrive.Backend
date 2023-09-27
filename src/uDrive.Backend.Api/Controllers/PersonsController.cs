using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Api.Services.Interfaces;
using uDrive.Backend.Model;
using uDrive.Backend.Model.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace uDrive.Backend.Api.Controllers;
/// <summary>
/// Controller for <see cref="Person"/> related endpoints
/// </summary>
[Authorize(Roles = $"{UDriveRoles.Secretary},{UDriveRoles.Administrator}")]
[Produces(Application.Json)]
[Consumes(Application.Json)]
[Route("[controller]")]
[ApiController]
public class PersonsController : ControllerBase
{ /// <summary>
  /// internal <see cref="DbContext"/> reference
  /// </summary>
    private static ApplicationDbContext _context;

    /// <summary>
    /// internal reference to <see cref="IAuthService"/>
    /// </summary>
    private readonly IAuthService _authService;
    /// <summary>
    /// Internal access for the <see cref="ILogger"/>.
    /// </summary>
    private readonly ILogger<PersonsController> _logger;

    private readonly UserManager<Person> _userManager;

    /// <inheritdoc />
    public PersonsController(
    ILogger<PersonsController> logger,
    ApplicationDbContext context, IAuthService authService,
     UserManager<Person> userManager
    )
    {
        _authService = authService;
        _context = context;
        _logger = logger;
        _userManager = userManager;
    }


    /// <summary>
    /// Method to verify a registered Person
    /// </summary>
    /// <param name="idPerson">The id of the <see cref="Person"/></param>
    /// <returns>Ok</returns>
    [HttpPatch("{idPerson}")]
    public async Task<ActionResult> VerifyPersonAsync([FromRoute] string idPerson)
    {
        if (idPerson is null || idPerson == string.Empty)
        {
            return BadRequest();
        }

        var user = await _userManager.FindByIdAsync(idPerson).ConfigureAwait(false); 
        
        if (user is null)
        {
            return NotFound();
        }
        
        user.Verified = true;
        await _userManager.AddToRoleAsync(user, "Person").ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);

        return Ok();
    }

    /// <summary>
    /// Method to Delete a <see cref="Person"/>
    /// </summary>
    /// <param name="idPerson">Id of the <see cref="Person"/></param>
    /// <returns>NoContent</returns>
    [HttpDelete("{idPerson}")]
    public async Task<ActionResult> DeletePersonWithIdAsync([FromRoute] string idPerson)
    {
        if (idPerson is null || idPerson == string.Empty)
        {
            return BadRequest();
        }

        var user = await _userManager.FindByIdAsync(idPerson).ConfigureAwait(false);
        if(user is null)
        {
            return NotFound();
        }


        await _userManager.DeleteAsync(user).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Method to delete a person, selected by his/her email
    /// </summary>
    /// <param name="emailPerson">The email of the <see cref="Person"/></param>
    /// <returns>NoContent</returns>
    [HttpDelete("DeletePersonWithEmail/{emailPerson}")]
    public async Task<ActionResult> DeletePersonWithEmailAsync([FromRoute] string emailPerson)
    {
        if (emailPerson is null || emailPerson == string.Empty)
        {
            return BadRequest();
        }

        var user = await _userManager.FindByEmailAsync(emailPerson).ConfigureAwait(false);
        if (user is null)
        {
            return NotFound();
        }
        await _userManager.DeleteAsync(user).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);

        return NoContent();
    }

    /// <summary>
    /// Method to give a <see cref="Person"/> a new <see cref="IdentityRole"/>
    /// </summary>
    /// <param name="role">Name of the Role</param>
    /// <param name="idPerson">Id of the <see cref="Person"/></param>
    /// <returns>OK</returns>
    [Authorize(Roles = $"{UDriveRoles.Administrator}")]
    [HttpPut("AddRoleToUser/{role}/{idPerson}")]
    public async Task<ActionResult> AddRoleToUser([FromRoute] string role, [FromRoute] string idPerson)
    {
        var user = await _userManager.FindByIdAsync(idPerson).ConfigureAwait(false);
        if (user is null)
        {
            return NotFound();
        }

        await _userManager.AddToRoleAsync(user,role).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);

        return Ok();
    }
}
