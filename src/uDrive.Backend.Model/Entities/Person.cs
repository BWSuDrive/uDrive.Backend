using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace uDrive.Backend.Model.Entities;

public class Person : IdentityUser
{

    //public string Id { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public bool Verified { get; set; } = false;

    public virtual ICollection<Driver> Drivers { get; } = new List<Driver>();
}
