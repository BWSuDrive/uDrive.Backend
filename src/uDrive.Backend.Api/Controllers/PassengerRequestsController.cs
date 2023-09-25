using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model.Entities;
using uDrive.Backend.Model;

using static System.Net.Mime.MediaTypeNames;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Packaging.Licenses;
using Microsoft.AspNetCore.Identity;
using uDrive.Backend.Model.DTO;
using uDrive.Backend.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace uDrive.Backend.Api.Controllers;

/// <summary>
/// Controller to access and modify <see cref="PassengerRequest"/> Entities. 
/// Inherits from <see cref="PersonRoleController{TEntity}"/>.
/// </summary>
public class PassengerRequestsController : PersonRoleController<PassengerRequest>
{    
    /// <inheritdoc />
    private readonly IAuthService _authService;

    /// <inheritdoc />
    private static ApplicationDbContext _context;


    /// <inheritdoc />
    public PassengerRequestsController(
    ILogger<PassengerRequestsController> logger,
    ApplicationDbContext context,
    IAuthService authService
)
    : base(logger, context, authService) { 
        _authService = authService;
        _context = context;
    }

    /// <summary>
    /// Gets a list of <see cref="PassengerRequest"/>
    /// </summary>
    /// <param name="personId">The id of the person</param>
    /// <returns></returns>
    [HttpGet("GetPassengerRequests/{personId}")]
    public async ValueTask<ActionResult<IList<PassengerRequest>>> GetPassengerRequestsAsync([FromRoute] string personId)
    {
        var user = _context.Persons.Where(x => x.Id == personId).AsTracking().Include(driver => driver.Drivers).ThenInclude( tourplan => tourplan.TourPlans).ThenInclude(request => request.PassengerRequests).FirstOrDefault();

        var requests = user.Drivers.SelectMany(x => x.TourPlans.SelectMany(x => x.PassengerRequests));
        //var claims = HttpContext.User;
        //var token = HttpContext.Request.Headers["Authorization"];
        ////var user = await _userManager.GetUserAsync(claims).ConfigureAwait(false);
        //var user = await _authService.GetLogedInPerson(token).ConfigureAwait(false);
        return Ok(requests);
    }


}



