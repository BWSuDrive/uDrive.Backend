using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using uDrive.Backend.Model;
using uDrive.Backend.Model.DTO;
using static System.Net.Mime.MediaTypeNames;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace uDrive.Backend.Api.Controllers.Abstract;

[Produces(Application.Json)]
[Consumes(Application.Json)]
[Route("[controller]")]
[ApiController]
public class AnonymousController<TEntity> : ControllerBase where TEntity : class, IEntity
{

    protected ILogger _logger;

    private static ApplicationDbContext _context;
    public IQueryable<TEntity> Entities => _context.Set<TEntity>().AsQueryable();

    public AnonymousController(ILogger<AnonymousController<TEntity>> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    [ProducesResponseType(Status200OK)]
    public ActionResult<IQueryable<TEntity>> Get()
    {
        return Ok(Entities);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public ActionResult<TEntity> GetById(string id)
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


    [HttpPost]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public async ValueTask<ActionResult<TEntity>> PostAsync([FromBody] TEntity entity)
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


    //[HttpPut("{key}")]
    //[ProducesResponseType(Status200OK)]
    //[ProducesResponseType(Status400BadRequest)]
    //[ProducesResponseType(Status404NotFound)]
    //public async ValueTask<ActionResult<TEntity>> PutAsync([FromRoute] string key, [FromBody] TEntity entity)
    //{
    //    if (!ModelState.IsValid || entity is null)
    //    {

    //        return BadRequest(ModelState);
    //    }
    //    if (entity.Id == string.Empty)
    //    {
    //        return BadRequest("The Id property must not be set.");
    //    }

    //    if (entity.Id != key)
    //    {
    //        return BadRequest("Id does not match the Id in the payload.");
    //    }

    // //   var savedEntity = Entities.SingleOrDefault(x => x.Id == key);

    //    var savedEntity = _context.Set<TEntity>().Where(x => x.Id == key).AsTracking();
    //    if (!savedEntity.Any())
    //    {
    //        return NotFound($"{nameof(TEntity)} with id {key} not found");
    //    }
    //    var ew = savedEntity.First();
    //    ew = entity;
    //    //savedEntity = entity;

    //    //_ = _context.Set<TEntity>().Update(entity);
    //    //  var save = await _context.Set<TEntity>(). .AddAsync(entity).ConfigureAwait(false);
    //    await _context.SaveChangesAsync();
    //    return Ok(savedEntity);
    //}

    //[HttpPatch("{key}")]
    //[ProducesResponseType(Status200OK)]
    //[ProducesResponseType(Status400BadRequest)]
    //[ProducesResponseType(Status404NotFound)]
    //public async ValueTask<ActionResult<TEntity>> PatchAsync([FromRoute] string key, [FromBody] TEntity entity)
    //{
    //    if (!ModelState.IsValid || entity is null)
    //    {

    //        return BadRequest(ModelState);
    //    }
    //    if (key == string.Empty)
    //    {
    //        return BadRequest("The Id must be set.");
    //    }

    //    if (entity.Id != key)
    //    {
    //        return BadRequest("Id does not match the Id in the payload.");
    //    }

    //    var savedEntity = Entities.SingleOrDefault(x => x.Id == key);

    //    if (savedEntity == null)
    //    {
    //        return NotFound($"{nameof(TEntity)} with id {key} not found");
    //    }
    //    savedEntity = entity;
    //    //  var save = await _context.Set<TEntity>(). .AddAsync(entity).ConfigureAwait(false);
    //    await _context.SaveChangesAsync();
    //    return Ok(savedEntity);
    //}

    [HttpDelete("{key}")]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async ValueTask<ActionResult> DeleteAsync([FromRoute] string key)
    {

        if (key == string.Empty)
        {
            return BadRequest("The Id must be set.");
        }
        var savedEntity = Entities.SingleOrDefault(x => x.Id == key);

        if (savedEntity == null)
        {
            return NotFound($"{nameof(TEntity)} with id {key} not found");
        }
        _ = _context.Set<TEntity>().Remove(savedEntity);
        await _context.SaveChangesAsync();
        return Ok();
    }
}
