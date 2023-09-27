using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using NetEvolve.Http.Correlation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace uDrive.Backend.Api.Test.Integration.Abstractions;

public sealed class TestBaseFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        if (builder is null)
        {
            throw new ArgumentNullException(nameof(builder));
        }
        _ = builder.ConfigureServices(services =>
        {
            _ = services.AddHttpCorrelation().WithTestGenerator();
        });

        return base.CreateHost(builder);
    }


}
