using COMACON.ComaconHelper;
using COMACON.config;
using FluentAssertions;
using Newtonsoft.Json.Linq;

namespace COMACON.tests;
public class ComaconHelperProxyTests
{
    private readonly ComaconHelperProxyOptions options = new()
    {
        ExecutableFilePath = @"c:\temp\app.exe",
        webApplicationDataStructures = new DefaultWebApplicationDataStructures(),
    };

    //[Fact]
    //public void TestGeneratingSetArguments()
    //{
    //    var factory = new DefaultComaconHelperProxy(options);

    //    var args = factory.generateSetArguments("path", "name", "type", "output");

    //    var expected = $"\"set\" \"{Path.Combine("path", "name")}\" \"type\" \"AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAAJgQjQHhFa02GBrQVTT289wAAAAACAAAAAAAQZgAAAAEAACAAAAD+dnUxrMLYnWP/TgVU6c3e/8TSoluA6QeHHifOKdodHAAAAAAOgAAAAAIAACAAAAB5Ok2kr0QpITwJsTpEydZR2m1R6aMbkHFadspEGv/WFRAAAABcvUEaci8qLSqrjMCDMDdvQAAAAOSLqu7LOC29MejIsNVU3Yy5KBuyTfNVpVQyqM2d0dDyjxbHEwZr+2l+rrXm511a7uRSa0S1qnC3cRfTSivqWhs=\"";

    //    args.Should().Be(expected);
    //}

    [Fact]
    public void TestGeneratingGetArgumentsApplicationServer211()
    {
        var factory = new DefaultComaconHelperProxy(options);
        DefaultWebApplicationDataStructures dwads = new DefaultWebApplicationDataStructures();

        string value = dwads.getWebApplicationDataStructureDictionary("Application Server", "211");

        var args = factory.generateGetArguments("path", "name", "type", value);

        var expected = $"\"get\" \"{Path.Combine("path", "name")}\" \"type\" \"{null}\" \"{value.Replace("\"", "\"\"")}\"";

        args.Should().Be(expected);
    }

    [Fact]
    public void TestGeneratingGetArgumentsAgendaOnline211()
    {
        var factory = new DefaultComaconHelperProxy(options);
        DefaultWebApplicationDataStructures dwads = new DefaultWebApplicationDataStructures();

        string value = dwads.getWebApplicationDataStructureDictionary("Agenda Online", "211");

        var args = factory.generateGetArguments("path", "name", "type", value);

        var expected = $"\"get\" \"{Path.Combine("path", "name")}\" \"type\" \"{null}\" \"{value.Replace("\"", "\"\"")}\"";

        args.Should().Be(expected);
    }

    [Fact]
    public void TestGeneratingGetArgumentsElectronicPlanReview211()
    {
        var factory = new DefaultComaconHelperProxy(options);
        DefaultWebApplicationDataStructures dwads = new DefaultWebApplicationDataStructures();

        string value = dwads.getWebApplicationDataStructureDictionary("Electronic Plan Review", "211");

        var args = factory.generateGetArguments("path", "name", "type", value);

        var expected = $"\"get\" \"{Path.Combine("path", "name")}\" \"type\" \"{null}\" \"{value.Replace("\"", "\"\"")}\"";

        args.Should().Be(expected);
    }

    [Fact]
    public void TestGeneratingGetArgumentsGatewayCachingServer211()
    {
        var factory = new DefaultComaconHelperProxy(options);
        DefaultWebApplicationDataStructures dwads = new DefaultWebApplicationDataStructures();

        string value = dwads.getWebApplicationDataStructureDictionary("Gateway Caching Server", "211");

        var args = factory.generateGetArguments("path", "name", "type", value);

        var expected = $"\"get\" \"{Path.Combine("path", "name")}\" \"type\" \"{null}\" \"{value.Replace("\"", "\"\"")}\"";

        args.Should().Be(expected);
    }

    [Fact]
    public void TestGeneratingGetArgumentsHealthcareFormManager211()
    {
        var factory = new DefaultComaconHelperProxy(options);
        DefaultWebApplicationDataStructures dwads = new DefaultWebApplicationDataStructures();

        string value = dwads.getWebApplicationDataStructureDictionary("Healthcare Form Manager", "211");

        var args = factory.generateGetArguments("path", "name", "type", value);

        var expected = $"\"get\" \"{Path.Combine("path", "name")}\" \"type\" \"{null}\" \"{value.Replace("\"", "\"\"")}\"";

        args.Should().Be(expected);
    }

    [Fact]
    public void TestGeneratingGetArgumentsPatientWindow211()
    {
        var factory = new DefaultComaconHelperProxy(options);
        DefaultWebApplicationDataStructures dwads = new DefaultWebApplicationDataStructures();

        string value = dwads.getWebApplicationDataStructureDictionary("Patient Window", "211");

        var args = factory.generateGetArguments("path", "name", "type", value);

        var expected = $"\"get\" \"{Path.Combine("path", "name")}\" \"type\" \"{null}\" \"{value.Replace("\"", "\"\"")}\"";

        args.Should().Be(expected);
    }

    [Fact]
    public void TestGeneratingGetArgumentsPublicAccessLegacy211()
    {
        var factory = new DefaultComaconHelperProxy(options);
        DefaultWebApplicationDataStructures dwads = new DefaultWebApplicationDataStructures();

        string value = dwads.getWebApplicationDataStructureDictionary("Public Access - Legacy", "211");

        var args = factory.generateGetArguments("path", "name", "type", value);

        var expected = $"\"get\" \"{Path.Combine("path", "name")}\" \"type\" \"{null}\" \"{value.Replace("\"", "\"\"")}\"";

        args.Should().Be(expected);
    }

    [Fact]
    public void TestGeneratingGetArgumentsPublicAccessNextGen211()
    {
        var factory = new DefaultComaconHelperProxy(options);
        DefaultWebApplicationDataStructures dwads = new DefaultWebApplicationDataStructures();

        string value = dwads.getWebApplicationDataStructureDictionary("Public Access - Next Gen", "211");

        var args = factory.generateGetArguments("path", "name", "type", value);

        var expected = $"\"get\" \"{Path.Combine("path", "name")}\" \"type\" \"{null}\" \"{value.Replace("\"", "\"\"")}\"";

        args.Should().Be(expected);
    }

    [Fact]
    public void TestGeneratingGetArgumentsReportingViewer211()
    {
        var factory = new DefaultComaconHelperProxy(options);
        DefaultWebApplicationDataStructures dwads = new DefaultWebApplicationDataStructures();

        string value = dwads.getWebApplicationDataStructureDictionary("Reporting Viewer", "211");

        var args = factory.generateGetArguments("path", "name", "type", value);

        var expected = $"\"get\" \"{Path.Combine("path", "name")}\" \"type\" \"{null}\" \"{value.Replace("\"","\"\"")}\"";

        args.Should().Be(expected);
    }

    [Fact]
    public void TestGeneratingGetArgumentsWebServer211()
    {
        var factory = new DefaultComaconHelperProxy(options);
        DefaultWebApplicationDataStructures dwads = new DefaultWebApplicationDataStructures();

        string value = dwads.getWebApplicationDataStructureDictionary("Web Server", "211");

        var args = factory.generateGetArguments("path", "name", "type", value);

        var expected = $"\"get\" \"{Path.Combine("path", "name")}\" \"type\" \"{null}\" \"{value.Replace("\"", "\"\"")}\"";

        args.Should().Be(expected);
    }
}