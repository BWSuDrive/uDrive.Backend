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


        protected override string ProvideNewRole() => UDriveRoles.Secretary;

        [Test]
        [Order(13)]
        public async Task GIveNewUserHigherRoleAsync()
        {
            var uri = ClientUriBuilder
            .Create()
            .AddSegments("Persons", "AddRoleToUser",ProvideNewRole(),NewUserId)
            .Build();
            using var request = new HttpRequestMessage(HttpMethod.Put, uri)
            {
            };
            var response = await AdminClient
                .SendAsync(request, HttpCompletionOption.ResponseContentRead)
                .ConfigureAwait(false);

            Assert.IsTrue(response.IsSuccessStatusCode);
        }


       
    }
}
