using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model;
using uDrive.Backend.Model.DTO;

namespace uDrive.Backend.Api.Test.Integration.Abstractions
{
    public abstract class DriverRoleControllerTestBase<TController, TEntity> : PersonRoleControllerTestBase<TController, TEntity>
    where TController : DriverRoleController<TEntity>
    where TEntity : class, IEntity
    {
        protected override SignInUserDTO ProvideCredentials()
       =>
            new SignInUserDTO()
            {
                Email = "Driver@udrive.de",
                Password = "DriverSTrongPassword!2345",
                UserName = "Driver@udrive.de",

            };

    }
}
