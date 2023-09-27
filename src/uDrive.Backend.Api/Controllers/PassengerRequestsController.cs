using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model.Entities;
using uDrive.Backend.Model;

using static System.Net.Mime.MediaTypeNames;
using static Microsoft.AspNetCore.Http.StatusCodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Packaging.Licenses;
using Microsoft.AspNetCore.Identity;
using uDrive.Backend.Model.DTO;
using uDrive.Backend.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Geolocation;

namespace uDrive.Backend.Api.Controllers;

/// <summary>
/// Controller to access and modify <see cref="PassengerRequest"/> Entities. 
/// Inherits from <see cref="PersonRoleController{TEntity}"/>.
/// </summary>
//[Produces(Application.Json)]
//[Consumes(Application.Json)]
//[Route("[controller]")]
//[ApiController]
//[Authorize(Roles = $"{UDriveRoles.Secretary},{UDriveRoles.Administrator},{UDriveRoles.Driver},{UDriveRoles.Person}")]

public class PassengerRequestsController : PersonRoleController<PassengerRequest>
{
    /// <inheritdoc />
    private readonly IAuthService _authService;

    /// <inheritdoc />
    private static ApplicationDbContext _context;


    /// <summary>
    /// internal queryable list of <see cref="TourPlan"/>
    /// </summary>
    public IQueryable<PassengerRequest> Entities => _context.Set<PassengerRequest>().AsQueryable();

    /// <inheritdoc />
    public PassengerRequestsController(
    ILogger<PassengerRequestsController> logger,
    ApplicationDbContext context,
    IAuthService authService
) : base(logger, context, authService)
    {
        _authService = authService;
        _context = context;
    }


    /// <summary>
    /// Queryable collection of <see cref="PassengerRequest"/>.
    /// </summary>
    /// <returns>
    /// Queryable collection of <see cref="PassengerRequest"/>.
    /// </returns>
    /// <response code="200">Returns a queryable collection of <see cref="PassengerRequest"/>.</response>
    [HttpGet]
    [ProducesResponseType(Status200OK)]
    public override async ValueTask<ActionResult<IQueryable<PassengerRequest>>> GetAsync()
    {
        var person = await _authService.GetLogedInPerson(HttpContext).ConfigureAwait(false);
        if (person is null)
        {
            return BadRequest();
        }


        var result = Entities.Where(x => x.IdPerson == person.Id).ToList();


        return Ok(result);
    }


    /// <summary>
    /// Searched entity.
    /// </summary>
    /// <param name="id">id of the searched entity.</param>
    /// <returns>Searched entity.</returns>
    /// <response code="200">Returns a queryable item of <see cref="PassengerRequest"/>.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public override async ValueTask<ActionResult<PassengerRequest>> GetByIdAsync(string id)
    {
        var person = await _authService.GetLogedInPerson(HttpContext).ConfigureAwait(false);
        if (person is null)
        {
            return BadRequest();
        }


        var result = Entities.Where(x => x.IdPerson == person.Id).ToList();

        if (id == string.Empty)
        {
            return BadRequest("Id is empty");
        }

        var entity = result.SingleOrDefault(x => x.Id == id);
        if (entity is null)
        {
            return NotFound($"Entity with Id '{id}' not found");
        }
        return entity;
    }

    /// <summary>
    /// Creates a new item, and returns the created item with the correct id.
    /// </summary>
    /// <param name="entity">Model to be inserted.</param>
    /// <response code="201">Return the newly created item.</response>
    /// <response code="400">If the model is not correct.</response>
    /// <returns>The newly created item.</returns>
    [HttpPost]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    public override async ValueTask<ActionResult<PassengerRequest>> PostAsync([FromBody] PassengerRequest entity)
    {
        if (!ModelState.IsValid || entity is null)
        {

            return BadRequest(ModelState);
        }

        if (entity.Id != null)
        {
            return BadRequest("The Id property must not be set.");
        }
        var person = await _authService.GetLogedInPerson(HttpContext).ConfigureAwait(false);
        if (person is null)
        {
            return BadRequest();
        }


        entity.IdPerson = person.Id;

        var save = await _context.Set<PassengerRequest>().AddAsync(entity).ConfigureAwait(false);
        await _context.SaveChangesAsync();
        return Ok(save.Entity);
    }



    /// <summary>
    /// Deletes the entity with the <paramref name="key"/>.
    /// </summary>
    /// <param name="key">Key of the entity to be deleted.</param>
    /// <response code="204">If the model could be deleted correctly.</response>
    /// <response code="400">If the model is not correct.</response>
    /// <response code="404">If the model could not be found.</response>
    [HttpDelete("{key}")]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public override async ValueTask<ActionResult> DeleteAsync([FromRoute] string key)
    {

        if (key == string.Empty)
        {
            return BadRequest("The Id must be set.");
        }

        var person = await _authService.GetLogedInPerson(HttpContext).ConfigureAwait(false);
        if (person is null)
        {
            return BadRequest();
        }

        var savedEntity = person.PassengerRequests.SingleOrDefault(x => x.Id == key);

        if (savedEntity == null)
        {
            return NotFound($"{nameof(TourPlan)} with id {key} not found");
        }
        _ = _context.Set<PassengerRequest>().Remove(savedEntity);
        await _context.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Gets a list of <see cref="PassengerRequest"/>
    /// </summary>
    /// <returns>
    /// <code>
    /// {
    ///   "id": "id",
    ///   "idPerson": "idPerson",
    ///   "idTourPlan": "idTourPlan",
    ///   "message": "Stehe an der Ecke",
    ///   "currentLatitude": 0,
    ///   "currentLongitude": 0,
    ///   "isPending": true,
    ///   "isDenied": false,
    ///   "person": {
    ///       "firstname": "Passenger1_Firstname",
    ///       "lastname": "Lastname_Passenger1",
    ///       "verified": true,
    ///       "drivers": [],
    ///       "asPassengers": [],
    ///       "passengerRequests": [
    ///           null
    ///       ],
    ///       "id": "id",
    ///       "userName": "Passenger1@udrive.de",
    ///       "normalizedUserName": "PASSENGER1@UDRIVE.DE",
    ///       "email": "Passenger1@udrive.de",
    ///       "normalizedEmail": "PASSENGER1@UDRIVE.DE",
    ///       "emailConfirmed": true,
    ///       "passwordHash": "",
    ///       "securityStamp": "",
    ///       "concurrencyStamp": "",
    ///       "phoneNumber": "number",
    ///       "phoneNumberConfirmed": true,
    ///       "twoFactorEnabled": false,
    ///       "lockoutEnd": null,
    ///       "lockoutEnabled": true,
    ///       "accessFailedCount": 0
    ///   },
    ///   "tourPlan": null
    ///}
    /// </code>
    /// </returns>
    [HttpGet("GetPassengerRequests")]
    [ProducesResponseType(Status200OK)]
    [ProducesResponseType(Status400BadRequest)]
    [ProducesResponseType(Status404NotFound)]
    public async ValueTask<ActionResult<IList<PassengerRequest>>> GetPassengerRequestsAsync()
    {

        var driver = await _authService.GetLogedInPerson(HttpContext).ConfigureAwait(false);
        if (driver is null)
        {
            return BadRequest();
        }
        var extend = _context.Persons.Where(x => x.Id == driver.Id).AsTracking()
            .Include(driver => driver.Driver)
            .ThenInclude(tourplan => tourplan.TourPlans)
            .ThenInclude(passReq => passReq.PassengerRequests)
            .ThenInclude(per => per.Person);
        if (!extend.Any())
        {
            return NoContent();
        }

        var requests = extend.Select(x => x.Driver.TourPlans.SelectMany(x => x.PassengerRequests).Where(x => x.IsPending));
        if (!requests.Any())
        {
            return NoContent();
        }

        return Ok(requests);
    }

    /// <summary>
    /// Allows the <see cref="Driver"/> to Accept a <see cref="PassengerRequest"/>
    /// It sets the <see cref="PassengerRequest.IsPending"/> to <see cref="Boolean.TrueString"/> and the <see cref="PassengerRequest.IsDenied"/> stays at <see cref="Boolean.FalseString"/>
    /// </summary>
    /// <param name="passengerRequest">
    /// <code>
    /// {
    ///     "idPerson": "idPerson",
    ///     "idTourPlan": "idTourPlan",
    ///     "message": "Stehe an der Ecke",
    ///     "currentLatitude": 0,
    ///     "currentLongitude": 0
    /// }
    ///</code>
    /// </param>
    /// <returns><see cref="Status200OK"/></returns>
    [HttpPut("AcceptRequest")]
    public async ValueTask<ActionResult> AcceptRequestAsync([FromBody] PassengerRequest passengerRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var driver = await _authService.GetLogedInPerson(HttpContext).ConfigureAwait(false);
        if (driver is null)
        {
            return BadRequest();
        }

        using var dbTransaction = _context.Database.BeginTransaction();

        passengerRequest.IsDenied = false;
        passengerRequest.IsPending = false;

        var tourplan = _context.TourPlans.Where(x => x.Id == passengerRequest.IdTourPlan).FirstOrDefault();

        if (tourplan is null)
        {
            return BadRequest($"TourPlan with id {passengerRequest.IdTourPlan} not found");
        }

        var passenger = _context.Persons.Where(x => x.Id != passengerRequest.IdPerson).FirstOrDefault();

        if (passenger is null)
        {
            return BadRequest($"Person with id {passengerRequest.IdPerson} not found");
        }

        passenger.AsPassengers.Add(tourplan);

        await dbTransaction.CommitAsync().ConfigureAwait(false);

        return Ok();
    }

    /// <summary>
    /// Allows the <see cref="Driver"/> to Deny a <see cref="PassengerRequest"/>
    /// It sets the <see cref="PassengerRequest.IsPending"/> to <see cref="Boolean.TrueString"/> and the <see cref="PassengerRequest.IsDenied"/> to <see cref="Boolean.TrueString"/>
    /// </summary>
    /// <param name="passengerRequest">
    /// <code>
    /// {
    ///     "idPerson": "idPerson",
    ///     "idTourPlan": "idTourPlan",
    ///     "message": "Stehe an der Ecke",
    ///     "currentLatitude": 0,
    ///     "currentLongitude": 0
    /// }
    ///</code>
    /// </param>
    /// <returns><see cref="Status200OK"/></returns>
    [HttpPut("DenyRequest")]
    public async ValueTask<ActionResult> DenyRequestAsync([FromBody] PassengerRequest passengerRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var driver = await _authService.GetLogedInPerson(HttpContext).ConfigureAwait(false);
        if (driver is null)
        {
            return BadRequest();
        }

        using var dbTransaction = _context.Database.BeginTransaction();

        passengerRequest.IsDenied = true;
        passengerRequest.IsPending = false;


        await dbTransaction.CommitAsync().ConfigureAwait(false);

        return Ok();
    }


    /// <summary>
    /// Gets all Drivers, who are at a tour
    /// </summary>
    /// <returns><see cref="List{T}"/> of <see cref="Driver"/> entities</returns>
    [HttpGet("GetScheduledDrivers")]
    public async ValueTask<ActionResult<Driver>> GetScheduledDriversAsync()
    {
        var res = _context.Drivers.AsTracking().Include(tours => tours.TourPlans).AsQueryable();
        var pes = res.Where(x => x.TourPlans.Any()).ToList();
        return Ok(pes);
    }

    /// <summary>
    /// Find drivers, who are in 5 km range
    /// </summary>
    /// <param name="dto">
    /// <code>
    /// {
    /// "currentLatitude": 50.08486509467797, 
    /// "currentLongitude": 8.458661956343363,
    /// "coordinates": "string"
    ///}
    ///</code></param>
    /// <returns>
    /// <code>
    /// [
    ///    {
    ///       "distance": 0.26,
    ///       "firstname": "Firstname_Test2",
    ///       "lastname": "Lastname_Test2",
    ///       "userName": "TestDriver2@udrive.de",
    ///       "idPerson": "ddebddc1-8747-42a8-896c-06563b280c12",
    ///       "driver": {
    ///           "id": "94bb701a-cc1c-42ce-9e98-02ae06809910",
    ///           "idDrivinglicense": "433640da-6279-4c25-a6e8-c54219399a4b",
    ///           "idPerson": "ddebddc1-8747-42a8-896c-06563b280c12",
    ///           "seats": 2,
    ///           "idDrivinglicenseNavigation": null,
    ///           "idPersonNavigation": null,
    ///           "tourPlans": []
    ///   },
    ///       "tourPlan": {
    ///           "id": "9141c66b-98bd-458c-9248-80658988f097",
    ///           "idDriver": "94bb701a-cc1c-42ce-9e98-02ae06809910",
    ///           "departure": "2023-09-25T17:52:12.257",
    ///           "stopRequests": 0,
    ///           "eta": "00:15:00",
    ///           "start": "string",
    ///           "destination": "string",
    ///           "message": "string",
    ///           "currentCoordinates": "string",
    ///           "currentLatitude": 50.08513701910111,
    ///           "currentLongitude": 8.452825469725695,
    ///           "driver": {
    ///               ...
    ///           },
    ///           "passengers": []
    ///       }
    ///   }
    ///]
    /// </code></returns>
    [HttpPost("FilterDriversBy5kmRadius")]
    public async ValueTask<ActionResult<DriversInRangeDTO>> FilterDriversBy5kmRadiusAsync([FromBody] GeocoordinatesDTO dto)
    => await GetDriversBy5kmRadiusAsync(dto,DateTime.Now).ConfigureAwait(false);

    [HttpPost("FilterDriversBy5kmRadius/{days}")]
    public async ValueTask<ActionResult<DriversInRangeDTO>> FilterDriversBy5kmRadiusAtDaysAsync([FromBody] GeocoordinatesDTO dto, int days)
   => await GetDriversBy5kmRadiusAsync(dto, DateTime.Now.AddDays(days)).ConfigureAwait(false);


    private async ValueTask<ActionResult<DriversInRangeDTO>> GetDriversBy5kmRadiusAsync(GeocoordinatesDTO dto, DateTime today)
    {
        var getDrivers = _context.Drivers.AsTracking().Include(tour => tour.TourPlans).Where(x => x.TourPlans != null);
        if (!getDrivers.Any())
        {
            return NoContent(/*"No planned tours found"*/);
        }
        var todaysDriver = getDrivers.Where(x => x.TourPlans.Where(o => o.Departure.Date == today.Date).Any());
        if (!todaysDriver.Any())
        {
            return NoContent(/*"No driver for the current date found"*/);
        }

        var toursInRange = new List<(bool inRange, double distance, TourPlan driverTourPlan)>();

        foreach (var driver in todaysDriver)
        {
            foreach (var tour in driver.TourPlans)
            {
                if (tour.Departure.Date == today.Date)
                {
                    var match = MatchDistance(tour, dto, 5);
                    if (match.inRange)
                    {
                        if (tour.Passengers is not null)
                        {
                            if (tour.Passengers.Any())
                            {
                                if (driver.Seats >= tour.Passengers.Count())
                                {
                                    break;
                                }
                            }
                        }

                        toursInRange.Add(match);
                    }
                }
            }
        }

        if (!toursInRange.Any())
        {
            return NoContent(/*"No driver in range found"*/);
        }

        var response = new List<DriversInRangeDTO>();
        foreach (var tour in toursInRange)
        {
            var driver = _context.Drivers.Where(x => x.Id == tour.driverTourPlan.IdDriver).AsNoTracking().FirstOrDefault();
            if (driver is null)
            {
                return NoContent();
            }
            var person = _context.Persons.Where(x => x.Id == driver.IdPerson).AsNoTracking().FirstOrDefault();
            if (person is null)
            {
                return NoContent();
            }

            response.Add(new DriversInRangeDTO()
            {
                Distance = tour.distance,
                Person = person,
                Driver = driver,
                TourPlan = tour.driverTourPlan
            });
        }
        return Ok(response);
    }


    /// <summary>
    /// Calculates the Distance between the <see cref="Driver"/> and the <see cref="Person"/>
    /// </summary>
    /// <param name="driverTourPlan">The selected <see cref="TourPlan"/></param>
    /// <param name="personPosition">The position of the <see cref="Person"/>, saved at <see cref="GeocoordinatesDTO"/></param>
    /// <param name="maxRadius">The maximum distance between <see cref="Driver"/> and <see cref="Person"/></param>
    /// <returns>
    /// Returns a tuple, at which inRange indicates if they are inside the maximum radius, distance the calculated distance and the sended <see cref="TourPlan"/>
    /// </returns>
    private (bool inRange, double distance, TourPlan driverTourPlan) MatchDistance(TourPlan driverTourPlan, GeocoordinatesDTO personPosition, int maxRadius)
    {
        Coordinate driverPosition = new Coordinate(driverTourPlan.CurrentLatitude, driverTourPlan.CurrentLongitude);
        Coordinate personCurrentPosition = new Coordinate(personPosition.CurrentLatitude, personPosition.CurrentLongitude);
        double distance = GeoCalculator.GetDistance(driverPosition, personCurrentPosition, 2);
        return (distance <= maxRadius, distance, driverTourPlan);

    }
}



