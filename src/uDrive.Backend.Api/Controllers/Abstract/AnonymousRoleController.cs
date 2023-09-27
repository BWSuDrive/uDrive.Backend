using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using uDrive.Backend.Api.Services.Interfaces;
using uDrive.Backend.Model;
using uDrive.Backend.Model.DTO;
using static System.Net.Mime.MediaTypeNames;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace uDrive.Backend.Api.Controllers.Abstract;

/// <summary>
/// Controller for REST Request, where no Authorization is required
/// </summary>
/// <typeparam name="TEntity"><see cref="IEntity"/> as <see cref="TEntity"/> as class</typeparam>
[Produces(Application.Json)]
[Consumes(Application.Json)]
[Route("[controller]")]
[ApiController]
public abstract class AnonymousRoleController<TEntity> : ControllerBase where TEntity : class, IEntity
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
    /// internal queryable list of <see cref="TEntity"/>
    /// </summary>
    public IQueryable<TEntity> Entities => _context.Set<TEntity>().AsQueryable();

    /// <summary>
    /// Internal constructor.
    /// </summary>
    /// <param name="logger">Logger, managed by dependency injection.</param>
    /// <param name="context">Context, managed by dependecy injection.</param>
    public AnonymousRoleController(ILogger<AnonymousRoleController<TEntity>> logger, ApplicationDbContext context, IAuthService authService)
    {
        _logger = logger;
        _context = context;
        _authService = authService;
    }

    /// <summary>
    /// Queryable collection of <typeparamref name="TEntity"/>.
    /// </summary>
    /// <returns>
    /// Queryable collection of <typeparamref name="TEntity"/>.
    /// </returns>
    /// <response code="200">Returns a queryable collection of <typeparamref name="TEntity"/>.</response>
    [HttpGet]
    [ProducesResponseType(Status200OK)]
    public virtual async ValueTask<ActionResult<IQueryable<TEntity>>> GetAsync()
    {
        return Ok(Entities);
    }


    /// <summary>
    /// Searched entity.
    /// </summary>
    /// <param name="id">id of the searched entity.</param>
    /// <returns>Searched entity.</returns>
    /// <response code="200">Returns a queryable item of <typeparamref name="TEntity"/>.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public virtual async ValueTask<ActionResult<TEntity>> GetByIdAsync(string id)
    {
        if (id == string.Empty)
        {
            return BadRequest("Id is empty");
        }

        var entity = Entities.SingleOrDefault(x => x.Id == id);
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
    public virtual async ValueTask<ActionResult<TEntity>> PostAsync([FromBody] TEntity entity)
    {
        if (!ModelState.IsValid || entity is null)
        {

            return BadRequest(ModelState);
        }

        if (entity.Id != null)
        {
            return BadRequest("The Id property must not be set.");
        }

        var save = await _context.Set<TEntity>().AddAsync(entity).ConfigureAwait(false);
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
    public virtual async ValueTask<ActionResult> DeleteAsync([FromRoute] string key)
    {

        if (key == string.Empty)
        {
            return BadRequest("The Id must be set.");
        }
        using var dbTransaction = _context.Database.BeginTransaction();
        var savedEntity = Entities.Where(x => x.Id == key);

        if (savedEntity == null)
        {
            return NotFound($"{nameof(TEntity)} with id {key} not found");
        }
        _ = await savedEntity.ExecuteDeleteAsync().ConfigureAwait(false);
        // _context.Set<TEntity>().Remove(savedEntity);
        await dbTransaction.CommitAsync().ConfigureAwait(false);
        //await _context.SaveChangesAsync().ConfigureAwait(false);
        return NoContent();
    }
}
