using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Api.Data;
using uDrive.Backend.Api.Data.Models;

namespace uDrive.Backend.Api.Controllers.V1;


public class DriversController : AnonymousController<Driver>
{
    public DriversController(
        ILogger<DriversController> logger,
        ApplicationDbContext context
    )
        : base(logger, context) { }

}
