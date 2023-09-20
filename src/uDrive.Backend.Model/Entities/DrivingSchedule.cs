using System;
using System.Collections.Generic;

namespace uDrive.Backend.Model.Entities;

public class DrivingSchedule : IEntity
{
    public string? Id { get; set; } 

    public TimeSpan Start { get; set; }

    public TimeSpan Arrival { get; set; }

    public string IdWeekday { get; set; } = null!;

    public virtual Weekday IdWeekdayNavigation { get; set; } = null!;

    public virtual ICollection<SpontanesDrive> SpontanesDrives { get; } = new List<SpontanesDrive>();

    public virtual ICollection<Driver> Drivers { get; } = new List<Driver>();
}
