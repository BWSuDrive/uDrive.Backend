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
    public abstract class AdministratorRoleControllerTestBase<TController, TEntity> : SecretaryRoleControllerTestBase<TController, TEntity>
    where TController : AdministratorRoleController<TEntity>
    where TEntity : class, IEntity
    {
        protected override SignInUserDTO ProvideCredentials()
       =>
            new SignInUserDTO()
            {
                Email = "Administrator@udrive.de",
                Password = "AdministratorSTrongPassword!2345",
                UserName = "Administrator@udrive.de",

            };

    }
}
