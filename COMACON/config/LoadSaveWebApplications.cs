﻿using COMACON.ComaconHelper;
using COMACONTranslationToHelperUtility;
using Microsoft.Web.Administration;
using Newtonsoft.Json;
//using System.Text.RegularExpressions;
using System.Xml;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace COMACON.config;

public interface LoadSaveWebApplications
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
    public string LoadWebApplicationConfiguration(TextReader reader,
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
    public string SaveWebApplicationConfiguration(string jsonDataStructure);
}

internal sealed class DefaultLoadSaveWebApplications : LoadSaveWebApplications
{
    private readonly ComaconHelperProxy ComaconHelperProxy;
    private readonly GenericHelperMethods GenericHelperMethods;
    private readonly WebApplicationDataStructures webApplicationDataStructures;
    private readonly SessionManagement sessionManagement;

    public DefaultLoadSaveWebApplications(ComaconHelperProxy proxy,
        GenericHelperMethods genericHelperMethods,
        WebApplicationDataStructures WebApplicationDataStructures,
        SessionManagement SessionManagement)
    {
        ComaconHelperProxy = proxy;
        GenericHelperMethods = genericHelperMethods;
        webApplicationDataStructures = WebApplicationDataStructures;
        sessionManagement = SessionManagement;
    }

    public string LoadWebApplicationConfiguration(TextReader reader,
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

        //string serializedObject = ComaconHelperProxy.Get(applicationPath, applicationName, webApplicationType, "211");
        //var translator = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(serializedObject);

        XmlNode root = xmlDoc.DocumentElement;
        XmlNode appSettings = root.SelectSingleNode("appSettings");
        XmlNode systemweb = root.SelectSingleNode("system.web");
        //Will need to add this section processing at some point in time.
        //XmlNode HylandApplicationsSharepointServices = root.SelectSingleNode("Hyland.Applications.Sharepoint.Services");
        //XmlNode HylandApplicationsSharepointSearchAdapter = root.SelectSingleNode("Hyland.Applications.Sharepoint.SearchAdapter");

        GenericHelperMethods.CheckHylandDllFiles(physicalPath, webApplicationVersion);
        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);
        GenericHelperMethods.getTootips(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);
        GenericHelperMethods.getGenericWebApplicationTooltips(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);

        switch (webApplicationType)
        {
            case "Application Server":
                GenericHelperMethods.ParseSessionAdministration(webconfigconfig, physicalPath + @"\Admin\sessionAdminSecurity.config");
                break;
            case "Agenda Online":
                break;
            case "Electronic Plan Review":
                break;
            case "Gateway Caching Server":
                break;
            case "Healthcare Form Manager":
                break;
            case "Patient Window":
                break;
            case "Public Access Viewer - Legacy":
                break;
            case "Public Access Viewer - Next Gen":
                break;
            case "Reporting Viewer":
                break;
            case "Web Server":
                GenericHelperMethods.ParseKeys(webconfigconfig, appSettings, "KeywordDropdownTypeaheadCharacterMinimum");
                GenericHelperMethods.getHealthcareWebViewerEnabled(webconfigconfig, root.SelectSingleNode("system.webServer"));
                break;
        }


        /********************************************************
         *               Load IIS Configuration
         ********************************************************/
        GenericHelperMethods.LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);

        return JsonConvert.SerializeObject(webconfigconfig);
    }

    public string SaveWebApplicationConfiguration(string jsonDataStructure)
    {
        webApplicationWebConfigConfiguration core = JsonConvert.DeserializeObject<webApplicationWebConfigConfiguration>(jsonDataStructure);
        XmlDocument configurationDocument = new XmlDocument();
        configurationDocument.Load(core.PhysicalPath + @"\web.config");
        var translatortoreturn = new NETCoreToNetFrameworkTranslator();

        File.Copy(core.PhysicalPath + @"\web.config", core.PhysicalPath + @"\web_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");
        if(core.Type == "Application Server")
        {
            File.Copy(core.PhysicalPath + @"\Admin\sessionAdminSecurity.config", core.PhysicalPath + @"\Admin\sessionAdminSecurity_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".config.bak");
        }

        List<string> elementsToSave = webApplicationDataStructures.getElementsToSave(core.Type, core.Version.Split('.')[0] + core.Version.Split('.')[1]);

        XmlNode root = configurationDocument.DocumentElement;

        foreach(string element in elementsToSave)
        {
            XmlNode node = root.SelectSingleNode(element);
            GenericHelperMethods.SaveKnownKeys(core, element, node, configurationDocument);
        }

        switch (core.Type)
        {
            case "Agenda Online Server":
                break;
            case "Application Server":
                GenericHelperMethods.SaveKnownKeys(core, "ADFS", root, configurationDocument);
                GenericHelperMethods.SaveKnownKeys(core, "Hyland.Authentication-TrustedClients", root.SelectSingleNode("Hyland.Authentication"), configurationDocument);
                GenericHelperMethods.SaveArrayItems("ResponsiveAppsApps", root.SelectSingleNode("Hyland.ResponsiveApps"), core, configurationDocument);
                GenericHelperMethods.SaveArrayItems("DiskGroupAliases", root.SelectSingleNode("Hyland.PlatterManagement"), core, configurationDocument);
                GenericHelperMethods.SaveArrayItems("Parameters", root.SelectSingleNode("Hyland.Services"), core, configurationDocument);
                GenericHelperMethods.SaveArrayItems("FormattedTextIframeSupportedDomains",root.SelectSingleNode("Hyland.WorkView.Core/FormattedTextIframeSupportedDomains"), core, configurationDocument);
                GenericHelperMethods.SaveKnownKeys(core, "Hyland.Core.Wopi", root, configurationDocument);
                break;
            case "Electronic Plan Review":
                break;
            case "Gateway Caching Server":
                break;
            case "Healthcare Form Manager":
                break;
            case "Patient Window":
                GenericHelperMethods.SaveKnownKeys(core, "ADFS", root, configurationDocument);
                break;
            case "Public Access Viewer - Legacy":
                GenericHelperMethods.SaveRequireKeywords(configurationDocument, root.SelectSingleNode("RequiredKeywords"), core);
                break;
            case "Public Access Viewer - Next Gen":
                GenericHelperMethods.SaveRequireKeywords(configurationDocument, root.SelectSingleNode("RequiredKeywords"), core);
                break;
            case "Reporting Viewer":
                break;
            case "Web Server":
                GenericHelperMethods.SaveKnownKeys(core, "ADFS", root, configurationDocument);
                GenericHelperMethods.SaveKnownKeys(core, "Healthcare Web Viewer Origin URL", root.SelectSingleNode("Hyland.Web.HealthcareWebViewer"), configurationDocument);
                GenericHelperMethods.SaveKnownKeys(core, "Keyword Dropdown Typeahead", root.SelectSingleNode("appSettings"), configurationDocument);
                foreach (Key k in core.knownKeys)
                {
                    if (k.Section == "Hyland.Web.HealthcareWebViewer" && k.PathName == "IsEnabled")
                    {
                        GenericHelperMethods.setHealthcareWebViewerEnabled(core, root.SelectSingleNode("system.webServer"), bool.Parse(k.Value), configurationDocument);
                    }
                }
                break;
        }

        configurationDocument.Save(core.PhysicalPath + @"\web.config");

        if(core.Type == "Application Server")
        {
            GenericHelperMethods.SaveSessionAdministration(core, core.PhysicalPath + @"\Admin\sessionAdminSecurity.config");
        }

        if(core.Type == "Application Server" || core.Type == "Reporting Viewer" || core.Type == "Web Server")
        {
            GenericHelperMethods.processOptimizeForWindowsAuthSelection(core.WindowsAuthOptimizeFor, core.SiteName, core.Path, core.ApplicationName, core.Type);
        }

        GenericHelperMethods.SaveIisConfiguration(core, root.SelectSingleNode("system.web"));


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
}