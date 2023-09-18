using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Api.Controllers.V1;


public class DriversController : AnonymousController<Driver>
{
    public DriversController(
        ILogger<DriversController> logger,
        ApplicationDbContext context
    )
        : base(logger, context) { }

}
