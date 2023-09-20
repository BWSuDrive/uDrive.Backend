using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Model;
using static System.Net.Mime.MediaTypeNames;

namespace uDrive.Backend.Api.Controllers.Abstract;

[ApiController]
[Authorize(Roles = "Person")]
public class PersonController<TEntity> : AnonymousController<TEntity>
    where TEntity : class, IEntity
{


    public PersonController(ILogger<PersonController<TEntity>> logger, ApplicationDbContext context) 
        : base(logger, context)
    {
       
    }

    [HttpPost]
    public async ValueTask<IActionResult> PostAsync(TEntity entity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        //_= await Entities.AddAsync<TEntity>(entity).ConfigureAwait(false);
        //_ = Entities.SaveChanges();

        return NoContent();
    }

}
