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
        await DeletePersonDeep(user).ConfigureAwait(false);
        await _userManager.DeleteAsync(user).ConfigureAwait(false);
        await _context.SaveChangesAsync().ConfigureAwait(false);

        return NoContent();
    }

    private async Task DeletePersonDeep(Person person)
    {
        using var dbTransaction = _context.Database.BeginTransaction();

        var store = _context.Persons.Where(x => x.Id == person.Id).AsTracking().Include(x => x.Driver).ThenInclude(o => o.TourPlans).Include(x => x.AsPassengers).Include(x => x.PassengerRequests).FirstOrDefault();


        //   await store.ExecuteDeleteAsync().ConfigureAwait(false);
        var foundDriver = store.Driver;
        //var licence = _context.DrivingLicences.Where(x => x.Id == foundDriver.IdDrivinglicense);
        //_ = await licence.ExecuteDeleteAsync().ConfigureAwait(false);

        //var tourplans = _context.TourPlans.Where(x => x.IdDriver == foundDriver.Id);
        //_ = await tourplans.ExecuteDeleteAsync().ConfigureAwait(false);

        //var passengerrequests = _context.PassengerRequests.Where(x => x.IdPerson == store.Id);
        //_ = await passengerrequests.ExecuteDeleteAsync().ConfigureAwait(false);
        var driver = _context.Drivers.Where(x => x.Id == foundDriver.Id);
        _ = await driver.ExecuteDeleteAsync().ConfigureAwait(false);

        dbTransaction.Commit();


    }

    private async Task DeleteTours(Driver driver)
    {
        foreach (var tour in driver.TourPlans)
        {

        }
    }


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
