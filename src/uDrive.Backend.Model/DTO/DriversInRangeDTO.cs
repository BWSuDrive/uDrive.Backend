using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uDrive.Backend.Model.Entities;

namespace uDrive.Backend.Model.DTO;

public class DriversInRangeDTO
{
    public double Distance { get; set; }
    public Person Person { get; set; }
    public Driver Driver { get; set; }
    public TourPlan TourPlan { get; set; }
}
