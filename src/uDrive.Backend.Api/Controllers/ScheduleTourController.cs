using Geolocation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Api.Services.Interfaces;
using uDrive.Backend.Model;
using uDrive.Backend.Model.DTO;
using uDrive.Backend.Model.Entities;
using static System.Net.Mime.MediaTypeNames;
namespace uDrive.Backend.Api.Controllers;


[Authorize(Roles = $"{UDriveRoles.Secretary},{UDriveRoles.Administrator},{UDriveRoles.Driver},{UDriveRoles.Person}")]
[Produces(Application.Json)]
[Consumes(Application.Json)]
[Route("[controller]")]
[ApiController]
public class ScheduleTourController : ControllerBase
{
    protected ILogger _logger;

    private static ApplicationDbContext _context;
    public ScheduleTourController(ILogger<ScheduleTourController> logger, ApplicationDbContext context, IAuthService authService)
    {
        _logger = logger;
        _context = context;
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
    {

        var today = DateTime.Now;
        var getDrivers = _context.Drivers.AsTracking().Include(tour => tour.TourPlans).Where(x => x.TourPlans != null);
        if (!getDrivers.Any())
        {
            return NotFound("No planned tours found");
        }
        var todaysDriver = getDrivers.Where(x => x.TourPlans.Where(o => o.Departure.Date == today.Date).Any());
        if (!todaysDriver.Any())
        {
            return NotFound("No driver for the current date found");
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

                        toursInRange.Add(match); break;
                    }
                }
            }
        }

        if (!toursInRange.Any())
        {
            return NotFound("No driver in range found");
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

    //[HttpPost("RequestForTourAsPassenger/{personId}")]
    //public async ValueTask<ActionResult> RequestForTourAsPassenger([FromBody] PassengerRequest passengerRequest)
    //{
    //    if (!ModelState.IsValid)
    //    {
    //        return BadRequest(ModelState);
    //    }

    //    _ = await _context.PassengerRequests.AddAsync(passengerRequest).ConfigureAwait(false);

    //    //var findTour = await _context.TourPlans.Where(x => x.Id == passengerRequest.idTourPlan).FirstOrDefaultAsync().ConfigureAwait(false);

    //    //if (findTour is null)
    //    //{
    //    //    return BadRequest();
    //    //}

    //    //var person = await _context.Persons.Where(x => x.Id == passengerRequest.idPerson).FirstOrDefaultAsync().ConfigureAwait(false);

    //    //if (person is null)
    //    //{
    //    //    return BadRequest($"{passengerRequest.idPerson} not found");
    //    //}

    //    ////person.AsPassengers.Add(findTour);
    //    ////findTour.Passengers.Add(person);
    //    _= await _context.SaveChangesAsync().ConfigureAwait(false);
    //    return Ok();

    //}


    private (bool inRange, double distance, TourPlan driverTourPlan) MatchDistance(TourPlan driverTourPlan, GeocoordinatesDTO personPosition, int maxRadius)
    {
        Coordinate driverPosition = new Coordinate(driverTourPlan.CurrentLatitude, driverTourPlan.CurrentLongitude);
        Coordinate personCurrentPosition = new Coordinate(personPosition.CurrentLatitude, personPosition.CurrentLongitude);
        double distance = GeoCalculator.GetDistance(driverPosition, personCurrentPosition, 2);
        return (distance < maxRadius, distance, driverTourPlan);

    }

}
