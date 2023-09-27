using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uDrive.Backend.Api.Test.Integration.Abstractions;
using uDrive.Backend.Model.DTO;

namespace uDrive.Backend.Api.Test.Integration.Controllers
{

    public sealed class DrivingLicencesControllerTests
    : SecretaryRoleControllerTestBase<DrivingLicencesController, DrivingLicence>
    {
        protected override DrivingLicence ProvideModelValidComplete()
       => new DrivingLicence
       {
           ExpireDate = DateTime.Now.AddMonths(2),
           LicenceClass = "Z"           
       };
    }
}
