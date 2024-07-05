using COMACON.config;
using COMACONTranslationToHelperUtility;
using FluentAssertions;
using Newtonsoft.Json;
using System.Xml;

namespace COMACON.tests;

public class ReportingViewerTests
{
    private readonly string cleanWebApplicationDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";
    private readonly string cleanWebApplicationDataStructure211WithVersionNumber = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";
    private readonly string cleanWebApplicationDataStructure221WithVersionNumber = @"{""Type"":"""",""Version"":""22.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";
    private readonly string cleanWebApplicationDataStructure231WithVersionNumber = @"{""Type"":"""",""Version"":""23.1.7.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";
    private readonly string cleanWebApplicationDataStructure241WithVersionNumber = @"{""Type"":"""",""Version"":""24.1.6.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

    [Fact]
    public void Test1()
    {
        //Testing to validate that the key is found and the appropriate value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings file=""version.xml"">
    <!-- This setting controls if the server will accept only https connections or not. 
            If you set this to false all incoming requests have to be made over https. 
            If you set this to true then both http and https connections are accepted. 
            The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value=""false"" />
    <add key=""dmsVirtualRoot"" value="""" />
    <add key=""dmsDataSource"" value="""" />
    <add key=""dmsOEMProductName"" value=""OnBase"" />
    <add key=""ServerDesignation"" value="""" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""ValidationSettings:UnobtrusiveValidationMode"" value=""None"" />
  </appSettings>";

        string keyName = "AllowInsecureConnection";
        string defaultValue = "false";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getNonStandardXmlValue(xmldoc.DocumentElement, keyName, defaultValue);

        value.Should().Be("false");
    }

    [Fact]
    public void Test2()
    {
        //Testing to validate that the key is not found and the default value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings file=""version.xml"">
    <!-- This setting controls if the server will accept only https connections or not. 
            If you set this to false all incoming requests have to be made over https. 
            If you set this to true then both http and https connections are accepted. 
            The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value="""" />
    <add key=""dmsVirtualRoot"" value="""" />
    <add key=""dmsDataSource"" value="""" />
    <add key=""dmsOEMProductName"" value=""OnBase"" />
    <add key=""ServerDesignation"" value="""" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""ValidationSettings:UnobtrusiveValidationMode"" value=""None"" />
  </appSettings>";

        string keyName = "allowInsecureConnection";
        string defaultValue = "false";

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
    <compilation debug=""true"" targetFramework=""4.7.2"">
      <assemblies>
        <add assembly=""DevExpress.Dashboard.v17.1.Web, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Dashboard.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Data.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.DataAccess.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Office.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Printing.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Charts.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.RichEdit.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Xpo.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Web.ASPxThemes.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
      </assemblies>
    </compilation>
    <!--  CUSTOM ERROR MESSAGES
              Set customErrors mode=""On"" or ""RemoteOnly"" to enable custom error messages, ""Off"" to disable. 
              Add <error> tags for each of the errors you want to handle.

              ""On"" Always display custom (friendly) messages.
              ""Off"" Always display detailed ASP.NET error information.
              ""RemoteOnly"" Display custom (friendly) messages only to users not running 
               on the local Web server. This setting is recommended for security purposes, so 
               that you do not display application detail information to remote clients.
        -->
    <customErrors mode=""RemoteOnly"" />
    <!--  AUTHENTICATION 
              This section sets the authentication policies of the application. Possible modes are ""Windows"", 
              ""Forms"", ""Passport"" and ""None""

              ""None"" No authentication is performed. 
              ""Windows"" IIS performs authentication (Basic, Digest, or Integrated Windows) according to 
               its settings for the application. Anonymous access must be disabled in IIS. 
              ""Forms"" You provide a custom form (Web page) for users to enter their credentials, and then 
               you authenticate them in your application. A user credential token is stored in a cookie.
              ""Passport"" Authentication is performed via a centralized authentication service provided
               by Microsoft that offers a single logon and core profile services for member sites.
        -->
    <authentication mode=""Windows"" />
    <!--  AUTHORIZATION 
              This section sets the authorization policies of the application. You can allow or deny access
              to application resources by user or role. Wildcards: ""*"" mean everyone, ""?"" means anonymous 
              (unauthenticated) users.
        -->
    <authorization>
      <allow users=""*"" />
      <!-- Allow all users -->
      <!--  <allow     users=""[comma separated list of users]""
                             roles=""[comma separated list of roles]""/>
                  <deny      users=""[comma separated list of users]""
                             roles=""[comma separated list of roles]""/>
            -->
    </authorization>
    <!--  APPLICATION-LEVEL TRACE LOGGING
              Application-level tracing enables trace log output for every page within an application. 
              Set trace enabled=""true"" to enable application trace logging.  If pageOutput=""true"", the
              trace information will be displayed at the bottom of each page.  Otherwise, you can view the 
              application trace log by browsing the ""trace.axd"" page from your web application
              root. 
        -->
    <trace enabled=""false"" requestLimit=""10"" pageOutput=""false"" traceMode=""SortByTime"" localOnly=""true"" />
    <!--  SESSION STATE SETTINGS
              By default ASP.NET uses cookies to identify which requests belong to a particular session. 
              If cookies are not available, a session can be tracked by adding a session identifier to the URL. 
              To disable cookies, set sessionState cookieless=""true"".
        -->
    <sessionState mode=""InProc"" stateConnectionString=""tcpip=127.0.0.1:42424"" sqlConnectionString=""data source=127.0.0.1;Trusted_Connection=yes"" cookieless=""false"" timeout=""20"" />
    <!--  HTTPRUNTIME
              By default the maximum size a request may be is 4096 KB.  If files larger than 4096 KB (4 MB)
              need to be uploaded increase the size of the maxRequestLength.  MaxRequestLength value is in KiloBytes.
              By default the maximum number of seconds that a request is allowed to execute is 90 seconds.
              If uploading large documents, the executionTimeout value may need to be increased for proper processing.
      
              If uploads larger than 30MB are required, maxRequestLength in the application server's web.config must also be increased.
              If uploads larger than 30MB are required and IIS7 or greater is being used, additional changes are required.
              Refer to the maxAllowedContentLength comments for information regarding the changes.
          -->
    <!--  GLOBALIZATION
              This section sets the globalization settings of the application. 
        -->
    <globalization requestEncoding=""utf-8"" responseEncoding=""utf-8"" />
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <httpRuntime targetFramework=""4.7.2"" requestValidationMode=""2.0"" maxRequestLength=""2048"" executionTimeout=""90"" enableVersionHeader=""false"" />
    <httpModules>
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" name=""ASPxHttpHandlerModule"" />
    </httpModules>
    <httpHandlers>
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" verb=""GET,POST"" path=""DX.ashx"" validate=""false"" />
      <add verb=""GET,POST"" path=""ASPxUploadProgressHandlerPage.ashx"" type=""DevExpress.Web.ASPxUploadProgressHttpHandler, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
    </httpHandlers>
  </system.web>";

        string nodeName = "httpRuntime";
        string attributeName = "maxRequestLength";
        string defaultValue = "4096";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getStandardXmlValue(xmldoc.DocumentElement, nodeName, attributeName, defaultValue);

        value.Should().Be("2048");
    }

    [Fact]
    public void Test4()
    {
        //Testing to validate that the key is not found and the default value is returned.
        //This is testing with just one level of nesting.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<system.web>
    <compilation debug=""true"" targetFramework=""4.7.2"">
      <assemblies>
        <add assembly=""DevExpress.Dashboard.v17.1.Web, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Dashboard.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Data.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.DataAccess.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Office.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Printing.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Charts.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.RichEdit.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Xpo.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Web.ASPxThemes.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
      </assemblies>
    </compilation>
    <!--  CUSTOM ERROR MESSAGES
              Set customErrors mode=""On"" or ""RemoteOnly"" to enable custom error messages, ""Off"" to disable. 
              Add <error> tags for each of the errors you want to handle.

              ""On"" Always display custom (friendly) messages.
              ""Off"" Always display detailed ASP.NET error information.
              ""RemoteOnly"" Display custom (friendly) messages only to users not running 
               on the local Web server. This setting is recommended for security purposes, so 
               that you do not display application detail information to remote clients.
        -->
    <customErrors mode=""RemoteOnly"" />
    <!--  AUTHENTICATION 
              This section sets the authentication policies of the application. Possible modes are ""Windows"", 
              ""Forms"", ""Passport"" and ""None""

              ""None"" No authentication is performed. 
              ""Windows"" IIS performs authentication (Basic, Digest, or Integrated Windows) according to 
               its settings for the application. Anonymous access must be disabled in IIS. 
              ""Forms"" You provide a custom form (Web page) for users to enter their credentials, and then 
               you authenticate them in your application. A user credential token is stored in a cookie.
              ""Passport"" Authentication is performed via a centralized authentication service provided
               by Microsoft that offers a single logon and core profile services for member sites.
        -->
    <authentication mode=""Windows"" />
    <!--  AUTHORIZATION 
              This section sets the authorization policies of the application. You can allow or deny access
              to application resources by user or role. Wildcards: ""*"" mean everyone, ""?"" means anonymous 
              (unauthenticated) users.
        -->
    <authorization>
      <allow users=""*"" />
      <!-- Allow all users -->
      <!--  <allow     users=""[comma separated list of users]""
                             roles=""[comma separated list of roles]""/>
                  <deny      users=""[comma separated list of users]""
                             roles=""[comma separated list of roles]""/>
            -->
    </authorization>
    <!--  APPLICATION-LEVEL TRACE LOGGING
              Application-level tracing enables trace log output for every page within an application. 
              Set trace enabled=""true"" to enable application trace logging.  If pageOutput=""true"", the
              trace information will be displayed at the bottom of each page.  Otherwise, you can view the 
              application trace log by browsing the ""trace.axd"" page from your web application
              root. 
        -->
    <trace enabled=""false"" requestLimit=""10"" pageOutput=""false"" traceMode=""SortByTime"" localOnly=""true"" />
    <!--  SESSION STATE SETTINGS
              By default ASP.NET uses cookies to identify which requests belong to a particular session. 
              If cookies are not available, a session can be tracked by adding a session identifier to the URL. 
              To disable cookies, set sessionState cookieless=""true"".
        -->
    <sessionState mode=""InProc"" stateConnectionString=""tcpip=127.0.0.1:42424"" sqlConnectionString=""data source=127.0.0.1;Trusted_Connection=yes"" cookieless=""false"" timeout=""20"" />
    <!--  HTTPRUNTIME
              By default the maximum size a request may be is 4096 KB.  If files larger than 4096 KB (4 MB)
              need to be uploaded increase the size of the maxRequestLength.  MaxRequestLength value is in KiloBytes.
              By default the maximum number of seconds that a request is allowed to execute is 90 seconds.
              If uploading large documents, the executionTimeout value may need to be increased for proper processing.
      
              If uploads larger than 30MB are required, maxRequestLength in the application server's web.config must also be increased.
              If uploads larger than 30MB are required and IIS7 or greater is being used, additional changes are required.
              Refer to the maxAllowedContentLength comments for information regarding the changes.
          -->
    <!--  GLOBALIZATION
              This section sets the globalization settings of the application. 
        -->
    <globalization requestEncoding=""utf-8"" responseEncoding=""utf-8"" />
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <httpRuntime targetFramework=""4.7.2"" requestValidationMode=""2.0"" maxRequestLength=""4096"" executionTimeout=""90"" enableVersionHeader=""false"" />
    <httpModules>
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" name=""ASPxHttpHandlerModule"" />
    </httpModules>
    <httpHandlers>
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" verb=""GET,POST"" path=""DX.ashx"" validate=""false"" />
      <add verb=""GET,POST"" path=""ASPxUploadProgressHandlerPage.ashx"" type=""DevExpress.Web.ASPxUploadProgressHttpHandler, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
    </httpHandlers>
  </system.web>";

        string nodeName = "httpRuntime";
        string attributeName = "MaxRequestLength";
        string defaultValue = "4096";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getStandardXmlValue(xmldoc.DocumentElement, nodeName, attributeName, defaultValue);

        value.Should().Be(defaultValue);
    }

    [Fact]
    public void Test5()
    {
        //Testing the Prebuilding of the 211 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""OptimizedServicePipeline"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Optimized-Service-Pipeline"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""Request-Timeout"",""Value"":""300"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
            {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
            {"Hyland.Services.Client","OptimizedServicePipeline","Enabled","1","Optimized-Service-Pipeline","true","","",""},
            {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","Request-Timeout","300","","",""},
            {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
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

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Web-Virtual-Directory"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Core-Data-Source"",""Value"":""[DATASOURCE NAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ServerDesignation"",""type"":""2"",""htmlIdName"":""Server-Designation"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
            {"appSettings","add","dmsVirtualRoot","2","Web-Virtual-Directory","http://[HOSTNAME]/[VIRTUAL ROOT]","","",""},
            {"appSettings","add","dmsDataSource","2","Core-Data-Source","[DATASOURCE NAME]","","",""},
            {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""}
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

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","",""},
            {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test8()
    {
        //Testing the Prebuilding of the 211 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test9()
    {
        //Testing the Prebuilding of the 211 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""50000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web.extensions","scripting/webServices/jsonSerialization","maxJsonLength","2","JSON-Serialization-Max-Length","50000000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test10()
    {
        //Testing the Prebuilding of the 211 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test11()
    {
        //Testing the parsing of the 211 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""OptimizedServicePipeline"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Optimized-Service-Pipeline"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""Request-Timeout"",""Value"":""300"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""OptimizedServicePipeline"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Optimized-Service-Pipeline"",""Value"":""True"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""Request-Timeout"",""Value"":""300"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.asmx"" ServiceClientType=""SOAP"" />
    <!-- AllowNTAuthenticationOnForwarding if enabled, allows the web server to forward NT credentials 
        to the  Application Server. Only turn this flag on when using NT authentication. -->
    <AllowNTAuthenticationOnForwarding Enabled=""false"" />
    <!-- Use the optimized service pipeline for more efficient communication of results -->
    <OptimizedServicePipeline Enabled=""True"" />
    <!-- Determines how long the service client should wait for a response from the application server -->
    <RequestTimeoutSeconds Value=""300"" />
    <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
    <!--System.Xml.XmlElement-->
    <StreamingSettings BufferSize=""64000"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test12()
    {
        //Testing the parsing of the 211 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Web-Virtual-Directory"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Core-Data-Source"",""Value"":""[DATASOURCE NAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ServerDesignation"",""type"":""2"",""htmlIdName"":""Server-Designation"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Web-Virtual-Directory"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Core-Data-Source"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ServerDesignation"",""type"":""2"",""htmlIdName"":""Server-Designation"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""webtheme\"" value=\""XP\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""ValidationSettings:UnobtrusiveValidationMode\"" value=\""None\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<appSettings file=""version.xml"">
    <!-- This setting controls if the server will accept only https connections or not. 
            If you set this to false all incoming requests have to be made over https. 
            If you set this to true then both http and https connections are accepted. 
            The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value="""" />
    <add key=""dmsVirtualRoot"" value="""" />
    <add key=""dmsDataSource"" value="""" />
    <add key=""dmsOEMProductName"" value=""OnBase"" />
    <add key=""ServerDesignation"" value="""" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""ValidationSettings:UnobtrusiveValidationMode"" value=""None"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test13()
    {
        //Testing the parsing of the 211 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.web>
    <compilation debug=""true"" targetFramework=""4.7.2"">
      <assemblies>
        <add assembly=""DevExpress.Dashboard.v17.1.Web, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Dashboard.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Data.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.DataAccess.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Office.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Printing.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Charts.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.RichEdit.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Xpo.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Web.ASPxThemes.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
      </assemblies>
    </compilation>
    <!--  CUSTOM ERROR MESSAGES
              Set customErrors mode=""On"" or ""RemoteOnly"" to enable custom error messages, ""Off"" to disable. 
              Add <error> tags for each of the errors you want to handle.

              ""On"" Always display custom (friendly) messages.
              ""Off"" Always display detailed ASP.NET error information.
              ""RemoteOnly"" Display custom (friendly) messages only to users not running 
               on the local Web server. This setting is recommended for security purposes, so 
               that you do not display application detail information to remote clients.
        -->
    <customErrors mode=""RemoteOnly"" />
    <!--  AUTHENTICATION 
              This section sets the authentication policies of the application. Possible modes are ""Windows"", 
              ""Forms"", ""Passport"" and ""None""

              ""None"" No authentication is performed. 
              ""Windows"" IIS performs authentication (Basic, Digest, or Integrated Windows) according to 
               its settings for the application. Anonymous access must be disabled in IIS. 
              ""Forms"" You provide a custom form (Web page) for users to enter their credentials, and then 
               you authenticate them in your application. A user credential token is stored in a cookie.
              ""Passport"" Authentication is performed via a centralized authentication service provided
               by Microsoft that offers a single logon and core profile services for member sites.
        -->
    <authentication mode=""Windows"" />
    <!--  AUTHORIZATION 
              This section sets the authorization policies of the application. You can allow or deny access
              to application resources by user or role. Wildcards: ""*"" mean everyone, ""?"" means anonymous 
              (unauthenticated) users.
        -->
    <authorization>
      <allow users=""*"" />
      <!-- Allow all users -->
      <!--  <allow     users=""[comma separated list of users]""
                             roles=""[comma separated list of roles]""/>
                  <deny      users=""[comma separated list of users]""
                             roles=""[comma separated list of roles]""/>
            -->
    </authorization>
    <!--  APPLICATION-LEVEL TRACE LOGGING
              Application-level tracing enables trace log output for every page within an application. 
              Set trace enabled=""true"" to enable application trace logging.  If pageOutput=""true"", the
              trace information will be displayed at the bottom of each page.  Otherwise, you can view the 
              application trace log by browsing the ""trace.axd"" page from your web application
              root. 
        -->
    <trace enabled=""false"" requestLimit=""10"" pageOutput=""false"" traceMode=""SortByTime"" localOnly=""true"" />
    <!--  SESSION STATE SETTINGS
              By default ASP.NET uses cookies to identify which requests belong to a particular session. 
              If cookies are not available, a session can be tracked by adding a session identifier to the URL. 
              To disable cookies, set sessionState cookieless=""true"".
        -->
    <sessionState mode=""InProc"" stateConnectionString=""tcpip=127.0.0.1:42424"" sqlConnectionString=""data source=127.0.0.1;Trusted_Connection=yes"" cookieless=""false"" timeout=""20"" />
    <!--  HTTPRUNTIME
              By default the maximum size a request may be is 4096 KB.  If files larger than 4096 KB (4 MB)
              need to be uploaded increase the size of the maxRequestLength.  MaxRequestLength value is in KiloBytes.
              By default the maximum number of seconds that a request is allowed to execute is 90 seconds.
              If uploading large documents, the executionTimeout value may need to be increased for proper processing.
      
              If uploads larger than 30MB are required, maxRequestLength in the application server's web.config must also be increased.
              If uploads larger than 30MB are required and IIS7 or greater is being used, additional changes are required.
              Refer to the maxAllowedContentLength comments for information regarding the changes.
          -->
    <!--  GLOBALIZATION
              This section sets the globalization settings of the application. 
        -->
    <globalization requestEncoding=""utf-8"" responseEncoding=""utf-8"" />
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <httpRuntime targetFramework=""4.7.2"" requestValidationMode=""2.0"" maxRequestLength=""4096"" executionTimeout=""90"" enableVersionHeader=""false"" />
    <httpModules>
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" name=""ASPxHttpHandlerModule"" />
    </httpModules>
    <httpHandlers>
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" verb=""GET,POST"" path=""DX.ashx"" validate=""false"" />
      <add verb=""GET,POST"" path=""ASPxUploadProgressHandlerPage.ashx"" type=""DevExpress.Web.ASPxUploadProgressHttpHandler, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
    </httpHandlers>
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test14()
    {
        //Testing the parsing of the 211 system.webServer section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.webServer>
    <validation validateIntegratedModeConfiguration=""false"" />
    <httpProtocol>
      <customHeaders>
        <remove name=""X-AspNet-Version"" />
        <remove name=""X-AspNetMvc-Version"" />
        <remove name=""X-Powered-By"" />
      </customHeaders>
    </httpProtocol>
    <modules>
      <!-- Required by DevExpress -->
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" name=""ASPxHttpHandlerModule"" />
      <!--The format for this section should additionally contain the preCondition attribute.-->
      <add name=""OnBaseContextModule"" type=""Hyland.Server.Diagnostics.OnBaseContextModule, Hyland.Server"" preCondition=""managedHandler"" />
      <!-- The following two modules are required for ADFS -->
      <!--add name=""WSFederationAuthenticationModule"" type=""System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!--add name=""SessionAuthenticationModule"" type=""System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!-- Http Trace -->
    </modules>
    <handlers accessPolicy=""Read, Script"">
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" verb=""GET,POST"" path=""DX.ashx"" name=""ASPxHttpHandlerModule"" preCondition=""integratedMode"" />
      <add name=""UnloadHandler.ashx_*"" path=""UnloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.UnloadHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""Login.ashx_*"" path=""Login.ashx"" verb=""*"" type=""Hyland.Controls.Web.Login.LoginHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""CalendarProvider.ashx_*"" path=""CalendarProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.Calendar.CalendarProvider,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Http Trace -->
      <add name=""ASPxUploadProgressHandler"" preCondition=""integratedMode"" verb=""GET,POST"" path=""ASPxUploadProgressHandlerPage.ashx"" type=""DevExpress.Web.ASPxUploadProgressHttpHandler, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
    </handlers>
    <!--This setting only applies to IIS7 and greater-->
    <!--The Request Filtering module will reject requests larger than 30MB by default.-->
    <!--If IIS7 or greater is being used and uploads larger than 30MB are expected, maxAllowedContentLength as well as maxRequestLength must be increased.-->
    <!--Uploads that are below maxAllowedContentLength but above maxRequestLength will display a friendly error message to the user.-->
    <!--Uploads that are above maxAllowedContentLength will be rejected and a 404 error will occur.-->
    <!--Therefore, this value (in bytes) should be larger and not equal to maxRequestLength (in kilobytes) or users will not receive a friendly error message.-->
    <!--Uncomment the section below and enter the value as needed.-->
    <!--This setting should be changed in both the web and application server's web.config.-->
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <security>
      <requestFiltering>
        <requestLimits maxAllowedContentLength=""30000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <!--Defines the default documents to use for IIS7 and greater-->
    <!--IIS7 and greater will store the configuration here instead of the metabase used in previous versions of IIS.-->
    <defaultDocument>
      <files>
        <clear />
        <add value=""Viewer.aspx"" />
      </files>
    </defaultDocument>
  </system.webServer>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.webServer", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test15()
    {
        //Testing the parsing of the 211 system.extensions section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""50000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""50000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.web.extensions>
    <scripting>
      <webServices>
        <jsonSerialization maxJsonLength=""50000000"">
        </jsonSerialization>
      </webServices>
    </scripting>
  </system.web.extensions>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.extensions", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test16()
    {
        //Testing the parsing of the 211 system.diagnostics section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.diagnostics>
    <switches>
      <!-- 
        This switch controls tracing globally through Hyland.Logging.
        It configures the level of information from Trace that is logged.
        For no information set the value to zero. Set the value to 1, 2, 3, or 4 for
        minimal, normal, detailed, or verbose messages, respectively.
        -->
      <add name=""hylandTracing"" value=""0"" />
    </switches>
  </system.diagnostics>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.diagnostics", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test17()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""username"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""OB-Username"",""Value"":""Tes"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""password"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""OB-Password"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""useTheme"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Dashboard-Theme"",""Value"":""dark"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboard"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Export-Dashboard"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboardItems"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Export-Dashboard-Items"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""acceptHttpParams"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Allow-HTTP-Parameters"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""sessionTraceLevel"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Dashboard-Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableAutoLogin"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""reportPagingLimit"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Report-Paging-Limit"",""Value"":""50"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Dashboard-Viewer-Settings"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""username"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""OB-Username"",""Value"":""Tes"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""password"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""OB-Password"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""useTheme"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Dashboard-Theme"",""Value"":""dark"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboard"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Export-Dashboard"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboardItems"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Export-Dashboard-Items"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""acceptHttpParams"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Allow-HTTP-Parameters"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""sessionTraceLevel"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Dashboard-Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableAutoLogin"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""reportPagingLimit"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Report-Paging-Limit"",""Value"":""50"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Dashboard-Viewer-Settings"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test18()
    {
        //Testing the parsing of the 211 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure211WithVersionNumber);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""ASP.NET Web""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":{""OutputFormat"":""Minimal""},""RouteType"":""Console"",""Name"":""Diagnostics Console (1)"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":{""SourceName"":""Hyland""},""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":null,""RouteType"":""EventLog"",""Name"":""EventLog"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""2"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":{""URL"":""http://localhost:8989""},""console"":null,""RouteType"":""DurableHttp"",""Name"":""Durable"",""SourceEvents"":""Audit Events"",""EnableIpAddressMasking"":""True"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""ASP.NET Web"" />
    <Routes>
      <Route name=""Diagnostics Console (1)"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Console"" />
        <add key=""OutputFormat"" value=""Minimal"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""EventLog"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""EventLog"" value=""Hyland"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
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
      <Route name=""Durable"">
        <add key=""minimum-level"" value=""Debug"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""DurableHttp"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
    </AuditRoutes>
  </Hyland.Logging>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Logging", xmldoc, new DefaultWebApplicationDataStructures());

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test19()
    {
        //Testing the Prebuilding of the 221 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""OptimizedServicePipeline"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Optimized-Service-Pipeline"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""Request-Timeout"",""Value"":""300"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
            {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
            {"Hyland.Services.Client","OptimizedServicePipeline","Enabled","1","Optimized-Service-Pipeline","true","","",""},
            {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","Request-Timeout","300","","",""},
            {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test20()
    {
        //Testing the Prebuilding of the 221 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Web-Virtual-Directory"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Core-Data-Source"",""Value"":""[DATASOURCE NAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ServerDesignation"",""type"":""2"",""htmlIdName"":""Server-Designation"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
            {"appSettings","add","dmsVirtualRoot","2","Web-Virtual-Directory","http://[HOSTNAME]/[VIRTUAL ROOT]","","",""},
            {"appSettings","add","dmsDataSource","2","Core-Data-Source","[DATASOURCE NAME]","","",""},
            {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test21()
    {
        //Testing the Prebuilding of the 221 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","",""},
            {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test22()
    {
        //Testing the Prebuilding of the 221 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test23()
    {
        //Testing the Prebuilding of the 221 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""50000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web.extensions","scripting/webServices/jsonSerialization","maxJsonLength","2","JSON-Serialization-Max-Length","50000000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test24()
    {
        //Testing the Prebuilding of the 221 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test25()
    {
        //Testing the parsing of the 221 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""OptimizedServicePipeline"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Optimized-Service-Pipeline"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""Request-Timeout"",""Value"":""300"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""OptimizedServicePipeline"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Optimized-Service-Pipeline"",""Value"":""True"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""Request-Timeout"",""Value"":""300"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.asmx"" ServiceClientType=""SOAP"" />
    <!-- AllowNTAuthenticationOnForwarding if enabled, allows the web server to forward NT credentials 
        to the  Application Server. Only turn this flag on when using NT authentication. -->
    <AllowNTAuthenticationOnForwarding Enabled=""false"" />
    <!-- Use the optimized service pipeline for more efficient communication of results -->
    <OptimizedServicePipeline Enabled=""True"" />
    <!-- Determines how long the service client should wait for a response from the application server -->
    <RequestTimeoutSeconds Value=""300"" />
    <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
    <!--System.Xml.XmlElement-->
    <StreamingSettings BufferSize=""64000"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test26()
    {
        //Testing the parsing of the 221 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Web-Virtual-Directory"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Core-Data-Source"",""Value"":""[DATASOURCE NAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ServerDesignation"",""type"":""2"",""htmlIdName"":""Server-Designation"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Web-Virtual-Directory"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Core-Data-Source"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ServerDesignation"",""type"":""2"",""htmlIdName"":""Server-Designation"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""webtheme\"" value=\""XP\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""ValidationSettings:UnobtrusiveValidationMode\"" value=\""None\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<appSettings file=""version.xml"">
    <!-- This setting controls if the server will accept only https connections or not. 
            If you set this to false all incoming requests have to be made over https. 
            If you set this to true then both http and https connections are accepted. 
            The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value="""" />
    <add key=""dmsVirtualRoot"" value="""" />
    <add key=""dmsDataSource"" value="""" />
    <add key=""dmsOEMProductName"" value=""OnBase"" />
    <add key=""ServerDesignation"" value="""" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""ValidationSettings:UnobtrusiveValidationMode"" value=""None"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test27()
    {
        //Testing the parsing of the 221 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.web>
    <compilation debug=""true"" targetFramework=""4.7.2"">
      <assemblies>
        <add assembly=""DevExpress.Dashboard.v17.1.Web, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Dashboard.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Data.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.DataAccess.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Office.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Printing.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Charts.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.RichEdit.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Xpo.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Web.ASPxThemes.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
      </assemblies>
    </compilation>
    <!--  CUSTOM ERROR MESSAGES
              Set customErrors mode=""On"" or ""RemoteOnly"" to enable custom error messages, ""Off"" to disable. 
              Add <error> tags for each of the errors you want to handle.

              ""On"" Always display custom (friendly) messages.
              ""Off"" Always display detailed ASP.NET error information.
              ""RemoteOnly"" Display custom (friendly) messages only to users not running 
               on the local Web server. This setting is recommended for security purposes, so 
               that you do not display application detail information to remote clients.
        -->
    <customErrors mode=""RemoteOnly"" />
    <!--  AUTHENTICATION 
              This section sets the authentication policies of the application. Possible modes are ""Windows"", 
              ""Forms"", ""Passport"" and ""None""

              ""None"" No authentication is performed. 
              ""Windows"" IIS performs authentication (Basic, Digest, or Integrated Windows) according to 
               its settings for the application. Anonymous access must be disabled in IIS. 
              ""Forms"" You provide a custom form (Web page) for users to enter their credentials, and then 
               you authenticate them in your application. A user credential token is stored in a cookie.
              ""Passport"" Authentication is performed via a centralized authentication service provided
               by Microsoft that offers a single logon and core profile services for member sites.
        -->
    <authentication mode=""Windows"" />
    <!--  AUTHORIZATION 
              This section sets the authorization policies of the application. You can allow or deny access
              to application resources by user or role. Wildcards: ""*"" mean everyone, ""?"" means anonymous 
              (unauthenticated) users.
        -->
    <authorization>
      <allow users=""*"" />
      <!-- Allow all users -->
      <!--  <allow     users=""[comma separated list of users]""
                             roles=""[comma separated list of roles]""/>
                  <deny      users=""[comma separated list of users]""
                             roles=""[comma separated list of roles]""/>
            -->
    </authorization>
    <!--  APPLICATION-LEVEL TRACE LOGGING
              Application-level tracing enables trace log output for every page within an application. 
              Set trace enabled=""true"" to enable application trace logging.  If pageOutput=""true"", the
              trace information will be displayed at the bottom of each page.  Otherwise, you can view the 
              application trace log by browsing the ""trace.axd"" page from your web application
              root. 
        -->
    <trace enabled=""false"" requestLimit=""10"" pageOutput=""false"" traceMode=""SortByTime"" localOnly=""true"" />
    <!--  SESSION STATE SETTINGS
              By default ASP.NET uses cookies to identify which requests belong to a particular session. 
              If cookies are not available, a session can be tracked by adding a session identifier to the URL. 
              To disable cookies, set sessionState cookieless=""true"".
        -->
    <sessionState mode=""InProc"" stateConnectionString=""tcpip=127.0.0.1:42424"" sqlConnectionString=""data source=127.0.0.1;Trusted_Connection=yes"" cookieless=""false"" timeout=""20"" />
    <!--  HTTPRUNTIME
              By default the maximum size a request may be is 4096 KB.  If files larger than 4096 KB (4 MB)
              need to be uploaded increase the size of the maxRequestLength.  MaxRequestLength value is in KiloBytes.
              By default the maximum number of seconds that a request is allowed to execute is 90 seconds.
              If uploading large documents, the executionTimeout value may need to be increased for proper processing.
      
              If uploads larger than 30MB are required, maxRequestLength in the application server's web.config must also be increased.
              If uploads larger than 30MB are required and IIS7 or greater is being used, additional changes are required.
              Refer to the maxAllowedContentLength comments for information regarding the changes.
          -->
    <!--  GLOBALIZATION
              This section sets the globalization settings of the application. 
        -->
    <globalization requestEncoding=""utf-8"" responseEncoding=""utf-8"" />
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <httpRuntime targetFramework=""4.7.2"" requestValidationMode=""2.0"" maxRequestLength=""4096"" executionTimeout=""90"" enableVersionHeader=""false"" />
    <httpModules>
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" name=""ASPxHttpHandlerModule"" />
    </httpModules>
    <httpHandlers>
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" verb=""GET,POST"" path=""DX.ashx"" validate=""false"" />
      <add verb=""GET,POST"" path=""ASPxUploadProgressHandlerPage.ashx"" type=""DevExpress.Web.ASPxUploadProgressHttpHandler, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
    </httpHandlers>
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test28()
    {
        //Testing the parsing of the 221 system.webServer section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.webServer>
    <validation validateIntegratedModeConfiguration=""false"" />
    <httpProtocol>
      <customHeaders>
        <remove name=""X-AspNet-Version"" />
        <remove name=""X-AspNetMvc-Version"" />
        <remove name=""X-Powered-By"" />
      </customHeaders>
    </httpProtocol>
    <modules>
      <!-- Required by DevExpress -->
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" name=""ASPxHttpHandlerModule"" />
      <!--The format for this section should additionally contain the preCondition attribute.-->
      <add name=""OnBaseContextModule"" type=""Hyland.Server.Diagnostics.OnBaseContextModule, Hyland.Server"" preCondition=""managedHandler"" />
      <!-- The following two modules are required for ADFS -->
      <!--add name=""WSFederationAuthenticationModule"" type=""System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!--add name=""SessionAuthenticationModule"" type=""System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!-- Http Trace -->
    </modules>
    <handlers accessPolicy=""Read, Script"">
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" verb=""GET,POST"" path=""DX.ashx"" name=""ASPxHttpHandlerModule"" preCondition=""integratedMode"" />
      <add name=""UnloadHandler.ashx_*"" path=""UnloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.UnloadHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""Login.ashx_*"" path=""Login.ashx"" verb=""*"" type=""Hyland.Controls.Web.Login.LoginHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""CalendarProvider.ashx_*"" path=""CalendarProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.Calendar.CalendarProvider,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Http Trace -->
      <add name=""ASPxUploadProgressHandler"" preCondition=""integratedMode"" verb=""GET,POST"" path=""ASPxUploadProgressHandlerPage.ashx"" type=""DevExpress.Web.ASPxUploadProgressHttpHandler, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
    </handlers>
    <!--This setting only applies to IIS7 and greater-->
    <!--The Request Filtering module will reject requests larger than 30MB by default.-->
    <!--If IIS7 or greater is being used and uploads larger than 30MB are expected, maxAllowedContentLength as well as maxRequestLength must be increased.-->
    <!--Uploads that are below maxAllowedContentLength but above maxRequestLength will display a friendly error message to the user.-->
    <!--Uploads that are above maxAllowedContentLength will be rejected and a 404 error will occur.-->
    <!--Therefore, this value (in bytes) should be larger and not equal to maxRequestLength (in kilobytes) or users will not receive a friendly error message.-->
    <!--Uncomment the section below and enter the value as needed.-->
    <!--This setting should be changed in both the web and application server's web.config.-->
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <security>
      <requestFiltering>
        <requestLimits maxAllowedContentLength=""30000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <!--Defines the default documents to use for IIS7 and greater-->
    <!--IIS7 and greater will store the configuration here instead of the metabase used in previous versions of IIS.-->
    <defaultDocument>
      <files>
        <clear />
        <add value=""Viewer.aspx"" />
      </files>
    </defaultDocument>
  </system.webServer>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.webServer", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test29()
    {
        //Testing the parsing of the 221 system.extensions section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""50000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""50000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.web.extensions>
    <scripting>
      <webServices>
        <jsonSerialization maxJsonLength=""50000000"">
        </jsonSerialization>
      </webServices>
    </scripting>
  </system.web.extensions>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.extensions", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test30()
    {
        //Testing the parsing of the 221 system.diagnostics section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.diagnostics>
    <switches>
      <!-- 
        This switch controls tracing globally through Hyland.Logging.
        It configures the level of information from Trace that is logged.
        For no information set the value to zero. Set the value to 1, 2, 3, or 4 for
        minimal, normal, detailed, or verbose messages, respectively.
        -->
      <add name=""hylandTracing"" value=""0"" />
    </switches>
  </system.diagnostics>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.diagnostics", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test31()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""username"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""OB-Username"",""Value"":""Tes"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""password"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""OB-Password"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""useTheme"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Dashboard-Theme"",""Value"":""dark"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboard"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Export-Dashboard"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboardItems"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Export-Dashboard-Items"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""acceptHttpParams"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Allow-HTTP-Parameters"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""sessionTraceLevel"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Dashboard-Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableAutoLogin"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""reportPagingLimit"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Report-Paging-Limit"",""Value"":""50"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Dashboard-Viewer-Settings"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""username"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""OB-Username"",""Value"":""Tes"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""password"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""OB-Password"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""useTheme"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Dashboard-Theme"",""Value"":""dark"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboard"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Export-Dashboard"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboardItems"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Export-Dashboard-Items"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""acceptHttpParams"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Allow-HTTP-Parameters"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""sessionTraceLevel"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Dashboard-Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableAutoLogin"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""reportPagingLimit"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Report-Paging-Limit"",""Value"":""50"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Dashboard-Viewer-Settings"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test32()
    {
        //Testing the parsing of the 221 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure221WithVersionNumber);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""22.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""ASP.NET Web""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":{""OutputFormat"":""Minimal""},""RouteType"":""Console"",""Name"":""Diagnostics Console (1)"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":{""SourceName"":""Hyland""},""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":null,""RouteType"":""EventLog"",""Name"":""EventLog"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""2"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":{""URL"":""http://localhost:8989""},""console"":null,""RouteType"":""DurableHttp"",""Name"":""Durable"",""SourceEvents"":""Audit Events"",""EnableIpAddressMasking"":""True"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""ASP.NET Web"" />
    <Routes>
      <Route name=""Diagnostics Console (1)"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Console"" />
        <add key=""OutputFormat"" value=""Minimal"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""EventLog"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""EventLog"" value=""Hyland"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
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
      <Route name=""Durable"">
        <add key=""minimum-level"" value=""Debug"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""DurableHttp"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
    </AuditRoutes>
  </Hyland.Logging>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Logging", xmldoc, new DefaultWebApplicationDataStructures());

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test33()
    {
        //Testing the Prebuilding of the 231 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""OptimizedServicePipeline"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Optimized-Service-Pipeline"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""Request-Timeout"",""Value"":""300"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
            {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
            {"Hyland.Services.Client","OptimizedServicePipeline","Enabled","1","Optimized-Service-Pipeline","true","","",""},
            {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","Request-Timeout","300","","",""},
            {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test34()
    {
        //Testing the Prebuilding of the 231 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Web-Virtual-Directory"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Core-Data-Source"",""Value"":""[DATASOURCE NAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ServerDesignation"",""type"":""2"",""htmlIdName"":""Server-Designation"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
            {"appSettings","add","dmsVirtualRoot","2","Web-Virtual-Directory","http://[HOSTNAME]/[VIRTUAL ROOT]","","",""},
            {"appSettings","add","dmsDataSource","2","Core-Data-Source","[DATASOURCE NAME]","","",""},
            {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test35()
    {
        //Testing the Prebuilding of the 231 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","",""},
            {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test36()
    {
        //Testing the Prebuilding of the 231 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","",""}
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

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""50000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web.extensions","scripting/webServices/jsonSerialization","maxJsonLength","2","JSON-Serialization-Max-Length","50000000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test38()
    {
        //Testing the Prebuilding of the 231 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test39()
    {
        //Testing the parsing of the 231 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""OptimizedServicePipeline"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Optimized-Service-Pipeline"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""Request-Timeout"",""Value"":""300"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""OptimizedServicePipeline"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Optimized-Service-Pipeline"",""Value"":""True"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""Request-Timeout"",""Value"":""300"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.asmx"" ServiceClientType=""SOAP"" />
    <!-- AllowNTAuthenticationOnForwarding if enabled, allows the web server to forward NT credentials 
        to the  Application Server. Only turn this flag on when using NT authentication. -->
    <AllowNTAuthenticationOnForwarding Enabled=""false"" />
    <!-- Use the optimized service pipeline for more efficient communication of results -->
    <OptimizedServicePipeline Enabled=""True"" />
    <!-- Determines how long the service client should wait for a response from the application server -->
    <RequestTimeoutSeconds Value=""300"" />
    <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
    <!--System.Xml.XmlElement-->
    <StreamingSettings BufferSize=""64000"" />
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
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Web-Virtual-Directory"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Core-Data-Source"",""Value"":""[DATASOURCE NAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ServerDesignation"",""type"":""2"",""htmlIdName"":""Server-Designation"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Web-Virtual-Directory"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Core-Data-Source"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ServerDesignation"",""type"":""2"",""htmlIdName"":""Server-Designation"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""webtheme\"" value=\""XP\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""ValidationSettings:UnobtrusiveValidationMode\"" value=\""None\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<appSettings file=""version.xml"">
    <!-- This setting controls if the server will accept only https connections or not. 
            If you set this to false all incoming requests have to be made over https. 
            If you set this to true then both http and https connections are accepted. 
            The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value="""" />
    <add key=""dmsVirtualRoot"" value="""" />
    <add key=""dmsDataSource"" value="""" />
    <add key=""dmsOEMProductName"" value=""OnBase"" />
    <add key=""ServerDesignation"" value="""" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""ValidationSettings:UnobtrusiveValidationMode"" value=""None"" />
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
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.web>
    <compilation debug=""true"" targetFramework=""4.7.2"">
      <assemblies>
        <add assembly=""DevExpress.Dashboard.v17.1.Web, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Dashboard.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Data.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.DataAccess.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Office.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Printing.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Charts.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.RichEdit.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Xpo.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Web.ASPxThemes.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
      </assemblies>
    </compilation>
    <!--  CUSTOM ERROR MESSAGES
              Set customErrors mode=""On"" or ""RemoteOnly"" to enable custom error messages, ""Off"" to disable. 
              Add <error> tags for each of the errors you want to handle.

              ""On"" Always display custom (friendly) messages.
              ""Off"" Always display detailed ASP.NET error information.
              ""RemoteOnly"" Display custom (friendly) messages only to users not running 
               on the local Web server. This setting is recommended for security purposes, so 
               that you do not display application detail information to remote clients.
        -->
    <customErrors mode=""RemoteOnly"" />
    <!--  AUTHENTICATION 
              This section sets the authentication policies of the application. Possible modes are ""Windows"", 
              ""Forms"", ""Passport"" and ""None""

              ""None"" No authentication is performed. 
              ""Windows"" IIS performs authentication (Basic, Digest, or Integrated Windows) according to 
               its settings for the application. Anonymous access must be disabled in IIS. 
              ""Forms"" You provide a custom form (Web page) for users to enter their credentials, and then 
               you authenticate them in your application. A user credential token is stored in a cookie.
              ""Passport"" Authentication is performed via a centralized authentication service provided
               by Microsoft that offers a single logon and core profile services for member sites.
        -->
    <authentication mode=""Windows"" />
    <!--  AUTHORIZATION 
              This section sets the authorization policies of the application. You can allow or deny access
              to application resources by user or role. Wildcards: ""*"" mean everyone, ""?"" means anonymous 
              (unauthenticated) users.
        -->
    <authorization>
      <allow users=""*"" />
      <!-- Allow all users -->
      <!--  <allow     users=""[comma separated list of users]""
                             roles=""[comma separated list of roles]""/>
                  <deny      users=""[comma separated list of users]""
                             roles=""[comma separated list of roles]""/>
            -->
    </authorization>
    <!--  APPLICATION-LEVEL TRACE LOGGING
              Application-level tracing enables trace log output for every page within an application. 
              Set trace enabled=""true"" to enable application trace logging.  If pageOutput=""true"", the
              trace information will be displayed at the bottom of each page.  Otherwise, you can view the 
              application trace log by browsing the ""trace.axd"" page from your web application
              root. 
        -->
    <trace enabled=""false"" requestLimit=""10"" pageOutput=""false"" traceMode=""SortByTime"" localOnly=""true"" />
    <!--  SESSION STATE SETTINGS
              By default ASP.NET uses cookies to identify which requests belong to a particular session. 
              If cookies are not available, a session can be tracked by adding a session identifier to the URL. 
              To disable cookies, set sessionState cookieless=""true"".
        -->
    <sessionState mode=""InProc"" stateConnectionString=""tcpip=127.0.0.1:42424"" sqlConnectionString=""data source=127.0.0.1;Trusted_Connection=yes"" cookieless=""false"" timeout=""20"" />
    <!--  HTTPRUNTIME
              By default the maximum size a request may be is 4096 KB.  If files larger than 4096 KB (4 MB)
              need to be uploaded increase the size of the maxRequestLength.  MaxRequestLength value is in KiloBytes.
              By default the maximum number of seconds that a request is allowed to execute is 90 seconds.
              If uploading large documents, the executionTimeout value may need to be increased for proper processing.
      
              If uploads larger than 30MB are required, maxRequestLength in the application server's web.config must also be increased.
              If uploads larger than 30MB are required and IIS7 or greater is being used, additional changes are required.
              Refer to the maxAllowedContentLength comments for information regarding the changes.
          -->
    <!--  GLOBALIZATION
              This section sets the globalization settings of the application. 
        -->
    <globalization requestEncoding=""utf-8"" responseEncoding=""utf-8"" />
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <httpRuntime targetFramework=""4.7.2"" requestValidationMode=""2.0"" maxRequestLength=""4096"" executionTimeout=""90"" enableVersionHeader=""false"" />
    <httpModules>
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" name=""ASPxHttpHandlerModule"" />
    </httpModules>
    <httpHandlers>
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" verb=""GET,POST"" path=""DX.ashx"" validate=""false"" />
      <add verb=""GET,POST"" path=""ASPxUploadProgressHandlerPage.ashx"" type=""DevExpress.Web.ASPxUploadProgressHttpHandler, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
    </httpHandlers>
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test42()
    {
        //Testing the parsing of the 231 system.webServer section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.webServer>
    <validation validateIntegratedModeConfiguration=""false"" />
    <httpProtocol>
      <customHeaders>
        <remove name=""X-AspNet-Version"" />
        <remove name=""X-AspNetMvc-Version"" />
        <remove name=""X-Powered-By"" />
      </customHeaders>
    </httpProtocol>
    <modules>
      <!-- Required by DevExpress -->
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" name=""ASPxHttpHandlerModule"" />
      <!--The format for this section should additionally contain the preCondition attribute.-->
      <add name=""OnBaseContextModule"" type=""Hyland.Server.Diagnostics.OnBaseContextModule, Hyland.Server"" preCondition=""managedHandler"" />
      <!-- The following two modules are required for ADFS -->
      <!--add name=""WSFederationAuthenticationModule"" type=""System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!--add name=""SessionAuthenticationModule"" type=""System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!-- Http Trace -->
    </modules>
    <handlers accessPolicy=""Read, Script"">
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" verb=""GET,POST"" path=""DX.ashx"" name=""ASPxHttpHandlerModule"" preCondition=""integratedMode"" />
      <add name=""UnloadHandler.ashx_*"" path=""UnloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.UnloadHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""Login.ashx_*"" path=""Login.ashx"" verb=""*"" type=""Hyland.Controls.Web.Login.LoginHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""CalendarProvider.ashx_*"" path=""CalendarProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.Calendar.CalendarProvider,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Http Trace -->
      <add name=""ASPxUploadProgressHandler"" preCondition=""integratedMode"" verb=""GET,POST"" path=""ASPxUploadProgressHandlerPage.ashx"" type=""DevExpress.Web.ASPxUploadProgressHttpHandler, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
    </handlers>
    <!--This setting only applies to IIS7 and greater-->
    <!--The Request Filtering module will reject requests larger than 30MB by default.-->
    <!--If IIS7 or greater is being used and uploads larger than 30MB are expected, maxAllowedContentLength as well as maxRequestLength must be increased.-->
    <!--Uploads that are below maxAllowedContentLength but above maxRequestLength will display a friendly error message to the user.-->
    <!--Uploads that are above maxAllowedContentLength will be rejected and a 404 error will occur.-->
    <!--Therefore, this value (in bytes) should be larger and not equal to maxRequestLength (in kilobytes) or users will not receive a friendly error message.-->
    <!--Uncomment the section below and enter the value as needed.-->
    <!--This setting should be changed in both the web and application server's web.config.-->
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <security>
      <requestFiltering>
        <requestLimits maxAllowedContentLength=""30000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <!--Defines the default documents to use for IIS7 and greater-->
    <!--IIS7 and greater will store the configuration here instead of the metabase used in previous versions of IIS.-->
    <defaultDocument>
      <files>
        <clear />
        <add value=""Viewer.aspx"" />
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
        //Testing the parsing of the 231 system.extensions section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""50000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""50000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.web.extensions>
    <scripting>
      <webServices>
        <jsonSerialization maxJsonLength=""50000000"">
        </jsonSerialization>
      </webServices>
    </scripting>
  </system.web.extensions>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.extensions", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test44()
    {
        //Testing the parsing of the 231 system.diagnostics section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.diagnostics>
    <switches>
      <!-- 
        This switch controls tracing globally through Hyland.Logging.
        It configures the level of information from Trace that is logged.
        For no information set the value to zero. Set the value to 1, 2, 3, or 4 for
        minimal, normal, detailed, or verbose messages, respectively.
        -->
      <add name=""hylandTracing"" value=""0"" />
    </switches>
  </system.diagnostics>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.diagnostics", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test45()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""username"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""OB-Username"",""Value"":""Tes"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""password"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""OB-Password"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""useTheme"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Dashboard-Theme"",""Value"":""dark"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboard"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Export-Dashboard"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboardItems"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Export-Dashboard-Items"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""acceptHttpParams"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Allow-HTTP-Parameters"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""sessionTraceLevel"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Dashboard-Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableAutoLogin"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""reportPagingLimit"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Report-Paging-Limit"",""Value"":""50"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Dashboard-Viewer-Settings"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""username"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""OB-Username"",""Value"":""Tes"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""password"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""OB-Password"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""useTheme"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Dashboard-Theme"",""Value"":""dark"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboard"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Export-Dashboard"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboardItems"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Export-Dashboard-Items"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""acceptHttpParams"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Allow-HTTP-Parameters"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""sessionTraceLevel"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Dashboard-Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableAutoLogin"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""reportPagingLimit"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Report-Paging-Limit"",""Value"":""50"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Dashboard-Viewer-Settings"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test46()
    {
        //Testing the parsing of the 231 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure231WithVersionNumber);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""23.1.7.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""ASP.NET Web""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":{""OutputFormat"":""Minimal""},""RouteType"":""Console"",""Name"":""Diagnostics Console (1)"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":{""SourceName"":""Hyland""},""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":null,""RouteType"":""EventLog"",""Name"":""EventLog"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""2"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":{""URL"":""http://localhost:8989""},""console"":null,""RouteType"":""DurableHttp"",""Name"":""Durable"",""SourceEvents"":""Audit Events"",""EnableIpAddressMasking"":""True"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""ASP.NET Web"" />
    <Routes>
      <Route name=""Diagnostics Console (1)"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Console"" />
        <add key=""OutputFormat"" value=""Minimal"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""EventLog"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""EventLog"" value=""Hyland"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
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
      <Route name=""Durable"">
        <add key=""minimum-level"" value=""Debug"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""DurableHttp"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
    </AuditRoutes>
  </Hyland.Logging>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Logging", xmldoc, new DefaultWebApplicationDataStructures());

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test47()
    {
        //Testing the Prebuilding of the 241 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""OptimizedServicePipeline"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Optimized-Service-Pipeline"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""Request-Timeout"",""Value"":""300"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
            {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
            {"Hyland.Services.Client","OptimizedServicePipeline","Enabled","1","Optimized-Service-Pipeline","true","","",""},
            {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","Request-Timeout","300","","",""},
            {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test48()
    {
        //Testing the Prebuilding of the 241 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Web-Virtual-Directory"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Core-Data-Source"",""Value"":""[DATASOURCE NAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ServerDesignation"",""type"":""2"",""htmlIdName"":""Server-Designation"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
            {"appSettings","add","dmsVirtualRoot","2","Web-Virtual-Directory","http://[HOSTNAME]/[VIRTUAL ROOT]","","",""},
            {"appSettings","add","dmsDataSource","2","Core-Data-Source","[DATASOURCE NAME]","","",""},
            {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test49()
    {
        //Testing the Prebuilding of the 241 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","",""},
            {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test50()
    {
        //Testing the Prebuilding of the 241 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test51()
    {
        //Testing the Prebuilding of the 241 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""50000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web.extensions","scripting/webServices/jsonSerialization","maxJsonLength","2","JSON-Serialization-Max-Length","50000000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test52()
    {
        //Testing the Prebuilding of the 241 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        string[,] translator = new string[,]
        {
            {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test53()
    {
        //Testing the parsing of the 241 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""OptimizedServicePipeline"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Optimized-Service-Pipeline"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""Request-Timeout"",""Value"":""300"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""http://localhost/AppServer"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""SOAP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""AllowNTAuthenticationOnForwarding"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Allow-NT-Authentication-On-Forwarding"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""OptimizedServicePipeline"",""AttributeName"":""Enabled"",""type"":""1"",""htmlIdName"":""Optimized-Service-Pipeline"",""Value"":""True"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""RequestTimeoutSeconds"",""AttributeName"":""Value"",""type"":""2"",""htmlIdName"":""Request-Timeout"",""Value"":""300"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""http://localhost/AppServer/Service.asmx"" ServiceClientType=""SOAP"" />
    <!-- AllowNTAuthenticationOnForwarding if enabled, allows the web server to forward NT credentials 
        to the  Application Server. Only turn this flag on when using NT authentication. -->
    <AllowNTAuthenticationOnForwarding Enabled=""false"" />
    <!-- Use the optimized service pipeline for more efficient communication of results -->
    <OptimizedServicePipeline Enabled=""True"" />
    <!-- Determines how long the service client should wait for a response from the application server -->
    <RequestTimeoutSeconds Value=""300"" />
    <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
    <!--System.Xml.XmlElement-->
    <StreamingSettings BufferSize=""64000"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test54()
    {
        //Testing the parsing of the 241 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Web-Virtual-Directory"",""Value"":""http://[HOSTNAME]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Core-Data-Source"",""Value"":""[DATASOURCE NAME]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ServerDesignation"",""type"":""2"",""htmlIdName"":""Server-Designation"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Web-Virtual-Directory"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Core-Data-Source"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ServerDesignation"",""type"":""2"",""htmlIdName"":""Server-Designation"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""webtheme\"" value=\""XP\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":"""",""type"":""0"",""htmlIdName"":"""",""Value"":""<add key=\""ValidationSettings:UnobtrusiveValidationMode\"" value=\""None\"" />"",""Version"":""21.1.38.1000"",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<appSettings file=""version.xml"">
    <!-- This setting controls if the server will accept only https connections or not. 
            If you set this to false all incoming requests have to be made over https. 
            If you set this to true then both http and https connections are accepted. 
            The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value="""" />
    <add key=""dmsVirtualRoot"" value="""" />
    <add key=""dmsDataSource"" value="""" />
    <add key=""dmsOEMProductName"" value=""OnBase"" />
    <add key=""ServerDesignation"" value="""" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""ValidationSettings:UnobtrusiveValidationMode"" value=""None"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test55()
    {
        //Testing the parsing of the 241 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.web>
    <compilation debug=""true"" targetFramework=""4.7.2"">
      <assemblies>
        <add assembly=""DevExpress.Dashboard.v17.1.Web, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Dashboard.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Data.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.DataAccess.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Office.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Printing.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Charts.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.RichEdit.v17.1.Core, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Xpo.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
        <add assembly=""DevExpress.Web.ASPxThemes.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
      </assemblies>
    </compilation>
    <!--  CUSTOM ERROR MESSAGES
              Set customErrors mode=""On"" or ""RemoteOnly"" to enable custom error messages, ""Off"" to disable. 
              Add <error> tags for each of the errors you want to handle.

              ""On"" Always display custom (friendly) messages.
              ""Off"" Always display detailed ASP.NET error information.
              ""RemoteOnly"" Display custom (friendly) messages only to users not running 
               on the local Web server. This setting is recommended for security purposes, so 
               that you do not display application detail information to remote clients.
        -->
    <customErrors mode=""RemoteOnly"" />
    <!--  AUTHENTICATION 
              This section sets the authentication policies of the application. Possible modes are ""Windows"", 
              ""Forms"", ""Passport"" and ""None""

              ""None"" No authentication is performed. 
              ""Windows"" IIS performs authentication (Basic, Digest, or Integrated Windows) according to 
               its settings for the application. Anonymous access must be disabled in IIS. 
              ""Forms"" You provide a custom form (Web page) for users to enter their credentials, and then 
               you authenticate them in your application. A user credential token is stored in a cookie.
              ""Passport"" Authentication is performed via a centralized authentication service provided
               by Microsoft that offers a single logon and core profile services for member sites.
        -->
    <authentication mode=""Windows"" />
    <!--  AUTHORIZATION 
              This section sets the authorization policies of the application. You can allow or deny access
              to application resources by user or role. Wildcards: ""*"" mean everyone, ""?"" means anonymous 
              (unauthenticated) users.
        -->
    <authorization>
      <allow users=""*"" />
      <!-- Allow all users -->
      <!--  <allow     users=""[comma separated list of users]""
                             roles=""[comma separated list of roles]""/>
                  <deny      users=""[comma separated list of users]""
                             roles=""[comma separated list of roles]""/>
            -->
    </authorization>
    <!--  APPLICATION-LEVEL TRACE LOGGING
              Application-level tracing enables trace log output for every page within an application. 
              Set trace enabled=""true"" to enable application trace logging.  If pageOutput=""true"", the
              trace information will be displayed at the bottom of each page.  Otherwise, you can view the 
              application trace log by browsing the ""trace.axd"" page from your web application
              root. 
        -->
    <trace enabled=""false"" requestLimit=""10"" pageOutput=""false"" traceMode=""SortByTime"" localOnly=""true"" />
    <!--  SESSION STATE SETTINGS
              By default ASP.NET uses cookies to identify which requests belong to a particular session. 
              If cookies are not available, a session can be tracked by adding a session identifier to the URL. 
              To disable cookies, set sessionState cookieless=""true"".
        -->
    <sessionState mode=""InProc"" stateConnectionString=""tcpip=127.0.0.1:42424"" sqlConnectionString=""data source=127.0.0.1;Trusted_Connection=yes"" cookieless=""false"" timeout=""20"" />
    <!--  HTTPRUNTIME
              By default the maximum size a request may be is 4096 KB.  If files larger than 4096 KB (4 MB)
              need to be uploaded increase the size of the maxRequestLength.  MaxRequestLength value is in KiloBytes.
              By default the maximum number of seconds that a request is allowed to execute is 90 seconds.
              If uploading large documents, the executionTimeout value may need to be increased for proper processing.
      
              If uploads larger than 30MB are required, maxRequestLength in the application server's web.config must also be increased.
              If uploads larger than 30MB are required and IIS7 or greater is being used, additional changes are required.
              Refer to the maxAllowedContentLength comments for information regarding the changes.
          -->
    <!--  GLOBALIZATION
              This section sets the globalization settings of the application. 
        -->
    <globalization requestEncoding=""utf-8"" responseEncoding=""utf-8"" />
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <httpRuntime targetFramework=""4.7.2"" requestValidationMode=""2.0"" maxRequestLength=""4096"" executionTimeout=""90"" enableVersionHeader=""false"" />
    <httpModules>
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" name=""ASPxHttpHandlerModule"" />
    </httpModules>
    <httpHandlers>
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" verb=""GET,POST"" path=""DX.ashx"" validate=""false"" />
      <add verb=""GET,POST"" path=""ASPxUploadProgressHandlerPage.ashx"" type=""DevExpress.Web.ASPxUploadProgressHttpHandler, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
    </httpHandlers>
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test56()
    {
        //Testing the parsing of the 241 system.webServer section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.webServer>
    <validation validateIntegratedModeConfiguration=""false"" />
    <httpProtocol>
      <customHeaders>
        <remove name=""X-AspNet-Version"" />
        <remove name=""X-AspNetMvc-Version"" />
        <remove name=""X-Powered-By"" />
      </customHeaders>
    </httpProtocol>
    <modules>
      <!-- Required by DevExpress -->
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" name=""ASPxHttpHandlerModule"" />
      <!--The format for this section should additionally contain the preCondition attribute.-->
      <add name=""OnBaseContextModule"" type=""Hyland.Server.Diagnostics.OnBaseContextModule, Hyland.Server"" preCondition=""managedHandler"" />
      <!-- The following two modules are required for ADFS -->
      <!--add name=""WSFederationAuthenticationModule"" type=""System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!--add name=""SessionAuthenticationModule"" type=""System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!-- Http Trace -->
    </modules>
    <handlers accessPolicy=""Read, Script"">
      <add type=""DevExpress.Web.ASPxHttpHandlerModule, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" verb=""GET,POST"" path=""DX.ashx"" name=""ASPxHttpHandlerModule"" preCondition=""integratedMode"" />
      <add name=""UnloadHandler.ashx_*"" path=""UnloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.UnloadHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""Login.ashx_*"" path=""Login.ashx"" verb=""*"" type=""Hyland.Controls.Web.Login.LoginHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""CalendarProvider.ashx_*"" path=""CalendarProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.Calendar.CalendarProvider,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Http Trace -->
      <add name=""ASPxUploadProgressHandler"" preCondition=""integratedMode"" verb=""GET,POST"" path=""ASPxUploadProgressHandlerPage.ashx"" type=""DevExpress.Web.ASPxUploadProgressHttpHandler, DevExpress.Web.v17.1, Version=17.1.8.0, Culture=neutral, PublicKeyToken=1bf70af93a3bd45a"" />
    </handlers>
    <!--This setting only applies to IIS7 and greater-->
    <!--The Request Filtering module will reject requests larger than 30MB by default.-->
    <!--If IIS7 or greater is being used and uploads larger than 30MB are expected, maxAllowedContentLength as well as maxRequestLength must be increased.-->
    <!--Uploads that are below maxAllowedContentLength but above maxRequestLength will display a friendly error message to the user.-->
    <!--Uploads that are above maxAllowedContentLength will be rejected and a 404 error will occur.-->
    <!--Therefore, this value (in bytes) should be larger and not equal to maxRequestLength (in kilobytes) or users will not receive a friendly error message.-->
    <!--Uncomment the section below and enter the value as needed.-->
    <!--This setting should be changed in both the web and application server's web.config.-->
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <security>
      <requestFiltering>
        <requestLimits maxAllowedContentLength=""30000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <!--Defines the default documents to use for IIS7 and greater-->
    <!--IIS7 and greater will store the configuration here instead of the metabase used in previous versions of IIS.-->
    <defaultDocument>
      <files>
        <clear />
        <add value=""Viewer.aspx"" />
      </files>
    </defaultDocument>
  </system.webServer>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.webServer", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test57()
    {
        //Testing the parsing of the 241 system.extensions section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""50000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""50000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.web.extensions>
    <scripting>
      <webServices>
        <jsonSerialization maxJsonLength=""50000000"">
        </jsonSerialization>
      </webServices>
    </scripting>
  </system.web.extensions>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.extensions", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test58()
    {
        //Testing the parsing of the 241 system.diagnostics section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<system.diagnostics>
    <switches>
      <!-- 
        This switch controls tracing globally through Hyland.Logging.
        It configures the level of information from Trace that is logged.
        For no information set the value to zero. Set the value to 1, 2, 3, or 4 for
        minimal, normal, detailed, or verbose messages, respectively.
        -->
      <add name=""hylandTracing"" value=""0"" />
    </switches>
  </system.diagnostics>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.diagnostics", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test59()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""username"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""OB-Username"",""Value"":""Tes"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""password"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""OB-Password"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""useTheme"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Dashboard-Theme"",""Value"":""dark"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboard"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Export-Dashboard"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboardItems"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Export-Dashboard-Items"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""acceptHttpParams"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Allow-HTTP-Parameters"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""sessionTraceLevel"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Dashboard-Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableAutoLogin"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""reportPagingLimit"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Report-Paging-Limit"",""Value"":""50"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Dashboard-Viewer-Settings"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""username"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""OB-Username"",""Value"":""Tes"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""password"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""OB-Password"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""useTheme"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Dashboard-Theme"",""Value"":""dark"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboard"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Export-Dashboard"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableExportDashboardItems"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Export-Dashboard-Items"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""acceptHttpParams"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Allow-HTTP-Parameters"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""sessionTraceLevel"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Dashboard-Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""enableAutoLogin"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""reportPagingLimit"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Report-Paging-Limit"",""Value"":""50"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.DashboardViewer"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Dashboard-Viewer-Settings"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test60()
    {
        //Testing the parsing of the 241 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure241WithVersionNumber);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""24.1.6.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""ASP.NET Web""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":{""OutputFormat"":""Minimal""},""RouteType"":""Console"",""Name"":""Diagnostics Console (1)"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":{""SourceName"":""Hyland""},""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":null,""RouteType"":""EventLog"",""Name"":""EventLog"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""2"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":{""URL"":""http://localhost:8989""},""console"":null,""RouteType"":""DurableHttp"",""Name"":""Durable"",""SourceEvents"":""Audit Events"",""EnableIpAddressMasking"":""True"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""ASP.NET Web"" />
    <Routes>
      <Route name=""Diagnostics Console (1)"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Console"" />
        <add key=""OutputFormat"" value=""Minimal"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
      <Route name=""EventLog"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""EventLog"" value=""Hyland"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
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
      <Route name=""Durable"">
        <add key=""minimum-level"" value=""Debug"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""DurableHttp"" value=""http://localhost:8989"" />
        <add key=""DisableIPAddressMasking"" value=""False"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
    </AuditRoutes>
  </Hyland.Logging>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Logging", xmldoc, new DefaultWebApplicationDataStructures());

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }
}