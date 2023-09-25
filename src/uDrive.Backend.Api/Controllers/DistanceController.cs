using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model;
using uDrive.Backend.Model.DTO;
using Geolocation;
using static System.Net.Mime.MediaTypeNames;

namespace uDrive.Backend.Api.Controllers;

[Produces(Application.Json)]
[Consumes(Application.Json)]
[Route("[controller]")]
[ApiController]
public class DistanceController : ControllerBase //TODO : change after testing to an exsiting model
{
    protected ILogger _logger;
    private static ApplicationDbContext _context;
    //public IQueryable<TEntity> Entities => _context.Set<TEntity>().AsQueryable(); // TODO

    public DistanceController(ILogger<DistanceController> logger, ApplicationDbContext context) // TODO
    {
        _logger = logger;
        _context = context;
    }


    //[HttpPost]
    //public async Task<IActionResult> GetAsync([FromBody] GeocoordinatesDTO dto)
    //{
    //    var driver = ConvertToLongitudeAndLattiude(dto.DriverPos);
        
    //    var person = ConvertToLongitudeAndLattiude(dto.PersonPos);
    //    Coordinate origin = new Coordinate(driver.longitude,driver.lattiude);
    //    Coordinate destination = new Coordinate(person.longitude, person.lattiude);
    //    double distance = GeoCalculator.GetDistance(origin, destination, 2);
    //    return Ok(distance);

    //}

    [Obsolete("to be deleted")]
    private (double longitude, double lattiude ) ConvertToLongitudeAndLattiude(string val)
    {
        var split = val.Split(',');
        return (double.Parse(split[0], System.Globalization.CultureInfo.InvariantCulture), double.Parse(split[1],System.Globalization.CultureInfo.InvariantCulture));
    }
}
