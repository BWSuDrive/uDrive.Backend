using System.Collections.ObjectModel;

namespace uDrive.Backend.Model.Entities;


/// <summary>
/// Entity of TourPlan
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
    /// TODO : please explain
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

    public virtual ICollection<Person> Passengers { get; } = new Collection<Person>();
    public virtual ICollection<PassengerRequest> PassengerRequests { get; } = new Collection<PassengerRequest>();


}
