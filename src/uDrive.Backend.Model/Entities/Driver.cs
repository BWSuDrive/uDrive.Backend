using System;
using System.Collections.Generic;

namespace uDrive.Backend.Model.Entities;

public class Driver : IEntity
{
    public string? Id { get; set; }

    public string IdDrivinglicense { get; set; } = null!;

    public string IdPerson { get; set; } = null!;

    public int Seats { get; set; }

    public virtual DrivingLicence? IdDrivinglicenseNavigation { get; set; } 

    public virtual Person? IdPersonNavigation { get; set; } 

    public virtual ICollection<TourPlan> TourPlans { get; } = new List<TourPlan>();

}
