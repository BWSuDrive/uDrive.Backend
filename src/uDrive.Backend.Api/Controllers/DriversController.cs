using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model.Entities;
using uDrive.Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace uDrive.Backend.Api.Controllers
{
    public class DriversController : PersonRoleController<Driver>
    {
        private static ApplicationDbContext _context;

        public DriversController(
        ILogger<DriversController> logger,
        ApplicationDbContext context
    )
        : base(logger, context) { 
        _context = context;
        }

        [HttpGet("GetScheduledDrivers")]
        public async ValueTask<ActionResult<Driver>> GetScheduledDriversAsync()
        {
            var res = _context.Drivers.AsTracking().Include(tours => tours.TourPlans).AsQueryable();
            var pes = res.Where(x => x.TourPlans.Any()).ToList();
            return Ok(pes);
        }

        [Authorize(Roles = $"{UDriveRoles.Secretary},{UDriveRoles.Administrator}")]
        [HttpPost("AddDrivingLicenceWithNewDriver/{personId}")]
        public async ValueTask<ActionResult<Driver>> PostAddDrivingLicenceWithNewDriverAsync([FromRoute] string personId, [FromBody] DrivingLicence drivingLicence)
        {
            if (!ModelState.IsValid || drivingLicence is null)
            {
                return BadRequest(ModelState);
            }

            if (personId == string.Empty || personId is null)
            {
                return BadRequest("personId is empty");
            }

            var person = _context.Persons.Where(x => x.Id == personId).FirstOrDefault();
            if (person == null)
            {
                return BadRequest($"Person with id {personId} could not be found!");
            }

            var license = await _context.DrivingLicences.AddAsync(drivingLicence).ConfigureAwait(false);
            var newLicenseEntity = license.Entity;
            if (newLicenseEntity is null)
            {
                throw new ArgumentException("Error");
            }

            var driver = new Driver()
            {
                IdDrivinglicense = newLicenseEntity.Id,
                IdPerson = personId
            };

            var newDriver = await _context.Drivers.AddAsync(driver).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return Ok(newDriver.Entity.Id);


        }
    }
}
