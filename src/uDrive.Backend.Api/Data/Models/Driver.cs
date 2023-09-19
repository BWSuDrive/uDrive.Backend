using System;
using System.Collections.Generic;
using uDrive.Backend.Api.Data;

namespace uDrive.Backend.Api.Data.Models;

public class Driver : IEntity
{
    public string Id { get; set; } = null!;

    public string IdDrivinglicense { get; set; } = null!;

    public string IdPerson { get; set; } = null!;

    public virtual DrivingLicence IdDrivinglicenseNavigation { get; set; } = null!;

    public virtual Person IdPersonNavigation { get; set; } = null!;

    public virtual ICollection<DrivingSchedule> DrivingSchedules { get;} = new List<DrivingSchedule>();
}
