using System.Collections.ObjectModel;

namespace uDrive.Backend.Model.Entities;


/// <summary>
/// Entity of TourPlan
/// A TourPlan is a scheduled ride, from <see cref="Start"/> to <see cref="Destination"/>.
/// A <see cref="Person"/> can request via an <see cref="PassengerRequest"/> to be an passenger
/// </summary>
public class TourPlan : IEntity
{
    public string? Id { get; set; }

    /// <summary>
    /// <see cref="Entities.Driver.Id"/> of the current <see cref="Entities.Driver"/> 
    /// </summary>
    public string IdDriver { get; set; } = null!;

    /// <summary>
    /// Date and Time of the start of the current <see cref="TourPlan"/>
    /// </summary>
    public DateTime Departure { get; set; }

    /// <summary>
    /// Minutes before no one can request to be an passenger
    /// </summary>
    public int? StopRequests { get; set; }

    /// <summary>
    /// Estimated traveling time
    /// </summary>
    public TimeSpan Eta { get; set; }

    /// <summary>
    /// Start position as plain Text
    /// </summary>
    public string Start { get; set; } = default!;

    /// <summary>
    /// Destination Position as plain Text
    /// </summary>
    public string Destination { get; set; } = default!;

    /// <summary>
    /// Customized Message from the <see cref="Entities.Driver"/> 
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// The current Latitude
    /// </summary>
    public double  CurrentLatitude { get; set; }

    /// <summary>
    /// The current Longitude
    /// </summary>
    public double  CurrentLongitude { get; set; }


    /// <summary>
    /// Linked <see cref="Entities.Driver"/> given by <see cref="IdDriver"/>
    /// </summary>
    public virtual Driver? Driver { get; set; } = null!;

    /// <summary>
    /// Collection of <see cref="Entities.Person"/> as passengers for the current ride
    /// </summary>
    public virtual ICollection<Person> Passengers { get; } = new Collection<Person>();

    /// <summary>
    /// Collection of <see cref="PassengerRequest"/> for the current ride
    /// </summary>
    public virtual ICollection<PassengerRequest> PassengerRequests { get; } = new Collection<PassengerRequest>();


}
