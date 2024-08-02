using COMACON.config;
using COMACONTranslationToHelperUtility;
using FluentAssertions;
using Newtonsoft.Json;
using System.Xml;

namespace COMACON.tests;

public class OnBasePatientWindowTests
{
    private readonly string cleanWebApplicationDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";
    private readonly string cleanWebApplicationDataStructure211WithVersionNumber = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";
    private readonly string cleanWebApplicationDataStructure221WithVersionNumber = @"{""Type"":"""",""Version"":""22.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";
    private readonly string cleanWebApplicationDataStructure231WithVersionNumber = @"{""Type"":"""",""Version"":""23.1.7.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";
    private readonly string cleanWebApplicationDataStructure241WithVersionNumber = @"{""Type"":"""",""Version"":""24.1.7.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

    [Fact]
    public void Test1()
    {
        //Testing to validate that the key is found and the appropriate value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings file=""version.xml"">
    <add key=""dmsVirtualRoot"" value=""https://[WEB SERVER]/[VIRTUAL ROOT]"" />
    <add key=""dmsDataSource"" value=""[DATA SOURCE]"" />
    <add key=""AllowViewSource"" value=""true"" />
    <!-- Session timeout variables -->
    <add key=""EnableSessionExpiration"" value=""true"" />
    <add key=""PromptOnSessionExpire"" value=""true"" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""default_username"" value="""" />
    <add key=""default_password"" value="""" />
    <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
    <add key=""enableDefaultLogin"" value=""false"" />
    <add key=""EnableAutoLogin"" value=""true"" />
    <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
    <!-- Enables the Split View / Cross Reference Document user interface. -->
    <add key=""EnableSplitView"" value=""true"" />
    <!-- Enables the Patient Search interface for non-admin users-->
    <add key=""EnablePatientSearch"" value=""false"" />
    <!-- Enables Patient Context Syncing -->
    <add key=""EnablePatientContextSyncing"" value=""false"" />
    <!-- Enables enforcement of UTC-based timestamp -->
    <add key=""EnableTimestamp"" value=""false"" />
    <!-- The amount of time in minutes the UTC-based timestamp is valid -->
    <add key=""TimestampTimeLimit"" value=""5"" />
    <!-- Enable hostname DNS lookup by IP when workstationName is not included as a request parameter-->
    <add key=""EnableWorkstationNameDNSLookup"" value=""false"" />
    <!--Settings respected by ULC controls-->
    <add key=""enableRowColoring"" value=""true"" />
    <!-- Settings for Thumbnail HitList Viewer -->
    <!-- Whether to allow web server caching of images -->
    <add key=""ThumbnailHitListAllowCaching"" value=""false"" />
    <add key=""ThumbnailHitListThumbnailMaxWidth"" value=""140"" />
    <add key=""ThumbnailHitListThumbnailMaxHeight"" value=""175"" />
    <add key=""ThumbnailHitListPreviewMaxWidth"" value=""1000"" />
    <add key=""ThumbnailHitListPreviewMaxHeight"" value=""1000"" />
    <!-- This setting controls if the server will accept only https connections or not. 
         If you set this to false all incoming requests have to be made over https. 
         If you set this to true then both http and https connections are accepted. 
         The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value=""false"" />
    <!-- Preventing caching will impact Viewer performance -->
    <add key=""PreventViewerClientCaching"" value=""true"" />
    <add key=""HTMLOnlyDocumentsPrintAsPDFs"" value=""true"" />
    <!-- These settings specify the labels of UI components related to System (Dynamic) List and Personal (Static) List functionality-->
    <add key=""SystemListDisplayLabel"" value=""System List"" />
    <add key=""PersonalListDisplayLabel"" value=""Personal List"" />
    <!-- The selected tab in OPW will be set to the color specified. Set the value to a RGB hex color value, i.e. #FF0000 is red, #0000FF is blue, or friendly name, red, blue, green, etc. -->
    <add key=""SelectedTabSingleColor"" value=""#000000"" />
    <add key=""__EnableEFormStandardPrinting"" value=""true"" />
    <!-- By default, ad-hoc federated searches via the ""Find More Studies"" button occur with all of the known Medical Record Numbers for the patient.
         Setting this value to true will use the Master Patient Index Number instead. -->
    <add key=""FederatedSearchWithMPI"" value=""false"" />
    <add key=""HideToolbarPrintButton"" value=""false"" />
    <add key=""autoDisplayNotePanelPDFOffice"" value=""true"" />
    <add key=""IdPUrl"" value="";;;"" />
    <add key=""EmergencyAccessDialogTitle"" value="""" />
    <add key=""EmergencyAccessDialogMessage"" value="""" />
    <add key=""EmergencyAccessDialogOtherReasonLabel"" value="""" />
    <add key=""ShowEmergencyAccessShowDocumentsCheckboxes"" value=""true"" />
    <add key=""ShowOtherReasonInEmergencyAccessDialog"" value=""true"" />
    <add key=""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"" value=""false"" />
  </appSettings>";

        string keyName = "EnableAutoLogin";
        string defaultValue = "false";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getNonStandardXmlValue(xmldoc.DocumentElement, keyName, defaultValue);

        value.Should().Be("true");
    }

    [Fact]
    public void Test2()
    {
        //Testing to validate that the key is not found and the default value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings file=""version.xml"">
    <add key=""dmsVirtualRoot"" value=""https://[WEB SERVER]/[VIRTUAL ROOT]"" />
    <add key=""dmsDataSource"" value=""[DATA SOURCE]"" />
    <add key=""AllowViewSource"" value=""true"" />
    <!-- Session timeout variables -->
    <add key=""EnableSessionExpiration"" value=""true"" />
    <add key=""PromptOnSessionExpire"" value=""true"" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""default_username"" value="""" />
    <add key=""default_password"" value="""" />
    <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
    <add key=""enableDefaultLogin"" value=""false"" />
    <add key=""EnableAutoLogin"" value=""false"" />
    <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
    <!-- Enables the Split View / Cross Reference Document user interface. -->
    <add key=""EnableSplitView"" value=""true"" />
    <!-- Enables the Patient Search interface for non-admin users-->
    <add key=""EnablePatientSearch"" value=""false"" />
    <!-- Enables Patient Context Syncing -->
    <add key=""EnablePatientContextSyncing"" value=""false"" />
    <!-- Enables enforcement of UTC-based timestamp -->
    <add key=""EnableTimestamp"" value=""false"" />
    <!-- The amount of time in minutes the UTC-based timestamp is valid -->
    <add key=""TimestampTimeLimit"" value=""5"" />
    <!-- Enable hostname DNS lookup by IP when workstationName is not included as a request parameter-->
    <add key=""EnableWorkstationNameDNSLookup"" value=""false"" />
    <!--Settings respected by ULC controls-->
    <add key=""enableRowColoring"" value=""true"" />
    <!-- Settings for Thumbnail HitList Viewer -->
    <!-- Whether to allow web server caching of images -->
    <add key=""ThumbnailHitListAllowCaching"" value=""false"" />
    <add key=""ThumbnailHitListThumbnailMaxWidth"" value=""140"" />
    <add key=""ThumbnailHitListThumbnailMaxHeight"" value=""175"" />
    <add key=""ThumbnailHitListPreviewMaxWidth"" value=""1000"" />
    <add key=""ThumbnailHitListPreviewMaxHeight"" value=""1000"" />
    <!-- This setting controls if the server will accept only https connections or not. 
         If you set this to false all incoming requests have to be made over https. 
         If you set this to true then both http and https connections are accepted. 
         The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value=""false"" />
    <!-- Preventing caching will impact Viewer performance -->
    <add key=""PreventViewerClientCaching"" value=""true"" />
    <add key=""HTMLOnlyDocumentsPrintAsPDFs"" value=""true"" />
    <!-- These settings specify the labels of UI components related to System (Dynamic) List and Personal (Static) List functionality-->
    <add key=""SystemListDisplayLabel"" value=""System List"" />
    <add key=""PersonalListDisplayLabel"" value=""Personal List"" />
    <!-- The selected tab in OPW will be set to the color specified. Set the value to a RGB hex color value, i.e. #FF0000 is red, #0000FF is blue, or friendly name, red, blue, green, etc. -->
    <add key=""SelectedTabSingleColor"" value=""#000000"" />
    <add key=""__EnableEFormStandardPrinting"" value=""true"" />
    <!-- By default, ad-hoc federated searches via the ""Find More Studies"" button occur with all of the known Medical Record Numbers for the patient.
         Setting this value to true will use the Master Patient Index Number instead. -->
    <add key=""FederatedSearchWithMPI"" value=""false"" />
    <add key=""HideToolbarPrintButton"" value=""false"" />
    <add key=""autoDisplayNotePanelPDFOffice"" value=""true"" />
    <add key=""IdPUrl"" value="";;;"" />
    <add key=""EmergencyAccessDialogTitle"" value="""" />
    <add key=""EmergencyAccessDialogMessage"" value="""" />
    <add key=""EmergencyAccessDialogOtherReasonLabel"" value="""" />
    <add key=""ShowEmergencyAccessShowDocumentsCheckboxes"" value=""true"" />
    <add key=""ShowOtherReasonInEmergencyAccessDialog"" value=""true"" />
    <add key=""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"" value=""false"" />
  </appSettings>";

        string keyName = "enableAutoLogin";
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

    For Patient Window, impersonation is (most likely) not needed. The default account of
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
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
    <authentication mode=""Windows"" />
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
    public void Test5()
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
    public void Test6()
    {
        //Testing the Prebuilding of the 211 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
            {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
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

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://[WEB SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATA SOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Enable-Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSplitView"",""type"":""1"",""htmlIdName"":""Enable-Split-View"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientSearch"",""type"":""1"",""htmlIdName"":""Enable-Patient-Search"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientContextSyncing"",""type"":""1"",""htmlIdName"":""Enable-Patient-Context-Syncing"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableTimestamp"",""type"":""1"",""htmlIdName"":""Enable-Timestamp"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TimestampTimeLimit"",""type"":""2"",""htmlIdName"":""Timestamp-Time-Limit"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableWorkstationNameDNSLookup"",""type"":""1"",""htmlIdName"":""Enable-Workstation-Name-DNS-Lookup"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListAllowCaching"",""type"":""1"",""htmlIdName"":""Allow-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxWidth"",""type"":""2"",""htmlIdName"":""Maximum-Width"",""Value"":""140"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxHeight"",""type"":""2"",""htmlIdName"":""Maximum-Height"",""Value"":""175"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxWidth"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Width"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxHeight"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Height"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HTMLOnlyDocumentsPrintAsPDFs"",""type"":""1"",""htmlIdName"":""HTML-Only-Documents-Print-As-PDFs"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SystemListDisplayLabel"",""type"":""2"",""htmlIdName"":""System-List-Display-Label"",""Value"":""System List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PersonalListDisplayLabel"",""type"":""2"",""htmlIdName"":""Personal-List-Display-Label"",""Value"":""Personal List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SelectedTabSingleColor"",""type"":""2"",""htmlIdName"":""Selected-Tab-Single-Color"",""Value"":""#000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""__EnableEFormStandardPrinting"",""type"":""1"",""htmlIdName"":""Enable-EForm-Standard-Printing"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FederatedSearchWithMPI"",""type"":""1"",""htmlIdName"":""Federated-Search-With-MPI"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HideToolbarPrintButton"",""type"":""1"",""htmlIdName"":""Hide-Toolbar-Print-Button"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""autoDisplayNotePanelPDFOffice"",""type"":""1"",""htmlIdName"":""Auto-Display-Note-Panel-PDF-Office"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogTitle"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Title"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogMessage"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogOtherReasonLabel"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Other-Reason-Label"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowEmergencyAccessShowDocumentsCheckboxes"",""type"":""1"",""htmlIdName"":""Show-Emergency-Access-Show-Documents-Checkboxes"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowOtherReasonInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Show-Other-Reason-In-Emergency-Access-Dialog"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","dmsVirtualRoot","2","Virtual-Directory","https://[WEB SERVER]/[VIRTUAL ROOT]","","",""},
            {"appSettings","add","dmsDataSource","2","Data-Source","[DATA SOURCE]","","",""},
            {"appSettings","add","AllowViewSource","1","Allow-View-Source","true","","",""},
            {"appSettings","add","EnableSessionExpiration","1","Enable-Session-Expiration","true","","",""},
            {"appSettings","add","PromptOnSessionExpire","1","Prompt-On-Session-Expire","true","","",""},
            {"appSettings","add","webtheme","2","Web-Theme","XP","","",""},
            {"appSettings","add","default_username","2","Default-Username","","","",""},
            {"appSettings","add","default_password","2","Default-Password","","","",""},
            {"appSettings","add","enableDefaultLogin","1","Enable-Default-Login","false","","",""},
            {"appSettings","add","EnableAutoLogin","1","Autologin","false","","",""},
            {"appSettings","add","forceSSOAutoLoginOverDomain","1","Force-OnBase-Authentication","false","","",""},
            {"appSettings","add","EnableSplitView","1","Enable-Split-View","true","","",""},
            {"appSettings","add","EnablePatientSearch","1","Enable-Patient-Search","false","","",""},
            {"appSettings","add","EnablePatientContextSyncing","1","Enable-Patient-Context-Syncing","false","","",""},
            {"appSettings","add","EnableTimestamp","1","Enable-Timestamp","false","","",""},
            {"appSettings","add","TimestampTimeLimit","2","Timestamp-Time-Limit","5","","",""},
            {"appSettings","add","EnableWorkstationNameDNSLookup","1","Enable-Workstation-Name-DNS-Lookup","false","","",""},
            {"appSettings","add","enableRowColoring","1","Row-Coloring","true","","",""},
            {"appSettings","add","ThumbnailHitListAllowCaching","1","Allow-Caching","false","","",""},
            {"appSettings","add","ThumbnailHitListThumbnailMaxWidth","2","Maximum-Width","140","","",""},
            {"appSettings","add","ThumbnailHitListThumbnailMaxHeight","2","Maximum-Height","175","","",""},
            {"appSettings","add","ThumbnailHitListPreviewMaxWidth","2","Preview-Maximum-Width","1000","","",""},
            {"appSettings","add","ThumbnailHitListPreviewMaxHeight","2","Preview-Maximum-Height","1000","","",""},
            {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
            {"appSettings","add","PreventViewerClientCaching","1","Prevent-Viewer-Client-Caching","true","","",""},
            {"appSettings","add","HTMLOnlyDocumentsPrintAsPDFs","1","HTML-Only-Documents-Print-As-PDFs","true","","",""},
            {"appSettings","add","SystemListDisplayLabel","2","System-List-Display-Label","System List","","",""},
            {"appSettings","add","PersonalListDisplayLabel","2","Personal-List-Display-Label","Personal List","","",""},
            {"appSettings","add","SelectedTabSingleColor","2","Selected-Tab-Single-Color","#000000","","",""},
            {"appSettings","add","__EnableEFormStandardPrinting","1","Enable-EForm-Standard-Printing","true","","",""},
            {"appSettings","add","FederatedSearchWithMPI","1","Federated-Search-With-MPI","false","","",""},
            {"appSettings","add","HideToolbarPrintButton","1","Hide-Toolbar-Print-Button","false","","",""},
            {"appSettings","add","autoDisplayNotePanelPDFOffice","1","Auto-Display-Note-Panel-PDF-Office","true","","",""},
            {"appSettings","add","IdPUrl","2","","","","",""},
            {"appSettings","add","EmergencyAccessDialogTitle","2","Emergency-Access-Dialog-Title","","","",""},
            {"appSettings","add","EmergencyAccessDialogMessage","2","Emergency-Access-Dialog-Message","","","",""},
            {"appSettings","add","EmergencyAccessDialogOtherReasonLabel","2","Emergency-Access-Dialog-Other-Reason-Label","","","",""},
            {"appSettings","add","ShowEmergencyAccessShowDocumentsCheckboxes","1","Show-Emergency-Access-Show-Documents-Checkboxes","true","","",""},
            {"appSettings","add","ShowOtherReasonInEmergencyAccessDialog","1","Show-Other-Reason-In-Emergency-Access-Dialog","true","","",""},
            {"appSettings","add","OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog","1","Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog","false","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test8()
    {
        //Testing the Prebuilding of the 211 Hyland.Authentication section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Authentication"",""PathName"":""adfs"",""AttributeName"":""enabled"",""type"":""1"",""htmlIdName"":""ADFS-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Authentication","adfs","enabled","1","ADFS-Enabled","false","","",""}
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
    public void Test10()
    {
        //Testing the parsing of the 211 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://[APP SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"" ServiceClientType=""Remoting"" />
    <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
    <StreamingSettings BufferSize=""64000"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

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
        //Testing the parsing of the 211 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://[WEB SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATA SOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Enable-Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSplitView"",""type"":""1"",""htmlIdName"":""Enable-Split-View"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientSearch"",""type"":""1"",""htmlIdName"":""Enable-Patient-Search"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientContextSyncing"",""type"":""1"",""htmlIdName"":""Enable-Patient-Context-Syncing"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableTimestamp"",""type"":""1"",""htmlIdName"":""Enable-Timestamp"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TimestampTimeLimit"",""type"":""2"",""htmlIdName"":""Timestamp-Time-Limit"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableWorkstationNameDNSLookup"",""type"":""1"",""htmlIdName"":""Enable-Workstation-Name-DNS-Lookup"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListAllowCaching"",""type"":""1"",""htmlIdName"":""Allow-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxWidth"",""type"":""2"",""htmlIdName"":""Maximum-Width"",""Value"":""140"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxHeight"",""type"":""2"",""htmlIdName"":""Maximum-Height"",""Value"":""175"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxWidth"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Width"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxHeight"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Height"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HTMLOnlyDocumentsPrintAsPDFs"",""type"":""1"",""htmlIdName"":""HTML-Only-Documents-Print-As-PDFs"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SystemListDisplayLabel"",""type"":""2"",""htmlIdName"":""System-List-Display-Label"",""Value"":""System List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PersonalListDisplayLabel"",""type"":""2"",""htmlIdName"":""Personal-List-Display-Label"",""Value"":""Personal List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SelectedTabSingleColor"",""type"":""2"",""htmlIdName"":""Selected-Tab-Single-Color"",""Value"":""#000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""__EnableEFormStandardPrinting"",""type"":""1"",""htmlIdName"":""Enable-EForm-Standard-Printing"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FederatedSearchWithMPI"",""type"":""1"",""htmlIdName"":""Federated-Search-With-MPI"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HideToolbarPrintButton"",""type"":""1"",""htmlIdName"":""Hide-Toolbar-Print-Button"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""autoDisplayNotePanelPDFOffice"",""type"":""1"",""htmlIdName"":""Auto-Display-Note-Panel-PDF-Office"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogTitle"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Title"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogMessage"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogOtherReasonLabel"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Other-Reason-Label"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowEmergencyAccessShowDocumentsCheckboxes"",""type"":""1"",""htmlIdName"":""Show-Emergency-Access-Show-Documents-Checkboxes"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowOtherReasonInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Show-Other-Reason-In-Emergency-Access-Dialog"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://[WEB SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATA SOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Enable-Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSplitView"",""type"":""1"",""htmlIdName"":""Enable-Split-View"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientSearch"",""type"":""1"",""htmlIdName"":""Enable-Patient-Search"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientContextSyncing"",""type"":""1"",""htmlIdName"":""Enable-Patient-Context-Syncing"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableTimestamp"",""type"":""1"",""htmlIdName"":""Enable-Timestamp"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TimestampTimeLimit"",""type"":""2"",""htmlIdName"":""Timestamp-Time-Limit"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableWorkstationNameDNSLookup"",""type"":""1"",""htmlIdName"":""Enable-Workstation-Name-DNS-Lookup"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListAllowCaching"",""type"":""1"",""htmlIdName"":""Allow-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxWidth"",""type"":""2"",""htmlIdName"":""Maximum-Width"",""Value"":""140"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxHeight"",""type"":""2"",""htmlIdName"":""Maximum-Height"",""Value"":""175"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxWidth"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Width"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxHeight"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Height"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HTMLOnlyDocumentsPrintAsPDFs"",""type"":""1"",""htmlIdName"":""HTML-Only-Documents-Print-As-PDFs"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SystemListDisplayLabel"",""type"":""2"",""htmlIdName"":""System-List-Display-Label"",""Value"":""System List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PersonalListDisplayLabel"",""type"":""2"",""htmlIdName"":""Personal-List-Display-Label"",""Value"":""Personal List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SelectedTabSingleColor"",""type"":""2"",""htmlIdName"":""Selected-Tab-Single-Color"",""Value"":""#000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""__EnableEFormStandardPrinting"",""type"":""1"",""htmlIdName"":""Enable-EForm-Standard-Printing"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FederatedSearchWithMPI"",""type"":""1"",""htmlIdName"":""Federated-Search-With-MPI"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HideToolbarPrintButton"",""type"":""1"",""htmlIdName"":""Hide-Toolbar-Print-Button"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""autoDisplayNotePanelPDFOffice"",""type"":""1"",""htmlIdName"":""Auto-Display-Note-Panel-PDF-Office"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogTitle"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Title"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogMessage"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogOtherReasonLabel"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Other-Reason-Label"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowEmergencyAccessShowDocumentsCheckboxes"",""type"":""1"",""htmlIdName"":""Show-Emergency-Access-Show-Documents-Checkboxes"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowOtherReasonInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Show-Other-Reason-In-Emergency-Access-Dialog"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":{""ServerLocation"":"""",""Tenant"":"""",""Client"":"""",""Secret"":""""},""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<appSettings file=""version.xml"">
    <add key=""dmsVirtualRoot"" value=""https://[WEB SERVER]/[VIRTUAL ROOT]"" />
    <add key=""dmsDataSource"" value=""[DATA SOURCE]"" />
    <add key=""AllowViewSource"" value=""true"" />
    <!-- Session timeout variables -->
    <add key=""EnableSessionExpiration"" value=""true"" />
    <add key=""PromptOnSessionExpire"" value=""true"" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""default_username"" value="""" />
    <add key=""default_password"" value="""" />
    <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
    <add key=""enableDefaultLogin"" value=""false"" />
    <add key=""EnableAutoLogin"" value=""false"" />
    <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
    <!-- Enables the Split View / Cross Reference Document user interface. -->
    <add key=""EnableSplitView"" value=""true"" />
    <!-- Enables the Patient Search interface for non-admin users-->
    <add key=""EnablePatientSearch"" value=""false"" />
    <!-- Enables Patient Context Syncing -->
    <add key=""EnablePatientContextSyncing"" value=""false"" />
    <!-- Enables enforcement of UTC-based timestamp -->
    <add key=""EnableTimestamp"" value=""false"" />
    <!-- The amount of time in minutes the UTC-based timestamp is valid -->
    <add key=""TimestampTimeLimit"" value=""5"" />
    <!-- Enable hostname DNS lookup by IP when workstationName is not included as a request parameter-->
    <add key=""EnableWorkstationNameDNSLookup"" value=""false"" />
    <!--Settings respected by ULC controls-->
    <add key=""enableRowColoring"" value=""true"" />
    <!-- Settings for Thumbnail HitList Viewer -->
    <!-- Whether to allow web server caching of images -->
    <add key=""ThumbnailHitListAllowCaching"" value=""false"" />
    <add key=""ThumbnailHitListThumbnailMaxWidth"" value=""140"" />
    <add key=""ThumbnailHitListThumbnailMaxHeight"" value=""175"" />
    <add key=""ThumbnailHitListPreviewMaxWidth"" value=""1000"" />
    <add key=""ThumbnailHitListPreviewMaxHeight"" value=""1000"" />
    <!-- This setting controls if the server will accept only https connections or not. 
         If you set this to false all incoming requests have to be made over https. 
         If you set this to true then both http and https connections are accepted. 
         The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value=""false"" />
    <!-- Preventing caching will impact Viewer performance -->
    <add key=""PreventViewerClientCaching"" value=""true"" />
    <add key=""HTMLOnlyDocumentsPrintAsPDFs"" value=""true"" />
    <!-- These settings specify the labels of UI components related to System (Dynamic) List and Personal (Static) List functionality-->
    <add key=""SystemListDisplayLabel"" value=""System List"" />
    <add key=""PersonalListDisplayLabel"" value=""Personal List"" />
    <!-- The selected tab in OPW will be set to the color specified. Set the value to a RGB hex color value, i.e. #FF0000 is red, #0000FF is blue, or friendly name, red, blue, green, etc. -->
    <add key=""SelectedTabSingleColor"" value=""#000000"" />
    <add key=""__EnableEFormStandardPrinting"" value=""true"" />
    <!-- By default, ad-hoc federated searches via the ""Find More Studies"" button occur with all of the known Medical Record Numbers for the patient.
         Setting this value to true will use the Master Patient Index Number instead. -->
    <add key=""FederatedSearchWithMPI"" value=""false"" />
    <add key=""HideToolbarPrintButton"" value=""false"" />
    <add key=""autoDisplayNotePanelPDFOffice"" value=""true"" />
    <add key=""IdPUrl"" value="""" />
    <add key=""EmergencyAccessDialogTitle"" value="""" />
    <add key=""EmergencyAccessDialogMessage"" value="""" />
    <add key=""EmergencyAccessDialogOtherReasonLabel"" value="""" />
    <add key=""ShowEmergencyAccessShowDocumentsCheckboxes"" value=""true"" />
    <add key=""ShowOtherReasonInEmergencyAccessDialog"" value=""true"" />
    <add key=""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"" value=""false"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test13()
    {
        //Testing the parsing of the 211 Hyland.Authentication section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Authentication"",""PathName"":""adfs"",""AttributeName"":""enabled"",""type"":""1"",""htmlIdName"":""ADFS-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Authentication"",""PathName"":""adfs"",""AttributeName"":""enabled"",""type"":""1"",""htmlIdName"":""ADFS-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Authentication>
    <adfs enabled=""false"" synchronizeUserAttributes=""true"" authenticationOnly=""2.0"" />
  </Hyland.Authentication>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Authentication", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test14()
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

    For Patient Window, impersonation is (most likely) not needed. The default account of
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
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
    <authentication mode=""Windows"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test15()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Validate-Against-Checksum"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Checksum-Key"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Validate-Against-Checksum"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Checksum-Key"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test16()
    {
        //Testing the parsing of the 211 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure211WithVersionNumber);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""Hyland Application Server""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":{""OutputFormat"":""Minimal""},""RouteType"":""Console"",""Name"":""Console"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""5"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":{""SourceName"":""Hyland""},""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":null,""RouteType"":""EventLog"",""Name"":""ErrorEventLog"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""Hyland Application Server"" />
    <Routes>
      <Route name=""Console"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Console"" />
        <add key=""OutputFormat"" value=""Minimal"" />
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
      <Route name=""ErrorEventLog"">
        <add key=""minimum-level"" value=""Error"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""EventLog"" value=""Hyland"" />
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
    public void Test17()
    {
        //Testing the parsing of the 211 ADFS section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":{""systemIdentityModel"":{""audienceUris"":[{""URI"":""https://Audience/URI/"",""id"":null},{""URI"":""https://dummy/dummy/"",""id"":null}],""trustedIssuers"":[{""Thumbprint"":""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"",""Name"":""Optional_Friendly_Name_For_The_Certificate"",""id"":null},{""Thumbprint"":""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"",""Name"":""Other_Friendly_Name"",""id"":null}]},""systemIdentityModelServices"":{""wsFederation"":{""Issuer"":""https://issuer/URI/adfs/ls/"",""Realm"":""https://Audience/URI/""},""serviceCertificate"":{""X509FindType"":""FindByThumbprint"",""FindValue"":""ZYXWVUTSRQPONMLKJIHGFEDCBA0987654321ZYXW"",""StoreLocation"":""LocalMachine"",""StoreName"":""My""},""CookieHandlerRequireSSL"":""false""},""knownKeys"":[],""ADFSEnabled"":""false"",""RequestValidationMode"":""2.0"",""AuthenticationMode"":""Windows"",""SynchronizeUserAttributes"":""true"",""AuthenticationOnly"":""2.0""},""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<configuration>
  <configSections>
    <section name=""Hyland.Services.Client"" type=""Hyland.Services.Client.ServiceClientConfiguration,Hyland.Services.Client"" />
    <section name=""Hyland.Logging"" type=""Hyland.Logging.Configuration.ClientConfigurationHandler,Hyland.Logging"" />
    <section name=""Hyland.Web.HealthcarePop"" type=""Hyland.Applications.Web.ConfigSections.HealthcarePopConfigSection, Hyland.Applications.Web"" />
    <!-- ADFS sections -->
    <section name=""Hyland.Authentication"" type=""Hyland.Authentication.Configuration.AuthenticationConfigurationSection, Hyland.Authentication"" />
    <section name=""system.identityModel"" type=""System.IdentityModel.Configuration.SystemIdentityModelSection, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"" />
    <section name=""system.identityModel.services"" type=""System.IdentityModel.Services.Configuration.SystemIdentityModelServicesSection, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"" />
    <!-- End ADFS sections -->
  </configSections>
  <Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"" ServiceClientType=""Remoting"" />
    <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
    <StreamingSettings BufferSize=""64000"" />
  </Hyland.Services.Client>
  <Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""Hyland Application Server"" />
    <Routes>
      <Route name=""Console"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Console"" />
        <add key=""OutputFormat"" value=""Minimal"" />
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
      <Route name=""ErrorEventLog"">
        <add key=""minimum-level"" value=""Error"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""EventLog"" value=""Hyland"" />
        <add key=""DisableIPAddressMasking"" value=""True"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
    </Routes>
    <AuditRoutes />
  </Hyland.Logging>
  <appSettings file=""version.xml"">
    <add key=""dmsVirtualRoot"" value=""https://[WEB SERVER]/[VIRTUAL ROOT]"" />
    <add key=""dmsDataSource"" value=""[DATA SOURCE]"" />
    <add key=""AllowViewSource"" value=""true"" />
    <!-- Session timeout variables -->
    <add key=""EnableSessionExpiration"" value=""true"" />
    <add key=""PromptOnSessionExpire"" value=""true"" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""default_username"" value="""" />
    <add key=""default_password"" value="""" />
    <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
    <add key=""enableDefaultLogin"" value=""false"" />
    <add key=""EnableAutoLogin"" value=""false"" />
    <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
    <!-- Enables the Split View / Cross Reference Document user interface. -->
    <add key=""EnableSplitView"" value=""true"" />
    <!-- Enables the Patient Search interface for non-admin users-->
    <add key=""EnablePatientSearch"" value=""false"" />
    <!-- Enables Patient Context Syncing -->
    <add key=""EnablePatientContextSyncing"" value=""false"" />
    <!-- Enables enforcement of UTC-based timestamp -->
    <add key=""EnableTimestamp"" value=""false"" />
    <!-- The amount of time in minutes the UTC-based timestamp is valid -->
    <add key=""TimestampTimeLimit"" value=""5"" />
    <!-- Enable hostname DNS lookup by IP when workstationName is not included as a request parameter-->
    <add key=""EnableWorkstationNameDNSLookup"" value=""false"" />
    <!--Settings respected by ULC controls-->
    <add key=""enableRowColoring"" value=""true"" />
    <!-- Settings for Thumbnail HitList Viewer -->
    <!-- Whether to allow web server caching of images -->
    <add key=""ThumbnailHitListAllowCaching"" value=""false"" />
    <add key=""ThumbnailHitListThumbnailMaxWidth"" value=""140"" />
    <add key=""ThumbnailHitListThumbnailMaxHeight"" value=""175"" />
    <add key=""ThumbnailHitListPreviewMaxWidth"" value=""1000"" />
    <add key=""ThumbnailHitListPreviewMaxHeight"" value=""1000"" />
    <!-- This setting controls if the server will accept only https connections or not. 
         If you set this to false all incoming requests have to be made over https. 
         If you set this to true then both http and https connections are accepted. 
         The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value=""false"" />
    <!-- Preventing caching will impact Viewer performance -->
    <add key=""PreventViewerClientCaching"" value=""true"" />
    <add key=""HTMLOnlyDocumentsPrintAsPDFs"" value=""true"" />
    <!-- These settings specify the labels of UI components related to System (Dynamic) List and Personal (Static) List functionality-->
    <add key=""SystemListDisplayLabel"" value=""System List"" />
    <add key=""PersonalListDisplayLabel"" value=""Personal List"" />
    <!-- The selected tab in OPW will be set to the color specified. Set the value to a RGB hex color value, i.e. #FF0000 is red, #0000FF is blue, or friendly name, red, blue, green, etc. -->
    <add key=""SelectedTabSingleColor"" value=""#000000"" />
    <add key=""__EnableEFormStandardPrinting"" value=""true"" />
    <!-- By default, ad-hoc federated searches via the ""Find More Studies"" button occur with all of the known Medical Record Numbers for the patient.
         Setting this value to true will use the Master Patient Index Number instead. -->
    <add key=""FederatedSearchWithMPI"" value=""false"" />
    <add key=""HideToolbarPrintButton"" value=""false"" />
    <add key=""autoDisplayNotePanelPDFOffice"" value=""true"" />
    <add key=""IdPUrl"" value="""" />
    <add key=""EmergencyAccessDialogTitle"" value="""" />
    <add key=""EmergencyAccessDialogMessage"" value="""" />
    <add key=""EmergencyAccessDialogOtherReasonLabel"" value="""" />
    <add key=""ShowEmergencyAccessShowDocumentsCheckboxes"" value=""true"" />
    <add key=""ShowOtherReasonInEmergencyAccessDialog"" value=""true"" />
    <add key=""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"" value=""false"" />
  </appSettings>
  <Hyland.Web.HealthcarePop>
    <EnableChecksum value=""true"" />
    <ChecksumKey value=""Test"" />
    <EnableLegacyChecksumFallback value=""false"" />
  </Hyland.Web.HealthcarePop>
  <Hyland.Authentication>
    <adfs enabled=""false"" synchronizeUserAttributes=""true"" authenticationOnly=""2.0"" />
  </Hyland.Authentication>
  <system.diagnostics>
    <switches>
      <!--
      This switch controls tracing globally through Hyland.Logging.
      It configures the level of information from Trace that is logged.
      For no information set the value to zero. Set the value to 1, 2, 3, or 4 for
      minimal, normal, detailed, or verbose messages, respectively.
      -->
      <add name=""hylandTracing"" value=""0"" />
    </switches>
  </system.diagnostics>
  <configProtectedData>
    <providers>
      <add name=""DpapiProvider"" type=""System.Configuration.DpapiProtectedConfigurationProvider,System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"" />
    </providers>
  </configProtectedData>
  <system.web>
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

    For Patient Window, impersonation is (most likely) not needed. The default account of
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
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
    <authentication mode=""Windows"" />
  </system.web>
  <system.webServer>
    <modules runAllManagedModulesForAllRequests=""true"">
      <!--The format for this section should additionally contain the preCondition attribute.-->
      <add name=""OnBaseContextModule"" type=""Hyland.Server.Diagnostics.OnBaseContextModule, Hyland.Server"" preCondition=""managedHandler"" />
      <!-- The following two modules are required for ADFS -->
      <!--add name=""WSFederationAuthenticationModule"" type=""System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!--add name=""SessionAuthenticationModule"" type=""System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
    </modules>
    <validation validateIntegratedModeConfiguration=""false"" />
    <handlers>
      <!-- Hyland.Applications.Web -->
      <add name=""DownloadHandler.ashx_*"" path=""DownloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.DownloadHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""OptimizedServicePipeline.ashx_*"" path=""OptimizedServicePipeline.ashx"" verb=""*"" type=""Hyland.Applications.Web.OptimizedServicePipelineProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""Service.asmx_*"" path=""Service.asmx"" verb=""*"" type=""Hyland.Applications.Web.ServiceHttpHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Applications.Web.Client.Controls -->
      <add name=""NoteType.ashx_*"" verb=""*"" path=""NoteType.ashx"" type=""Hyland.Applications.Web.Client.Controls.NoteType, Hyland.Applications.Web.Client"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Applications.Web.Handlers -->
      <add name=""DocumentActionHandler.ashx_*"" path=""DocumentActionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentActionHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentDataHandler.ashx_*"" path=""DocumentDataHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentDataHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FormProc.ashx_*"" path=""FormProc.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.FormProc, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ScriptExceptionHandler.ashx_*"" path=""ScriptExceptionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.ScriptExceptionHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Applications.Web.WindowsManager -->
      <add name=""UnloadHandler.ashx_*"" path=""UnloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.UnloadHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""WindowDirector.ashx_*"" path=""WindowDirector.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.WindowDirector, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Controls.Web -->
      <add name=""CalendarProvider.ashx_*"" path=""CalendarProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.Calendar.CalendarProvider, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FileServiceHandler.ashx_*"" path=""FileServiceHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.FileServiceHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""Login.ashx_*"" path=""Login.ashx"" verb=""*"" type=""Hyland.Controls.Web.Login.LoginHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""NoteHandler.ashx_*"" path=""NoteHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.NoteHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PrintHandler.ashx_*"" path=""PrintHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.PrintHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Controls.Web.GenericViewer -->
      <add name=""GVCDocActions.ashx_*"" path=""GVCDocActions.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.GVCDocActions, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""IDOLDocumentHandler.ashx_*"" path=""IDOLDocumentHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.IDOLDocumentHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageProvider.ashx_*"" path=""ImageProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.UtilityControls.ImageViewer.ImageProvider, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""MarkupLanguageHandler.ashx_*"" path=""MarkupLanguageHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.MarkupLanguageHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""OleHandler.ashx_*"" path=""OleHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.OleHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PdfHandler.ashx_*"" path=""PdfHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.PdfHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""WopiHandler.ashx_*"" path=""WopiHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.WopiHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Controls.Web.Viewer -->
      <add name=""ThumbnailHandler.ashx_GET"" path=""ThumbnailHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ThumbnailHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageHandler.ashx_GET"" path=""ImageHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ImageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Applications.Web.PatientWindow -->
      <add name=""ExceptionMessage.ashx_*"" path=""ExceptionMessage.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.ExceptionMessageHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Applications.Web.PatientWindow.Controls -->
      <add name=""ChartSearchHandler.ashx_*"" path=""ChartSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.Search.ChartSearchHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentCorrectionActionHandler.ashx_*"" path=""DocumentCorrectionActionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.DocumentCorrectionAction.DocumentCorrectionActionHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PatientSearchHandler.ashx_*"" path=""PatientSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.Search.PatientSearchHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ScheduledPatientSearchHandler.ashx_*"" path=""ScheduledPatientSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.Search.ScheduledPatientSearchHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UniversalListControlHandler.ashx_*"" path=""UniversalListControlHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.List.UniversalListControlHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Applications.Web.PatientWindow.Dialogs -->
      <add name=""ConfidentialityCodesHandler.ashx_*"" path=""ConfidentialityCodesHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Dialogs.ConfidentialityCodesHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UserOptionsHandler.ashx_*"" path=""UserOptionsHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Dialogs.UserOptionsHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Controls.Web.Medical -->
      <add name=""ConfidentialityNoticeHandler.ashx_*"" path=""ConfidentialityNoticeHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.Medical.ConfidentialityNoticeControls.ConfidentialityNoticeHandler, Hyland.Controls.Web.Medical"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
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
    <security>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
  </system.webServer>
  <!--
  The system.identityModel section is used to enable Windows Identity Foundation options.

  The audienceUri identifies the relying party (RP - this application).  This much exactly (case, trailing slash, etc.) match the Relying Party Trust Identifier on the ADFS sever.
  The certificate identified by the thumbprint in the trustedIssuers element is the token-signing certificate found on the ADFS server.
  -->
  <!--<system.identityModel><identityConfiguration saveBootstrapContext=""true""><securityTokenHandlers><securityTokenHandlerConfiguration><audienceUris><add value=""https://Audience/URI/"" /><add value=""https://dummy/dummy/"" /></audienceUris><issuerNameRegistry type=""System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089""><trustedIssuers><add thumbprint=""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"" name=""Optional_Friendly_Name_For_The_Certificate"" /><add thumbprint=""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"" name=""Other_Friendly_Name"" /></trustedIssuers></issuerNameRegistry></securityTokenHandlerConfiguration></securityTokenHandlers></identityConfiguration></system.identityModel>-->
  <!--
  system.identityModel.services is used to configure authentication using the WS-Federation protocol.

  wsFederation node
    The 'issuer' attribute specifies the URI of the token issuer.  It sets the base URL for authentication requests.
    The 'realm' attribute specifies the URI used to identify the relying party (RP - this application).  This much exactly (case, trailing slash, etc.) match the Relying Party Trust Identifier on the ADFS sever.

  The certificate identified by the certificateReference element is the encryption certificate configured on the Relying Party Trust on the ADFS server.
  -->
  <!--<system.identityModel.services><federationConfiguration requireSsl=""false""><wsFederation issuer=""https://issuer/URI/adfs/ls/"" realm=""https://Audience/URI/"" /><serviceCertificate><certificateReference x509FindType=""FindByThumbprint"" findValue=""ZYXWVUTSRQPONMLKJIHGFEDCBA0987654321ZYXW"" storeLocation=""LocalMachine"" storeName=""My"" /></serviceCertificate></federationConfiguration></system.identityModel.services>-->
  <runtime>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""Microsoft.Extensions.DependencyInjection.Abstractions"" publicKeyToken=""adb9793829ddae60"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-2.1.1.0"" newVersion=""2.1.1.0"" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""Microsoft.Extensions.Logging.Abstractions"" publicKeyToken=""adb9793829ddae60"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-2.1.1.0"" newVersion=""2.1.1.0"" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""Microsoft.Owin"" publicKeyToken=""31bf3856ad364e35"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-4.0.1.0"" newVersion=""4.0.1.0"" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""Newtonsoft.Json"" publicKeyToken=""30ad4fe6b2a6aeed"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-11.0.0.0"" newVersion=""11.0.0.0"" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""System.Buffers"" publicKeyToken=""cc7b13ffcd2ddd51"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-4.0.3.0"" newVersion=""4.0.3.0"" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""System.Configuration.ConfigurationManager"" publicKeyToken=""cc7b13ffcd2ddd51"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-4.0.3.0"" newVersion=""4.0.3.0"" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""System.Runtime.CompilerServices.Unsafe"" publicKeyToken=""b03f5f7f11d50a3a"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-4.0.6.0"" newVersion=""4.0.6.0"" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
</configuration>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "ADFS", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test18()
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
    public void Test19()
    {
        //Testing the Prebuilding of the 221 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
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

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://[WEB SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATA SOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Enable-Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSplitView"",""type"":""1"",""htmlIdName"":""Enable-Split-View"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientSearch"",""type"":""1"",""htmlIdName"":""Enable-Patient-Search"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientContextSyncing"",""type"":""1"",""htmlIdName"":""Enable-Patient-Context-Syncing"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableTimestamp"",""type"":""1"",""htmlIdName"":""Enable-Timestamp"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TimestampTimeLimit"",""type"":""2"",""htmlIdName"":""Timestamp-Time-Limit"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableWorkstationNameDNSLookup"",""type"":""1"",""htmlIdName"":""Enable-Workstation-Name-DNS-Lookup"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListAllowCaching"",""type"":""1"",""htmlIdName"":""Allow-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxWidth"",""type"":""2"",""htmlIdName"":""Maximum-Width"",""Value"":""140"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxHeight"",""type"":""2"",""htmlIdName"":""Maximum-Height"",""Value"":""175"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxWidth"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Width"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxHeight"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Height"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HTMLOnlyDocumentsPrintAsPDFs"",""type"":""1"",""htmlIdName"":""HTML-Only-Documents-Print-As-PDFs"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SystemListDisplayLabel"",""type"":""2"",""htmlIdName"":""System-List-Display-Label"",""Value"":""System List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PersonalListDisplayLabel"",""type"":""2"",""htmlIdName"":""Personal-List-Display-Label"",""Value"":""Personal List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SelectedTabSingleColor"",""type"":""2"",""htmlIdName"":""Selected-Tab-Single-Color"",""Value"":""#000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""__EnableEFormStandardPrinting"",""type"":""1"",""htmlIdName"":""Enable-EForm-Standard-Printing"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FederatedSearchWithMPI"",""type"":""1"",""htmlIdName"":""Federated-Search-With-MPI"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HideToolbarPrintButton"",""type"":""1"",""htmlIdName"":""Hide-Toolbar-Print-Button"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""autoDisplayNotePanelPDFOffice"",""type"":""1"",""htmlIdName"":""Auto-Display-Note-Panel-PDF-Office"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogTitle"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Title"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogMessage"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogOtherReasonLabel"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Other-Reason-Label"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowEmergencyAccessShowDocumentsCheckboxes"",""type"":""1"",""htmlIdName"":""Show-Emergency-Access-Show-Documents-Checkboxes"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowOtherReasonInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Show-Other-Reason-In-Emergency-Access-Dialog"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","dmsVirtualRoot","2","Virtual-Directory","https://[WEB SERVER]/[VIRTUAL ROOT]","","",""},
            {"appSettings","add","dmsDataSource","2","Data-Source","[DATA SOURCE]","","",""},
            {"appSettings","add","AllowViewSource","1","Allow-View-Source","true","","",""},
            {"appSettings","add","EnableSessionExpiration","1","Enable-Session-Expiration","true","","",""},
            {"appSettings","add","PromptOnSessionExpire","1","Prompt-On-Session-Expire","true","","",""},
            {"appSettings","add","webtheme","2","Web-Theme","XP","","",""},
            {"appSettings","add","default_username","2","Default-Username","","","",""},
            {"appSettings","add","default_password","2","Default-Password","","","",""},
            {"appSettings","add","enableDefaultLogin","1","Enable-Default-Login","false","","",""},
            {"appSettings","add","EnableAutoLogin","1","Autologin","false","","",""},
            {"appSettings","add","forceSSOAutoLoginOverDomain","1","Force-OnBase-Authentication","false","","",""},
            {"appSettings","add","EnableSplitView","1","Enable-Split-View","true","","",""},
            {"appSettings","add","EnablePatientSearch","1","Enable-Patient-Search","false","","",""},
            {"appSettings","add","EnablePatientContextSyncing","1","Enable-Patient-Context-Syncing","false","","",""},
            {"appSettings","add","EnableTimestamp","1","Enable-Timestamp","false","","",""},
            {"appSettings","add","TimestampTimeLimit","2","Timestamp-Time-Limit","5","","",""},
            {"appSettings","add","EnableWorkstationNameDNSLookup","1","Enable-Workstation-Name-DNS-Lookup","false","","",""},
            {"appSettings","add","enableRowColoring","1","Row-Coloring","true","","",""},
            {"appSettings","add","ThumbnailHitListAllowCaching","1","Allow-Caching","false","","",""},
            {"appSettings","add","ThumbnailHitListThumbnailMaxWidth","2","Maximum-Width","140","","",""},
            {"appSettings","add","ThumbnailHitListThumbnailMaxHeight","2","Maximum-Height","175","","",""},
            {"appSettings","add","ThumbnailHitListPreviewMaxWidth","2","Preview-Maximum-Width","1000","","",""},
            {"appSettings","add","ThumbnailHitListPreviewMaxHeight","2","Preview-Maximum-Height","1000","","",""},
            {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
            {"appSettings","add","PreventViewerClientCaching","1","Prevent-Viewer-Client-Caching","true","","",""},
            {"appSettings","add","HTMLOnlyDocumentsPrintAsPDFs","1","HTML-Only-Documents-Print-As-PDFs","true","","",""},
            {"appSettings","add","SystemListDisplayLabel","2","System-List-Display-Label","System List","","",""},
            {"appSettings","add","PersonalListDisplayLabel","2","Personal-List-Display-Label","Personal List","","",""},
            {"appSettings","add","SelectedTabSingleColor","2","Selected-Tab-Single-Color","#000000","","",""},
            {"appSettings","add","__EnableEFormStandardPrinting","1","Enable-EForm-Standard-Printing","true","","",""},
            {"appSettings","add","FederatedSearchWithMPI","1","Federated-Search-With-MPI","false","","",""},
            {"appSettings","add","HideToolbarPrintButton","1","Hide-Toolbar-Print-Button","false","","",""},
            {"appSettings","add","autoDisplayNotePanelPDFOffice","1","Auto-Display-Note-Panel-PDF-Office","true","","",""},
            {"appSettings","add","IdPUrl","2","","","","",""},
            {"appSettings","add","EmergencyAccessDialogTitle","2","Emergency-Access-Dialog-Title","","","",""},
            {"appSettings","add","EmergencyAccessDialogMessage","2","Emergency-Access-Dialog-Message","","","",""},
            {"appSettings","add","EmergencyAccessDialogOtherReasonLabel","2","Emergency-Access-Dialog-Other-Reason-Label","","","",""},
            {"appSettings","add","ShowEmergencyAccessShowDocumentsCheckboxes","1","Show-Emergency-Access-Show-Documents-Checkboxes","true","","",""},
            {"appSettings","add","ShowOtherReasonInEmergencyAccessDialog","1","Show-Other-Reason-In-Emergency-Access-Dialog","true","","",""},
            {"appSettings","add","OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog","1","Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog","false","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test21()
    {
        //Testing the Prebuilding of the 221 Hyland.Authentication section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Authentication"",""PathName"":""adfs"",""AttributeName"":""enabled"",""type"":""1"",""htmlIdName"":""ADFS-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Authentication","adfs","enabled","1","ADFS-Enabled","false","","",""}
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
    public void Test23()
    {
        //Testing the parsing of the 221 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://[APP SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"" ServiceClientType=""Remoting"" />
    <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
    <StreamingSettings BufferSize=""64000"" />
  </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test24()
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
    public void Test25()
    {
        //Testing the parsing of the 221 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://[WEB SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATA SOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Enable-Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSplitView"",""type"":""1"",""htmlIdName"":""Enable-Split-View"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientSearch"",""type"":""1"",""htmlIdName"":""Enable-Patient-Search"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientContextSyncing"",""type"":""1"",""htmlIdName"":""Enable-Patient-Context-Syncing"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableTimestamp"",""type"":""1"",""htmlIdName"":""Enable-Timestamp"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TimestampTimeLimit"",""type"":""2"",""htmlIdName"":""Timestamp-Time-Limit"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableWorkstationNameDNSLookup"",""type"":""1"",""htmlIdName"":""Enable-Workstation-Name-DNS-Lookup"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListAllowCaching"",""type"":""1"",""htmlIdName"":""Allow-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxWidth"",""type"":""2"",""htmlIdName"":""Maximum-Width"",""Value"":""140"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxHeight"",""type"":""2"",""htmlIdName"":""Maximum-Height"",""Value"":""175"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxWidth"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Width"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxHeight"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Height"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HTMLOnlyDocumentsPrintAsPDFs"",""type"":""1"",""htmlIdName"":""HTML-Only-Documents-Print-As-PDFs"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SystemListDisplayLabel"",""type"":""2"",""htmlIdName"":""System-List-Display-Label"",""Value"":""System List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PersonalListDisplayLabel"",""type"":""2"",""htmlIdName"":""Personal-List-Display-Label"",""Value"":""Personal List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SelectedTabSingleColor"",""type"":""2"",""htmlIdName"":""Selected-Tab-Single-Color"",""Value"":""#000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""__EnableEFormStandardPrinting"",""type"":""1"",""htmlIdName"":""Enable-EForm-Standard-Printing"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FederatedSearchWithMPI"",""type"":""1"",""htmlIdName"":""Federated-Search-With-MPI"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HideToolbarPrintButton"",""type"":""1"",""htmlIdName"":""Hide-Toolbar-Print-Button"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""autoDisplayNotePanelPDFOffice"",""type"":""1"",""htmlIdName"":""Auto-Display-Note-Panel-PDF-Office"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogTitle"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Title"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogMessage"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogOtherReasonLabel"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Other-Reason-Label"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowEmergencyAccessShowDocumentsCheckboxes"",""type"":""1"",""htmlIdName"":""Show-Emergency-Access-Show-Documents-Checkboxes"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowOtherReasonInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Show-Other-Reason-In-Emergency-Access-Dialog"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://[WEB SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATA SOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Enable-Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSplitView"",""type"":""1"",""htmlIdName"":""Enable-Split-View"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientSearch"",""type"":""1"",""htmlIdName"":""Enable-Patient-Search"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientContextSyncing"",""type"":""1"",""htmlIdName"":""Enable-Patient-Context-Syncing"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableTimestamp"",""type"":""1"",""htmlIdName"":""Enable-Timestamp"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TimestampTimeLimit"",""type"":""2"",""htmlIdName"":""Timestamp-Time-Limit"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableWorkstationNameDNSLookup"",""type"":""1"",""htmlIdName"":""Enable-Workstation-Name-DNS-Lookup"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListAllowCaching"",""type"":""1"",""htmlIdName"":""Allow-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxWidth"",""type"":""2"",""htmlIdName"":""Maximum-Width"",""Value"":""140"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxHeight"",""type"":""2"",""htmlIdName"":""Maximum-Height"",""Value"":""175"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxWidth"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Width"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxHeight"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Height"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HTMLOnlyDocumentsPrintAsPDFs"",""type"":""1"",""htmlIdName"":""HTML-Only-Documents-Print-As-PDFs"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SystemListDisplayLabel"",""type"":""2"",""htmlIdName"":""System-List-Display-Label"",""Value"":""System List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PersonalListDisplayLabel"",""type"":""2"",""htmlIdName"":""Personal-List-Display-Label"",""Value"":""Personal List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SelectedTabSingleColor"",""type"":""2"",""htmlIdName"":""Selected-Tab-Single-Color"",""Value"":""#000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""__EnableEFormStandardPrinting"",""type"":""1"",""htmlIdName"":""Enable-EForm-Standard-Printing"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FederatedSearchWithMPI"",""type"":""1"",""htmlIdName"":""Federated-Search-With-MPI"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HideToolbarPrintButton"",""type"":""1"",""htmlIdName"":""Hide-Toolbar-Print-Button"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""autoDisplayNotePanelPDFOffice"",""type"":""1"",""htmlIdName"":""Auto-Display-Note-Panel-PDF-Office"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogTitle"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Title"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogMessage"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogOtherReasonLabel"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Other-Reason-Label"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowEmergencyAccessShowDocumentsCheckboxes"",""type"":""1"",""htmlIdName"":""Show-Emergency-Access-Show-Documents-Checkboxes"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowOtherReasonInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Show-Other-Reason-In-Emergency-Access-Dialog"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":{""ServerLocation"":"""",""Tenant"":"""",""Client"":"""",""Secret"":""""},""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<appSettings file=""version.xml"">
    <add key=""dmsVirtualRoot"" value=""https://[WEB SERVER]/[VIRTUAL ROOT]"" />
    <add key=""dmsDataSource"" value=""[DATA SOURCE]"" />
    <add key=""AllowViewSource"" value=""true"" />
    <!-- Session timeout variables -->
    <add key=""EnableSessionExpiration"" value=""true"" />
    <add key=""PromptOnSessionExpire"" value=""true"" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""default_username"" value="""" />
    <add key=""default_password"" value="""" />
    <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
    <add key=""enableDefaultLogin"" value=""false"" />
    <add key=""EnableAutoLogin"" value=""false"" />
    <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
    <!-- Enables the Split View / Cross Reference Document user interface. -->
    <add key=""EnableSplitView"" value=""true"" />
    <!-- Enables the Patient Search interface for non-admin users-->
    <add key=""EnablePatientSearch"" value=""false"" />
    <!-- Enables Patient Context Syncing -->
    <add key=""EnablePatientContextSyncing"" value=""false"" />
    <!-- Enables enforcement of UTC-based timestamp -->
    <add key=""EnableTimestamp"" value=""false"" />
    <!-- The amount of time in minutes the UTC-based timestamp is valid -->
    <add key=""TimestampTimeLimit"" value=""5"" />
    <!-- Enable hostname DNS lookup by IP when workstationName is not included as a request parameter-->
    <add key=""EnableWorkstationNameDNSLookup"" value=""false"" />
    <!--Settings respected by ULC controls-->
    <add key=""enableRowColoring"" value=""true"" />
    <!-- Settings for Thumbnail HitList Viewer -->
    <!-- Whether to allow web server caching of images -->
    <add key=""ThumbnailHitListAllowCaching"" value=""false"" />
    <add key=""ThumbnailHitListThumbnailMaxWidth"" value=""140"" />
    <add key=""ThumbnailHitListThumbnailMaxHeight"" value=""175"" />
    <add key=""ThumbnailHitListPreviewMaxWidth"" value=""1000"" />
    <add key=""ThumbnailHitListPreviewMaxHeight"" value=""1000"" />
    <!-- This setting controls if the server will accept only https connections or not. 
         If you set this to false all incoming requests have to be made over https. 
         If you set this to true then both http and https connections are accepted. 
         The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value=""false"" />
    <!-- Preventing caching will impact Viewer performance -->
    <add key=""PreventViewerClientCaching"" value=""true"" />
    <add key=""HTMLOnlyDocumentsPrintAsPDFs"" value=""true"" />
    <!-- These settings specify the labels of UI components related to System (Dynamic) List and Personal (Static) List functionality-->
    <add key=""SystemListDisplayLabel"" value=""System List"" />
    <add key=""PersonalListDisplayLabel"" value=""Personal List"" />
    <!-- The selected tab in OPW will be set to the color specified. Set the value to a RGB hex color value, i.e. #FF0000 is red, #0000FF is blue, or friendly name, red, blue, green, etc. -->
    <add key=""SelectedTabSingleColor"" value=""#000000"" />
    <add key=""__EnableEFormStandardPrinting"" value=""true"" />
    <!-- By default, ad-hoc federated searches via the ""Find More Studies"" button occur with all of the known Medical Record Numbers for the patient.
         Setting this value to true will use the Master Patient Index Number instead. -->
    <add key=""FederatedSearchWithMPI"" value=""false"" />
    <add key=""HideToolbarPrintButton"" value=""false"" />
    <add key=""autoDisplayNotePanelPDFOffice"" value=""true"" />
    <add key=""IdPUrl"" value="""" />
    <add key=""EmergencyAccessDialogTitle"" value="""" />
    <add key=""EmergencyAccessDialogMessage"" value="""" />
    <add key=""EmergencyAccessDialogOtherReasonLabel"" value="""" />
    <add key=""ShowEmergencyAccessShowDocumentsCheckboxes"" value=""true"" />
    <add key=""ShowOtherReasonInEmergencyAccessDialog"" value=""true"" />
    <add key=""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"" value=""false"" />
  </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test26()
    {
        //Testing the parsing of the 221 Hyland.Authentication section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Authentication"",""PathName"":""adfs"",""AttributeName"":""enabled"",""type"":""1"",""htmlIdName"":""ADFS-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Authentication"",""PathName"":""adfs"",""AttributeName"":""enabled"",""type"":""1"",""htmlIdName"":""ADFS-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Authentication>
    <adfs enabled=""false"" synchronizeUserAttributes=""true"" authenticationOnly=""2.0"" />
  </Hyland.Authentication>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Authentication", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test27()
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

    For Patient Window, impersonation is (most likely) not needed. The default account of
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
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
    <authentication mode=""Windows"" />
  </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test28()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Validate-Against-Checksum"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Checksum-Key"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Validate-Against-Checksum"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Checksum-Key"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test29()
    {
        //Testing the parsing of the 221 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure221WithVersionNumber);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""22.1.8.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""Hyland Application Server""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":{""OutputFormat"":""Minimal""},""RouteType"":""Console"",""Name"":""Console"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""5"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":{""SourceName"":""Hyland""},""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":null,""RouteType"":""EventLog"",""Name"":""ErrorEventLog"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""Hyland Application Server"" />
    <Routes>
      <Route name=""Console"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Console"" />
        <add key=""OutputFormat"" value=""Minimal"" />
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
      <Route name=""ErrorEventLog"">
        <add key=""minimum-level"" value=""Error"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""EventLog"" value=""Hyland"" />
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
    public void Test30()
    {
        //Testing the parsing of the 221 ADFS section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":{""systemIdentityModel"":{""audienceUris"":[{""URI"":""https://Audience/URI/"",""id"":null},{""URI"":""https://dummy/dummy/"",""id"":null}],""trustedIssuers"":[{""Thumbprint"":""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"",""Name"":""Optional_Friendly_Name_For_The_Certificate"",""id"":null},{""Thumbprint"":""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"",""Name"":""Other_Friendly_Name"",""id"":null}]},""systemIdentityModelServices"":{""wsFederation"":{""Issuer"":""https://issuer/URI/adfs/ls/"",""Realm"":""https://Audience/URI/""},""serviceCertificate"":{""X509FindType"":""FindByThumbprint"",""FindValue"":""ZYXWVUTSRQPONMLKJIHGFEDCBA0987654321ZYXW"",""StoreLocation"":""LocalMachine"",""StoreName"":""My""},""CookieHandlerRequireSSL"":""false""},""knownKeys"":[],""ADFSEnabled"":""false"",""RequestValidationMode"":""2.0"",""AuthenticationMode"":""Windows"",""SynchronizeUserAttributes"":""true"",""AuthenticationOnly"":""2.0""},""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<configuration>
  <configSections>
    <section name=""Hyland.Services.Client"" type=""Hyland.Services.Client.ServiceClientConfiguration,Hyland.Services.Client"" />
    <section name=""Hyland.Logging"" type=""Hyland.Logging.Configuration.ClientConfigurationHandler,Hyland.Logging"" />
    <section name=""Hyland.Web.HealthcarePop"" type=""Hyland.Applications.Web.ConfigSections.HealthcarePopConfigSection, Hyland.Applications.Web"" />
    <!-- ADFS sections -->
    <section name=""Hyland.Authentication"" type=""Hyland.Authentication.Configuration.AuthenticationConfigurationSection, Hyland.Authentication"" />
    <section name=""system.identityModel"" type=""System.IdentityModel.Configuration.SystemIdentityModelSection, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"" />
    <section name=""system.identityModel.services"" type=""System.IdentityModel.Services.Configuration.SystemIdentityModelServicesSection, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"" />
    <!-- End ADFS sections -->
  </configSections>
  <Hyland.Services.Client>
    <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
    <ApplicationServer Url=""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"" ServiceClientType=""Remoting"" />
    <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
    <StreamingSettings BufferSize=""64000"" />
  </Hyland.Services.Client>
  <Hyland.Logging TruncateLogValues=""1024"">
    <WindowsEventLogging sourcename=""Hyland Application Server"" />
    <Routes>
      <Route name=""Console"">
        <add key=""minimum-level"" value=""Information"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""Console"" />
        <add key=""OutputFormat"" value=""Minimal"" />
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
      <Route name=""ErrorEventLog"">
        <add key=""minimum-level"" value=""Error"" />
        <add key=""maximum-level"" value=""Critical"" />
        <add key=""EventLog"" value=""Hyland"" />
        <add key=""DisableIPAddressMasking"" value=""True"" />
        <add key=""include-profiles"" value="""" />
        <add key=""exclude-profiles"" value="""" />
      </Route>
    </Routes>
    <AuditRoutes />
  </Hyland.Logging>
  <appSettings file=""version.xml"">
    <add key=""dmsVirtualRoot"" value=""https://[WEB SERVER]/[VIRTUAL ROOT]"" />
    <add key=""dmsDataSource"" value=""[DATA SOURCE]"" />
    <add key=""AllowViewSource"" value=""true"" />
    <!-- Session timeout variables -->
    <add key=""EnableSessionExpiration"" value=""true"" />
    <add key=""PromptOnSessionExpire"" value=""true"" />
    <add key=""webtheme"" value=""XP"" />
    <add key=""default_username"" value="""" />
    <add key=""default_password"" value="""" />
    <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
    <add key=""enableDefaultLogin"" value=""false"" />
    <add key=""EnableAutoLogin"" value=""false"" />
    <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
    <!-- Enables the Split View / Cross Reference Document user interface. -->
    <add key=""EnableSplitView"" value=""true"" />
    <!-- Enables the Patient Search interface for non-admin users-->
    <add key=""EnablePatientSearch"" value=""false"" />
    <!-- Enables Patient Context Syncing -->
    <add key=""EnablePatientContextSyncing"" value=""false"" />
    <!-- Enables enforcement of UTC-based timestamp -->
    <add key=""EnableTimestamp"" value=""false"" />
    <!-- The amount of time in minutes the UTC-based timestamp is valid -->
    <add key=""TimestampTimeLimit"" value=""5"" />
    <!-- Enable hostname DNS lookup by IP when workstationName is not included as a request parameter-->
    <add key=""EnableWorkstationNameDNSLookup"" value=""false"" />
    <!--Settings respected by ULC controls-->
    <add key=""enableRowColoring"" value=""true"" />
    <!-- Settings for Thumbnail HitList Viewer -->
    <!-- Whether to allow web server caching of images -->
    <add key=""ThumbnailHitListAllowCaching"" value=""false"" />
    <add key=""ThumbnailHitListThumbnailMaxWidth"" value=""140"" />
    <add key=""ThumbnailHitListThumbnailMaxHeight"" value=""175"" />
    <add key=""ThumbnailHitListPreviewMaxWidth"" value=""1000"" />
    <add key=""ThumbnailHitListPreviewMaxHeight"" value=""1000"" />
    <!-- This setting controls if the server will accept only https connections or not. 
         If you set this to false all incoming requests have to be made over https. 
         If you set this to true then both http and https connections are accepted. 
         The recommended setting is false.-->
    <add key=""AllowInsecureConnection"" value=""false"" />
    <!-- Preventing caching will impact Viewer performance -->
    <add key=""PreventViewerClientCaching"" value=""true"" />
    <add key=""HTMLOnlyDocumentsPrintAsPDFs"" value=""true"" />
    <!-- These settings specify the labels of UI components related to System (Dynamic) List and Personal (Static) List functionality-->
    <add key=""SystemListDisplayLabel"" value=""System List"" />
    <add key=""PersonalListDisplayLabel"" value=""Personal List"" />
    <!-- The selected tab in OPW will be set to the color specified. Set the value to a RGB hex color value, i.e. #FF0000 is red, #0000FF is blue, or friendly name, red, blue, green, etc. -->
    <add key=""SelectedTabSingleColor"" value=""#000000"" />
    <add key=""__EnableEFormStandardPrinting"" value=""true"" />
    <!-- By default, ad-hoc federated searches via the ""Find More Studies"" button occur with all of the known Medical Record Numbers for the patient.
         Setting this value to true will use the Master Patient Index Number instead. -->
    <add key=""FederatedSearchWithMPI"" value=""false"" />
    <add key=""HideToolbarPrintButton"" value=""false"" />
    <add key=""autoDisplayNotePanelPDFOffice"" value=""true"" />
    <add key=""IdPUrl"" value="""" />
    <add key=""EmergencyAccessDialogTitle"" value="""" />
    <add key=""EmergencyAccessDialogMessage"" value="""" />
    <add key=""EmergencyAccessDialogOtherReasonLabel"" value="""" />
    <add key=""ShowEmergencyAccessShowDocumentsCheckboxes"" value=""true"" />
    <add key=""ShowOtherReasonInEmergencyAccessDialog"" value=""true"" />
    <add key=""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"" value=""false"" />
  </appSettings>
  <Hyland.Web.HealthcarePop>
    <EnableChecksum value=""true"" />
    <ChecksumKey value=""Test"" />
    <EnableLegacyChecksumFallback value=""false"" />
  </Hyland.Web.HealthcarePop>
  <Hyland.Authentication>
    <adfs enabled=""false"" synchronizeUserAttributes=""true"" authenticationOnly=""2.0"" />
  </Hyland.Authentication>
  <system.diagnostics>
    <switches>
      <!--
      This switch controls tracing globally through Hyland.Logging.
      It configures the level of information from Trace that is logged.
      For no information set the value to zero. Set the value to 1, 2, 3, or 4 for
      minimal, normal, detailed, or verbose messages, respectively.
      -->
      <add name=""hylandTracing"" value=""0"" />
    </switches>
  </system.diagnostics>
  <configProtectedData>
    <providers>
      <add name=""DpapiProvider"" type=""System.Configuration.DpapiProtectedConfigurationProvider,System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"" />
    </providers>
  </configProtectedData>
  <system.web>
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

    For Patient Window, impersonation is (most likely) not needed. The default account of
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
    <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
    <authentication mode=""Windows"" />
  </system.web>
  <system.webServer>
    <modules runAllManagedModulesForAllRequests=""true"">
      <!--The format for this section should additionally contain the preCondition attribute.-->
      <add name=""OnBaseContextModule"" type=""Hyland.Server.Diagnostics.OnBaseContextModule, Hyland.Server"" preCondition=""managedHandler"" />
      <!-- The following two modules are required for ADFS -->
      <!--add name=""WSFederationAuthenticationModule"" type=""System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
      <!--add name=""SessionAuthenticationModule"" type=""System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
    </modules>
    <validation validateIntegratedModeConfiguration=""false"" />
    <handlers>
      <!-- Hyland.Applications.Web -->
      <add name=""DownloadHandler.ashx_*"" path=""DownloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.DownloadHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""OptimizedServicePipeline.ashx_*"" path=""OptimizedServicePipeline.ashx"" verb=""*"" type=""Hyland.Applications.Web.OptimizedServicePipelineProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""Service.asmx_*"" path=""Service.asmx"" verb=""*"" type=""Hyland.Applications.Web.ServiceHttpHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Applications.Web.Client.Controls -->
      <add name=""NoteType.ashx_*"" verb=""*"" path=""NoteType.ashx"" type=""Hyland.Applications.Web.Client.Controls.NoteType, Hyland.Applications.Web.Client"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Applications.Web.Handlers -->
      <add name=""DocumentActionHandler.ashx_*"" path=""DocumentActionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentActionHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentDataHandler.ashx_*"" path=""DocumentDataHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentDataHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FormProc.ashx_*"" path=""FormProc.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.FormProc, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ScriptExceptionHandler.ashx_*"" path=""ScriptExceptionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.ScriptExceptionHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Applications.Web.WindowsManager -->
      <add name=""UnloadHandler.ashx_*"" path=""UnloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.UnloadHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""WindowDirector.ashx_*"" path=""WindowDirector.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.WindowDirector, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Controls.Web -->
      <add name=""CalendarProvider.ashx_*"" path=""CalendarProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.Calendar.CalendarProvider, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""FileServiceHandler.ashx_*"" path=""FileServiceHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.FileServiceHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""Login.ashx_*"" path=""Login.ashx"" verb=""*"" type=""Hyland.Controls.Web.Login.LoginHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""NoteHandler.ashx_*"" path=""NoteHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.NoteHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PrintHandler.ashx_*"" path=""PrintHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.PrintHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Controls.Web.GenericViewer -->
      <add name=""GVCDocActions.ashx_*"" path=""GVCDocActions.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.GVCDocActions, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""IDOLDocumentHandler.ashx_*"" path=""IDOLDocumentHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.IDOLDocumentHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageProvider.ashx_*"" path=""ImageProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.UtilityControls.ImageViewer.ImageProvider, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""MarkupLanguageHandler.ashx_*"" path=""MarkupLanguageHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.MarkupLanguageHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""OleHandler.ashx_*"" path=""OleHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.OleHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PdfHandler.ashx_*"" path=""PdfHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.PdfHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""WopiHandler.ashx_*"" path=""WopiHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.WopiHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Controls.Web.Viewer -->
      <add name=""ThumbnailHandler.ashx_GET"" path=""ThumbnailHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ThumbnailHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ImageHandler.ashx_GET"" path=""ImageHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ImageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Applications.Web.PatientWindow -->
      <add name=""ExceptionMessage.ashx_*"" path=""ExceptionMessage.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.ExceptionMessageHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Applications.Web.PatientWindow.Controls -->
      <add name=""ChartSearchHandler.ashx_*"" path=""ChartSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.Search.ChartSearchHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""DocumentCorrectionActionHandler.ashx_*"" path=""DocumentCorrectionActionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.DocumentCorrectionAction.DocumentCorrectionActionHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""PatientSearchHandler.ashx_*"" path=""PatientSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.Search.PatientSearchHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""ScheduledPatientSearchHandler.ashx_*"" path=""ScheduledPatientSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.Search.ScheduledPatientSearchHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UniversalListControlHandler.ashx_*"" path=""UniversalListControlHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.List.UniversalListControlHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Applications.Web.PatientWindow.Dialogs -->
      <add name=""ConfidentialityCodesHandler.ashx_*"" path=""ConfidentialityCodesHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Dialogs.ConfidentialityCodesHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <add name=""UserOptionsHandler.ashx_*"" path=""UserOptionsHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Dialogs.UserOptionsHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
      <!-- Hyland.Controls.Web.Medical -->
      <add name=""ConfidentialityNoticeHandler.ashx_*"" path=""ConfidentialityNoticeHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.Medical.ConfidentialityNoticeControls.ConfidentialityNoticeHandler, Hyland.Controls.Web.Medical"" preCondition=""integratedMode,runtimeVersionv4.0"" />
    </handlers>
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
    <security>
      <authentication>
        <anonymousAuthentication enabled=""true"" />
        <windowsAuthentication enabled=""true"" />
      </authentication>
    </security>
  </system.webServer>
  <!--
  The system.identityModel section is used to enable Windows Identity Foundation options.

  The audienceUri identifies the relying party (RP - this application).  This much exactly (case, trailing slash, etc.) match the Relying Party Trust Identifier on the ADFS sever.
  The certificate identified by the thumbprint in the trustedIssuers element is the token-signing certificate found on the ADFS server.
  -->
  <!--<system.identityModel><identityConfiguration saveBootstrapContext=""true""><securityTokenHandlers><securityTokenHandlerConfiguration><audienceUris><add value=""https://Audience/URI/"" /><add value=""https://dummy/dummy/"" /></audienceUris><issuerNameRegistry type=""System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089""><trustedIssuers><add thumbprint=""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"" name=""Optional_Friendly_Name_For_The_Certificate"" /><add thumbprint=""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"" name=""Other_Friendly_Name"" /></trustedIssuers></issuerNameRegistry></securityTokenHandlerConfiguration></securityTokenHandlers></identityConfiguration></system.identityModel>-->
  <!--
  system.identityModel.services is used to configure authentication using the WS-Federation protocol.

  wsFederation node
    The 'issuer' attribute specifies the URI of the token issuer.  It sets the base URL for authentication requests.
    The 'realm' attribute specifies the URI used to identify the relying party (RP - this application).  This much exactly (case, trailing slash, etc.) match the Relying Party Trust Identifier on the ADFS sever.

  The certificate identified by the certificateReference element is the encryption certificate configured on the Relying Party Trust on the ADFS server.
  -->
  <!--<system.identityModel.services><federationConfiguration requireSsl=""false""><wsFederation issuer=""https://issuer/URI/adfs/ls/"" realm=""https://Audience/URI/"" /><serviceCertificate><certificateReference x509FindType=""FindByThumbprint"" findValue=""ZYXWVUTSRQPONMLKJIHGFEDCBA0987654321ZYXW"" storeLocation=""LocalMachine"" storeName=""My"" /></serviceCertificate></federationConfiguration></system.identityModel.services>-->
  <runtime>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""Microsoft.Extensions.DependencyInjection.Abstractions"" publicKeyToken=""adb9793829ddae60"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-2.1.1.0"" newVersion=""2.1.1.0"" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""Microsoft.Extensions.Logging.Abstractions"" publicKeyToken=""adb9793829ddae60"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-2.1.1.0"" newVersion=""2.1.1.0"" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""Microsoft.Owin"" publicKeyToken=""31bf3856ad364e35"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-4.0.1.0"" newVersion=""4.0.1.0"" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""Newtonsoft.Json"" publicKeyToken=""30ad4fe6b2a6aeed"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-11.0.0.0"" newVersion=""11.0.0.0"" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""System.Buffers"" publicKeyToken=""cc7b13ffcd2ddd51"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-4.0.3.0"" newVersion=""4.0.3.0"" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""System.Configuration.ConfigurationManager"" publicKeyToken=""cc7b13ffcd2ddd51"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-4.0.3.0"" newVersion=""4.0.3.0"" />
      </dependentAssembly>
    </assemblyBinding>
    <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
      <dependentAssembly>
        <assemblyIdentity name=""System.Runtime.CompilerServices.Unsafe"" publicKeyToken=""b03f5f7f11d50a3a"" culture=""neutral"" />
        <bindingRedirect oldVersion=""0.0.0.0-4.0.6.0"" newVersion=""4.0.6.0"" />
      </dependentAssembly>
    </assemblyBinding>
  </runtime>
</configuration>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "ADFS", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test31()
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
    public void Test32()
    {
        //Testing the Prebuilding of the 231 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
            {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test33()
    {
        //Testing the Prebuilding of the 231 appSettings section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://[WEB SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATA SOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Enable-Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSplitView"",""type"":""1"",""htmlIdName"":""Enable-Split-View"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientSearch"",""type"":""1"",""htmlIdName"":""Enable-Patient-Search"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientContextSyncing"",""type"":""1"",""htmlIdName"":""Enable-Patient-Context-Syncing"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableTimestamp"",""type"":""1"",""htmlIdName"":""Enable-Timestamp"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TimestampTimeLimit"",""type"":""2"",""htmlIdName"":""Timestamp-Time-Limit"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableWorkstationNameDNSLookup"",""type"":""1"",""htmlIdName"":""Enable-Workstation-Name-DNS-Lookup"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListAllowCaching"",""type"":""1"",""htmlIdName"":""Allow-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxWidth"",""type"":""2"",""htmlIdName"":""Maximum-Width"",""Value"":""140"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxHeight"",""type"":""2"",""htmlIdName"":""Maximum-Height"",""Value"":""175"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxWidth"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Width"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxHeight"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Height"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HTMLOnlyDocumentsPrintAsPDFs"",""type"":""1"",""htmlIdName"":""HTML-Only-Documents-Print-As-PDFs"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SystemListDisplayLabel"",""type"":""2"",""htmlIdName"":""System-List-Display-Label"",""Value"":""System List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PersonalListDisplayLabel"",""type"":""2"",""htmlIdName"":""Personal-List-Display-Label"",""Value"":""Personal List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SelectedTabSingleColor"",""type"":""2"",""htmlIdName"":""Selected-Tab-Single-Color"",""Value"":""#000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""__EnableEFormStandardPrinting"",""type"":""1"",""htmlIdName"":""Enable-EForm-Standard-Printing"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FederatedSearchWithMPI"",""type"":""1"",""htmlIdName"":""Federated-Search-With-MPI"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HideToolbarPrintButton"",""type"":""1"",""htmlIdName"":""Hide-Toolbar-Print-Button"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""autoDisplayNotePanelPDFOffice"",""type"":""1"",""htmlIdName"":""Auto-Display-Note-Panel-PDF-Office"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogTitle"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Title"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogMessage"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogOtherReasonLabel"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Other-Reason-Label"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowEmergencyAccessShowDocumentsCheckboxes"",""type"":""1"",""htmlIdName"":""Show-Emergency-Access-Show-Documents-Checkboxes"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowOtherReasonInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Show-Other-Reason-In-Emergency-Access-Dialog"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserPdfViewer"",""type"":""1"",""htmlIdName"":""Enable-Bowser-PDF-Viewer"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""KeywordPanelViewType"",""type"":""2"",""htmlIdName"":""Keyword-Panel-View-Type"",""Value"":""flat"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""workflowMenu"",""type"":""1"",""htmlIdName"":""Workflow-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""createDocumentMenu"",""type"":""1"",""htmlIdName"":""Create-Document-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""fileMenu"",""type"":""1"",""htmlIdName"":""File-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""sendToPrintQueueMenu"",""type"":""1"",""htmlIdName"":""Send-To-Print-Queue-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""reindexMenu"",""type"":""1"",""htmlIdName"":""Re-Index-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","dmsVirtualRoot","2","Virtual-Directory","https://[WEB SERVER]/[VIRTUAL ROOT]","","",""},
            {"appSettings","add","dmsDataSource","2","Data-Source","[DATA SOURCE]","","",""},
            {"appSettings","add","AllowViewSource","1","Allow-View-Source","true","","",""},
            {"appSettings","add","EnableSessionExpiration","1","Enable-Session-Expiration","true","","",""},
            {"appSettings","add","PromptOnSessionExpire","1","Prompt-On-Session-Expire","true","","",""},
            {"appSettings","add","webtheme","2","Web-Theme","XP","","",""},
            {"appSettings","add","default_username","2","Default-Username","","","",""},
            {"appSettings","add","default_password","2","Default-Password","","","",""},
            {"appSettings","add","enableDefaultLogin","1","Enable-Default-Login","false","","",""},
            {"appSettings","add","EnableAutoLogin","1","Autologin","false","","",""},
            {"appSettings","add","forceSSOAutoLoginOverDomain","1","Force-OnBase-Authentication","false","","",""},
            {"appSettings","add","EnableSplitView","1","Enable-Split-View","true","","",""},
            {"appSettings","add","EnablePatientSearch","1","Enable-Patient-Search","false","","",""},
            {"appSettings","add","EnablePatientContextSyncing","1","Enable-Patient-Context-Syncing","false","","",""},
            {"appSettings","add","EnableTimestamp","1","Enable-Timestamp","false","","",""},
            {"appSettings","add","TimestampTimeLimit","2","Timestamp-Time-Limit","5","","",""},
            {"appSettings","add","EnableWorkstationNameDNSLookup","1","Enable-Workstation-Name-DNS-Lookup","false","","",""},
            {"appSettings","add","enableRowColoring","1","Row-Coloring","true","","",""},
            {"appSettings","add","ThumbnailHitListAllowCaching","1","Allow-Caching","false","","",""},
            {"appSettings","add","ThumbnailHitListThumbnailMaxWidth","2","Maximum-Width","140","","",""},
            {"appSettings","add","ThumbnailHitListThumbnailMaxHeight","2","Maximum-Height","175","","",""},
            {"appSettings","add","ThumbnailHitListPreviewMaxWidth","2","Preview-Maximum-Width","1000","","",""},
            {"appSettings","add","ThumbnailHitListPreviewMaxHeight","2","Preview-Maximum-Height","1000","","",""},
            {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
            {"appSettings","add","PreventViewerClientCaching","1","Prevent-Viewer-Client-Caching","true","","",""},
            {"appSettings","add","HTMLOnlyDocumentsPrintAsPDFs","1","HTML-Only-Documents-Print-As-PDFs","true","","",""},
            {"appSettings","add","SystemListDisplayLabel","2","System-List-Display-Label","System List","","",""},
            {"appSettings","add","PersonalListDisplayLabel","2","Personal-List-Display-Label","Personal List","","",""},
            {"appSettings","add","SelectedTabSingleColor","2","Selected-Tab-Single-Color","#000000","","",""},
            {"appSettings","add","__EnableEFormStandardPrinting","1","Enable-EForm-Standard-Printing","true","","",""},
            {"appSettings","add","FederatedSearchWithMPI","1","Federated-Search-With-MPI","false","","",""},
            {"appSettings","add","HideToolbarPrintButton","1","Hide-Toolbar-Print-Button","false","","",""},
            {"appSettings","add","autoDisplayNotePanelPDFOffice","1","Auto-Display-Note-Panel-PDF-Office","true","","",""},
            {"appSettings","add","IdPUrl","2","","","","",""},
            {"appSettings","add","EmergencyAccessDialogTitle","2","Emergency-Access-Dialog-Title","","","",""},
            {"appSettings","add","EmergencyAccessDialogMessage","2","Emergency-Access-Dialog-Message","","","",""},
            {"appSettings","add","EmergencyAccessDialogOtherReasonLabel","2","Emergency-Access-Dialog-Other-Reason-Label","","","",""},
            {"appSettings","add","ShowEmergencyAccessShowDocumentsCheckboxes","1","Show-Emergency-Access-Show-Documents-Checkboxes","true","","",""},
            {"appSettings","add","ShowOtherReasonInEmergencyAccessDialog","1","Show-Other-Reason-In-Emergency-Access-Dialog","true","","",""},
            {"appSettings","add","OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog","1","Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog","false","","",""},
            {"appSettings","add","EnableBrowserPdfViewer","1","Enable-Bowser-PDF-Viewer","false","","",""},
            {"appSettings","add","KeywordPanelViewType","2","Keyword-Panel-View-Type","flat","","",""},
            {"appSettings","add","workflowMenu","1","Workflow-Menu","false","","",""},
            {"appSettings","add","createDocumentMenu","1","Create-Document-Menu","false","","",""},
            {"appSettings","add","fileMenu","1","File-Menu","false","","",""},
            {"appSettings","add","sendToPrintQueueMenu","1","Send-To-Print-Queue-Menu","false","","",""},
            {"appSettings","add","reindexMenu","1","Re-Index-Menu","false","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test34()
    {
        //Testing the Prebuilding of the 231 Hyland.Authentication section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Authentication"",""PathName"":""adfs"",""AttributeName"":""enabled"",""type"":""1"",""htmlIdName"":""ADFS-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
                {"Hyland.Authentication","adfs","enabled","1","ADFS-Enabled","false","","",""}
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
    public void Test44()
    {
        //Testing the Prebuilding of the 231 system.web.extensions section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""2097152"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web.extensions","scripting/webServices/jsonSerialization","maxJsonLength","2","JSON-Serialization-Max-Length","2097152","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test36()
    {
        //Testing the parsing of the 231 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://[APP SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
        <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
        <ApplicationServer Url=""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"" ServiceClientType=""Remoting"" />
        <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
        <StreamingSettings BufferSize=""64000"" />
      </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test37()
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
    public void Test38()
    {
        //Testing the parsing of the 231 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://[WEB SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATA SOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Enable-Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSplitView"",""type"":""1"",""htmlIdName"":""Enable-Split-View"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientSearch"",""type"":""1"",""htmlIdName"":""Enable-Patient-Search"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientContextSyncing"",""type"":""1"",""htmlIdName"":""Enable-Patient-Context-Syncing"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableTimestamp"",""type"":""1"",""htmlIdName"":""Enable-Timestamp"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TimestampTimeLimit"",""type"":""2"",""htmlIdName"":""Timestamp-Time-Limit"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableWorkstationNameDNSLookup"",""type"":""1"",""htmlIdName"":""Enable-Workstation-Name-DNS-Lookup"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListAllowCaching"",""type"":""1"",""htmlIdName"":""Allow-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxWidth"",""type"":""2"",""htmlIdName"":""Maximum-Width"",""Value"":""140"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxHeight"",""type"":""2"",""htmlIdName"":""Maximum-Height"",""Value"":""175"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxWidth"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Width"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxHeight"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Height"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HTMLOnlyDocumentsPrintAsPDFs"",""type"":""1"",""htmlIdName"":""HTML-Only-Documents-Print-As-PDFs"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SystemListDisplayLabel"",""type"":""2"",""htmlIdName"":""System-List-Display-Label"",""Value"":""System List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PersonalListDisplayLabel"",""type"":""2"",""htmlIdName"":""Personal-List-Display-Label"",""Value"":""Personal List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SelectedTabSingleColor"",""type"":""2"",""htmlIdName"":""Selected-Tab-Single-Color"",""Value"":""#000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""__EnableEFormStandardPrinting"",""type"":""1"",""htmlIdName"":""Enable-EForm-Standard-Printing"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FederatedSearchWithMPI"",""type"":""1"",""htmlIdName"":""Federated-Search-With-MPI"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HideToolbarPrintButton"",""type"":""1"",""htmlIdName"":""Hide-Toolbar-Print-Button"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""autoDisplayNotePanelPDFOffice"",""type"":""1"",""htmlIdName"":""Auto-Display-Note-Panel-PDF-Office"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogTitle"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Title"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogMessage"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogOtherReasonLabel"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Other-Reason-Label"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowEmergencyAccessShowDocumentsCheckboxes"",""type"":""1"",""htmlIdName"":""Show-Emergency-Access-Show-Documents-Checkboxes"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowOtherReasonInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Show-Other-Reason-In-Emergency-Access-Dialog"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserPdfViewer"",""type"":""1"",""htmlIdName"":""Enable-Bowser-PDF-Viewer"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""KeywordPanelViewType"",""type"":""2"",""htmlIdName"":""Keyword-Panel-View-Type"",""Value"":""flat"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""workflowMenu"",""type"":""1"",""htmlIdName"":""Workflow-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""createDocumentMenu"",""type"":""1"",""htmlIdName"":""Create-Document-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""fileMenu"",""type"":""1"",""htmlIdName"":""File-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""sendToPrintQueueMenu"",""type"":""1"",""htmlIdName"":""Send-To-Print-Queue-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""reindexMenu"",""type"":""1"",""htmlIdName"":""Re-Index-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://[WEB SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATA SOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Enable-Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSplitView"",""type"":""1"",""htmlIdName"":""Enable-Split-View"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientSearch"",""type"":""1"",""htmlIdName"":""Enable-Patient-Search"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientContextSyncing"",""type"":""1"",""htmlIdName"":""Enable-Patient-Context-Syncing"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableTimestamp"",""type"":""1"",""htmlIdName"":""Enable-Timestamp"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TimestampTimeLimit"",""type"":""2"",""htmlIdName"":""Timestamp-Time-Limit"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableWorkstationNameDNSLookup"",""type"":""1"",""htmlIdName"":""Enable-Workstation-Name-DNS-Lookup"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListAllowCaching"",""type"":""1"",""htmlIdName"":""Allow-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxWidth"",""type"":""2"",""htmlIdName"":""Maximum-Width"",""Value"":""140"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxHeight"",""type"":""2"",""htmlIdName"":""Maximum-Height"",""Value"":""175"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxWidth"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Width"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxHeight"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Height"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HTMLOnlyDocumentsPrintAsPDFs"",""type"":""1"",""htmlIdName"":""HTML-Only-Documents-Print-As-PDFs"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SystemListDisplayLabel"",""type"":""2"",""htmlIdName"":""System-List-Display-Label"",""Value"":""System List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PersonalListDisplayLabel"",""type"":""2"",""htmlIdName"":""Personal-List-Display-Label"",""Value"":""Personal List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SelectedTabSingleColor"",""type"":""2"",""htmlIdName"":""Selected-Tab-Single-Color"",""Value"":""#000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""__EnableEFormStandardPrinting"",""type"":""1"",""htmlIdName"":""Enable-EForm-Standard-Printing"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FederatedSearchWithMPI"",""type"":""1"",""htmlIdName"":""Federated-Search-With-MPI"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HideToolbarPrintButton"",""type"":""1"",""htmlIdName"":""Hide-Toolbar-Print-Button"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""autoDisplayNotePanelPDFOffice"",""type"":""1"",""htmlIdName"":""Auto-Display-Note-Panel-PDF-Office"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogTitle"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Title"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogMessage"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogOtherReasonLabel"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Other-Reason-Label"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowEmergencyAccessShowDocumentsCheckboxes"",""type"":""1"",""htmlIdName"":""Show-Emergency-Access-Show-Documents-Checkboxes"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowOtherReasonInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Show-Other-Reason-In-Emergency-Access-Dialog"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserPdfViewer"",""type"":""1"",""htmlIdName"":""Enable-Bowser-PDF-Viewer"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""KeywordPanelViewType"",""type"":""2"",""htmlIdName"":""Keyword-Panel-View-Type"",""Value"":""flat"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""workflowMenu"",""type"":""1"",""htmlIdName"":""Workflow-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""createDocumentMenu"",""type"":""1"",""htmlIdName"":""Create-Document-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""fileMenu"",""type"":""1"",""htmlIdName"":""File-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""sendToPrintQueueMenu"",""type"":""1"",""htmlIdName"":""Send-To-Print-Queue-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""reindexMenu"",""type"":""1"",""htmlIdName"":""Re-Index-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":{""ServerLocation"":"""",""Tenant"":"""",""Client"":"""",""Secret"":""""},""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<appSettings file=""version.xml"">
        <add key=""dmsVirtualRoot"" value=""https://[WEB SERVER]/[VIRTUAL ROOT]"" />
        <add key=""dmsDataSource"" value=""[DATA SOURCE]"" />
        <add key=""AllowViewSource"" value=""true"" />
        <!-- Session timeout variables -->
        <add key=""EnableSessionExpiration"" value=""true"" />
        <add key=""PromptOnSessionExpire"" value=""true"" />
        <add key=""webtheme"" value=""XP"" />
        <add key=""default_username"" value="""" />
        <add key=""default_password"" value="""" />
        <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
        <add key=""enableDefaultLogin"" value=""false"" />
        <add key=""EnableAutoLogin"" value=""false"" />
        <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
        <!-- Enables the Split View / Cross Reference Document user interface. -->
        <add key=""EnableSplitView"" value=""true"" />
        <!-- Enables the Patient Search interface for non-admin users-->
        <add key=""EnablePatientSearch"" value=""false"" />
        <!-- Enables Patient Context Syncing -->
        <add key=""EnablePatientContextSyncing"" value=""false"" />
        <!-- Enables enforcement of UTC-based timestamp -->
        <add key=""EnableTimestamp"" value=""false"" />
        <!-- The amount of time in minutes the UTC-based timestamp is valid -->
        <add key=""TimestampTimeLimit"" value=""5"" />
        <!-- Enable hostname DNS lookup by IP when workstationName is not included as a request parameter-->
        <add key=""EnableWorkstationNameDNSLookup"" value=""false"" />
        <!--Settings respected by ULC controls-->
        <add key=""enableRowColoring"" value=""true"" />
        <!-- Settings for Thumbnail HitList Viewer -->
        <!-- Whether to allow web server caching of images -->
        <add key=""ThumbnailHitListAllowCaching"" value=""false"" />
        <add key=""ThumbnailHitListThumbnailMaxWidth"" value=""140"" />
        <add key=""ThumbnailHitListThumbnailMaxHeight"" value=""175"" />
        <add key=""ThumbnailHitListPreviewMaxWidth"" value=""1000"" />
        <add key=""ThumbnailHitListPreviewMaxHeight"" value=""1000"" />
        <!-- This setting controls if the server will accept only https connections or not. 
             If you set this to false all incoming requests have to be made over https. 
             If you set this to true then both http and https connections are accepted. 
             The recommended setting is false.-->
        <add key=""AllowInsecureConnection"" value=""false"" />
        <!-- Preventing caching will impact Viewer performance -->
        <add key=""PreventViewerClientCaching"" value=""true"" />
        <add key=""HTMLOnlyDocumentsPrintAsPDFs"" value=""true"" />
        <!-- These settings specify the labels of UI components related to System (Dynamic) List and Personal (Static) List functionality-->
        <add key=""SystemListDisplayLabel"" value=""System List"" />
        <add key=""PersonalListDisplayLabel"" value=""Personal List"" />
        <!-- The selected tab in OPW will be set to the color specified. Set the value to a RGB hex color value, i.e. #FF0000 is red, #0000FF is blue, or friendly name, red, blue, green, etc. -->
        <add key=""SelectedTabSingleColor"" value=""#000000"" />
        <add key=""__EnableEFormStandardPrinting"" value=""true"" />
        <!-- By default, ad-hoc federated searches via the ""Find More Studies"" button occur with all of the known Medical Record Numbers for the patient.
             Setting this value to true will use the Master Patient Index Number instead. -->
        <add key=""FederatedSearchWithMPI"" value=""false"" />
        <add key=""HideToolbarPrintButton"" value=""false"" />
        <add key=""autoDisplayNotePanelPDFOffice"" value=""true"" />
        <add key=""IdPUrl"" value="""" />
        <add key=""EmergencyAccessDialogTitle"" value="""" />
        <add key=""EmergencyAccessDialogMessage"" value="""" />
        <add key=""EmergencyAccessDialogOtherReasonLabel"" value="""" />
        <add key=""ShowEmergencyAccessShowDocumentsCheckboxes"" value=""true"" />
        <add key=""ShowOtherReasonInEmergencyAccessDialog"" value=""true"" />
        <add key=""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"" value=""false"" />
      </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test39()
    {
        //Testing the parsing of the 231 Hyland.Authentication section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Authentication"",""PathName"":""adfs"",""AttributeName"":""enabled"",""type"":""1"",""htmlIdName"":""ADFS-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Authentication"",""PathName"":""adfs"",""AttributeName"":""enabled"",""type"":""1"",""htmlIdName"":""ADFS-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Authentication>
        <adfs enabled=""false"" synchronizeUserAttributes=""true"" authenticationOnly=""2.0"" />
      </Hyland.Authentication>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Authentication", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test40()
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

        For Patient Window, impersonation is (most likely) not needed. The default account of
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
        <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
        <authentication mode=""Windows"" />
      </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test41()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Validate-Against-Checksum"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Checksum-Key"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Validate-Against-Checksum"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Checksum-Key"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test42()
    {
        //Testing the parsing of the 231 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure231WithVersionNumber);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""23.1.7.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""Hyland Application Server""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":{""OutputFormat"":""Minimal""},""RouteType"":""Console"",""Name"":""Console"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""5"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":{""SourceName"":""Hyland""},""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":null,""RouteType"":""EventLog"",""Name"":""ErrorEventLog"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
        <WindowsEventLogging sourcename=""Hyland Application Server"" />
        <Routes>
          <Route name=""Console"">
            <add key=""minimum-level"" value=""Information"" />
            <add key=""maximum-level"" value=""Critical"" />
            <add key=""Console"" />
            <add key=""OutputFormat"" value=""Minimal"" />
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
          <Route name=""ErrorEventLog"">
            <add key=""minimum-level"" value=""Error"" />
            <add key=""maximum-level"" value=""Critical"" />
            <add key=""EventLog"" value=""Hyland"" />
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
    public void Test43()
    {
        //Testing the parsing of the 231 ADFS section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":{""systemIdentityModel"":{""audienceUris"":[{""URI"":""https://Audience/URI/"",""id"":null},{""URI"":""https://dummy/dummy/"",""id"":null}],""trustedIssuers"":[{""Thumbprint"":""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"",""Name"":""Optional_Friendly_Name_For_The_Certificate"",""id"":null},{""Thumbprint"":""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"",""Name"":""Other_Friendly_Name"",""id"":null}]},""systemIdentityModelServices"":{""wsFederation"":{""Issuer"":""https://issuer/URI/adfs/ls/"",""Realm"":""https://Audience/URI/""},""serviceCertificate"":{""X509FindType"":""FindByThumbprint"",""FindValue"":""ZYXWVUTSRQPONMLKJIHGFEDCBA0987654321ZYXW"",""StoreLocation"":""LocalMachine"",""StoreName"":""My""},""CookieHandlerRequireSSL"":""false""},""knownKeys"":[],""ADFSEnabled"":""false"",""RequestValidationMode"":""2.0"",""AuthenticationMode"":""Windows"",""SynchronizeUserAttributes"":""true"",""AuthenticationOnly"":""2.0""},""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<configuration>
      <configSections>
        <section name=""Hyland.Services.Client"" type=""Hyland.Services.Client.ServiceClientConfiguration,Hyland.Services.Client"" />
        <section name=""Hyland.Logging"" type=""Hyland.Logging.Configuration.ClientConfigurationHandler,Hyland.Logging"" />
        <section name=""Hyland.Web.HealthcarePop"" type=""Hyland.Applications.Web.ConfigSections.HealthcarePopConfigSection, Hyland.Applications.Web"" />
        <!-- ADFS sections -->
        <section name=""Hyland.Authentication"" type=""Hyland.Authentication.Configuration.AuthenticationConfigurationSection, Hyland.Authentication"" />
        <section name=""system.identityModel"" type=""System.IdentityModel.Configuration.SystemIdentityModelSection, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"" />
        <section name=""system.identityModel.services"" type=""System.IdentityModel.Services.Configuration.SystemIdentityModelServicesSection, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"" />
        <!-- End ADFS sections -->
      </configSections>
      <Hyland.Services.Client>
        <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
        <ApplicationServer Url=""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"" ServiceClientType=""Remoting"" />
        <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
        <StreamingSettings BufferSize=""64000"" />
      </Hyland.Services.Client>
      <Hyland.Logging TruncateLogValues=""1024"">
        <WindowsEventLogging sourcename=""Hyland Application Server"" />
        <Routes>
          <Route name=""Console"">
            <add key=""minimum-level"" value=""Information"" />
            <add key=""maximum-level"" value=""Critical"" />
            <add key=""Console"" />
            <add key=""OutputFormat"" value=""Minimal"" />
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
          <Route name=""ErrorEventLog"">
            <add key=""minimum-level"" value=""Error"" />
            <add key=""maximum-level"" value=""Critical"" />
            <add key=""EventLog"" value=""Hyland"" />
            <add key=""DisableIPAddressMasking"" value=""True"" />
            <add key=""include-profiles"" value="""" />
            <add key=""exclude-profiles"" value="""" />
          </Route>
        </Routes>
        <AuditRoutes />
      </Hyland.Logging>
      <appSettings file=""version.xml"">
        <add key=""dmsVirtualRoot"" value=""https://[WEB SERVER]/[VIRTUAL ROOT]"" />
        <add key=""dmsDataSource"" value=""[DATA SOURCE]"" />
        <add key=""AllowViewSource"" value=""true"" />
        <!-- Session timeout variables -->
        <add key=""EnableSessionExpiration"" value=""true"" />
        <add key=""PromptOnSessionExpire"" value=""true"" />
        <add key=""webtheme"" value=""XP"" />
        <add key=""default_username"" value="""" />
        <add key=""default_password"" value="""" />
        <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
        <add key=""enableDefaultLogin"" value=""false"" />
        <add key=""EnableAutoLogin"" value=""false"" />
        <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
        <!-- Enables the Split View / Cross Reference Document user interface. -->
        <add key=""EnableSplitView"" value=""true"" />
        <!-- Enables the Patient Search interface for non-admin users-->
        <add key=""EnablePatientSearch"" value=""false"" />
        <!-- Enables Patient Context Syncing -->
        <add key=""EnablePatientContextSyncing"" value=""false"" />
        <!-- Enables enforcement of UTC-based timestamp -->
        <add key=""EnableTimestamp"" value=""false"" />
        <!-- The amount of time in minutes the UTC-based timestamp is valid -->
        <add key=""TimestampTimeLimit"" value=""5"" />
        <!-- Enable hostname DNS lookup by IP when workstationName is not included as a request parameter-->
        <add key=""EnableWorkstationNameDNSLookup"" value=""false"" />
        <!--Settings respected by ULC controls-->
        <add key=""enableRowColoring"" value=""true"" />
        <!-- Settings for Thumbnail HitList Viewer -->
        <!-- Whether to allow web server caching of images -->
        <add key=""ThumbnailHitListAllowCaching"" value=""false"" />
        <add key=""ThumbnailHitListThumbnailMaxWidth"" value=""140"" />
        <add key=""ThumbnailHitListThumbnailMaxHeight"" value=""175"" />
        <add key=""ThumbnailHitListPreviewMaxWidth"" value=""1000"" />
        <add key=""ThumbnailHitListPreviewMaxHeight"" value=""1000"" />
        <!-- This setting controls if the server will accept only https connections or not. 
             If you set this to false all incoming requests have to be made over https. 
             If you set this to true then both http and https connections are accepted. 
             The recommended setting is false.-->
        <add key=""AllowInsecureConnection"" value=""false"" />
        <!-- Preventing caching will impact Viewer performance -->
        <add key=""PreventViewerClientCaching"" value=""true"" />
        <add key=""HTMLOnlyDocumentsPrintAsPDFs"" value=""true"" />
        <!-- These settings specify the labels of UI components related to System (Dynamic) List and Personal (Static) List functionality-->
        <add key=""SystemListDisplayLabel"" value=""System List"" />
        <add key=""PersonalListDisplayLabel"" value=""Personal List"" />
        <!-- The selected tab in OPW will be set to the color specified. Set the value to a RGB hex color value, i.e. #FF0000 is red, #0000FF is blue, or friendly name, red, blue, green, etc. -->
        <add key=""SelectedTabSingleColor"" value=""#000000"" />
        <add key=""__EnableEFormStandardPrinting"" value=""true"" />
        <!-- By default, ad-hoc federated searches via the ""Find More Studies"" button occur with all of the known Medical Record Numbers for the patient.
             Setting this value to true will use the Master Patient Index Number instead. -->
        <add key=""FederatedSearchWithMPI"" value=""false"" />
        <add key=""HideToolbarPrintButton"" value=""false"" />
        <add key=""autoDisplayNotePanelPDFOffice"" value=""true"" />
        <add key=""IdPUrl"" value="""" />
        <add key=""EmergencyAccessDialogTitle"" value="""" />
        <add key=""EmergencyAccessDialogMessage"" value="""" />
        <add key=""EmergencyAccessDialogOtherReasonLabel"" value="""" />
        <add key=""ShowEmergencyAccessShowDocumentsCheckboxes"" value=""true"" />
        <add key=""ShowOtherReasonInEmergencyAccessDialog"" value=""true"" />
        <add key=""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"" value=""false"" />
      </appSettings>
      <Hyland.Web.HealthcarePop>
        <EnableChecksum value=""true"" />
        <ChecksumKey value=""Test"" />
        <EnableLegacyChecksumFallback value=""false"" />
      </Hyland.Web.HealthcarePop>
      <Hyland.Authentication>
        <adfs enabled=""false"" synchronizeUserAttributes=""true"" authenticationOnly=""2.0"" />
      </Hyland.Authentication>
      <system.diagnostics>
        <switches>
          <!--
          This switch controls tracing globally through Hyland.Logging.
          It configures the level of information from Trace that is logged.
          For no information set the value to zero. Set the value to 1, 2, 3, or 4 for
          minimal, normal, detailed, or verbose messages, respectively.
          -->
          <add name=""hylandTracing"" value=""0"" />
        </switches>
      </system.diagnostics>
      <configProtectedData>
        <providers>
          <add name=""DpapiProvider"" type=""System.Configuration.DpapiProtectedConfigurationProvider,System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"" />
        </providers>
      </configProtectedData>
      <system.web>
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

        For Patient Window, impersonation is (most likely) not needed. The default account of
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
        <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
        <authentication mode=""Windows"" />
      </system.web>
      <system.webServer>
        <modules runAllManagedModulesForAllRequests=""true"">
          <!--The format for this section should additionally contain the preCondition attribute.-->
          <add name=""OnBaseContextModule"" type=""Hyland.Server.Diagnostics.OnBaseContextModule, Hyland.Server"" preCondition=""managedHandler"" />
          <!-- The following two modules are required for ADFS -->
          <!--add name=""WSFederationAuthenticationModule"" type=""System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
          <!--add name=""SessionAuthenticationModule"" type=""System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
        </modules>
        <validation validateIntegratedModeConfiguration=""false"" />
        <handlers>
          <!-- Hyland.Applications.Web -->
          <add name=""DownloadHandler.ashx_*"" path=""DownloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.DownloadHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""OptimizedServicePipeline.ashx_*"" path=""OptimizedServicePipeline.ashx"" verb=""*"" type=""Hyland.Applications.Web.OptimizedServicePipelineProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""Service.asmx_*"" path=""Service.asmx"" verb=""*"" type=""Hyland.Applications.Web.ServiceHttpHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Applications.Web.Client.Controls -->
          <add name=""NoteType.ashx_*"" verb=""*"" path=""NoteType.ashx"" type=""Hyland.Applications.Web.Client.Controls.NoteType, Hyland.Applications.Web.Client"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Applications.Web.Handlers -->
          <add name=""DocumentActionHandler.ashx_*"" path=""DocumentActionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentActionHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""DocumentDataHandler.ashx_*"" path=""DocumentDataHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentDataHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""FormProc.ashx_*"" path=""FormProc.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.FormProc, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""ScriptExceptionHandler.ashx_*"" path=""ScriptExceptionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.ScriptExceptionHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Applications.Web.WindowsManager -->
          <add name=""UnloadHandler.ashx_*"" path=""UnloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.UnloadHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""WindowDirector.ashx_*"" path=""WindowDirector.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.WindowDirector, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Controls.Web -->
          <add name=""CalendarProvider.ashx_*"" path=""CalendarProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.Calendar.CalendarProvider, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""FileServiceHandler.ashx_*"" path=""FileServiceHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.FileServiceHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""Login.ashx_*"" path=""Login.ashx"" verb=""*"" type=""Hyland.Controls.Web.Login.LoginHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""NoteHandler.ashx_*"" path=""NoteHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.NoteHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""PrintHandler.ashx_*"" path=""PrintHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.PrintHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Controls.Web.GenericViewer -->
          <add name=""GVCDocActions.ashx_*"" path=""GVCDocActions.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.GVCDocActions, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""IDOLDocumentHandler.ashx_*"" path=""IDOLDocumentHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.IDOLDocumentHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""ImageProvider.ashx_*"" path=""ImageProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.UtilityControls.ImageViewer.ImageProvider, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""MarkupLanguageHandler.ashx_*"" path=""MarkupLanguageHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.MarkupLanguageHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""OleHandler.ashx_*"" path=""OleHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.OleHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""PdfHandler.ashx_*"" path=""PdfHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.PdfHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""WopiHandler.ashx_*"" path=""WopiHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.WopiHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Controls.Web.Viewer -->
          <add name=""ThumbnailHandler.ashx_GET"" path=""ThumbnailHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ThumbnailHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""ImageHandler.ashx_GET"" path=""ImageHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ImageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Applications.Web.PatientWindow -->
          <add name=""ExceptionMessage.ashx_*"" path=""ExceptionMessage.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.ExceptionMessageHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Applications.Web.PatientWindow.Controls -->
          <add name=""ChartSearchHandler.ashx_*"" path=""ChartSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.Search.ChartSearchHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""DocumentCorrectionActionHandler.ashx_*"" path=""DocumentCorrectionActionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.DocumentCorrectionAction.DocumentCorrectionActionHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""PatientSearchHandler.ashx_*"" path=""PatientSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.Search.PatientSearchHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""ScheduledPatientSearchHandler.ashx_*"" path=""ScheduledPatientSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.Search.ScheduledPatientSearchHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""UniversalListControlHandler.ashx_*"" path=""UniversalListControlHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.List.UniversalListControlHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Applications.Web.PatientWindow.Dialogs -->
          <add name=""ConfidentialityCodesHandler.ashx_*"" path=""ConfidentialityCodesHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Dialogs.ConfidentialityCodesHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""UserOptionsHandler.ashx_*"" path=""UserOptionsHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Dialogs.UserOptionsHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Controls.Web.Medical -->
          <add name=""ConfidentialityNoticeHandler.ashx_*"" path=""ConfidentialityNoticeHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.Medical.ConfidentialityNoticeControls.ConfidentialityNoticeHandler, Hyland.Controls.Web.Medical"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        </handlers>
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
        <security>
          <authentication>
            <anonymousAuthentication enabled=""true"" />
            <windowsAuthentication enabled=""true"" />
          </authentication>
        </security>
      </system.webServer>
      <!--
      The system.identityModel section is used to enable Windows Identity Foundation options.

      The audienceUri identifies the relying party (RP - this application).  This much exactly (case, trailing slash, etc.) match the Relying Party Trust Identifier on the ADFS sever.
      The certificate identified by the thumbprint in the trustedIssuers element is the token-signing certificate found on the ADFS server.
      -->
      <!--<system.identityModel><identityConfiguration saveBootstrapContext=""true""><securityTokenHandlers><securityTokenHandlerConfiguration><audienceUris><add value=""https://Audience/URI/"" /><add value=""https://dummy/dummy/"" /></audienceUris><issuerNameRegistry type=""System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089""><trustedIssuers><add thumbprint=""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"" name=""Optional_Friendly_Name_For_The_Certificate"" /><add thumbprint=""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"" name=""Other_Friendly_Name"" /></trustedIssuers></issuerNameRegistry></securityTokenHandlerConfiguration></securityTokenHandlers></identityConfiguration></system.identityModel>-->
      <!--
      system.identityModel.services is used to configure authentication using the WS-Federation protocol.

      wsFederation node
        The 'issuer' attribute specifies the URI of the token issuer.  It sets the base URL for authentication requests.
        The 'realm' attribute specifies the URI used to identify the relying party (RP - this application).  This much exactly (case, trailing slash, etc.) match the Relying Party Trust Identifier on the ADFS sever.

      The certificate identified by the certificateReference element is the encryption certificate configured on the Relying Party Trust on the ADFS server.
      -->
      <!--<system.identityModel.services><federationConfiguration requireSsl=""false""><wsFederation issuer=""https://issuer/URI/adfs/ls/"" realm=""https://Audience/URI/"" /><serviceCertificate><certificateReference x509FindType=""FindByThumbprint"" findValue=""ZYXWVUTSRQPONMLKJIHGFEDCBA0987654321ZYXW"" storeLocation=""LocalMachine"" storeName=""My"" /></serviceCertificate></federationConfiguration></system.identityModel.services>-->
      <runtime>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""Microsoft.Extensions.DependencyInjection.Abstractions"" publicKeyToken=""adb9793829ddae60"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-2.1.1.0"" newVersion=""2.1.1.0"" />
          </dependentAssembly>
        </assemblyBinding>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""Microsoft.Extensions.Logging.Abstractions"" publicKeyToken=""adb9793829ddae60"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-2.1.1.0"" newVersion=""2.1.1.0"" />
          </dependentAssembly>
        </assemblyBinding>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""Microsoft.Owin"" publicKeyToken=""31bf3856ad364e35"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-4.0.1.0"" newVersion=""4.0.1.0"" />
          </dependentAssembly>
        </assemblyBinding>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""Newtonsoft.Json"" publicKeyToken=""30ad4fe6b2a6aeed"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-11.0.0.0"" newVersion=""11.0.0.0"" />
          </dependentAssembly>
        </assemblyBinding>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""System.Buffers"" publicKeyToken=""cc7b13ffcd2ddd51"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-4.0.3.0"" newVersion=""4.0.3.0"" />
          </dependentAssembly>
        </assemblyBinding>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""System.Configuration.ConfigurationManager"" publicKeyToken=""cc7b13ffcd2ddd51"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-4.0.3.0"" newVersion=""4.0.3.0"" />
          </dependentAssembly>
        </assemblyBinding>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""System.Runtime.CompilerServices.Unsafe"" publicKeyToken=""b03f5f7f11d50a3a"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-4.0.6.0"" newVersion=""4.0.6.0"" />
          </dependentAssembly>
        </assemblyBinding>
      </runtime>
    </configuration>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "ADFS", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test45()
    {
        //Testing the parsing of the 231 system.web.extensions section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""2097152"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""2097152"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.web.extensions>
		<scripting>
			<webServices>
				<jsonSerialization maxJsonLength=""2097152"" />
			</webServices>
		</scripting>
	</system.web.extensions>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web.extensions", xmldoc);

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
        //Testing the Prebuilding of the 241 Hyland.Services.Client section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem","","",""},
            {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
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

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://[WEB SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATA SOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Enable-Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSplitView"",""type"":""1"",""htmlIdName"":""Enable-Split-View"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientSearch"",""type"":""1"",""htmlIdName"":""Enable-Patient-Search"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientContextSyncing"",""type"":""1"",""htmlIdName"":""Enable-Patient-Context-Syncing"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableTimestamp"",""type"":""1"",""htmlIdName"":""Enable-Timestamp"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TimestampTimeLimit"",""type"":""2"",""htmlIdName"":""Timestamp-Time-Limit"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableWorkstationNameDNSLookup"",""type"":""1"",""htmlIdName"":""Enable-Workstation-Name-DNS-Lookup"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListAllowCaching"",""type"":""1"",""htmlIdName"":""Allow-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxWidth"",""type"":""2"",""htmlIdName"":""Maximum-Width"",""Value"":""140"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxHeight"",""type"":""2"",""htmlIdName"":""Maximum-Height"",""Value"":""175"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxWidth"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Width"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxHeight"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Height"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HTMLOnlyDocumentsPrintAsPDFs"",""type"":""1"",""htmlIdName"":""HTML-Only-Documents-Print-As-PDFs"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SystemListDisplayLabel"",""type"":""2"",""htmlIdName"":""System-List-Display-Label"",""Value"":""System List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PersonalListDisplayLabel"",""type"":""2"",""htmlIdName"":""Personal-List-Display-Label"",""Value"":""Personal List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SelectedTabSingleColor"",""type"":""2"",""htmlIdName"":""Selected-Tab-Single-Color"",""Value"":""#000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""__EnableEFormStandardPrinting"",""type"":""1"",""htmlIdName"":""Enable-EForm-Standard-Printing"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FederatedSearchWithMPI"",""type"":""1"",""htmlIdName"":""Federated-Search-With-MPI"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HideToolbarPrintButton"",""type"":""1"",""htmlIdName"":""Hide-Toolbar-Print-Button"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""autoDisplayNotePanelPDFOffice"",""type"":""1"",""htmlIdName"":""Auto-Display-Note-Panel-PDF-Office"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogTitle"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Title"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogMessage"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogOtherReasonLabel"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Other-Reason-Label"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowEmergencyAccessShowDocumentsCheckboxes"",""type"":""1"",""htmlIdName"":""Show-Emergency-Access-Show-Documents-Checkboxes"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowOtherReasonInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Show-Other-Reason-In-Emergency-Access-Dialog"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserPdfViewer"",""type"":""1"",""htmlIdName"":""Enable-Bowser-PDF-Viewer"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""KeywordPanelViewType"",""type"":""2"",""htmlIdName"":""Keyword-Panel-View-Type"",""Value"":""flat"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""workflowMenu"",""type"":""1"",""htmlIdName"":""Workflow-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""createDocumentMenu"",""type"":""1"",""htmlIdName"":""Create-Document-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""fileMenu"",""type"":""1"",""htmlIdName"":""File-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""sendToPrintQueueMenu"",""type"":""1"",""htmlIdName"":""Send-To-Print-Queue-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""reindexMenu"",""type"":""1"",""htmlIdName"":""Re-Index-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","dmsVirtualRoot","2","Virtual-Directory","https://[WEB SERVER]/[VIRTUAL ROOT]","","",""},
            {"appSettings","add","dmsDataSource","2","Data-Source","[DATA SOURCE]","","",""},
            {"appSettings","add","AllowViewSource","1","Allow-View-Source","true","","",""},
            {"appSettings","add","EnableSessionExpiration","1","Enable-Session-Expiration","true","","",""},
            {"appSettings","add","PromptOnSessionExpire","1","Prompt-On-Session-Expire","true","","",""},
            {"appSettings","add","webtheme","2","Web-Theme","XP","","",""},
            {"appSettings","add","default_username","2","Default-Username","","","",""},
            {"appSettings","add","default_password","2","Default-Password","","","",""},
            {"appSettings","add","enableDefaultLogin","1","Enable-Default-Login","false","","",""},
            {"appSettings","add","EnableAutoLogin","1","Autologin","false","","",""},
            {"appSettings","add","forceSSOAutoLoginOverDomain","1","Force-OnBase-Authentication","false","","",""},
            {"appSettings","add","EnableSplitView","1","Enable-Split-View","true","","",""},
            {"appSettings","add","EnablePatientSearch","1","Enable-Patient-Search","false","","",""},
            {"appSettings","add","EnablePatientContextSyncing","1","Enable-Patient-Context-Syncing","false","","",""},
            {"appSettings","add","EnableTimestamp","1","Enable-Timestamp","false","","",""},
            {"appSettings","add","TimestampTimeLimit","2","Timestamp-Time-Limit","5","","",""},
            {"appSettings","add","EnableWorkstationNameDNSLookup","1","Enable-Workstation-Name-DNS-Lookup","false","","",""},
            {"appSettings","add","enableRowColoring","1","Row-Coloring","true","","",""},
            {"appSettings","add","ThumbnailHitListAllowCaching","1","Allow-Caching","false","","",""},
            {"appSettings","add","ThumbnailHitListThumbnailMaxWidth","2","Maximum-Width","140","","",""},
            {"appSettings","add","ThumbnailHitListThumbnailMaxHeight","2","Maximum-Height","175","","",""},
            {"appSettings","add","ThumbnailHitListPreviewMaxWidth","2","Preview-Maximum-Width","1000","","",""},
            {"appSettings","add","ThumbnailHitListPreviewMaxHeight","2","Preview-Maximum-Height","1000","","",""},
            {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
            {"appSettings","add","PreventViewerClientCaching","1","Prevent-Viewer-Client-Caching","true","","",""},
            {"appSettings","add","HTMLOnlyDocumentsPrintAsPDFs","1","HTML-Only-Documents-Print-As-PDFs","true","","",""},
            {"appSettings","add","SystemListDisplayLabel","2","System-List-Display-Label","System List","","",""},
            {"appSettings","add","PersonalListDisplayLabel","2","Personal-List-Display-Label","Personal List","","",""},
            {"appSettings","add","SelectedTabSingleColor","2","Selected-Tab-Single-Color","#000000","","",""},
            {"appSettings","add","__EnableEFormStandardPrinting","1","Enable-EForm-Standard-Printing","true","","",""},
            {"appSettings","add","FederatedSearchWithMPI","1","Federated-Search-With-MPI","false","","",""},
            {"appSettings","add","HideToolbarPrintButton","1","Hide-Toolbar-Print-Button","false","","",""},
            {"appSettings","add","autoDisplayNotePanelPDFOffice","1","Auto-Display-Note-Panel-PDF-Office","true","","",""},
            {"appSettings","add","IdPUrl","2","","","","",""},
            {"appSettings","add","EmergencyAccessDialogTitle","2","Emergency-Access-Dialog-Title","","","",""},
            {"appSettings","add","EmergencyAccessDialogMessage","2","Emergency-Access-Dialog-Message","","","",""},
            {"appSettings","add","EmergencyAccessDialogOtherReasonLabel","2","Emergency-Access-Dialog-Other-Reason-Label","","","",""},
            {"appSettings","add","ShowEmergencyAccessShowDocumentsCheckboxes","1","Show-Emergency-Access-Show-Documents-Checkboxes","true","","",""},
            {"appSettings","add","ShowOtherReasonInEmergencyAccessDialog","1","Show-Other-Reason-In-Emergency-Access-Dialog","true","","",""},
            {"appSettings","add","OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog","1","Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog","false","","",""},
            {"appSettings","add","EnableBrowserPdfViewer","1","Enable-Bowser-PDF-Viewer","false","","",""},
            {"appSettings","add","KeywordPanelViewType","2","Keyword-Panel-View-Type","flat","","",""},
            {"appSettings","add","workflowMenu","1","Workflow-Menu","false","","",""},
            {"appSettings","add","createDocumentMenu","1","Create-Document-Menu","false","","",""},
            {"appSettings","add","fileMenu","1","File-Menu","false","","",""},
            {"appSettings","add","sendToPrintQueueMenu","1","Send-To-Print-Queue-Menu","false","","",""},
            {"appSettings","add","reindexMenu","1","Re-Index-Menu","false","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test49()
    {
        //Testing the Prebuilding of the 241 Hyland.Authentication section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Authentication"",""PathName"":""adfs"",""AttributeName"":""enabled"",""type"":""1"",""htmlIdName"":""ADFS-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
                {"Hyland.Authentication","adfs","enabled","1","ADFS-Enabled","false","","",""}
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
    public void Test51()
    {
        //Testing the Prebuilding of the 241 system.web.extensions section of the webApplicationWebConfigConfiguration object.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""2097152"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        string[,] translator = new string[,]
        {
            {"system.web.extensions","scripting/webServices/jsonSerialization","maxJsonLength","2","JSON-Serialization-Max-Length","2097152","","",""}
        };

        factory.PrebuildKnownKeys(translator, ds);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test52()
    {
        //Testing the parsing of the 241 Hyland.Services.Client section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""Url"",""type"":""2"",""htmlIdName"":""Application-Server-URL"",""Value"":""https://[APP SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""ApplicationServer"",""AttributeName"":""ServiceClientType"",""type"":""2"",""htmlIdName"":""Service-Client-Type"",""Value"":""Remoting"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Services.Client"",""PathName"":""StreamingSettings"",""AttributeName"":""BufferSize"",""type"":""2"",""htmlIdName"":""Stream-Settings"",""Value"":""64000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Services.Client>
        <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
        <ApplicationServer Url=""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"" ServiceClientType=""Remoting"" />
        <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
        <StreamingSettings BufferSize=""64000"" />
      </Hyland.Services.Client>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Services.Client", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test53()
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
    public void Test54()
    {
        //Testing the parsing of the 241 appSettings section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://[WEB SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATA SOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Enable-Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSplitView"",""type"":""1"",""htmlIdName"":""Enable-Split-View"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientSearch"",""type"":""1"",""htmlIdName"":""Enable-Patient-Search"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientContextSyncing"",""type"":""1"",""htmlIdName"":""Enable-Patient-Context-Syncing"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableTimestamp"",""type"":""1"",""htmlIdName"":""Enable-Timestamp"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TimestampTimeLimit"",""type"":""2"",""htmlIdName"":""Timestamp-Time-Limit"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableWorkstationNameDNSLookup"",""type"":""1"",""htmlIdName"":""Enable-Workstation-Name-DNS-Lookup"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListAllowCaching"",""type"":""1"",""htmlIdName"":""Allow-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxWidth"",""type"":""2"",""htmlIdName"":""Maximum-Width"",""Value"":""140"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxHeight"",""type"":""2"",""htmlIdName"":""Maximum-Height"",""Value"":""175"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxWidth"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Width"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxHeight"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Height"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HTMLOnlyDocumentsPrintAsPDFs"",""type"":""1"",""htmlIdName"":""HTML-Only-Documents-Print-As-PDFs"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SystemListDisplayLabel"",""type"":""2"",""htmlIdName"":""System-List-Display-Label"",""Value"":""System List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PersonalListDisplayLabel"",""type"":""2"",""htmlIdName"":""Personal-List-Display-Label"",""Value"":""Personal List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SelectedTabSingleColor"",""type"":""2"",""htmlIdName"":""Selected-Tab-Single-Color"",""Value"":""#000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""__EnableEFormStandardPrinting"",""type"":""1"",""htmlIdName"":""Enable-EForm-Standard-Printing"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FederatedSearchWithMPI"",""type"":""1"",""htmlIdName"":""Federated-Search-With-MPI"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HideToolbarPrintButton"",""type"":""1"",""htmlIdName"":""Hide-Toolbar-Print-Button"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""autoDisplayNotePanelPDFOffice"",""type"":""1"",""htmlIdName"":""Auto-Display-Note-Panel-PDF-Office"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogTitle"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Title"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogMessage"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogOtherReasonLabel"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Other-Reason-Label"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowEmergencyAccessShowDocumentsCheckboxes"",""type"":""1"",""htmlIdName"":""Show-Emergency-Access-Show-Documents-Checkboxes"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowOtherReasonInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Show-Other-Reason-In-Emergency-Access-Dialog"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserPdfViewer"",""type"":""1"",""htmlIdName"":""Enable-Bowser-PDF-Viewer"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""KeywordPanelViewType"",""type"":""2"",""htmlIdName"":""Keyword-Panel-View-Type"",""Value"":""flat"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""workflowMenu"",""type"":""1"",""htmlIdName"":""Workflow-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""createDocumentMenu"",""type"":""1"",""htmlIdName"":""Create-Document-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""fileMenu"",""type"":""1"",""htmlIdName"":""File-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""sendToPrintQueueMenu"",""type"":""1"",""htmlIdName"":""Send-To-Print-Queue-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""reindexMenu"",""type"":""1"",""htmlIdName"":""Re-Index-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsVirtualRoot"",""type"":""2"",""htmlIdName"":""Virtual-Directory"",""Value"":""https://[WEB SERVER]/[VIRTUAL ROOT]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""dmsDataSource"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATA SOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowViewSource"",""type"":""1"",""htmlIdName"":""Allow-View-Source"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSessionExpiration"",""type"":""1"",""htmlIdName"":""Enable-Session-Expiration"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PromptOnSessionExpire"",""type"":""1"",""htmlIdName"":""Prompt-On-Session-Expire"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""webtheme"",""type"":""2"",""htmlIdName"":""Web-Theme"",""Value"":""XP"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_username"",""type"":""2"",""htmlIdName"":""Default-Username"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""default_password"",""type"":""2"",""htmlIdName"":""Default-Password"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableDefaultLogin"",""type"":""1"",""htmlIdName"":""Enable-Default-Login"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableAutoLogin"",""type"":""1"",""htmlIdName"":""Autologin"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""forceSSOAutoLoginOverDomain"",""type"":""1"",""htmlIdName"":""Force-OnBase-Authentication"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableSplitView"",""type"":""1"",""htmlIdName"":""Enable-Split-View"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientSearch"",""type"":""1"",""htmlIdName"":""Enable-Patient-Search"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnablePatientContextSyncing"",""type"":""1"",""htmlIdName"":""Enable-Patient-Context-Syncing"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableTimestamp"",""type"":""1"",""htmlIdName"":""Enable-Timestamp"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""TimestampTimeLimit"",""type"":""2"",""htmlIdName"":""Timestamp-Time-Limit"",""Value"":""5"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableWorkstationNameDNSLookup"",""type"":""1"",""htmlIdName"":""Enable-Workstation-Name-DNS-Lookup"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""enableRowColoring"",""type"":""1"",""htmlIdName"":""Row-Coloring"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListAllowCaching"",""type"":""1"",""htmlIdName"":""Allow-Caching"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxWidth"",""type"":""2"",""htmlIdName"":""Maximum-Width"",""Value"":""140"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListThumbnailMaxHeight"",""type"":""2"",""htmlIdName"":""Maximum-Height"",""Value"":""175"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxWidth"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Width"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ThumbnailHitListPreviewMaxHeight"",""type"":""2"",""htmlIdName"":""Preview-Maximum-Height"",""Value"":""1000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""AllowInsecureConnection"",""type"":""1"",""htmlIdName"":""Allow-Insecure-Connections"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PreventViewerClientCaching"",""type"":""1"",""htmlIdName"":""Prevent-Viewer-Client-Caching"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HTMLOnlyDocumentsPrintAsPDFs"",""type"":""1"",""htmlIdName"":""HTML-Only-Documents-Print-As-PDFs"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SystemListDisplayLabel"",""type"":""2"",""htmlIdName"":""System-List-Display-Label"",""Value"":""System List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""PersonalListDisplayLabel"",""type"":""2"",""htmlIdName"":""Personal-List-Display-Label"",""Value"":""Personal List"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SelectedTabSingleColor"",""type"":""2"",""htmlIdName"":""Selected-Tab-Single-Color"",""Value"":""#000000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""__EnableEFormStandardPrinting"",""type"":""1"",""htmlIdName"":""Enable-EForm-Standard-Printing"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""FederatedSearchWithMPI"",""type"":""1"",""htmlIdName"":""Federated-Search-With-MPI"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""HideToolbarPrintButton"",""type"":""1"",""htmlIdName"":""Hide-Toolbar-Print-Button"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""autoDisplayNotePanelPDFOffice"",""type"":""1"",""htmlIdName"":""Auto-Display-Note-Panel-PDF-Office"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""IdPUrl"",""type"":""2"",""htmlIdName"":"""",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogTitle"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Title"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogMessage"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Message"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EmergencyAccessDialogOtherReasonLabel"",""type"":""2"",""htmlIdName"":""Emergency-Access-Dialog-Other-Reason-Label"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowEmergencyAccessShowDocumentsCheckboxes"",""type"":""1"",""htmlIdName"":""Show-Emergency-Access-Show-Documents-Checkboxes"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ShowOtherReasonInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Show-Other-Reason-In-Emergency-Access-Dialog"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"",""type"":""1"",""htmlIdName"":""Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EnableBrowserPdfViewer"",""type"":""1"",""htmlIdName"":""Enable-Bowser-PDF-Viewer"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""KeywordPanelViewType"",""type"":""2"",""htmlIdName"":""Keyword-Panel-View-Type"",""Value"":""flat"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""workflowMenu"",""type"":""1"",""htmlIdName"":""Workflow-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""createDocumentMenu"",""type"":""1"",""htmlIdName"":""Create-Document-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""fileMenu"",""type"":""1"",""htmlIdName"":""File-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""sendToPrintQueueMenu"",""type"":""1"",""htmlIdName"":""Send-To-Print-Queue-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""reindexMenu"",""type"":""1"",""htmlIdName"":""Re-Index-Menu"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":{""ServerLocation"":"""",""Tenant"":"""",""Client"":"""",""Secret"":""""},""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<appSettings file=""version.xml"">
        <add key=""dmsVirtualRoot"" value=""https://[WEB SERVER]/[VIRTUAL ROOT]"" />
        <add key=""dmsDataSource"" value=""[DATA SOURCE]"" />
        <add key=""AllowViewSource"" value=""true"" />
        <!-- Session timeout variables -->
        <add key=""EnableSessionExpiration"" value=""true"" />
        <add key=""PromptOnSessionExpire"" value=""true"" />
        <add key=""webtheme"" value=""XP"" />
        <add key=""default_username"" value="""" />
        <add key=""default_password"" value="""" />
        <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
        <add key=""enableDefaultLogin"" value=""false"" />
        <add key=""EnableAutoLogin"" value=""false"" />
        <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
        <!-- Enables the Split View / Cross Reference Document user interface. -->
        <add key=""EnableSplitView"" value=""true"" />
        <!-- Enables the Patient Search interface for non-admin users-->
        <add key=""EnablePatientSearch"" value=""false"" />
        <!-- Enables Patient Context Syncing -->
        <add key=""EnablePatientContextSyncing"" value=""false"" />
        <!-- Enables enforcement of UTC-based timestamp -->
        <add key=""EnableTimestamp"" value=""false"" />
        <!-- The amount of time in minutes the UTC-based timestamp is valid -->
        <add key=""TimestampTimeLimit"" value=""5"" />
        <!-- Enable hostname DNS lookup by IP when workstationName is not included as a request parameter-->
        <add key=""EnableWorkstationNameDNSLookup"" value=""false"" />
        <!--Settings respected by ULC controls-->
        <add key=""enableRowColoring"" value=""true"" />
        <!-- Settings for Thumbnail HitList Viewer -->
        <!-- Whether to allow web server caching of images -->
        <add key=""ThumbnailHitListAllowCaching"" value=""false"" />
        <add key=""ThumbnailHitListThumbnailMaxWidth"" value=""140"" />
        <add key=""ThumbnailHitListThumbnailMaxHeight"" value=""175"" />
        <add key=""ThumbnailHitListPreviewMaxWidth"" value=""1000"" />
        <add key=""ThumbnailHitListPreviewMaxHeight"" value=""1000"" />
        <!-- This setting controls if the server will accept only https connections or not. 
             If you set this to false all incoming requests have to be made over https. 
             If you set this to true then both http and https connections are accepted. 
             The recommended setting is false.-->
        <add key=""AllowInsecureConnection"" value=""false"" />
        <!-- Preventing caching will impact Viewer performance -->
        <add key=""PreventViewerClientCaching"" value=""true"" />
        <add key=""HTMLOnlyDocumentsPrintAsPDFs"" value=""true"" />
        <!-- These settings specify the labels of UI components related to System (Dynamic) List and Personal (Static) List functionality-->
        <add key=""SystemListDisplayLabel"" value=""System List"" />
        <add key=""PersonalListDisplayLabel"" value=""Personal List"" />
        <!-- The selected tab in OPW will be set to the color specified. Set the value to a RGB hex color value, i.e. #FF0000 is red, #0000FF is blue, or friendly name, red, blue, green, etc. -->
        <add key=""SelectedTabSingleColor"" value=""#000000"" />
        <add key=""__EnableEFormStandardPrinting"" value=""true"" />
        <!-- By default, ad-hoc federated searches via the ""Find More Studies"" button occur with all of the known Medical Record Numbers for the patient.
             Setting this value to true will use the Master Patient Index Number instead. -->
        <add key=""FederatedSearchWithMPI"" value=""false"" />
        <add key=""HideToolbarPrintButton"" value=""false"" />
        <add key=""autoDisplayNotePanelPDFOffice"" value=""true"" />
        <add key=""IdPUrl"" value="""" />
        <add key=""EmergencyAccessDialogTitle"" value="""" />
        <add key=""EmergencyAccessDialogMessage"" value="""" />
        <add key=""EmergencyAccessDialogOtherReasonLabel"" value="""" />
        <add key=""ShowEmergencyAccessShowDocumentsCheckboxes"" value=""true"" />
        <add key=""ShowOtherReasonInEmergencyAccessDialog"" value=""true"" />
        <add key=""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"" value=""false"" />
      </appSettings>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "appSettings", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test55()
    {
        //Testing the parsing of the 241 Hyland.Authentication section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Authentication"",""PathName"":""adfs"",""AttributeName"":""enabled"",""type"":""1"",""htmlIdName"":""ADFS-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""Hyland.Authentication"",""PathName"":""adfs"",""AttributeName"":""enabled"",""type"":""1"",""htmlIdName"":""ADFS-Enabled"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Authentication>
        <adfs enabled=""false"" synchronizeUserAttributes=""true"" authenticationOnly=""2.0"" />
      </Hyland.Authentication>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "Hyland.Authentication", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test56()
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

        For Patient Window, impersonation is (most likely) not needed. The default account of
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
        <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
        <authentication mode=""Windows"" />
      </system.web>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test57()
    {
        //Testing the parsing of the translator that came back from the COMACON Helper executable
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Validate-Against-Checksum"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Checksum-Key"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""type"":""1"",""htmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableChecksum"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Validate-Against-Checksum"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""ChecksumKey"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Checksum-Key"",""Value"":""Test"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""EnableLegacyChecksumFallback"",""AttributeName"":""value"",""Type"":""1"",""HtmlIdName"":""Enable-Legacy-Checksum-Fallback"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.HealthcarePop"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Healthcare-Pop-Integration-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test58()
    {
        //Testing the parsing of the 241 Hyland.Logging section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure241WithVersionNumber);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":""24.1.7.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":{""windowsEventLogging"":{""SourceName"":""Hyland Application Server""},""Routes"":[{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":{""OutputFormat"":""Minimal""},""RouteType"":""Console"",""Name"":""Console"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""True"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""3"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":null,""splunk"":null,""file"":null,""http"":{""URL"":""http://localhost:8989""},""durablehttp"":null,""console"":null,""RouteType"":""Http"",""Name"":""DiagnosticsConsole"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null},{""filter"":{""Profiles"":[],""MinimumErrorLevel"":""5"",""MaximumErrorLevel"":""6"",""FilterProfilesIncludeExcludeNeither"":""Neither""},""eventlog"":{""SourceName"":""Hyland""},""splunk"":null,""file"":null,""http"":null,""durablehttp"":null,""console"":null,""RouteType"":""EventLog"",""Name"":""ErrorEventLog"",""SourceEvents"":""Diagnostics Events"",""EnableIpAddressMasking"":""False"",""id"":null}],""truncateloggingcharacters"":""1024"",""profilesForHTML"":[""asp.net"",""ChangeTracking"",""client"",""configuration"",""error"",""EpicSettings"",""fulltext"",""ihe"",""ldap"",""logging"",""mobile.service"",""None"",""Patient-Window"",""report.services"",""service"",""tcservices"",""timer"",""undefined"",""vbscript"",""wcf"",""workflow"",""cache"",""chromium-service-pim"",""configuration"",""db"",""file"",""hl7"",""image-rendering-pim"",""locking"",""mobile.raw"",""named-pipe-core"",""OnBase"",""pim-manager"",""scriptexecution"",""TC"",""tcverbose"",""trace"",""unity"",""warnings"",""web.service""]},""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<Hyland.Logging TruncateLogValues=""1024"">
        <WindowsEventLogging sourcename=""Hyland Application Server"" />
        <Routes>
          <Route name=""Console"">
            <add key=""minimum-level"" value=""Information"" />
            <add key=""maximum-level"" value=""Critical"" />
            <add key=""Console"" />
            <add key=""OutputFormat"" value=""Minimal"" />
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
          <Route name=""ErrorEventLog"">
            <add key=""minimum-level"" value=""Error"" />
            <add key=""maximum-level"" value=""Critical"" />
            <add key=""EventLog"" value=""Hyland"" />
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
    public void Test59()
    {
        //Testing the parsing of the 241 ADFS section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = new webApplicationWebConfigConfiguration();

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":{""systemIdentityModel"":{""audienceUris"":[{""URI"":""https://Audience/URI/"",""id"":null},{""URI"":""https://dummy/dummy/"",""id"":null}],""trustedIssuers"":[{""Thumbprint"":""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"",""Name"":""Optional_Friendly_Name_For_The_Certificate"",""id"":null},{""Thumbprint"":""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"",""Name"":""Other_Friendly_Name"",""id"":null}]},""systemIdentityModelServices"":{""wsFederation"":{""Issuer"":""https://issuer/URI/adfs/ls/"",""Realm"":""https://Audience/URI/""},""serviceCertificate"":{""X509FindType"":""FindByThumbprint"",""FindValue"":""ZYXWVUTSRQPONMLKJIHGFEDCBA0987654321ZYXW"",""StoreLocation"":""LocalMachine"",""StoreName"":""My""},""CookieHandlerRequireSSL"":""false""},""knownKeys"":[],""ADFSEnabled"":""false"",""RequestValidationMode"":""2.0"",""AuthenticationMode"":""Windows"",""SynchronizeUserAttributes"":""true"",""AuthenticationOnly"":""2.0""},""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<configuration>
      <configSections>
        <section name=""Hyland.Services.Client"" type=""Hyland.Services.Client.ServiceClientConfiguration,Hyland.Services.Client"" />
        <section name=""Hyland.Logging"" type=""Hyland.Logging.Configuration.ClientConfigurationHandler,Hyland.Logging"" />
        <section name=""Hyland.Web.HealthcarePop"" type=""Hyland.Applications.Web.ConfigSections.HealthcarePopConfigSection, Hyland.Applications.Web"" />
        <!-- ADFS sections -->
        <section name=""Hyland.Authentication"" type=""Hyland.Authentication.Configuration.AuthenticationConfigurationSection, Hyland.Authentication"" />
        <section name=""system.identityModel"" type=""System.IdentityModel.Configuration.SystemIdentityModelSection, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"" />
        <section name=""system.identityModel.services"" type=""System.IdentityModel.Services.Configuration.SystemIdentityModelServicesSection, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=B77A5C561934E089"" />
        <!-- End ADFS sections -->
      </configSections>
      <Hyland.Services.Client>
        <!-- All Urls Must end with 'Service.rem' for Remoting or 'Service.asmx' for SOAP. -->
        <ApplicationServer Url=""https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem"" ServiceClientType=""Remoting"" />
        <!-- This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for.-->
        <StreamingSettings BufferSize=""64000"" />
      </Hyland.Services.Client>
      <Hyland.Logging TruncateLogValues=""1024"">
        <WindowsEventLogging sourcename=""Hyland Application Server"" />
        <Routes>
          <Route name=""Console"">
            <add key=""minimum-level"" value=""Information"" />
            <add key=""maximum-level"" value=""Critical"" />
            <add key=""Console"" />
            <add key=""OutputFormat"" value=""Minimal"" />
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
          <Route name=""ErrorEventLog"">
            <add key=""minimum-level"" value=""Error"" />
            <add key=""maximum-level"" value=""Critical"" />
            <add key=""EventLog"" value=""Hyland"" />
            <add key=""DisableIPAddressMasking"" value=""True"" />
            <add key=""include-profiles"" value="""" />
            <add key=""exclude-profiles"" value="""" />
          </Route>
        </Routes>
        <AuditRoutes />
      </Hyland.Logging>
      <appSettings file=""version.xml"">
        <add key=""dmsVirtualRoot"" value=""https://[WEB SERVER]/[VIRTUAL ROOT]"" />
        <add key=""dmsDataSource"" value=""[DATA SOURCE]"" />
        <add key=""AllowViewSource"" value=""true"" />
        <!-- Session timeout variables -->
        <add key=""EnableSessionExpiration"" value=""true"" />
        <add key=""PromptOnSessionExpire"" value=""true"" />
        <add key=""webtheme"" value=""XP"" />
        <add key=""default_username"" value="""" />
        <add key=""default_password"" value="""" />
        <!-- The enableDefaultLogin key will bypass the login ui and automatically login using default_username and default_password. -->
        <add key=""enableDefaultLogin"" value=""false"" />
        <add key=""EnableAutoLogin"" value=""false"" />
        <add key=""forceSSOAutoLoginOverDomain"" value=""false"" />
        <!-- Enables the Split View / Cross Reference Document user interface. -->
        <add key=""EnableSplitView"" value=""true"" />
        <!-- Enables the Patient Search interface for non-admin users-->
        <add key=""EnablePatientSearch"" value=""false"" />
        <!-- Enables Patient Context Syncing -->
        <add key=""EnablePatientContextSyncing"" value=""false"" />
        <!-- Enables enforcement of UTC-based timestamp -->
        <add key=""EnableTimestamp"" value=""false"" />
        <!-- The amount of time in minutes the UTC-based timestamp is valid -->
        <add key=""TimestampTimeLimit"" value=""5"" />
        <!-- Enable hostname DNS lookup by IP when workstationName is not included as a request parameter-->
        <add key=""EnableWorkstationNameDNSLookup"" value=""false"" />
        <!--Settings respected by ULC controls-->
        <add key=""enableRowColoring"" value=""true"" />
        <!-- Settings for Thumbnail HitList Viewer -->
        <!-- Whether to allow web server caching of images -->
        <add key=""ThumbnailHitListAllowCaching"" value=""false"" />
        <add key=""ThumbnailHitListThumbnailMaxWidth"" value=""140"" />
        <add key=""ThumbnailHitListThumbnailMaxHeight"" value=""175"" />
        <add key=""ThumbnailHitListPreviewMaxWidth"" value=""1000"" />
        <add key=""ThumbnailHitListPreviewMaxHeight"" value=""1000"" />
        <!-- This setting controls if the server will accept only https connections or not. 
             If you set this to false all incoming requests have to be made over https. 
             If you set this to true then both http and https connections are accepted. 
             The recommended setting is false.-->
        <add key=""AllowInsecureConnection"" value=""false"" />
        <!-- Preventing caching will impact Viewer performance -->
        <add key=""PreventViewerClientCaching"" value=""true"" />
        <add key=""HTMLOnlyDocumentsPrintAsPDFs"" value=""true"" />
        <!-- These settings specify the labels of UI components related to System (Dynamic) List and Personal (Static) List functionality-->
        <add key=""SystemListDisplayLabel"" value=""System List"" />
        <add key=""PersonalListDisplayLabel"" value=""Personal List"" />
        <!-- The selected tab in OPW will be set to the color specified. Set the value to a RGB hex color value, i.e. #FF0000 is red, #0000FF is blue, or friendly name, red, blue, green, etc. -->
        <add key=""SelectedTabSingleColor"" value=""#000000"" />
        <add key=""__EnableEFormStandardPrinting"" value=""true"" />
        <!-- By default, ad-hoc federated searches via the ""Find More Studies"" button occur with all of the known Medical Record Numbers for the patient.
             Setting this value to true will use the Master Patient Index Number instead. -->
        <add key=""FederatedSearchWithMPI"" value=""false"" />
        <add key=""HideToolbarPrintButton"" value=""false"" />
        <add key=""autoDisplayNotePanelPDFOffice"" value=""true"" />
        <add key=""IdPUrl"" value="""" />
        <add key=""EmergencyAccessDialogTitle"" value="""" />
        <add key=""EmergencyAccessDialogMessage"" value="""" />
        <add key=""EmergencyAccessDialogOtherReasonLabel"" value="""" />
        <add key=""ShowEmergencyAccessShowDocumentsCheckboxes"" value=""true"" />
        <add key=""ShowOtherReasonInEmergencyAccessDialog"" value=""true"" />
        <add key=""OtherReasonTextBoxAlwaysAvailableInEmergencyAccessDialog"" value=""false"" />
      </appSettings>
      <Hyland.Web.HealthcarePop>
        <EnableChecksum value=""true"" />
        <ChecksumKey value=""Test"" />
        <EnableLegacyChecksumFallback value=""false"" />
      </Hyland.Web.HealthcarePop>
      <Hyland.Authentication>
        <adfs enabled=""false"" synchronizeUserAttributes=""true"" authenticationOnly=""2.0"" />
      </Hyland.Authentication>
      <system.diagnostics>
        <switches>
          <!--
          This switch controls tracing globally through Hyland.Logging.
          It configures the level of information from Trace that is logged.
          For no information set the value to zero. Set the value to 1, 2, 3, or 4 for
          minimal, normal, detailed, or verbose messages, respectively.
          -->
          <add name=""hylandTracing"" value=""0"" />
        </switches>
      </system.diagnostics>
      <configProtectedData>
        <providers>
          <add name=""DpapiProvider"" type=""System.Configuration.DpapiProtectedConfigurationProvider,System.Configuration, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"" />
        </providers>
      </configProtectedData>
      <system.web>
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

        For Patient Window, impersonation is (most likely) not needed. The default account of
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
        <pages validateRequest=""false"" controlRenderingCompatibilityVersion=""4.0"" />
        <authentication mode=""Windows"" />
      </system.web>
      <system.webServer>
        <modules runAllManagedModulesForAllRequests=""true"">
          <!--The format for this section should additionally contain the preCondition attribute.-->
          <add name=""OnBaseContextModule"" type=""Hyland.Server.Diagnostics.OnBaseContextModule, Hyland.Server"" preCondition=""managedHandler"" />
          <!-- The following two modules are required for ADFS -->
          <!--add name=""WSFederationAuthenticationModule"" type=""System.IdentityModel.Services.WSFederationAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
          <!--add name=""SessionAuthenticationModule"" type=""System.IdentityModel.Services.SessionAuthenticationModule, System.IdentityModel.Services, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"" preCondition=""managedHandler"" /-->
        </modules>
        <validation validateIntegratedModeConfiguration=""false"" />
        <handlers>
          <!-- Hyland.Applications.Web -->
          <add name=""DownloadHandler.ashx_*"" path=""DownloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.DownloadHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""HttpServiceHandler.ashx_*"" path=""HttpServiceHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.HttpServiceHandlerProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""OptimizedServicePipeline.ashx_*"" path=""OptimizedServicePipeline.ashx"" verb=""*"" type=""Hyland.Applications.Web.OptimizedServicePipelineProxy, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""Service.asmx_*"" path=""Service.asmx"" verb=""*"" type=""Hyland.Applications.Web.ServiceHttpHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Applications.Web.Client.Controls -->
          <add name=""NoteType.ashx_*"" verb=""*"" path=""NoteType.ashx"" type=""Hyland.Applications.Web.Client.Controls.NoteType, Hyland.Applications.Web.Client"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Applications.Web.Handlers -->
          <add name=""DocumentActionHandler.ashx_*"" path=""DocumentActionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentActionHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""DocumentDataHandler.ashx_*"" path=""DocumentDataHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.DocumentDataHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""FormProc.ashx_*"" path=""FormProc.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.FormProc, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""UnityFormHandler.ashx_*"" path=""UnityFormHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.UnityFormHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""ScriptExceptionHandler.ashx_*"" path=""ScriptExceptionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.Handlers.ScriptExceptionHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Applications.Web.WindowsManager -->
          <add name=""UnloadHandler.ashx_*"" path=""UnloadHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.UnloadHandler, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""WindowDirector.ashx_*"" path=""WindowDirector.ashx"" verb=""*"" type=""Hyland.Applications.Web.WindowsManager.WindowDirector, Hyland.Applications.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Controls.Web -->
          <add name=""CalendarProvider.ashx_*"" path=""CalendarProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.Calendar.CalendarProvider, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""FileServiceHandler.ashx_*"" path=""FileServiceHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.FileServiceHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""Login.ashx_*"" path=""Login.ashx"" verb=""*"" type=""Hyland.Controls.Web.Login.LoginHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""NoteHandler.ashx_*"" path=""NoteHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.NoteHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""PrintHandler.ashx_*"" path=""PrintHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.PrintHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Controls.Web.GenericViewer -->
          <add name=""GVCDocActions.ashx_*"" path=""GVCDocActions.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.GVCDocActions, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""IDOLDocumentHandler.ashx_*"" path=""IDOLDocumentHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.IDOLDocumentHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""ImageProvider.ashx_*"" path=""ImageProvider.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.UtilityControls.ImageViewer.ImageProvider, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""MarkupLanguageHandler.ashx_*"" path=""MarkupLanguageHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.MarkupLanguageHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""OleHandler.ashx_*"" path=""OleHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.OleHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""PdfHandler.ashx_*"" path=""PdfHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.PdfHandler, Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""WopiHandler.ashx_*"" path=""WopiHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.GenericViewer.WopiHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Controls.Web.Viewer -->
          <add name=""ThumbnailHandler.ashx_GET"" path=""ThumbnailHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ThumbnailHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""ImageHandler.ashx_GET"" path=""ImageHandler.ashx"" verb=""GET"" type=""Hyland.Controls.Web.Viewer.ImageHandler,Hyland.Controls.Web"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Applications.Web.PatientWindow -->
          <add name=""ExceptionMessage.ashx_*"" path=""ExceptionMessage.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.ExceptionMessageHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Applications.Web.PatientWindow.Controls -->
          <add name=""ChartSearchHandler.ashx_*"" path=""ChartSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.Search.ChartSearchHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""DocumentCorrectionActionHandler.ashx_*"" path=""DocumentCorrectionActionHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.DocumentCorrectionAction.DocumentCorrectionActionHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""PatientSearchHandler.ashx_*"" path=""PatientSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.Search.PatientSearchHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""ScheduledPatientSearchHandler.ashx_*"" path=""ScheduledPatientSearchHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.Search.ScheduledPatientSearchHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""UniversalListControlHandler.ashx_*"" path=""UniversalListControlHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Controls.List.UniversalListControlHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Applications.Web.PatientWindow.Dialogs -->
          <add name=""ConfidentialityCodesHandler.ashx_*"" path=""ConfidentialityCodesHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Dialogs.ConfidentialityCodesHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <add name=""UserOptionsHandler.ashx_*"" path=""UserOptionsHandler.ashx"" verb=""*"" type=""Hyland.Applications.Web.PatientWindow.Dialogs.UserOptionsHandler, Hyland.Applications.Web.PatientWindow"" preCondition=""integratedMode,runtimeVersionv4.0"" />
          <!-- Hyland.Controls.Web.Medical -->
          <add name=""ConfidentialityNoticeHandler.ashx_*"" path=""ConfidentialityNoticeHandler.ashx"" verb=""*"" type=""Hyland.Controls.Web.Medical.ConfidentialityNoticeControls.ConfidentialityNoticeHandler, Hyland.Controls.Web.Medical"" preCondition=""integratedMode,runtimeVersionv4.0"" />
        </handlers>
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
        <security>
          <authentication>
            <anonymousAuthentication enabled=""true"" />
            <windowsAuthentication enabled=""true"" />
          </authentication>
        </security>
      </system.webServer>
      <!--
      The system.identityModel section is used to enable Windows Identity Foundation options.

      The audienceUri identifies the relying party (RP - this application).  This much exactly (case, trailing slash, etc.) match the Relying Party Trust Identifier on the ADFS sever.
      The certificate identified by the thumbprint in the trustedIssuers element is the token-signing certificate found on the ADFS server.
      -->
      <!--<system.identityModel><identityConfiguration saveBootstrapContext=""true""><securityTokenHandlers><securityTokenHandlerConfiguration><audienceUris><add value=""https://Audience/URI/"" /><add value=""https://dummy/dummy/"" /></audienceUris><issuerNameRegistry type=""System.IdentityModel.Tokens.ConfigurationBasedIssuerNameRegistry, System.IdentityModel, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089""><trustedIssuers><add thumbprint=""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"" name=""Optional_Friendly_Name_For_The_Certificate"" /><add thumbprint=""ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890ABCD"" name=""Other_Friendly_Name"" /></trustedIssuers></issuerNameRegistry></securityTokenHandlerConfiguration></securityTokenHandlers></identityConfiguration></system.identityModel>-->
      <!--
      system.identityModel.services is used to configure authentication using the WS-Federation protocol.

      wsFederation node
        The 'issuer' attribute specifies the URI of the token issuer.  It sets the base URL for authentication requests.
        The 'realm' attribute specifies the URI used to identify the relying party (RP - this application).  This much exactly (case, trailing slash, etc.) match the Relying Party Trust Identifier on the ADFS sever.

      The certificate identified by the certificateReference element is the encryption certificate configured on the Relying Party Trust on the ADFS server.
      -->
      <!--<system.identityModel.services><federationConfiguration requireSsl=""false""><wsFederation issuer=""https://issuer/URI/adfs/ls/"" realm=""https://Audience/URI/"" /><serviceCertificate><certificateReference x509FindType=""FindByThumbprint"" findValue=""ZYXWVUTSRQPONMLKJIHGFEDCBA0987654321ZYXW"" storeLocation=""LocalMachine"" storeName=""My"" /></serviceCertificate></federationConfiguration></system.identityModel.services>-->
      <runtime>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""Microsoft.Extensions.DependencyInjection.Abstractions"" publicKeyToken=""adb9793829ddae60"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-2.1.1.0"" newVersion=""2.1.1.0"" />
          </dependentAssembly>
        </assemblyBinding>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""Microsoft.Extensions.Logging.Abstractions"" publicKeyToken=""adb9793829ddae60"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-2.1.1.0"" newVersion=""2.1.1.0"" />
          </dependentAssembly>
        </assemblyBinding>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""Microsoft.Owin"" publicKeyToken=""31bf3856ad364e35"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-4.0.1.0"" newVersion=""4.0.1.0"" />
          </dependentAssembly>
        </assemblyBinding>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""Newtonsoft.Json"" publicKeyToken=""30ad4fe6b2a6aeed"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-11.0.0.0"" newVersion=""11.0.0.0"" />
          </dependentAssembly>
        </assemblyBinding>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""System.Buffers"" publicKeyToken=""cc7b13ffcd2ddd51"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-4.0.3.0"" newVersion=""4.0.3.0"" />
          </dependentAssembly>
        </assemblyBinding>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""System.Configuration.ConfigurationManager"" publicKeyToken=""cc7b13ffcd2ddd51"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-4.0.3.0"" newVersion=""4.0.3.0"" />
          </dependentAssembly>
        </assemblyBinding>
        <assemblyBinding xmlns=""urn:schemas-microsoft-com:asm.v1"">
          <dependentAssembly>
            <assemblyIdentity name=""System.Runtime.CompilerServices.Unsafe"" publicKeyToken=""b03f5f7f11d50a3a"" culture=""neutral"" />
            <bindingRedirect oldVersion=""0.0.0.0-4.0.6.0"" newVersion=""4.0.6.0"" />
          </dependentAssembly>
        </assemblyBinding>
      </runtime>
    </configuration>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "ADFS", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test60()
    {
        //Testing the parsing of the 241 system.web.extensions section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""2097152"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""system.web.extensions"",""PathName"":""scripting/webServices/jsonSerialization"",""AttributeName"":""maxJsonLength"",""type"":""2"",""htmlIdName"":""JSON-Serialization-Max-Length"",""Value"":""2097152"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]},""publicCommentIntegrations"":[],""tooltips"":[],""formattedTextIframeSupportedDomains"":[]}";

        var xmlNode = @"<system.web.extensions>
		<scripting>
			<webServices>
				<jsonSerialization maxJsonLength=""2097152"" />
			</webServices>
		</scripting>
	</system.web.extensions>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "system.web.extensions", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }
}