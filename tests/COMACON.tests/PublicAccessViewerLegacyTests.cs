using COMACON.config;
using COMACONTranslationToHelperUtility;
using FluentAssertions;
using Newtonsoft.Json;
using System.Xml;

namespace COMACON.tests;

public class PublicAccessViewerLegacyTests
{
    private readonly string cleanWebApplicationDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";
    private readonly string cleanWebApplicationDataStructure211WithVersionNumber = @"{""Type"":"""",""Version"":""21.1.38.1000"",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

    [Fact]
    public void Test1()
    {
        //Testing to validate that the key is found and the appropriate value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings>
    <!-- Whether or not to encrypt the document ID when displaying search results. -->
    <add key=""EncryptDocId"" value=""true"" />
    <!-- Whether or not to pass encrypted folder IDs when performing folder queries. -->
    <add key=""EncryptFolderId"" value=""false"" />
    <!-- The key to use when encryption is enabled. -->
    <add key=""CheckSumKey"" value="""" />
    <!-- Whether or not to use the configured Custom Query display columns when displaying search results. -->
    <add key=""UseDisplayColumns"" value=""false"" />
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
    <!--Caching Settings-->
    <!--Path to the Public Access cache-->
    <add key=""CachePath"" value="""" />
    <!--Number of days before a document in the cache becomes stale-->
    <add key=""ExpireTime"" value=""1"" />
    <!--Maximum cache size (GB)-->
    <add key=""MaxCacheSize"" value=""1"" />
    <!--Any files over this file size (MB) get cached-->
    <add key=""SizeToCache"" value=""20"" />
    <!--Prompt to open/save any files over this file size (MB) instead of opening directly in the viewer-->
    <add key=""SizeToPrompt"" value=""20"" />
  </appSettings>";

        string keyName = "ViewerMode";
        string defaultValue = "Native";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getNonStandardXmlValue(xmldoc.DocumentElement, keyName, defaultValue);

        value.Should().Be("PDF");
    }

    [Fact]
    public void Test2()
    {
        //Testing to validate that the key is not found and the default value is returned.
        var factory = new DefaultGenericHelperMethods();

        var xmlNode = @"<appSettings>
    <!-- Whether or not to encrypt the document ID when displaying search results. -->
    <add key=""EncryptDocId"" value=""true"" />
    <!-- Whether or not to pass encrypted folder IDs when performing folder queries. -->
    <add key=""EncryptFolderId"" value=""false"" />
    <!-- The key to use when encryption is enabled. -->
    <add key=""CheckSumKey"" value="""" />
    <!-- Whether or not to use the configured Custom Query display columns when displaying search results. -->
    <add key=""UseDisplayColumns"" value=""false"" />
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
    <!--Caching Settings-->
    <!--Path to the Public Access cache-->
    <add key=""CachePath"" value="""" />
    <!--Number of days before a document in the cache becomes stale-->
    <add key=""ExpireTime"" value=""1"" />
    <!--Maximum cache size (GB)-->
    <add key=""MaxCacheSize"" value=""1"" />
    <!--Any files over this file size (MB) get cached-->
    <add key=""SizeToCache"" value=""20"" />
    <!--Prompt to open/save any files over this file size (MB) instead of opening directly in the viewer-->
    <add key=""SizeToPrompt"" value=""20"" />
  </appSettings>";

        string keyName = "viewerMode";
        string defaultValue = "PDF";

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
    <httpRuntime requestValidationMode=""2.0"" maxRequestLength=""4096"" executionTimeout=""60"" enableVersionHeader=""false"" />
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
        string attributeName = "executionTimeout";
        string defaultValue = "90";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        string value = factory.getStandardXmlValue(xmldoc.DocumentElement, nodeName, attributeName, defaultValue);

        value.Should().Be("60");
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
    <httpRuntime requestValidationMode=""2.0"" maxRequestLength=""4096"" executionTimeout=""60"" enableVersionHeader=""false"" />
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
        string attributeName = "ExecutionTimeout";
        string defaultValue = "90";

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

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptFolderId"",""type"":""1"",""htmlIdName"":""Encrypt-Folder-ID"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CheckSumKey"",""type"":""2"",""htmlIdName"":""Checksum-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        string[,] translator = new string[,]
        {
            {"appSettings","add","EncryptDocId","1","Encrypt-Doc-ID","true","","",""},
            {"appSettings", "add", "EncryptFolderId", "1", "Encrypt-Folder-ID", "false", "", "",""},
            {"appSettings","add","CheckSumKey","2","Checksum-Key","","","",""},
            {"appSettings", "add", "UseDisplayColumns", "1", "Use-Display-Columns", "true", "", "",""},
            {"appSettings", "add", "QueryLimit", "2", "Query-Limit", "0", "", "",""},
            {"appSettings", "add", "ChunkSize", "2", "Chunk-Size", "512000", "", "",""},
            {"appSettings", "add", "ViewerMode", "2", "Viewer-Mode", "PDF", "", "",""},
            {"appSettings", "add", "CachePath", "2", "Cache-Path", "C:\\DocCache", "", "",""},
            {"appSettings", "add", "ExpireTime", "2", "Expiration-Time", "1", "", "",""},
            {"appSettings", "add", "MaxCacheSize", "2", "Max-Cache-Size", "10", "", "",""},
            {"appSettings", "add", "SizeToCache", "2", "Size-to-Cache", "1", "", "",""},
            {"appSettings", "add", "SizeToPrompt", "2", "Size-to-Prompt", "20", "", "",""}
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
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(@"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptFolderId"",""type"":""1"",""htmlIdName"":""Encrypt-Folder-ID"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CheckSumKey"",""type"":""2"",""htmlIdName"":""Checksum-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":""C:\\DocCache"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""10"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}");

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptDocId"",""type"":""1"",""htmlIdName"":""Encrypt-Doc-ID"",""Value"":""true"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""EncryptFolderId"",""type"":""1"",""htmlIdName"":""Encrypt-Folder-ID"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CheckSumKey"",""type"":""2"",""htmlIdName"":""Checksum-Key"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""UseDisplayColumns"",""type"":""1"",""htmlIdName"":""Use-Display-Columns"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""QueryLimit"",""type"":""2"",""htmlIdName"":""Query-Limit"",""Value"":""0"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ChunkSize"",""type"":""2"",""htmlIdName"":""Chunk-Size"",""Value"":""512000"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ViewerMode"",""type"":""2"",""htmlIdName"":""Viewer-Mode"",""Value"":""PDF"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""CachePath"",""type"":""2"",""htmlIdName"":""Cache-Path"",""Value"":"""",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""ExpireTime"",""type"":""2"",""htmlIdName"":""Expiration-Time"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""MaxCacheSize"",""type"":""2"",""htmlIdName"":""Max-Cache-Size"",""Value"":""1"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToCache"",""type"":""2"",""htmlIdName"":""Size-to-Cache"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""appSettings"",""PathName"":""add"",""AttributeName"":""SizeToPrompt"",""type"":""2"",""htmlIdName"":""Size-to-Prompt"",""Value"":""20"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<appSettings>
    <!-- Whether or not to encrypt the document ID when displaying search results. -->
    <add key=""EncryptDocId"" value=""true"" />
    <!-- Whether or not to pass encrypted folder IDs when performing folder queries. -->
    <add key=""EncryptFolderId"" value=""false"" />
    <!-- The key to use when encryption is enabled. -->
    <add key=""CheckSumKey"" value="""" />
    <!-- Whether or not to use the configured Custom Query display columns when displaying search results. -->
    <add key=""UseDisplayColumns"" value=""false"" />
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
    <!--Caching Settings-->
    <!--Path to the Public Access cache-->
    <add key=""CachePath"" value="""" />
    <!--Number of days before a document in the cache becomes stale-->
    <add key=""ExpireTime"" value=""1"" />
    <!--Maximum cache size (GB)-->
    <add key=""MaxCacheSize"" value=""1"" />
    <!--Any files over this file size (MB) get cached-->
    <add key=""SizeToCache"" value=""20"" />
    <!--Prompt to open/save any files over this file size (MB) instead of opening directly in the viewer-->
    <add key=""SizeToPrompt"" value=""20"" />
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

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""user"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""PAVL-Username"",""Value"":""[Username]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""password"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""PAVL-Password"",""Value"":""dummy"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""datasource"",""AttributeName"":""value"",""type"":""2"",""htmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""type"":""1"",""htmlIdName"":""Encrypt-Public-Access-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var translatorValue = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(@"{""knownKeys"":[{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""user"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""PAVL-Username"",""Value"":""[Username]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""password"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""PAVL-Password"",""Value"":""dummy"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""datasource"",""AttributeName"":""value"",""Type"":""2"",""HtmlIdName"":""Data-Source"",""Value"":""[DATASOURCE]"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""},{""Section"":""Hyland.Web.PublicAccess"",""PathName"":""IsEncrypted"",""AttributeName"":"""",""Type"":""1"",""HtmlIdName"":""Encrypt-Public-Access-Configuration"",""Value"":""false"",""Version"":"""",""minimumValue"":"""",""maximumValue"":""""}],""connectionStrings"":null}");

        factory.ParseTranslator(ds, translatorValue);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }

    [Fact]
    public void Test12()
    {
        //Testing the parsing of the 211 RequiredKeywords section from the web.config file.
        var factory = new DefaultGenericHelperMethods();
        var ds = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(cleanWebApplicationDataStructure);

        string expectedJsonDataStructure = @"{""Type"":"""",""Version"":"""",""PhysicalPath"":"""",""Path"":"""",""SiteName"":"""",""ApplicationName"":"""",""Bitness"":"""",""knownKeys"":[],""translatorKnownKeys"":[],""unknownAttributeKeys"":[],""unknownElementKeys"":[],""connectionStrings"":null,""hylandLogging"":null,""hylandIdentityProviderUrl"":null,""requiredKeywords"":[{""QueryID"":""*"",""KeywordID"":""0""},{""QueryID"":""0"",""KeywordID"":""0""},{""QueryID"":""9"",""KeywordID"":""6""}],""hylandApplicationsAgendaPubAccessPublicComment"":null,""hylandAuthenticationADFS"":null,""hylandAuthentication"":null,""hylandResponsiveApps"":null,""hylandServicesParameters"":null,""hylandPlatterManagement"":null,""WindowsAuthOptimizeFor"":[],""navigationPanel"":null,""customValidation"":null,""healthcareWebViewer"":null,""keywordDropdownTypeAhead"":null,""IisConfiguration"":{""application"":null,""applicationPool"":null},""sessionAdministration"":null,""elementsToHide"":{""elements"":[]},""processingErrors"":{""CriticalErrors"":[],""NonCriticalErrors"":[]}}";

        var xmlNode = @"<RequiredKeywords>
    <Query ID=""*"">
      <Keyword ID=""0"" />
    </Query>
    <Query ID=""0"">
      <Keyword ID=""0"" />
    </Query>
    <Query ID=""9"">
      <Keyword ID=""6"" />
    </Query>
  </RequiredKeywords>";

        XmlDocument xmldoc = new XmlDocument { InnerXml = xmlNode };

        factory.ParseKeys(ds, xmldoc.DocumentElement, "RequiredKeywords", xmldoc);

        Assert.Equal(expectedJsonDataStructure, JsonConvert.SerializeObject(ds));
    }
}
