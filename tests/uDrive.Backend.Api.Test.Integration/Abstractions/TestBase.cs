using NetEvolve.Extensions.NUnit;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uDrive.Backend.Api.Test.Integration.Abstractions;

[ExcludeFromCodeCoverage]
[IntegrationTest]
[TestFixture]
[Parallelizable]
public abstract class TestBase : ContinuousTestBase
{
    protected TestBaseFactory TestFactory{ get; private set; }

    [OneTimeSetUp]
    public async Task InitAsync()
    {

        TestFactory = new TestBaseFactory();
    }
}
