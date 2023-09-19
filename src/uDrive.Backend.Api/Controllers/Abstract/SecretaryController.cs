using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Api.Data;
using static System.Net.Mime.MediaTypeNames;

namespace uDrive.Backend.Api.Controllers.Abstract;

[Produces(Application.Json)]
[Consumes(Application.Json)]
[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = "Secretary")]
public class SecretaryController<TEntity> : AnonymousController<TEntity>
    where TEntity : class, IEntity
{

   protected ILogger _logger;

    private static ApplicationDbContext _context;
    public IQueryable<TEntity> Entities => _context.Set<TEntity>().AsQueryable();

    public SecretaryController(ILogger<SecretaryController<TEntity>> logger, ApplicationDbContext context) 
        : base(logger, context)
    {
       
    }

}
