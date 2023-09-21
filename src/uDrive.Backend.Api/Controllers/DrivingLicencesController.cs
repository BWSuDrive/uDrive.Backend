using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model.Entities;
using uDrive.Backend.Model;

using static System.Net.Mime.MediaTypeNames;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Packaging.Licenses;

namespace uDrive.Backend.Api.Controllers;

public class DrivingLicencesController : SecretaryRoleController<DrivingLicence>
{
    private static ApplicationDbContext _context;

    public DrivingLicencesController(
    ILogger<DrivingLicencesController> logger,
    ApplicationDbContext context
)
    : base(logger, context) { 
    
    _context = context;
    }

   
}



