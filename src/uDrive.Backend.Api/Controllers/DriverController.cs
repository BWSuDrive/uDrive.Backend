using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model.Entities;
using uDrive.Backend.Model;

namespace uDrive.Backend.Api.Controllers
{
    public class DriversController : PersonController<Driver>
    {
        public DriversController(
        ILogger<DriversController> logger,
        ApplicationDbContext context
    )
        : base(logger, context) { }
    }
}
