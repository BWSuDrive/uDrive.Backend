using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Model;
using static System.Net.Mime.MediaTypeNames;

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
    public async ValueTask<IQueryable<TEntity>> GetAsync()
    {
        return Entities;
    }
}
