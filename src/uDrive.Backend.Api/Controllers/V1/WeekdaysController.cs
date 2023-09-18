using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Api.Controllers.V1
{
    public class WeekdaysController : SecretaryController<Weekday>
    {
        public WeekdaysController(
        ILogger<WeekdaysController> logger,
        ApplicationDbContext context
    )
        : base(logger, context) { }
    }
}
