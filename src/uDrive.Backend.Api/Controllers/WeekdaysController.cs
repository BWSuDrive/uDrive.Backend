using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.AspNetCore.Http.StatusCodes;

using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Api.Controllers;

public class WeekdaysController : SecretaryRoleController<Weekday>
{
    private static ApplicationDbContext _context;

    public WeekdaysController(
    ILogger<WeekdaysController> logger,
    ApplicationDbContext context
)
    : base(logger, context) {
        _context = context;
    }

    [HttpPut("{key}")]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async ValueTask<ActionResult<Weekday>> PutAsync([FromRoute] string key, [FromBody] Weekday data)
    {
        if (!ModelState.IsValid || data is null)
        {

            return BadRequest(ModelState);
        }
        if (data.Id == string.Empty)
        {
            return BadRequest("The Id property must not be set.");
        }

        if (data.Id != key)
        {
            return BadRequest("Id does not match the Id in the payload.");
        }


        var entities = _context.Set<Weekday>().Where(x => x.Id == key);
        if (!entities.Any())
        {
            return NotFound($"{nameof(Weekday)} with id {key} not found");
        }
        var entity = entities.First();
        entity.Name = data.Name;
        await _context.SaveChangesAsync();
        return Ok(entities);
    }

    [HttpPatch("{key}")]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async ValueTask<ActionResult<Weekday>> PatchAsync([FromRoute] string key, [FromBody] Weekday data)
    {
        if (!ModelState.IsValid || data is null)
        {

            return BadRequest(ModelState);
        }
        if (key == string.Empty)
        {
            return BadRequest("The Id must be set.");
        }

        if (data.Id != key)
        {
            return BadRequest("Id does not match the Id in the payload.");
        }

        var entities = _context.Set<Weekday>().Where(x => x.Id == key);
        if (!entities.Any())
        {
            return NotFound($"{nameof(Weekday)} with id {key} not found");
        }
        var entity = entities.First();
        entity.Name = data.Name;
        await _context.SaveChangesAsync();
        return Ok(entity);
    }
}
