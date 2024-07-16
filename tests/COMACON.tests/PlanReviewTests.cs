using COMACON.config;
using COMACONTranslationToHelperUtility;
using FluentAssertions;
using Newtonsoft.Json;
using System.Xml;

namespace COMACON.tests;

public class PlanReviewTests
{
    [Fact]
    public void Test1()
    {
        //Testing to validate that the key is found and the appropriate value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings>
    <add key=""StyleSheetPath"" value=""BasicBlue/"" />
    <add key=""AllowSignon"" value=""true"" />
    <add key=""AllowSignoff"" value=""true"" />
    <add key=""DefaultTimeZone"" value=""64"" />
    <add key=""SearchStartYear"" value=""2012"" />
    <add key=""DisplayDocumentsPerPage"" value=""20"" />
    <add key=""MaxLookupResults"" value=""20"" />
    <add key=""ResetPasswordLinkExpiration"" value=""60"" />
    <add key=""FileUploadDirectory"" value=""~/Upload"" />
    <add key=""FileUploadValidator"" value="""" />
    <add key=""TokenAuthentication"" value=""false"" />
    <add key=""SingleSignOn"" value=""false"" />
    <add key=""SingleSignOnSourceID"" value=""1"" />
    <add key=""SSOUserResolutionMode"" value=""0"" />
    <add key=""CAPTCHAPublicKey"" value="""" />
    <add key=""CAPTCHAPrivateKey"" value="""" />
    <add key=""PasswordStrengthPattern"" value=""^(?=.{4,}).*$"" />
    <add key=""PasswordStrengthMessage"" value="""" />
    <!-- UsernameValidationPattern default value = [\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+ -->
    <add key=""UsernameValidationPattern"" value=""[\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+"" />
    <add key=""DisciplineItemsPerMenu"" value=""15"" />
    <add key=""webpages:Enabled"" value=""false"" />
  </appSettings>";

        string keyName = "FileUploadDirectory";
        string defaultValue = "~/Upload";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getNonStandardXmlValue(xmldoc.DocumentElement, keyName, defaultValue);

        value.Should().Be("~/Upload");
    }

    [Fact]
    public void Test2()
    {
        //Testing to validate that the key is not found and the default value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings>
    <add key=""StyleSheetPath"" value=""BasicBlue/"" />
    <add key=""AllowSignon"" value=""true"" />
    <add key=""AllowSignoff"" value=""true"" />
    <add key=""DefaultTimeZone"" value=""64"" />
    <add key=""SearchStartYear"" value=""2012"" />
    <add key=""DisplayDocumentsPerPage"" value=""20"" />
    <add key=""MaxLookupResults"" value=""20"" />
    <add key=""ResetPasswordLinkExpiration"" value=""60"" />
    <add key=""FileUploadDirectory"" value=""~/Upload"" />
    <add key=""FileUploadValidator"" value="""" />
    <add key=""TokenAuthentication"" value=""false"" />
    <add key=""SingleSignOn"" value=""false"" />
    <add key=""SingleSignOnSourceID"" value=""1"" />
    <add key=""SSOUserResolutionMode"" value=""0"" />
    <add key=""CAPTCHAPublicKey"" value="""" />
    <add key=""CAPTCHAPrivateKey"" value="""" />
    <add key=""PasswordStrengthPattern"" value=""^(?=.{4,}).*$"" />
    <add key=""PasswordStrengthMessage"" value="""" />
    <!-- UsernameValidationPattern default value = [\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+ -->
    <add key=""UsernameValidationPattern"" value=""[\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+"" />
    <add key=""DisciplineItemsPerMenu"" value=""15"" />
    <add key=""webpages:Enabled"" value=""false"" />
  </appSettings>";

        string keyName = "FileUploadDirectory";
        string defaultValue = "~/Upload";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getNonStandardXmlValue(xmldoc, keyName, defaultValue);

        value.Should().Be(defaultValue);
    }

    [Fact]
    public void Test3()
    {
        //Testing to validate that the key is found and the appropriate value is returned.
        //This is testing with just one level of nesting.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://[server]/[virtual directory]/Service.asmx"" ServiceClientType=""SOAP"" />
  </Hyland.Services.Client>";

        string nodeName = "ApplicationServer";
        string attributeName = "Url";
        string defaultValue = "Default Name";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getStandardXmlValue(xmldoc.DocumentElement, nodeName, attributeName, defaultValue);

        value.Should().Be("http://[server]/[virtual directory]/Service.asmx");
    }

    [Fact]
    public void Test4()
    {
        //Testing to validate that the key is not found and the default value is returned.
        //This is testing with just one level of nesting.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://[server]/[virtual directory]/Service.asmx"" ServiceClientType=""SOAP"" />
  </Hyland.Services.Client>";

        string nodeName = "ApplicationServer";
        string attributeName = "url";
        string defaultValue = "Default Name";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getStandardXmlValue(xmldoc.DocumentElement, nodeName, attributeName, defaultValue);

        //Assert.True(true);
        value.Should().Be(defaultValue);
    }

    [Fact]
    public void Test5()
    {
        //Testing the Prebuilding of the 211 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[server]/[virtual directory]/Service.asmx","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test6()
    {
        //Testing the Prebuilding of the 211 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""4"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","StyleSheetPath","2","Stylesheet-Directory-Location","BasicBlue/","","",""},
            {"appSettings","add","AllowSignon","1","Allow-Sign-On","true","","",""},
            {"appSettings","add","AllowSignoff","1","Allow-Sign-Off","true","","",""},
            {"appSettings","add","DefaultTimeZone","2","Default-User-Time-Zone","4","","",""},
            {"appSettings","add","SearchStartYear","2","Search-Start-Year","2012","","",""},
            {"appSettings","add","DisplayDocumentsPerPage","2","Items-Per-Page","20","","",""},
            {"appSettings","add","MaxLookupResults","2","Max-Lookup-Results","20","","",""},
            {"appSettings","add","ResetPasswordLinkExpiration","2","Reset-Password-Link-Lifetime","60","","",""},
            {"appSettings","add","FileUploadDirectory","2","File-Upload-Directory","~/Upload","","",""},
            {"appSettings","add","FileUploadValidator","2","File-Upload-Validator","","","",""},
            {"appSettings","add","TokenAuthentication","1","Token-Authentication","false","","",""},
            {"appSettings","add","SingleSignOn","1","Allow-Single-Sign-On","false","","",""},
            {"appSettings","add","SingleSignOnSourceID","2","Source-ID","1","","",""},
            {"appSettings","add","SSOUserResolutionMode","2","Resolution-Mode","0","","",""},
            {"appSettings","add","CAPTCHAPublicKey","2","Public-CAPTCHA-Key","","","",""},
            {"appSettings","add","CAPTCHAPrivateKey","2","Private-CAPTCHA-Key","","","",""},
            {"appSettings","add","PasswordStrengthPattern","2","Password-Strength-Pattern","^(?=.{4,}).*$","","",""},
            {"appSettings","add","PasswordStrengthMessage","2","Password-Strength-Message","","","",""},
            {"appSettings","add","UsernameValidationPattern","2","Username-Validation-Pattern","[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+","","",""},
            {"appSettings","add","DisciplineItemsPerMenu","2","Discipline-Items-Per-Menu","15","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test7()
    {
        //Testing the Prebuilding of the 211 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web", "httpRuntime", "maxRequestLength", "2", "HTTP-Runtime-Maximum-Request-Length", "4096", "", "", ""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test14()
    {
        //Testing the Prebuilding of the 211 system.webServer section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test8()
    {
        //Testing the parsing of the 211 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://[server]/[virtual directory]/Service.asmx"" ServiceClientType=""SOAP"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test9()
    {
        //Testing the parsing of the 211 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""webpages:Enabled\"" value=\""false\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<appSettings>
    <add key=""StyleSheetPath"" value=""BasicBlue/"" />
    <add key=""AllowSignon"" value=""true"" />
    <add key=""AllowSignoff"" value=""true"" />
    <add key=""DefaultTimeZone"" value=""64"" />
    <add key=""SearchStartYear"" value=""2012"" />
    <add key=""DisplayDocumentsPerPage"" value=""20"" />
    <add key=""MaxLookupResults"" value=""20"" />
    <add key=""ResetPasswordLinkExpiration"" value=""60"" />
    <add key=""FileUploadDirectory"" value=""~/Upload"" />
    <add key=""FileUploadValidator"" value="""" />
    <add key=""TokenAuthentication"" value=""false"" />
    <add key=""SingleSignOn"" value=""false"" />
    <add key=""SingleSignOnSourceID"" value=""1"" />
    <add key=""SSOUserResolutionMode"" value=""0"" />
    <add key=""CAPTCHAPublicKey"" value="""" />
    <add key=""CAPTCHAPrivateKey"" value="""" />
    <add key=""PasswordStrengthPattern"" value=""^(?=.{4,}).*$"" />
    <add key=""PasswordStrengthMessage"" value="""" />
    <!-- UsernameValidationPattern default value = [\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+ -->
    <add key=""UsernameValidationPattern"" value=""[\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+"" />
    <add key=""DisciplineItemsPerMenu"" value=""15"" />
    <add key=""webpages:Enabled"" value=""false"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test10()
    {
        //Testing the parsing of the 211 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.web>
    <globalization enableClientBasedCulture=""true"" culture=""auto:en-US"" uiCulture=""auto:en"" />
    <compilation debug=""true"" targetFramework=""4.7.2"">
      <buildProviders>
        <add extension="".template"" type=""System.Web.WebPages.Razor.RazorBuildProvider,System.Web.WebPages.Razor"" />
      </buildProviders>
      <assemblies>
        <add assembly=""netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"" />
      </assemblies>
    </compilation>
    <!--
		Enabling request validation in view pages would cause validation to occur
		after the input has already been processed by the controller. By default
		MVC performs request validation before a controller processes the input.
		To change this behavior apply the ValidateInputAttribute to a
		controller or action.
	-->
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
    <authentication mode=""Forms"">
      <forms loginUrl=""~/SignIn/SignIn"" timeout=""2880"" />
    </authentication>
    <httpRuntime maxRequestLength=""4096"" enableVersionHeader=""false"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Applications.AgendaPubAccess.PublicComment", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test11()
    {
        //Testing the parsing of the 211 system.webServer section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.webServer>
    <validation validateIntegratedModeConfiguration=""false"" />
    <modules runAllManagedModulesForAllRequests=""true"" />
    <handlers>
      <!--The format for this section should additionally contain the name and preCondition attributes.-->
      <!--The name attribute follows the pattern ""<path>_<verb>""-->
      <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
    <security>
      <requestFiltering>
        <!-- This should be set the same as the one in the Application Server's web.config. -->
        <requestLimits maxAllowedContentLength=""30000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <httpProtocol>
      <customHeaders>
        <remove name=""X-Powered-By"" />
      </customHeaders>
    </httpProtocol>
    <defaultDocument>
      <files>
        <remove value=""Default.htm"" />
        <add value=""Default.htm"" />
      </files>
    </defaultDocument>
  </system.webServer>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.webServer", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test12()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""EPR-Username"",""Value"":""Us3"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""EPR-Password"",""Value"":""P@ss"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""D@taS0urce"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Electronic-Plan-Review"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""EPR-Username"",""Value"":""Us3"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""EPR-Password"",""Value"":""P@ss"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""D@taS0urce"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Electronic-Plan-Review"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test13()
    {
        //Testing the parsing of the 211 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""OnBase Plan Review Portal""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""5"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":{""SourceName"":""Hyland""},""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":null,""RouteType"":""EventLog"",""Name"":""ErrorEventLog"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""2"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":{""OutputFormat"":""Minimal""},""RouteType"":""Console"",""Name"":""Console"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""OnBase Plan Review Portal"" />
    <Routes>
      <Route name=""DiagnosticsConsole"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Http"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""ErrorEventLog"">
        <add key=""minimum-level"" value=""Error"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""EventLog"" value=""Hyland"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""Console"">
        <add key=""minimum-level"" value=""Debug"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Console"" />
        <add key=""OutputFormat"" value=""Minimal"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
    </Routes>
    <AuditRoutes>
    </AuditRoutes>
  </Hyland.Logging>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Logging", xmldoc, new DefaultWebApplicationDataStructures());

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test15()
    {
        //Testing the Prebuilding of the 221 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[server]/[virtual directory]/Service.asmx","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test16()
    {
        //Testing the Prebuilding of the 221 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","StyleSheetPath","2","Stylesheet-Directory-Location","BasicBlue/","","",""},
            {"appSettings","add","AllowSignon","1","Allow-Sign-On","true","","",""},
            {"appSettings","add","AllowSignoff","1","Allow-Sign-Off","true","","",""},
            {"appSettings","add","DefaultTimeZone","2","Default-User-Time-Zone","64","","",""},
            {"appSettings","add","SearchStartYear","2","Search-Start-Year","2012","","",""},
            {"appSettings","add","DisplayDocumentsPerPage","2","Items-Per-Page","20","","",""},
            {"appSettings","add","MaxLookupResults","2","Max-Lookup-Results","20","","",""},
            {"appSettings","add","ResetPasswordLinkExpiration","2","Reset-Password-Link-Lifetime","60","","",""},
            {"appSettings","add","FileUploadDirectory","2","File-Upload-Directory","~/Upload","","",""},
            {"appSettings","add","FileUploadValidator","2","File-Upload-Validator","","","",""},
            {"appSettings","add","TokenAuthentication","1","Token-Authentication","false","","",""},
            {"appSettings","add","SingleSignOn","1","Allow-Single-Sign-On","false","","",""},
            {"appSettings","add","SingleSignOnSourceID","2","Source-ID","1","","",""},
            {"appSettings","add","SSOUserResolutionMode","2","Resolution-Mode","0","","",""},
            {"appSettings","add","CAPTCHAPublicKey","2","Public-CAPTCHA-Key","","","",""},
            {"appSettings","add","CAPTCHAPrivateKey","2","Private-CAPTCHA-Key","","","",""},
            {"appSettings","add","PasswordStrengthPattern","2","Password-Strength-Pattern","^(?=.{4,}).*$","","",""},
            {"appSettings","add","PasswordStrengthMessage","2","Password-Strength-Message","","","",""},
            {"appSettings","add","UsernameValidationPattern","2","Username-Validation-Pattern","[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+","","",""},
            {"appSettings","add","DisciplineItemsPerMenu","2","Discipline-Items-Per-Menu","15","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test17()
    {
        //Testing the Prebuilding of the 221 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test18()
    {
        //Testing the Prebuilding of the 221 system.webServer section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test19()
    {
        //Testing the parsing of the 221 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://[server]/[virtual directory]/Service.asmx"" ServiceClientType=""SOAP"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test20()
    {
        //Testing the parsing of the 221 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""22.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""22.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""webpages:Enabled\"" value=\""false\"" />"",""Version"":""22.1.8.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<appSettings>
    <add key=""StyleSheetPath"" value=""BasicBlue/"" />
    <add key=""AllowSignon"" value=""true"" />
    <add key=""AllowSignoff"" value=""true"" />
    <add key=""DefaultTimeZone"" value=""64"" />
    <add key=""SearchStartYear"" value=""2012"" />
    <add key=""DisplayDocumentsPerPage"" value=""20"" />
    <add key=""MaxLookupResults"" value=""20"" />
    <add key=""ResetPasswordLinkExpiration"" value=""60"" />
    <add key=""FileUploadDirectory"" value=""~/Upload"" />
    <add key=""FileUploadValidator"" value="""" />
    <add key=""TokenAuthentication"" value=""false"" />
    <add key=""SingleSignOn"" value=""false"" />
    <add key=""SingleSignOnSourceID"" value=""1"" />
    <add key=""SSOUserResolutionMode"" value=""0"" />
    <add key=""CAPTCHAPublicKey"" value="""" />
    <add key=""CAPTCHAPrivateKey"" value="""" />
    <add key=""PasswordStrengthPattern"" value=""^(?=.{4,}).*$"" />
    <add key=""PasswordStrengthMessage"" value="""" />
    <!-- UsernameValidationPattern default value = [\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+ -->
    <add key=""UsernameValidationPattern"" value=""[\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+"" />
    <add key=""DisciplineItemsPerMenu"" value=""15"" />
    <add key=""webpages:Enabled"" value=""false"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test21()
    {
        //Testing the parsing of the 221 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.web>
    <globalization enableClientBasedCulture=""true"" culture=""auto:en-US"" uiCulture=""auto:en"" />
    <compilation debug=""true"" targetFramework=""4.7.2"">
      <buildProviders>
        <add extension="".template"" type=""System.Web.WebPages.Razor.RazorBuildProvider,System.Web.WebPages.Razor"" />
      </buildProviders>
      <assemblies>
        <add assembly=""netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"" />
      </assemblies>
    </compilation>
    <!--
		Enabling request validation in view pages would cause validation to occur
		after the input has already been processed by the controller. By default
		MVC performs request validation before a controller processes the input.
		To change this behavior apply the ValidateInputAttribute to a
		controller or action.
	-->
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
    <authentication mode=""Forms"">
      <forms loginUrl=""~/SignIn/SignIn"" timeout=""2880"" />
    </authentication>
    <httpRuntime maxRequestLength=""4096"" enableVersionHeader=""false"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Applications.AgendaPubAccess.PublicComment", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test22()
    {
        //Testing the parsing of the 221 system.webServer section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.webServer>
    <validation validateIntegratedModeConfiguration=""false"" />
    <modules runAllManagedModulesForAllRequests=""true"" />
    <handlers>
      <!--The format for this section should additionally contain the name and preCondition attributes.-->
      <!--The name attribute follows the pattern ""<path>_<verb>""-->
      <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
    <security>
      <requestFiltering>
        <!-- This should be set the same as the one in the Application Server's web.config. -->
        <requestLimits maxAllowedContentLength=""30000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <httpProtocol>
      <customHeaders>
        <remove name=""X-Powered-By"" />
      </customHeaders>
    </httpProtocol>
    <defaultDocument>
      <files>
        <remove value=""Default.htm"" />
        <add value=""Default.htm"" />
      </files>
    </defaultDocument>
  </system.webServer>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.webServer", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test23()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""EPR-Username"",""Value"":""Us3"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""EPR-Password"",""Value"":""P@ss"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""D@taS0urce"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Electronic-Plan-Review"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""EPR-Username"",""Value"":""Us3"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""EPR-Password"",""Value"":""P@ss"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""D@taS0urce"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Electronic-Plan-Review"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test24()
    {
        //Testing the parsing of the 221 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""22.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""22.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""OnBase Plan Review Portal""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""5"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":{""SourceName"":""Hyland""},""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":null,""RouteType"":""EventLog"",""Name"":""ErrorEventLog"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""2"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":{""OutputFormat"":""Minimal""},""RouteType"":""Console"",""Name"":""Console"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""OnBase Plan Review Portal"" />
    <Routes>
      <Route name=""DiagnosticsConsole"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Http"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""ErrorEventLog"">
        <add key=""minimum-level"" value=""Error"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""EventLog"" value=""Hyland"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""Console"">
        <add key=""minimum-level"" value=""Debug"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Console"" />
        <add key=""OutputFormat"" value=""Minimal"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
    </Routes>
    <AuditRoutes>
    </AuditRoutes>
  </Hyland.Logging>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Logging", xmldoc, new DefaultWebApplicationDataStructures());

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test25()
    {
        //Testing the Prebuilding of the 231 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[server]/[virtual directory]/Service.asmx","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test26()
    {
        //Testing the Prebuilding of the 231 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","StyleSheetPath","2","Stylesheet-Directory-Location","BasicBlue/","","",""},
            {"appSettings","add","AllowSignon","1","Allow-Sign-On","true","","",""},
            {"appSettings","add","AllowSignoff","1","Allow-Sign-Off","true","","",""},
            {"appSettings","add","DefaultTimeZone","2","Default-User-Time-Zone","64","","",""},
            {"appSettings","add","SearchStartYear","2","Search-Start-Year","2012","","",""},
            {"appSettings","add","DisplayDocumentsPerPage","2","Items-Per-Page","20","","",""},
            {"appSettings","add","MaxLookupResults","2","Max-Lookup-Results","20","","",""},
            {"appSettings","add","ResetPasswordLinkExpiration","2","Reset-Password-Link-Lifetime","60","","",""},
            {"appSettings","add","FileUploadDirectory","2","File-Upload-Directory","~/Upload","","",""},
            {"appSettings","add","FileUploadValidator","2","File-Upload-Validator","","","",""},
            {"appSettings","add","TokenAuthentication","1","Token-Authentication","false","","",""},
            {"appSettings","add","SingleSignOn","1","Allow-Single-Sign-On","false","","",""},
            {"appSettings","add","SingleSignOnSourceID","2","Source-ID","1","","",""},
            {"appSettings","add","SSOUserResolutionMode","2","Resolution-Mode","0","","",""},
            {"appSettings","add","CAPTCHAPublicKey","2","Public-CAPTCHA-Key","","","",""},
            {"appSettings","add","CAPTCHAPrivateKey","2","Private-CAPTCHA-Key","","","",""},
            {"appSettings","add","PasswordStrengthPattern","2","Password-Strength-Pattern","^(?=.{4,}).*$","","",""},
            {"appSettings","add","PasswordStrengthMessage","2","Password-Strength-Message","","","",""},
            {"appSettings","add","UsernameValidationPattern","2","Username-Validation-Pattern","[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+","","",""},
            {"appSettings","add","DisciplineItemsPerMenu","2","Discipline-Items-Per-Menu","15","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test27()
    {
        //Testing the Prebuilding of the 231 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test28()
    {
        //Testing the Prebuilding of the 231 system.webServer section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test29()
    {
        //Testing the parsing of the 231 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://[server]/[virtual directory]/Service.asmx"" ServiceClientType=""SOAP"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test30()
    {
        //Testing the parsing of the 231 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""23.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""23.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""webpages:Enabled\"" value=\""false\"" />"",""Version"":""23.1.8.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<appSettings>
    <add key=""StyleSheetPath"" value=""BasicBlue/"" />
    <add key=""AllowSignon"" value=""true"" />
    <add key=""AllowSignoff"" value=""true"" />
    <add key=""DefaultTimeZone"" value=""64"" />
    <add key=""SearchStartYear"" value=""2012"" />
    <add key=""DisplayDocumentsPerPage"" value=""20"" />
    <add key=""MaxLookupResults"" value=""20"" />
    <add key=""ResetPasswordLinkExpiration"" value=""60"" />
    <add key=""FileUploadDirectory"" value=""~/Upload"" />
    <add key=""FileUploadValidator"" value="""" />
    <add key=""TokenAuthentication"" value=""false"" />
    <add key=""SingleSignOn"" value=""false"" />
    <add key=""SingleSignOnSourceID"" value=""1"" />
    <add key=""SSOUserResolutionMode"" value=""0"" />
    <add key=""CAPTCHAPublicKey"" value="""" />
    <add key=""CAPTCHAPrivateKey"" value="""" />
    <add key=""PasswordStrengthPattern"" value=""^(?=.{4,}).*$"" />
    <add key=""PasswordStrengthMessage"" value="""" />
    <!-- UsernameValidationPattern default value = [\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+ -->
    <add key=""UsernameValidationPattern"" value=""[\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+"" />
    <add key=""DisciplineItemsPerMenu"" value=""15"" />
    <add key=""webpages:Enabled"" value=""false"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test31()
    {
        //Testing the parsing of the 231 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.web>
    <globalization enableClientBasedCulture=""true"" culture=""auto:en-US"" uiCulture=""auto:en"" />
    <compilation debug=""true"" targetFramework=""4.7.2"">
      <buildProviders>
        <add extension="".template"" type=""System.Web.WebPages.Razor.RazorBuildProvider,System.Web.WebPages.Razor"" />
      </buildProviders>
      <assemblies>
        <add assembly=""netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"" />
      </assemblies>
    </compilation>
    <!--
		Enabling request validation in view pages would cause validation to occur
		after the input has already been processed by the controller. By default
		MVC performs request validation before a controller processes the input.
		To change this behavior apply the ValidateInputAttribute to a
		controller or action.
	-->
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
    <authentication mode=""Forms"">
      <forms loginUrl=""~/SignIn/SignIn"" timeout=""2880"" />
    </authentication>
    <httpRuntime maxRequestLength=""4096"" enableVersionHeader=""false"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Applications.AgendaPubAccess.PublicComment", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test32()
    {
        //Testing the parsing of the 231 system.webServer section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.webServer>
    <validation validateIntegratedModeConfiguration=""false"" />
    <modules runAllManagedModulesForAllRequests=""true"" />
    <handlers>
      <!--The format for this section should additionally contain the name and preCondition attributes.-->
      <!--The name attribute follows the pattern ""<path>_<verb>""-->
      <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
    <security>
      <requestFiltering>
        <!-- This should be set the same as the one in the Application Server's web.config. -->
        <requestLimits maxAllowedContentLength=""30000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <httpProtocol>
      <customHeaders>
        <remove name=""X-Powered-By"" />
      </customHeaders>
    </httpProtocol>
    <defaultDocument>
      <files>
        <remove value=""Default.htm"" />
        <add value=""Default.htm"" />
      </files>
    </defaultDocument>
  </system.webServer>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.webServer", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test33()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""EPR-Username"",""Value"":""Us3"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""EPR-Password"",""Value"":""P@ss"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""D@taS0urce"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Electronic-Plan-Review"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""EPR-Username"",""Value"":""Us3"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""EPR-Password"",""Value"":""P@ss"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""D@taS0urce"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Electronic-Plan-Review"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test34()
    {
        //Testing the parsing of the 231 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""23.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""23.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""OnBase Plan Review Portal""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""5"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":{""SourceName"":""Hyland""},""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":null,""RouteType"":""EventLog"",""Name"":""ErrorEventLog"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""2"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":{""OutputFormat"":""Minimal""},""RouteType"":""Console"",""Name"":""Console"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""OnBase Plan Review Portal"" />
    <Routes>
      <Route name=""DiagnosticsConsole"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Http"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""ErrorEventLog"">
        <add key=""minimum-level"" value=""Error"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""EventLog"" value=""Hyland"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""Console"">
        <add key=""minimum-level"" value=""Debug"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Console"" />
        <add key=""OutputFormat"" value=""Minimal"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
    </Routes>
    <AuditRoutes>
    </AuditRoutes>
  </Hyland.Logging>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Logging", xmldoc, new DefaultWebApplicationDataStructures());

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test35()
    {
        //Testing the Prebuilding of the 231 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[server]/[virtual directory]/Service.asmx","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test36()
    {
        //Testing the Prebuilding of the 231 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","StyleSheetPath","2","Stylesheet-Directory-Location","BasicBlue/","","",""},
            {"appSettings","add","AllowSignon","1","Allow-Sign-On","true","","",""},
            {"appSettings","add","AllowSignoff","1","Allow-Sign-Off","true","","",""},
            {"appSettings","add","DefaultTimeZone","2","Default-User-Time-Zone","64","","",""},
            {"appSettings","add","SearchStartYear","2","Search-Start-Year","2012","","",""},
            {"appSettings","add","DisplayDocumentsPerPage","2","Items-Per-Page","20","","",""},
            {"appSettings","add","MaxLookupResults","2","Max-Lookup-Results","20","","",""},
            {"appSettings","add","ResetPasswordLinkExpiration","2","Reset-Password-Link-Lifetime","60","","",""},
            {"appSettings","add","FileUploadDirectory","2","File-Upload-Directory","~/Upload","","",""},
            {"appSettings","add","FileUploadValidator","2","File-Upload-Validator","","","",""},
            {"appSettings","add","TokenAuthentication","1","Token-Authentication","false","","",""},
            {"appSettings","add","SingleSignOn","1","Allow-Single-Sign-On","false","","",""},
            {"appSettings","add","SingleSignOnSourceID","2","Source-ID","1","","",""},
            {"appSettings","add","SSOUserResolutionMode","2","Resolution-Mode","0","","",""},
            {"appSettings","add","CAPTCHAPublicKey","2","Public-CAPTCHA-Key","","","",""},
            {"appSettings","add","CAPTCHAPrivateKey","2","Private-CAPTCHA-Key","","","",""},
            {"appSettings","add","PasswordStrengthPattern","2","Password-Strength-Pattern","^(?=.{4,}).*$","","",""},
            {"appSettings","add","PasswordStrengthMessage","2","Password-Strength-Message","","","",""},
            {"appSettings","add","UsernameValidationPattern","2","Username-Validation-Pattern","[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+","","",""},
            {"appSettings","add","DisciplineItemsPerMenu","2","Discipline-Items-Per-Menu","15","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test37()
    {
        //Testing the Prebuilding of the 231 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test38()
    {
        //Testing the Prebuilding of the 231 system.webServer section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test39()
    {
        //Testing the parsing of the 231 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://[server]/[virtual directory]/Service.asmx"" ServiceClientType=""SOAP"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test40()
    {
        //Testing the parsing of the 231 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""23.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""23.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""webpages:Enabled\"" value=\""false\"" />"",""Version"":""23.1.8.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<appSettings>
    <add key=""StyleSheetPath"" value=""BasicBlue/"" />
    <add key=""AllowSignon"" value=""true"" />
    <add key=""AllowSignoff"" value=""true"" />
    <add key=""DefaultTimeZone"" value=""64"" />
    <add key=""SearchStartYear"" value=""2012"" />
    <add key=""DisplayDocumentsPerPage"" value=""20"" />
    <add key=""MaxLookupResults"" value=""20"" />
    <add key=""ResetPasswordLinkExpiration"" value=""60"" />
    <add key=""FileUploadDirectory"" value=""~/Upload"" />
    <add key=""FileUploadValidator"" value="""" />
    <add key=""TokenAuthentication"" value=""false"" />
    <add key=""SingleSignOn"" value=""false"" />
    <add key=""SingleSignOnSourceID"" value=""1"" />
    <add key=""SSOUserResolutionMode"" value=""0"" />
    <add key=""CAPTCHAPublicKey"" value="""" />
    <add key=""CAPTCHAPrivateKey"" value="""" />
    <add key=""PasswordStrengthPattern"" value=""^(?=.{4,}).*$"" />
    <add key=""PasswordStrengthMessage"" value="""" />
    <!-- UsernameValidationPattern default value = [\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+ -->
    <add key=""UsernameValidationPattern"" value=""[\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+"" />
    <add key=""DisciplineItemsPerMenu"" value=""15"" />
    <add key=""webpages:Enabled"" value=""false"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test41()
    {
        //Testing the parsing of the 231 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.web>
    <globalization enableClientBasedCulture=""true"" culture=""auto:en-US"" uiCulture=""auto:en"" />
    <compilation debug=""true"" targetFramework=""4.7.2"">
      <buildProviders>
        <add extension="".template"" type=""System.Web.WebPages.Razor.RazorBuildProvider,System.Web.WebPages.Razor"" />
      </buildProviders>
      <assemblies>
        <add assembly=""netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"" />
      </assemblies>
    </compilation>
    <!--
		Enabling request validation in view pages would cause validation to occur
		after the input has already been processed by the controller. By default
		MVC performs request validation before a controller processes the input.
		To change this behavior apply the ValidateInputAttribute to a
		controller or action.
	-->
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
    <authentication mode=""Forms"">
      <forms loginUrl=""~/SignIn/SignIn"" timeout=""2880"" />
    </authentication>
    <httpRuntime maxRequestLength=""4096"" enableVersionHeader=""false"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Applications.AgendaPubAccess.PublicComment", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test42()
    {
        //Testing the parsing of the 231 system.webServer section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.webServer>
    <validation validateIntegratedModeConfiguration=""false"" />
    <modules runAllManagedModulesForAllRequests=""true"" />
    <handlers>
      <!--The format for this section should additionally contain the name and preCondition attributes.-->
      <!--The name attribute follows the pattern ""<path>_<verb>""-->
      <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
    <security>
      <requestFiltering>
        <!-- This should be set the same as the one in the Application Server's web.config. -->
        <requestLimits maxAllowedContentLength=""30000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <httpProtocol>
      <customHeaders>
        <remove name=""X-Powered-By"" />
      </customHeaders>
    </httpProtocol>
    <defaultDocument>
      <files>
        <remove value=""Default.htm"" />
        <add value=""Default.htm"" />
      </files>
    </defaultDocument>
  </system.webServer>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.webServer", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test43()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""EPR-Username"",""Value"":""Us3"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""EPR-Password"",""Value"":""P@ss"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""D@taS0urce"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Electronic-Plan-Review"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""EPR-Username"",""Value"":""Us3"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""EPR-Password"",""Value"":""P@ss"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""D@taS0urce"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Electronic-Plan-Review"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test44()
    {
        //Testing the parsing of the 231 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""OnBase Plan Review Portal""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""5"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":{""SourceName"":""Hyland""},""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":null,""RouteType"":""EventLog"",""Name"":""ErrorEventLog"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""2"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":{""OutputFormat"":""Minimal""},""RouteType"":""Console"",""Name"":""Console"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""OnBase Plan Review Portal"" />
    <Routes>
      <Route name=""DiagnosticsConsole"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Http"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""ErrorEventLog"">
        <add key=""minimum-level"" value=""Error"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""EventLog"" value=""Hyland"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""Console"">
        <add key=""minimum-level"" value=""Debug"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Console"" />
        <add key=""OutputFormat"" value=""Minimal"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
    </Routes>
    <AuditRoutes>
    </AuditRoutes>
  </Hyland.Logging>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Logging", xmldoc, new DefaultWebApplicationDataStructures());

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test45()
    {
        //Testing the Prebuilding of the 241 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[server]/[virtual directory]/Service.asmx","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test46()
    {
        //Testing the Prebuilding of the 241 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","StyleSheetPath","2","Stylesheet-Directory-Location","BasicBlue/","","",""},
            {"appSettings","add","AllowSignon","1","Allow-Sign-On","true","","",""},
            {"appSettings","add","AllowSignoff","1","Allow-Sign-Off","true","","",""},
            {"appSettings","add","DefaultTimeZone","2","Default-User-Time-Zone","64","","",""},
            {"appSettings","add","SearchStartYear","2","Search-Start-Year","2012","","",""},
            {"appSettings","add","DisplayDocumentsPerPage","2","Items-Per-Page","20","","",""},
            {"appSettings","add","MaxLookupResults","2","Max-Lookup-Results","20","","",""},
            {"appSettings","add","ResetPasswordLinkExpiration","2","Reset-Password-Link-Lifetime","60","","",""},
            {"appSettings","add","FileUploadDirectory","2","File-Upload-Directory","~/Upload","","",""},
            {"appSettings","add","FileUploadValidator","2","File-Upload-Validator","","","",""},
            {"appSettings","add","TokenAuthentication","1","Token-Authentication","false","","",""},
            {"appSettings","add","SingleSignOn","1","Allow-Single-Sign-On","false","","",""},
            {"appSettings","add","SingleSignOnSourceID","2","Source-ID","1","","",""},
            {"appSettings","add","SSOUserResolutionMode","2","Resolution-Mode","0","","",""},
            {"appSettings","add","CAPTCHAPublicKey","2","Public-CAPTCHA-Key","","","",""},
            {"appSettings","add","CAPTCHAPrivateKey","2","Private-CAPTCHA-Key","","","",""},
            {"appSettings","add","PasswordStrengthPattern","2","Password-Strength-Pattern","^(?=.{4,}).*$","","",""},
            {"appSettings","add","PasswordStrengthMessage","2","Password-Strength-Message","","","",""},
            {"appSettings","add","UsernameValidationPattern","2","Username-Validation-Pattern","[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+","","",""},
            {"appSettings","add","DisciplineItemsPerMenu","2","Discipline-Items-Per-Menu","15","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test47()
    {
        //Testing the Prebuilding of the 241 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web", "httpRuntime", "maxRequestLength", "2", "HTTP-Runtime-Maximum-Request-Length", "4096", "", "", ""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test48()
    {
        //Testing the Prebuilding of the 241 system.webServer section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test49()
    {
        //Testing the parsing of the 241 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[server]/[virtual directory]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://[server]/[virtual directory]/Service.asmx"" ServiceClientType=""SOAP"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test50()
    {
        //Testing the parsing of the 241 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StyleSheetPath"",""type"":""2"",""htmlIdName"":""Stylesheet-Directory-Location"",""Value"":""BasicBlue/"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignon"",""type"":""1"",""htmlIdName"":""Allow-Sign-On"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowSignoff"",""type"":""1"",""htmlIdName"":""Allow-Sign-Off"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DefaultTimeZone"",""type"":""2"",""htmlIdName"":""Default-User-Time-Zone"",""Value"":""64"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SearchStartYear"",""type"":""2"",""htmlIdName"":""Search-Start-Year"",""Value"":""2012"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisplayDocumentsPerPage"",""type"":""2"",""htmlIdName"":""Items-Per-Page"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxLookupResults"",""type"":""2"",""htmlIdName"":""Max-Lookup-Results"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ResetPasswordLinkExpiration"",""type"":""2"",""htmlIdName"":""Reset-Password-Link-Lifetime"",""Value"":""60"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadDirectory"",""type"":""2"",""htmlIdName"":""File-Upload-Directory"",""Value"":""~/Upload"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FileUploadValidator"",""type"":""2"",""htmlIdName"":""File-Upload-Validator"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TokenAuthentication"",""type"":""1"",""htmlIdName"":""Token-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOn"",""type"":""1"",""htmlIdName"":""Allow-Single-Sign-On"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SingleSignOnSourceID"",""type"":""2"",""htmlIdName"":""Source-ID"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SSOUserResolutionMode"",""type"":""2"",""htmlIdName"":""Resolution-Mode"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPublicKey"",""type"":""2"",""htmlIdName"":""Public-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CAPTCHAPrivateKey"",""type"":""2"",""htmlIdName"":""Private-CAPTCHA-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthPattern"",""type"":""2"",""htmlIdName"":""Password-Strength-Pattern"",""Value"":""^(?=.{4,}).*$"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PasswordStrengthMessage"",""type"":""2"",""htmlIdName"":""Password-Strength-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UsernameValidationPattern"",""type"":""2"",""htmlIdName"":""Username-Validation-Pattern"",""Value"":""[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DisciplineItemsPerMenu"",""type"":""2"",""htmlIdName"":""Discipline-Items-Per-Menu"",""Value"":""15"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""webpages:Enabled\"" value=\""false\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<appSettings>
    <add key=""StyleSheetPath"" value=""BasicBlue/"" />
    <add key=""AllowSignon"" value=""true"" />
    <add key=""AllowSignoff"" value=""true"" />
    <add key=""DefaultTimeZone"" value=""64"" />
    <add key=""SearchStartYear"" value=""2012"" />
    <add key=""DisplayDocumentsPerPage"" value=""20"" />
    <add key=""MaxLookupResults"" value=""20"" />
    <add key=""ResetPasswordLinkExpiration"" value=""60"" />
    <add key=""FileUploadDirectory"" value=""~/Upload"" />
    <add key=""FileUploadValidator"" value="""" />
    <add key=""TokenAuthentication"" value=""false"" />
    <add key=""SingleSignOn"" value=""false"" />
    <add key=""SingleSignOnSourceID"" value=""1"" />
    <add key=""SSOUserResolutionMode"" value=""0"" />
    <add key=""CAPTCHAPublicKey"" value="""" />
    <add key=""CAPTCHAPrivateKey"" value="""" />
    <add key=""PasswordStrengthPattern"" value=""^(?=.{4,}).*$"" />
    <add key=""PasswordStrengthMessage"" value="""" />
    <!-- UsernameValidationPattern default value = [\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+ -->
    <add key=""UsernameValidationPattern"" value=""[\da-zA-Z\u00C0-\u00D6\u00D8-\u00F6\u00F8-\u00FF]+"" />
    <add key=""DisciplineItemsPerMenu"" value=""15"" />
    <add key=""webpages:Enabled"" value=""false"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test51()
    {
        //Testing the parsing of the 241 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.web>
    <globalization enableClientBasedCulture=""true"" culture=""auto:en-US"" uiCulture=""auto:en"" />
    <compilation debug=""true"" targetFramework=""4.7.2"">
      <buildProviders>
        <add extension="".template"" type=""System.Web.WebPages.Razor.RazorBuildProvider,System.Web.WebPages.Razor"" />
      </buildProviders>
      <assemblies>
        <add assembly=""netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"" />
      </assemblies>
    </compilation>
    <!--
		Enabling request validation in view pages would cause validation to occur
		after the input has already been processed by the controller. By default
		MVC performs request validation before a controller processes the input.
		To change this behavior apply the ValidateInputAttribute to a
		controller or action.
	-->
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
    <authentication mode=""Forms"">
      <forms loginUrl=""~/SignIn/SignIn"" timeout=""2880"" />
    </authentication>
    <httpRuntime maxRequestLength=""4096"" enableVersionHeader=""false"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Applications.AgendaPubAccess.PublicComment", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test52()
    {
        //Testing the parsing of the 241 system.webServer section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.webServer>
    <validation validateIntegratedModeConfiguration=""false"" />
    <modules runAllManagedModulesForAllRequests=""true"" />
    <handlers>
      <!--The format for this section should additionally contain the name and preCondition attributes.-->
      <!--The name attribute follows the pattern ""<path>_<verb>""-->
      <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
    <security>
      <requestFiltering>
        <!-- This should be set the same as the one in the Application Server's web.config. -->
        <requestLimits maxAllowedContentLength=""30000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <httpProtocol>
      <customHeaders>
        <remove name=""X-Powered-By"" />
      </customHeaders>
    </httpProtocol>
    <defaultDocument>
      <files>
        <remove value=""Default.htm"" />
        <add value=""Default.htm"" />
      </files>
    </defaultDocument>
  </system.webServer>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.webServer", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test53()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""EPR-Username"",""Value"":""Us3"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""EPR-Password"",""Value"":""P@ss"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""D@taS0urce"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Electronic-Plan-Review"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""EPR-Username"",""Value"":""Us3"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""EPR-Password"",""Value"":""P@ss"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""D@taS0urce"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.PlanReview.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Electronic-Plan-Review"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test54()
    {
        //Testing the parsing of the 241 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""23.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""23.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""OnBase Plan Review Portal""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""5"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":{""SourceName"":""Hyland""},""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":null,""RouteType"":""EventLog"",""Name"":""ErrorEventLog"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""2"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":{""OutputFormat"":""Minimal""},""RouteType"":""Console"",""Name"":""Console"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""OnBase Plan Review Portal"" />
    <Routes>
      <Route name=""DiagnosticsConsole"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Http"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""ErrorEventLog"">
        <add key=""minimum-level"" value=""Error"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""EventLog"" value=""Hyland"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""Console"">
        <add key=""minimum-level"" value=""Debug"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Console"" />
        <add key=""OutputFormat"" value=""Minimal"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
    </Routes>
    <AuditRoutes>
    </AuditRoutes>
  </Hyland.Logging>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Logging", xmldoc, new DefaultWebApplicationDataStructures());

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }
}