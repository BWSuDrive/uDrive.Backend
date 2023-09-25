using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace uDrive.Backend.Model.Entities;

public class Person : IdentityUser
{

    //public string Id { get; set; } = null!;

    /// <summary>
    /// Firstname of the registered Person
    /// </summary>
    public string Firstname { get; set; } = null!;

    /// <summary>
    /// Lastname of the registered Person
    /// </summary>
    public string Lastname { get; set; } = null!;

    public bool Verified { get; set; } = false;

    public virtual ICollection<Driver> Drivers { get; } = new List<Driver>();

    public virtual ICollection<TourPlan> AsPassengers { get;} = new Collection<TourPlan>();
}
