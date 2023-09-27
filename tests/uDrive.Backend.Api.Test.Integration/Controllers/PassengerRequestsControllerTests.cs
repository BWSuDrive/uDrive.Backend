using Argon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using uDrive.Backend.Api.Test.Integration.Abstractions;
using uDrive.Backend.Model;
using uDrive.Backend.Model.DTO;

namespace uDrive.Backend.Api.Test.Integration.Controllers
{

    public sealed class PassengerRequestsControllerTests
    : PersonRoleControllerTestBase<PassengerRequestsController, PassengerRequest>
    {
        private string TourId = string.Empty;
        protected override PassengerRequest ProvideModelValidComplete()
       => new PassengerRequest
       {
           IdPerson = "",
           IdTourPlan = TourId,
           Message = "Will mit!!",
           CurrentLatitude = 0,
           CurrentLongitude = 0,

       };


        [Test]
        [Order(99)]
        public async Task GET_All_FilterDriversBy5kmRadius()
        {

            var uri = ClientUriBuilder
            .Create()
            .AddSegments("PassengerRequests", "FilterDriversBy5kmRadius")
            .Build();
            var requestBody = new GeocoordinatesDTO()
            {
                CurrentLatitude = 0,
                CurrentLongitude = 0,
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = JsonContent.Create(requestBody)
            };
            var response = await Client
                 .SendAsync(request, HttpCompletionOption.ResponseContentRead)
                 .ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                string output = await response.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<List<DriversInRangeDTO>>(output);
                TourId = deserialized.FirstOrDefault().TourPlan.Id;
            }
            await VerifyResponseAsync(HttpStatusCode.OK, response).ConfigureAwait(false);
        }

        //protected override Expression<Func<DrivingLicence, object>> ProvideRequiredProperty() => model => model.ExpireDate;

    }
}
