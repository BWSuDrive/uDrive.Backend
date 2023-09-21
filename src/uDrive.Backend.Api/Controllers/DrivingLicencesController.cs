using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model.Entities;
using uDrive.Backend.Model;
using Microsoft.AspNetCore.Mvc;

namespace uDrive.Backend.Api.Controllers
{
    public class DrivingLicencesController : SecretaryRoleController<DrivingLicence>
    {
        public DrivingLicencesController(
        ILogger<DrivingLicencesController> logger,
        ApplicationDbContext context
    )
        : base(logger, context) { }
    }


    //[HttpPost("/AddDriver/{key}")]
    //public async Task<IActionResult> PostAddDriver()
}
