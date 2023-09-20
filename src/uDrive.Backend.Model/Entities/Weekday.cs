using System;
using System.Collections.Generic;

namespace uDrive.Backend.Model.Entities;

public class Weekday : IEntity
{
    public string? Id { get; set; } 

    public string Name { get; set; } = null!;

    public virtual ICollection<DrivingSchedule> DrivingSchedules { get; } = new List<DrivingSchedule>();
}
