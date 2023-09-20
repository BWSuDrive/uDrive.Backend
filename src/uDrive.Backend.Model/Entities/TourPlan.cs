using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uDrive.Backend.Model.Entities;

public class TourPlan : IEntity
{
    public string? Id { get; set; }
    public string IdDriver { get; set; } = null!;
    public DateTime Date { get; set; }
    public TimeSpan Departure { get; set; }
    public int StopRequests { get; set; }
    public TimeSpan Eta { get; set; }
    public string Start { get; set; }
    public string Destiniation { get; set; }
    public virtual Driver Driver { get; set; } = null!;

}
