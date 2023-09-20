using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Model;
using uDrive.Backend.Model.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace uDrive.Backend.Api.Controllers.Abstract;

[Authorize (Roles = $"{UDriveRoles.Secretary},{UDriveRoles.Administrator},{UDriveRoles.Person}")]
public class PersonRoleController<TEntity> : AnonymousController<TEntity>
    where TEntity : class, IEntity
{


    public PersonRoleController(ILogger<PersonRoleController<TEntity>> logger, ApplicationDbContext context) 
        : base(logger, context)
    {
       
    }

    //[HttpPost]
    //public async ValueTask<IActionResult> PostAsync(TEntity entity)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    //_= await Entities.AddAsync<TEntity>(entity).ConfigureAwait(false);
    //    //_ = Entities.SaveChanges();

    //    return NoContent();
    //}

}
