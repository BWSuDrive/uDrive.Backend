using System;
using System.Collections.Generic;

namespace uDrive.Backend.Model.Entities;

public class SpontanesDrive : IEntity
{
    public string Id { get; set; } = null!;

    public DateTime? Date { get; set; }

    public string IdDrivingScheduleOverwrite { get; set; } = null!;

    public virtual DrivingSchedule IdDrivingScheduleOverwriteNavigation { get; set; } = null!;
}
