using COMACON.config;
using COMACONTranslationToHelperUtility;
using FluentAssertions;
using Newtonsoft.Json;
using System.Xml;

namespace COMACON.tests;

public class AgendaOnlineTests
{
    private readonly string cleanWebApplicationDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

    [Fact]
    public void Test1()
    {
        //Testing to validate that the key is found and the appropriate value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings>
    <add key=""StreamChunkSize"" value=""65536"" />
    <add key=""PlayerSourceFilePath"" value=""../Scripts/jwplayer"" />
    <add key=""PlayerVersion"" value=""JWPlayer 8.8.5"" />
    <add key=""MinPoolSize"" value=""1"" />
    <add key=""MaxPoolSize"" value=""5"" />
    <add key=""webpages:Enabled"" value=""false"" />
  </appSettings>";

        string keyName = "PlayerVersion";
        string defaultValue = "JWPlayer 8.8.5";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getNonStandardXmlValue(xmldoc.DocumentElement, keyName, defaultValue);

        value.Should().Be("JWPlayer 8.8.5");
    }

    [Fact]
    public void Test2()
    {
        //Testing to validate that the key is not found and the default value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings>
    <add key=""StreamChunkSize"" value=""65536"" />
    <add key=""PlayerSourceFilePath"" value=""../Scripts/jwplayer"" />
    <add key=""PlayerVersion"" value=""JWPlayer 8.8.5"" />
    <add key=""MinPoolSize"" value=""1"" />
    <add key=""MaxPoolSize"" value=""5"" />
    <add key=""webpages:Enabled"" value=""false"" />
  </appSettings>";

        string keyName = "PlayerVersion";
        string defaultValue = "JWPlayer 8.8.5";

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
    <ApplicationServer Url=""http://localhost/AppServer/Service.asmx"" ServiceClientType=""SOAP"" />
  </Hyland.Services.Client>";

        string nodeName = "ApplicationServer";
        string attributeName = "Url";
        string defaultValue = "Default Name";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getStandardXmlValue(xmldoc.DocumentElement, nodeName, attributeName, defaultValue);

        value.Should().Be("http://localhost/AppServer/Service.asmx");
    }

    [Fact]
    public void Test4()
    {
        //Testing to validate that the key is not found and the default value is returned.
        //This is testing with just one level of nesting.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.asmx"" ServiceClientType=""SOAP"" />
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

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://localhost/AppServer/Service.asmx","","",""},
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

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.8.5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","StreamChunkSize","2","Stream-Chunk-Size","65536","","",""},
            {"appSettings","add","PlayerSourceFilePath","2","Player-Source-File-Path","../Scripts/jwplayer","","",""},
            {"appSettings","add","PlayerVersion","2","Player-Version","JWPlayer 8.8.5","","",""},
            {"appSettings","add","MinPoolSize","2","Min-Pool-Size","1","","",""},
            {"appSettings","add","MaxPoolSize","2","Max-Pool-Size","5","","",""},
            {"appSettings","add","webpages:Enabled","1","webpages-Enabled","false","","",""}
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

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","name","2","Integration-Name","","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","url","2","Integration-URL","[URL from Unity forms config]","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","token","2","Integration-Token","[Token from Unity forms config]","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","AvailabilityFromMeetingStart","2","Availability-From-Meeting-Start","0","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test8()
    {
        //Testing the parsing of the 211 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.asmx"" ServiceClientType=""SOAP"" />
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
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.8.5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.8.5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<appSettings>
    <add key=""StreamChunkSize"" value=""65536"" />
    <add key=""PlayerSourceFilePath"" value=""../Scripts/jwplayer"" />
    <add key=""PlayerVersion"" value=""JWPlayer 8.8.5"" />
    <add key=""MinPoolSize"" value=""1"" />
    <add key=""MaxPoolSize"" value=""5"" />
    <add key=""webpages:Enabled"" value=""false"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test10()
    {
        //Testing the parsing of the 211 Hyland.Applications.AgendaPubAccess.PublicComment section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Applications.AgendaPubAccess.PublicComment>
    <integrations>
      <!-- AvailabilityFromMeetingStart: 
     This value is in hours. It is based on the start time of the meeting.
     This value determines when the Make Comment button is no longer available in the meeting.
     This value can be a whole number, decimal, or negative value (a negative value disables the button by the number of hours specified before the meeting start time).
     The default value is 0, meaning that once the meeting start time passes, the button is disabled. -->
      <integration name="""" url=""[URL from Unity forms config]"" token=""[Token from Unity forms config]"" AvailabilityFromMeetingStart=""0"">
        <meeting_types>
          <meeting_type name="""" />
        </meeting_types>
        <agenda_fields>
          <field name=""meeting_name"" form_field_id="""" />
          <field name=""meeting_date"" form_field_id="""" />
          <field name=""item_id"" form_field_id="""" />
          <field name=""item_title"" form_field_id="""" />
        </agenda_fields>
      </integration>
    </integrations>
  </Hyland.Applications.AgendaPubAccess.PublicComment>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Applications.AgendaPubAccess.PublicComment", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test11()
    {
        //Testing the parsing of the 211 appSettings section from the web.config file.
        //This test will encounter an unknown appSettings element and will make sure that it is added to the unknownElementKeys section.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.8.5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.8.5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""dummyunknownkey\"" value=\""true\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<appSettings>
    <add key=""StreamChunkSize"" value=""65536"" />
    <add key=""PlayerSourceFilePath"" value=""../Scripts/jwplayer"" />
    <add key=""PlayerVersion"" value=""JWPlayer 8.8.5"" />
    <add key=""MinPoolSize"" value=""1"" />
    <add key=""MaxPoolSize"" value=""5"" />
    <add key=""webpages:Enabled"" value=""false"" />
    <add key=""dummyunknownkey"" value=""true"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test12()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Session-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Session-Password"",""Value"":""Testing2"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""None"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Agenda-Online-Access"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Session-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Session-Password"",""Value"":""Testing2"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""None"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Agenda-Online-Access"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test13()
    {
        //Testing the parsing of the 211 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""OnBase Agenda Online""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""OnBase Agenda Online"" />
    <Routes>
      <Route name=""DiagnosticsConsole"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Http"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""True"" />
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
    public void Test14()
    {
        //Testing the Prebuilding of the 221 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://localhost/AppServer/Service.asmx","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test15()
    {
        //Testing the Prebuilding of the 221 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","StreamChunkSize","2","Stream-Chunk-Size","65536","","",""},
            {"appSettings","add","PlayerSourceFilePath","2","Player-Source-File-Path","../Scripts/jwplayer","","",""},
            {"appSettings","add","PlayerVersion","2","Player-Version","JWPlayer 8.24.6","","",""},
            {"appSettings","add","MinPoolSize","2","Min-Pool-Size","1","","",""},
            {"appSettings","add","MaxPoolSize","2","Max-Pool-Size","5","","",""},
            {"appSettings","add","webpages:Enabled","1","webpages-Enabled","false","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test16()
    {
        //Testing the Prebuilding of the 221 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","name","2","Integration-Name","","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","url","2","Integration-URL","[URL from Unity forms config]","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","token","2","Integration-Token","[Token from Unity forms config]","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","AvailabilityFromMeetingStart","2","Availability-From-Meeting-Start","0","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test17()
    {
        //Testing the parsing of the 211 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.asmx"" ServiceClientType=""SOAP"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test18()
    {
        //Testing the parsing of the 211 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<appSettings>
    <add key=""StreamChunkSize"" value=""65536"" />
    <add key=""PlayerSourceFilePath"" value=""../Scripts/jwplayer"" />
    <add key=""PlayerVersion"" value=""JWPlayer 8.24.6"" />
    <add key=""MinPoolSize"" value=""1"" />
    <add key=""MaxPoolSize"" value=""5"" />
    <add key=""webpages:Enabled"" value=""false"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test19()
    {
        //Testing the parsing of the 211 Hyland.Applications.AgendaPubAccess.PublicComment section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Applications.AgendaPubAccess.PublicComment>
    <integrations>
      <!-- AvailabilityFromMeetingStart: 
     This value is in hours. It is based on the start time of the meeting.
     This value determines when the Make Comment button is no longer available in the meeting.
     This value can be a whole number, decimal, or negative value (a negative value disables the button by the number of hours specified before the meeting start time).
     The default value is 0, meaning that once the meeting start time passes, the button is disabled. -->
      <integration name="""" url=""[URL from Unity forms config]"" token=""[Token from Unity forms config]"" AvailabilityFromMeetingStart=""0"">
        <meeting_types>
          <meeting_type name="""" />
        </meeting_types>
        <agenda_fields>
          <field name=""meeting_name"" form_field_id="""" />
          <field name=""meeting_date"" form_field_id="""" />
          <field name=""item_id"" form_field_id="""" />
          <field name=""item_title"" form_field_id="""" />
        </agenda_fields>
      </integration>
    </integrations>
  </Hyland.Applications.AgendaPubAccess.PublicComment>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Applications.AgendaPubAccess.PublicComment", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test20()
    {
        //Testing the parsing of the 211 appSettings section from the web.config file.
        //This test will encounter an unknown appSettings element and will make sure that it is added to the unknownElementKeys section.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""dummyunknownkey\"" value=\""true\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<appSettings>
    <add key=""StreamChunkSize"" value=""65536"" />
    <add key=""PlayerSourceFilePath"" value=""../Scripts/jwplayer"" />
    <add key=""PlayerVersion"" value=""JWPlayer 8.24.6"" />
    <add key=""MinPoolSize"" value=""1"" />
    <add key=""MaxPoolSize"" value=""5"" />
    <add key=""webpages:Enabled"" value=""false"" />
    <add key=""dummyunknownkey"" value=""true"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test21()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Session-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Session-Password"",""Value"":""Testing2"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""None"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Agenda-Online-Access"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Session-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Session-Password"",""Value"":""Testing2"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""None"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Agenda-Online-Access"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test22()
    {
        //Testing the parsing of the 211 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""OnBase Agenda Online""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""OnBase Agenda Online"" />
    <Routes>
      <Route name=""DiagnosticsConsole"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Http"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""True"" />
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
    public void Test23()
    {
        //Testing the Prebuilding of the 231 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://localhost/AppServer/Service.asmx","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test24()
    {
        //Testing the Prebuilding of the 231 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""GoogleAnalytics"",""type"":""2"",""htmlIdName"":""Google-Analytics"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","StreamChunkSize","2","Stream-Chunk-Size","65536","","",""},
            {"appSettings", "add", "PlayerSourceFilePath", "2", "Player-Source-File-Path", "../Scripts/jwplayer", "", "", ""},
            {"appSettings","add","PlayerVersion","2","Player-Version","JWPlayer 8.24.6","","",""},
            {"appSettings","add","MinPoolSize","2","Min-Pool-Size","1","","",""},
            {"appSettings","add","MaxPoolSize","2","Max-Pool-Size","5","","",""},
            {"appSettings", "add", "webpages:Enabled", "1", "webpages-Enabled", "false", "", "", ""},
            {"appSettings","add","GoogleAnalytics","2","Google-Analytics","","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test25()
    {
        //Testing the Prebuilding of the 231 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","name","2","Integration-Name","","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","url","2","Integration-URL","[URL from Unity forms config]","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","token","2","Integration-Token","[Token from Unity forms config]","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","AvailabilityFromMeetingStart","2","Availability-From-Meeting-Start","0","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test26()
    {
        //Testing the parsing of the 231 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.asmx"" ServiceClientType=""SOAP"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test27()
    {
        //Testing the parsing of the 231 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""GoogleAnalytics"",""type"":""2"",""htmlIdName"":""Google-Analytics"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""GoogleAnalytics"",""type"":""2"",""htmlIdName"":""Google-Analytics"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<appSettings>
		<add key=""StreamChunkSize"" value=""65536"" />
		<add key=""PlayerSourceFilePath"" value=""../Scripts/jwplayer"" />
		<add key=""PlayerVersion"" value=""JWPlayer 8.24.6"" />
		<add key=""MinPoolSize"" value=""1"" />
		<add key=""MaxPoolSize"" value=""5"" />
		<add key=""webpages:Enabled"" value=""false"" />
		<add key=""GoogleAnalytics"" value="""" />
	</appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test28()
    {
        //Testing the parsing of the 231 Hyland.Applications.AgendaPubAccess.PublicComment section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Applications.AgendaPubAccess.PublicComment>
    <integrations>
      <!-- AvailabilityFromMeetingStart: 
     This value is in hours. It is based on the start time of the meeting.
     This value determines when the Make Comment button is no longer available in the meeting.
     This value can be a whole number, decimal, or negative value (a negative value disables the button by the number of hours specified before the meeting start time).
     The default value is 0, meaning that once the meeting start time passes, the button is disabled. -->
      <integration name="""" url=""[URL from Unity forms config]"" token=""[Token from Unity forms config]"" AvailabilityFromMeetingStart=""0"">
        <meeting_types>
          <meeting_type name="""" />
        </meeting_types>
        <agenda_fields>
          <field name=""meeting_name"" form_field_id="""" />
          <field name=""meeting_date"" form_field_id="""" />
          <field name=""item_id"" form_field_id="""" />
          <field name=""item_title"" form_field_id="""" />
        </agenda_fields>
      </integration>
    </integrations>
  </Hyland.Applications.AgendaPubAccess.PublicComment>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Applications.AgendaPubAccess.PublicComment", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test29()
    {
        //Testing the parsing of the 231 appSettings section from the web.config file.
        //This test will encounter an unknown appSettings element and will make sure that it is added to the unknownElementKeys section.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.8.5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.8.5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""dummyunknownkey\"" value=\""true\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<appSettings>
    <add key=""StreamChunkSize"" value=""65536"" />
    <add key=""PlayerSourceFilePath"" value=""../Scripts/jwplayer"" />
    <add key=""PlayerVersion"" value=""JWPlayer 8.8.5"" />
    <add key=""MinPoolSize"" value=""1"" />
    <add key=""MaxPoolSize"" value=""5"" />
    <add key=""webpages:Enabled"" value=""false"" />
    <add key=""dummyunknownkey"" value=""true"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test30()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Session-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Session-Password"",""Value"":""Testing2"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""None"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Agenda-Online-Access"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Session-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Session-Password"",""Value"":""Testing2"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""None"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Agenda-Online-Access"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test31()
    {
        //Testing the parsing of the 231 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""23.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""23.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""OnBase Agenda Online""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""OnBase Agenda Online"" />
    <Routes>
      <Route name=""DiagnosticsConsole"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Http"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""True"" />
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
    public void Test32()
    {
        //Testing the Prebuilding of the 221 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://localhost/AppServer/Service.asmx","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test33()
    {
        //Testing the Prebuilding of the 221 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""GoogleAnalytics"",""type"":""2"",""htmlIdName"":""Google-Analytics"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","StreamChunkSize","2","Stream-Chunk-Size","65536","","",""},
            {"appSettings","add","PlayerSourceFilePath","2","Player-Source-File-Path","../Scripts/jwplayer","","",""},
            {"appSettings","add","PlayerVersion","2","Player-Version","JWPlayer 8.24.6","","",""},
            {"appSettings","add","MinPoolSize","2","Min-Pool-Size","1","","",""},
            {"appSettings","add","MaxPoolSize","2","Max-Pool-Size","5","","",""},
            {"appSettings","add","webpages:Enabled","1","webpages-Enabled","false","","",""},
            {"appSettings","add","GoogleAnalytics","2","Google-Analytics","","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test34()
    {
        //Testing the Prebuilding of the 221 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","name","2","Integration-Name","","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","url","2","Integration-URL","[URL from Unity forms config]","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","token","2","Integration-Token","[Token from Unity forms config]","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","AvailabilityFromMeetingStart","2","Availability-From-Meeting-Start","0","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test35()
    {
        //Testing the parsing of the 221 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.asmx"" ServiceClientType=""SOAP"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test36()
    {
        //Testing the parsing of the 221 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""GoogleAnalytics"",""type"":""2"",""htmlIdName"":""Google-Analytics"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""GoogleAnalytics"",""type"":""2"",""htmlIdName"":""Google-Analytics"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<appSettings>
		<add key=""StreamChunkSize"" value=""65536"" />
		<add key=""PlayerSourceFilePath"" value=""../Scripts/jwplayer"" />
		<add key=""PlayerVersion"" value=""JWPlayer 8.24.6"" />
		<add key=""MinPoolSize"" value=""1"" />
		<add key=""MaxPoolSize"" value=""5"" />
		<add key=""webpages:Enabled"" value=""false"" />
		<add key=""GoogleAnalytics"" value="""" />
	</appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test37()
    {
        //Testing the parsing of the 221 Hyland.Applications.AgendaPubAccess.PublicComment section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Applications.AgendaPubAccess.PublicComment>
    <integrations>
      <!-- AvailabilityFromMeetingStart: 
     This value is in hours. It is based on the start time of the meeting.
     This value determines when the Make Comment button is no longer available in the meeting.
     This value can be a whole number, decimal, or negative value (a negative value disables the button by the number of hours specified before the meeting start time).
     The default value is 0, meaning that once the meeting start time passes, the button is disabled. -->
      <integration name="""" url=""[URL from Unity forms config]"" token=""[Token from Unity forms config]"" AvailabilityFromMeetingStart=""0"">
        <meeting_types>
          <meeting_type name="""" />
        </meeting_types>
        <agenda_fields>
          <field name=""meeting_name"" form_field_id="""" />
          <field name=""meeting_date"" form_field_id="""" />
          <field name=""item_id"" form_field_id="""" />
          <field name=""item_title"" form_field_id="""" />
        </agenda_fields>
      </integration>
    </integrations>
  </Hyland.Applications.AgendaPubAccess.PublicComment>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Applications.AgendaPubAccess.PublicComment", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test38()
    {
        //Testing the parsing of the 221 appSettings section from the web.config file.
        //This test will encounter an unknown appSettings element and will make sure that it is added to the unknownElementKeys section.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.8.5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.8.5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""dummyunknownkey\"" value=\""true\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<appSettings>
    <add key=""StreamChunkSize"" value=""65536"" />
    <add key=""PlayerSourceFilePath"" value=""../Scripts/jwplayer"" />
    <add key=""PlayerVersion"" value=""JWPlayer 8.8.5"" />
    <add key=""MinPoolSize"" value=""1"" />
    <add key=""MaxPoolSize"" value=""5"" />
    <add key=""webpages:Enabled"" value=""false"" />
    <add key=""dummyunknownkey"" value=""true"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test39()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Session-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Session-Password"",""Value"":""Testing2"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""None"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Agenda-Online-Access"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Session-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Session-Password"",""Value"":""Testing2"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""None"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Agenda-Online-Access"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test40()
    {
        //Testing the parsing of the 221 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""22.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""22.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""OnBase Agenda Online""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""OnBase Agenda Online"" />
    <Routes>
      <Route name=""DiagnosticsConsole"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Http"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""True"" />
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
    public void Test41()
    {
        //Testing the Prebuilding of the 241 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://localhost/AppServer/Service.asmx","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test42()
    {
        //Testing the Prebuilding of the 241 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""GoogleAnalytics"",""type"":""2"",""htmlIdName"":""Google-Analytics"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","StreamChunkSize","2","Stream-Chunk-Size","65536","","",""},
            {"appSettings","add","PlayerSourceFilePath","2","Player-Source-File-Path","../Scripts/jwplayer","","",""},
            {"appSettings","add","PlayerVersion","2","Player-Version","JWPlayer 8.24.6","","",""},
            {"appSettings","add","MinPoolSize","2","Min-Pool-Size","1","","",""},
            {"appSettings","add","MaxPoolSize","2","Max-Pool-Size","5","","",""},
            {"appSettings","add","webpages:Enabled","1","webpages-Enabled","false","","",""},
            {"appSettings","add","GoogleAnalytics","2","Google-Analytics","","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test43()
    {
        //Testing the Prebuilding of the 241 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","name","2","Integration-Name","","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","url","2","Integration-URL","[URL from Unity forms config]","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","token","2","Integration-Token","[Token from Unity forms config]","","",""},
            {"Hyland.Applications.AgendaPubAccess.PublicComment","integrations/integration","AvailabilityFromMeetingStart","2","Availability-From-Meeting-Start","0","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test44()
    {
        //Testing the parsing of the 241 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer/Service.asmx"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.asmx"" ServiceClientType=""SOAP"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test45()
    {
        //Testing the parsing of the 241 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""GoogleAnalytics"",""type"":""2"",""htmlIdName"":""Google-Analytics"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.24.6"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""GoogleAnalytics"",""type"":""2"",""htmlIdName"":""Google-Analytics"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<appSettings>
		<add key=""StreamChunkSize"" value=""65536"" />
		<add key=""PlayerSourceFilePath"" value=""../Scripts/jwplayer"" />
		<add key=""PlayerVersion"" value=""JWPlayer 8.24.6"" />
		<add key=""MinPoolSize"" value=""1"" />
		<add key=""MaxPoolSize"" value=""5"" />
		<add key=""webpages:Enabled"" value=""false"" />
		<add key=""GoogleAnalytics"" value="""" />
	</appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test46()
    {
        //Testing the parsing of the 241 Hyland.Applications.AgendaPubAccess.PublicComment section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""name"",""type"":""2"",""htmlIdName"":""Integration-Name"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""url"",""type"":""2"",""htmlIdName"":""Integration-URL"",""Value"":""[URL from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""token"",""type"":""2"",""htmlIdName"":""Integration-Token"",""Value"":""[Token from Unity forms config]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.PublicComment"",""PathName"":""integrations/integration"",""AttributeName"":""AvailabilityFromMeetingStart"",""type"":""2"",""htmlIdName"":""Availability-From-Meeting-Start"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Applications.AgendaPubAccess.PublicComment>
    <integrations>
      <!-- AvailabilityFromMeetingStart: 
     This value is in hours. It is based on the start time of the meeting.
     This value determines when the Make Comment button is no longer available in the meeting.
     This value can be a whole number, decimal, or negative value (a negative value disables the button by the number of hours specified before the meeting start time).
     The default value is 0, meaning that once the meeting start time passes, the button is disabled. -->
      <integration name="""" url=""[URL from Unity forms config]"" token=""[Token from Unity forms config]"" AvailabilityFromMeetingStart=""0"">
        <meeting_types>
          <meeting_type name="""" />
        </meeting_types>
        <agenda_fields>
          <field name=""meeting_name"" form_field_id="""" />
          <field name=""meeting_date"" form_field_id="""" />
          <field name=""item_id"" form_field_id="""" />
          <field name=""item_title"" form_field_id="""" />
        </agenda_fields>
      </integration>
    </integrations>
  </Hyland.Applications.AgendaPubAccess.PublicComment>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Applications.AgendaPubAccess.PublicComment", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test47()
    {
        //Testing the parsing of the 241 appSettings section from the web.config file.
        //This test will encounter an unknown appSettings element and will make sure that it is added to the unknownElementKeys section.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.8.5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""StreamChunkSize"",""type"":""2"",""htmlIdName"":""Stream-Chunk-Size"",""Value"":""65536"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerSourceFilePath"",""type"":""2"",""htmlIdName"":""Player-Source-File-Path"",""Value"":""../Scripts/jwplayer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PlayerVersion"",""type"":""2"",""htmlIdName"":""Player-Version"",""Value"":""JWPlayer 8.8.5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MinPoolSize"",""type"":""2"",""htmlIdName"":""Min-Pool-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxPoolSize"",""type"":""2"",""htmlIdName"":""Max-Pool-Size"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webpages:Enabled"",""type"":""1"",""htmlIdName"":""webpages-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""dummyunknownkey\"" value=\""true\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<appSettings>
    <add key=""StreamChunkSize"" value=""65536"" />
    <add key=""PlayerSourceFilePath"" value=""../Scripts/jwplayer"" />
    <add key=""PlayerVersion"" value=""JWPlayer 8.8.5"" />
    <add key=""MinPoolSize"" value=""1"" />
    <add key=""MaxPoolSize"" value=""5"" />
    <add key=""webpages:Enabled"" value=""false"" />
    <add key=""dummyunknownkey"" value=""true"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test48()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Session-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Session-Password"",""Value"":""Testing2"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""None"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Agenda-Online-Access"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionUser"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Session-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""SessionPassword"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Session-Password"",""Value"":""Testing2"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""DataSource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""None"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Applications.AgendaPubAccess.Client"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Agenda-Online-Access"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test49()
    {
        //Testing the parsing of the 241 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""24.1.2.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""24.1.2.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""OnBase Agenda Online""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""OnBase Agenda Online"" />
    <Routes>
      <Route name=""DiagnosticsConsole"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Http"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""True"" />
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
