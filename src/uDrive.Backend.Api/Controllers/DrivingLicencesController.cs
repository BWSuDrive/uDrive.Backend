using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model.Entities;
using uDrive.Backend.Model;

using static System.Net.Mime.MediaTypeNames;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Packaging.Licenses;
using uDrive.Backend.Api.Services.Interfaces;

namespace uDrive.Backend.Api.Controllers;

/// <summary>
/// Controller to access and modify <see cref="DrivingLicence"/> Entities. 
/// Inherits from <see cref="SecretaryRoleController{TEntity}"/>.
/// </summary>
public class DrivingLicencesController : SecretaryRoleController<DrivingLicence>
{
    /// <inheritdoc />
    public DrivingLicencesController(
    ILogger<DrivingLicencesController> logger,
    ApplicationDbContext context,
    IAuthService authService
)
    : base(logger, context, authService) { 
    
    }

   
}



