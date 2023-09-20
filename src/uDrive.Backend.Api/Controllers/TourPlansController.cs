using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Api.Controllers;

public class TourPlansController : PersonController<TourPlan>
{
    public TourPlansController(
    ILogger<TourPlansController> logger,
    ApplicationDbContext context
)
    : base(logger, context) { }
}
