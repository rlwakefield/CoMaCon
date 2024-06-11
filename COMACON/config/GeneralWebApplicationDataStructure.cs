namespace COMACON.config;

/********************************************************
*         Web Application Retrieval Classes
********************************************************/
public class WebApplications
{
    public List<ApplicationDetails> webApps = new List<ApplicationDetails>();
}

public class ApplicationDetails
{
    public string name = "";
    public string type = "";
    public string version = "";
    public string site = "";
    public string path = "";
    public string webConfigPhysicalPath = "";
    public string physicalPath = "";
    public string bitness = "";
}


/********************************************************
*        Web Application web.config Configuration
********************************************************/
public class webApplicationWebConfigConfiguration
{
    public string Type = "";
    public string Version = "";
    public string PhysicalPath = "";
    public string Path = "";
    public string SiteName = "";
    public string ApplicationName = "";
    public string Bitness = "";
    public List<Key> knownKeys = new List<Key>();
    public List<Key> translatorKnownKeys = new List<Key>();
    public List<Key> unknownAttributeKeys = new List<Key>();
    public List<Key> unknownElementKeys = new List<Key>();
    public ConnectionStrings? connectionStrings;
    public HylandLogging? hylandLogging;
    public HylandIdentityProviderUrl? hylandIdentityProviderUrl;
    public List<RequiredKeywords> requiredKeywords = new List<RequiredKeywords>();
    public HylandApplicationsAgendaPubAccessPublicComment? hylandApplicationsAgendaPubAccessPublicComment;
    public HylandAuthenticationADFS? hylandAuthenticationADFS;
    public HylandAuthentication? hylandAuthentication;
    public HylandResponsiveApps? hylandResponsiveApps;
    public HylandServicesParameters? hylandServicesParameters;
    public HylandPlatterManagement? hylandPlatterManagement;
    public List<string> WindowsAuthOptimizeFor = new List<string>();
    public NavigationPanel? navigationPanel;
    public CustomValidation? customValidation;
    public HealthcareWebViewer? healthcareWebViewer;
    public KeywordDropdownTypeAhead? keywordDropdownTypeAhead;
    public IisConfiguration IisConfiguration = new IisConfiguration();
    public SessionAdministration? sessionAdministration;
    public ElementsToHide elementsToHide = new ElementsToHide();
    public ProcessingErrors processingErrors = new ProcessingErrors();
    public List<HylandApplicationsAgendaPubAccessPublicComment> publicCommentIntegrations = new List<HylandApplicationsAgendaPubAccessPublicComment>();
    
    public void AddCriticalError(string message)
    {
        processingErrors.CriticalErrors.Add(message);
    }
    public void AddNonCriticalError(string message)
    {
        processingErrors.NonCriticalErrors.Add(message);
    }
}

public class Key
{
    public string? Section { get; set; }
    public string? PathName { get; set; }
    public string? AttributeName { get; set; }
    public string? type { get; set; }
    public string? htmlIdName { get; set; }
    public string? Value { get; set; }
    public string? Version { get; set; }
    public string? minimumValue { get; set; }
    public string? maximumValue { get; set; }
}


/********************************************************
*  Public Access Viewer (Next Gen & Legacy) Section(s)
********************************************************/
public class RequiredKeywords
{
    public string? QueryID { get; set; }
    public string? KeywordID { get; set; }
}


/********************************************************
*               Agenda Online Section(s)
********************************************************/
public class HylandApplicationsAgendaPubAccessPublicComment
{
    public string? Name { get; set; }
    public string? URL { get; set; }
    public string? Token { get; set; }
    public string? AvailabilityFromMeetingStart { get; set; }
    public List<MeetingType> meetingTypes = new List<MeetingType>();
    public List<AgendaField> agendaFields = new List<AgendaField>();
    public string? id { get; set; }
}

public class MeetingType
{
    public string? Name { get; set; }
}

public class AgendaField
{
    public string? Name { get; set; }
    public string? FormFieldID { get; set; }
}


/********************************************************
*             Application Server Section(s)
********************************************************/
public class HylandResponsiveApps
{
    public List<ResponsiveApp> responsiveApps = new List<ResponsiveApp>();
}

public class ResponsiveApp
{
    public string? Name = "";
    public string? IconURL = "";
    public string? URL = "";
}

public class HylandServicesParameters
{
    public List<Parameter> parameters = new List<Parameter>();
}

public class Parameter
{
    public string? name = "";
    public string? value = "";
}

public class HylandPlatterManagement
{
    public List<DiskGroupAlias> diskGroupAliases = new List<DiskGroupAlias>();
}

public class DiskGroupAlias
{
    public string? oldname { get; set; }
    public string? newname { get; set; }
    public string? type { get; set; }
    public string? id { get; set; }
}


/********************************************************
*               Connection Strings V2
********************************************************/
public class ConnectionStrings
{
    public string? EncryptConnectionStrings { get; set; }
    public List<ConnectionString> connectionStrings = new List<ConnectionString>();
}

public class ConnectionString
{
    public string? Name { get; set; } = "";
    public string? Provider { get; set; } = "";
    public ConnectionStringSql sql = new ConnectionStringSql();
    public ConnectionStringOracle oracle = new ConnectionStringOracle();
    public string? IntegratedSecurity { get; set; } = "";
    public string? UserId { get; set; } = "";
    public string? Password { get; set; } = "";
    public string? AdditionalOptions { get; set; } = "";
    public string? id { get; set; } = "";
}

public class ConnectionStringSql
{
    public string? DataSource { get; set; } = "";
    public string? Database { get; set; } = "";
}

public class ConnectionStringOracle
{
    public string? TNSConnectionString = "true";
    public string? Host { get; set; } = "";
    public string? Database { get; set; } = "";
    public string? Protocol { get; set; } = "TCP";
    public string? Port { get; set; } = "";
}


/********************************************************
*                  Hyland Logging V2
********************************************************/
public class HylandLogging
{
    public string? truncateloggingcharacters { get; set; }
    public WindowsEventLogging windowsEventLogging = new WindowsEventLogging();
    public List<Route> Routes = new List<Route>();
    public string[] profilesForHTML { get; set; }
}

public class Route
{
    public string? RouteType { get; set; }
    public string? Name { get; set; }
    public string? SourceEvents { get; set; }
    public string? EnableIpAddressMasking { get; set; }
    public Filter filter = new Filter();
    public HylandLoggingRouteEventLog? eventlog;
    public HylandLoggingRouteSplunk? splunk;
    public HylandLoggingRouteFile? file;
    public HylandLoggingRouteHTTP? http;
    public HylandLoggingRouteDurableHTTP? durablehttp;
    public HylandLoggingRouteConsole? console;
    public string? id { get; set; }
}

public class WindowsEventLogging
{
    public string? SourceName { get; set; }
}

public class Filter
{
    public string? MinimumErrorLevel { get; set; }
    public string? MaximumErrorLevel { get; set; }
    public string? FilterProfilesIncludeExcludeNeither { get; set; }
    public List<string> Profiles = new List<string>();
}

public class Profile
{
    public string? Name { get; set; }
}

public class HylandLoggingRouteSplunk
{
    public string? ServerUrl { get; set; }
    public string? SplunkToken { get; set; }
    public string? SplunkIndex { get; set; }
    public string? SplunkSource { get; set; }
    public string? SplunkSourceType { get; set; }
    public string? SplunkHost { get; set; }
}

public class HylandLoggingRouteFile
{
    public string? FilePath { get; set; }
    public string? FileSizeLimit { get; set; }
    public string? RollWhenLimitReached { get; set; }
    public string? RollInterval { get; set; }
    public string? RetainedFilesCount { get; set; }
    public string? OutputFormat { get; set; }
}

public class HylandLoggingRouteDurableHTTP
{
    public string? URL { get; set; }
}

public class HylandLoggingRouteHTTP
{
    public string? URL { get; set; }
}

public class HylandLoggingRouteConsole
{
    public string? OutputFormat { get; set; }
}

public class HylandLoggingRouteEventLog
{
    public string? SourceName { get; set; }
}


/********************************************************
*             Hyland Identity Provider URL
********************************************************/
public class HylandIdentityProviderUrl
{
    public string? ServerLocation { get; set; }
    public string? Tenant { get; set; }
    public string? Client { get; set; }
    public string? Secret { get; set; }
}


/********************************************************
*                Hyland Authentication
********************************************************/
public class HylandAuthentication
{
    public string? TrustMode { get; set; }
    public List<TrustedClient> trustedClients = new List<TrustedClient>();
}

public class TrustedClient
{
    public string? StoreLocation { get; set; }
    public string? StoreName { get; set; }
    public string? FindType { get; set; }
    public string? FindValue { get; set; }
    public string? Description { get; set; }
    public string? id { get; set; }
}

/********************************************************
*            Hyland Authentication - ADFS
********************************************************/
public class HylandAuthenticationADFS
{
    public string ADFSEnabled { get; set; } = "false";
    public string RequestValidationMode { get; set; } = "2.0";
    public string AuthenticationMode { get; set; } = "Windows";
    public string SynchronizeUserAttributes { get; set; } = "true";
    public string AuthenticationOnly { get; set; } = "false";
    public SystemIdentityModel systemIdentityModel = new SystemIdentityModel();
    public SystemIdentityModelServices systemIdentityModelServices = new SystemIdentityModelServices();
    public List<Key> knownKeys = new List<Key>();
}

public class SystemIdentityModel
{
    public List<AudienceUri> audienceUris = new List<AudienceUri>();
    public List<TrustedIssuer> trustedIssuers = new List<TrustedIssuer>();
    
}

public class AudienceUri
{
    public string? URI { get; set; }
    public string? id {  get; set; }
}

public class TrustedIssuer
{
    public string? Thumbprint { get; set; }
    public string? Name { get; set; }
    public string? id { get; set; }
}

public class SystemIdentityModelServices
{
    public string CookieHandlerRequireSSL { get; set; } = "false";
    public wsFederation wsFederation = new wsFederation();
    public ServiceCertificate serviceCertificate = new ServiceCertificate();
}

public class wsFederation
{
    public string? Issuer { get; set; }
    public string? Realm { get; set; }
}

public class ServiceCertificate
{
    public string? X509FindType { get; set; }
    public string? FindValue { get; set; }
    public string? StoreLocation { get; set; }
    public string? StoreName { get; set; }
}


/********************************************************
*            Web Server - Navigation Panel
********************************************************/
public class NavigationPanel
{
    public string defaultContext { get; set; } = "";
    public string defaultControlBar { get; set; } = "";
    public string defaultContextID { get; set; } = "";
    public List<Context> Contexts = new List<Context>();
}

public class Context
{
    public ContextInfo contextInfo = new ContextInfo();
    public List<ControlBar> ControlBars = new List<ControlBar>();
    public string? id { get; set; }
}

public class ContextInfo
{
    public string? name { get; set; }
    public string? displayName { get; set; }
    public string? displayOrder { get; set; }
    public string? icon { get; set; }
    public string? enabled { get; set; }
}

public class ControlBar
{
    public string? name { get; set; }
    public string? displayName { get; set; }
    public string? path { get; set; }
    public string? icon { get; set; }
    public string? useSplitView { get; set; }
    public string? enabled { get; set; }
}


/********************************************************
*            Web Server - Custom Validation
********************************************************/
public class CustomValidation
{
    public ApplicationLevel application = new ApplicationLevel();
    public List<Page> pages = new List<Page>();
}

public class ApplicationLevel
{
    public string? scriptLocation { get; set; }
    public List<Keyword> keywords = new List<Keyword>();
}

public class Page
{
    public string? location { get; set; }
    public string? htmlId { get; set; }
    public string? name { get; set; }
    public string? scriptLocation { get; set; }
    public List<Keyword> keywords = new List<Keyword>();
}

public class Keyword
{
    public string? keywordId { get; set; }
    public string? validator { get; set; }
    public string? id { get; set; }
}


/********************************************************
*           Web Server - Healthcare Web Viewer
********************************************************/
public class HealthcareWebViewer
{
    public List<SourceOrigin> Origins = new List<SourceOrigin>();
}

public class SourceOrigin
{
    public string? origin { get; set; }
    public string? id { get; set; }
}


/********************************************************
*           Web Server - Healthcare Web Viewer
********************************************************/
public class KeywordDropdownTypeAhead
{
    public List<CharacterMinimum> characterMinimums = new List<CharacterMinimum>();
}

public class CharacterMinimum
{
    public string KeywordID = "";
    public string CharacterCount = "";
    public string id = "";
}


/********************************************************
*              IIS Configuration Classes 
********************************************************/
public class IisConfiguration
{
    public IisApplication? application;
    public IisApplicationPool? applicationPool;
}


/********************************************************
*        IIS Configuration Classes - Application
********************************************************/
public class IisApplication
{
    public string? defaultDocument { get; set; }
    public string? anonymousAuthentication { get; set; }
    public string? aspNetImpersonation { get; set; }
    public string? windowsAuthentication { get; set; }
    public string? applicationPoolName { get; set; }
    public string? preLoadEnabled { get; set; }
    public string? useAppPoolCredentials { get; set; }
    public string? sessionAdministrationsUsers { get; set; }
    public string? sessionAdministrationsRoles { get; set; }
}


/********************************************************
*     IIS Configuration Classes - Application Pool
********************************************************/
public class IisApplicationPool
{
    public string? generalNetClrVerson { get; set; }
    public string? generalEnable32BitApplications { get; set; }
    public string? generalManagedPilelineMode { get; set; }
    public string? generalQueueLength { get; set; }
    public string? generalStartMode { get; set; }
    public string? cpuLimitInterval { get; set; }
    public string? processModelIdentityType { get; set; }
    public string? processModelIdentityUsername { get; set; }
    public string? processModelIdentityPassword { get; set; }
    public string? processModelIdleTimeOut { get; set; }
    public string? processModelPingEnabled { get; set; }
    public string? rapidFailProtectionEnabled { get; set; }
    public string? recyclingRegularTimeInterval { get; set; }
}


/********************************************************
*      Application Server Session Administration
********************************************************/
public class SessionAdministration
{
    public List<ApplicationSessionAdministrationUser> users = new List<ApplicationSessionAdministrationUser>();
    public List<ApplicationSessionAdministrationRole> roles = new List<ApplicationSessionAdministrationRole>();
}

public class ApplicationSessionAdministrationUser
{
    public string? user { get; set; }
    public string? id { get; set; }
}

public class ApplicationSessionAdministrationRole
{
    public string? role { get; set; }
    public string? id { get; set; }
}


/********************************************************
*      Elements to Hide in the Web Application
********************************************************/
public class ElementsToHide
{
    public List<Element> elements = new List<Element>();
}

public class Element
{
    public string? HtmlName { get; set; }
}


/********************************************************
*       Error/Result Information Handling Object
********************************************************/
public class ProcessingErrors
{
    public List<string> CriticalErrors = new List<string>();
    public List<string> NonCriticalErrors = new List<string>();
}


/********************************************************
*       Error/Result Information Handling Object
********************************************************/
public class SavingResults
{
    public List<string> CriticalErrors = new List<string>();
    public List<string> NonCriticalErrors = new List<string>();
}
