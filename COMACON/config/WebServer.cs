using COMACON.ComaconHelper;
using COMACONTranslationToHelperUtility;
using Microsoft.Web.Administration;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json.Linq;
using Serilog;
using static System.Collections.Specialized.BitVector32;
using static System.Formats.Asn1.AsnWriter;

namespace COMACON.config;

public interface WebServerConfiguration
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="reader"></param>
    /// <param name="webApplicationType"></param>
    /// <param name="webApplicationVersion"></param>
    /// <param name="siteName"></param>
    /// <param name="applicationName"></param>
    /// <param name="applicationPath"></param>
    /// <param name="physicalPath"></param>
    /// <param name="bitness"></param>
    /// <returns>
    /// 
    /// </returns>
    public string LoadWebServerConfiguration(TextReader reader,
            string webApplicationType,
            string webApplicationVersion,
            string siteName,
            string applicationName,
            string applicationPath,
            string physicalPath,
            string bitness);
    /// <summary>
    ///
    /// </summary>
    /// <param name="jsonDataStructure"></param>
    /// <returns>
    /// 
    /// </returns>
    public string SaveWebServerConfiguration(string jsonDataStructure);
}

internal sealed class DefaultWebServerConfiguration : WebServerConfiguration
{
    private readonly ComaconHelperProxy ComaconHelperProxy;
    private readonly GenericHelperMethods GenericHelperMethods;
    private readonly WebApplicationDataStructures webApplicationDataStructures;

    public DefaultWebServerConfiguration(ComaconHelperProxy proxy, GenericHelperMethods genericHelperMethods, WebApplicationDataStructures WebApplicationDataStructures)
    {
        ComaconHelperProxy = proxy;
        GenericHelperMethods = genericHelperMethods;
        webApplicationDataStructures = WebApplicationDataStructures;
    }

    public string LoadWebServerConfiguration(TextReader reader,
            string webApplicationType,
            string webApplicationVersion,
            string siteName,
            string applicationName,
            string applicationPath,
            string physicalPath,
            string bitness)
    {
        GenericHelperMethods.CheckHylandDllFiles(physicalPath,webApplicationVersion);

        switch (webApplicationVersion)
        {
            case var s when s.StartsWith("21.1"):
                return Load211WebServerConfiguration(reader, webApplicationType, webApplicationVersion, siteName, applicationName, applicationPath, physicalPath, bitness);
            case var s when s.StartsWith("22.1"):
                return Load221WebServerConfiguration(reader, webApplicationType, webApplicationVersion, siteName, applicationName, applicationPath, physicalPath, bitness);
            case var s when s.StartsWith("23.1"):
                return Load231WebServerConfiguration(reader, webApplicationType, webApplicationVersion, siteName, applicationName, applicationPath, physicalPath, bitness);
            case var s when s.StartsWith("24.1"):
                return Load241WebServerConfiguration(reader, webApplicationType, webApplicationVersion, siteName, applicationName, applicationPath, physicalPath, bitness);
        }
        return "";
    }

    public string Load211WebServerConfiguration(TextReader reader,
            string webApplicationType,
            string webApplicationVersion,
            string siteName,
            string applicationName,
            string applicationPath,
            string physicalPath,
            string bitness)
    {
        //Pre-paring work.
        var validXml = reader.ReadToEnd();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(validXml);

        webApplicationWebConfigConfiguration webconfigconfig = new webApplicationWebConfigConfiguration();
        ServerManager manager = new ServerManager();
        Configuration config = manager.GetWebConfiguration(siteName + applicationPath + applicationName);

        XmlNode root = xmlDoc.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode systemweb = root.SelectSingleNode("system.web");

        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);
        GenericHelperMethods.ParseKeys(webconfigconfig, appSettings, "KeywordDropdownTypeaheadCharacterMinimum");
        GenericHelperMethods.getHealthcareWebViewerEnabled(webconfigconfig, root.SelectSingleNode("system.webServer"));

        GenericHelperMethods.LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);

        return JsonConvert.SerializeObject(webconfigconfig);
    }

    public string Load221WebServerConfiguration(TextReader reader,
            string webApplicationType,
            string webApplicationVersion,
            string siteName,
            string applicationName,
            string applicationPath,
            string physicalPath,
            string bitness)
    {
        //Pre-paring work.
        var validXml = reader.ReadToEnd();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(validXml);

        webApplicationWebConfigConfiguration webconfigconfig = new webApplicationWebConfigConfiguration();
        ServerManager manager = new ServerManager();
        Configuration config = manager.GetWebConfiguration(siteName + applicationPath + applicationName);

        XmlNode root = xmlDoc.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode systemweb = root.SelectSingleNode("system.web");

        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);
        GenericHelperMethods.ParseKeys(webconfigconfig, appSettings, "KeywordDropdownTypeaheadCharacterMinimum");
        GenericHelperMethods.getHealthcareWebViewerEnabled(webconfigconfig, root.SelectSingleNode("system.webServer"));

        GenericHelperMethods.LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);

        return JsonConvert.SerializeObject(webconfigconfig);
    }

    public string Load231WebServerConfiguration(TextReader reader,
            string webApplicationType,
            string webApplicationVersion,
            string siteName,
            string applicationName,
            string applicationPath,
            string physicalPath,
            string bitness)
    {
        //Pre-paring work.
        var validXml = reader.ReadToEnd();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(validXml);

        webApplicationWebConfigConfiguration webconfigconfig = new webApplicationWebConfigConfiguration();
        ServerManager manager = new ServerManager();
        Configuration config = manager.GetWebConfiguration(siteName + applicationPath + applicationName);

        XmlNode root = xmlDoc.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode systemweb = root.SelectSingleNode("system.web");

        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0]+ webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);
        GenericHelperMethods.ParseKeys(webconfigconfig, appSettings, "KeywordDropdownTypeaheadCharacterMinimum");
        GenericHelperMethods.getHealthcareWebViewerEnabled(webconfigconfig, root.SelectSingleNode("system.webServer"));

        GenericHelperMethods.LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);

        return JsonConvert.SerializeObject(webconfigconfig);
    }

    public string Load241WebServerConfiguration(TextReader reader,
            string webApplicationType,
            string webApplicationVersion,
            string siteName,
            string applicationName,
            string applicationPath,
            string physicalPath,
            string bitness)
    {
        //Pre-paring work.
        var validXml = reader.ReadToEnd();

        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(validXml);

        webApplicationWebConfigConfiguration webconfigconfig = new webApplicationWebConfigConfiguration();
        ServerManager manager = new ServerManager();
        Configuration config = manager.GetWebConfiguration(siteName + applicationPath + applicationName);

        XmlNode root = xmlDoc.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode systemweb = root.SelectSingleNode("system.web");

        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);
        GenericHelperMethods.ParseKeys(webconfigconfig, appSettings, "KeywordDropdownTypeaheadCharacterMinimum");
        GenericHelperMethods.getHealthcareWebViewerEnabled(webconfigconfig, root.SelectSingleNode("system.webServer"));

        GenericHelperMethods.LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);

        return JsonConvert.SerializeObject(webconfigconfig);
    }

    public string SaveWebServerConfiguration(string jsonDataStructure)
    {
        var jsonObject = JObject.Parse(jsonDataStructure);
        string majorVersion = jsonObject["Version"].ToString().Substring(0, jsonObject["Version"].ToString().IndexOf(".", jsonObject["Version"].ToString().IndexOf(".") + 1));
        switch (majorVersion)
        {
            case "21.1":
                return Save211WebServerConfiguration(jsonDataStructure);
            case "22.1":
                return Save221WebServerConfiguration(jsonDataStructure);
            case "23.1":
                return Save231WebServerConfiguration(jsonDataStructure);
            case "24.1":
                return Save241WebServerConfiguration(jsonDataStructure);
            default:
                break;
        }

        return "";
    }

    public string Save211WebServerConfiguration(string jsonDataStructure)
    {
        webApplicationWebConfigConfiguration core = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(jsonDataStructure);
        XmlDocument configurationDocument = new XmlDocument();
        configurationDocument.Load(core.PhysicalPath + @"\web.config");
        var translatortoreturn = new NETCoreToNetFrameworkTranslator();

        //Copy the web.config file to a backup file and rename it to web_DateYYYYMMDD_TimeHHMMSS.config.bak
        File.Copy(core.PhysicalPath + @"\web.config", core.PhysicalPath + @"\web_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");

        XmlNode root = configurationDocument.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode systemdiagnostics = root.SelectSingleNode("system.diagnostics");
        XmlNode systemweb = root.SelectSingleNode("system.web");
        XmlNode systemwebextensions = root.SelectSingleNode("system.web.extensions");
        XmlNode systemwebServer = root.SelectSingleNode("system.webServer");
        XmlNode systemnet = root.SelectSingleNode("system.net");
        XmlNode systemserviceModal = root.SelectSingleNode("system.serviceModel");
        XmlNode HylandServicesClient = root.SelectSingleNode("Hyland.Services.Client");
        XmlNode HylandLogging = root.SelectSingleNode("Hyland.Logging");
        XmlNode NavigationPanel = root.SelectSingleNode("NavigationPanel");
        XmlNode CustomValidation = root.SelectSingleNode("CustomValidation");
        XmlNode HylandAuthentication = root.SelectSingleNode("Hyland.Authentication");
        XmlNode systemidentityModel = root.SelectSingleNode("system.identityModel");
        XmlNode systemidentityModelservices = root.SelectSingleNode("system.identityModel.services");
        XmlNode HylandWebDashboardViewer = root.SelectSingleNode("Hyland.Web.DashboardViewer");
        XmlNode HylandWebHealthcareWebViewer = root.SelectSingleNode("Hyland.Web.HealthcareWebViewer");

        GenericHelperMethods.SaveKnownKeys(core, "appSettings", appSettings, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Services.Client", HylandServicesClient, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web", systemweb, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.webServer", systemwebServer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Web.DashboardViewer", HylandWebDashboardViewer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Web.HealthcareWebViewer", HylandWebHealthcareWebViewer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.diagnostics", systemdiagnostics, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "ADFS", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Custom Validation", CustomValidation, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Navigation Panel", NavigationPanel, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Healthcare Web Viewer Origin URL", HylandWebHealthcareWebViewer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Keyword Dropdown Typeahead", appSettings, configurationDocument);
        foreach (Key k in core.knownKeys)
        {
            if(k.Section == "Hyland.Web.HealthcareWebViewer" && k.PathName == "IsEnabled")
            {
                GenericHelperMethods.setHealthcareWebViewerEnabled(core, systemwebServer, bool.Parse(k.Value), configurationDocument);
            }
        }

        configurationDocument.Save(core.PhysicalPath + @"\web.config");

        //Checks the Windows Authentication Optimize For setting to determine what needs to be done:
        GenericHelperMethods.processOptimizeForWindowsAuthSelection(core.WindowsAuthOptimizeFor, core.SiteName, core.Path, core.ApplicationName, core.Type);

        GenericHelperMethods.SaveIisConfiguration(core, systemweb);


        /********************************************************
         *              Translator To Return Work
         ********************************************************/
        GenericHelperMethods.createWebApplicationTranslatorToReturnV2(translatortoreturn, core);
        //Console.WriteLine(JsonConvert.SerializeObject(translatortoreturn));
        string serializedOutputObject = JsonConvert.SerializeObject(translatortoreturn);


        /********************************************************
         *         Get the serialized output and store it.
         ********************************************************/
        string serializedObject = ComaconHelperProxy.Set(core.Path, core.ApplicationName, core.Type, serializedOutputObject, "211");
        //Console.WriteLine(serializedObject);


        /********************************************************
         *         Returns a hard coded 200 (for now).
         ********************************************************/
        return "200";
    }

    public string Save221WebServerConfiguration(string jsonDataStructure)
    {
        webApplicationWebConfigConfiguration core = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(jsonDataStructure);
        XmlDocument configurationDocument = new XmlDocument();
        configurationDocument.Load(core.PhysicalPath + @"\web.config");
        var translatortoreturn = new NETCoreToNetFrameworkTranslator();

        File.Copy(core.PhysicalPath + @"\web.config", core.PhysicalPath + @"\web_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");

        XmlNode root = configurationDocument.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode systemdiagnostics = root.SelectSingleNode("system.diagnostics");
        XmlNode systemweb = root.SelectSingleNode("system.web");
        XmlNode systemwebextensions = root.SelectSingleNode("system.web.extensions");
        XmlNode systemwebServer = root.SelectSingleNode("system.webServer");
        XmlNode systemnet = root.SelectSingleNode("system.net");
        XmlNode systemserviceModal = root.SelectSingleNode("system.serviceModel");
        XmlNode HylandServicesClient = root.SelectSingleNode("Hyland.Services.Client");
        XmlNode HylandLogging = root.SelectSingleNode("Hyland.Logging");
        XmlNode NavigationPanel = root.SelectSingleNode("NavigationPanel");
        XmlNode CustomValidation = root.SelectSingleNode("CustomValidation");
        XmlNode HylandAuthentication = root.SelectSingleNode("Hyland.Authentication");
        XmlNode systemidentityModel = root.SelectSingleNode("system.identityModel");
        XmlNode systemidentityModelservices = root.SelectSingleNode("system.identityModel.services");
        XmlNode HylandWebDashboardViewer = root.SelectSingleNode("Hyland.Web.DashboardViewer");
        XmlNode HylandWebHealthcareWebViewer = root.SelectSingleNode("Hyland.Web.HealthcareWebViewer");

        GenericHelperMethods.SaveKnownKeys(core, "appSettings", appSettings, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Services.Client", HylandServicesClient, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web", systemweb, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.webServer", systemwebServer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Web.DashboardViewer", HylandWebDashboardViewer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Web.HealthcareWebViewer", HylandWebHealthcareWebViewer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.diagnostics", systemdiagnostics, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "ADFS", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Custom Validation", CustomValidation, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Navigation Panel", NavigationPanel, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Healthcare Web Viewer Origin URL", HylandWebHealthcareWebViewer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Keyword Dropdown Typeahead", appSettings, configurationDocument);
        foreach (Key k in core.knownKeys)
        {
            if (k.Section == "Hyland.Web.HealthcareWebViewer" && k.PathName == "IsEnabled")
            {
                GenericHelperMethods.setHealthcareWebViewerEnabled(core, systemwebServer, bool.Parse(k.Value), configurationDocument);
            }
        }

        configurationDocument.Save(core.PhysicalPath + @"\web.config");

        //Checks the Windows Authentication Optimize For setting to determine what needs to be done:
        GenericHelperMethods.processOptimizeForWindowsAuthSelection(core.WindowsAuthOptimizeFor, core.SiteName, core.Path, core.ApplicationName, core.Type);

        GenericHelperMethods.SaveIisConfiguration(core, systemweb);


        /********************************************************
         *              Translator To Return Work
         ********************************************************/
        GenericHelperMethods.createWebApplicationTranslatorToReturnV2(translatortoreturn, core);
        //Console.WriteLine(JsonConvert.SerializeObject(translatortoreturn));
        string serializedOutputObject = JsonConvert.SerializeObject(translatortoreturn);


        /********************************************************
         *         Get the serialized output and store it.
         ********************************************************/
        string serializedObject = ComaconHelperProxy.Set(core.Path, core.ApplicationName, core.Type, serializedOutputObject, "221");
        //Console.WriteLine(serializedObject);


        /********************************************************
         *         Returns a hard coded 200 (for now).
         ********************************************************/
        return "200";
    }

    public string Save231WebServerConfiguration(string jsonDataStructure)
    {
        webApplicationWebConfigConfiguration core = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(jsonDataStructure);
        XmlDocument configurationDocument = new XmlDocument();
        configurationDocument.Load(core.PhysicalPath + @"\web.config");
        var translatortoreturn = new NETCoreToNetFrameworkTranslator();

        File.Copy(core.PhysicalPath + @"\web.config", core.PhysicalPath + @"\web_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");

        XmlNode root = configurationDocument.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode systemdiagnostics = root.SelectSingleNode("system.diagnostics");
        XmlNode systemweb = root.SelectSingleNode("system.web");
        XmlNode systemwebextensions = root.SelectSingleNode("system.web.extensions");
        XmlNode systemwebServer = root.SelectSingleNode("system.webServer");
        XmlNode systemnet = root.SelectSingleNode("system.net");
        XmlNode systemserviceModal = root.SelectSingleNode("system.serviceModel");
        XmlNode HylandServicesClient = root.SelectSingleNode("Hyland.Services.Client");
        XmlNode HylandLogging = root.SelectSingleNode("Hyland.Logging");
        XmlNode NavigationPanel = root.SelectSingleNode("NavigationPanel");
        XmlNode CustomValidation = root.SelectSingleNode("CustomValidation");
        XmlNode HylandAuthentication = root.SelectSingleNode("Hyland.Authentication");
        XmlNode systemidentityModel = root.SelectSingleNode("system.identityModel");
        XmlNode systemidentityModelservices = root.SelectSingleNode("system.identityModel.services");
        XmlNode HylandWebDashboardViewer = root.SelectSingleNode("Hyland.Web.DashboardViewer");
        XmlNode HylandWebHealthcareWebViewer = root.SelectSingleNode("Hyland.Web.HealthcareWebViewer");

        GenericHelperMethods.SaveKnownKeys(core, "appSettings", appSettings, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Services.Client", HylandServicesClient, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web", systemweb, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.webServer", systemwebServer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Web.DashboardViewer", HylandWebDashboardViewer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Web.HealthcareWebViewer", HylandWebHealthcareWebViewer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.diagnostics", systemdiagnostics, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "ADFS", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Custom Validation", CustomValidation, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Navigation Panel", NavigationPanel, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Healthcare Web Viewer Origin URL", HylandWebHealthcareWebViewer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Keyword Dropdown Typeahead", appSettings, configurationDocument);
        foreach (Key k in core.knownKeys)
        {
            if (k.Section == "Hyland.Web.HealthcareWebViewer" && k.PathName == "IsEnabled")
            {
                GenericHelperMethods.setHealthcareWebViewerEnabled(core, systemwebServer, bool.Parse(k.Value), configurationDocument);
                break;
            }
        }

        configurationDocument.Save(core.PhysicalPath + @"\web.config");

        //Checks the Windows Authentication Optimize For setting to determine what needs to be done:
        GenericHelperMethods.processOptimizeForWindowsAuthSelection(core.WindowsAuthOptimizeFor, core.SiteName, core.Path, core.ApplicationName, core.Type);

        GenericHelperMethods.SaveIisConfiguration(core, systemweb);


        /********************************************************
         *              Translator To Return Work
         ********************************************************/
        GenericHelperMethods.createWebApplicationTranslatorToReturnV2(translatortoreturn, core);
        //Console.WriteLine(JsonConvert.SerializeObject(translatortoreturn));
        string serializedOutputObject = JsonConvert.SerializeObject(translatortoreturn);


        /********************************************************
         *         Get the serialized output and store it.
         ********************************************************/
        string serializedObject = ComaconHelperProxy.Set(core.Path, core.ApplicationName, core.Type, serializedOutputObject, "231");
        //Console.WriteLine(serializedObject);


        /********************************************************
         *         Returns a hard coded 200 (for now).
         ********************************************************/
        return "200";
    }

    public string Save241WebServerConfiguration(string jsonDataStructure)
    {
        webApplicationWebConfigConfiguration core = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(jsonDataStructure);
        XmlDocument configurationDocument = new XmlDocument();
        configurationDocument.Load(core.PhysicalPath + @"\web.config");
        var translatortoreturn = new NETCoreToNetFrameworkTranslator();

        File.Copy(core.PhysicalPath + @"\web.config", core.PhysicalPath + @"\web_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");

        XmlNode root = configurationDocument.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode systemdiagnostics = root.SelectSingleNode("system.diagnostics");
        XmlNode systemweb = root.SelectSingleNode("system.web");
        XmlNode systemwebextensions = root.SelectSingleNode("system.web.extensions");
        XmlNode systemwebServer = root.SelectSingleNode("system.webServer");
        XmlNode systemnet = root.SelectSingleNode("system.net");
        XmlNode systemserviceModal = root.SelectSingleNode("system.serviceModel");
        XmlNode HylandServicesClient = root.SelectSingleNode("Hyland.Services.Client");
        XmlNode HylandLogging = root.SelectSingleNode("Hyland.Logging");
        XmlNode NavigationPanel = root.SelectSingleNode("NavigationPanel");
        XmlNode CustomValidation = root.SelectSingleNode("CustomValidation");
        XmlNode HylandAuthentication = root.SelectSingleNode("Hyland.Authentication");
        XmlNode systemidentityModel = root.SelectSingleNode("system.identityModel");
        XmlNode systemidentityModelservices = root.SelectSingleNode("system.identityModel.services");
        XmlNode HylandWebDashboardViewer = root.SelectSingleNode("Hyland.Web.DashboardViewer");
        XmlNode HylandWebHealthcareWebViewer = root.SelectSingleNode("Hyland.Web.HealthcareWebViewer");

        GenericHelperMethods.SaveKnownKeys(core, "appSettings", appSettings, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Services.Client", HylandServicesClient, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web", systemweb, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.webServer", systemwebServer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Web.DashboardViewer", HylandWebDashboardViewer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Web.HealthcareWebViewer", HylandWebHealthcareWebViewer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.diagnostics", systemdiagnostics, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "ADFS", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Custom Validation", CustomValidation, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Navigation Panel", NavigationPanel, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Healthcare Web Viewer Origin URL", HylandWebHealthcareWebViewer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Keyword Dropdown Typeahead", appSettings, configurationDocument);
        foreach (Key k in core.knownKeys)
        {
            if (k.Section == "Hyland.Web.HealthcareWebViewer" && k.PathName == "IsEnabled")
            {
                GenericHelperMethods.setHealthcareWebViewerEnabled(core, systemwebServer, bool.Parse(k.Value), configurationDocument);
                break;
            }
        }

        configurationDocument.Save(core.PhysicalPath + @"\web.config");

        //Checks the Windows Authentication Optimize For setting to determine what needs to be done:
        GenericHelperMethods.processOptimizeForWindowsAuthSelection(core.WindowsAuthOptimizeFor, core.SiteName, core.Path, core.ApplicationName, core.Type);

        GenericHelperMethods.SaveIisConfiguration(core, systemweb);


        /********************************************************
         *              Translator To Return Work
         ********************************************************/
        GenericHelperMethods.createWebApplicationTranslatorToReturnV2(translatortoreturn, core);
        //Console.WriteLine(JsonConvert.SerializeObject(translatortoreturn));
        string serializedOutputObject = JsonConvert.SerializeObject(translatortoreturn);


        /********************************************************
         *         Get the serialized output and store it.
         ********************************************************/
        string serializedObject = ComaconHelperProxy.Set(core.Path, core.ApplicationName, core.Type, serializedOutputObject, "241");
        //Console.WriteLine(serializedObject);


        /********************************************************
         *         Returns a hard coded 200 (for now).
         ********************************************************/
        return "200";
    }
}