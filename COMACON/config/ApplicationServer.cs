using COMACON.ComaconHelper;
using COMACONTranslationToHelperUtility;
using Microsoft.Web.Administration;
using Newtonsoft.Json;
//using System.Text.RegularExpressions;
using System.Xml;
using Serilog;
//using COMACON.ComaconHelper;
using Newtonsoft.Json.Linq;
//using static System.Collections.Specialized.BitVector32;
//using System.Xml.Linq;

namespace COMACON.config;

public interface ApplicationServerConfiguration
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
    public string LoadApplicationServerConfiguration(TextReader reader,
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
    public string SaveApplicationServerConfiguration(string jsonDataStructure);
}

internal sealed class DefaultApplicationServerConfiguration : ApplicationServerConfiguration
{
    private readonly ComaconHelperProxy ComaconHelperProxy;
    private readonly GenericHelperMethods GenericHelperMethods;
    private readonly WebApplicationDataStructures webApplicationDataStructures;

    public DefaultApplicationServerConfiguration(ComaconHelperProxy proxy, GenericHelperMethods genericHelperMethods, WebApplicationDataStructures WebApplicationDataStructures)
    {
        ComaconHelperProxy = proxy;
        GenericHelperMethods = genericHelperMethods;
        webApplicationDataStructures = WebApplicationDataStructures;
    }

    public string LoadApplicationServerConfiguration(TextReader reader,
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
                return Load211ApplicationServerConfiguration(reader, webApplicationType, webApplicationVersion, siteName, applicationName, applicationPath, physicalPath, bitness);
            case var s when s.StartsWith("22.1"):
                return Load221ApplicationServerConfiguration(reader, webApplicationType, webApplicationVersion, siteName, applicationName, applicationPath, physicalPath, bitness);
            case var s when s.StartsWith("23.1"):
                return Load231ApplicationServerConfiguration(reader, webApplicationType, webApplicationVersion, siteName, applicationName, applicationPath, physicalPath, bitness);
            case var s when s.StartsWith("24.1"):
                return Load241ApplicationServerConfiguration(reader, webApplicationType, webApplicationVersion, siteName, applicationName, applicationPath, physicalPath, bitness);
        }
        return "";
    }

    public string Load211ApplicationServerConfiguration(TextReader reader,
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
        //CoreAppServerDataStructure applicationServerDataStructure = new CoreAppServerDataStructure();
        ServerManager manager = new ServerManager();
        Configuration config = manager.GetWebConfiguration(siteName + applicationPath + applicationName);

        //Get the serialized output and store it.
        //Log.Logger.Information("Getting the potentially protected sections of the web.config.");
        //string serializedObject = ComaconHelperProxy.Get(applicationPath, applicationName, webApplicationType, "211");
        //Deserialize the object.
        //var translator = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(serializedObject);

        /* Setting up the default XmlNode sections for processing. */
        XmlNode root = xmlDoc.DocumentElement;
        XmlNode systemweb = root.SelectSingleNode("system.web");

        //! Need to figure out how to implement this functionality and all in the UI.
        XmlNode HylandApplicationsSharepointServices = root.SelectSingleNode("Hyland.Applications.Sharepoint.Services");
        XmlNode HylandApplicationsSharepointSearchAdapter = root.SelectSingleNode("Hyland.Applications.Sharepoint.SearchAdapter");
        
        //! Still need to implement this as I am not sure why it is blank in the default web.config.
        //XmlNode HylandCoreMedia = root.SelectSingleNode("Hyland.Core.Media");

        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        //GenericHelperMethods.CreateOptimizeWindowsAuthenticationForArray(config, webApplicationDataStructures, xmlDoc, webconfigconfig, webApplicationType, translator, root.SelectSingleNode("appSettings"));
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        //GenericHelperMethods.ParseTranslator(webconfigconfig, translator);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);

        GenericHelperMethods.ParseSessionAdministration(webconfigconfig, physicalPath + @"\Admin\sessionAdminSecurity.config");



        /********************************************************
         *               Load IIS Configuration
         ********************************************************/
        GenericHelperMethods.LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);


        //Console.WriteLine(JsonConvert.SerializeObject(webconfigconfig));
        return JsonConvert.SerializeObject(webconfigconfig);
    }

    public string Load221ApplicationServerConfiguration(TextReader reader,
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
        //CoreAppServerDataStructure applicationServerDataStructure = new CoreAppServerDataStructure();
        ServerManager manager = new ServerManager();
        Configuration config = manager.GetWebConfiguration(siteName + applicationPath + applicationName);

        //Get the serialized output and store it.
        //Log.Logger.Information("Getting the potentially protected sections of the web.config.");
        //string serializedObject = ComaconHelperProxy.Get(applicationPath, applicationName, webApplicationType, "221");
        //Deserialize the object.
        //var translator = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(serializedObject);

        /* Setting up the default XmlNode sections for processing. */
        XmlNode root = xmlDoc.DocumentElement;
        XmlNode systemweb = root.SelectSingleNode("system.web");

        //! Need to figure out how to implement this functionality and all in the UI.
        XmlNode HylandApplicationsSharepointServices = root.SelectSingleNode("Hyland.Applications.Sharepoint.Services");
        XmlNode HylandApplicationsSharepointSearchAdapter = root.SelectSingleNode("Hyland.Applications.Sharepoint.SearchAdapter");

        //! Still need to implement this as I am not sure why it is blank in the default web.config.
        //XmlNode HylandCoreMedia = root.SelectSingleNode("Hyland.Core.Media");

        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        //GenericHelperMethods.CreateOptimizeWindowsAuthenticationForArray(config, webApplicationDataStructures, xmlDoc, webconfigconfig, webApplicationType, translator, root.SelectSingleNode("appSettings"));
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        //GenericHelperMethods.ParseTranslator(webconfigconfig, translator);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);

        GenericHelperMethods.ParseSessionAdministration(webconfigconfig, physicalPath + @"\Admin\sessionAdminSecurity.config");



        /********************************************************
         *               Load IIS Configuration
         ********************************************************/
        GenericHelperMethods.LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);


        //Console.WriteLine(JsonConvert.SerializeObject(webconfigconfig));
        return JsonConvert.SerializeObject(webconfigconfig);
    }

    public string Load231ApplicationServerConfiguration(TextReader reader,
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
        //CoreAppServerDataStructure applicationServerDataStructure = new CoreAppServerDataStructure();
        ServerManager manager = new ServerManager();
        Configuration config = manager.GetWebConfiguration(siteName + applicationPath + applicationName);

        //Get the serialized output and store it.
        //Log.Logger.Information("Getting the potentially protected sections of the web.config.");
        //string serializedObject = ComaconHelperProxy.Get(applicationPath, applicationName, webApplicationType, "231");
        //Deserialize the object.
        //var translator = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(serializedObject);

        /* Setting up the default XmlNode sections for processing. */
        XmlNode root = xmlDoc.DocumentElement;
        XmlNode systemweb = root.SelectSingleNode("system.web");

        //! Need to figure out how to implement this functionality and all in the UI.
        XmlNode HylandApplicationsSharepointServices = root.SelectSingleNode("Hyland.Applications.Sharepoint.Services");
        XmlNode HylandApplicationsSharepointSearchAdapter = root.SelectSingleNode("Hyland.Applications.Sharepoint.SearchAdapter");

        //! Still need to implement this as I am not sure why it is blank in the default web.config.
        //XmlNode HylandCoreMedia = root.SelectSingleNode("Hyland.Core.Media");

        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        //GenericHelperMethods.CreateOptimizeWindowsAuthenticationForArray(config, webApplicationDataStructures, xmlDoc, webconfigconfig, webApplicationType, translator, root.SelectSingleNode("appSettings"));
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        //GenericHelperMethods.ParseTranslator(webconfigconfig, translator);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);

        GenericHelperMethods.ParseSessionAdministration(webconfigconfig, physicalPath + @"\Admin\sessionAdminSecurity.config");



        /********************************************************
         *               Load IIS Configuration
         ********************************************************/
        GenericHelperMethods.LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);


        //Console.WriteLine(JsonConvert.SerializeObject(webconfigconfig));
        return JsonConvert.SerializeObject(webconfigconfig);
    }

    public string Load241ApplicationServerConfiguration(TextReader reader,
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
        //CoreAppServerDataStructure applicationServerDataStructure = new CoreAppServerDataStructure();
        ServerManager manager = new ServerManager();
        Configuration config = manager.GetWebConfiguration(siteName + applicationPath + applicationName);

        //Get the serialized output and store it.
        //Log.Logger.Information("Getting the potentially protected sections of the web.config.");
        //string serializedObject = ComaconHelperProxy.Get(applicationPath, applicationName, webApplicationType, "241");
        //Deserialize the object.
        //var translator = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(serializedObject);

        /* Setting up the default XmlNode sections for processing. */
        XmlNode root = xmlDoc.DocumentElement;
        XmlNode systemweb = root.SelectSingleNode("system.web");

        //! Need to figure out how to implement this functionality and all in the UI.
        XmlNode HylandApplicationsSharepointServices = root.SelectSingleNode("Hyland.Applications.Sharepoint.Services");
        XmlNode HylandApplicationsSharepointSearchAdapter = root.SelectSingleNode("Hyland.Applications.Sharepoint.SearchAdapter");

        //! Still need to implement this as I am not sure why it is blank in the default web.config.
        //XmlNode HylandCoreMedia = root.SelectSingleNode("Hyland.Core.Media");

        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        //GenericHelperMethods.CreateOptimizeWindowsAuthenticationForArray(config, webApplicationDataStructures, xmlDoc, webconfigconfig, webApplicationType, translator, root.SelectSingleNode("appSettings"));
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        //GenericHelperMethods.ParseTranslator(webconfigconfig, translator);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);

        GenericHelperMethods.ParseSessionAdministration(webconfigconfig, physicalPath + @"\Admin\sessionAdminSecurity.config");



        /********************************************************
         *               Load IIS Configuration
         ********************************************************/
        GenericHelperMethods.LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);


        //Console.WriteLine(JsonConvert.SerializeObject(webconfigconfig));
        return JsonConvert.SerializeObject(webconfigconfig);
    }

    public string SaveApplicationServerConfiguration(string jsonDataStructure)
    {
        //Console.WriteLine("Json Data Structure: " + jsonDataStructure);
        var jsonObject = JObject.Parse(jsonDataStructure);
        string majorVersion = jsonObject["Version"].ToString().Substring(0, jsonObject["Version"].ToString().IndexOf(".", jsonObject["Version"].ToString().IndexOf(".") + 1));
        switch (majorVersion)
        {
            case "21.1":
                return Save211ApplicationServerConfiguration(jsonDataStructure);
            case "22.1":
                return Save221ApplicationServerConfiguration(jsonDataStructure);
            case "23.1":
                return Save231ApplicationServerConfiguration(jsonDataStructure);
            case "24.1":
                return Save241ApplicationServerConfiguration(jsonDataStructure);
        }

        return "";
    }

    public string Save211ApplicationServerConfiguration(string jsonDataStructure)
    {
        webApplicationWebConfigConfiguration core = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(jsonDataStructure);
        //CoreAppServerDataStructure core = JsonConvert.DeserializeObject<CoreAppServerDataStructure>(jsonDataStructure);
        XmlDocument configurationDocument = new XmlDocument();
        configurationDocument.Load(core.PhysicalPath + @"\web.config");
        var translatortoreturn = new NETCoreToNetFrameworkTranslator();

        File.Copy(core.PhysicalPath + @"\web.config", core.PhysicalPath + @"\web_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");
        File.Copy(core.PhysicalPath + @"\Admin\sessionAdminSecurity.config", core.PhysicalPath + @"\Admin\sessionAdminSecurity_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");

        XmlNode root = configurationDocument.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode systemdiagnostics = root.SelectSingleNode("system.diagnostics");
        XmlNode systemweb = root.SelectSingleNode("system.web");
        XmlNode systemwebServer = root.SelectSingleNode("system.webServer");
        XmlNode HylandResponsiveApps = root.SelectSingleNode("Hyland.ResponsiveApps");
        //! Need to figure out how to implement this functionality and all in the UI.
        XmlNode HylandApplicationsSharepointServices = root.SelectSingleNode("Hyland.Applications.Sharepoint.Services");
        XmlNode HylandApplicationsSharepointSearchAdapter = root.SelectSingleNode("Hyland.Applications.Sharepoint.SearchAdapter");
        XmlNode HylandPlatterManagement = root.SelectSingleNode("Hyland.PlatterManagement");
        XmlNode HylandServices = root.SelectSingleNode("Hyland.Services");
        XmlNode HylandXMLServicesDocumentConnector = root.SelectSingleNode("Hyland.XMLServices.DocumentConnector");
        XmlNode HylandCoreFullText = root.SelectSingleNode("Hyland.Core.FullText");
        XmlNode HylandWorkViewCore = root.SelectSingleNode("Hyland.WorkView.Core");
        //! Still need to implement this as I am not sure why it is blank in the default web.config.
        XmlNode HylandCoreMedia = root.SelectSingleNode("Hyland.Core.Media");
        XmlNode HylandCoreMediaHostedApplicationServer = root.SelectSingleNode("Hyland.Core.Media.HostedApplicationServer");
        XmlNode HylandAuthentication = root.SelectSingleNode("Hyland.Authentication");
        XmlNode HylandCoreIDOL = root.SelectSingleNode("Hyland.Core.IDOL");
        XmlNode HylandCoreWopi = root.SelectSingleNode("Hyland.Core.Wopi");
        XmlNode HylandIntegrationsLOBBrokerLOBBrokerConfigSection = root.SelectSingleNode("Hyland.Integrations.LOBBroker.LOBBrokerConfigSection");
        XmlNode systemidentityModel = root.SelectSingleNode("system.identityModel");
        XmlNode systemidentityModelservices = root.SelectSingleNode("system.identityModel.services");
        XmlNode systemserviceModel = root.SelectSingleNode("system.serviceModel");
        XmlNode HylandLogging = root.SelectSingleNode("Hyland.Logging");

        GenericHelperMethods.SaveKnownKeys(core, "appSettings", appSettings, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web", systemweb, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.webServer", systemwebServer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "ADFS", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.ResponsiveApps", HylandResponsiveApps, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.PlatterManagement", HylandPlatterManagement, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Services", HylandServices, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.XMLServices.DocumentConnector", HylandXMLServicesDocumentConnector, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.FullText", HylandCoreFullText, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.WorkView.Core", HylandWorkViewCore, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.IDOL", HylandCoreIDOL, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "root", root, configurationDocument);
        if(HylandCoreWopi != null)
        {
            GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.Wopi", HylandCoreWopi, configurationDocument);
        }
        else
        {
            GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.Wopi", root, configurationDocument);
        }
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.Wopi", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Integrations.LOBBroker.LOBBRokerConfigSection", HylandIntegrationsLOBBrokerLOBBrokerConfigSection, configurationDocument);
        //GenericHelperMethods.SaveKnownKeys(core, "system.diagnostics", null, configurationDocument);
        //GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Authentication", HylandAuthentication, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Authentication-TrustedClients", HylandAuthentication, configurationDocument);
        //GenericHelperMethods.SaveKnownKeys(core, "", null, configurationDocument);
        GenericHelperMethods.SaveArrayItems("ResponsiveAppsApps", HylandResponsiveApps, core, configurationDocument);
        GenericHelperMethods.SaveArrayItems("DiskGroupAliases", HylandPlatterManagement, core, configurationDocument);
        GenericHelperMethods.SaveArrayItems("Parameters", HylandServices, core, configurationDocument);

        configurationDocument.Save(core.PhysicalPath + @"\web.config");

        GenericHelperMethods.SaveSessionAdministration(core, core.PhysicalPath + @"\Admin\sessionAdminSecurity.config");

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

    public string Save221ApplicationServerConfiguration(string jsonDataStructure)
    {
        webApplicationWebConfigConfiguration core = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(jsonDataStructure);
        //CoreAppServerDataStructure core = JsonConvert.DeserializeObject<CoreAppServerDataStructure>(jsonDataStructure);
        XmlDocument configurationDocument = new XmlDocument();
        configurationDocument.Load(core.PhysicalPath + @"\web.config");
        var translatortoreturn = new NETCoreToNetFrameworkTranslator();

        File.Copy(core.PhysicalPath + @"\web.config", core.PhysicalPath + @"\web_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");
        File.Copy(core.PhysicalPath + @"\Admin\sessionAdminSecurity.config", core.PhysicalPath + @"\Admin\sessionAdminSecurity_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");

        XmlNode root = configurationDocument.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode systemdiagnostics = root.SelectSingleNode("system.diagnostics");
        XmlNode systemweb = root.SelectSingleNode("system.web");
        XmlNode systemwebServer = root.SelectSingleNode("system.webServer");
        XmlNode HylandResponsiveApps = root.SelectSingleNode("Hyland.ResponsiveApps");
        //! Need to figure out how to implement this functionality and all in the UI.
        XmlNode HylandApplicationsSharepointServices = root.SelectSingleNode("Hyland.Applications.Sharepoint.Services");
        XmlNode HylandApplicationsSharepointSearchAdapter = root.SelectSingleNode("Hyland.Applications.Sharepoint.SearchAdapter");
        XmlNode HylandPlatterManagement = root.SelectSingleNode("Hyland.PlatterManagement");
        XmlNode HylandServices = root.SelectSingleNode("Hyland.Services");
        XmlNode HylandXMLServicesDocumentConnector = root.SelectSingleNode("Hyland.XMLServices.DocumentConnector");
        XmlNode HylandCoreFullText = root.SelectSingleNode("Hyland.Core.FullText");
        XmlNode HylandWorkViewCore = root.SelectSingleNode("Hyland.WorkView.Core");
        //! Still need to implement this as I am not sure why it is blank in the default web.config.
        XmlNode HylandCoreMedia = root.SelectSingleNode("Hyland.Core.Media");
        XmlNode HylandCoreMediaHostedApplicationServer = root.SelectSingleNode("Hyland.Core.Media.HostedApplicationServer");
        XmlNode HylandAuthentication = root.SelectSingleNode("Hyland.Authentication");
        XmlNode HylandCoreWopi = root.SelectSingleNode("Hyland.Core.Wopi");
        XmlNode HylandIntegrationsLOBBrokerLOBBrokerConfigSection = root.SelectSingleNode("Hyland.Integrations.LOBBroker.LOBBrokerConfigSection");
        XmlNode systemidentityModel = root.SelectSingleNode("system.identityModel");
        XmlNode systemidentityModelservices = root.SelectSingleNode("system.identityModel.services");
        XmlNode systemserviceModel = root.SelectSingleNode("system.serviceModel");
        XmlNode HylandLogging = root.SelectSingleNode("Hyland.Logging");

        GenericHelperMethods.SaveKnownKeys(core, "appSettings", appSettings, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web", systemweb, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.webServer", systemwebServer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "ADFS", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.ResponsiveApps", HylandResponsiveApps, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.PlatterManagement", HylandPlatterManagement, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Services", HylandServices, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.XMLServices.DocumentConnector", HylandXMLServicesDocumentConnector, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.FullText", HylandCoreFullText, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.WorkView.Core", HylandWorkViewCore, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "root", root, configurationDocument);
        if (HylandCoreWopi != null)
        {
            GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.Wopi", HylandCoreWopi, configurationDocument);
        }
        else
        {
            GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.Wopi", root, configurationDocument);
        }
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.Wopi", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Integrations.LOBBroker.LOBBRokerConfigSection", HylandIntegrationsLOBBrokerLOBBrokerConfigSection, configurationDocument);
        //GenericHelperMethods.SaveKnownKeys(core, "system.diagnostics", null, configurationDocument);
        //GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Authentication", HylandAuthentication, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Authentication-TrustedClients", HylandAuthentication, configurationDocument);
        //GenericHelperMethods.SaveKnownKeys(core, "", null, configurationDocument);
        GenericHelperMethods.SaveArrayItems("ResponsiveAppsApps", HylandResponsiveApps, core, configurationDocument);
        GenericHelperMethods.SaveArrayItems("DiskGroupAliases", HylandPlatterManagement, core, configurationDocument);
        GenericHelperMethods.SaveArrayItems("Parameters", HylandServices, core, configurationDocument);

        configurationDocument.Save(core.PhysicalPath + @"\web.config");

        GenericHelperMethods.SaveSessionAdministration(core, core.PhysicalPath + @"\Admin\sessionAdminSecurity.config");

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

    public string Save231ApplicationServerConfiguration(string jsonDataStructure)
    {
        webApplicationWebConfigConfiguration core = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(jsonDataStructure);
        //CoreAppServerDataStructure core = JsonConvert.DeserializeObject<CoreAppServerDataStructure>(jsonDataStructure);
        XmlDocument configurationDocument = new XmlDocument();
        configurationDocument.Load(core.PhysicalPath + @"\web.config");
        var translatortoreturn = new NETCoreToNetFrameworkTranslator();

        File.Copy(core.PhysicalPath + @"\web.config", core.PhysicalPath + @"\web_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");
        File.Copy(core.PhysicalPath + @"\Admin\sessionAdminSecurity.config", core.PhysicalPath + @"\Admin\sessionAdminSecurity_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");

        XmlNode root = configurationDocument.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode systemdiagnostics = root.SelectSingleNode("system.diagnostics");
        XmlNode systemweb = root.SelectSingleNode("system.web");
        XmlNode systemwebServer = root.SelectSingleNode("system.webServer");
        XmlNode HylandResponsiveApps = root.SelectSingleNode("Hyland.ResponsiveApps");
        //! Need to figure out how to implement this functionality and all in the UI.
        XmlNode HylandApplicationsSharepointServices = root.SelectSingleNode("Hyland.Applications.Sharepoint.Services");
        XmlNode HylandApplicationsSharepointSearchAdapter = root.SelectSingleNode("Hyland.Applications.Sharepoint.SearchAdapter");
        XmlNode HylandPlatterManagement = root.SelectSingleNode("Hyland.PlatterManagement");
        XmlNode HylandServices = root.SelectSingleNode("Hyland.Services");
        XmlNode HylandXMLServicesDocumentConnector = root.SelectSingleNode("Hyland.XMLServices.DocumentConnector");
        XmlNode HylandCoreFullText = root.SelectSingleNode("Hyland.Core.FullText");
        XmlNode HylandWorkViewCore = root.SelectSingleNode("Hyland.WorkView.Core");
        //! Still need to implement this as I am not sure why it is blank in the default web.config.
        XmlNode HylandCoreMedia = root.SelectSingleNode("Hyland.Core.Media");
        XmlNode HylandCoreMediaHostedApplicationServer = root.SelectSingleNode("Hyland.Core.Media.HostedApplicationServer");
        XmlNode HylandAuthentication = root.SelectSingleNode("Hyland.Authentication");
        XmlNode HylandIntegrationsLOBBrokerLOBBrokerConfigSection = root.SelectSingleNode("Hyland.Integrations.LOBBroker.LOBBrokerConfigSection");
        XmlNode systemidentityModel = root.SelectSingleNode("system.identityModel");
        XmlNode systemidentityModelservices = root.SelectSingleNode("system.identityModel.services");
        XmlNode systemserviceModel = root.SelectSingleNode("system.serviceModel");
        XmlNode HylandLogging = root.SelectSingleNode("Hyland.Logging");

        GenericHelperMethods.SaveKnownKeys(core, "appSettings", appSettings, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web", systemweb, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.webServer", systemwebServer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "ADFS", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.ResponsiveApps", HylandResponsiveApps, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.PlatterManagement", HylandPlatterManagement, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Services", HylandServices, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.XMLServices.DocumentConnector", HylandXMLServicesDocumentConnector, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.FullText", HylandCoreFullText, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.WorkView.Core", HylandWorkViewCore, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "root", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.Wopi", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Integrations.LOBBroker.LOBBRokerConfigSection", HylandIntegrationsLOBBrokerLOBBrokerConfigSection, configurationDocument);
        //GenericHelperMethods.SaveKnownKeys(core, "system.diagnostics", null, configurationDocument);
        //GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Authentication", HylandAuthentication, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Authentication-TrustedClients", HylandAuthentication, configurationDocument);
        //GenericHelperMethods.SaveKnownKeys(core, "", null, configurationDocument);
        GenericHelperMethods.SaveArrayItems("ResponsiveAppsApps", HylandResponsiveApps, core, configurationDocument);
        GenericHelperMethods.SaveArrayItems("DiskGroupAliases", HylandPlatterManagement, core, configurationDocument);
        GenericHelperMethods.SaveArrayItems("Parameters", HylandServices, core, configurationDocument);

        configurationDocument.Save(core.PhysicalPath + @"\web.config");

        GenericHelperMethods.SaveSessionAdministration(core, core.PhysicalPath + @"\Admin\sessionAdminSecurity.config");

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

    public string Save241ApplicationServerConfiguration(string jsonDataStructure)
    {
        webApplicationWebConfigConfiguration core = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(jsonDataStructure);
        //CoreAppServerDataStructure core = JsonConvert.DeserializeObject<CoreAppServerDataStructure>(jsonDataStructure);
        XmlDocument configurationDocument = new XmlDocument();
        configurationDocument.Load(core.PhysicalPath + @"\web.config");
        var translatortoreturn = new NETCoreToNetFrameworkTranslator();

        File.Copy(core.PhysicalPath + @"\web.config", core.PhysicalPath + @"\web_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");
        File.Copy(core.PhysicalPath + @"\Admin\sessionAdminSecurity.config", core.PhysicalPath + @"\Admin\sessionAdminSecurity_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");

        XmlNode root = configurationDocument.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode systemdiagnostics = root.SelectSingleNode("system.diagnostics");
        XmlNode systemweb = root.SelectSingleNode("system.web");
        XmlNode systemwebServer = root.SelectSingleNode("system.webServer");
        XmlNode HylandResponsiveApps = root.SelectSingleNode("Hyland.ResponsiveApps");
        //! Need to figure out how to implement this functionality and all in the UI.
        XmlNode HylandApplicationsSharepointServices = root.SelectSingleNode("Hyland.Applications.Sharepoint.Services");
        XmlNode HylandApplicationsSharepointSearchAdapter = root.SelectSingleNode("Hyland.Applications.Sharepoint.SearchAdapter");
        XmlNode HylandPlatterManagement = root.SelectSingleNode("Hyland.PlatterManagement");
        XmlNode HylandServices = root.SelectSingleNode("Hyland.Services");
        XmlNode HylandXMLServicesDocumentConnector = root.SelectSingleNode("Hyland.XMLServices.DocumentConnector");
        XmlNode HylandCoreFullText = root.SelectSingleNode("Hyland.Core.FullText");
        XmlNode HylandWorkViewCore = root.SelectSingleNode("Hyland.WorkView.Core");
        //! Still need to implement this as I am not sure why it is blank in the default web.config.
        XmlNode HylandCoreMedia = root.SelectSingleNode("Hyland.Core.Media");
        XmlNode HylandCoreMediaHostedApplicationServer = root.SelectSingleNode("Hyland.Core.Media.HostedApplicationServer");
        XmlNode HylandAuthentication = root.SelectSingleNode("Hyland.Authentication");
        XmlNode HylandIntegrationsLOBBrokerLOBBrokerConfigSection = root.SelectSingleNode("Hyland.Integrations.LOBBroker.LOBBrokerConfigSection");
        XmlNode systemidentityModel = root.SelectSingleNode("system.identityModel");
        XmlNode systemidentityModelservices = root.SelectSingleNode("system.identityModel.services");
        XmlNode systemserviceModel = root.SelectSingleNode("system.serviceModel");
        XmlNode HylandLogging = root.SelectSingleNode("Hyland.Logging");

        GenericHelperMethods.SaveKnownKeys(core, "appSettings", appSettings, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.web", systemweb, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "system.webServer", systemwebServer, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "ADFS", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.ResponsiveApps", HylandResponsiveApps, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.PlatterManagement", HylandPlatterManagement, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Services", HylandServices, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.XMLServices.DocumentConnector", HylandXMLServicesDocumentConnector, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.FullText", HylandCoreFullText, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.WorkView.Core", HylandWorkViewCore, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "root", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.Wopi", root, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Integrations.LOBBroker.LOBBRokerConfigSection", HylandIntegrationsLOBBrokerLOBBrokerConfigSection, configurationDocument);
        //GenericHelperMethods.SaveKnownKeys(core, "system.diagnostics", null, configurationDocument);
        //GenericHelperMethods.SaveKnownKeys(core, "Hyland.Logging", HylandLogging, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Authentication", HylandAuthentication, configurationDocument);
        GenericHelperMethods.SaveKnownKeys(core, "Hyland.Authentication-TrustedClients", HylandAuthentication, configurationDocument);
        //GenericHelperMethods.SaveKnownKeys(core, "", null, configurationDocument);
        GenericHelperMethods.SaveArrayItems("ResponsiveAppsApps", HylandResponsiveApps, core, configurationDocument);
        GenericHelperMethods.SaveArrayItems("DiskGroupAliases", HylandPlatterManagement, core, configurationDocument);
        GenericHelperMethods.SaveArrayItems("Parameters", HylandServices, core, configurationDocument);

        configurationDocument.Save(core.PhysicalPath + @"\web.config");

        GenericHelperMethods.SaveSessionAdministration(core, core.PhysicalPath + @"\Admin\sessionAdminSecurity.config");

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