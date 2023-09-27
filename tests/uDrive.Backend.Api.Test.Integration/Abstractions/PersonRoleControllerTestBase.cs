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
using Argon;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace uDrive.Backend.Api.Test.Integration.Abstractions
{
    public abstract class PersonRoleControllerTestBase<TController, TEntity> : AnonymousRoleControllerTestBase<TController, TEntity>
    where TController : PersonRoleController<TEntity>
    where TEntity : class, IEntity
    {
        private int _patchIndex = 1;
        private int _putIndex = 1;

        protected abstract TEntity ProvideModelValidComplete();


        [Test]
        [Order(200)]
        public async Task POST_ValidModel_Expected_Result()
        {
            var uri = CreateUri().Build();
            var requestBody = ProvideModelValidComplete();
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
                var deserialized = JsonConvert.DeserializeObject<TEntity>(output);

                newId = deserialized.Id;
            }
            await VerifyResponseAsync(HttpStatusCode.OK, response, requestBody)
                .ConfigureAwait(false);
        }


        [Test]
        [Order(201)]
        public async Task GET_All_AfterValidPOST_Expected_Result()
        => await GET_All_Expected_Result().ConfigureAwait(false);

        [Test]
        [Order(202)]
        public async Task GET_ById_AfterValidPOST_Expected_Result()
        => await GET_ById_Expected_Result().ConfigureAwait(false);

       


        [Test]
        [Order(500)]
        public async Task DELETE_ById_Expected_Result()
        {
            var uri = CreateUri(newId).Build();
            var response = await Client.DeleteAsync(uri).ConfigureAwait(false);

            await VerifyResponseAsync(HttpStatusCode.NoContent, response)
                .ConfigureAwait(false);
        }

        [Test]
        [Order(501)]
        public async Task GET_All_AfterDELETE_Expected_Result()
       => await GET_All_Expected_Result().ConfigureAwait(false);

       

    }
}
