using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using uDrive.Backend.Api.Test.Integration.Abstractions;
using uDrive.Backend.Model.DTO;

namespace uDrive.Backend.Api.Test.Integration.Controllers
{

    public sealed class TourPlansControllerTests
    : DriverRoleControllerTestBase<TourPlansController, TourPlan>
    {

        protected override TourPlan ProvideModelValidComplete()
       => new TourPlan
       {
           IdDriver = "",
           CurrentLatitude = 0, CurrentLongitude = 0,
           Departure = DateTime.Now,
           Eta = new TimeSpan(00,00,10),
           Start = "Zuhause",
           Destination = "Schule",
           StopRequests = 0,
           Message = "Fahre gern zu zweit"

       };

        [Test]

        [Order(501)]
        public async Task DummyTour() => await POST_ValidModel_Expected_Result().ConfigureAwait(false);


    }
}
