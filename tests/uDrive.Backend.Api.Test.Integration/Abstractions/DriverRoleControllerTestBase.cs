using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using uDrive.Backend.Api.Controllers.Abstract;
using uDrive.Backend.Model;
using uDrive.Backend.Model.DTO;
using Argon;

namespace uDrive.Backend.Api.Test.Integration.Abstractions
{
    public abstract class DriverRoleControllerTestBase<TController, TEntity> : PersonRoleControllerTestBase<TController, TEntity>
    where TController : DriverRoleController<TEntity>
    where TEntity : class, IEntity
    {
        private static DrivingLicence Licence = new DrivingLicence
        {
            ExpireDate = new DateTime(2024, 12, 30, 0, 0, 0, DateTimeKind.Utc),
            LicenceClass = "X"
        };

        [Test]
        [Order(14)]
        public async Task SetNewUserAsDriver()
        {
            var uri = ClientUriBuilder
            .Create()
            .AddSegments("Drivers","AddDrivingLicenceWithNewDriver", NewUserId)
            .Build();

            var requestBody = Licence;

            using var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = JsonContent.Create(requestBody)
            };
            var response = await AdminClient
                .SendAsync(request, HttpCompletionOption.ResponseContentRead)
                .ConfigureAwait(false);
         
            await VerifyResponseAsync(HttpStatusCode.OK, response, requestBody)
                .ConfigureAwait(false);
        }

    }
}
