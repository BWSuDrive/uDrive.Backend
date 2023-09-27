//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using uDrive.Backend.Api.Test.Integration.Abstractions;
//using uDrive.Backend.Model.DTO;

//namespace uDrive.Backend.Api.Test.Integration.Controllers
//{

//    public sealed class TourPlansControllerTests
//    : DriverRoleControllerTestBase<TourPlansController, TourPlan>
//    {
        
//        protected override TourPlan ProvideModelValidComplete()
//       => new TourPlan
//       {
//           ExpireDate = new DateTime(2024, 12, 30, 0, 0, 0, DateTimeKind.Utc),
//           LicenceClass = "Z"           
//       };

//        //protected override Expression<Func<DrivingLicence, object>> ProvideRequiredProperty() => model => model.ExpireDate;

//    }
//}
