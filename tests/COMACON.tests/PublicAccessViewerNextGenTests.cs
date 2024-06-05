using COMACON.config;
using COMACONTranslationToHelperUtility;
using FluentAssertions;
using Newtonsoft.Json;
using System.Xml;

namespace COMACON.tests;

public class PublicAccessViewerNextGenTests
{
    private readonly string cleanWebApplicationDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";
    private readonly string cleanWebApplicationDataStructure211WithVersionNumber = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";
    private readonly string cleanWebApplicationDataStructure221WithVersionNumber = @"{""Type"":"""",""Version"":""22.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";
    private readonly string cleanWebApplicationDataStructure231WithVersionNumber = @"{""Type"":"""",""Version"":""23.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";
    private readonly string cleanWebApplicationDataStructure241WithVersionNumber = @"{""Type"":"""",""Version"":""24.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

    [Fact]
    public void Test1()
    {
        //Testing to validate that the key is found and the appropriate value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings>
    <!-- Whether or not to encrypt the document ID when displaying search results. -->
    <add key=""EncryptDocId"" value=""false"" />
    <!-- Whether or not to use the configured Custom Query display columns when displaying search results. -->
    <add key=""UseDisplayColumns"" value=""true"" />
    <!-- Search results will be limited to this number. ""0"" implies unlimited. -->
    <add key=""QueryLimit"" value=""0"" />
    <!-- The size in bytes to use when downloading the document. -->
    <add key=""ChunkSize"" value=""512000"" />
    <!--Viewer Mode
    Valid values are:
    -PDF: All documents will be converted to PDF and streamed to the viewer.
      If too large (see SizeToPrompt setting), will prompt to download PDF file instead.
    -Native: All documents will download in their native format and will not display in the viewer.
    -NativeOptional: Documents will stream to the viewer as PDF and a link in the viewer will
      provide the option to download the file in its native format.
    -->
    <add key=""ViewerMode"" value=""PDF"" />
    <!-- Overlay Mode - The type of overlay so see on documents that use one. Note that
    this option can only be used if the PDF viewer mode is used when viewing documents that
    use an overlay. This will not affect other documents.
    Valid values are:
    - Off - Insert data into a blank, white page.
    - Print - Print view as shown in any other OnBase client.
    - View - The original view. The document will show as it does in any other OnBase client.
    -->
    <add key=""OverlayMode"" value=""Print"" />
    <!--Caching Settings-->
    <!--Path to the Public Access cache-->
    <add key=""CachePath"" value=""C:\DocCache"" />
    <!--Number of days before a document in the cache becomes stale-->
    <add key=""ExpireTime"" value=""1"" />
    <!--Maximum cache size (GB)-->
    <add key=""MaxCacheSize"" value=""10"" />
    <!--Any files over this file size (MB) get cached-->
    <add key=""SizeToCache"" value=""1"" />
    <!--Prompt to open/save any files over this file size (MB) instead of opening directly in the viewer-->
    <add key=""SizeToPrompt"" value=""20"" />
    <!-- The approximate time, in minutes, after which to rest the throttle cache (i.e. everyone will be unthrottled, limits reset). A value of 0 or less will disable throttling. -->
    <add key=""ThrottleResetTimer"" value=""5"" />
    <!-- The number of requests each user can make before being throttled. A value of 0 or less will disable throttling. -->
    <add key=""ThrottleThreshold"" value=""1000"" />
    <!-- Whether or not to allow the browser to cache documents for a short amount of time to reduce repeated requests.  -->
    <add key=""EnableBrowserCaching"" value=""false"" />
    <!-- Whether or not to show decoration/formatting for document names (i.e. <yellow>). Only works on autonames - decoration will always be applied to display columns, regardless of this setting. -->
    <add key=""DecorateDocumentNames"" value=""true"" />
    <add key=""TestingUnknown"" value=""true"" />
  </appSettings>";

        string keyName = "SizeToCache";
        string defaultValue = "1";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getNonStandardXmlValue(xmldoc.DocumentElement, keyName, defaultValue);

        value.Should().Be("1");
    }

    [Fact]
    public void Test2()
    {
        //Testing to validate that the key is not found and the default value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings>
    <!-- Whether or not to encrypt the document ID when displaying search results. -->
    <add key=""EncryptDocId"" value=""false"" />
    <!-- Whether or not to use the configured Custom Query display columns when displaying search results. -->
    <add key=""UseDisplayColumns"" value=""true"" />
    <!-- Search results will be limited to this number. ""0"" implies unlimited. -->
    <add key=""QueryLimit"" value=""0"" />
    <!-- The size in bytes to use when downloading the document. -->
    <add key=""ChunkSize"" value=""512000"" />
    <!--Viewer Mode
    Valid values are:
    -PDF: All documents will be converted to PDF and streamed to the viewer.
      If too large (see SizeToPrompt setting), will prompt to download PDF file instead.
    -Native: All documents will download in their native format and will not display in the viewer.
    -NativeOptional: Documents will stream to the viewer as PDF and a link in the viewer will
      provide the option to download the file in its native format.
    -->
    <add key=""ViewerMode"" value=""PDF"" />
    <!-- Overlay Mode - The type of overlay so see on documents that use one. Note that
    this option can only be used if the PDF viewer mode is used when viewing documents that
    use an overlay. This will not affect other documents.
    Valid values are:
    - Off - Insert data into a blank, white page.
    - Print - Print view as shown in any other OnBase client.
    - View - The original view. The document will show as it does in any other OnBase client.
    -->
    <add key=""OverlayMode"" value=""Print"" />
    <!--Caching Settings-->
    <!--Path to the Public Access cache-->
    <add key=""CachePath"" value=""C:\DocCache"" />
    <!--Number of days before a document in the cache becomes stale-->
    <add key=""ExpireTime"" value=""1"" />
    <!--Maximum cache size (GB)-->
    <add key=""MaxCacheSize"" value=""10"" />
    <!--Any files over this file size (MB) get cached-->
    <add key=""SizeToCache"" value=""1"" />
    <!--Prompt to open/save any files over this file size (MB) instead of opening directly in the viewer-->
    <add key=""SizeToPrompt"" value=""20"" />
    <!-- The approximate time, in minutes, after which to rest the throttle cache (i.e. everyone will be unthrottled, limits reset). A value of 0 or less will disable throttling. -->
    <add key=""ThrottleResetTimer"" value=""5"" />
    <!-- The number of requests each user can make before being throttled. A value of 0 or less will disable throttling. -->
    <add key=""ThrottleThreshold"" value=""1000"" />
    <!-- Whether or not to allow the browser to cache documents for a short amount of time to reduce repeated requests.  -->
    <add key=""EnableBrowserCaching"" value=""false"" />
    <!-- Whether or not to show decoration/formatting for document names (i.e. <yellow>). Only works on autonames - decoration will always be applied to display columns, regardless of this setting. -->
    <add key=""DecorateDocumentNames"" value=""true"" />
    <add key=""TestingUnknown"" value=""true"" />
  </appSettings>";

        string keyName = "sizeToCache";
        string defaultValue = "1";

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

        var xmlNode = @"<system.web>
    <compilation debug=""false"" targetFramework=""4.7.2"" />
    <httpRuntime executionTimeout=""10"" targetFramework=""4.7.2"" />
  </system.web>";

        string nodeName = "httpRuntime";
        string attributeName = "executionTimeout";
        string defaultValue = "100";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getStandardXmlValue(xmldoc.DocumentElement, nodeName, attributeName, defaultValue);

        value.Should().Be("10");
    }

    [Fact]
    public void Test4()
    {
        //Testing to validate that the key is found and the appropriate value is returned.
        //This is testing with just one level of nesting.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<system.web>
    <compilation debug=""false"" targetFramework=""4.7.2"" />
    <httpRuntime executionTimeout=""10"" targetFramework=""4.7.2"" />
  </system.web>";

        string nodeName = "httpRuntime";
        string attributeName = "ExecutionTimeout";
        string defaultValue = "100";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getStandardXmlValue(xmldoc.DocumentElement, nodeName, attributeName, defaultValue);

        value.Should().Be(defaultValue);
    }

    [Fact]
    public void Test5()
    {
        //Testing the Prebuilding of the 211 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OverlayMode"",""type"":""2"",""htmlIdName"":""Default-Overlay-Mode"",""Value"":""Print"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleResetTimer"",""type"":""2"",""htmlIdName"":""Interval-Between-Throttle-Cache-Resets"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleThreshold"",""type"":""2"",""htmlIdName"":""Amount-of-Requests-During-Each-Throttle-Interval"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserCaching"",""type"":""1"",""htmlIdName"":""Enable-Local-Browser-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DecorateDocumentNames"",""type"":""1"",""htmlIdName"":""Decorate-Document-Names"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","EncryptDocId","1","Encrypt-Doc-ID","true","","",""},
            {"appSettings","add","UseDisplayColumns","1","Use-Display-Columns","true","","",""},
            {"appSettings", "add", "QueryLimit", "2", "Query-Limit", "0", "", "", ""},
            {"appSettings", "add", "ChunkSize", "2", "Chunk-Size", "512000", "", "", ""},
            {"appSettings", "add", "ViewerMode", "2", "Viewer-Mode", "PDF", "", "", ""},
            {"appSettings", "add", "OverlayMode", "2", "Default-Overlay-Mode", "Print", "", "", ""},
            {"appSettings", "add", "CachePath", "2", "Cache-Path", "C:\\DocCache", "", "", ""},
            {"appSettings", "add", "ExpireTime", "2", "Expiration-Time", "1", "", "", ""},
            {"appSettings", "add", "MaxCacheSize", "2", "Max-Cache-Size", "10", "", "", ""},
            {"appSettings", "add", "SizeToCache", "2", "Size-to-Cache", "1", "", "", ""},
            {"appSettings", "add", "SizeToPrompt", "2", "Size-to-Prompt", "20", "", "", ""},
            {"appSettings", "add", "ThrottleResetTimer", "2", "Interval-Between-Throttle-Cache-Resets", "5", "", "", ""},
            {"appSettings", "add", "ThrottleThreshold", "2", "Amount-of-Requests-During-Each-Throttle-Interval", "1000", "", "", ""},
            {"appSettings", "add", "EnableBrowserCaching", "1", "Enable-Local-Browser-Caching", "true", "", "", ""},
            {"appSettings", "add", "DecorateDocumentNames", "1", "Decorate-Document-Names", "true", "", "", ""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test6()
    {
        //Testing the Prebuilding of the 211 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://localhost/AppServer/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""SOAP-Client-Request-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://localhost/AppServer/Service.rem","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
            {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","SOAP-Client-Request-Timeout","100","","",""},
            {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
            {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
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

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","100","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test8()
    {
        //Testing the parsing of the 211 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OverlayMode"",""type"":""2"",""htmlIdName"":""Default-Overlay-Mode"",""Value"":""Print"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleResetTimer"",""type"":""2"",""htmlIdName"":""Interval-Between-Throttle-Cache-Resets"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleThreshold"",""type"":""2"",""htmlIdName"":""Amount-of-Requests-During-Each-Throttle-Interval"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserCaching"",""type"":""1"",""htmlIdName"":""Enable-Local-Browser-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DecorateDocumentNames"",""type"":""1"",""htmlIdName"":""Decorate-Document-Names"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OverlayMode"",""type"":""2"",""htmlIdName"":""Default-Overlay-Mode"",""Value"":""Print"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleResetTimer"",""type"":""2"",""htmlIdName"":""Interval-Between-Throttle-Cache-Resets"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleThreshold"",""type"":""2"",""htmlIdName"":""Amount-of-Requests-During-Each-Throttle-Interval"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserCaching"",""type"":""1"",""htmlIdName"":""Enable-Local-Browser-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DecorateDocumentNames"",""type"":""1"",""htmlIdName"":""Decorate-Document-Names"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<appSettings>
    <!-- Whether or not to encrypt the document ID when displaying search results. -->
    <add key=""EncryptDocId"" value=""false"" />
    <!-- Whether or not to use the configured Custom Query display columns when displaying search results. -->
    <add key=""UseDisplayColumns"" value=""true"" />
    <!-- Search results will be limited to this number. ""0"" implies unlimited. -->
    <add key=""QueryLimit"" value=""0"" />
    <!-- The size in bytes to use when downloading the document. -->
    <add key=""ChunkSize"" value=""512000"" />
    <!--Viewer Mode
    Valid values are:
    -PDF: All documents will be converted to PDF and streamed to the viewer.
      If too large (see SizeToPrompt setting), will prompt to download PDF file instead.
    -Native: All documents will download in their native format and will not display in the viewer.
    -NativeOptional: Documents will stream to the viewer as PDF and a link in the viewer will
      provide the option to download the file in its native format.
    -->
    <add key=""ViewerMode"" value=""PDF"" />
    <!-- Overlay Mode - The type of overlay so see on documents that use one. Note that
    this option can only be used if the PDF viewer mode is used when viewing documents that
    use an overlay. This will not affect other documents.
    Valid values are:
    - Off - Insert data into a blank, white page.
    - Print - Print view as shown in any other OnBase client.
    - View - The original view. The document will show as it does in any other OnBase client.
    -->
    <add key=""OverlayMode"" value=""Print"" />
    <!--Caching Settings-->
    <!--Path to the Public Access cache-->
    <add key=""CachePath"" value=""C:\DocCache"" />
    <!--Number of days before a document in the cache becomes stale-->
    <add key=""ExpireTime"" value=""1"" />
    <!--Maximum cache size (GB)-->
    <add key=""MaxCacheSize"" value=""10"" />
    <!--Any files over this file size (MB) get cached-->
    <add key=""SizeToCache"" value=""1"" />
    <!--Prompt to open/save any files over this file size (MB) instead of opening directly in the viewer-->
    <add key=""SizeToPrompt"" value=""20"" />
    <!-- The approximate time, in minutes, after which to rest the throttle cache (i.e. everyone will be unthrottled, limits reset). A value of 0 or less will disable throttling. -->
    <add key=""ThrottleResetTimer"" value=""5"" />
    <!-- The number of requests each user can make before being throttled. A value of 0 or less will disable throttling. -->
    <add key=""ThrottleThreshold"" value=""1000"" />
    <!-- Whether or not to allow the browser to cache documents for a short amount of time to reduce repeated requests.  -->
    <add key=""EnableBrowserCaching"" value=""false"" />
    <!-- Whether or not to show decoration/formatting for document names (i.e. <yellow>). Only works on autonames - decoration will always be applied to display columns, regardless of this setting. -->
    <add key=""DecorateDocumentNames"" value=""true"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test9()
    {
        //Testing the parsing of the 211 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://localhost/AppServer/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""SOAP-Client-Request-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""SOAP-Client-Request-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.rem"" ServiceClientType=""Remoting"" />
    <!-- If using SOAP and your requests take too long, you can increase the timeout value with RequestTimeoutSeconds.
    The executionTimeout value in the httpRuntime node in the Application Server web.config file must be equal to or
    greater than this value. -->
    <RequestTimeoutSeconds Value=""100"" />
    <!-- AllowNTAuthenticationOnForwarding if enabled, allows the web server to forward NT credentials 
            to the  Application Server. Only turn this flag on when using NT authentication. -->
    <AllowNTAuthenticationOnForwarding Enabled=""false"" />
    <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
    <!--<StreamingSettings BufferSize=""64000"" />-->
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test10()
    {
        //Testing the parsing of the 211 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<system.web>
    <!-- 
            Set compilation debug=""true"" to insert debugging 
            symbols into the compiled page. Because this 
            affects performance, set this value to true only 
            during development.
        -->
    <compilation debug=""false"" targetFramework=""4.7.2"" />
    <!--
            The <authentication> section enables configuration 
            of the security authentication mode used by 
            ASP.NET to identify an incoming user. 
        -->
    <authentication mode=""Windows"" />
    <!--
            The <customErrors> section enables configuration 
            of what to do if/when an unhandled error occurs 
            during the execution of a request. Specifically, 
            it enables developers to configure html error pages 
            to be displayed in place of a error stack trace.

        <customErrors mode=""RemoteOnly"" defaultRedirect=""GenericErrorPage.htm"">
            <error statusCode=""403"" redirect=""NoAccess.htm"" />
            <error statusCode=""404"" redirect=""FileNotFound.htm"" />
        </customErrors>
        -->
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""3.5"" clientIDMode=""AutoID"">
      <controls>
        <add tagPrefix=""PublicAccess"" assembly=""Hyland.PublicAccess.Controls"" namespace=""Hyland.PublicAccess.Controls"" />
        <add tagPrefix=""PublicAccess"" assembly=""Hyland.PublicAccess.Controls"" namespace=""Hyland.PublicAccess.Controls.Datasource"" />
      </controls>
    </pages>
    <httpHandlers>
      <add verb=""GET,HEAD,POST"" path=""*.asbx"" type=""System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"" validate=""false"" />
      <add verb=""*"" path=""PublicAccessProvider.ashx"" type=""Hyland.PublicAccess.Controls.PublicAccessProvider,Hyland.PublicAccess.Controls"" />
      <add verb=""*"" path=""PDFProvider.ashx"" type=""Hyland.PublicAccess.Controls.PDFProvider,Hyland.PublicAccess.Controls"" />
    </httpHandlers>
    <!-- By default, requests are allowed to execute for a maximum of 100 seconds. -->
    <httpRuntime executionTimeout=""100"" requestValidationMode=""2.0"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test11()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""user"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""PAVNG-Username"",""Value"":""[USERNAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""password"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""PAVNG-Password"",""Value"":""[PASSWORD"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""datasource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Public-Access-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""user"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""PAVNG-Username"",""Value"":""[USERNAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""password"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""PAVNG-Password"",""Value"":""[PASSWORD"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""datasource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Public-Access-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test12()
    {
        //Testing the parsing of the 211 RequiredKeywords section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[{""QueryID"":""1"",""KeywordID"":""0""},{""QueryID"":""6"",""KeywordID"":""9""},{""QueryID"":""8"",""KeywordID"":""5""}],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<RequiredKeywords>
    <Query ID=""1"">
      <Keyword ID=""0"" />
    </Query>
    <Query ID=""6"">
      <Keyword ID=""9"" />
    </Query>
    <Query ID=""8"">
      <Keyword ID=""5"" />
    </Query>
  </RequiredKeywords>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "RequiredKeywords", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test13()
    {
        //Testing the Prebuilding of the 221 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OverlayMode"",""type"":""2"",""htmlIdName"":""Default-Overlay-Mode"",""Value"":""Print"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleResetTimer"",""type"":""2"",""htmlIdName"":""Interval-Between-Throttle-Cache-Resets"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleThreshold"",""type"":""2"",""htmlIdName"":""Amount-of-Requests-During-Each-Throttle-Interval"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserCaching"",""type"":""1"",""htmlIdName"":""Enable-Local-Browser-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DecorateDocumentNames"",""type"":""1"",""htmlIdName"":""Decorate-Document-Names"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","EncryptDocId","1","Encrypt-Doc-ID","true","","",""},
            {"appSettings", "add", "UseDisplayColumns", "1", "Use-Display-Columns", "true", "", "", ""},
            {"appSettings","add","QueryLimit","2","Query-Limit","0","","",""},
            {"appSettings","add","ChunkSize","2","Chunk-Size","512000","","",""},
            {"appSettings","add","ViewerMode","2","Viewer-Mode","PDF","","",""},
            {"appSettings","add","OverlayMode","2","Default-Overlay-Mode","Print","","",""},
            {"appSettings","add","CachePath","2","Cache-Path","C:\\DocCache","","",""},
            {"appSettings","add","ExpireTime","2","Expiration-Time","1","","",""},
            {"appSettings","add","MaxCacheSize","2","Max-Cache-Size","10","","",""},
            {"appSettings","add","SizeToCache","2","Size-to-Cache","1","","",""},
            {"appSettings","add","SizeToPrompt","2","Size-to-Prompt","20","","",""},
            {"appSettings","add","ThrottleResetTimer","2","Interval-Between-Throttle-Cache-Resets","5","","",""},
            {"appSettings","add","ThrottleThreshold","2","Amount-of-Requests-During-Each-Throttle-Interval","1000","","",""},
            {"appSettings","add","EnableBrowserCaching","1","Enable-Local-Browser-Caching","true","","",""},
            {"appSettings","add","DecorateDocumentNames","1","Decorate-Document-Names","true","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test14()
    {
        //Testing the Prebuilding of the 221 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://localhost/AppServer/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""SOAP-Client-Request-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://localhost/AppServer/Service.rem","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
            {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","SOAP-Client-Request-Timeout","100","","",""},
            {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
            {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test15()
    {
        //Testing the Prebuilding of the 221 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","100","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test16()
    {
        //Testing the parsing of the 221 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OverlayMode"",""type"":""2"",""htmlIdName"":""Default-Overlay-Mode"",""Value"":""Print"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleResetTimer"",""type"":""2"",""htmlIdName"":""Interval-Between-Throttle-Cache-Resets"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleThreshold"",""type"":""2"",""htmlIdName"":""Amount-of-Requests-During-Each-Throttle-Interval"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserCaching"",""type"":""1"",""htmlIdName"":""Enable-Local-Browser-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DecorateDocumentNames"",""type"":""1"",""htmlIdName"":""Decorate-Document-Names"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OverlayMode"",""type"":""2"",""htmlIdName"":""Default-Overlay-Mode"",""Value"":""Print"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleResetTimer"",""type"":""2"",""htmlIdName"":""Interval-Between-Throttle-Cache-Resets"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleThreshold"",""type"":""2"",""htmlIdName"":""Amount-of-Requests-During-Each-Throttle-Interval"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserCaching"",""type"":""1"",""htmlIdName"":""Enable-Local-Browser-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DecorateDocumentNames"",""type"":""1"",""htmlIdName"":""Decorate-Document-Names"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<appSettings>
    <!-- Whether or not to encrypt the document ID when displaying search results. -->
    <add key=""EncryptDocId"" value=""false"" />
    <!-- Whether or not to use the configured Custom Query display columns when displaying search results. -->
    <add key=""UseDisplayColumns"" value=""true"" />
    <!-- Search results will be limited to this number. ""0"" implies unlimited. -->
    <add key=""QueryLimit"" value=""0"" />
    <!-- The size in bytes to use when downloading the document. -->
    <add key=""ChunkSize"" value=""512000"" />
    <!--Viewer Mode
    Valid values are:
    -PDF: All documents will be converted to PDF and streamed to the viewer.
      If too large (see SizeToPrompt setting), will prompt to download PDF file instead.
    -Native: All documents will download in their native format and will not display in the viewer.
    -NativeOptional: Documents will stream to the viewer as PDF and a link in the viewer will
      provide the option to download the file in its native format.
    -->
    <add key=""ViewerMode"" value=""PDF"" />
    <!-- Overlay Mode - The type of overlay so see on documents that use one. Note that
    this option can only be used if the PDF viewer mode is used when viewing documents that
    use an overlay. This will not affect other documents.
    Valid values are:
    - Off - Insert data into a blank, white page.
    - Print - Print view as shown in any other OnBase client.
    - View - The original view. The document will show as it does in any other OnBase client.
    -->
    <add key=""OverlayMode"" value=""Print"" />
    <!--Caching Settings-->
    <!--Path to the Public Access cache-->
    <add key=""CachePath"" value=""C:\DocCache"" />
    <!--Number of days before a document in the cache becomes stale-->
    <add key=""ExpireTime"" value=""1"" />
    <!--Maximum cache size (GB)-->
    <add key=""MaxCacheSize"" value=""10"" />
    <!--Any files over this file size (MB) get cached-->
    <add key=""SizeToCache"" value=""1"" />
    <!--Prompt to open/save any files over this file size (MB) instead of opening directly in the viewer-->
    <add key=""SizeToPrompt"" value=""20"" />
    <!-- The approximate time, in minutes, after which to rest the throttle cache (i.e. everyone will be unthrottled, limits reset). A value of 0 or less will disable throttling. -->
    <add key=""ThrottleResetTimer"" value=""5"" />
    <!-- The number of requests each user can make before being throttled. A value of 0 or less will disable throttling. -->
    <add key=""ThrottleThreshold"" value=""1000"" />
    <!-- Whether or not to allow the browser to cache documents for a short amount of time to reduce repeated requests.  -->
    <add key=""EnableBrowserCaching"" value=""false"" />
    <!-- Whether or not to show decoration/formatting for document names (i.e. <yellow>). Only works on autonames - decoration will always be applied to display columns, regardless of this setting. -->
    <add key=""DecorateDocumentNames"" value=""true"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test17()
    {
        //Testing the parsing of the 221 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://localhost/AppServer/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""SOAP-Client-Request-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""SOAP-Client-Request-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.rem"" ServiceClientType=""Remoting"" />
    <!-- If using SOAP and your requests take too long, you can increase the timeout value with RequestTimeoutSeconds.
    The executionTimeout value in the httpRuntime node in the Application Server web.config file must be equal to or
    greater than this value. -->
    <RequestTimeoutSeconds Value=""100"" />
    <!-- AllowNTAuthenticationOnForwarding if enabled, allows the web server to forward NT credentials 
            to the  Application Server. Only turn this flag on when using NT authentication. -->
    <AllowNTAuthenticationOnForwarding Enabled=""false"" />
    <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
    <!--<StreamingSettings BufferSize=""64000"" />-->
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test18()
    {
        //Testing the parsing of the 221 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<system.web>
    <!-- 
            Set compilation debug=""true"" to insert debugging 
            symbols into the compiled page. Because this 
            affects performance, set this value to true only 
            during development.
        -->
    <compilation debug=""false"" targetFramework=""4.7.2"" />
    <!--
            The <authentication> section enables configuration 
            of the security authentication mode used by 
            ASP.NET to identify an incoming user. 
        -->
    <authentication mode=""Windows"" />
    <!--
            The <customErrors> section enables configuration 
            of what to do if/when an unhandled error occurs 
            during the execution of a request. Specifically, 
            it enables developers to configure html error pages 
            to be displayed in place of a error stack trace.

        <customErrors mode=""RemoteOnly"" defaultRedirect=""GenericErrorPage.htm"">
            <error statusCode=""403"" redirect=""NoAccess.htm"" />
            <error statusCode=""404"" redirect=""FileNotFound.htm"" />
        </customErrors>
        -->
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""3.5"" clientIDMode=""AutoID"">
      <controls>
        <add tagPrefix=""PublicAccess"" assembly=""Hyland.PublicAccess.Controls"" namespace=""Hyland.PublicAccess.Controls"" />
        <add tagPrefix=""PublicAccess"" assembly=""Hyland.PublicAccess.Controls"" namespace=""Hyland.PublicAccess.Controls.Datasource"" />
      </controls>
    </pages>
    <httpHandlers>
      <add verb=""GET,HEAD,POST"" path=""*.asbx"" type=""System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"" validate=""false"" />
      <add verb=""*"" path=""PublicAccessProvider.ashx"" type=""Hyland.PublicAccess.Controls.PublicAccessProvider,Hyland.PublicAccess.Controls"" />
      <add verb=""*"" path=""PDFProvider.ashx"" type=""Hyland.PublicAccess.Controls.PDFProvider,Hyland.PublicAccess.Controls"" />
    </httpHandlers>
    <!-- By default, requests are allowed to execute for a maximum of 100 seconds. -->
    <httpRuntime executionTimeout=""100"" requestValidationMode=""2.0"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test19()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""user"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""PAVNG-Username"",""Value"":""[USERNAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""password"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""PAVNG-Password"",""Value"":""[PASSWORD"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""datasource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Public-Access-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""user"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""PAVNG-Username"",""Value"":""[USERNAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""password"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""PAVNG-Password"",""Value"":""[PASSWORD"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""datasource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Public-Access-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test20()
    {
        //Testing the parsing of the 221 RequiredKeywords section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[{""QueryID"":""1"",""KeywordID"":""0""},{""QueryID"":""6"",""KeywordID"":""9""},{""QueryID"":""8"",""KeywordID"":""5""}],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<RequiredKeywords>
    <Query ID=""1"">
      <Keyword ID=""0"" />
    </Query>
    <Query ID=""6"">
      <Keyword ID=""9"" />
    </Query>
    <Query ID=""8"">
      <Keyword ID=""5"" />
    </Query>
  </RequiredKeywords>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "RequiredKeywords", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test21()
    {
        //Testing the Prebuilding of the 231 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OverlayMode"",""type"":""2"",""htmlIdName"":""Default-Overlay-Mode"",""Value"":""Print"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleResetTimer"",""type"":""2"",""htmlIdName"":""Interval-Between-Throttle-Cache-Resets"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleThreshold"",""type"":""2"",""htmlIdName"":""Amount-of-Requests-During-Each-Throttle-Interval"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserCaching"",""type"":""1"",""htmlIdName"":""Enable-Local-Browser-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DecorateDocumentNames"",""type"":""1"",""htmlIdName"":""Decorate-Document-Names"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AlwaysWildcardAlphanumericKeywords"",""type"":""1"",""htmlIdName"":""Always-Wildcard-Alphanumeric-Keywords"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","EncryptDocId","1","Encrypt-Doc-ID","true","","",""},
            {"appSettings","add","UseDisplayColumns","1","Use-Display-Columns","true","","",""},
            {"appSettings","add","QueryLimit","2","Query-Limit","0","","",""},
            {"appSettings","add","ChunkSize","2","Chunk-Size","512000","","",""},
            {"appSettings","add","ViewerMode","2","Viewer-Mode","PDF","","",""},
            {"appSettings","add","OverlayMode","2","Default-Overlay-Mode","Print","","",""},
            {"appSettings","add","CachePath","2","Cache-Path","C:\\DocCache","","",""},
            {"appSettings","add","ExpireTime","2","Expiration-Time","1","","",""},
            {"appSettings","add","MaxCacheSize","2","Max-Cache-Size","10","","",""},
            {"appSettings","add","SizeToCache","2","Size-to-Cache","1","","",""},
            {"appSettings","add","SizeToPrompt","2","Size-to-Prompt","20","","",""},
            {"appSettings","add","ThrottleResetTimer","2","Interval-Between-Throttle-Cache-Resets","5","","",""},
            {"appSettings","add","ThrottleThreshold","2","Amount-of-Requests-During-Each-Throttle-Interval","1000","","",""},
            {"appSettings","add","EnableBrowserCaching","1","Enable-Local-Browser-Caching","true","","",""},
            {"appSettings","add","DecorateDocumentNames","1","Decorate-Document-Names","true","","",""},
            {"appSettings","add","AlwaysWildcardAlphanumericKeywords","1","Always-Wildcard-Alphanumeric-Keywords","false","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test22()
    {
        //Testing the Prebuilding of the 231 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://localhost/AppServer/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""SOAP-Client-Request-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://localhost/AppServer/Service.rem","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
            {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","SOAP-Client-Request-Timeout","100","","",""},
            {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
            {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test23()
    {
        //Testing the Prebuilding of the 231 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","100","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test24()
    {
        //Testing the parsing of the 231 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OverlayMode"",""type"":""2"",""htmlIdName"":""Default-Overlay-Mode"",""Value"":""Print"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleResetTimer"",""type"":""2"",""htmlIdName"":""Interval-Between-Throttle-Cache-Resets"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleThreshold"",""type"":""2"",""htmlIdName"":""Amount-of-Requests-During-Each-Throttle-Interval"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserCaching"",""type"":""1"",""htmlIdName"":""Enable-Local-Browser-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DecorateDocumentNames"",""type"":""1"",""htmlIdName"":""Decorate-Document-Names"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AlwaysWildcardAlphanumericKeywords"",""type"":""1"",""htmlIdName"":""Always-Wildcard-Alphanumeric-Keywords"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OverlayMode"",""type"":""2"",""htmlIdName"":""Default-Overlay-Mode"",""Value"":""Print"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleResetTimer"",""type"":""2"",""htmlIdName"":""Interval-Between-Throttle-Cache-Resets"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleThreshold"",""type"":""2"",""htmlIdName"":""Amount-of-Requests-During-Each-Throttle-Interval"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserCaching"",""type"":""1"",""htmlIdName"":""Enable-Local-Browser-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DecorateDocumentNames"",""type"":""1"",""htmlIdName"":""Decorate-Document-Names"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AlwaysWildcardAlphanumericKeywords"",""type"":""1"",""htmlIdName"":""Always-Wildcard-Alphanumeric-Keywords"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<appSettings>
    <!-- Whether or not to encrypt the document ID when displaying search results. -->
    <add key=""EncryptDocId"" value=""true"" />
    <!-- Whether or not to use the configured Custom Query display columns when displaying search results. -->
    <add key=""UseDisplayColumns"" value=""true"" />
    <!-- Whether or not Alphanumeric Keyword searches will automatically act as if a wildcard (*) was appended at the end -->
    <add key=""AlwaysWildcardAlphanumericKeywords"" value=""false""/>
    <!-- Search results will be limited to this number. ""0"" implies unlimited. -->
    <add key=""QueryLimit"" value=""0"" />
    <!-- The size in bytes to use when downloading the document. -->
    <add key=""ChunkSize"" value=""512000"" />
    <!--Viewer Mode
    Valid values are:
    -PDF: All documents will be converted to PDF and streamed to the viewer.
      If too large (see SizeToPrompt setting), will prompt to download PDF file instead.
    -Native: All documents will download in their native format and will not display in the viewer.
    -NativeOptional: Documents will stream to the viewer as PDF and a link in the viewer will
      provide the option to download the file in its native format.
    -->
    <add key=""ViewerMode"" value=""PDF"" />
    <!-- Overlay Mode - The type of overlay so see on documents that use one. Note that
    this option can only be used if the PDF viewer mode is used when viewing documents that
    use an overlay. This will not affect other documents.
    Valid values are:
    - Off - Insert data into a blank, white page.
    - Print - Print view as shown in any other OnBase client.
    - View - The original view. The document will show as it does in any other OnBase client.
    -->
    <add key=""OverlayMode"" value=""Print"" />
    <!--Caching Settings-->
    <!--Path to the Public Access cache-->
    <add key=""CachePath"" value=""C:\DocCache"" />
    <!--Number of days before a document in the cache becomes stale-->
    <add key=""ExpireTime"" value=""1"" />
    <!--Maximum cache size (GB)-->
    <add key=""MaxCacheSize"" value=""10"" />
    <!--Any files over this file size (MB) get cached-->
    <add key=""SizeToCache"" value=""1"" />
    <!--Prompt to open/save any files over this file size (MB) instead of opening directly in the viewer-->
    <add key=""SizeToPrompt"" value=""20"" />
    <!-- The approximate time, in minutes, after which to rest the throttle cache (i.e. everyone will be unthrottled, limits reset). A value of 0 or less will disable throttling. -->
    <add key=""ThrottleResetTimer"" value=""5"" />
    <!-- The number of requests each user can make before being throttled. A value of 0 or less will disable throttling. -->
    <add key=""ThrottleThreshold"" value=""1000"" />
    <!-- Whether or not to allow the browser to cache documents for a short amount of time to reduce repeated requests.  -->
    <add key=""EnableBrowserCaching"" value=""false"" />
    <!-- Whether or not to show decoration/formatting for document names (i.e. <yellow>). Only works on autonames - decoration will always be applied to display columns, regardless of this setting. -->
    <add key=""DecorateDocumentNames"" value=""true"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test25()
    {
        //Testing the parsing of the 231 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://localhost/AppServer/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""SOAP-Client-Request-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""SOAP-Client-Request-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.rem"" ServiceClientType=""Remoting"" />
    <!-- If using SOAP and your requests take too long, you can increase the timeout value with RequestTimeoutSeconds.
    The executionTimeout value in the httpRuntime node in the Application Server web.config file must be equal to or
    greater than this value. -->
    <RequestTimeoutSeconds Value=""100"" />
    <!-- AllowNTAuthenticationOnForwarding if enabled, allows the web server to forward NT credentials 
            to the  Application Server. Only turn this flag on when using NT authentication. -->
    <AllowNTAuthenticationOnForwarding Enabled=""false"" />
    <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
    <!--<StreamingSettings BufferSize=""64000"" />-->
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test26()
    {
        //Testing the parsing of the 231 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<system.web>
    <!-- 
            Set compilation debug=""true"" to insert debugging 
            symbols into the compiled page. Because this 
            affects performance, set this value to true only 
            during development.
        -->
    <compilation debug=""false"" targetFramework=""4.7.2"" />
    <!--
            The <authentication> section enables configuration 
            of the security authentication mode used by 
            ASP.NET to identify an incoming user. 
        -->
    <authentication mode=""Windows"" />
    <!--
            The <customErrors> section enables configuration 
            of what to do if/when an unhandled error occurs 
            during the execution of a request. Specifically, 
            it enables developers to configure html error pages 
            to be displayed in place of a error stack trace.

        <customErrors mode=""RemoteOnly"" defaultRedirect=""GenericErrorPage.htm"">
            <error statusCode=""403"" redirect=""NoAccess.htm"" />
            <error statusCode=""404"" redirect=""FileNotFound.htm"" />
        </customErrors>
        -->
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""3.5"" clientIDMode=""AutoID"">
      <controls>
        <add tagPrefix=""PublicAccess"" assembly=""Hyland.PublicAccess.Controls"" namespace=""Hyland.PublicAccess.Controls"" />
        <add tagPrefix=""PublicAccess"" assembly=""Hyland.PublicAccess.Controls"" namespace=""Hyland.PublicAccess.Controls.Datasource"" />
      </controls>
    </pages>
    <httpHandlers>
      <add verb=""GET,HEAD,POST"" path=""*.asbx"" type=""System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"" validate=""false"" />
      <add verb=""*"" path=""PublicAccessProvider.ashx"" type=""Hyland.PublicAccess.Controls.PublicAccessProvider,Hyland.PublicAccess.Controls"" />
      <add verb=""*"" path=""PDFProvider.ashx"" type=""Hyland.PublicAccess.Controls.PDFProvider,Hyland.PublicAccess.Controls"" />
    </httpHandlers>
    <!-- By default, requests are allowed to execute for a maximum of 100 seconds. -->
    <httpRuntime executionTimeout=""100"" requestValidationMode=""2.0"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test27()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""user"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""PAVNG-Username"",""Value"":""[USERNAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""password"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""PAVNG-Password"",""Value"":""[PASSWORD"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""datasource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Public-Access-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""user"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""PAVNG-Username"",""Value"":""[USERNAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""password"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""PAVNG-Password"",""Value"":""[PASSWORD"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""datasource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Public-Access-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test28()
    {
        //Testing the parsing of the 241 RequiredKeywords section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[{""QueryID"":""1"",""KeywordID"":""0""},{""QueryID"":""6"",""KeywordID"":""9""},{""QueryID"":""8"",""KeywordID"":""5""}],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<RequiredKeywords>
    <Query ID=""1"">
      <Keyword ID=""0"" />
    </Query>
    <Query ID=""6"">
      <Keyword ID=""9"" />
    </Query>
    <Query ID=""8"">
      <Keyword ID=""5"" />
    </Query>
  </RequiredKeywords>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "RequiredKeywords", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test29()
    {
        //Testing the Prebuilding of the 241 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OverlayMode"",""type"":""2"",""htmlIdName"":""Default-Overlay-Mode"",""Value"":""Print"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleResetTimer"",""type"":""2"",""htmlIdName"":""Interval-Between-Throttle-Cache-Resets"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleThreshold"",""type"":""2"",""htmlIdName"":""Amount-of-Requests-During-Each-Throttle-Interval"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserCaching"",""type"":""1"",""htmlIdName"":""Enable-Local-Browser-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DecorateDocumentNames"",""type"":""1"",""htmlIdName"":""Decorate-Document-Names"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AlwaysWildcardAlphanumericKeywords"",""type"":""1"",""htmlIdName"":""Always-Wildcard-Alphanumeric-Keywords"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","EncryptDocId","1","Encrypt-Doc-ID","true","","",""},
            {"appSettings","add","UseDisplayColumns","1","Use-Display-Columns","true","","",""},
            {"appSettings","add","QueryLimit","2","Query-Limit","0","","",""},
            {"appSettings","add","ChunkSize","2","Chunk-Size","512000","","",""},
            {"appSettings","add","ViewerMode","2","Viewer-Mode","PDF","","",""},
            {"appSettings","add","OverlayMode","2","Default-Overlay-Mode","Print","","",""},
            {"appSettings","add","CachePath","2","Cache-Path","C:\\DocCache","","",""},
            {"appSettings","add","ExpireTime","2","Expiration-Time","1","","",""},
            {"appSettings","add","MaxCacheSize","2","Max-Cache-Size","10","","",""},
            {"appSettings","add","SizeToCache","2","Size-to-Cache","1","","",""},
            {"appSettings","add","SizeToPrompt","2","Size-to-Prompt","20","","",""},
            {"appSettings","add","ThrottleResetTimer","2","Interval-Between-Throttle-Cache-Resets","5","","",""},
            {"appSettings","add","ThrottleThreshold","2","Amount-of-Requests-During-Each-Throttle-Interval","1000","","",""},
            {"appSettings","add","EnableBrowserCaching","1","Enable-Local-Browser-Caching","true","","",""},
            {"appSettings","add","DecorateDocumentNames","1","Decorate-Document-Names","true","","",""},
            {"appSettings","add","AlwaysWildcardAlphanumericKeywords","1","Always-Wildcard-Alphanumeric-Keywords","false","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test30()
    {
        //Testing the Prebuilding of the 241 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://localhost/AppServer/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""SOAP-Client-Request-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://localhost/AppServer/Service.rem","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
            {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","SOAP-Client-Request-Timeout","100","","",""},
            {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
            {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test31()
    {
        //Testing the Prebuilding of the 241 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","100","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test32()
    {
        //Testing the parsing of the 241 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OverlayMode"",""type"":""2"",""htmlIdName"":""Default-Overlay-Mode"",""Value"":""Print"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleResetTimer"",""type"":""2"",""htmlIdName"":""Interval-Between-Throttle-Cache-Resets"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleThreshold"",""type"":""2"",""htmlIdName"":""Amount-of-Requests-During-Each-Throttle-Interval"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserCaching"",""type"":""1"",""htmlIdName"":""Enable-Local-Browser-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DecorateDocumentNames"",""type"":""1"",""htmlIdName"":""Decorate-Document-Names"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AlwaysWildcardAlphanumericKeywords"",""type"":""1"",""htmlIdName"":""Always-Wildcard-Alphanumeric-Keywords"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OverlayMode"",""type"":""2"",""htmlIdName"":""Default-Overlay-Mode"",""Value"":""Print"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleResetTimer"",""type"":""2"",""htmlIdName"":""Interval-Between-Throttle-Cache-Resets"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThrottleThreshold"",""type"":""2"",""htmlIdName"":""Amount-of-Requests-During-Each-Throttle-Interval"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserCaching"",""type"":""1"",""htmlIdName"":""Enable-Local-Browser-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""DecorateDocumentNames"",""type"":""1"",""htmlIdName"":""Decorate-Document-Names"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AlwaysWildcardAlphanumericKeywords"",""type"":""1"",""htmlIdName"":""Always-Wildcard-Alphanumeric-Keywords"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<appSettings>
    <!-- Whether or not to encrypt the document ID when displaying search results. -->
    <add key=""EncryptDocId"" value=""true"" />
    <!-- Whether or not to use the configured Custom Query display columns when displaying search results. -->
    <add key=""UseDisplayColumns"" value=""true"" />
    <!-- Whether or not Alphanumeric Keyword searches will automatically act as if a wildcard (*) was appended at the end -->
    <add key=""AlwaysWildcardAlphanumericKeywords"" value=""false""/>
    <!-- Search results will be limited to this number. ""0"" implies unlimited. -->
    <add key=""QueryLimit"" value=""0"" />
    <!-- The size in bytes to use when downloading the document. -->
    <add key=""ChunkSize"" value=""512000"" />
    <!--Viewer Mode
    Valid values are:
    -PDF: All documents will be converted to PDF and streamed to the viewer.
      If too large (see SizeToPrompt setting), will prompt to download PDF file instead.
    -Native: All documents will download in their native format and will not display in the viewer.
    -NativeOptional: Documents will stream to the viewer as PDF and a link in the viewer will
      provide the option to download the file in its native format.
    -->
    <add key=""ViewerMode"" value=""PDF"" />
    <!-- Overlay Mode - The type of overlay so see on documents that use one. Note that
    this option can only be used if the PDF viewer mode is used when viewing documents that
    use an overlay. This will not affect other documents.
    Valid values are:
    - Off - Insert data into a blank, white page.
    - Print - Print view as shown in any other OnBase client.
    - View - The original view. The document will show as it does in any other OnBase client.
    -->
    <add key=""OverlayMode"" value=""Print"" />
    <!--Caching Settings-->
    <!--Path to the Public Access cache-->
    <add key=""CachePath"" value=""C:\DocCache"" />
    <!--Number of days before a document in the cache becomes stale-->
    <add key=""ExpireTime"" value=""1"" />
    <!--Maximum cache size (GB)-->
    <add key=""MaxCacheSize"" value=""10"" />
    <!--Any files over this file size (MB) get cached-->
    <add key=""SizeToCache"" value=""1"" />
    <!--Prompt to open/save any files over this file size (MB) instead of opening directly in the viewer-->
    <add key=""SizeToPrompt"" value=""20"" />
    <!-- The approximate time, in minutes, after which to rest the throttle cache (i.e. everyone will be unthrottled, limits reset). A value of 0 or less will disable throttling. -->
    <add key=""ThrottleResetTimer"" value=""5"" />
    <!-- The number of requests each user can make before being throttled. A value of 0 or less will disable throttling. -->
    <add key=""ThrottleThreshold"" value=""1000"" />
    <!-- Whether or not to allow the browser to cache documents for a short amount of time to reduce repeated requests.  -->
    <add key=""EnableBrowserCaching"" value=""false"" />
    <!-- Whether or not to show decoration/formatting for document names (i.e. <yellow>). Only works on autonames - decoration will always be applied to display columns, regardless of this setting. -->
    <add key=""DecorateDocumentNames"" value=""true"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test33()
    {
        //Testing the parsing of the 241 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://localhost/AppServer/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""SOAP-Client-Request-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""SOAP-Client-Request-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.rem"" ServiceClientType=""Remoting"" />
    <!-- If using SOAP and your requests take too long, you can increase the timeout value with RequestTimeoutSeconds.
    The executionTimeout value in the httpRuntime node in the Application Server web.config file must be equal to or
    greater than this value. -->
    <RequestTimeoutSeconds Value=""100"" />
    <!-- AllowNTAuthenticationOnForwarding if enabled, allows the web server to forward NT credentials 
            to the  Application Server. Only turn this flag on when using NT authentication. -->
    <AllowNTAuthenticationOnForwarding Enabled=""false"" />
    <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
    <!--<StreamingSettings BufferSize=""64000"" />-->
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test34()
    {
        //Testing the parsing of the 241 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""100"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<system.web>
    <!-- 
            Set compilation debug=""true"" to insert debugging 
            symbols into the compiled page. Because this 
            affects performance, set this value to true only 
            during development.
        -->
    <compilation debug=""false"" targetFramework=""4.7.2"" />
    <!--
            The <authentication> section enables configuration 
            of the security authentication mode used by 
            ASP.NET to identify an incoming user. 
        -->
    <authentication mode=""Windows"" />
    <!--
            The <customErrors> section enables configuration 
            of what to do if/when an unhandled error occurs 
            during the execution of a request. Specifically, 
            it enables developers to configure html error pages 
            to be displayed in place of a error stack trace.

        <customErrors mode=""RemoteOnly"" defaultRedirect=""GenericErrorPage.htm"">
            <error statusCode=""403"" redirect=""NoAccess.htm"" />
            <error statusCode=""404"" redirect=""FileNotFound.htm"" />
        </customErrors>
        -->
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""3.5"" clientIDMode=""AutoID"">
      <controls>
        <add tagPrefix=""PublicAccess"" assembly=""Hyland.PublicAccess.Controls"" namespace=""Hyland.PublicAccess.Controls"" />
        <add tagPrefix=""PublicAccess"" assembly=""Hyland.PublicAccess.Controls"" namespace=""Hyland.PublicAccess.Controls.Datasource"" />
      </controls>
    </pages>
    <httpHandlers>
      <add verb=""GET,HEAD,POST"" path=""*.asbx"" type=""System.Web.Script.Services.ScriptHandlerFactory, System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"" validate=""false"" />
      <add verb=""*"" path=""PublicAccessProvider.ashx"" type=""Hyland.PublicAccess.Controls.PublicAccessProvider,Hyland.PublicAccess.Controls"" />
      <add verb=""*"" path=""PDFProvider.ashx"" type=""Hyland.PublicAccess.Controls.PDFProvider,Hyland.PublicAccess.Controls"" />
    </httpHandlers>
    <!-- By default, requests are allowed to execute for a maximum of 100 seconds. -->
    <httpRuntime executionTimeout=""100"" requestValidationMode=""2.0"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test35()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""user"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""PAVNG-Username"",""Value"":""[USERNAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""password"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""PAVNG-Password"",""Value"":""[PASSWORD"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""datasource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Public-Access-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""user"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""PAVNG-Username"",""Value"":""[USERNAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""password"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""PAVNG-Password"",""Value"":""[PASSWORD"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""datasource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Public-Access-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test36()
    {
        //Testing the parsing of the 241 RequiredKeywords section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[{""QueryID"":""1"",""KeywordID"":""0""},{""QueryID"":""6"",""KeywordID"":""9""},{""QueryID"":""8"",""KeywordID"":""5""}],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<RequiredKeywords>
    <Query ID=""1"">
      <Keyword ID=""0"" />
    </Query>
    <Query ID=""6"">
      <Keyword ID=""9"" />
    </Query>
    <Query ID=""8"">
      <Keyword ID=""5"" />
    </Query>
  </RequiredKeywords>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "RequiredKeywords", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }
}
