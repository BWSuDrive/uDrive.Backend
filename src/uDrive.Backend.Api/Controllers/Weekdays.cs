using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Model;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Roles = "Secretary")]

public class Weekdays : ControllerBase
{
    private readonly SignInManager<Person> _signInManager;
    private readonly ILogger<Login> _logger;
    private readonly UserManager<Person> _userManager;
    private readonly IConfiguration _configuration;
    private static ApplicationDbContext _context;

    public Weekdays(SignInManager<Person> signInManager, UserManager<Person> userManager, ILogger<Login> logger, IConfiguration configuration, ApplicationDbContext context)
    {
        _signInManager = signInManager;
        _logger = logger;
        _userManager = userManager;
        _configuration = configuration;
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var res = _context.Weekdays;
        return Ok(res);
    }

}
