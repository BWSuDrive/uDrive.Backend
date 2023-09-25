using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uDrive.Backend.Model.DTO;

public class GeocoordinatesDTO
{
    //public string DriverPos { get; set; }
    //public string PersonPos { get; set; }

    /// <summary>
    /// The current Latitude
    /// </summary>
    public double CurrentLatitude { get; set; }

    /// <summary>
    /// The current Longitude
    /// </summary>
    public double CurrentLongitude { get; set; }

    public string? Coordinates { get; set; }
}
