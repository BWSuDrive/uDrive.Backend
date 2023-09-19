using System;
using System.Collections.Generic;

namespace uDrive.Backend.Api.Data.Models;

public class Weekday : IEntity
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<DrivingSchedule> DrivingSchedules { get; } = new List<DrivingSchedule>();
}
