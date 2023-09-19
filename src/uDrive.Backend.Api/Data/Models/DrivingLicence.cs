using System;
using System.Collections.Generic;

namespace uDrive.Backend.Api.Data.Models;

public class DrivingLicence : IEntity
{
    public string Id { get; set; } = null!;

    public DateTime ExpireDate { get; set; }

    public string LicenceClass { get; set; } = null!;

    public virtual ICollection<Driver> Drivers { get;} = new List<Driver>();
}
