using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Api.Services.Interfaces;
using uDrive.Backend.Model;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Api.Controllers;

/// <summary>
/// Controller to access and modify <see cref="DrivingLicence"/> Entities. 
/// Inherits from <see cref="SecretaryRoleController{TEntity}"/>.
/// </summary>
public class TourPlansController : DriverRoleController<TourPlan>
{
    /// <inheritdoc />
    public TourPlansController(
    ILogger<TourPlansController> logger,
    ApplicationDbContext context,
    IAuthService authService
)
    : base(logger, context, authService) { }

}
