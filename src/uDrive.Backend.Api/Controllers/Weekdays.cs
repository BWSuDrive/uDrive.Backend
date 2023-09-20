using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Api.Controllers;

[Authorize(Roles = "Secretary")]
public class WeekdaysController : SecretaryController<Weekday>
{
    public WeekdaysController(
    ILogger<WeekdaysController> logger,
    ApplicationDbContext context
)
    : base(logger, context) { }
}
