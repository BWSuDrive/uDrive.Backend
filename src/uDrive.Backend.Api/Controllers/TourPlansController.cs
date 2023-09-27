using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Api.Services.Interfaces;
using uDrive.Backend.Model;
using uDrive.Backend.Model.Entities;
using static System.Net.Mime.MediaTypeNames;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace uDrive.Backend.Api.Controllers;

/// <summary>
/// Controller to access and modify <see cref="DrivingLicence"/> Entities. 
/// Inherits from <see cref="SecretaryRoleController{TEntity}"/>.
/// </summary>
//[Produces(Application.Json)]
//[Consumes(Application.Json)]
//[Route("[controller]")]
//[ApiController]
//[Authorize(Roles = $"{UDriveRoles.Secretary},{UDriveRoles.Administrator},{UDriveRoles.Driver}")]
public class TourPlansController : DriverRoleController<TourPlan>
{
    private readonly IAuthService _authService;

    /// <summary>
    /// Internal access for the <see cref="ILogger"/>.
    /// </summary>
    protected ILogger _logger;

    /// <summary>
    /// internal <see cref="DbContext"/> reference
    /// </summary>
    private static ApplicationDbContext _context;

    /// <summary>
    /// internal queryable list of <see cref="TourPlan"/>
    /// </summary>
    public IQueryable<TourPlan> Entities => _context.Set<TourPlan>().AsQueryable();
    /// <inheritdoc />
    public TourPlansController(
    ILogger<TourPlansController> logger,
    ApplicationDbContext context,
    IAuthService authService
) : base(logger, context, authService)
    {
        _logger = logger;
        _context = context;
        _authService = authService;
    }

    /// <summary>
    /// Queryable collection of <typeparamref name="TourPlan"/>.
    /// </summary>
    /// <returns>
    /// Queryable collection of <typeparamref name="TourPlan"/>.
    /// </returns>
    /// <response code="200">Returns a queryable collection of <typeparamref name="TourPlan"/>.</response>
    [HttpGet]
    [ProducesResponseType(Status200OK)]
    public override async ValueTask<ActionResult<IQueryable<TourPlan>>> GetAsync()
    {
        var person = await _authService.GetLogedInPerson(HttpContext).ConfigureAwait(false);
        if (person is null)
        {
            return BadRequest();
        }

        var driver = person.Drivers.FirstOrDefault();
        if (driver is null)
        {
            return BadRequest();
        }

        var result = Entities.Where(x => x.IdDriver == driver.Id).ToList();


        return Ok(result);
    }


    /// <summary>
    /// Searched entity.
    /// </summary>
    /// <param name="id">id of the searched entity.</param>
    /// <returns>Searched entity.</returns>
    /// <response code="200">Returns a queryable item of <typeparamref name="TourPlan"/>.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public override async ValueTask<ActionResult<TourPlan>> GetByIdAsync(string id)
    {
        var person = await _authService.GetLogedInPerson(HttpContext).ConfigureAwait(false);
        if (person is null)
        {
            return BadRequest();
        }

        var driver = person.Drivers.FirstOrDefault();
        if (driver is null)
        {
            return BadRequest();
        }

        var result = Entities.Where(x => x.IdDriver == driver.Id).ToList();

        if (id == string.Empty)
        {
            return BadRequest("Id is empty");
        }

        var entity = result.SingleOrDefault(x => x.Id == id);
        if (entity is null)
        {
            return NotFound($"Entity with Id '{id}' not found");
        }
        return entity;
    }

    /// <summary>
    /// Creates a new item, and returns the created item with the correct id.
    /// </summary>
    /// <param name="entity">Model to be inserted.</param>
    /// <response code="201">Return the newly created item.</response>
    /// <response code="400">If the model is not correct.</response>
    /// <returns>The newly created item.</returns>
    [HttpPost]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public override async ValueTask<ActionResult<TourPlan>> PostAsync([FromBody] TourPlan entity)
    {
        if (!ModelState.IsValid || entity is null)
        {

            return BadRequest(ModelState);
        }

        if (entity.Id != null)
        {
            return BadRequest("The Id property must not be set.");
        }
        var person = await _authService.GetLogedInPerson(HttpContext).ConfigureAwait(false);
        if (person is null)
        {
            return BadRequest();
        }

        var driver = person.Drivers.FirstOrDefault();
        if (driver is null)
        {
            return BadRequest();
        }

        entity.IdDriver = driver.Id;

        var save = await _context.Set<TourPlan>().AddAsync(entity).ConfigureAwait(false);
        await _context.SaveChangesAsync();
        return Ok(save.Entity);
    }



    /// <summary>
    /// Deletes the entity with the <paramref name="key"/>.
    /// </summary>
    /// <param name="key">Key of the entity to be deleted.</param>
    /// <response code="204">If the model could be deleted correctly.</response>
    /// <response code="400">If the model is not correct.</response>
    /// <response code="404">If the model could not be found.</response>
    [HttpDelete("{key}")]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public override async ValueTask<ActionResult> DeleteAsync([FromRoute] string key)
    {

        if (key == string.Empty)
        {
            return BadRequest("The Id must be set.");
        }

        var person = await _authService.GetLogedInPerson(HttpContext).ConfigureAwait(false);
        if (person is null)
        {
            return BadRequest();
        }

        var driver = person.Drivers.FirstOrDefault();
        if (driver is null)
        {
            return BadRequest();
        }

        var result = Entities.Where(x => x.IdDriver == driver.Id).ToList();        

        var savedEntity = result.SingleOrDefault(x => x.Id == key);

        if (savedEntity == null)
        {
            return NotFound($"{nameof(TourPlan)} with id {key} not found");
        }
        _ = _context.Set<TourPlan>().Remove(savedEntity);
        await _context.SaveChangesAsync();
        return Ok();
    }

}
