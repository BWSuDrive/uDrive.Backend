#define AUTO_VERIFY

using Argon;
using Microsoft.AspNetCore.Mvc.Testing;
using NetEvolve.Extensions.NUnit;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace uDrive.Backend.Api.Test.Integration.Abstractions;

[ExcludeFromCodeCoverage]
[IntegrationTest]
[TestFixture]
[Parallelizable]
public abstract class TestBase : ContinuousTestBase
{
    protected virtual string token { get; set; }
    protected virtual string adminToken { get; set; }
    protected virtual string newId { get; set; }

    protected TestBaseFactory TestFactory { get; private set; }
    protected HttpClient Client => CreateClientWithToken();

    protected HttpClient AdminClient => CreateAdminClientWithToken();

    private HttpClient CreateClientWithToken()
    {
        if (token == null)
        {
            return TestFactory.CreateClient();
        }
        else
        {
            var client = TestFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);
            return client;
        }
    }

    private HttpClient CreateAdminClientWithToken()
    {
        if (adminToken == null)
        {
            return TestFactory.CreateClient();
        }
        else
        {
            var client = TestFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", adminToken);
            return client;
        }


    }

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        TestFactory = new TestBaseFactory();
        TestFactory.ConfigureAwait(false);
    }


    protected async ValueTask VerifyResponseAsync(
     HttpStatusCode expectedStatusCode,
     HttpResponseMessage? response,
     object requestModel = default!
 )
    {
        if (response is null)
        {
            throw new ArgumentNullException(nameof(response));
        }

        var resultContent = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

        if (response.StatusCode >= HttpStatusCode.InternalServerError)
        {
            Assert.Fail(resultContent);
            return;
        }

        var resultData = string.IsNullOrWhiteSpace(resultContent)
            ? null
            : JToken.Parse(resultContent);

        if (response.StatusCode != expectedStatusCode)
        {
            Assert.Fail(
                "StatusCode does not correspond to the expected result.{0}Result: '{1}' Expected: '{2}'{0}{3}",
                Environment.NewLine, response.StatusCode, expectedStatusCode, resultData
                );
        }

        var request = response.RequestMessage;

        JToken? requestBody;
        if (requestModel is null)
        {
            requestBody = null;
        }
        else if (requestModel is string stringModel)
        {
            requestBody = JToken.Parse(stringModel);
        }
        else
        {
            requestBody = JToken.FromObject(requestModel, Json.Serializer);
        }

        request.Headers.Authorization = null;
        Assert.That(request, Is.Not.Null);
        Assert.That(request.RequestUri, Is.Not.Null);

        string absolutePath = request.RequestUri.AbsolutePath;
       var requestPA = newId is not null ?  absolutePath.Contains(newId) ? absolutePath.Replace(newId, "ID") : absolutePath : absolutePath;

        

        _ = await Verify(
                new
                {
                    requestPath = requestPA,
                    requestQuery = string.IsNullOrWhiteSpace(request.RequestUri.Query)
                        ? null
                        : request.RequestUri.Query,
                    requestBody,
                    requestHeader = request.Headers,
                    requestMethod = request.Method.Method,
                    responseBody = resultData,
                    responseHeader = response.Headers,
                    statusCode = response.StatusCode,
                    statusCodeExpected = response.StatusCode == expectedStatusCode
                },
                expectedStatusCode
        )
            .ConfigureAwait(false);
    }

    private SettingsTask Verify<T>(T value, HttpStatusCode statusCode)
    {
        var testClassName = GetType().Name;
        var testMethodName = TestContext.CurrentContext.Test.MethodName;
        var orderIndex = TestContext.CurrentContext.Test.Properties["Order"].Cast<int>().FirstOrDefault();

        return Verifier
        .Verify(value)
        .UseDirectory("./../_verifySnapshots")
        .UseFileName($"{testClassName}_Order({orderIndex:D4})_Status({statusCode})_{testMethodName}")
#if AUTO_VERIFY
        .AutoVerify()
#endif
    ;
    }
    protected sealed class ClientUriBuilder
    {
        private readonly List<string> _segments;
        private ClientUriBuilder()
        {
            _segments = new();
        }

        internal static ClientUriBuilder Create() => new ClientUriBuilder();



        internal ClientUriBuilder AddSegment(object segment)
        {
            _segments.Add(segment is string stringSegment ? stringSegment : $"{segment}");
            return this;
        }

        internal ClientUriBuilder AddSegments(params object[] segments)
        {
            if (segments is not null)
            {
                foreach (var segment in segments)
                {
                    _segments.Add(segment is string stringSegment ? stringSegment : $"{segment}");
                }
            }
            return this;
        }

        internal Uri Build()
        {
            var uriString = $"/{string.Join("/", _segments)}";

            return new Uri(uriString, UriKind.Relative);
        }
    }
}
