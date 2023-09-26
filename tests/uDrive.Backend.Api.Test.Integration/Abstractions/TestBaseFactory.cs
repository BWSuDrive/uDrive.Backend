using Microsoft.AspNetCore.Mvc.Testing;
using NetEvolve.Extensions.NUnit;

using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace uDrive.Backend.Api.Test.Integration.Abstractions;

public sealed class TestBaseFactory : WebApplicationFactory<Program>
{
   // public async Task InitAsync() => await _container.StartAsync().ConfigureAwait(false);


}
