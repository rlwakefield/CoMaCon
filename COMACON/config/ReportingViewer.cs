using COMACON.ComaconHelper;
using COMACONTranslationToHelperUtility;
using Microsoft.Web.Administration;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace COMACON.config;

public interface ReportingViewerConfiguration
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
    public string LoadReportingViewerConfiguration(TextReader reader,
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
    public string SaveReportingViewerServerConfiguration(string jsonDataStructure);
}

internal sealed class DefaultReportingViewerConfiguration : ReportingViewerConfiguration
{
    private readonly ComaconHelperProxy ComaconHelperProxy;
    private readonly GenericHelperMethods GenericHelperMethods;
    private readonly WebApplicationDataStructures webApplicationDataStructures;

    public DefaultReportingViewerConfiguration(ComaconHelperProxy proxy, GenericHelperMethods genericHelperMethods, WebApplicationDataStructures WebApplicationDataStructures)
    {
        ComaconHelperProxy = proxy;
        GenericHelperMethods = genericHelperMethods;
        webApplicationDataStructures = WebApplicationDataStructures;
    }

    public string LoadReportingViewerConfiguration(TextReader reader,
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
                return Load211ReportingViewerConfiguration(reader, webApplicationType, webApplicationVersion, siteName, applicationName, applicationPath, physicalPath, bitness);
            case var s when s.StartsWith("22.1"):
                return Load221ReportingViewerConfiguration(reader, webApplicationType, webApplicationVersion, siteName, applicationName, applicationPath, physicalPath, bitness);
            case var s when s.StartsWith("23.1"):
                return Load231ReportingViewerConfiguration(reader, webApplicationType, webApplicationVersion, siteName, applicationName, applicationPath, physicalPath, bitness);
            case var s when s.StartsWith("24.1"):
                return Load241ReportingViewerConfiguration(reader, webApplicationType, webApplicationVersion, siteName, applicationName, applicationPath, physicalPath, bitness);
        }
        return "";
    }

    public string Load211ReportingViewerConfiguration(TextReader reader,
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

        //Get the serialized output and store it.
        //string serializedObject = ComaconHelperProxy.Get(applicationPath, applicationName, webApplicationType, "211");
        //Console.WriteLine(serializedObject);
        //Deserialize the object.
        //var translator = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(serializedObject);

        XmlNode root = xmlDoc.DocumentElement;
        XmlNode systemweb = root.SelectSingleNode("system.web");

        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        //GenericHelperMethods.ParseTranslator(webconfigconfig, translator);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);


        /********************************************************
         *               Load IIS Configuration
         ********************************************************/
        GenericHelperMethods.LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);


        return JsonConvert.SerializeObject(webconfigconfig);
    }

    public string Load221ReportingViewerConfiguration(TextReader reader,
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

        //Get the serialized output and store it.
        //string serializedObject = ComaconHelperProxy.Get(applicationPath, applicationName, webApplicationType, "221");
        //Deserialize the object.
        //var translator = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(serializedObject);

        XmlNode root = xmlDoc.DocumentElement;
        XmlNode systemweb = root.SelectSingleNode("system.web");

        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        //GenericHelperMethods.ParseTranslator(webconfigconfig, translator);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);


        /********************************************************
         *               Load IIS Configuration
         ********************************************************/
        GenericHelperMethods.LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);


        return JsonConvert.SerializeObject(webconfigconfig);
    }

    public string Load231ReportingViewerConfiguration(TextReader reader,
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

        //Get the serialized output and store it.
        //string serializedObject = ComaconHelperProxy.Get(applicationPath, applicationName, webApplicationType, "231");
        //Deserialize the object.
        //var translator = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(serializedObject);

        XmlNode root = xmlDoc.DocumentElement;
        XmlNode systemweb = root.SelectSingleNode("system.web");

        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        //GenericHelperMethods.ParseTranslator(webconfigconfig, translator);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);


        /********************************************************
         *               Load IIS Configuration
         ********************************************************/
        GenericHelperMethods.LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);


        return JsonConvert.SerializeObject(webconfigconfig);
    }

    public string Load241ReportingViewerConfiguration(TextReader reader,
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

        //Get the serialized output and store it.
        //string serializedObject = ComaconHelperProxy.Get(applicationPath, applicationName, webApplicationType, "231");
        //Deserialize the object.
        //var translator = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(serializedObject);

        XmlNode root = xmlDoc.DocumentElement;
        XmlNode systemweb = root.SelectSingleNode("system.web");

        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        //GenericHelperMethods.ParseTranslator(webconfigconfig, translator);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);


        /********************************************************
         *               Load IIS Configuration
         ********************************************************/
        GenericHelperMethods.LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);


        return JsonConvert.SerializeObject(webconfigconfig);
    }

    public string SaveReportingViewerServerConfiguration(string jsonDataStructure)
    {
        // Console.WriteLine("Json Data Structure: " + jsonDataStructure);
        var jsonObject = JObject.Parse(jsonDataStructure);
        // string version = jsonObject["Version"].ToString();
        string majorVersion = jsonObject["Version"].ToString().Substring(0, jsonObject["Version"].ToString().IndexOf(".", jsonObject["Version"].ToString().IndexOf(".") + 1));
        // Console.WriteLine("Version: " + version);
        // Console.WriteLine("Major Version: " + majorVersion);
        switch (majorVersion)
        {
            case "21.1":
                return Save211ReportingViewerServerConfiguration(jsonDataStructure);
            case "22.1":
                return Save221ReportingViewerServerConfiguration(jsonDataStructure);
            case "23.1":
                return Save231ReportingViewerServerConfiguration(jsonDataStructure);
            case "24.1":
                return Save241ReportingViewerServerConfiguration(jsonDataStructure);
            default:
                // Console.WriteLine("Hit the default statement.");
                break;
        }

        return "";
    }

    public string Save211ReportingViewerServerConfiguration(string jsonDataStructure)
    {
        webApplicationWebConfigConfiguration core = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(jsonDataStructure);
        XmlDocument configurationDocument = new XmlDocument();
        configurationDocument.Load(core.PhysicalPath + @"\web.config");
        var translatortoreturn = new NETCoreToNetFrameworkTranslator();

        File.Copy(core.PhysicalPath + @"\web.config", core.PhysicalPath + @"\web_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");

        XmlNode root = configurationDocument.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode HylandWebDashboardViewer = root.SelectSingleNode("Hyland.Web.DashboardViewer");
        XmlNode HylandServicesClient = root.SelectSingleNode("Hyland.Services.Client");
        XmlNode HylandLogging = root.SelectSingleNode("Hyland.Logging");
        XmlNode systemweb = root.SelectSingleNode("system.web");
        XmlNode systemwebextensions = root.SelectSingleNode("system.web.extensions");
        XmlNode systemwebServer = root.SelectSingleNode("system.webServer");
        XmlNode systemnet = root.SelectSingleNode("system.net");
        XmlNode systemdiagnostics = root.SelectSingleNode("system.diagnostics");
        XmlNode devExpress = root.SelectSingleNode("devExpress");

        GenericHelperMethods.SaveKnownKeys(core, "appSettings", appSettings, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Services.Client", HylandServicesClient, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web", systemweb, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.webServer", systemwebServer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.diagnostics", systemdiagnostics, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web.extensions", systemwebextensions, configurationDocument);

        configurationDocument.Save(core.PhysicalPath + @"\web.config");

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

    public string Save221ReportingViewerServerConfiguration(string jsonDataStructure)
    {
        webApplicationWebConfigConfiguration core = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(jsonDataStructure);
        XmlDocument configurationDocument = new XmlDocument();
        configurationDocument.Load(core.PhysicalPath + @"\web.config");
        var translatortoreturn = new NETCoreToNetFrameworkTranslator();

        File.Copy(core.PhysicalPath + @"\web.config", core.PhysicalPath + @"\web_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");

        XmlNode root = configurationDocument.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode HylandWebDashboardViewer = root.SelectSingleNode("Hyland.Web.DashboardViewer");
        XmlNode HylandServicesClient = root.SelectSingleNode("Hyland.Services.Client");
        XmlNode HylandLogging = root.SelectSingleNode("Hyland.Logging");
        XmlNode systemweb = root.SelectSingleNode("system.web");
        XmlNode systemwebextensions = root.SelectSingleNode("system.web.extensions");
        XmlNode systemwebServer = root.SelectSingleNode("system.webServer");
        XmlNode systemnet = root.SelectSingleNode("system.net");
        XmlNode systemdiagnostics = root.SelectSingleNode("system.diagnostics");
        XmlNode devExpress = root.SelectSingleNode("devExpress");

        GenericHelperMethods.SaveKnownKeys(core, "appSettings", appSettings, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Services.Client", HylandServicesClient, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web", systemweb, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.webServer", systemwebServer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.diagnostics", systemdiagnostics, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web.extensions", systemwebextensions, configurationDocument);

        configurationDocument.Save(core.PhysicalPath + @"\web.config");

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

    public string Save231ReportingViewerServerConfiguration(string jsonDataStructure)
    {
        webApplicationWebConfigConfiguration core = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(jsonDataStructure);
        XmlDocument configurationDocument = new XmlDocument();
        configurationDocument.Load(core.PhysicalPath + @"\web.config");
        var translatortoreturn = new NETCoreToNetFrameworkTranslator();

        File.Copy(core.PhysicalPath + @"\web.config", core.PhysicalPath + @"\web_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");

        XmlNode root = configurationDocument.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode HylandWebDashboardViewer = root.SelectSingleNode("Hyland.Web.DashboardViewer");
        XmlNode HylandServicesClient = root.SelectSingleNode("Hyland.Services.Client");
        XmlNode HylandLogging = root.SelectSingleNode("Hyland.Logging");
        XmlNode systemweb = root.SelectSingleNode("system.web");
        XmlNode systemwebextensions = root.SelectSingleNode("system.web.extensions");
        XmlNode systemwebServer = root.SelectSingleNode("system.webServer");
        XmlNode systemnet = root.SelectSingleNode("system.net");
        XmlNode systemdiagnostics = root.SelectSingleNode("system.diagnostics");
        XmlNode devExpress = root.SelectSingleNode("devExpress");

        GenericHelperMethods.SaveKnownKeys(core, "appSettings", appSettings, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Services.Client", HylandServicesClient, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web", systemweb, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.webServer", systemwebServer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.diagnostics", systemdiagnostics, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web.extensions", systemwebextensions, configurationDocument);

        configurationDocument.Save(core.PhysicalPath + @"\web.config");

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

    public string Save241ReportingViewerServerConfiguration(string jsonDataStructure)
    {
        webApplicationWebConfigConfiguration core = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(jsonDataStructure);
        XmlDocument configurationDocument = new XmlDocument();
        configurationDocument.Load(core.PhysicalPath + @"\web.config");
        var translatortoreturn = new NETCoreToNetFrameworkTranslator();

        File.Copy(core.PhysicalPath + @"\web.config", core.PhysicalPath + @"\web_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");

        XmlNode root = configurationDocument.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode HylandWebDashboardViewer = root.SelectSingleNode("Hyland.Web.DashboardViewer");
        XmlNode HylandServicesClient = root.SelectSingleNode("Hyland.Services.Client");
        XmlNode HylandLogging = root.SelectSingleNode("Hyland.Logging");
        XmlNode systemweb = root.SelectSingleNode("system.web");
        XmlNode systemwebextensions = root.SelectSingleNode("system.web.extensions");
        XmlNode systemwebServer = root.SelectSingleNode("system.webServer");
        XmlNode systemnet = root.SelectSingleNode("system.net");
        XmlNode systemdiagnostics = root.SelectSingleNode("system.diagnostics");
        XmlNode devExpress = root.SelectSingleNode("devExpress");

        GenericHelperMethods.SaveKnownKeys(core, "appSettings", appSettings, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Services.Client", HylandServicesClient, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web", systemweb, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.webServer", systemwebServer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.diagnostics", systemdiagnostics, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web.extensions", systemwebextensions, configurationDocument);

        configurationDocument.Save(core.PhysicalPath + @"\web.config");

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