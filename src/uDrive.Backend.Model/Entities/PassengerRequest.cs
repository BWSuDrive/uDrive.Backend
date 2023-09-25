using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uDrive.Backend.Model.Entities;

public class PassengerRequest : IEntity
{
    public string? Id { get; set; }
    
    public string IdPerson { get; set; }

    public string IdTourPlan { get; set; }
    public string? Message { get; set; }

    /// <summary>
    /// The current Latitude
    /// </summary>
    public double CurrentLatitude { get; set; }

    /// <summary>
    /// The current Longitude
    /// </summary>
    public double CurrentLongitude { get; set; }

    public bool IsPending { get; set; } = true;

    public bool IsDenied { get; set; } = false;

    public virtual Person? Person { get; }

    public virtual TourPlan? TourPlan { get; }

}
