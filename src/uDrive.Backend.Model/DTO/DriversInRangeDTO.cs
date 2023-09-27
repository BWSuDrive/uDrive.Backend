using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Model.DTO;

/// <summary>
/// DTO response after a search <see cref="Entities.Driver"/>, 
/// </summary>
public class DriversInRangeDTO
{
    /// <summary>
    /// The calculated distance
    /// </summary>
    public double Distance { get; set; }

    /// <summary>
    /// The <see cref="Entities.Person"/> object of the <see cref="Entities.Driver"/>
    /// </summary>
    public Person Person { get; set; }

    /// <summary>
    /// The <see cref="Entities.Driver"/> object of the found Driver
    /// </summary>
    public Driver Driver { get; set; }

    /// <summary>
    /// The <see cref="Entities.TourPlan"/> which is nearby the searching <see cref="Entities.Person"/>
    /// </summary>
    public TourPlan TourPlan { get; set; }
}
