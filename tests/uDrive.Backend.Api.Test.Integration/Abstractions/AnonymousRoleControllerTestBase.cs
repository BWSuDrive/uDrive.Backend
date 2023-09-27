using Microsoft.Data.SqlClient;
using NetEvolve.Extensions.NUnit;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VerifyNUnit;
using VerifyTests;

using uDrive.Backend.Api.Controllers.Abstract;

using uDrive.Backend.Model;
using uDrive.Backend.Model.DTO;
using System.Net.Http.Json;
using Argon;
using System.Net.Http.Headers;
namespace uDrive.Backend.Api.Test.Integration.Abstractions;

[ExcludeFromCodeCoverage]
[IntegrationTest]
[TestFixture]
[Parallelizable]
public abstract class AnonymousRoleControllerTestBase<TController, TEntity> : TestBase
    where TController : AnonymousRoleController<TEntity>
    where TEntity : class, IEntity
{
    private protected readonly string _entityName;

    public List<TEntity> _entities;

    protected virtual SignInUserDTO ProvideCredentials()
        =>
             new SignInUserDTO();

    protected RegisterDTO NewPerson = new RegisterDTO()
    {
        Email = "TestUser@udrive.de",
        Firstname = "Test",
        Lastname = "Test",
        Password = "Test1234!",
        UserName = "TestUser@udrive.de",
        PhoneNumber = "1234567890"
    };

    protected SignInUserDTO AdminCredentials = new SignInUserDTO()
    {
        Email = "Administrator@udrive.de",
        Password = "AdministratorSTrongPassword!2345",
        UserName = "Administrator@udrive.de",

    };

    protected string NewUserId = string.Empty;

    protected AnonymousRoleControllerTestBase()
    : base() =>
        _entityName = typeof(TController).Name.Replace(
            "Controller",
            string.Empty,
            StringComparison.OrdinalIgnoreCase
        );


    protected ClientUriBuilder CreateUri() =>
      ClientUriBuilder.Create().AddSegments(_entityName);
    protected ClientUriBuilder CreateUri(params object[] additionalSegments) =>
       CreateUri().AddSegments(additionalSegments);

    [Test]
    [Order(10)]
    public async Task Login()
    {
        var uri = ClientUriBuilder
            .Create()
            .AddSegments("Login")
            .Build();

        using var request = new HttpRequestMessage(HttpMethod.Post, uri)
        {
            Content = JsonContent.Create(ProvideCredentials())
        };
        var response = await Client
            .SendAsync(request, HttpCompletionOption.ResponseContentRead)
            .ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            string output = await response.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<Response<LoginResponseDTO>>(output);
            token = deserialized.Data.Token;
        }

        Assert.IsTrue(response.IsSuccessStatusCode);
    }
    [Test]
    [Order(11)]
    public async Task LoginAdmin()
    {
        var uri = ClientUriBuilder
            .Create()
            .AddSegments("Login")
            .Build();

        using var request = new HttpRequestMessage(HttpMethod.Post, uri)
        {
            Content = JsonContent.Create(AdminCredentials)
        };
        var response = await AdminClient
            .SendAsync(request, HttpCompletionOption.ResponseContentRead)
            .ConfigureAwait(false);

        if (response.IsSuccessStatusCode)
        {
            string output = await response.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<Response<LoginResponseDTO>>(output);
            adminToken = deserialized.Data.Token;
        }

        Assert.IsTrue(response.IsSuccessStatusCode);
    }
    [Test]
    [Order(50)]
    public async Task RegisterTestUser()
    {
        var response = await  RegisterNewUserAsync().ConfigureAwait(false);     
           
        if(response.StatusCode == HttpStatusCode.BadRequest)
        {
            await DeleteTestUserWithEmail().ConfigureAwait(false);
            response = await RegisterNewUserAsync().ConfigureAwait(false);

        }

        Assert.IsTrue(response.IsSuccessStatusCode);

    }



    private async Task<HttpResponseMessage> RegisterNewUserAsync()
    {
        var uri = ClientUriBuilder
           .Create()
           .AddSegments("Register")
           .Build();
        var requestBody = NewPerson;
        using var request = new HttpRequestMessage(HttpMethod.Post, uri)
        {
            Content = JsonContent.Create(requestBody)
        };
        var response = await Client
            .SendAsync(request, HttpCompletionOption.ResponseContentRead)
            .ConfigureAwait(false);
        string output = await response.Content.ReadAsStringAsync();
        var deserialized = JsonConvert.DeserializeObject<Response<LoginResponseDTO>>(output);
        NewUserId = deserialized.Data.Id;
        return response;

    }

    [Test]
    [Order(9999)]
    public async Task DeleteTestUser()
    {
        var uri = ClientUriBuilder
            .Create()
            .AddSegments("Persons",NewUserId)
            .Build();
       
        var response = await AdminClient
            .DeleteAsync(uri)
            .ConfigureAwait(false);
        Assert.IsTrue(response.StatusCode == HttpStatusCode.NoContent);
    }


    public async Task DeleteTestUserWithEmail()
    {
        var uri = ClientUriBuilder
            .Create()
            .AddSegments("Persons", "DeletePersonWithEmail", NewPerson.Email)
            .Build();

        var response = await AdminClient
            .DeleteAsync(uri)
            .ConfigureAwait(false);
    }

    

    [Test]
    [Order(100)]
    public async Task GET_All_Expected_Result()
    {
        var uri = CreateUri().Build();

        var response = await Client.GetAsync(uri, HttpCompletionOption.ResponseContentRead)
        .ConfigureAwait(false);
        if (response.IsSuccessStatusCode)
        {
            string output = await response.Content.ReadAsStringAsync();
            var deserialized = JsonConvert.DeserializeObject<List<TEntity>>(output);
            _entities = deserialized;
        }
        await VerifyResponseAsync(HttpStatusCode.OK, response).ConfigureAwait(false);
    }

    [Test]
    [Order(101)]
    public async Task GET_ById_Expected_Result()
    {
        string id = _entities.FirstOrDefault().Id;
        var uri = CreateUri(id).Build();
        var response = await Client
            .GetAsync(uri, HttpCompletionOption.ResponseContentRead)
            .ConfigureAwait(false);

        await VerifyResponseAsync(HttpStatusCode.OK, response).ConfigureAwait(false);
    }


}
