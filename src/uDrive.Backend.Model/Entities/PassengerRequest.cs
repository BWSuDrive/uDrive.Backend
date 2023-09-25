using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uDrive.Backend.Model.Entities;

public class PassengerRequest : IEntity
{
    public string? Id { get; set; }
    
    public string idPerson { get; set; }

    public string idTourPlan { get; set; }
    public string? Message { get; set; }

    /// <summary>
    /// The current Latitude
    /// </summary>
    public double CurrentLatitude { get; set; }

    /// <summary>
    /// The current Longitude
    /// </summary>
    public double CurrentLongitude { get; set; }

    public virtual Person? Person { get; }

    public virtual TourPlan? TourPlan { get; }

}
