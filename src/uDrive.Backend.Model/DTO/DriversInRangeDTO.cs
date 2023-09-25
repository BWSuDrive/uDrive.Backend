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
    /// <summary>
    /// Firstname of the registered Person
    /// </summary>
    //public string Firstname { get; set; } = null!;

    ///// <summary>
    ///// Lastname of the registered Person
    ///// </summary>
    //public string Lastname { get; set; } = null!;

    //public string UserName { get; set; } = null!;
    //public string idPerson { get; set; } = null!;
    public Person Person { get; set; }
    public Driver Driver { get; set; }
    public TourPlan TourPlan { get; set; }
}
