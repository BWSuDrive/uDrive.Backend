using Geolocation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Api.Services.Interfaces;
using uDrive.Backend.Model;
using uDrive.Backend.Model.DTO;
using uDrive.Backend.Model.Entities;
using static System.Net.Mime.MediaTypeNames;
namespace uDrive.Backend.Api.Controllers;


[Authorize(Roles = $"{UDriveRoles.Secretary},{UDriveRoles.Administrator},{UDriveRoles.Driver},{UDriveRoles.Person}")]
[Produces(Application.Json)]
[Consumes(Application.Json)]
[Route("[controller]")]
[ApiController]
public class ScheduleTourController : ControllerBase
{
    protected ILogger _logger;

    private static ApplicationDbContext _context;
    public ScheduleTourController(ILogger<ScheduleTourController> logger, ApplicationDbContext context, IAuthService authService)
    {
        _logger = logger;
        _context = context;
    }

   

}
