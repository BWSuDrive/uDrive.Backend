using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;

namespace uDrive.Backend.Model.Entities;

/// <summary>
/// A <see cref="Person"/> is a <see cref="IdentityUser"/> who can use the app. All Users are a <see cref="Person"/>
/// </summary>
public class Person : IdentityUser
{

    /// <summary>
    /// Firstname of the registered Person
    /// </summary>
    public string Firstname { get; set; } = null!;

    /// <summary>
    /// Lastname of the registered Person
    /// </summary>
    public string Lastname { get; set; } = null!;

    /// <summary>
    /// Defines, if an <see cref="Person"/> is verified to use the app
    /// </summary>
    public bool Verified { get; set; } = false;

    /// <summary>
    /// The corresponding <see cref="Entities.Driver"/> 
    /// </summary>
    public virtual Driver? Driver { get; } = default;

    /// <summary>
    /// Collection of connected <see cref="Entities.TourPlan"/>, where the person was an passenger
    /// </summary>
    public virtual ICollection<TourPlan> AsPassengers { get;} = new Collection<TourPlan>();

    /// <summary>
    /// Collection of <see cref="Entities.PassengerRequest"/>, which the <see cref="Person"/> send to an <see cref="Entities.Driver"/>
    /// </summary>
    public virtual ICollection<PassengerRequest> PassengerRequests{ get; } = new Collection<PassengerRequest>();

}
