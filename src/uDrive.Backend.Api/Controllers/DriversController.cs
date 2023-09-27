using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model.Entities;
using uDrive.Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using uDrive.Backend.Model.DTO;
using Geolocation;
using uDrive.Backend.Api.Services.Interfaces;

namespace uDrive.Backend.Api.Controllers
{
    /// <summary>
    /// Controller to access and modify <see cref="Driver"/> Entities. 
    /// Inherits from <see cref="SecretaryRoleController{TEntity}"/>.
    /// </summary>
    public class DriversController : SecretaryRoleController<Driver>
    {
        /// <summary>
        /// internal <see cref="DbContext"/> reference
        /// </summary>
        private static ApplicationDbContext _context;

        /// <summary>
        /// internal reference to <see cref="IAuthService"/>
        /// </summary>
        private readonly IAuthService _authService;

        /// <inheritdoc />
        public DriversController(
        ILogger<DriversController> logger,
        ApplicationDbContext context, IAuthService authService
    )
        : base(logger, context, authService)
        {
            _authService = authService;
            _context = context;
        }


       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personId">Id of the <see cref="Person"/></param>
        /// <param name="drivingLicence"><see cref="IEntity"/><see cref="DrivingLicence"/></param>
        /// <returns><see cref="List{T}"/> of <see cref="Driver"/>
        /// <code>
        /// [
        ///    {
        ///       "id": "01d3f9da-c371-4c79-bc48-d57c2b90f4b7",
        ///        "idDrivinglicense": "a1a2e759-ed78-43f8-aef6-e34e50957196",
        ///        "idPerson": "601fee53-202a-400d-8d59-5c9772c7fdae",
        ///        "idDrivinglicenseNavigation": null,
        ///        "idPersonNavigation": null,
        ///        "drivingSchedules": [],
        ///        "tourPlans": []
        ///    }
        ///]
        /// </code>
        /// </returns>
        /// <exception cref="ArgumentException"></exception>
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
            if(!await _authService.AssignPersonToRoleAsync(person,"Driver").ConfigureAwait(false))
            {
                throw new ArgumentException();
            }
            var newDriver = await _context.Drivers.AddAsync(driver).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return Ok(newDriver.Entity.Id);
        }


    }
}
