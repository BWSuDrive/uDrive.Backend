using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model;
using uDrive.Backend.Model.DTO;

namespace uDrive.Backend.Api.Test.Integration.Abstractions
{
    public abstract class SecretaryRoleControllerTestBase<TController, TEntity> : DriverRoleControllerTestBase<TController, TEntity>
    where TController : SecretaryRoleController<TEntity>
    where TEntity : class, IEntity
    {
        protected override SignInUserDTO ProvideCredentials()
       =>
            new SignInUserDTO()
            {
                Email = "Secretary@udrive.de",
                Password = "SecretarySTrongPassword!2345",
                UserName = "Secretary@udrive.de",

            };



       
    }
}
