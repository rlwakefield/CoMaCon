using COMACON.ComaconHelper;
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

    public DefaultLoadSaveWebApplications(ComaconHelperProxy proxy, GenericHelperMethods genericHelperMethods, WebApplicationDataStructures WebApplicationDataStructures)
    {
        ComaconHelperProxy = proxy;
        GenericHelperMethods = genericHelperMethods;
        webApplicationDataStructures = WebApplicationDataStructures;
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

        GenericHelperMethods.ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
        GenericHelperMethods.ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1]);
        GenericHelperMethods.processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
        GenericHelperMethods.getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion.Split('.')[0] + webApplicationVersion.Split('.')[1], webApplicationDataStructures);

        switch(webApplicationType)
        {
            case "Application Server":
                GenericHelperMethods.ParseSessionAdministration(webconfigconfig, physicalPath + @"\Admin\sessionAdminSecurity.config");
                break;
            case "Agenda Online Server":
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
        return "200";
    }
}