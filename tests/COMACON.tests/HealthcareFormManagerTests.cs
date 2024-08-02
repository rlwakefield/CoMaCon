using COMACON.config;
using COMACONTranslationToHelperUtility;
using FluentAssertions;
using Newtonsoft.Json;
using System.Xml;

namespace COMACON.tests;

public class HealthcareFormManagerTests
{
    private readonly string cleanWebApplicationDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";
    private readonly string cleanWebApplicationDataStructure211WithVersionNumber = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";
    private readonly string cleanWebApplicationDataStructure221WithVersionNumber = @"{""Type"":"""",""Version"":""22.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";
    private readonly string cleanWebApplicationDataStructure231WithVersionNumber = @"{""Type"":"""",""Version"":""23.1.7.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";
    private readonly string cleanWebApplicationDataStructure241WithVersionNumber = @"{""Type"":"""",""Version"":""24.1.7.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

    [Fact]
    public void Test1()
    {
        //Testing to validate that the key is found and the appropriate value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings file=""version.xml"">
    <add key=""allowedDomain"" value=""[APP SERVER]"" />
    <add key=""dmsVirtualRoot"" value=""http://DESKTOP-6I1HC77/HealthcareFormManager"" />
    <add key=""dmsDataSource"" value=""OnBaseTest"" />
    <add key=""AllowViewSource"" value=""false"" />
    <!-- Session timout variables -->
    <add key=""EnableSessionExpiration"" value=""true"" />
    <add key=""PromptOnSessionExpire"" value=""true"" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""default_username"" value=""Test"" />
    <add key=""default_password"" value=""Testing"" />
    <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
    <add key=""enableDefaultLogin"" value=""false"" />
    <add key=""EnableAutoLogin"" value=""false"" />
    <add key=""IdPUrl"" value=""Test1;Test2;Test3;Test4"" />
    <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
    <!--
		The EnableActiveX key has been removed and replaced by WebClientType.
		Valid values are:
							activex | html | selectable
		""activex"" will enable the ActiveX web client.
		""html"" will enable the HTML Only web client.
		""selectable"" will provide users an option upon login to select which
					 client type (ActiveX or HTML Only) to use.
		-->
    <add key=""WebClientType"" value=""activex"" />
    <!--Settings respected by ULC controls-->
    <add key=""enableRowColoring"" value=""true"" />
    <!-- This setting controls if the server will accept only https connections or not. 
				 If you set this to false all incoming requests have to be made over https. 
				 If you set this to true then both http and https connections are accepted. 
				 The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value=""true"" />
    <!-- Preventing caching will impact Viewer performance -->
    <add key=""PreventViewerClientCaching"" value=""true"" />
  </appSettings>";

        string keyName = "WebClientType";
        string defaultValue = "html";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getNonStandardXmlValue(xmldoc.DocumentElement, keyName, defaultValue);

        value.Should().Be("activex");
    }

    [Fact]
    public void Test2()
    {
        //Testing to validate that the key is not found and the default value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings file=""version.xml"">
    <add key=""allowedDomain"" value=""[APP SERVER]"" />
    <add key=""dmsVirtualRoot"" value=""http://DESKTOP-6I1HC77/HealthcareFormManager"" />
    <add key=""dmsDataSource"" value=""OnBaseTest"" />
    <add key=""AllowViewSource"" value=""false"" />
    <!-- Session timout variables -->
    <add key=""EnableSessionExpiration"" value=""true"" />
    <add key=""PromptOnSessionExpire"" value=""true"" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""default_username"" value=""Test"" />
    <add key=""default_password"" value=""Testing"" />
    <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
    <add key=""enableDefaultLogin"" value=""false"" />
    <add key=""EnableAutoLogin"" value=""false"" />
    <add key=""IdPUrl"" value=""Test1;Test2;Test3;Test4"" />
    <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
    <!--
		The EnableActiveX key has been removed and replaced by WebClientType.
		Valid values are:
							activex | html | selectable
		""activex"" will enable the ActiveX web client.
		""html"" will enable the HTML Only web client.
		""selectable"" will provide users an option upon login to select which
					 client type (ActiveX or HTML Only) to use.
		-->
    <add key=""WebClientType"" value=""activex"" />
    <!--Settings respected by ULC controls-->
    <add key=""enableRowColoring"" value=""true"" />
    <!-- This setting controls if the server will accept only https connections or not. 
				 If you set this to false all incoming requests have to be made over https. 
				 If you set this to true then both http and https connections are accepted. 
				 The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value=""true"" />
    <!-- Preventing caching will impact Viewer performance -->
    <add key=""PreventViewerClientCaching"" value=""true"" />
  </appSettings>";

        string keyName = "WebClientType";
        string defaultValue = "html";

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
    <compilation debug=""false"" targetFramework=""4.7.2"">
      <assemblies>
        <add assembly=""netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"" />
      </assemblies>
    </compilation>
    <!--
			SESSION STATE SETTINGS
		-->
    <sessionState mode=""InProc"" stateConnectionString=""tcpip=127.0.0.1:42424"" sqlConnectionString=""data source=127.0.0.1;Trusted_Connection=yes"" cookieless=""false"" cookieSameSite=""Lax"" timeout=""20"" />
    <!--
		For a description of web.config changes see http://go.microsoft.com/fwlink/?LinkId=235367.

		The following attributes can be set on the <httpRuntime> tag.
			<system.Web>
				<httpRuntime targetFramework=""4.7.2"" />
			</system.Web>
		-->
    <!--  HTTPRUNTIME
			By default the maximum size a request may be is 4096 KB.  If files larger than 4096 KB (4 MB)
			need to be uploaded increase the size of the maxRequestLength.  MaxRequestLength value is in KiloBytes.
			By default the maximum number of seconds that a request is allowed to execute is 90 seconds.
			If uploading large documents, the executionTimeout value may need to be increased for proper processing.

			If uploads larger than 30MB are required, maxRequestLength in the application server's web.config must also be increased.
			If uploads larger than 30MB are required and IIS7 or greater is being used, additional changes are required.
			Refer to the maxAllowedContentLength comments for information regarding the changes.
		-->
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <httpRuntime requestValidationMode=""2.0"" maxRequestLength=""2048"" executionTimeout=""90"" enableVersionHeader=""false"" />
    <!--  GLOBALIZATION
					This section sets the globalization settings of the application. 
		-->
    <globalization requestEncoding=""utf-8"" responseEncoding=""utf-8"" />
    <!-- IDENTITY
		By setting impersonate=""true"" the username and password set in the registry will be used
		when the application is started.

		For Healthcare Form Manager, impersonation is (most likely) not needed. The default account of
		NetworkService or ApplicationPoolIdentity should have the proper file permissions and network
		permissions to communicate with the Application Server.

		Use Impersonation on the Application Server for proper NTFS file security.
		When using NT Authentication, LDAP Authentication, Active Directory Authentication, and certain SSOs
		the Application Server will require a user with additional permissions to complete user authentication.

		Use aspnet_setreg.exe to encrypt and set the username and password in the registry.
		aspnet_setreg -k:SOFTWARE\Hyland\AppNet\Identity -u:<domain>\<username> -p:<password>

		NOTE: Each time aspnet_setreg.exe is run, the security on the registry key is restored to the default.
		If using x64 regedit, search with the Wow6432Node in the key path. If the x86 version is used, this is unnecessary.
		Use regedit to update HKLM:SOFTWARE\Hyland\AppNet\Identity\ASPNET_SETREG key to allow read permissions
		by the identity running the Application Pool.
		-->
    <!--
		<identity impersonate=""false""
			userName=""registry:HKLM\SOFTWARE\Wow6432Node\Hyland\AppNet\Identity\ASPNET_SETREG,userName""
			password=""registry:HKLM\SOFTWARE\Wow6432Node\Hyland\AppNet\Identity\ASPNET_SETREG,password""
			/>
		-->
    <!-- Authentication and Authorization sections for ADFS -->
    <!--
		<authentication mode=""None"" />
		<authorization>
			<deny users=""?"" />
		</authorization>
		-->
    <webServices>
      <!-- The web services HTTP POST protocol is disabled by default in .NET 1.1 and above.
				 The following entry enables the protocol and is required by Hyland Services -->
      <protocols>
        <add name=""HttpPost"" />
      </protocols>
      <!-- SOAP Extensions for ADFS -->
      <!--
			<soapExtensionTypes>
				<add type=""Hyland.Authentication.ADFS.CustomADFSAuthSoapExtension, Hyland.Authentication"" />
			</soapExtensionTypes>
			-->
    </webServices>
    <pages validateRequest=""true"" controlRenderingCompatibilityVersion=""4.0"" />
    <httpCookies httpOnlyCookies=""true"" requireSSL=""true"" />
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
        //Testing to validate that the key is found and the appropriate value is returned.
        //This is testing a multiple level select.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<system.webServer>
    <modules runAllManagedModulesForAllRequests=""true"">
      <!--The format for this section should additionally contain the preCondition attribute.-->
      <add name=""OnBaseContextModule"" type=""Hyland.Server.Diagnostics.OnBaseContextModule, Hyland.Server"" preCondition=""managedHandler"" />
      <!-- The following two modules are required for ADFS -->
      <!--add name=""WSFederationAuthenticationModule"" type=""System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!--add name=""SessionAuthenticationModule"" type=""System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
    </modules>
    <validation validateIntegratedModeConfiguration=""false"" />
    <handlers accessPolicy=""Read, Script"">
      <add name=""Login.ashx_*"" path=""Login.ashx"" verb=""*"" type=""Hyland.Controls.Web.Login.LoginHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Windows Manager Dependencies -->
      <add name=""WindowDirector.ashx_*"" path=""WindowDirector.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.WindowDirector,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Viewer Dependencies -->
      <add name=""OptimizedServicePipeline.ashx_*"" path=""OptimizedServicePipeline.ashx"" verb=""*"" type=""Hyland.Applications.Web.OptimizedServicePipelineProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DownloadHandler.ashx_*"" path=""DownloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.DownloadHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FormProc.ashx_*"" path=""FormProc.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.FormProc, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentActionHandler.ashx_*"" path=""DocumentActionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentActionHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""NoteType.ashx_*"" verb=""*"" path=""NoteType.ashx"" type=""Hyland.Applications.Web.Client.Controls.NoteType,Hyland.Applications.Web.Client"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentDataHandler.ashx_*"" path=""DocumentDataHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentDataHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PrintHandler.ashx_*"" path=""PrintHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.PrintHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""NoteHandler.ashx_*"" path=""NoteHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.NoteHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""GVCDocActions.ashx_*"" path=""GVCDocActions.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.GVCDocActions,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PdfHandler.ashx_*"" path=""PdfHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.PdfHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""OleHandler.ashx_*"" path=""OleHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.OleHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""IDOLDocumentHandler.ashx_*"" path=""IDOLDocumentHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.IDOLDocumentHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FileServiceHandler.ashx_*"" path=""FileServiceHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.FileServiceHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""MarkupLanguageHandler.ashx_*"" path=""MarkupLanguageHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.MarkupLanguageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ThumbnailHandler.ashx_GET"" path=""ThumbnailHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ThumbnailHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageHandler.ashx_GET"" path=""ImageHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ImageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UnloadHandler.ashx_*"" path=""UnloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.UnloadHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageProvider.ashx_*"" path=""ImageProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.UtilityControls.ImageViewer.ImageProvider,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ExceptionMessage.ashx_*"" path=""ExceptionMessage.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.ExceptionMessageHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ScriptExceptionHandler.ashx_*"" path=""ScriptExceptionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.ScriptExceptionHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ChartSearchHandler.ashx_*"" path=""ChartSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.Controls.Search.ChartSearchHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UniversalListControlHandler.ashx_*"" path=""UniversalListControlHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.Controls.UniversalListControlHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
    <!--The Request Filtering module will reject requests larger than 30MB by default.-->
    <!--If IIS7 or greater is being used and uploads larger than 30MB are expected, maxAllowedContentLength as well as maxRequestLength must be increased.-->
    <!--Uploads that are below maxAllowedContentLength but above maxRequestLength will display a friendly error message to the user.-->
    <!--Uploads that are above maxAllowedContentLength will be rejected and a 404 error will occur.-->
    <!--Therefore, this value (in bytes) should be larger and not equal to maxRequestLength (in kilobytes) or users will not receive a friendly error message.-->
    <!--Uncomment the section below and enter the value as needed.-->
    <!--This setting should be changed in both the Web Server and Application Server's web.config.-->
    <security>
      <requestFiltering>
        <requestLimits maxAllowedContentLength=""3000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <defaultDocument>
      <files>
        <clear />
        <add value=""Login.aspx"" />
      </files>
    </defaultDocument>
    <httpProtocol>
      <!--The custom headers section is only for IIS7 and greater.  -->
      <customHeaders>
        <remove name=""X-Powered-By"" />
        <!-- IE=11 tells Internet Explorer 11 to render pages in standards mode supported by the browser. -->
        <add name=""X-UA-Compatible"" value=""IE=11"" />
      </customHeaders>
    </httpProtocol>
  </system.webServer>";

        string nodeName = "security/requestFiltering/requestLimits";
        string attributeName = "maxAllowedContentLength";
        string defaultValue = "30000000";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getStandardXmlValue(xmldoc.DocumentElement, nodeName, attributeName, defaultValue);

        value.Should().Be("3000000");
    }

    [Fact]
    public void Test5()
    {
        //Testing to validate that the key is not found and the default value is returned.
        //This is testing with just one level of nesting.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<system.web>
    <compilation debug=""false"" targetFramework=""4.7.2"">
      <assemblies>
        <add assembly=""netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"" />
      </assemblies>
    </compilation>
    <!--
			SESSION STATE SETTINGS
		-->
    <sessionState mode=""InProc"" stateConnectionString=""tcpip=127.0.0.1:42424"" sqlConnectionString=""data source=127.0.0.1;Trusted_Connection=yes"" cookieless=""false"" cookieSameSite=""Lax"" timeout=""20"" />
    <!--
		For a description of web.config changes see http://go.microsoft.com/fwlink/?LinkId=235367.

		The following attributes can be set on the <httpRuntime> tag.
			<system.Web>
				<httpRuntime targetFramework=""4.7.2"" />
			</system.Web>
		-->
    <!--  HTTPRUNTIME
			By default the maximum size a request may be is 4096 KB.  If files larger than 4096 KB (4 MB)
			need to be uploaded increase the size of the maxRequestLength.  MaxRequestLength value is in KiloBytes.
			By default the maximum number of seconds that a request is allowed to execute is 90 seconds.
			If uploading large documents, the executionTimeout value may need to be increased for proper processing.

			If uploads larger than 30MB are required, maxRequestLength in the application server's web.config must also be increased.
			If uploads larger than 30MB are required and IIS7 or greater is being used, additional changes are required.
			Refer to the maxAllowedContentLength comments for information regarding the changes.
		-->
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <httpRuntime requestValidationMode=""2.0"" maxRequestLength=""2048"" executionTimeout=""90"" enableVersionHeader=""false"" />
    <!--  GLOBALIZATION
					This section sets the globalization settings of the application. 
		-->
    <globalization requestEncoding=""utf-8"" responseEncoding=""utf-8"" />
    <!-- IDENTITY
		By setting impersonate=""true"" the username and password set in the registry will be used
		when the application is started.

		For Healthcare Form Manager, impersonation is (most likely) not needed. The default account of
		NetworkService or ApplicationPoolIdentity should have the proper file permissions and network
		permissions to communicate with the Application Server.

		Use Impersonation on the Application Server for proper NTFS file security.
		When using NT Authentication, LDAP Authentication, Active Directory Authentication, and certain SSOs
		the Application Server will require a user with additional permissions to complete user authentication.

		Use aspnet_setreg.exe to encrypt and set the username and password in the registry.
		aspnet_setreg -k:SOFTWARE\Hyland\AppNet\Identity -u:<domain>\<username> -p:<password>

		NOTE: Each time aspnet_setreg.exe is run, the security on the registry key is restored to the default.
		If using x64 regedit, search with the Wow6432Node in the key path. If the x86 version is used, this is unnecessary.
		Use regedit to update HKLM:SOFTWARE\Hyland\AppNet\Identity\ASPNET_SETREG key to allow read permissions
		by the identity running the Application Pool.
		-->
    <!--
		<identity impersonate=""false""
			userName=""registry:HKLM\SOFTWARE\Wow6432Node\Hyland\AppNet\Identity\ASPNET_SETREG,userName""
			password=""registry:HKLM\SOFTWARE\Wow6432Node\Hyland\AppNet\Identity\ASPNET_SETREG,password""
			/>
		-->
    <!-- Authentication and Authorization sections for ADFS -->
    <!--
		<authentication mode=""None"" />
		<authorization>
			<deny users=""?"" />
		</authorization>
		-->
    <webServices>
      <!-- The web services HTTP POST protocol is disabled by default in .NET 1.1 and above.
				 The following entry enables the protocol and is required by Hyland Services -->
      <protocols>
        <add name=""HttpPost"" />
      </protocols>
      <!-- SOAP Extensions for ADFS -->
      <!--
			<soapExtensionTypes>
				<add type=""Hyland.Authentication.ADFS.CustomADFSAuthSoapExtension, Hyland.Authentication"" />
			</soapExtensionTypes>
			-->
    </webServices>
    <pages validateRequest=""true"" controlRenderingCompatibilityVersion=""4.0"" />
    <httpCookies httpOnlyCookies=""true"" requireSSL=""true"" />
  </system.web>";

        string nodeName = "httpRuntime";
        string attributeName = "MaxRequestLength";
        string defaultValue = "4096";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getStandardXmlValue(xmldoc.DocumentElement, nodeName, attributeName, defaultValue);

        value.Should().Be(defaultValue);
    }

    [Fact]
    public void Test6()
    {
        //Testing the Prebuilding of the 211 system.diagnostics section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test7()
    {
        //Testing the Prebuilding of the 211 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""allowedDomain"",""type"":""2"",""htmlIdName"":""Allowed-Domain"",""Value"":""[APP SERVER]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://localhost/HealthcareFormManager"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""WebClientType"",""type"":""2"",""htmlIdName"":""Web-Client-Type"",""Value"":""html"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","allowedDomain","2","Allowed-Domain","[APP SERVER]","","",""},
            {"appSettings","add","dmsVirtualRoot","2","Virtual-Directory","https://localhost/HealthcareFormManager","","",""},
            {"appSettings","add","dmsDataSource","2","Data-Source","[DATASOURCE]","","",""},
            {"appSettings","add","AllowViewSource","1","Allow-View-Source","false","","",""},
            {"appSettings","add","EnableSessionExpiration","1","Enable-Session-Expiration","true","","",""},
            {"appSettings","add","PromptOnSessionExpire","1","Prompt-On-Session-Expire","true","","",""},
            {"appSettings","add","webtheme","2","Web-Theme","XP","","",""},
            {"appSettings","add","default_username","2","Default-Username","","","",""},
            {"appSettings","add","default_password","2","Default-Password","","","",""},
            {"appSettings","add","enableDefaultLogin","1","Default-Login","false","","",""},
            {"appSettings","add","EnableAutoLogin","1","Autologin","false","","",""},
            {"appSettings","add","IdPUrl","2","","","","",""},
            {"appSettings","add","forceSSOAutoLoginOverDomain","1","Force-OnBase-Authentication","false","","",""},
            {"appSettings","add","WebClientType","2","Web-Client-Type","html","","",""},
            {"appSettings","add","enableRowColoring","1","Row-Coloring","true","","",""},
            {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
            {"appSettings","add","PreventViewerClientCaching","1","Prevent-Viewer-Client-Caching","true","","",""}
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

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""timeout"",""type"":""2"",""htmlIdName"":""Session-Timeout"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""cookieSameSite"",""type"":""2"",""htmlIdName"":""Samesite-Cookie-Policy"",""Value"":""Lax"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","",""},
            {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","",""},
            {"system.web","sessionState","timeout","2","Session-Timeout","20","","",""},
            {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test9()
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
    public void Test10()
    {
        //Testing the parsing of the 211 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""allowedDomain"",""type"":""2"",""htmlIdName"":""Allowed-Domain"",""Value"":""[APP SERVER]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://localhost/HealthcareFormManager"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""WebClientType"",""type"":""2"",""htmlIdName"":""Web-Client-Type"",""Value"":""html"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""allowedDomain"",""type"":""2"",""htmlIdName"":""Allowed-Domain"",""Value"":""[APP SERVER]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""http://DESKTOP-6I1HC77/HealthcareFormManager"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""OnBaseTest"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":""Testing"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":""Test1;Test2;Test3;Test4"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""WebClientType"",""type"":""2"",""htmlIdName"":""Web-Client-Type"",""Value"":""html"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":{""ServerLocation"":""Test1"",""Tenant"":""Test2"",""Client"":""Test3"",""Secret"":""Test4""},""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<appSettings file=""version.xml"">
    <add key=""allowedDomain"" value=""[APP SERVER]"" />
    <add key=""dmsVirtualRoot"" value=""http://DESKTOP-6I1HC77/HealthcareFormManager"" />
    <add key=""dmsDataSource"" value=""OnBaseTest"" />
    <add key=""AllowViewSource"" value=""false"" />
    <!-- Session timout variables -->
    <add key=""EnableSessionExpiration"" value=""true"" />
    <add key=""PromptOnSessionExpire"" value=""true"" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""default_username"" value=""Test"" />
    <add key=""default_password"" value=""Testing"" />
    <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
    <add key=""enableDefaultLogin"" value=""false"" />
    <add key=""EnableAutoLogin"" value=""false"" />
    <add key=""IdPUrl"" value=""Test1;Test2;Test3;Test4"" />
    <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
    <!--
		The EnableActiveX key has been removed and replaced by WebClientType.
		Valid values are:
							activex | html | selectable
		""activex"" will enable the ActiveX web client.
		""html"" will enable the HTML Only web client.
		""selectable"" will provide users an option upon login to select which
					 client type (ActiveX or HTML Only) to use.
		-->
    <add key=""WebClientType"" value=""html"" />
    <!--Settings respected by ULC controls-->
    <add key=""enableRowColoring"" value=""true"" />
    <!-- This setting controls if the server will accept only https connections or not. 
				 If you set this to false all incoming requests have to be made over https. 
				 If you set this to true then both http and https connections are accepted. 
				 The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value=""true"" />
    <!-- Preventing caching will impact Viewer performance -->
    <add key=""PreventViewerClientCaching"" value=""true"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test11()
    {
        //Testing the parsing of the 211 system.diagnostics section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

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
    public void Test12()
    {
        //Testing the parsing of the 211 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""timeout"",""type"":""2"",""htmlIdName"":""Session-Timeout"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""cookieSameSite"",""type"":""2"",""htmlIdName"":""Samesite-Cookie-Policy"",""Value"":""Lax"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""timeout"",""type"":""2"",""htmlIdName"":""Session-Timeout"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""cookieSameSite"",""type"":""2"",""htmlIdName"":""Samesite-Cookie-Policy"",""Value"":""Lax"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.web>
    <compilation debug=""false"" targetFramework=""4.7.2"">
      <assemblies>
        <add assembly=""netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"" />
      </assemblies>
    </compilation>
    <!--
			SESSION STATE SETTINGS
		-->
    <sessionState mode=""InProc"" stateConnectionString=""tcpip=127.0.0.1:42424"" sqlConnectionString=""data source=127.0.0.1;Trusted_Connection=yes"" cookieless=""false"" cookieSameSite=""Lax"" timeout=""20"" />
    <!--
		For a description of web.config changes see http://go.microsoft.com/fwlink/?LinkId=235367.

		The following attributes can be set on the <httpRuntime> tag.
			<system.Web>
				<httpRuntime targetFramework=""4.7.2"" />
			</system.Web>
		-->
    <!--  HTTPRUNTIME
			By default the maximum size a request may be is 4096 KB.  If files larger than 4096 KB (4 MB)
			need to be uploaded increase the size of the maxRequestLength.  MaxRequestLength value is in KiloBytes.
			By default the maximum number of seconds that a request is allowed to execute is 90 seconds.
			If uploading large documents, the executionTimeout value may need to be increased for proper processing.

			If uploads larger than 30MB are required, maxRequestLength in the application server's web.config must also be increased.
			If uploads larger than 30MB are required and IIS7 or greater is being used, additional changes are required.
			Refer to the maxAllowedContentLength comments for information regarding the changes.
		-->
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <httpRuntime requestValidationMode=""2.0"" maxRequestLength=""4096"" executionTimeout=""90"" enableVersionHeader=""false"" />
    <!--  GLOBALIZATION
					This section sets the globalization settings of the application. 
		-->
    <globalization requestEncoding=""utf-8"" responseEncoding=""utf-8"" />
    <!-- IDENTITY
		By setting impersonate=""true"" the username and password set in the registry will be used
		when the application is started.

		For Healthcare Form Manager, impersonation is (most likely) not needed. The default account of
		NetworkService or ApplicationPoolIdentity should have the proper file permissions and network
		permissions to communicate with the Application Server.

		Use Impersonation on the Application Server for proper NTFS file security.
		When using NT Authentication, LDAP Authentication, Active Directory Authentication, and certain SSOs
		the Application Server will require a user with additional permissions to complete user authentication.

		Use aspnet_setreg.exe to encrypt and set the username and password in the registry.
		aspnet_setreg -k:SOFTWARE\Hyland\AppNet\Identity -u:<domain>\<username> -p:<password>

		NOTE: Each time aspnet_setreg.exe is run, the security on the registry key is restored to the default.
		If using x64 regedit, search with the Wow6432Node in the key path. If the x86 version is used, this is unnecessary.
		Use regedit to update HKLM:SOFTWARE\Hyland\AppNet\Identity\ASPNET_SETREG key to allow read permissions
		by the identity running the Application Pool.
		-->
    <!--
		<identity impersonate=""false""
			userName=""registry:HKLM\SOFTWARE\Wow6432Node\Hyland\AppNet\Identity\ASPNET_SETREG,userName""
			password=""registry:HKLM\SOFTWARE\Wow6432Node\Hyland\AppNet\Identity\ASPNET_SETREG,password""
			/>
		-->
    <!-- Authentication and Authorization sections for ADFS -->
    <!--
		<authentication mode=""None"" />
		<authorization>
			<deny users=""?"" />
		</authorization>
		-->
    <webServices>
      <!-- The web services HTTP POST protocol is disabled by default in .NET 1.1 and above.
				 The following entry enables the protocol and is required by Hyland Services -->
      <protocols>
        <add name=""HttpPost"" />
      </protocols>
      <!-- SOAP Extensions for ADFS -->
      <!--
			<soapExtensionTypes>
				<add type=""Hyland.Authentication.ADFS.CustomADFSAuthSoapExtension, Hyland.Authentication"" />
			</soapExtensionTypes>
			-->
    </webServices>
    <pages validateRequest=""true"" controlRenderingCompatibilityVersion=""4.0"" />
    <httpCookies httpOnlyCookies=""true"" requireSSL=""true"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test13()
    {
        //Testing the parsing of the 211 system.webServer section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.webServer>
    <modules runAllManagedModulesForAllRequests=""true"">
      <!--The format for this section should additionally contain the preCondition attribute.-->
      <add name=""OnBaseContextModule"" type=""Hyland.Server.Diagnostics.OnBaseContextModule, Hyland.Server"" preCondition=""managedHandler"" />
      <!-- The following two modules are required for ADFS -->
      <!--add name=""WSFederationAuthenticationModule"" type=""System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!--add name=""SessionAuthenticationModule"" type=""System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
    </modules>
    <validation validateIntegratedModeConfiguration=""false"" />
    <handlers accessPolicy=""Read, Script"">
      <add name=""Login.ashx_*"" path=""Login.ashx"" verb=""*"" type=""Hyland.Controls.Web.Login.LoginHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Windows Manager Dependencies -->
      <add name=""WindowDirector.ashx_*"" path=""WindowDirector.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.WindowDirector,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Viewer Dependencies -->
      <add name=""OptimizedServicePipeline.ashx_*"" path=""OptimizedServicePipeline.ashx"" verb=""*"" type=""Hyland.Applications.Web.OptimizedServicePipelineProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DownloadHandler.ashx_*"" path=""DownloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.DownloadHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FormProc.ashx_*"" path=""FormProc.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.FormProc, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentActionHandler.ashx_*"" path=""DocumentActionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentActionHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""NoteType.ashx_*"" verb=""*"" path=""NoteType.ashx"" type=""Hyland.Applications.Web.Client.Controls.NoteType,Hyland.Applications.Web.Client"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentDataHandler.ashx_*"" path=""DocumentDataHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentDataHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PrintHandler.ashx_*"" path=""PrintHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.PrintHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""NoteHandler.ashx_*"" path=""NoteHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.NoteHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""GVCDocActions.ashx_*"" path=""GVCDocActions.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.GVCDocActions,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PdfHandler.ashx_*"" path=""PdfHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.PdfHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""OleHandler.ashx_*"" path=""OleHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.OleHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""IDOLDocumentHandler.ashx_*"" path=""IDOLDocumentHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.IDOLDocumentHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FileServiceHandler.ashx_*"" path=""FileServiceHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.FileServiceHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""MarkupLanguageHandler.ashx_*"" path=""MarkupLanguageHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.MarkupLanguageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ThumbnailHandler.ashx_GET"" path=""ThumbnailHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ThumbnailHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageHandler.ashx_GET"" path=""ImageHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ImageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UnloadHandler.ashx_*"" path=""UnloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.UnloadHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageProvider.ashx_*"" path=""ImageProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.UtilityControls.ImageViewer.ImageProvider,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ExceptionMessage.ashx_*"" path=""ExceptionMessage.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.ExceptionMessageHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ScriptExceptionHandler.ashx_*"" path=""ScriptExceptionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.ScriptExceptionHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ChartSearchHandler.ashx_*"" path=""ChartSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.Controls.Search.ChartSearchHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UniversalListControlHandler.ashx_*"" path=""UniversalListControlHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.Controls.UniversalListControlHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
    <!--The Request Filtering module will reject requests larger than 30MB by default.-->
    <!--If IIS7 or greater is being used and uploads larger than 30MB are expected, maxAllowedContentLength as well as maxRequestLength must be increased.-->
    <!--Uploads that are below maxAllowedContentLength but above maxRequestLength will display a friendly error message to the user.-->
    <!--Uploads that are above maxAllowedContentLength will be rejected and a 404 error will occur.-->
    <!--Therefore, this value (in bytes) should be larger and not equal to maxRequestLength (in kilobytes) or users will not receive a friendly error message.-->
    <!--Uncomment the section below and enter the value as needed.-->
    <!--This setting should be changed in both the Web Server and Application Server's web.config.-->
    <security>
      <requestFiltering>
        <requestLimits maxAllowedContentLength=""30000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <defaultDocument>
      <files>
        <clear />
        <add value=""Login.aspx"" />
      </files>
    </defaultDocument>
    <httpProtocol>
      <!--The custom headers section is only for IIS7 and greater.  -->
      <customHeaders>
        <remove name=""X-Powered-By"" />
        <!-- IE=11 tells Internet Explorer 11 to render pages in standards mode supported by the browser. -->
        <add name=""X-UA-Compatible"" value=""IE=11"" />
      </customHeaders>
    </httpProtocol>
  </system.webServer>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.webServer", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test14()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Validate-Against-Checksum"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Checksum-Key"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Validate-Against-Checksum"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Checksum-Key"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test15()
    {
        //Testing the parsing of the 211 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure211WithVersionNumber);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""Hyland Application Server""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""Hyland Application Server"" />
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
    <AuditRoutes />
  </Hyland.Logging>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Logging", xmldoc, new DefaultWebApplicationDataStructures());

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test16()
    {
        //Testing the Prebuilding of the 221 system.diagnostics section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test17()
    {
        //Testing the Prebuilding of the 221 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""allowedDomain"",""type"":""2"",""htmlIdName"":""Allowed-Domain"",""Value"":""[APP SERVER]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://localhost/HealthcareFormManager"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""WebClientType"",""type"":""2"",""htmlIdName"":""Web-Client-Type"",""Value"":""html"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","allowedDomain","2","Allowed-Domain","[APP SERVER]","","",""},
            {"appSettings","add","dmsVirtualRoot","2","Virtual-Directory","https://localhost/HealthcareFormManager","","",""},
            {"appSettings","add","dmsDataSource","2","Data-Source","[DATASOURCE]","","",""},
            {"appSettings","add","AllowViewSource","1","Allow-View-Source","false","","",""},
            {"appSettings","add","EnableSessionExpiration","1","Enable-Session-Expiration","true","","",""},
            {"appSettings","add","PromptOnSessionExpire","1","Prompt-On-Session-Expire","true","","",""},
            {"appSettings","add","webtheme","2","Web-Theme","XP","","",""},
            {"appSettings","add","default_username","2","Default-Username","","","",""},
            {"appSettings","add","default_password","2","Default-Password","","","",""},
            {"appSettings","add","enableDefaultLogin","1","Default-Login","false","","",""},
            {"appSettings","add","EnableAutoLogin","1","Autologin","false","","",""},
            {"appSettings","add","IdPUrl","2","","","","",""},
            {"appSettings","add","forceSSOAutoLoginOverDomain","1","Force-OnBase-Authentication","false","","",""},
            {"appSettings","add","WebClientType","2","Web-Client-Type","html","","",""},
            {"appSettings","add","enableRowColoring","1","Row-Coloring","true","","",""},
            {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
            {"appSettings","add","PreventViewerClientCaching","1","Prevent-Viewer-Client-Caching","true","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test18()
    {
        //Testing the Prebuilding of the 221 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""timeout"",""type"":""2"",""htmlIdName"":""Session-Timeout"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""cookieSameSite"",""type"":""2"",""htmlIdName"":""Samesite-Cookie-Policy"",""Value"":""Lax"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","",""},
            {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","",""},
            {"system.web","sessionState","timeout","2","Session-Timeout","20","","",""},
            {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test19()
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
    public void Test20()
    {
        //Testing the parsing of the 221 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""allowedDomain"",""type"":""2"",""htmlIdName"":""Allowed-Domain"",""Value"":""[APP SERVER]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://localhost/HealthcareFormManager"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""WebClientType"",""type"":""2"",""htmlIdName"":""Web-Client-Type"",""Value"":""html"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""allowedDomain"",""type"":""2"",""htmlIdName"":""Allowed-Domain"",""Value"":""[APP SERVER]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""http://DESKTOP-6I1HC77/HealthcareFormManager"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""OnBaseTest"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":""Testing"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":""Test1;Test2;Test3;Test4"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""WebClientType"",""type"":""2"",""htmlIdName"":""Web-Client-Type"",""Value"":""html"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":{""ServerLocation"":""Test1"",""Tenant"":""Test2"",""Client"":""Test3"",""Secret"":""Test4""},""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<appSettings file=""version.xml"">
    <add key=""allowedDomain"" value=""[APP SERVER]"" />
    <add key=""dmsVirtualRoot"" value=""http://DESKTOP-6I1HC77/HealthcareFormManager"" />
    <add key=""dmsDataSource"" value=""OnBaseTest"" />
    <add key=""AllowViewSource"" value=""false"" />
    <!-- Session timout variables -->
    <add key=""EnableSessionExpiration"" value=""true"" />
    <add key=""PromptOnSessionExpire"" value=""true"" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""default_username"" value=""Test"" />
    <add key=""default_password"" value=""Testing"" />
    <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
    <add key=""enableDefaultLogin"" value=""false"" />
    <add key=""EnableAutoLogin"" value=""false"" />
    <add key=""IdPUrl"" value=""Test1;Test2;Test3;Test4"" />
    <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
    <!--
		The EnableActiveX key has been removed and replaced by WebClientType.
		Valid values are:
							activex | html | selectable
		""activex"" will enable the ActiveX web client.
		""html"" will enable the HTML Only web client.
		""selectable"" will provide users an option upon login to select which
					 client type (ActiveX or HTML Only) to use.
		-->
    <add key=""WebClientType"" value=""html"" />
    <!--Settings respected by ULC controls-->
    <add key=""enableRowColoring"" value=""true"" />
    <!-- This setting controls if the server will accept only https connections or not. 
				 If you set this to false all incoming requests have to be made over https. 
				 If you set this to true then both http and https connections are accepted. 
				 The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value=""true"" />
    <!-- Preventing caching will impact Viewer performance -->
    <add key=""PreventViewerClientCaching"" value=""true"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test21()
    {
        //Testing the parsing of the 221 system.diagnostics section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

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
    public void Test22()
    {
        //Testing the parsing of the 221 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""timeout"",""type"":""2"",""htmlIdName"":""Session-Timeout"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""cookieSameSite"",""type"":""2"",""htmlIdName"":""Samesite-Cookie-Policy"",""Value"":""Lax"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""timeout"",""type"":""2"",""htmlIdName"":""Session-Timeout"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""cookieSameSite"",""type"":""2"",""htmlIdName"":""Samesite-Cookie-Policy"",""Value"":""Lax"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.web>
    <compilation debug=""false"" targetFramework=""4.7.2"">
      <assemblies>
        <add assembly=""netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"" />
      </assemblies>
    </compilation>
    <!--
			SESSION STATE SETTINGS
		-->
    <sessionState mode=""InProc"" stateConnectionString=""tcpip=127.0.0.1:42424"" sqlConnectionString=""data source=127.0.0.1;Trusted_Connection=yes"" cookieless=""false"" cookieSameSite=""Lax"" timeout=""20"" />
    <!--
		For a description of web.config changes see http://go.microsoft.com/fwlink/?LinkId=235367.

		The following attributes can be set on the <httpRuntime> tag.
			<system.Web>
				<httpRuntime targetFramework=""4.7.2"" />
			</system.Web>
		-->
    <!--  HTTPRUNTIME
			By default the maximum size a request may be is 4096 KB.  If files larger than 4096 KB (4 MB)
			need to be uploaded increase the size of the maxRequestLength.  MaxRequestLength value is in KiloBytes.
			By default the maximum number of seconds that a request is allowed to execute is 90 seconds.
			If uploading large documents, the executionTimeout value may need to be increased for proper processing.

			If uploads larger than 30MB are required, maxRequestLength in the application server's web.config must also be increased.
			If uploads larger than 30MB are required and IIS7 or greater is being used, additional changes are required.
			Refer to the maxAllowedContentLength comments for information regarding the changes.
		-->
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <httpRuntime requestValidationMode=""2.0"" maxRequestLength=""4096"" executionTimeout=""90"" enableVersionHeader=""false"" />
    <!--  GLOBALIZATION
					This section sets the globalization settings of the application. 
		-->
    <globalization requestEncoding=""utf-8"" responseEncoding=""utf-8"" />
    <!-- IDENTITY
		By setting impersonate=""true"" the username and password set in the registry will be used
		when the application is started.

		For Healthcare Form Manager, impersonation is (most likely) not needed. The default account of
		NetworkService or ApplicationPoolIdentity should have the proper file permissions and network
		permissions to communicate with the Application Server.

		Use Impersonation on the Application Server for proper NTFS file security.
		When using NT Authentication, LDAP Authentication, Active Directory Authentication, and certain SSOs
		the Application Server will require a user with additional permissions to complete user authentication.

		Use aspnet_setreg.exe to encrypt and set the username and password in the registry.
		aspnet_setreg -k:SOFTWARE\Hyland\AppNet\Identity -u:<domain>\<username> -p:<password>

		NOTE: Each time aspnet_setreg.exe is run, the security on the registry key is restored to the default.
		If using x64 regedit, search with the Wow6432Node in the key path. If the x86 version is used, this is unnecessary.
		Use regedit to update HKLM:SOFTWARE\Hyland\AppNet\Identity\ASPNET_SETREG key to allow read permissions
		by the identity running the Application Pool.
		-->
    <!--
		<identity impersonate=""false""
			userName=""registry:HKLM\SOFTWARE\Wow6432Node\Hyland\AppNet\Identity\ASPNET_SETREG,userName""
			password=""registry:HKLM\SOFTWARE\Wow6432Node\Hyland\AppNet\Identity\ASPNET_SETREG,password""
			/>
		-->
    <!-- Authentication and Authorization sections for ADFS -->
    <!--
		<authentication mode=""None"" />
		<authorization>
			<deny users=""?"" />
		</authorization>
		-->
    <webServices>
      <!-- The web services HTTP POST protocol is disabled by default in .NET 1.1 and above.
				 The following entry enables the protocol and is required by Hyland Services -->
      <protocols>
        <add name=""HttpPost"" />
      </protocols>
      <!-- SOAP Extensions for ADFS -->
      <!--
			<soapExtensionTypes>
				<add type=""Hyland.Authentication.ADFS.CustomADFSAuthSoapExtension, Hyland.Authentication"" />
			</soapExtensionTypes>
			-->
    </webServices>
    <pages validateRequest=""true"" controlRenderingCompatibilityVersion=""4.0"" />
    <httpCookies httpOnlyCookies=""true"" requireSSL=""true"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test23()
    {
        //Testing the parsing of the 221 system.webServer section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.webServer>
    <modules runAllManagedModulesForAllRequests=""true"">
      <!--The format for this section should additionally contain the preCondition attribute.-->
      <add name=""OnBaseContextModule"" type=""Hyland.Server.Diagnostics.OnBaseContextModule, Hyland.Server"" preCondition=""managedHandler"" />
      <!-- The following two modules are required for ADFS -->
      <!--add name=""WSFederationAuthenticationModule"" type=""System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!--add name=""SessionAuthenticationModule"" type=""System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
    </modules>
    <validation validateIntegratedModeConfiguration=""false"" />
    <handlers accessPolicy=""Read, Script"">
      <add name=""Login.ashx_*"" path=""Login.ashx"" verb=""*"" type=""Hyland.Controls.Web.Login.LoginHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Windows Manager Dependencies -->
      <add name=""WindowDirector.ashx_*"" path=""WindowDirector.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.WindowDirector,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Viewer Dependencies -->
      <add name=""OptimizedServicePipeline.ashx_*"" path=""OptimizedServicePipeline.ashx"" verb=""*"" type=""Hyland.Applications.Web.OptimizedServicePipelineProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DownloadHandler.ashx_*"" path=""DownloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.DownloadHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FormProc.ashx_*"" path=""FormProc.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.FormProc, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentActionHandler.ashx_*"" path=""DocumentActionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentActionHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""NoteType.ashx_*"" verb=""*"" path=""NoteType.ashx"" type=""Hyland.Applications.Web.Client.Controls.NoteType,Hyland.Applications.Web.Client"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentDataHandler.ashx_*"" path=""DocumentDataHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentDataHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PrintHandler.ashx_*"" path=""PrintHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.PrintHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""NoteHandler.ashx_*"" path=""NoteHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.NoteHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""GVCDocActions.ashx_*"" path=""GVCDocActions.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.GVCDocActions,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PdfHandler.ashx_*"" path=""PdfHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.PdfHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""OleHandler.ashx_*"" path=""OleHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.OleHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""IDOLDocumentHandler.ashx_*"" path=""IDOLDocumentHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.IDOLDocumentHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FileServiceHandler.ashx_*"" path=""FileServiceHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.FileServiceHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""MarkupLanguageHandler.ashx_*"" path=""MarkupLanguageHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.MarkupLanguageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ThumbnailHandler.ashx_GET"" path=""ThumbnailHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ThumbnailHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageHandler.ashx_GET"" path=""ImageHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ImageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UnloadHandler.ashx_*"" path=""UnloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.UnloadHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageProvider.ashx_*"" path=""ImageProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.UtilityControls.ImageViewer.ImageProvider,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ExceptionMessage.ashx_*"" path=""ExceptionMessage.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.ExceptionMessageHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ScriptExceptionHandler.ashx_*"" path=""ScriptExceptionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.ScriptExceptionHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ChartSearchHandler.ashx_*"" path=""ChartSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.Controls.Search.ChartSearchHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UniversalListControlHandler.ashx_*"" path=""UniversalListControlHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.Controls.UniversalListControlHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
    <!--The Request Filtering module will reject requests larger than 30MB by default.-->
    <!--If IIS7 or greater is being used and uploads larger than 30MB are expected, maxAllowedContentLength as well as maxRequestLength must be increased.-->
    <!--Uploads that are below maxAllowedContentLength but above maxRequestLength will display a friendly error message to the user.-->
    <!--Uploads that are above maxAllowedContentLength will be rejected and a 404 error will occur.-->
    <!--Therefore, this value (in bytes) should be larger and not equal to maxRequestLength (in kilobytes) or users will not receive a friendly error message.-->
    <!--Uncomment the section below and enter the value as needed.-->
    <!--This setting should be changed in both the Web Server and Application Server's web.config.-->
    <security>
      <requestFiltering>
        <requestLimits maxAllowedContentLength=""30000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <defaultDocument>
      <files>
        <clear />
        <add value=""Login.aspx"" />
      </files>
    </defaultDocument>
    <httpProtocol>
      <!--The custom headers section is only for IIS7 and greater.  -->
      <customHeaders>
        <remove name=""X-Powered-By"" />
        <!-- IE=11 tells Internet Explorer 11 to render pages in standards mode supported by the browser. -->
        <add name=""X-UA-Compatible"" value=""IE=11"" />
      </customHeaders>
    </httpProtocol>
  </system.webServer>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.webServer", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test24()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Validate-Against-Checksum"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Checksum-Key"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Validate-Against-Checksum"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Checksum-Key"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test25()
    {
        //Testing the parsing of the 221 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure221WithVersionNumber);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""22.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""Hyland Application Server""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""Hyland Application Server"" />
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
    <AuditRoutes />
  </Hyland.Logging>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Logging", xmldoc, new DefaultWebApplicationDataStructures());

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test26()
    {
        //Testing the Prebuilding of the 231 system.diagnostics section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test27()
    {
        //Testing the Prebuilding of the 231 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""allowedDomain"",""type"":""2"",""htmlIdName"":""Allowed-Domain"",""Value"":""[APP SERVER]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://localhost/HealthcareFormManager"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""WebClientType"",""type"":""2"",""htmlIdName"":""Web-Client-Type"",""Value"":""html"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","allowedDomain","2","Allowed-Domain","[APP SERVER]","","",""},
            {"appSettings","add","dmsVirtualRoot","2","Virtual-Directory","https://localhost/HealthcareFormManager","","",""},
            {"appSettings","add","dmsDataSource","2","Data-Source","[DATASOURCE]","","",""},
            {"appSettings","add","AllowViewSource","1","Allow-View-Source","false","","",""},
            {"appSettings","add","EnableSessionExpiration","1","Enable-Session-Expiration","true","","",""},
            {"appSettings","add","PromptOnSessionExpire","1","Prompt-On-Session-Expire","true","","",""},
            {"appSettings","add","webtheme","2","Web-Theme","XP","","",""},
            {"appSettings","add","default_username","2","Default-Username","","","",""},
            {"appSettings","add","default_password","2","Default-Password","","","",""},
            {"appSettings","add","enableDefaultLogin","1","Default-Login","false","","",""},
            {"appSettings","add","EnableAutoLogin","1","Autologin","false","","",""},
            {"appSettings","add","IdPUrl","2","","","","",""},
            {"appSettings","add","forceSSOAutoLoginOverDomain","1","Force-OnBase-Authentication","false","","",""},
            {"appSettings","add","WebClientType","2","Web-Client-Type","html","","",""},
            {"appSettings","add","enableRowColoring","1","Row-Coloring","true","","",""},
            {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
            {"appSettings","add","PreventViewerClientCaching","1","Prevent-Viewer-Client-Caching","true","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test28()
    {
        //Testing the Prebuilding of the 231 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""timeout"",""type"":""2"",""htmlIdName"":""Session-Timeout"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""cookieSameSite"",""type"":""2"",""htmlIdName"":""Samesite-Cookie-Policy"",""Value"":""Lax"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","",""},
            {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","",""},
            {"system.web","sessionState","timeout","2","Session-Timeout","20","","",""},
            {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test29()
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
    public void Test30()
    {
        //Testing the parsing of the 231 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""allowedDomain"",""type"":""2"",""htmlIdName"":""Allowed-Domain"",""Value"":""[APP SERVER]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://localhost/HealthcareFormManager"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""WebClientType"",""type"":""2"",""htmlIdName"":""Web-Client-Type"",""Value"":""html"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""allowedDomain"",""type"":""2"",""htmlIdName"":""Allowed-Domain"",""Value"":""[APP SERVER]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""http://DESKTOP-6I1HC77/HealthcareFormManager"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""OnBaseTest"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":""Testing"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":""Test1;Test2;Test3;Test4"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""WebClientType"",""type"":""2"",""htmlIdName"":""Web-Client-Type"",""Value"":""html"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":{""ServerLocation"":""Test1"",""Tenant"":""Test2"",""Client"":""Test3"",""Secret"":""Test4""},""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<appSettings file=""version.xml"">
    <add key=""allowedDomain"" value=""[APP SERVER]"" />
    <add key=""dmsVirtualRoot"" value=""http://DESKTOP-6I1HC77/HealthcareFormManager"" />
    <add key=""dmsDataSource"" value=""OnBaseTest"" />
    <add key=""AllowViewSource"" value=""false"" />
    <!-- Session timout variables -->
    <add key=""EnableSessionExpiration"" value=""true"" />
    <add key=""PromptOnSessionExpire"" value=""true"" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""default_username"" value=""Test"" />
    <add key=""default_password"" value=""Testing"" />
    <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
    <add key=""enableDefaultLogin"" value=""false"" />
    <add key=""EnableAutoLogin"" value=""false"" />
    <add key=""IdPUrl"" value=""Test1;Test2;Test3;Test4"" />
    <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
    <!--
		The EnableActiveX key has been removed and replaced by WebClientType.
		Valid values are:
							activex | html | selectable
		""activex"" will enable the ActiveX web client.
		""html"" will enable the HTML Only web client.
		""selectable"" will provide users an option upon login to select which
					 client type (ActiveX or HTML Only) to use.
		-->
    <add key=""WebClientType"" value=""html"" />
    <!--Settings respected by ULC controls-->
    <add key=""enableRowColoring"" value=""true"" />
    <!-- This setting controls if the server will accept only https connections or not. 
				 If you set this to false all incoming requests have to be made over https. 
				 If you set this to true then both http and https connections are accepted. 
				 The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value=""true"" />
    <!-- Preventing caching will impact Viewer performance -->
    <add key=""PreventViewerClientCaching"" value=""true"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test31()
    {
        //Testing the parsing of the 231 system.diagnostics section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

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
    public void Test32()
    {
        //Testing the parsing of the 231 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""timeout"",""type"":""2"",""htmlIdName"":""Session-Timeout"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""cookieSameSite"",""type"":""2"",""htmlIdName"":""Samesite-Cookie-Policy"",""Value"":""Lax"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""timeout"",""type"":""2"",""htmlIdName"":""Session-Timeout"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""cookieSameSite"",""type"":""2"",""htmlIdName"":""Samesite-Cookie-Policy"",""Value"":""Lax"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.web>
    <compilation debug=""false"" targetFramework=""4.7.2"">
      <assemblies>
        <add assembly=""netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"" />
      </assemblies>
    </compilation>
    <!--
			SESSION STATE SETTINGS
		-->
    <sessionState mode=""InProc"" stateConnectionString=""tcpip=127.0.0.1:42424"" sqlConnectionString=""data source=127.0.0.1;Trusted_Connection=yes"" cookieless=""false"" cookieSameSite=""Lax"" timeout=""20"" />
    <!--
		For a description of web.config changes see http://go.microsoft.com/fwlink/?LinkId=235367.

		The following attributes can be set on the <httpRuntime> tag.
			<system.Web>
				<httpRuntime targetFramework=""4.7.2"" />
			</system.Web>
		-->
    <!--  HTTPRUNTIME
			By default the maximum size a request may be is 4096 KB.  If files larger than 4096 KB (4 MB)
			need to be uploaded increase the size of the maxRequestLength.  MaxRequestLength value is in KiloBytes.
			By default the maximum number of seconds that a request is allowed to execute is 90 seconds.
			If uploading large documents, the executionTimeout value may need to be increased for proper processing.

			If uploads larger than 30MB are required, maxRequestLength in the application server's web.config must also be increased.
			If uploads larger than 30MB are required and IIS7 or greater is being used, additional changes are required.
			Refer to the maxAllowedContentLength comments for information regarding the changes.
		-->
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <httpRuntime requestValidationMode=""2.0"" maxRequestLength=""4096"" executionTimeout=""90"" enableVersionHeader=""false"" />
    <!--  GLOBALIZATION
					This section sets the globalization settings of the application. 
		-->
    <globalization requestEncoding=""utf-8"" responseEncoding=""utf-8"" />
    <!-- IDENTITY
		By setting impersonate=""true"" the username and password set in the registry will be used
		when the application is started.

		For Healthcare Form Manager, impersonation is (most likely) not needed. The default account of
		NetworkService or ApplicationPoolIdentity should have the proper file permissions and network
		permissions to communicate with the Application Server.

		Use Impersonation on the Application Server for proper NTFS file security.
		When using NT Authentication, LDAP Authentication, Active Directory Authentication, and certain SSOs
		the Application Server will require a user with additional permissions to complete user authentication.

		Use aspnet_setreg.exe to encrypt and set the username and password in the registry.
		aspnet_setreg -k:SOFTWARE\Hyland\AppNet\Identity -u:<domain>\<username> -p:<password>

		NOTE: Each time aspnet_setreg.exe is run, the security on the registry key is restored to the default.
		If using x64 regedit, search with the Wow6432Node in the key path. If the x86 version is used, this is unnecessary.
		Use regedit to update HKLM:SOFTWARE\Hyland\AppNet\Identity\ASPNET_SETREG key to allow read permissions
		by the identity running the Application Pool.
		-->
    <!--
		<identity impersonate=""false""
			userName=""registry:HKLM\SOFTWARE\Wow6432Node\Hyland\AppNet\Identity\ASPNET_SETREG,userName""
			password=""registry:HKLM\SOFTWARE\Wow6432Node\Hyland\AppNet\Identity\ASPNET_SETREG,password""
			/>
		-->
    <!-- Authentication and Authorization sections for ADFS -->
    <!--
		<authentication mode=""None"" />
		<authorization>
			<deny users=""?"" />
		</authorization>
		-->
    <webServices>
      <!-- The web services HTTP POST protocol is disabled by default in .NET 1.1 and above.
				 The following entry enables the protocol and is required by Hyland Services -->
      <protocols>
        <add name=""HttpPost"" />
      </protocols>
      <!-- SOAP Extensions for ADFS -->
      <!--
			<soapExtensionTypes>
				<add type=""Hyland.Authentication.ADFS.CustomADFSAuthSoapExtension, Hyland.Authentication"" />
			</soapExtensionTypes>
			-->
    </webServices>
    <pages validateRequest=""true"" controlRenderingCompatibilityVersion=""4.0"" />
    <httpCookies httpOnlyCookies=""true"" requireSSL=""true"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test33()
    {
        //Testing the parsing of the 231 system.webServer section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.webServer>
    <modules runAllManagedModulesForAllRequests=""true"">
      <!--The format for this section should additionally contain the preCondition attribute.-->
      <add name=""OnBaseContextModule"" type=""Hyland.Server.Diagnostics.OnBaseContextModule, Hyland.Server"" preCondition=""managedHandler"" />
      <!-- The following two modules are required for ADFS -->
      <!--add name=""WSFederationAuthenticationModule"" type=""System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!--add name=""SessionAuthenticationModule"" type=""System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
    </modules>
    <validation validateIntegratedModeConfiguration=""false"" />
    <handlers accessPolicy=""Read, Script"">
      <add name=""Login.ashx_*"" path=""Login.ashx"" verb=""*"" type=""Hyland.Controls.Web.Login.LoginHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Windows Manager Dependencies -->
      <add name=""WindowDirector.ashx_*"" path=""WindowDirector.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.WindowDirector,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Viewer Dependencies -->
      <add name=""OptimizedServicePipeline.ashx_*"" path=""OptimizedServicePipeline.ashx"" verb=""*"" type=""Hyland.Applications.Web.OptimizedServicePipelineProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DownloadHandler.ashx_*"" path=""DownloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.DownloadHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FormProc.ashx_*"" path=""FormProc.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.FormProc, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentActionHandler.ashx_*"" path=""DocumentActionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentActionHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""NoteType.ashx_*"" verb=""*"" path=""NoteType.ashx"" type=""Hyland.Applications.Web.Client.Controls.NoteType,Hyland.Applications.Web.Client"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentDataHandler.ashx_*"" path=""DocumentDataHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentDataHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PrintHandler.ashx_*"" path=""PrintHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.PrintHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""NoteHandler.ashx_*"" path=""NoteHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.NoteHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""GVCDocActions.ashx_*"" path=""GVCDocActions.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.GVCDocActions,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PdfHandler.ashx_*"" path=""PdfHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.PdfHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""OleHandler.ashx_*"" path=""OleHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.OleHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""IDOLDocumentHandler.ashx_*"" path=""IDOLDocumentHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.IDOLDocumentHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FileServiceHandler.ashx_*"" path=""FileServiceHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.FileServiceHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""MarkupLanguageHandler.ashx_*"" path=""MarkupLanguageHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.MarkupLanguageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ThumbnailHandler.ashx_GET"" path=""ThumbnailHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ThumbnailHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageHandler.ashx_GET"" path=""ImageHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ImageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UnloadHandler.ashx_*"" path=""UnloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.UnloadHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageProvider.ashx_*"" path=""ImageProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.UtilityControls.ImageViewer.ImageProvider,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ExceptionMessage.ashx_*"" path=""ExceptionMessage.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.ExceptionMessageHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ScriptExceptionHandler.ashx_*"" path=""ScriptExceptionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.ScriptExceptionHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ChartSearchHandler.ashx_*"" path=""ChartSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.Controls.Search.ChartSearchHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UniversalListControlHandler.ashx_*"" path=""UniversalListControlHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.Controls.UniversalListControlHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
    <!--The Request Filtering module will reject requests larger than 30MB by default.-->
    <!--If IIS7 or greater is being used and uploads larger than 30MB are expected, maxAllowedContentLength as well as maxRequestLength must be increased.-->
    <!--Uploads that are below maxAllowedContentLength but above maxRequestLength will display a friendly error message to the user.-->
    <!--Uploads that are above maxAllowedContentLength will be rejected and a 404 error will occur.-->
    <!--Therefore, this value (in bytes) should be larger and not equal to maxRequestLength (in kilobytes) or users will not receive a friendly error message.-->
    <!--Uncomment the section below and enter the value as needed.-->
    <!--This setting should be changed in both the Web Server and Application Server's web.config.-->
    <security>
      <requestFiltering>
        <requestLimits maxAllowedContentLength=""30000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <defaultDocument>
      <files>
        <clear />
        <add value=""Login.aspx"" />
      </files>
    </defaultDocument>
    <httpProtocol>
      <!--The custom headers section is only for IIS7 and greater.  -->
      <customHeaders>
        <remove name=""X-Powered-By"" />
        <!-- IE=11 tells Internet Explorer 11 to render pages in standards mode supported by the browser. -->
        <add name=""X-UA-Compatible"" value=""IE=11"" />
      </customHeaders>
    </httpProtocol>
  </system.webServer>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.webServer", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test34()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Validate-Against-Checksum"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Checksum-Key"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Validate-Against-Checksum"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Checksum-Key"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test35()
    {
        //Testing the parsing of the 231 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure231WithVersionNumber);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""23.1.7.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""Hyland Application Server""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""Hyland Application Server"" />
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
    <AuditRoutes />
  </Hyland.Logging>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Logging", xmldoc, new DefaultWebApplicationDataStructures());

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test46()
    {
        //Testing the Prebuilding of the 241 system.diagnostics section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test47()
    {
        //Testing the Prebuilding of the 241 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""allowedDomain"",""type"":""2"",""htmlIdName"":""Allowed-Domain"",""Value"":""[APP SERVER]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://localhost/HealthcareFormManager"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""WebClientType"",""type"":""2"",""htmlIdName"":""Web-Client-Type"",""Value"":""html"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","allowedDomain","2","Allowed-Domain","[APP SERVER]","","",""},
            {"appSettings","add","dmsVirtualRoot","2","Virtual-Directory","https://localhost/HealthcareFormManager","","",""},
            {"appSettings","add","dmsDataSource","2","Data-Source","[DATASOURCE]","","",""},
            {"appSettings","add","AllowViewSource","1","Allow-View-Source","false","","",""},
            {"appSettings","add","EnableSessionExpiration","1","Enable-Session-Expiration","true","","",""},
            {"appSettings","add","PromptOnSessionExpire","1","Prompt-On-Session-Expire","true","","",""},
            {"appSettings","add","webtheme","2","Web-Theme","XP","","",""},
            {"appSettings","add","default_username","2","Default-Username","","","",""},
            {"appSettings","add","default_password","2","Default-Password","","","",""},
            {"appSettings","add","enableDefaultLogin","1","Default-Login","false","","",""},
            {"appSettings","add","EnableAutoLogin","1","Autologin","false","","",""},
            {"appSettings","add","IdPUrl","2","","","","",""},
            {"appSettings","add","forceSSOAutoLoginOverDomain","1","Force-OnBase-Authentication","false","","",""},
            {"appSettings","add","WebClientType","2","Web-Client-Type","html","","",""},
            {"appSettings","add","enableRowColoring","1","Row-Coloring","true","","",""},
            {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
            {"appSettings","add","PreventViewerClientCaching","1","Prevent-Viewer-Client-Caching","true","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test48()
    {
        //Testing the Prebuilding of the 241 system.web section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""timeout"",""type"":""2"",""htmlIdName"":""Session-Timeout"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""cookieSameSite"",""type"":""2"",""htmlIdName"":""Samesite-Cookie-Policy"",""Value"":""Lax"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","",""},
            {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","",""},
            {"system.web","sessionState","timeout","2","Session-Timeout","20","","",""},
            {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test49()
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
    public void Test50()
    {
        //Testing the parsing of the 241 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""allowedDomain"",""type"":""2"",""htmlIdName"":""Allowed-Domain"",""Value"":""[APP SERVER]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://localhost/HealthcareFormManager"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""WebClientType"",""type"":""2"",""htmlIdName"":""Web-Client-Type"",""Value"":""html"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""allowedDomain"",""type"":""2"",""htmlIdName"":""Allowed-Domain"",""Value"":""[APP SERVER]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""http://DESKTOP-6I1HC77/HealthcareFormManager"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""OnBaseTest"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":""Testing"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":""Test1;Test2;Test3;Test4"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""WebClientType"",""type"":""2"",""htmlIdName"":""Web-Client-Type"",""Value"":""html"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":{""ServerLocation"":""Test1"",""Tenant"":""Test2"",""Client"":""Test3"",""Secret"":""Test4""},""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<appSettings file=""version.xml"">
    <add key=""allowedDomain"" value=""[APP SERVER]"" />
    <add key=""dmsVirtualRoot"" value=""http://DESKTOP-6I1HC77/HealthcareFormManager"" />
    <add key=""dmsDataSource"" value=""OnBaseTest"" />
    <add key=""AllowViewSource"" value=""false"" />
    <!-- Session timout variables -->
    <add key=""EnableSessionExpiration"" value=""true"" />
    <add key=""PromptOnSessionExpire"" value=""true"" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""default_username"" value=""Test"" />
    <add key=""default_password"" value=""Testing"" />
    <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
    <add key=""enableDefaultLogin"" value=""false"" />
    <add key=""EnableAutoLogin"" value=""false"" />
    <add key=""IdPUrl"" value=""Test1;Test2;Test3;Test4"" />
    <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
    <!--
		The EnableActiveX key has been removed and replaced by WebClientType.
		Valid values are:
							activex | html | selectable
		""activex"" will enable the ActiveX web client.
		""html"" will enable the HTML Only web client.
		""selectable"" will provide users an option upon login to select which
					 client type (ActiveX or HTML Only) to use.
		-->
    <add key=""WebClientType"" value=""html"" />
    <!--Settings respected by ULC controls-->
    <add key=""enableRowColoring"" value=""true"" />
    <!-- This setting controls if the server will accept only https connections or not. 
				 If you set this to false all incoming requests have to be made over https. 
				 If you set this to true then both http and https connections are accepted. 
				 The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value=""true"" />
    <!-- Preventing caching will impact Viewer performance -->
    <add key=""PreventViewerClientCaching"" value=""true"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test51()
    {
        //Testing the parsing of the 241 system.diagnostics section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.diagnostics"",""PathName"":""switches/add[@name='hylandTracing']"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Tracing-Info-Level"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

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
    public void Test52()
    {
        //Testing the parsing of the 241 system.web section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""timeout"",""type"":""2"",""htmlIdName"":""Session-Timeout"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""cookieSameSite"",""type"":""2"",""htmlIdName"":""Samesite-Cookie-Policy"",""Value"":""Lax"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""maxRequestLength"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Maximum-Request-Length"",""Value"":""4096"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""httpRuntime"",""AttributeName"":""executionTimeout"",""type"":""2"",""htmlIdName"":""HTTP-Runtime-Execution-Timeout"",""Value"":""90"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""timeout"",""type"":""2"",""htmlIdName"":""Session-Timeout"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""system.web"",""PathName"":""sessionState"",""AttributeName"":""cookieSameSite"",""type"":""2"",""htmlIdName"":""Samesite-Cookie-Policy"",""Value"":""Lax"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.web>
    <compilation debug=""false"" targetFramework=""4.7.2"">
      <assemblies>
        <add assembly=""netstandard, Version=2.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51"" />
      </assemblies>
    </compilation>
    <!--
			SESSION STATE SETTINGS
		-->
    <sessionState mode=""InProc"" stateConnectionString=""tcpip=127.0.0.1:42424"" sqlConnectionString=""data source=127.0.0.1;Trusted_Connection=yes"" cookieless=""false"" cookieSameSite=""Lax"" timeout=""20"" />
    <!--
		For a description of web.config changes see http://go.microsoft.com/fwlink/?LinkId=235367.

		The following attributes can be set on the <httpRuntime> tag.
			<system.Web>
				<httpRuntime targetFramework=""4.7.2"" />
			</system.Web>
		-->
    <!--  HTTPRUNTIME
			By default the maximum size a request may be is 4096 KB.  If files larger than 4096 KB (4 MB)
			need to be uploaded increase the size of the maxRequestLength.  MaxRequestLength value is in KiloBytes.
			By default the maximum number of seconds that a request is allowed to execute is 90 seconds.
			If uploading large documents, the executionTimeout value may need to be increased for proper processing.

			If uploads larger than 30MB are required, maxRequestLength in the application server's web.config must also be increased.
			If uploads larger than 30MB are required and IIS7 or greater is being used, additional changes are required.
			Refer to the maxAllowedContentLength comments for information regarding the changes.
		-->
    <!-- WARNING - Do not set this value below 4MB or uploads over 4MB will fail - WARNING -->
    <httpRuntime requestValidationMode=""2.0"" maxRequestLength=""4096"" executionTimeout=""90"" enableVersionHeader=""false"" />
    <!--  GLOBALIZATION
					This section sets the globalization settings of the application. 
		-->
    <globalization requestEncoding=""utf-8"" responseEncoding=""utf-8"" />
    <!-- IDENTITY
		By setting impersonate=""true"" the username and password set in the registry will be used
		when the application is started.

		For Healthcare Form Manager, impersonation is (most likely) not needed. The default account of
		NetworkService or ApplicationPoolIdentity should have the proper file permissions and network
		permissions to communicate with the Application Server.

		Use Impersonation on the Application Server for proper NTFS file security.
		When using NT Authentication, LDAP Authentication, Active Directory Authentication, and certain SSOs
		the Application Server will require a user with additional permissions to complete user authentication.

		Use aspnet_setreg.exe to encrypt and set the username and password in the registry.
		aspnet_setreg -k:SOFTWARE\Hyland\AppNet\Identity -u:<domain>\<username> -p:<password>

		NOTE: Each time aspnet_setreg.exe is run, the security on the registry key is restored to the default.
		If using x64 regedit, search with the Wow6432Node in the key path. If the x86 version is used, this is unnecessary.
		Use regedit to update HKLM:SOFTWARE\Hyland\AppNet\Identity\ASPNET_SETREG key to allow read permissions
		by the identity running the Application Pool.
		-->
    <!--
		<identity impersonate=""false""
			userName=""registry:HKLM\SOFTWARE\Wow6432Node\Hyland\AppNet\Identity\ASPNET_SETREG,userName""
			password=""registry:HKLM\SOFTWARE\Wow6432Node\Hyland\AppNet\Identity\ASPNET_SETREG,password""
			/>
		-->
    <!-- Authentication and Authorization sections for ADFS -->
    <!--
		<authentication mode=""None"" />
		<authorization>
			<deny users=""?"" />
		</authorization>
		-->
    <webServices>
      <!-- The web services HTTP POST protocol is disabled by default in .NET 1.1 and above.
				 The following entry enables the protocol and is required by Hyland Services -->
      <protocols>
        <add name=""HttpPost"" />
      </protocols>
      <!-- SOAP Extensions for ADFS -->
      <!--
			<soapExtensionTypes>
				<add type=""Hyland.Authentication.ADFS.CustomADFSAuthSoapExtension, Hyland.Authentication"" />
			</soapExtensionTypes>
			-->
    </webServices>
    <pages validateRequest=""true"" controlRenderingCompatibilityVersion=""4.0"" />
    <httpCookies httpOnlyCookies=""true"" requireSSL=""true"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test53()
    {
        //Testing the parsing of the 241 system.webServer section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.webServer"",""PathName"":""security/requestFiltering/requestLimits"",""AttributeName"":""maxAllowedContentLength"",""type"":""2"",""htmlIdName"":""Max-Allowed-Content-Length"",""Value"":""30000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.webServer>
    <modules runAllManagedModulesForAllRequests=""true"">
      <!--The format for this section should additionally contain the preCondition attribute.-->
      <add name=""OnBaseContextModule"" type=""Hyland.Server.Diagnostics.OnBaseContextModule, Hyland.Server"" preCondition=""managedHandler"" />
      <!-- The following two modules are required for ADFS -->
      <!--add name=""WSFederationAuthenticationModule"" type=""System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!--add name=""SessionAuthenticationModule"" type=""System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
    </modules>
    <validation validateIntegratedModeConfiguration=""false"" />
    <handlers accessPolicy=""Read, Script"">
      <add name=""Login.ashx_*"" path=""Login.ashx"" verb=""*"" type=""Hyland.Controls.Web.Login.LoginHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Windows Manager Dependencies -->
      <add name=""WindowDirector.ashx_*"" path=""WindowDirector.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.WindowDirector,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Viewer Dependencies -->
      <add name=""OptimizedServicePipeline.ashx_*"" path=""OptimizedServicePipeline.ashx"" verb=""*"" type=""Hyland.Applications.Web.OptimizedServicePipelineProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DownloadHandler.ashx_*"" path=""DownloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.DownloadHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FormProc.ashx_*"" path=""FormProc.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.FormProc, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentActionHandler.ashx_*"" path=""DocumentActionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentActionHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""NoteType.ashx_*"" verb=""*"" path=""NoteType.ashx"" type=""Hyland.Applications.Web.Client.Controls.NoteType,Hyland.Applications.Web.Client"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentDataHandler.ashx_*"" path=""DocumentDataHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentDataHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PrintHandler.ashx_*"" path=""PrintHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.PrintHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""NoteHandler.ashx_*"" path=""NoteHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.NoteHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""GVCDocActions.ashx_*"" path=""GVCDocActions.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.GVCDocActions,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PdfHandler.ashx_*"" path=""PdfHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.PdfHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""OleHandler.ashx_*"" path=""OleHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.OleHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""IDOLDocumentHandler.ashx_*"" path=""IDOLDocumentHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.IDOLDocumentHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FileServiceHandler.ashx_*"" path=""FileServiceHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.FileServiceHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""MarkupLanguageHandler.ashx_*"" path=""MarkupLanguageHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.MarkupLanguageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ThumbnailHandler.ashx_GET"" path=""ThumbnailHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ThumbnailHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageHandler.ashx_GET"" path=""ImageHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ImageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UnloadHandler.ashx_*"" path=""UnloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.UnloadHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageProvider.ashx_*"" path=""ImageProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.UtilityControls.ImageViewer.ImageProvider,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ExceptionMessage.ashx_*"" path=""ExceptionMessage.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.ExceptionMessageHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ScriptExceptionHandler.ashx_*"" path=""ScriptExceptionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.ScriptExceptionHandler,Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ChartSearchHandler.ashx_*"" path=""ChartSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.Controls.Search.ChartSearchHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UniversalListControlHandler.ashx_*"" path=""UniversalListControlHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HealthcareFormManager.Controls.UniversalListControlHandler,Hyland.Applications.Web.HealthcareFormManager"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
    <!--The Request Filtering module will reject requests larger than 30MB by default.-->
    <!--If IIS7 or greater is being used and uploads larger than 30MB are expected, maxAllowedContentLength as well as maxRequestLength must be increased.-->
    <!--Uploads that are below maxAllowedContentLength but above maxRequestLength will display a friendly error message to the user.-->
    <!--Uploads that are above maxAllowedContentLength will be rejected and a 404 error will occur.-->
    <!--Therefore, this value (in bytes) should be larger and not equal to maxRequestLength (in kilobytes) or users will not receive a friendly error message.-->
    <!--Uncomment the section below and enter the value as needed.-->
    <!--This setting should be changed in both the Web Server and Application Server's web.config.-->
    <security>
      <requestFiltering>
        <requestLimits maxAllowedContentLength=""30000000"" />
      </requestFiltering>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
    <defaultDocument>
      <files>
        <clear />
        <add value=""Login.aspx"" />
      </files>
    </defaultDocument>
    <httpProtocol>
      <!--The custom headers section is only for IIS7 and greater.  -->
      <customHeaders>
        <remove name=""X-Powered-By"" />
        <!-- IE=11 tells Internet Explorer 11 to render pages in standards mode supported by the browser. -->
        <add name=""X-UA-Compatible"" value=""IE=11"" />
      </customHeaders>
    </httpProtocol>
  </system.webServer>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.webServer", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test54()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Validate-Against-Checksum"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Checksum-Key"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Validate-Against-Checksum"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Checksum-Key"",""Value"":""Testin"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test55()
    {
        //Testing the parsing of the 241 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure241WithVersionNumber);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""24.1.7.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""Hyland Application Server""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""Hyland Application Server"" />
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
    <AuditRoutes />
  </Hyland.Logging>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Logging", xmldoc, new DefaultWebApplicationDataStructures());

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }
}