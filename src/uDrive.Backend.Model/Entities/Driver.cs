namespace uDrive.Backend.Model.Entities;

/// <summary>
/// The <see cref="Driver"/> object. 
/// A Driver is a <see cref="Person"/>, who successfully was registered as an Driver. He can schedule a <see cref="TourPlan"/> and he/she needs a <see cref="DrivingLicence"/>
/// </summary>
public class Driver : IEntity
{
    /// <inheritdoc />
    public string? Id { get; set; }

    /// <summary>
    /// Id of the corresponding <see cref="Entities.DrivingLicence"/>
    /// </summary>
    public string IdDrivinglicense { get; set; } = null!;

    /// <summary>
    /// Id of the corresponding <see cref="Entities.Person"/>
    /// </summary>
    public string IdPerson { get; set; } = null!;

    /// <summary>
    /// Amount of seats
    /// </summary>
    public int Seats { get; set; }

    /// <summary>
    /// Entity of <see cref="Entities.DrivingLicence"/>, given by <see cref="IdDrivinglicense"/>
    /// </summary>
    public virtual DrivingLicence? IdDrivinglicenseNavigation { get; set; } 

    /// <summary>
    /// Entity of <see cref="Entities.Person"/>, given by <see cref="IdPerson"/>
    /// </summary>
    public virtual Person? IdPersonNavigation { get; set; } 


    /// <summary>
    /// Collection of <see cref="TourPlan"/>, wo can saved and deleted
    /// </summary>
    public virtual ICollection<TourPlan> TourPlans { get; } = new List<TourPlan>();

}
