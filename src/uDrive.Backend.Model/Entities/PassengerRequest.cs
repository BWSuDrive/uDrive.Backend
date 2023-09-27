namespace uDrive.Backend.Model.Entities;

/// <summary>
/// Request of an <see cref="Entities.Person"/> to an <see cref="Entities.Driver"/>
/// </summary>
public class PassengerRequest : IEntity
{
    /// <inheritdoc />
    public string? Id { get; set; }
    
    /// <summary>
    /// Id of the requesting <see cref="Entities.Person"/>
    /// </summary>
    public string IdPerson { get; set; }

    /// <summary>
    /// Id of the <see cref="Entities.TourPlan"/>, who the <see cref="Entities.Person"/> requested for
    /// </summary>
    public string IdTourPlan { get; set; }

    /// <summary>
    /// Customized message of the requesting <see cref="Entities.Person"/>
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// The current Latitude
    /// </summary>
    public double CurrentLatitude { get; set; }

    /// <summary>
    /// The current Longitude
    /// </summary>
    public double CurrentLongitude { get; set; }

    /// <summary>
    /// Defines, if the request is pending
    /// </summary>
    public bool IsPending { get; set; } = true;

    /// <summary>
    /// Defines, if the request was denied or not
    /// </summary>
    public bool IsDenied { get; set; } = false;

    /// <summary>
    /// Corresponding <see cref="Entities.Person"/> Entity, given by <see cref="IdPerson"/>
    /// </summary>
    public virtual Person? Person { get; }

    /// <summary>
    /// Corresponding <see cref="Entities.TourPlan+"/> Entity, given by <see cref="IdTourPlan"/>
    /// </summary>
    public virtual TourPlan? TourPlan { get; }

}
