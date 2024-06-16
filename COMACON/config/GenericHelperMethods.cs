using Microsoft.Web.Administration;
using Newtonsoft.Json;
using System.Xml;
using Serilog;
using System.Diagnostics;
using System.Reflection;
using System.Xml.Linq;
using COMACONTranslationToHelperUtility;
using COMACON.ComaconHelper;

namespace COMACON.config;

public interface GenericHelperMethods
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="node"></param>
    /// <param name="nodeName"></param>
    /// <param name="attributeName"></param>
    /// <param name="defaultValue"></param>
    /// <returns>
    /// 
    /// </returns>
    public string getStandardXmlValue(XmlNode node,
        string nodeName,
        string attributeName,
        string defaultValue);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="node"></param>
    /// <param name="keyName"></param>
    /// <param name="defaultValue"></param>
    /// <returns>
    /// 
    /// </returns>
    public string getNonStandardXmlValue(XmlNode node,
        string keyName,
        string defaultValue);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="node"></param>
    /// <param name="elementName"></param>
    /// <param name="keyName"></param>
    /// <param name="defaultValue"></param>
    /// <returns>
    /// 
    /// </returns>
    public string getNonStandardXmlValueInnerText(XmlNode node,
        string elementName,
        string keyName,
        string defaultValue);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="node"></param>
    /// <param name="nodeName"></param>
    /// <param name="attributeName"></param>
    /// <param name="newValue"></param>
    /// <returns>
    /// 
    /// </returns>
    public void setStandardXmlValue(XmlNode node,
        string nodeName,
        string attributeName,
        string newValue);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="node"></param>
    /// <param name="keyName"></param>
    /// <param name="newValue"></param>
    /// <returns>
    /// 
    /// </returns>
    public void setNonStandardXmlValue(XmlNode node,
        string keyName,
        string newValue);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="configurationDocument"></param>
    /// <param name="route"></param>
    /// <param name="profiles"></param>
    /// <returns>
    /// 
    /// </returns>
    public void setRoutesFilterProfileElementsAndAttributesValues(string type,
        XmlDocument configurationDocument,
        XmlNode route,
        List<string> profiles);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="stringToFix"></param>
    /// <returns>
    /// 
    /// </returns>
    public string capitalizeFirstLetterOfString(string stringToFix);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="webApplication"></param>
    /// <param name="attributeName"></param>
    /// <param name="newValue"></param>
    /// <returns>
    /// 
    /// </returns>
    public void setApplicationIisSetting(Application webApplication,
        string attributeName,
        string newValue);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="config"></param>
    /// <param name="section"></param>
    /// <param name="collection"></param>
    /// <param name="attributeName"></param>
    /// <param name="newValue"></param>
    /// <returns>
    /// 
    /// </returns>
    public void setApplicationIisSetting(Configuration config,
        string section,
        string collection,
        string attributeName,
        string newValue);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="webApplication"></param>
    /// <param name="newValue"></param>
    /// <returns>
    /// 
    /// </returns>
    public void setApplicationAppPoolNameIisSetting(Microsoft.Web.Administration.Application webApplication,
        string newValue);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="config"></param>
    /// <param name="section"></param>
    /// <param name="attributeName"></param>
    /// <param name="newValue"></param>
    /// <returns>
    /// 
    /// </returns>
    public void setApplicationIisSetting(Configuration config,
        string section,
        string attributeName,
        string newValue);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="appPool"></param>
    /// <param name="section"></param>
    /// <param name="setting"></param>
    /// <param name="newValue"></param>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns>
    /// 
    /// </returns>
    public void setApplicationPoolIisSetting(Microsoft.Web.Administration.ApplicationPool appPool,
        string section,
        string setting,
        string newValue,
        string username = "",
        string password = "");
    /// <summary>
    /// 
    /// </summary>
    /// <param name="optionsSelected"></param>
    /// <param name="siteName"></param>
    /// <param name="applicationPath"></param>
    /// <param name="applicationName"></param>
    /// <param name="applicationType"></param>
    /// <returns>
    /// 
    /// </returns>
    public void processOptimizeForWindowsAuthSelection(List<string> optionsSelected,
        string siteName,
        string applicationPath,
        string applicationName,
        string applicationType);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="vdir"></param>
    /// <returns>
    /// 
    /// </returns>
    public string findWebApplicationType(VirtualDirectory vdir);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="vdir"></param>
    /// <returns>
    /// 
    /// </returns>
    public string findWebApplicationVersion(string type,
        VirtualDirectory vdir);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="vdir"></param>
    /// <returns>
    /// 
    /// </returns>
    public string getWebApplicationBitness(string type,
        VirtualDirectory vdir);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="config"></param>
    /// <param name="systemweb"></param>
    /// <param name="webApplication"></param>
    /// <param name="iisConfiguration"></param>
    /// <returns>
    /// 
    /// </returns>
    public void loadApplicationSettings(Configuration config,
        XmlNode systemweb,
        Application webApplication,
        IisConfiguration iisConfiguration);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="iisConfiguration"></param>
    /// <param name="appPool"></param>
    /// <returns>
    /// 
    /// </returns>
    public void loadApplicationPoolSettings(ApplicationPool appPool,
        IisConfiguration iisConfiguration);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ds"></param>
    /// <param name="node"></param>
    /// <param name="sect"></param>
    /// <param name="xmlDocument"></param>
    /// <param name="wads"></param>
    /// <returns>
    /// 
    /// </returns>
    public void ParseKeys(webApplicationWebConfigConfiguration ds,
        XmlNode node,
        string sect,
        XmlDocument xmlDocument = null,
        WebApplicationDataStructures wads = null);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="translator"></param>
    /// <param name="ds"></param>
    /// <returns>
    /// 
    /// </returns>
    public void PrebuildKnownKeys(string[,] translator,
        webApplicationWebConfigConfiguration ds);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ds"></param>
    /// <param name="sect"></param>
    /// <param name="node"></param>
    /// <param name="xmlDoc"></param>
    /// <returns>
    /// 
    /// </returns>
    public void SaveKnownKeys(webApplicationWebConfigConfiguration ds,
        string sect,
        XmlNode node, 
        XmlDocument xmlDoc);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="core"></param>
    /// <param name="systemweb"></param>
    /// <returns>
    /// 
    /// </returns>
    public void SaveIisConfiguration(webApplicationWebConfigConfiguration core,
        XmlNode systemweb);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="xmlString"></param>
    /// <returns>
    /// 
    /// </returns>
    public bool IsValidXml(string xmlString);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ds"></param>
    /// <param name="manager"></param>
    /// <param name="siteName"></param>
    /// <param name="applicationPath"></param>
    /// <param name="applicationName"></param>
    /// <param name="systemweb"></param>
    /// <param name="config"></param>
    /// <returns>
    /// 
    /// </returns>
    public void LoadIisConfiguration(webApplicationWebConfigConfiguration ds,
        ServerManager manager,
        string siteName,
        string applicationPath,
        string applicationName,
        XmlNode systemweb,
        Configuration config);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="configurationDocument"></param>
    /// <param name="RequiredKeywords"></param>
    /// <param name="core"></param>
    /// <returns>
    /// 
    /// </returns>
    public void SaveRequireKeywords(XmlDocument configurationDocument,
        XmlNode RequiredKeywords,
        webApplicationWebConfigConfiguration core);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="root"></param>
    /// <param name="xmlDoc"></param>
    /// <param name="ds"></param>
    /// <returns>
    /// 
    /// </returns>
    public void ParseAdfs(XmlNode root,
        XmlDocument xmlDoc,
        webApplicationWebConfigConfiguration ds);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="section"></param>
    /// <param name="node"></param>
    /// <param name="webConfigConfiguration"></param>
    /// <param name="configDoc"></param>
    /// <returns>
    /// 
    /// </returns>
    public void SaveArrayItems(string section,
        XmlNode node,
        webApplicationWebConfigConfiguration webConfigConfiguration,
        XmlDocument configDoc);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="translatortoreturn"></param>
    /// <param name="type"></param>
    /// <param name="core"></param>
    /// <returns>
    /// 
    /// </returns>
    public void createWebApplicationTranslatorToReturn(NETCoreToNetFrameworkTranslator translatortoreturn,
        string type,
        webApplicationWebConfigConfiguration core);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="translator"></param>
    /// <param name="type"></param>
    /// <param name="webconfigconfig"></param>
    /// <returns>
    /// 
    /// </returns>
    public void ParseWebApplicationTranslator(NETCoreToNetFrameworkTranslator translator,
        string type,
        webApplicationWebConfigConfiguration webconfigconfig);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ds"></param>
    /// <param name="node"></param>
    /// <param name="wads"></param>
    /// <returns>
    /// 
    /// </returns>
    public void ParseCustomValidation(webApplicationWebConfigConfiguration ds,
        XmlNode node,
        WebApplicationDataStructures wads);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ds"></param>
    /// <param name="node"></param>
    /// <returns>
    /// 
    /// </returns>
    public void ParseNavigationPanel(webApplicationWebConfigConfiguration ds,
        XmlNode node);
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="ds"></param>
    /// <param name="translator"></param>
    /// <returns>
    /// 
    /// </returns>
    //public void ParseTranslator(webApplicationWebConfigConfiguration ds,
    //    NETCoreToNetFrameworkTranslator translator);
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="translatortoreturn"></param>
    /// <param name="core"></param>
    /// <returns>
    /// 
    /// </returns>
    public void createWebApplicationTranslatorToReturnV2(NETCoreToNetFrameworkTranslator translatortoreturn,
        webApplicationWebConfigConfiguration core);
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="config"></param>
    /// <param name="webApplicationDataStructures"></param>
    /// <param name="xmlDoc"></param>
    /// <param name="webconfigconfig"></param>
    /// <param name="webApplicationType"></param>
    /// <param name="translator"></param>
    /// <param name="appSettings"></param>
    /// <returns>
    /// 
    /// </returns>
    public void CreateOptimizeWindowsAuthenticationForArray(Configuration config,
        WebApplicationDataStructures webApplicationDataStructures,
        XmlDocument xmlDoc,
        webApplicationWebConfigConfiguration webconfigconfig,
        string webApplicationType,
        NETCoreToNetFrameworkTranslator translator,
        XmlNode appSettings);
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="webApplicationDataStructures"></param>
    /// <param name="webconfigconfig"></param>
    /// <param name="root"></param>
    /// <param name="xmlDoc"></param>
    /// <param name="webApplicationType"></param>
    /// <param name="version"></param>
    /// <returns>
    /// 
    /// </returns>
    public void ParseWebApplicationSectionsTranslator(WebApplicationDataStructures webApplicationDataStructures,
        webApplicationWebConfigConfiguration webconfigconfig,
        XmlNode root,
        XmlDocument xmlDoc,
        string webApplicationType,
        string version);
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="webconfigconfig"></param>
    /// <param name="webApplicationType"></param>
    /// <param name="webApplicationVersion"></param>
    /// <param name="applicationName"></param>
    /// <param name="siteName"></param>
    /// <param name="physicalPath"></param>
    /// <param name="applicationPath"></param>
    /// <param name="bitness"></param>
    /// <returns>
    /// 
    /// </returns>
    public void ParseCoreConfigurationData(webApplicationWebConfigConfiguration webconfigconfig,
        string webApplicationType,
        string webApplicationVersion,
        string applicationName,
        string siteName,
        string physicalPath,
        string applicationPath,
        string bitness);
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="webconfigconfig"></param>
    /// <param name="filePath"></param>
    /// <returns>
    /// 
    /// </returns>
    public void ParseSessionAdministration(webApplicationWebConfigConfiguration webconfigconfig,
        string filePath);
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="webconfigconfig"></param>
    /// <param name="filePath"></param>
    /// <returns>
    /// 
    /// </returns>
    public void SaveSessionAdministration(webApplicationWebConfigConfiguration webconfigconfig,
        string filePath);
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="webconfigconfig"></param>
    /// <param name="type"></param>
    /// <param name="version"></param>
    /// <param name="wads"></param>
    /// <returns>
    /// 
    /// </returns>
    public void getElementsToHide(webApplicationWebConfigConfiguration webconfigconfig,
        string type,
        string version,
        WebApplicationDataStructures wads);
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="webconfigconfig"></param>
    /// <param name="systemwebserver"></param>
    /// <returns>
    /// 
    /// </returns>
    public void getHealthcareWebViewerEnabled(webApplicationWebConfigConfiguration webconfigconfig,
        XmlNode systemwebserver);
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="webconfigconfig"></param>
    /// <param name="systemwebserver"></param>
    /// <param name="value"></param>
    /// <param name="xmlDoc"></param>
    /// <returns>
    /// 
    /// </returns>
    public void setHealthcareWebViewerEnabled(webApplicationWebConfigConfiguration webconfigconfig,
        XmlNode systemwebserver,
        bool value,
        XmlDocument xmlDoc);
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="ComaconHelperProxy"></param>
    /// <param name="webApplicationType"></param>
    /// <param name="webApplicationVersion"></param>
    /// <param name="applicationName"></param>
    /// <param name="applicationPath"></param>
    /// <param name="root"></param>
    /// <param name="webconfigconfig"></param>
    /// <param name="config"></param>
    /// <param name="xmlDoc"></param>
    /// <param name="webApplicationDataStructures"></param>
    /// <returns>
    /// 
    /// </returns>
    public void processTranslator(ComaconHelperProxy ComaconHelperProxy,
        string webApplicationType,
        string webApplicationVersion,
        string applicationName,
        string applicationPath,
        XmlNode root,
        webApplicationWebConfigConfiguration webconfigconfig,
        Configuration config,
        XmlDocument xmlDoc,
        WebApplicationDataStructures webApplicationDataStructures);
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="ComaconHelperProxy"></param>
    /// <param name="webApplicationType"></param>
    /// <param name="webApplicationVersion"></param>
    /// <param name="applicationName"></param>
    /// <param name="applicationPath"></param>
    /// <param name="root"></param>
    /// <param name="webconfigconfig"></param>
    /// <param name="config"></param>
    /// <param name="xmlDoc"></param>
    /// <param name="webApplicationDataStructures"></param>
    /// <param name="siteName"></param>
    /// <param name="physicalPath"></param>
    /// <param name="bitness"></param>
    /// <param name="appSettings"></param>
    /// <param name="systemweb"></param>
    /// <param name="manager"></param>
    /// <returns>
    /// 
    /// </returns>
    //public void processWebApplication(ComaconHelperProxy ComaconHelperProxy,
    //    string webApplicationType,
    //    string webApplicationVersion,
    //    string applicationName,
    //    string applicationPath,
    //    XmlNode root,
    //    webApplicationWebConfigConfiguration webconfigconfig,
    //    Configuration config,
    //    XmlDocument xmlDoc,
    //    WebApplicationDataStructures webApplicationDataStructures,
    //    string siteName,
    //    string physicalPath,
    //    string bitness,
    //    XmlNode appSettings,
    //    XmlNode systemweb,
    //    ServerManager manager);
    /// <summary>
    /// 
    /// </summary>
    /// 
    /// <param name="physicalPath"></param>
    /// <param version="version"></param>
    /// <returns>
    /// 
    /// </returns>
    public void CheckHylandDllFiles(string physicalPath, string version);
}

internal class DefaultGenericHelperMethods : GenericHelperMethods
{
    /********************************************************
    *                 Get Helper Methods
    ********************************************************/
    public string getStandardXmlValue(XmlNode node, string nodeName, string attributeName, string defaultValue)
    {
        Log.Logger.Information("Getting standard XML value for {0} in the {1} node. The default value being passed is {2}.", attributeName, nodeName, defaultValue);
        try
        {
            return node.SelectSingleNode(nodeName).Attributes[attributeName].Value;
        }
        catch (Exception e)
        {
            Log.Logger.Warning("Unable to find the {0} attribute in the {1} node.The default value {2} is being returned.", attributeName, nodeName, defaultValue);
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            return defaultValue;
        }
    }

    public string getNonStandardXmlValue(XmlNode node, string keyName, string defaultValue)
    {
        Log.Logger.Information("Getting non-standard XML value for {0}. The default value being passed is {1}. The node is {2}.", keyName, defaultValue, node.OuterXml);
        try
        {
            return node.SelectSingleNode("add[@key='" + keyName + "']").Attributes["value"].Value;
        }
        catch (Exception e)
        {
            Log.Logger.Warning("Unable to find the non-standard XML value for {0} for the node {1}. The default value {2} is being returned.", keyName, node.OuterXml, defaultValue);
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            return defaultValue;
        }
    }

    public string getNonStandardXmlValueInnerText(XmlNode node, string elementName, string keyName, string defaultValue)
    {
        Log.Logger.Information("Getting non-standard XML InnerText value for {0} in the {1} element. The default value being passed is {2}.", keyName, elementName, defaultValue);
        try
        {
            return node.SelectSingleNode(elementName).SelectSingleNode(keyName).InnerText;
        }
        catch (Exception e)
        {
            Log.Logger.Warning("Unable to find the non-standard XML InnerText value for {0} in the {1} element. The default value {2} is being returned.", keyName, elementName, defaultValue);
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            return defaultValue;
        }
        
    }


    /********************************************************
    *                 Set Helper Methods
    ********************************************************/
    public void setStandardXmlValue(XmlNode node, string nodeName, string attributeName, string newValue)
    {
        try
        {
            XmlNode testNode = node.SelectSingleNode(nodeName).Attributes[attributeName];
            if (testNode != null)
            {
                if (testNode.Value != newValue)
                {
                    node.SelectSingleNode(nodeName).Attributes[attributeName].Value = newValue;
                }
            }
            else
            {
                // ! TODO - Need to figure out how to set the code here exactly.
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error("Unable to set the standard XML new value of {2} for {0} in the {1} node.", attributeName, nodeName, newValue);
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void setNonStandardXmlValue(XmlNode node, string keyName, string newValue)
    {
        try
        {
            XmlNode testNode = node.SelectSingleNode("add[@key='" + keyName + "']") ?? null;
            if (testNode != null)
            {
                if (testNode.Attributes["value"].Value != newValue)
                {
                    node.SelectSingleNode("add[@key='" + keyName + "']").Attributes["value"].Value = newValue;
                }
            }
            else
            {
                // ! TODO - Need to actually code this now.
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error("Unable to set the non-standard XML new value of {2} for {0} in the {1} node.", keyName, node.OuterXml, newValue);
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void setRoutesFilterProfileElementsAndAttributesValues(string type, XmlDocument configurationDocument, XmlNode route, List<string> profiles)
    {
        try
        {
            string profilesValue = "";
            foreach (string profile in profiles)
            {
                profilesValue += "," + profile;
            }
            XmlElement diagnosticsEventsRouteFilterIncludeElement = configurationDocument.CreateElement("add");
            XmlAttribute diagnosticsEventsRouteFilterIncludeKey = configurationDocument.CreateAttribute("key");
            XmlAttribute diagnosticsEventsRouteFilterIncludeValue = configurationDocument.CreateAttribute("value");
            diagnosticsEventsRouteFilterIncludeKey.Value = "include-profiles";

            XmlElement diagnosticsEventsRouteFilterExcludeElement = configurationDocument.CreateElement("add");
            XmlAttribute diagnosticsEventsRouteFilterExcludeKey = configurationDocument.CreateAttribute("key");
            XmlAttribute diagnosticsEventsRouteFilterExcludeValue = configurationDocument.CreateAttribute("value");
            diagnosticsEventsRouteFilterExcludeKey.Value = "exclude-profiles";
            switch (type)
            {
                case "Neither":
                    diagnosticsEventsRouteFilterIncludeElement.Attributes.Append(diagnosticsEventsRouteFilterIncludeKey);

                    diagnosticsEventsRouteFilterExcludeElement.Attributes.Append(diagnosticsEventsRouteFilterExcludeKey);

                    route.AppendChild(diagnosticsEventsRouteFilterIncludeElement);
                    route.AppendChild(diagnosticsEventsRouteFilterExcludeElement);
                    break;
                case "Include":
                    diagnosticsEventsRouteFilterIncludeValue.Value = profilesValue;
                    diagnosticsEventsRouteFilterIncludeElement.Attributes.Append(diagnosticsEventsRouteFilterIncludeKey);
                    diagnosticsEventsRouteFilterIncludeElement.Attributes.Append(diagnosticsEventsRouteFilterIncludeValue);

                    diagnosticsEventsRouteFilterExcludeElement.Attributes.Append(diagnosticsEventsRouteFilterExcludeKey);

                    route.AppendChild(diagnosticsEventsRouteFilterIncludeElement);
                    route.AppendChild(diagnosticsEventsRouteFilterExcludeElement);
                    break;
                case "Exclude":
                    diagnosticsEventsRouteFilterIncludeElement.Attributes.Append(diagnosticsEventsRouteFilterIncludeKey);

                    diagnosticsEventsRouteFilterExcludeValue.Value = profilesValue;
                    diagnosticsEventsRouteFilterExcludeElement.Attributes.Append(diagnosticsEventsRouteFilterExcludeKey);
                    diagnosticsEventsRouteFilterExcludeElement.Attributes.Append(diagnosticsEventsRouteFilterExcludeValue);

                    route.AppendChild(diagnosticsEventsRouteFilterIncludeElement);
                    route.AppendChild(diagnosticsEventsRouteFilterExcludeElement);
                    break;
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error("Unable to set the routes filter profile elements and attributes values for the {0} type.", type);
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public string capitalizeFirstLetterOfString(string stringToFix)
    {
        try
        {
            char[] letters = stringToFix.ToCharArray();
            letters[0] = char.ToUpper(letters[0]);
            return new string(letters);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
            return stringToFix;
        }
    }

    public void setApplicationIisSetting(Microsoft.Web.Administration.Application webApplication, string attributeName, string newValue)
    {
        try
        {
            if (webApplication.Attributes[attributeName].Value != newValue)
            {
                webApplication.Attributes[attributeName].Value = newValue;
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void setApplicationIisSetting(Microsoft.Web.Administration.Configuration config, string section, string collection, string attributeName, string newValue)
    {
        try
        {
            if (config.GetSection(section).GetCollection(collection).FirstOrDefault().Attributes[attributeName].Value != newValue)
            {
                config.GetSection(section).GetCollection(collection).FirstOrDefault().Attributes[attributeName].Value = newValue;
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void setApplicationAppPoolNameIisSetting(Microsoft.Web.Administration.Application webApplication, string newValue)
    {
        try
        {
            if (webApplication.ApplicationPoolName != newValue)
            {
                webApplication.ApplicationPoolName = newValue;
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void setApplicationIisSetting(Configuration config, string section, string attributeName, string newValue)
    {
        try
        {
            if (config.GetSection(section).GetAttributeValue(attributeName) != newValue)
            {
                config.GetSection(section).SetAttributeValue(attributeName, newValue);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void setApplicationPoolIisSetting(ApplicationPool appPool, string section, string setting, string newValue, string username = "", string password = "")
    {
        try
        {
            switch (section)
            {
                case "General":
                    switch (setting)
                    {
                        case ".NET Clr Version":
                            appPool.ManagedRuntimeVersion = newValue;
                            break;
                        case "Enabled 32-Bit Applications":
                            appPool.Enable32BitAppOnWin64 = newValue == "true";
                            break;
                        case "Managed Pipeline Mode":
                            switch (newValue)
                            {
                                case "Integrated":
                                    appPool.ManagedPipelineMode = Microsoft.Web.Administration.ManagedPipelineMode.Integrated;
                                    break;
                                case "Classic":
                                    appPool.ManagedPipelineMode = Microsoft.Web.Administration.ManagedPipelineMode.Classic;
                                    break;
                            }
                            break;
                        case "Queue Length":
                            appPool.QueueLength = long.Parse(newValue);
                            break;
                        case "Start Mode":
                            switch (newValue)
                            {
                                case "OnDemand":
                                    appPool.StartMode = Microsoft.Web.Administration.StartMode.OnDemand;
                                    break;
                                case "AlwaysRunning":
                                    appPool.StartMode = Microsoft.Web.Administration.StartMode.AlwaysRunning;
                                    break;
                            }
                            break;
                    }
                    break;
                case "CPU":
                    switch (setting)
                    {
                        case "Limit Interval":
                            appPool.Cpu.ResetInterval = TimeSpan.FromMinutes(double.Parse(newValue));
                            break;
                    }
                    break;
                case "Process Model":
                    switch (setting)
                    {
                        case "Identity Type":
                            switch (newValue)
                            {
                                case "ApplicationPoolIdentity":
                                    appPool.ProcessModel.IdentityType = ProcessModelIdentityType.ApplicationPoolIdentity;
                                    break;
                                case "LocalService":
                                    appPool.ProcessModel.IdentityType = Microsoft.Web.Administration.ProcessModelIdentityType.LocalService;
                                    break;
                                case "LocalSystem":
                                    appPool.ProcessModel.IdentityType = Microsoft.Web.Administration.ProcessModelIdentityType.LocalSystem;
                                    break;
                                case "NetworkService":
                                    appPool.ProcessModel.IdentityType = Microsoft.Web.Administration.ProcessModelIdentityType.NetworkService;
                                    appPool.ProcessModel.UserName = username;
                                    appPool.ProcessModel.Password = password;
                                    break;
                                case "SpecificUser":
                                    appPool.ProcessModel.IdentityType = Microsoft.Web.Administration.ProcessModelIdentityType.SpecificUser;
                                    appPool.ProcessModel.UserName = username;
                                    appPool.ProcessModel.Password = password;
                                    break;
                            }
                            break;
                        case "Idle Timeout":
                            appPool.ProcessModel.IdleTimeout = TimeSpan.FromMinutes(double.Parse(newValue));
                            break;
                        case "Ping Enabled":
                            appPool.ProcessModel.PingingEnabled = newValue == "true";
                            break;
                    }
                    break;
                case "Rapid-Failover Protection":
                    switch (setting)
                    {
                        case "Enabled":
                            appPool.Failure.RapidFailProtection = newValue == "true";
                            break;
                    }
                    break;
                case "Recycling":
                    switch (setting)
                    {
                        case "Regular Time Interval":
                            appPool.Recycling.PeriodicRestart.Time = TimeSpan.FromMinutes(double.Parse(newValue));
                            break;
                    }
                    break;
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public string findWebApplicationType(VirtualDirectory vdir)
    {
        try
        {
            return File.Exists(vdir.PhysicalPath + @"\bin\Hyland.Applications.Server.dll.config") ? "Application Server" :
                File.Exists(vdir.PhysicalPath + @"\bin\Hyland.Applications.AgendaPubAccess.Client.dll.config") ? "Agenda Online" :
                File.Exists(vdir.PhysicalPath + @"\bin\Hyland.Applications.PlanReview.Client.dll.config") ? "Electronic Plan Review" :
                File.Exists(vdir.PhysicalPath + @"\bin\Hyland.Applications.ApplicationServerGateway.dll.config") ? "Gateway Caching Server" :
                File.Exists(vdir.PhysicalPath + @"\bin\Hyland.Applications.Web.HealthcareFormManager.dll.config") ? "Healthcare Form Manager" :
                File.Exists(vdir.PhysicalPath + @"\bin\Hyland.Applications.Web.PatientWindow.dll.config") ? "Patient Window" :
                File.Exists(vdir.PhysicalPath + @"\bin\Hyland.Web.PublicAccess.dll.config") ? "Public Access - Legacy" :
                File.Exists(vdir.PhysicalPath + @"\bin\Hyland.Web.PublicAccess.Server.dll.config") ? "Public Access - Next Gen" :
                File.Exists(vdir.PhysicalPath + @"\bin\Hyland.Applications.Web.DashboardViewer.dll.config") ? "Reporting Viewer" :
                File.Exists(vdir.PhysicalPath + @"\bin\Hyland.Applications.Web.Client.dll.config") ? "Web Server" : "None";
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
            return "";
        }
        
    }

    public string findWebApplicationVersion(string type, VirtualDirectory vdir)
    {
        try
        {
            string testPath = vdir.PhysicalPath + @"\bin\Hyland.Applications.Server.dll";

            XmlDocument versionXmlDoc = new XmlDocument();
            switch (type)
            {
                case "Application Server":
                    FileVersionInfo applicationServerVersion = FileVersionInfo.GetVersionInfo(vdir.PhysicalPath + @"\bin\Hyland.Applications.Server.dll");
                    return applicationServerVersion.FileVersion;
                case "Agenda Online":
                    FileVersionInfo agendaOnlineVersion = FileVersionInfo.GetVersionInfo(vdir.PhysicalPath + @"\bin\Hyland.Applications.AgendaPubAccess.Client.dll");
                    return agendaOnlineVersion.FileVersion;
                case "Electronic Plan Review":
                    FileVersionInfo electronicPlanReviewVersion = FileVersionInfo.GetVersionInfo(vdir.PhysicalPath + @"\bin\Hyland.Applications.PlanReview.Client.dll");
                    return electronicPlanReviewVersion.FileVersion;
                case "Gateway Caching Server":
                    FileVersionInfo gatewayCachingServerVersion = FileVersionInfo.GetVersionInfo(vdir.PhysicalPath + @"\bin\Hyland.Applications.ApplicationServerGateway.dll");
                    return gatewayCachingServerVersion.FileVersion;
                case "Healthcare Form Manager":
                    versionXmlDoc.Load(vdir.PhysicalPath + @"\version.xml");
                    return versionXmlDoc.DocumentElement.SelectSingleNode("add[@key='version_num']").Attributes["value"].Value.Replace(",", ".");
                case "Patient Window":
                    versionXmlDoc.Load(vdir.PhysicalPath + @"\version.xml");
                    return versionXmlDoc.DocumentElement.SelectSingleNode("add[@key='version_num']").Attributes["value"].Value.Replace(",", ".");
                case "Public Access - Legacy":
                    FileVersionInfo publicAccessLegacyVersion = FileVersionInfo.GetVersionInfo(vdir.PhysicalPath + @"\bin\Hyland.Web.PublicAccess.dll");
                    return publicAccessLegacyVersion.FileVersion;
                case "Public Access - Next Gen":
                    FileVersionInfo publicAccessNextGenVersion = FileVersionInfo.GetVersionInfo(vdir.PhysicalPath + @"\bin\Hyland.Web.PublicAccess.Server.dll");
                    return publicAccessNextGenVersion.FileVersion;
                case "Reporting Viewer":
                    versionXmlDoc.Load(vdir.PhysicalPath + @"\version.xml");
                    return versionXmlDoc.DocumentElement.SelectSingleNode("add[@key='version_num']").Attributes["value"].Value.Replace(",", ".");
                case "Web Server":
                    versionXmlDoc.Load(vdir.PhysicalPath + @"\version.xml");
                    return versionXmlDoc.DocumentElement.SelectSingleNode("add[@key='version_num']").Attributes["value"].Value.Replace(",", ".");
                default:
                    return "";
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
            return "";
        }
    }

    public string getWebApplicationBitness(string type, VirtualDirectory vdir)
    {
        try
        {
            switch (type)
            {
                case "Application Server":
                    return IsDll64Bit(vdir.PhysicalPath + @"\bin\Hyland.Applications.Server.dll").ToString();
                case "Agenda Online":
                    return IsDll64Bit(vdir.PhysicalPath + @"\bin\Hyland.Applications.AgendaPubAccess.Client.dll").ToString();
                case "Electronic Plan Review":
                    return IsDll64Bit(vdir.PhysicalPath + @"\bin\Hyland.Applications.PlanReview.Client.dll").ToString();
                case "Gateway Caching Server":
                    return IsDll64Bit(vdir.PhysicalPath + @"\bin\Hyland.Applications.ApplicationServerGateway.dll").ToString();
                case "Healthcare Form Manager":
                    return IsDll64Bit(vdir.PhysicalPath + @"\bin\Hyland.Applications.Web.HealthcareFormManager.dll").ToString();
                case "Patient Window":
                    return IsDll64Bit(vdir.PhysicalPath + @"\bin\Hyland.Applications.Web.PatientWindow.dll").ToString();
                case "Public Access - Legacy":
                    return IsDll64Bit(vdir.PhysicalPath + @"\bin\Hyland.Web.PublicAccess.dll").ToString();
                case "Public Access - Next Gen":
                    return IsDll64Bit(vdir.PhysicalPath + @"\bin\Hyland.Web.PublicAccess.Server.dll").ToString();
                case "Reporting Viewer":
                    return IsDll64Bit(vdir.PhysicalPath + @"\bin\Hyland.Applications.Web.DashboardViewer.dll").ToString();
                case "Web Server":
                    return IsDll64Bit(vdir.PhysicalPath + @"\bin\Hyland.Applications.Web.Client.dll").ToString();
                default:
                    return "";
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
            return "";
        }
    }

    private static bool IsDll64Bit(string dllPath)
    {
        PortableExecutableKinds peKind;
        ImageFileMachine machine;
        try
        {
            Module module = Assembly.LoadFile(dllPath).ManifestModule;
            module.GetPEKind(out peKind, out machine);
            return (machine == ImageFileMachine.AMD64 || machine == ImageFileMachine.IA64);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
            Log.Logger.Error("Can't find the .dll file at {0}.", dllPath);
        }
        return false;
    }

    public void loadApplicationSettings(Configuration config, XmlNode systemweb, Application webApplication, IisConfiguration iisConfiguration)
    {
        try
        {
            IisApplication application = new IisApplication();
            application.defaultDocument = config.GetSection("system.webServer/defaultDocument").GetCollection("files").FirstOrDefault().Attributes["value"].Value.ToString();
            application.anonymousAuthentication = config.GetSection(@"system.webServer/security/authentication/anonymousAuthentication").GetAttributeValue("enabled").ToString();
            application.aspNetImpersonation = getStandardXmlValue(systemweb, "identity", "impersonate", ""); //systemweb.SelectSingleNode("identity").Attributes["impersonate"].Value;
            application.windowsAuthentication = config.GetSection(@"system.webServer/security/authentication/windowsAuthentication").GetAttributeValue("enabled").ToString();
            application.useAppPoolCredentials = config.GetSection(@"system.webServer/security/authentication/windowsAuthentication").GetAttributeValue("useAppPoolCredentials").ToString();
            application.applicationPoolName = webApplication.ApplicationPoolName;
            application.preLoadEnabled = webApplication.Attributes["preloadEnabled"].Value.ToString();
            iisConfiguration.application = application;
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    //public void processWebApplication(ComaconHelperProxy ComaconHelperProxy, string webApplicationType, string webApplicationVersion, string applicationName, string applicationPath, XmlNode root, webApplicationWebConfigConfiguration webconfigconfig, Configuration config, XmlDocument xmlDoc, WebApplicationDataStructures webApplicationDataStructures, string siteName, string physicalPath, string bitness, XmlNode appSettings, XmlNode systemweb, ServerManager manager)
    //{


    //    switch (webApplicationType)
    //    {
    //        case "Web Server":
    //            processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion, applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
    //            ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
    //            ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion);
    //            getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion, webApplicationDataStructures);
    //            ParseKeys(webconfigconfig, appSettings, "KeywordDropdownTypeaheadCharacterMinimum");
    //            getHealthcareWebViewerEnabled(webconfigconfig, root.SelectSingleNode("system.webServer"));
    //            break;
    //    }

    //    LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);
    //}

    //public void processWebApplicationV2(ComaconHelperProxy ComaconHelperProxy, webApplicationWebConfigConfiguration webconfigconfig, WebApplicationDataStructures webApplicationDataStructures, TextReader reader, string webApplicationType, string webApplicationVersion, string siteName, string applicationName, string applicationPath, string physicalPath, string bitness)
    //{
    //    //Pre-paring work.
    //    var validXml = reader.ReadToEnd();

    //    XmlDocument xmlDoc = new XmlDocument();
    //    xmlDoc.LoadXml(validXml);

    //    ServerManager manager = new ServerManager();
    //    Configuration config = manager.GetWebConfiguration(siteName + applicationPath + applicationName);

    //    XmlNode root = xmlDoc.DocumentElement;
    //    XmlNode appSettings = root.SelectSingleNode("appSettings");
    //    XmlNode systemweb = root.SelectSingleNode("system.web");

    //    switch (webApplicationType)
    //    {
    //        case "Web Server":
    //            switch (webApplicationVersion)
    //            {
    //                case "211":
    //                    break;
    //                default:
    //                    processTranslator(ComaconHelperProxy, webApplicationType, webApplicationVersion, applicationName, applicationPath, root, webconfigconfig, config, xmlDoc, webApplicationDataStructures);
    //                    ParseCoreConfigurationData(webconfigconfig, webApplicationType, webApplicationVersion, applicationName, siteName, physicalPath, applicationPath, bitness);
    //                    ParseWebApplicationSectionsTranslator(webApplicationDataStructures, webconfigconfig, root, xmlDoc, webApplicationType, webApplicationVersion);
    //                    getElementsToHide(webconfigconfig, webApplicationType, webApplicationVersion, webApplicationDataStructures);
    //                    ParseKeys(webconfigconfig, appSettings, "KeywordDropdownTypeaheadCharacterMinimum");
    //                    getHealthcareWebViewerEnabled(webconfigconfig, root.SelectSingleNode("system.webServer"));
    //                    break;
    //            }
    //            break;
    //    }

    //    LoadIisConfiguration(webconfigconfig, manager, siteName, applicationPath, applicationName, systemweb, config);
    //}

    public void processTranslator(ComaconHelperProxy ComaconHelperProxy, string webApplicationType, string webApplicationVersion, string applicationName, string applicationPath, XmlNode root, webApplicationWebConfigConfiguration webconfigconfig, Configuration config, XmlDocument xmlDoc, WebApplicationDataStructures webApplicationDataStructures)
    {
        try
        {
            //Get the serialized output and store it.
            string serializedObject = ComaconHelperProxy.Get(applicationPath, applicationName, webApplicationType, webApplicationVersion);

            try
            {
                //Deserialize the object.
                var translator = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(serializedObject);
                ParseTranslator(webconfigconfig, translator);
                if (webApplicationType == "Web Server" || webApplicationType == "Application Server" || webApplicationType == "Reporting Viewer")
                {
                    CreateOptimizeWindowsAuthenticationForArray(config, webApplicationDataStructures, xmlDoc, webconfigconfig, webApplicationType, translator, root.SelectSingleNode("appSettings"));
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error("Error: {0}", e.Message);
                Log.Logger.Error("Error: {0}", e.StackTrace);
                Log.Logger.Error("Version: {0}", webApplicationVersion);
                Log.Logger.Error("Type: {0}", webApplicationType);
                Log.Logger.Error("Translator Output: {0}", serializedObject);
                webconfigconfig.AddCriticalError("Error processing the translator results. See the log file for more details.");
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error("Error: {0}", e.Message);
            Log.Logger.Error("Error: {0}", e.StackTrace);
            Log.Logger.Error("Version: {0}", webApplicationVersion);
            Log.Logger.Error("Type: {0}", webApplicationType);
            webconfigconfig.AddCriticalError("Error getting the string to send to COMACON Helper Utility. See the log file for more details.");
        }
        
    }


    /********************************************************
     *                 Parsing Functions
     ********************************************************/
    public void ParseKeys(webApplicationWebConfigConfiguration ds, XmlNode node, string sect, XmlDocument xmlDocument = null, WebApplicationDataStructures wads = null)
    {
        switch (sect)
        {
            case "root":
                ParseSpecificKeys(ds, node, sect);
                break;
            case "system.web":
                ParseSpecificKeys(ds, node, sect);
                break;
            case "system.webServer":
                ParseSpecificKeys(ds, node, sect);
                break;
            case "system.diagnostics":
                ParseSpecificKeys(ds, node, sect);
                break;
            case "system.web.extensions":
                ParseSpecificKeys(ds, node, sect);
                break;
            case "Hyland.Web.DashboardViewer":
                ParseSpecificKeys(ds, node, sect);
                break;
            case "Hyland.Integrations.LOBBroker.LOBBrokerConfigSection":
                ParseHylandIntegrationsLOBBrokerLOBBrokerConfigSection(ds, node, sect, xmlDocument);
                break;
            case "Hyland.Core.Wopi":
                ParseHylandCoreWopi(ds, node, sect, xmlDocument);
                break;
            case "Hyland.PlatterManagement":
                ParseHylandPlatterManagement(ds, node, sect, xmlDocument);
                break;
            case "Hyland.ResponsiveApps":
                ParseHylandResponsiveApps(ds, node, sect, xmlDocument);
                break;
            case "appSettings":
                ParseAppSettingsKeysV2(ds, node, sect, xmlDocument);
                break;
            case "Hyland.Applications.AgendaPubAccess.PublicComment":
                //ParseSpecificKeys(ds, node, sect);
                //ParseHylandApplicationsAgendaPubAccessPublicCommentExtraKeys(ds, node, sect);
                ParseHylandApplicationsAgendaPubAccessPublicComment(ds, node, sect);
                break;
            case "Hyland.Logging":
                ParseHylandLogging(ds, node, wads);
                break;
            case "Hyland.Authentication":
                ParseHylandAuthentication(ds, node, sect);
                break;
            case "Hyland.Services":
                ParseHylandServices(ds, node, sect, xmlDocument);
                break;
            case "Hyland.Services.Client":
                ParseAllElementsAndAttributesV2(ds, node, sect, xmlDocument);
                PostParseHylandServicesClientElement(ds, node, sect, xmlDocument);
                break;
            case "NavigationPanel":
                ParseNavigationPanel(ds, node);
                break;
            case "KeywordDropdownTypeaheadCharacterMinimum":
                ParseKeywordDropdownTypeaheadCharacterMinimum(ds, node);
                break;
            case "ADFS":
                ParseAdfs(node, xmlDocument, ds);
                break;
            case "CustomValidation":
                ParseCustomValidation(ds, node, wads);
                break;
            case "RequiredKeywords":
                ParseRequiredKeywords(node, ds);
                break;
            case "Hyland.Web.HealthcareWebViewer":
                ParseSpecificKeys(ds, node, sect);
                ParseHealthcareWebViewerSourceWhitelist(ds, node);
                break;
            case "Hyland.XMLServices.DocumentConnector":
                ParseSpecificKeys(ds, node, sect);
                break;
            case "Hyland.WorkView.Core":
                ParseSpecificKeys(ds, node, sect);
                break;
            default:
                ParseAllElementsAndAttributesV2(ds, node, sect, xmlDocument);
                break;
        }
    }

    private void ParseKeywordDropdownTypeaheadCharacterMinimum(webApplicationWebConfigConfiguration ds, XmlNode node)
    {
        try
        {
            string kwddtacmValue = node.SelectSingleNode("add[@key='KeywordDropdownTypeaheadCharacterMinimum']").Attributes["value"].Value;
            string[] kwddtacmValueArray = kwddtacmValue.Split(',');
            KeywordDropdownTypeAhead keywordDropdownTypeAhead = new KeywordDropdownTypeAhead();
            //Loop over the array
            foreach (string s in kwddtacmValueArray)
            {
                string[] split = s.Split(':');
                if(split.Length == 2)
                {
                    CharacterMinimum cm = new CharacterMinimum();
                    cm.KeywordID = split[0];
                    cm.CharacterCount = split[1];
                    keywordDropdownTypeAhead.characterMinimums.Add(cm);
                }
                else
                {
                    Log.Logger.Warning("Invalid KeywordDropdownTypeaheadCharacterMinimum value: {0}", s);
                }
            }

            ds.keywordDropdownTypeAhead = keywordDropdownTypeAhead;
        }
        catch (Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            Log.Logger.Warning("Error parsing KeywordDropdownTypeaheadCharacterMinimum");
        }
    }

    private void ParseHylandServices(webApplicationWebConfigConfiguration ds, XmlNode node, string sect, XmlDocument xmlDocument)
    {
        try
        {
            ParseAllElementsAndAttributesV2(ds, node, sect, xmlDocument);

            XmlNode parameters = node.SelectSingleNode("parameters");
            HylandServicesParameters hsp = new HylandServicesParameters();

            if (parameters != null)
            {
                foreach (XmlNode p in parameters.ChildNodes)
                {
                    try
                    {
                        if (p.NodeType != XmlNodeType.Comment)
                        {
                            Parameter param = new Parameter();
                            param.name = p.Attributes["name"].Value;
                            param.value = p.Attributes["value"].Value;
                            hsp.parameters.Add(param);
                        }
                    }
                    catch
                    {
                        Log.Logger.Warning("Error processing the node {0}.", p.OuterXml);
                    }
                }
                ds.hylandServicesParameters = hsp;
            }
        }
        catch (Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            Log.Logger.Warning("Error parsing Hyland.Services");
        }
    }

    private void ParseHylandIntegrationsLOBBrokerLOBBrokerConfigSection(webApplicationWebConfigConfiguration ds, XmlNode root, string sect, XmlDocument xmlDocument)
    {
        try
        {
            XmlNode HylandIntegrationsLOBBrokerLOBBrokerConfigSection = root.SelectSingleNode("Hyland.Integrations.LOBBroker.LOBBrokerConfigSection");

            if (HylandIntegrationsLOBBrokerLOBBrokerConfigSection == null)
            {
                foreach (XmlNode node in root.ChildNodes)
                {
                    if (node.NodeType == XmlNodeType.Comment)
                    {
                        if (IsValidXml(node.Value.Trim()))
                        {
                            XmlReader commentReader = XmlReader.Create(new StringReader(node.Value.Trim()));
                            XmlNode n = xmlDocument.ReadNode(commentReader);
                            if (n.Name == "Hyland.Integrations.LOBBroker.LOBBrokerConfigSection")
                            {
                                ParseAllElementsAndAttributesV2(ds, n, "Hyland.Integrations.LOBBroker.LOBBrokerConfigSection", xmlDocument);
                            }
                        }
                    }
                }
            }
            else
            {
                ParseAllElementsAndAttributesV2(ds, HylandIntegrationsLOBBrokerLOBBrokerConfigSection, "Hyland.Integrations.LOBBroker.LOBBrokerConfigSection", xmlDocument);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            Log.Logger.Warning("Error parsing Hyland.Integrations.LOBBroker.LOBBrokerConfigSection");
        }
    }

    private void ParseHylandCoreWopi(webApplicationWebConfigConfiguration ds, XmlNode root, string sect, XmlDocument xmlDocument)
    {
        try
        {
            XmlNode HylandCoreWopi = root.SelectSingleNode("Hyland.Core.Wopi");

            if (HylandCoreWopi == null)
            {
                foreach (XmlNode node in root.ChildNodes)
                {
                    if (node.NodeType == XmlNodeType.Comment)
                    {
                        if (IsValidXml(node.Value.Trim()))
                        {
                            XmlReader commentReader = XmlReader.Create(new StringReader(node.Value.Trim()));
                            XmlNode n = xmlDocument.ReadNode(commentReader);
                            if (n.Name == "Hyland.Core.Wopi")
                            {

                                ParseSpecificKeys(ds, n, "Hyland.Core.Wopi");
                            }
                        }
                    }
                }
            }
            else
            {
                ParseSpecificKeys(ds, HylandCoreWopi, "Hyland.Core.Wopi");
            }
        }
        catch (Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            Log.Logger.Warning("Error parsing Hyland.Core.Wopi");
        }
    }

    private void ParseHylandResponsiveApps(webApplicationWebConfigConfiguration ds, XmlNode node, string sect, XmlDocument xmlDocument)
    {
        try
        {
            ParseSpecificKeys(ds, node, sect);

            XmlNode apps2 = node.SelectSingleNode("Apps");
            HylandResponsiveApps hra = new HylandResponsiveApps();

            foreach (XmlNode app in apps2.ChildNodes)
            {
                if (app.NodeType != XmlNodeType.Comment)
                {
                    ResponsiveApp ra = new ResponsiveApp();
                    ra.Name = app.Attributes["name"].Value;
                    ra.IconURL = app.Attributes["icon"].Value;
                    ra.URL = app.Attributes["url"].Value;
                    hra.responsiveApps.Add(ra);
                }
            }
            ds.hylandResponsiveApps = hra;
        }
        catch (Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            Log.Logger.Warning("Error parsing Hyland.ResponsiveApps");
        }
    }

    private void ParseHylandPlatterManagement(webApplicationWebConfigConfiguration ds, XmlNode node, string sect, XmlDocument xmlDocument)
    {
        try
        {
            foreach (XmlNode childNode in node.ChildNodes)
            {
                if (childNode.NodeType == XmlNodeType.Comment)
                {
                    if (IsValidXml(childNode.Value.Trim()))
                    {
                        XmlReader commentReader = XmlReader.Create(new StringReader(childNode.Value.Trim()));
                        XmlNode n = xmlDocument.ReadNode(commentReader);

                        foreach (XmlAttribute attr in n.Attributes)
                        {
                            Key k = FindKey(ds.knownKeys, sect, n.Name, attr.Name);

                            if (k != null)
                            {
                                k.Value = n.Attributes[k.AttributeName].Value;
                            }
                            else
                            {
                                AddUnknownKeyElement(sect, n, "", ds);
                            }
                        }
                    }
                }
                else
                {
                    foreach (XmlAttribute attr in childNode.Attributes)
                    {
                        Key k = FindKey(ds.knownKeys, sect, childNode.Name, attr.Name);

                        if (k != null)
                        {
                            k.Value = childNode.Attributes[k.AttributeName].Value;
                        }
                        else
                        {
                            AddUnknownKeyElement(sect, childNode, "", ds);
                        }
                    }
                }
            }

            XmlNode diskGroupAliases = node.SelectSingleNode("DiskgroupAlias");
            HylandPlatterManagement hpm = new HylandPlatterManagement();
            try
            {
                foreach (XmlNode dga in diskGroupAliases.ChildNodes)
                {
                    if (dga.NodeType != XmlNodeType.Comment)
                    {
                        DiskGroupAlias a = new DiskGroupAlias();
                        a.oldname = dga.Attributes["oldname"].Value;
                        a.newname = dga.Attributes["newname"].Value;
                        a.type = dga.Attributes["type"].Value;
                        hpm.diskGroupAliases.Add(a);
                    }
                }
            }
            catch(Exception e)
            {
                Log.Logger.Warning(e.Message);
                Log.Logger.Warning(e.StackTrace);
                Log.Logger.Warning("Error parsing Hyland.PlatterManagement DiskgroupAlias");
            }
            
            ds.hylandPlatterManagement = hpm;
        }
        catch (Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            Log.Logger.Warning("Error parsing Hyland.PlatterManagement");
        }
    }

    private void PostParseHylandServicesClientElement(webApplicationWebConfigConfiguration ds, XmlNode parentNode, string section, XmlDocument xmlDoc)
    {
        try
        {
            Key url = FindKey(ds.knownKeys, section, "ApplicationServer", "Url");
            url.Value = url.Value.Substring(0, url.Value.LastIndexOf('/'));
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
            Log.Logger.Warning("Error updating the URL value to remove the Service.rem/Service.asmx value.");
        }
    }

    private void ParseAllElementsAndAttributesV2(webApplicationWebConfigConfiguration ds, XmlNode parentNode, string section, XmlDocument xmlDoc)
    {
        try
        {
            //Parses all chidren nodes of the parent node.
            foreach (XmlNode childNode in parentNode.ChildNodes)
            {
                //Checks to see if the current node is a comment or not.
                if (childNode.NodeType == XmlNodeType.Comment)
                {
                    //Checks if the comment node has valid XML inside of it.
                    if (IsValidXml(childNode.Value.Trim()))
                    {
                        //Since we know that the comment nodes value is valid XML,
                        //need to create a temporary XmlNode to then parse all of the attributes.
                        XmlReader commentReader = XmlReader.Create(new StringReader(childNode.Value.Trim()));
                        XmlNode n = xmlDoc.ReadNode(commentReader);

                        //Now I am going to parse over all of the attributes of the 
                        foreach (XmlAttribute attr in n.Attributes)
                        {
                            Key k = FindKey(ds.knownKeys, section, n.Name, attr.Name);

                            if (k != null)
                            {
                                //Key was found, so we just need to update that keys Value variable.
                                k.Value = n.Attributes[k.AttributeName].Value;
                            }
                            else
                            {
                                //Key was NOT found, so need to add the node to the Unknown Elements List<>.
                                AddUnknownKeyElement(section, n, "", ds);
                            }
                        }
                    }
                }
                else
                {
                    foreach (XmlAttribute attr in childNode.Attributes)
                    {
                        Console.WriteLine();
                        Console.WriteLine(attr.Name);
                        Console.WriteLine();
                        Key k = FindKey(ds.knownKeys, section, childNode.Name, attr.Name);

                        if (k != null)
                        {
                            //Key was found, so we just need to update that keys Value variable.
                            if (k.AttributeName != "ServiceClientType" && childNode.Attributes[k.AttributeName].Value != "")
                            {
                                //Specific to the ServiceClientType attribute and the fact that it has to have a value.
                                //So validating it isn't blank and going from there.
                                k.Value = childNode.Attributes[k.AttributeName].Value;
                            } else if (k.AttributeName == "ServiceClientType" && childNode.Attributes[k.AttributeName].Value != "")
                            {
                                k.Value = childNode.Attributes[k.AttributeName].Value;
                            }
                        }
                        else
                        {
                            //Key was NOT found, so need to add the node to the Unknown Elements List<>.
                            AddUnknownKeyElement(section, childNode, "", ds);
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
            Log.Logger.Warning("Error parsing all elements and attributes in the {0} parent node for the {1} section.", parentNode.Name, section);
        }
    }

    public void ParseNavigationPanel(webApplicationWebConfigConfiguration ds, XmlNode node)
    {
        try
        {
            NavigationPanel npanel = new NavigationPanel();
            npanel.defaultContext = node?.SelectSingleNode("DefaultContextInfo/defaultContext")?.InnerText ?? "";
            npanel.defaultControlBar = node?.SelectSingleNode("DefaultContextInfo/defaultControlBar")?.InnerText ?? "";
            npanel.defaultContextID = node?.SelectSingleNode("DefaultContextInfo/defaultContextID")?.InnerText ?? "";

            XmlNodeList NavPanelContexts = node.SelectNodes("Context");
            foreach (XmlNode node2 in NavPanelContexts)
            {
                Context c = new Context();
                c.contextInfo.name = getNonStandardXmlValueInnerText(node2, "ContextInfo", "name", "");
                c.contextInfo.displayName = getNonStandardXmlValueInnerText(node2, "ContextInfo", "displayName", "");
                c.contextInfo.displayOrder = getNonStandardXmlValueInnerText(node2, "ContextInfo", "displayOrder", "");
                c.contextInfo.icon = getNonStandardXmlValueInnerText(node2, "ContextInfo", "icon", "");
                c.contextInfo.enabled = getNonStandardXmlValueInnerText(node2, "ContextInfo", "enabled", "");

                XmlNodeList cbars = node2.SelectNodes("ControlBar");
                foreach (XmlNode cbar in cbars)
                {
                    try
                    {
                        ControlBar cb = new ControlBar();
                        cb.name = cbar.SelectSingleNode("name").InnerText;
                        cb.displayName = cbar.SelectSingleNode("displayName").InnerText;
                        cb.path = cbar.SelectSingleNode("path").InnerText;
                        cb.icon = cbar.SelectSingleNode("icon").InnerText;
                        try
                        {
                            cb.useSplitView = cbar.SelectSingleNode("useSplitView").InnerText;
                        }
                        catch
                        {
                            cb.useSplitView = null;
                        }
                        cb.enabled = cbar.SelectSingleNode("enabled").InnerText;
                        c.ControlBars.Add(cb);
                    }
                    catch
                    {
                        Log.Logger.Warning("Error parsing the ControlBar Navigation Panel element.");
                        Log.Logger.Warning("ControlBar: " + cbar.OuterXml);
                    }
                }

                npanel.Contexts.Add(c);
            }

            try
            {
                XmlNode helpContext = node.SelectSingleNode("HelpContextInfo");
                if (helpContext != null)
                {
                    Context c = new Context();
                    c.contextInfo.name = helpContext.SelectSingleNode("name").InnerText;
                    c.contextInfo.displayName = helpContext.SelectSingleNode("displayName").InnerText;
                    c.contextInfo.icon = helpContext.SelectSingleNode("icon").InnerText;
                    c.contextInfo.enabled = helpContext.SelectSingleNode("enabled").InnerText;
                    npanel.Contexts.Add(c);
                }
            }
            catch
            {
                Log.Logger.Warning("Error parsing the HelpContextInfo Navigation Panel element.");
            }

            ds.navigationPanel = npanel;
        }
        catch (Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            Log.Logger.Warning("Error parsing NavigationPanel");
        }
    }

    public void ParseCustomValidation(webApplicationWebConfigConfiguration ds, XmlNode node, WebApplicationDataStructures wads)
    {
        try
        {
            Dictionary<string, string[]> customValidationPagesDictionary = wads.getCustomValidationPagesDictionary("211");

            CustomValidation customValidation = new CustomValidation();
            XmlNode appLevel = node.SelectSingleNode("application");
            customValidation.application.scriptLocation = appLevel.Attributes["scriptLocation"].Value;
            if (appLevel.SelectSingleNode("keywords").HasChildNodes)
            {
                foreach (XmlNode alkw in appLevel.SelectSingleNode("keywords").ChildNodes)
                {
                    try
                    {
                        Keyword kw = new Keyword();
                        kw.keywordId = alkw.Attributes["id"].Value;
                        kw.validator = alkw.Attributes["validator"].Value;
                        customValidation.application.keywords.Add(kw);
                    }
                    catch
                    {
                        Log.Logger.Warning("Error parsing the Keyword element.");
                        Log.Logger.Warning("Keyword: " + alkw.OuterXml);
                    }
                }
            }

            XmlNodeList pagesLevel = node.SelectNodes("pages/page");
            foreach (XmlNode p in pagesLevel)
            {
                try
                {
                    Page p2 = new Page();
                    p2.location = p.Attributes["location"].Value;
                    p2.scriptLocation = p.Attributes["scriptLocation"].Value;
                    customValidationPagesDictionary.TryGetValue(p2.location, out var foundObject);
                    p2.name = foundObject[1];
                    p2.htmlId = foundObject[2];

                    foreach (XmlNode alkw in p.SelectSingleNode("keywords").ChildNodes)
                    {
                        try
                        {
                            Keyword kw = new Keyword();
                            kw.keywordId = alkw.Attributes["id"].Value;
                            kw.validator = alkw.Attributes["validator"].Value;
                            p2.keywords.Add(kw);
                        }
                        catch
                        {
                            Log.Logger.Warning("Error parsing the Keyword element.");
                            Log.Logger.Warning("Keyword: " + alkw.OuterXml);
                        }
                    }

                    customValidation.pages.Add(p2);
                }
                catch
                {
                    Log.Logger.Warning("Error parsing the Page element.");
                    Log.Logger.Warning("Page: " + p.OuterXml);
                }
            }

            ds.customValidation = customValidation;
        }
        catch (Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            Log.Logger.Warning("Error parsing CustomValidation");
        }
    }

    private void ParseHylandAuthentication(webApplicationWebConfigConfiguration ds, XmlNode node, string sect)
    {
        try
        {
            HylandAuthentication ha = new HylandAuthentication();
            XmlNode trustedClients = node?.SelectSingleNode("trustedClients");
            try
            {
                switch (trustedClients.Attributes["trustMode"].Value)
                {
                    case "On":
                        ha.TrustMode = "true";
                        break;
                    case "Off":
                        ha.TrustMode = "false";
                        break;
                    default:
                        ha.TrustMode = "false";
                        break;
                }
                //ha.TrustMode = trustedClients.Attributes["trustMode"].Value ?? "On";
            }
            catch
            {
                ha.TrustMode = "false";
            }
            //ha.TrustMode = trustedClients?.Attributes?["trustMode"]?.Value ?? "On";
            foreach (XmlNode tc in trustedClients.ChildNodes)
            {
                TrustedClient tc1 = new TrustedClient();
                tc1.StoreLocation = tc.Attributes["storeLocation"].Value;
                tc1.StoreName = tc.Attributes["storeName"].Value;
                tc1.FindType = tc.Attributes["findType"].Value;
                tc1.FindValue = tc.Attributes["findValue"].Value;
                try
                {
                    if (tc.Attributes["description"].Value == "")
                    {
                        tc1.Description = "<Blank>";
                    }
                    else
                    {
                        tc1.Description = tc.Attributes["description"].Value;
                    }
                }
                catch
                {
                    tc1.Description = "<Blank>";
                }
                ha.trustedClients.Add(tc1);
            }
            ds.hylandAuthentication = ha;
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
            Log.Logger.Warning("Error parsing Hyland.Authentication");
        }
    }

    private void ParseHylandCoreIDOLKeys(webApplicationWebConfigConfiguration ds, XmlNode node, string sect, XmlDocument xmlDocument)
    {
        try
        {
            foreach (XmlNode n in node.ChildNodes)
            {
                if (n.NodeType == XmlNodeType.Comment)
                {
                    //Validates the value inside of the comment is valid XML.
                    if (IsValidXml(n.Value.Trim()))
                    {
                        //Since we know that this is valid XML, need to check and see
                        //if this matches any of the elements in the translator.
                        XmlReader commentReader = XmlReader.Create(new StringReader(n.Value.Trim()));
                        XmlNode n1 = xmlDocument.ReadNode(commentReader);
                        foreach (Key k in ds.knownKeys)
                        {
                            if (k.Section == sect && k.PathName == n1.Name)
                            {
                                k.Value = n1.Attributes[k.AttributeName].Value;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Key k in ds.knownKeys)
                    {
                        if (k.Section == sect && k.PathName == "")
                        {
                            k.Value = node.Attributes[k.AttributeName].Value;
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void ParseAppSettingsKeysV2(webApplicationWebConfigConfiguration ds, XmlNode appSettingsNode, string sect, XmlDocument xmlDoc)
    {
        string[] keysToIgnore = { "KeywordDropdownTypeaheadCharacterMinimum", "dmsOEMProductName" };

        try
        {
            //Parses over each of the elements under the appSettings node, commented out or not.
            foreach (XmlNode node in appSettingsNode.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Comment)
                {
                    //Validates the value inside of the comment is valid XML.
                    if (IsValidXml(node.Value.Trim()))
                    {
                        //Since we know that this is valid XML, need to check and see
                        //if this matches any of the elements in the translator.
                        XmlReader commentReader = XmlReader.Create(new StringReader(node.Value.Trim()));
                        XmlNode n = xmlDoc.ReadNode(commentReader);

                        if(!keysToIgnore.Contains(n.Attributes["key"].Value))
                        {
                            Key k = FindKey(ds.knownKeys, sect, n.Name, n.Attributes["key"].Value);

                            if (k != null)
                            {
                                //Key was found, so we just need to update that keys Value variable.
                                k.Value = n.Attributes["value"].Value;
                            }
                            else
                            {
                                //Key was NOT found, so need to add the node to the Unknown Elements List<>.
                                AddUnknownKeyElement(sect, n, "", ds);
                            }
                        }
                    }
                }
                else
                {
                    if (!keysToIgnore.Contains(node.Attributes["key"].Value))
                    {
                        Key k = FindKey(ds.knownKeys, sect, node.Name, node.Attributes["key"].Value);

                        if (k != null)
                        {
                            //Key was found, so we just need to update that keys Value variable.
                            k.Value = node.Attributes["value"].Value;
                        }
                        else
                        {
                            //Key was NOT found, so need to add the node to the Unknown Elements List<>.
                            AddUnknownKeyElement(sect, node, "", ds);
                        }
                    }
                }
            }

            Key IdPKey = FindKey(ds.knownKeys, "appSettings", "add", "IdPUrl");
            if (IdPKey != null)
            {
                try
                {
                    HylandIdentityProviderUrl h = new HylandIdentityProviderUrl();
                    string[] elements = IdPKey.Value.Split(";");
                    h.ServerLocation = elements[0];
                    h.Tenant = elements[1];
                    h.Client = elements[2];
                    h.Secret = elements[3];
                    ds.hylandIdentityProviderUrl = h;
                }
                catch
                {
                    HylandIdentityProviderUrl h = new HylandIdentityProviderUrl();
                    h.ServerLocation = "";
                    h.Tenant = "";
                    h.Client = "";
                    h.Secret = "";
                    ds.hylandIdentityProviderUrl = h;
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            Log.Logger.Warning("Error parsing the appSettings keys.");
        }
    }

    private static void ParseSpecificKeys(webApplicationWebConfigConfiguration ds, XmlNode node, string sect)
    {
        try
        {
            foreach (Key k in ds.knownKeys)
            {
                //Verifies it is a key in the section we are working with.
                if (k.Section == sect)
                {
                    //Checks if the Path is empty, indicating that the attribute is at the root element level.
                    if (k.PathName == "")
                    {
                        try
                        {
                            k.Value = node.Attributes[k.AttributeName].Value;
                        }
                        catch (Exception e)
                        {
                            Log.Logger.Warning(e.Message);
                            Log.Logger.Warning(e.StackTrace);
                            Log.Logger.Warning("Error parsing the {0} attribute for the {1} node in {2} section.", k.AttributeName, node.Name, sect);
                        }
                    }
                    else
                    {
                        try
                        {
                            k.Value = node.SelectSingleNode(k.PathName).Attributes[k.AttributeName].Value;
                        }
                        catch (Exception e)
                        {
                            Log.Logger.Warning(e.Message);
                            Log.Logger.Warning(e.StackTrace);
                            Log.Logger.Warning("Error parsing the {0} node path for the {1} attribute in the {2} section.", k.PathName, k.AttributeName, sect);
                            //ds.AddNonCriticalError("Error parsing the " + k.PathName + " node path for the " + k.AttributeName + " attribute in the " + sect + " section.");
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            Log.Logger.Warning("Error parsing the specific keys for the {0} section.", sect);
        }
    }

    public void LoadIisConfiguration(webApplicationWebConfigConfiguration ds, ServerManager manager, string siteName, string applicationPath, string applicationName, XmlNode systemweb, Configuration config)
    {
        Application webApplication = manager.Sites[siteName].Applications[applicationPath + applicationName];
        ApplicationPool appPool = manager.ApplicationPools[webApplication.ApplicationPoolName];

        loadApplicationSettings(config, systemweb, webApplication, ds.IisConfiguration);
        loadApplicationPoolSettings(appPool, ds.IisConfiguration);
    }

    public void ParseAdfs(XmlNode root, XmlDocument xmlDoc, webApplicationWebConfigConfiguration ds)
    {
        try
        {
            HylandAuthenticationADFS haadfs = new HylandAuthenticationADFS();
            if (root.SelectSingleNode("system.identityModel") == null && root.SelectSingleNode("system.identityModel.services") == null)
            {
                foreach (XmlNode childNode in root.ChildNodes)
                {
                    if (childNode.NodeType == XmlNodeType.Comment)
                    {
                        string commentValue = childNode.Value.Trim();
                        if (IsValidXml(commentValue))
                        {
                            XmlReader commentReader = XmlReader.Create(new StringReader(commentValue));
                            XmlNode node = xmlDoc.ReadNode(commentReader);

                            switch (node.Name)
                            {
                                case "system.identityModel":
                                    ParseSystemIdentityModel(node, haadfs);
                                    break;
                                case "system.identityModel.services":
                                    ParseSystemIdentityModelServices(node, haadfs);
                                    break;
                            }
                        }
                    }
                }
            }
            else if (root.SelectSingleNode("system.identityModel") == null && root.SelectSingleNode("system.identityModel.services") != null)
            {
                //At this point we know that the system.identityModel is null and will look for it as a commented out section.
                //And we know that the system.identityModel.services is not null and should parse it normally.
                foreach (XmlNode childNode in root.ChildNodes)
                {
                    if (childNode.NodeType == XmlNodeType.Comment)
                    {
                        string commentValue = childNode.Value.Trim();
                        if (IsValidXml(commentValue))
                        {
                            XmlReader commentReader = XmlReader.Create(new StringReader(commentValue));
                            XmlNode node = xmlDoc.ReadNode(commentReader);

                            switch (node.Name)
                            {
                                case "system.identityModel":
                                    ParseSystemIdentityModel(node, haadfs);
                                    break;
                            }
                        }
                    }
                }
                ParseSystemIdentityModelServices(root.SelectSingleNode("system.identityModel.services"), haadfs);
            }
            else if (root.SelectSingleNode("system.identityModel") != null && root.SelectSingleNode("system.identityModel.services") == null)
            {
                //At this point we know that the system.identityModel.services is null and will look for it as a commented out section.
                //And we know that the system.identityModel is not null and should parse it normally.
                foreach (XmlNode childNode in root.ChildNodes)
                {
                    if (childNode.NodeType == XmlNodeType.Comment)
                    {
                        string commentValue = childNode.Value.Trim();
                        if (IsValidXml(commentValue))
                        {
                            XmlReader commentReader = XmlReader.Create(new StringReader(commentValue));
                            XmlNode node = xmlDoc.ReadNode(commentReader);

                            switch (node.Name)
                            {
                                case "system.identityModel.services":
                                    ParseSystemIdentityModelServices(node, haadfs);
                                    break;
                            }
                        }
                    }
                }
                ParseSystemIdentityModel(root.SelectSingleNode("system.identityModel"), haadfs);
            }
            else
            {
                //Since the rest of the above are false, we know that both are uncommented and will be parsed normally.
                ParseSystemIdentityModel(root.SelectSingleNode("system.identityModel"), haadfs);
                ParseSystemIdentityModelServices(root.SelectSingleNode("system.identityModel.services"), haadfs);
            }

            ParseCoreAdfsSettings(root, haadfs);

            ds.hylandAuthenticationADFS = haadfs;
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void ParseCoreAdfsSettings(XmlNode node, HylandAuthenticationADFS haadfs)
    {
        try
        {
            haadfs.ADFSEnabled = node?.SelectSingleNode("Hyland.Authentication/adfs")?.Attributes?["enabled"]?.Value ?? "false";
            haadfs.RequestValidationMode = node?.SelectSingleNode("system.web/httpRuntime")?.Attributes?["requestValidationMode"]?.Value ?? "2.0";
            haadfs.AuthenticationMode = node?.SelectSingleNode("system.web/authentication")?.Attributes?["mode"]?.Value ?? "Windows";
            haadfs.SynchronizeUserAttributes = node?.SelectSingleNode("Hyland.Authentication/adfs")?.Attributes?["synchronizeUserAttributes"]?.Value ?? "true";
            haadfs.AuthenticationOnly = node?.SelectSingleNode("Hyland.Authentication/adfs")?.Attributes?["authenticationOnly"]?.Value ?? "false";
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void ParseSystemIdentityModel(XmlNode node, HylandAuthenticationADFS haadfs)
    {
        try
        {
            foreach (XmlNode n in node.SelectNodes("identityConfiguration/securityTokenHandlers/securityTokenHandlerConfiguration/audienceUris/add"))
            {
                AudienceUri auri = new AudienceUri();
                auri.URI = n.Attributes["value"].Value;
                haadfs.systemIdentityModel.audienceUris.Add(auri);
            }

            foreach (XmlNode n1 in node.SelectNodes("identityConfiguration/securityTokenHandlers/securityTokenHandlerConfiguration/issuerNameRegistry/trustedIssuers/add"))
            {
                try
                {
                    TrustedIssuer ti = new TrustedIssuer();
                    ti.Thumbprint = n1.Attributes["thumbprint"].Value;
                    ti.Name = n1.Attributes["name"].Value;
                    haadfs.systemIdentityModel.trustedIssuers.Add(ti);
                }
                catch
                {

                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void ParseSystemIdentityModelServices(XmlNode node, HylandAuthenticationADFS haadfs)
    {
        try
        {
            haadfs.systemIdentityModelServices.CookieHandlerRequireSSL = node?.SelectSingleNode("federationConfiguration/cookieHandler")?.Attributes?["requireSsl"].Value ?? "false";
            haadfs.systemIdentityModelServices.wsFederation.Issuer = node.SelectSingleNode("federationConfiguration/wsFederation").Attributes["issuer"].Value;
            haadfs.systemIdentityModelServices.wsFederation.Realm = node.SelectSingleNode("federationConfiguration/wsFederation").Attributes["realm"].Value;
            haadfs.systemIdentityModelServices.serviceCertificate.X509FindType = node.SelectSingleNode("federationConfiguration/serviceCertificate/certificateReference").Attributes["x509FindType"].Value;
            haadfs.systemIdentityModelServices.serviceCertificate.FindValue = node.SelectSingleNode("federationConfiguration/serviceCertificate/certificateReference").Attributes["findValue"].Value;
            haadfs.systemIdentityModelServices.serviceCertificate.StoreLocation = node.SelectSingleNode("federationConfiguration/serviceCertificate/certificateReference").Attributes["storeLocation"].Value;
            haadfs.systemIdentityModelServices.serviceCertificate.StoreName = node.SelectSingleNode("federationConfiguration/serviceCertificate/certificateReference").Attributes["storeName"].Value;
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private string getMinMaxErrorLevel(Route routeData, string leveltoget)
    {
        try
        {
            if (leveltoget == "Min")
            {
                switch (routeData.filter.MinimumErrorLevel)
                {
                    case "1":
                        return "Trace";
                    case "2":
                        return "Debug";
                    case "3":
                        return "Information";
                    case "4":
                        return "Warning";
                    case "5":
                        return "Error";
                    case "6":
                        return "Critical";
                }
            }
            else if (leveltoget == "Max")
            {
                switch (routeData.filter.MaximumErrorLevel)
                {
                    case "1":
                        return "Trace";
                    case "2":
                        return "Debug";
                    case "3":
                        return "Information";
                    case "4":
                        return "Warning";
                    case "5":
                        return "Error";
                    case "6":
                        return "Critical";
                }
            }
            //Default return value that should never be returned.
            return "";
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
            return "";
        }
    }

    private void ParseAllElementsAndAttributes(webApplicationWebConfigConfiguration ds, XmlNode node, string sect)
    {
        try
        {
            bool validattribute = false;
            //string attrname = "";
            List<Key> tempkeys = new List<Key>();
            //Loops over all of the known keys.
            foreach (Key k in ds.knownKeys)
            {
                //Verifies it is a key in the section we are working with.
                if (k.Section == sect)
                {
                    if (k.PathName == node.LocalName)
                    {
                        tempkeys.Add(k);
                    }
                }
            }

            if (tempkeys.Count == 0)
            {
                AddUnknownKeyElement(sect, node, "", ds);
            }
            else
            {
                foreach (XmlAttribute attr in node.Attributes)
                {
                    validattribute = false;
                    foreach (Key k in tempkeys)
                    {
                        if (attr.Name == k.AttributeName)
                        {
                            validattribute = true;
                            k.Value = attr.Value;
                            break;
                        }
                    }

                    if (!validattribute)
                    {
                        AddUnknownKeyAttribute(sect, node, attr.Name, ds);
                    }
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void ParseHylandApplicationsAgendaPubAccessPublicCommentExtraKeys(webApplicationWebConfigConfiguration ds, XmlNode node, string sect)
    {
        try
        {
            HylandApplicationsAgendaPubAccessPublicComment h = new HylandApplicationsAgendaPubAccessPublicComment();
            foreach (XmlNode n in node.SelectSingleNode("integrations/integration/meeting_types"))
            {
                if (n.Name == "meeting_type")
                {
                    MeetingType mt = new MeetingType();
                    mt.Name = n.Attributes["name"].Value;
                    h.meetingTypes.Add(mt);
                }
            }

            foreach (XmlNode n1 in node.SelectSingleNode("integrations/integration/agenda_fields"))
            {
                if (n1.Name == "field")
                {
                    AgendaField af = new AgendaField();
                    af.Name = n1.Attributes["name"].Value;
                    af.FormFieldID = n1.Attributes["form_field_id"].Value;
                    h.agendaUnityFormFields.Add(af);
                }
            }
            ds.hylandApplicationsAgendaPubAccessPublicComment = h;
        }
        catch (Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            Log.Logger.Warning("Error processing Hyland.Applications.AgendaPubAccessPublicComment keys.");
        }
    }

    private void ParseHylandApplicationsAgendaPubAccessPublicComment(webApplicationWebConfigConfiguration ds, XmlNode node, string sect)
    {
        try
        {
            XmlNodeList integrations = node.SelectNodes("integrations/integration");

            foreach(XmlNode n in integrations)
            {
                if(n.Attributes["name"].Value != "")
                {
                    HylandApplicationsAgendaPubAccessPublicComment h = new HylandApplicationsAgendaPubAccessPublicComment();
                    h.Name = n.Attributes["name"].Value;
                    h.URL = n.Attributes["url"].Value;
                    h.Token = n.Attributes["token"].Value;
                    h.AvailabilityFromMeetingStart = n.Attributes["AvailabilityFromMeetingStart"].Value;

                    foreach (XmlNode n1 in node.SelectSingleNode("integrations/integration/agenda_fields"))
                    {
                        if (n1.Name == "field")
                        {
                            AgendaField af = new AgendaField();
                            af.Name = n1.Attributes["name"].Value;
                            af.FormFieldID = n1.Attributes["form_field_id"].Value;
                            h.agendaUnityFormFields.Add(af);
                        }
                    }

                    foreach (XmlNode n2 in node.SelectSingleNode("integrations/integration/meeting_types"))
                    {
                        if (n2.Name == "meeting_type")
                        {
                            MeetingType mt = new MeetingType();
                            mt.Name = n2.Attributes["name"].Value;
                            h.meetingTypes.Add(mt);
                        }
                    }

                    ds.publicCommentIntegrations.Add(h);
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            Log.Logger.Warning("Error processing Hyland.Applications.AgendaPubAccessPublicComment keys.");
        }
    }

    private void ParseHylandLogging(webApplicationWebConfigConfiguration ds, XmlNode node, WebApplicationDataStructures wads)
    {
        try
        {
            HylandLogging hl = new HylandLogging();
            hl.truncateloggingcharacters = node?.Attributes?["TruncateLogValues"]?.Value ?? "1024";

            string? sourceName = node?.SelectSingleNode("WindowsEventLogging")?.Attributes?["sourcename"]?.Value?.ToString();
            if (sourceName != null)
            {
                hl.windowsEventLogging.SourceName = sourceName;
            }

            try
            {
                if (node.SelectSingleNode("Routes") != null && node.SelectSingleNode("Routes").HasChildNodes)
                {
                    XmlNodeList? xmlRoutes = node?.SelectSingleNode("Routes")?.SelectNodes("Route");
                    ParseHylandLoggingRoutes(xmlRoutes, hl, "Diagnostics Events");
                }
            }
            catch
            {
                Log.Logger.Warning("There are no Routes to process.");
            }

            try
            {
                if (node.SelectSingleNode("AuditRoutes") != null && node.SelectSingleNode("AuditRoutes").HasChildNodes)
                {
                    XmlNodeList? xmlRoutes = node?.SelectSingleNode("AuditRoutes")?.SelectNodes("Route");

                    ParseHylandLoggingRoutes(xmlRoutes, hl, "Audit Events");
                }
            }
            catch
            {
                Log.Logger.Warning("There are no AuditRoutes to process.");
            }
            
            ds.hylandLogging = hl;

            hl.profilesForHTML = wads.getDiagnosticsSettingsProfiles(ds.Version);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
            Log.Logger.Warning("Error parsing Hyland.Logging");
        }
    }

    private void ParseHylandLoggingRoutes(XmlNodeList xmlRoutes, HylandLogging hl, string SourceEvents)
    {
        try
        {
            //Newer code and way of doing things.
            foreach (XmlNode xnode in xmlRoutes)
            {
                Route r = new Route();

                foreach (XmlNode xnode1 in xnode.ChildNodes)
                {
                    if(xnode1.NodeType != XmlNodeType.Comment)
                    {
                        switch (xnode1.Attributes["key"].Value)
                        {
                            case "Console":
                                r.RouteType = "Console";
                                HylandLoggingRouteConsole c = new HylandLoggingRouteConsole();
                                c.OutputFormat = xnode?.SelectSingleNode("add[@key='OutputFormat']")?.Attributes?["value"]?.Value ?? "Minimal";
                                r.console = c;
                                break;
                            case "DurableHttp":
                                r.RouteType = "DurableHttp";
                                HylandLoggingRouteDurableHTTP d = new HylandLoggingRouteDurableHTTP();
                                d.URL = xnode1.Attributes["value"].Value;
                                r.durablehttp = d;
                                break;
                            case "HylandLog":
                            case "EventLog":
                                r.RouteType = "EventLog";
                                HylandLoggingRouteEventLog e = new HylandLoggingRouteEventLog();
                                e.SourceName = xnode1?.Attributes["value"]?.Value ?? "Hyland";
                                r.eventlog = e;
                                break;
                            case "File":
                                r.RouteType = "File";
                                HylandLoggingRouteFile f = new HylandLoggingRouteFile();
                                f.FilePath = xnode1.Attributes["value"].Value;
                                f.FileSizeLimit = xnode.SelectSingleNode("add[@key='FileByteLimit']")?.Attributes["value"].Value ?? "1073741824";
                                f.RollWhenLimitReached = xnode.SelectSingleNode("add[@key='FileRollOnSize']")?.Attributes["value"].Value ?? "False";
                                f.RollInterval = xnode.SelectSingleNode("add[@key='FileRollInterval']")?.Attributes["value"].Value ?? "Infinite";
                                if (String.IsNullOrWhiteSpace(xnode.SelectSingleNode("add[@key='FileCountLimit']")?.Attributes["value"].Value))
                                {
                                    f.RetainedFilesCount = "0";
                                }
                                else
                                {
                                    f.RetainedFilesCount = xnode.SelectSingleNode("add[@key='FileCountLimit']")?.Attributes["value"].Value;
                                }
                                f.OutputFormat = xnode.SelectSingleNode("add[@key='OutputFormat']").Attributes["value"].Value;
                                r.file = f;
                                break;
                            case "Http":
                                r.RouteType = "Http";
                                HylandLoggingRouteHTTP h = new HylandLoggingRouteHTTP();
                                h.URL = xnode1.Attributes["value"].Value;
                                r.http = h;
                                break;
                            case "Splunk":
                                r.RouteType = "Splunk";
                                HylandLoggingRouteSplunk s = new HylandLoggingRouteSplunk();
                                s.ServerUrl = xnode1.Attributes["value"].Value;
                                s.SplunkToken = xnode.SelectSingleNode("add[@key='SplunkToken']")?.Attributes["value"].Value ?? "";
                                s.SplunkIndex = xnode.SelectSingleNode("add[@key='SplunkIndex']").Attributes["value"].Value;
                                s.SplunkSource = xnode.SelectSingleNode("add[@key='SplunkSource']").Attributes["value"].Value;
                                s.SplunkSourceType = xnode.SelectSingleNode("add[@key='SplunkSourceType']").Attributes["value"].Value;
                                s.SplunkHost = xnode.SelectSingleNode("add[@key='SplunkHost']").Attributes["value"].Value;
                                r.splunk = s;
                                break;
                        }
                    }
                }

                if (r.RouteType != null)
                {
                    r.Name = xnode.Attributes["name"].Value;
                    r.SourceEvents = SourceEvents;

                    string temp = xnode.SelectSingleNode("add[@key='DisableIPAddressMasking']")?.Attributes["value"].Value.ToLower() ?? "False";
                    if (bool.Parse(temp))
                    {
                        r.EnableIpAddressMasking = "False";
                    }
                    else
                    {
                        r.EnableIpAddressMasking = "True";
                    }

                    switch (xnode.SelectSingleNode("add[@key='minimum-level']")?.Attributes["value"]?.Value ?? "Information")
                    {
                        case "Trace":
                            r.filter.MinimumErrorLevel = "1";
                            break;
                        case "Debug":
                            r.filter.MinimumErrorLevel = "2";
                            break;
                        case "Information":
                            r.filter.MinimumErrorLevel = "3";
                            break;
                        case "Warning":
                            r.filter.MinimumErrorLevel = "4";
                            break;
                        case "Error":
                            r.filter.MinimumErrorLevel = "5";
                            break;
                        case "Critical":
                            r.filter.MinimumErrorLevel = "6";
                            break;
                        default:
                            r.filter.MinimumErrorLevel = "6";
                            break;
                    }

                    switch (xnode.SelectSingleNode("add[@key='maximum-level']")?.Attributes["value"]?.Value ?? "Critical")
                    {
                        case "Trace":
                            r.filter.MaximumErrorLevel = "1";
                            break;
                        case "Debug":
                            r.filter.MaximumErrorLevel = "2";
                            break;
                        case "Information":
                            r.filter.MaximumErrorLevel = "3";
                            break;
                        case "Warning":
                            r.filter.MaximumErrorLevel = "4";
                            break;
                        case "Error":
                            r.filter.MaximumErrorLevel = "5";
                            break;
                        case "Critical":
                            r.filter.MaximumErrorLevel = "6";
                            break;
                        default:
                            r.filter.MaximumErrorLevel = "3";
                            break;
                    }

                    if (xnode?.SelectSingleNode("add[@key='include-profiles']")?.Attributes?["value"]?.Value != "" && xnode?.SelectSingleNode("add[@key='include-profiles']")?.Attributes?["value"]?.Value != null)
                    {
                        r.filter.FilterProfilesIncludeExcludeNeither = "Include";
                        string[] profiles = xnode.SelectSingleNode("add[@key='include-profiles']")?.Attributes["value"].Value.Split(',');
                        for (int j = 0; j < profiles.Length; j++)
                        {
                            r.filter.Profiles.Add(profiles[j]);
                        }
                    }
                    else if (xnode?.SelectSingleNode("add[@key='exclude-profiles']")?.Attributes?["value"]?.Value != "" && xnode?.SelectSingleNode("add[@key='exclude-profiles']")?.Attributes?["value"]?.Value != null)
                    {
                        r.filter.FilterProfilesIncludeExcludeNeither = "Exclude";
                        string[] profiles = xnode.SelectSingleNode("add[@key='exclude-profiles']").Attributes["value"].Value.Split(',');
                        for (int j = 0; j < profiles.Length; j++)
                        {
                            r.filter.Profiles.Add(profiles[j]);
                        }
                    }
                    else
                    {
                        r.filter.FilterProfilesIncludeExcludeNeither = "Neither";
                    }

                    hl.Routes.Add(r);
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void AddUnknownKeyAttribute(String sect, XmlNode node, String attrname, webApplicationWebConfigConfiguration ds)
    {
        try
        {
            Key key = new Key();
            key.Section = sect;
            key.PathName = node.LocalName;
            key.AttributeName = attrname;
            //Because we don't know the type, we apply the unknown value of 0.
            key.type = "0";
            //Because there isn't an HTML ID value, we just set this to blank.
            key.htmlIdName = "";
            key.Value = node.Attributes[attrname].Value;
            key.Version = ds.Version;
            ds.unknownAttributeKeys.Add(key);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void loadApplicationPoolSettings(Microsoft.Web.Administration.ApplicationPool appPool, IisConfiguration iisConfiguration)
    {
        try
        {
            IisApplicationPool applicationPool = new IisApplicationPool();
            applicationPool.generalNetClrVerson = appPool.ManagedRuntimeVersion.ToString();
            applicationPool.generalEnable32BitApplications = appPool.Enable32BitAppOnWin64.ToString();
            applicationPool.generalManagedPilelineMode = appPool.ManagedPipelineMode.ToString();
            applicationPool.generalQueueLength = appPool.QueueLength.ToString();
            applicationPool.generalStartMode = appPool.StartMode.ToString();
            applicationPool.cpuLimitInterval = appPool.Cpu.ResetInterval.Minutes.ToString();
            applicationPool.processModelIdentityType = appPool.ProcessModel.IdentityType.ToString();
            applicationPool.processModelIdentityUsername = appPool.ProcessModel.UserName.ToString();
            applicationPool.processModelIdentityPassword = appPool.ProcessModel.Password.ToString();
            applicationPool.processModelIdleTimeOut = appPool.ProcessModel.IdleTimeout.Minutes.ToString();
            applicationPool.processModelPingEnabled = appPool.ProcessModel.PingingEnabled.ToString();
            applicationPool.rapidFailProtectionEnabled = appPool.Failure.RapidFailProtection.ToString();
            applicationPool.recyclingRegularTimeInterval = appPool.Recycling.PeriodicRestart.Time.Minutes.ToString();
            iisConfiguration.applicationPool = applicationPool;
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void AddUnknownKeyElement(String sect, XmlNode node, String attrname, webApplicationWebConfigConfiguration ds)
    {
        try
        {
            Key key = new Key();
            key.Section = sect;
            key.PathName = node.LocalName;
            key.AttributeName = attrname;
            //Because we don't know the type, we apply the unknown value of 0.
            key.type = "0";
            //Because there isn't an HTML ID value, we just set this to blank.
            key.htmlIdName = "";
            key.Value = node.OuterXml;
            key.Version = ds.Version;
            key.minimumValue = "";
            key.maximumValue = "";
            ds.unknownElementKeys.Add(key);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void ParseWebApplicationTranslator(NETCoreToNetFrameworkTranslator translator, string type, webApplicationWebConfigConfiguration webconfigconfig)
    {
        try
        {
            //TODO: Need to add an "action" string variable to this method possibly so it can handle both the parsing and the saving.
            switch (type)
            {
                case "Application Server":
                    //parseApplicationServerTranslator(translator, webconfigconfig);
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
                case "Public Access - Legacy":
                    break;
                case "Public Access - Next Gen":
                    break;
                case "Reporting Viewer":
                    break;
                case "Web Server":
                    break;
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    //private void parseApplicationServerTranslator(NETCoreToNetFrameworkTranslator translator, webApplicationWebConfigConfiguration webconfigconfig)
    //{
    //    try
    //    {
    //        foreach (Key keys in webconfigconfig.knownKeys)
    //        {
    //            switch (keys.Section)
    //            {
    //                case "Hyland.Web.AppServerPop":
    //                    switch (keys.PathName)
    //                    {
    //                        case "EnableChecksum":
    //                            keys.Value = translator.ApplicationServer.AppServerPopIntegration.EnableCheckSum;
    //                            break;
    //                        case "ChecksumKey":
    //                            keys.Value = translator.ApplicationServer.AppServerPopIntegration.ChecksumKey;
    //                            break;
    //                        case "EnableLegacyChecksumCreation":
    //                            keys.Value = translator.ApplicationServer.AppServerPopIntegration.EnableLegacyChecksumCreation;
    //                            break;
    //                        case "IsEncrypted":
    //                            keys.Value = translator.ApplicationServer.AppServerPopIntegration.IsEncrypted;
    //                            break;
    //                    }
    //                    break;
    //                case "Hyland.Applications.Portals.ExternalAccess":
    //                    switch (keys.PathName)
    //                    {
    //                        case "username":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerExernalAccess.Username;
    //                            break;
    //                        case "password":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerExernalAccess.Password;
    //                            break;
    //                        case "minPoolSize":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerExernalAccess.MinPoolSize;
    //                            break;
    //                        case "maxPoolSize":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerExernalAccess.MaxPoolSize;
    //                            break;
    //                        case "IsEncrypted":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerExernalAccess.IsEncrypted;
    //                            break;
    //                    }
    //                    break;
    //                case "Hyland.ContentComposer.Core":
    //                    switch (keys.PathName)
    //                    {
    //                        case "ClientId":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerContentComposer.ClientID;
    //                            break;
    //                        case "ClientSecret":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerContentComposer.ClientSecret;
    //                            break;
    //                        case "Username":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerContentComposer.Username;
    //                            break;
    //                        case "Password":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerContentComposer.Password;
    //                            break;
    //                        case "IsEncrypted":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerContentComposer.IsEncrypted;
    //                            break;
    //                    }
    //                    break;
    //                case "Hyland.Core.Media.HostedApplicationServer":
    //                    switch (keys.PathName)
    //                    {
    //                        case "url":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerMedia.URL;
    //                            break;
    //                        case "datasource":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerMedia.Datasource;
    //                            break;
    //                        case "username":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerMedia.Username;
    //                            break;
    //                        case "password":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerMedia.Password;
    //                            break;
    //                        case "IsEncrypted":
    //                            keys.Value = translator.ApplicationServer.ApplicationServerMedia.IsEncrypted;
    //                            break;
    //                    }
    //                    break;
    //            }
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        Log.Logger.Error(e.Message);
    //        Log.Logger.Error(e.StackTrace);
    //    }

    //    try
    //    {
    //        /********************************************************
    //         *                  Connection Strings
    //         ********************************************************/
    //        //! Will pull all of this from the translator object due to potential encryption.
    //        //ConnectionStringsDataStructure cstrings = new ConnectionStringsDataStructure();
    //        ConnectionStrings connectionStrings = new ConnectionStrings();
    //        webconfigconfig.connectionStrings = connectionStrings;
    //        if(translator.ApplicationServer.AppServerConnectionStrings.ConnectionStrings.Count > 0)
    //        {
    //            foreach (COMACONTranslationToHelperUtility.ConnectionString cstring in translator.ApplicationServer.AppServerConnectionStrings.ConnectionStrings)
    //            {
    //                ConnectionString cstring1 = new ConnectionString();
    //                cstring1.Name = cstring.Name;
    //                cstring1.Provider = cstring.ProviderName;
    //                cstring1.IntegratedSecurity = cstring.IntegratedSecurity;
    //                cstring1.UserId = cstring.UserID;
    //                cstring1.Password = cstring.Password;
    //                cstring1.AdditionalOptions = cstring.AdditionalParameters;
    //                switch (cstring.ProviderName)
    //                {
    //                    case "System.Data.SqlClient":
    //                        ConnectionStringSql cstringsql = new ConnectionStringSql();
    //                        cstringsql.DataSource = cstring.DataSource;
    //                        cstringsql.Database = cstring.Database;
    //                        cstring1.sql = cstringsql;
    //                        break;
    //                    case "Oracle.ManagedDataAccess.Client":
    //                        ConnectionStringOracle cstringoracle = new ConnectionStringOracle();
    //                        cstringoracle.TNSConnectionString = cstring.TnsConnectionString;
    //                        cstringoracle.Host = cstring.OracleHost;
    //                        cstringoracle.Database = cstring.Database;
    //                        cstringoracle.Protocol = cstring.OracleProtocol;
    //                        cstringoracle.Port = cstring.OraclePort;
    //                        cstring1.oracle = cstringoracle;
    //                        break;
    //                }
    //                webconfigconfig.connectionStrings.connectionStrings.Add(cstring1);
    //            }
    //            connectionStrings.EncryptConnectionStrings = translator.ApplicationServer.AppServerConnectionStrings.IsEncrypted;
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        Log.Logger.Error(e.Message);
    //        Log.Logger.Error(e.StackTrace);
    //    }
    //}


    /********************************************************
     *                  Saving Functions
     ********************************************************/
    public void SaveKnownKeys(webApplicationWebConfigConfiguration ds, string sect, XmlNode node, XmlDocument xmlDoc)
    {
        //Console.WriteLine("Saving " + sect);
        switch (sect)
        {
            case "appSettings":
                foreach (Key k in ds.knownKeys)
                {
                    if (k.Section == sect)
                    {
                        if (k.AttributeName == "IdPUrl")
                        {
                            if (ds.hylandIdentityProviderUrl.ServerLocation == "" || ds.hylandIdentityProviderUrl.Tenant == "" || ds.hylandIdentityProviderUrl.Client == "" || ds.hylandIdentityProviderUrl.Secret == "")
                            {
                                k.Value = "";
                            }
                            else
                            {
                                k.Value = ds.hylandIdentityProviderUrl.ServerLocation + ";" + ds.hylandIdentityProviderUrl.Tenant + ";" + ds.hylandIdentityProviderUrl.Client + ";" + ds.hylandIdentityProviderUrl.Secret;
                            }
                        }

                        SaveAppSettingsSection(node, k, xmlDoc);
                    }
                }
                break;
            case "Hyland.Applications.AgendaPubAccess.PublicComment":
                //SaveHylandApplicationsAgendaPubAccessPublicCommentExtraKeys(xmlDoc, node, ds);
                SaveHylandApplicationsAgendaPubAccessPublicComment(xmlDoc, node, ds);
                break;
            case "Hyland.Logging":
                SaveHylandLoggingDiagnosticsRoutes(xmlDoc, node, ds);
                break;
            case "Hyland.Core.Wopi":
                SaveHylandCoreWopiSection(xmlDoc, node, ds);
                break;
            case "Hyland.Authentication-TrustedClients":
                SaveHylandAuthenticationTrustedClients(xmlDoc, node, ds);
                break;
            case "ADFS":
                SaveAdfs(xmlDoc, node, ds);
                break;
            case "CustomValidation":
                SaveCustomValidationSection(xmlDoc, node, ds);
                break;
            case "NavigationPanel":
                SaveNavigationPanelSection(xmlDoc, node, ds);
                break;
            case "Healthcare Web Viewer Origin URL":
                SaveHealthcareWebViewerSourceOriginUrl(xmlDoc, node, ds);
                break;
            case "Keyword Dropdown Typeahead":
                SaveKeywordDropdownTypeahead(xmlDoc, node, ds);
                break;
            case "Hyland.Services.Client":
                foreach (Key k in ds.knownKeys)
                {
                    if (k.Section == sect)
                    {
                        SaveSpecificKeys(node, k, xmlDoc);
                    }
                }
                PostSaveHylandServicesClientSection(node);
                break;
            default:
                foreach (Key k in ds.knownKeys)
                {
                    if (k.Section == sect)
                    {
                        SaveSpecificKeys(node, k, xmlDoc);
                    }
                }
                break;
        }
    }

    private void PostSaveHylandServicesClientSection(XmlNode hscnode)
    {
        try
        {
            switch (hscnode.SelectSingleNode("ApplicationServer").Attributes["ServiceClientType"].Value)
            {
                case "SOAP":
                    hscnode.SelectSingleNode("ApplicationServer").Attributes["Url"].Value += "/Service.asmx";
                    break;
                case "Remoting":
                case "remoting":
                    hscnode.SelectSingleNode("ApplicationServer").Attributes["Url"].Value += "/Service.rem";
                    break;
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void SaveHylandAuthenticationTrustedClients(XmlDocument configurationDocument, XmlNode node, webApplicationWebConfigConfiguration core)
    {
        try
        {
            XmlNode trustedClientsNode = node.SelectSingleNode("trustedClients");
            //trustedClientsNode.Attributes["trustMode"].Value = core.hylandAuthentication.TrustMode;
            trustedClientsNode.RemoveAll();
            XmlAttribute trustmode = configurationDocument.CreateAttribute("trustMode");
            switch (core.hylandAuthentication.TrustMode)
            {
                case "true":
                    trustmode.Value = "On";
                    break;
                case "false":
                    trustmode.Value = "Off";
                    break;
                default:
                    trustmode.Value = "Off";
                    break;
            }
            trustedClientsNode.Attributes.Append(trustmode);

            foreach (TrustedClient tc in core.hylandAuthentication.trustedClients)
            {
                XmlNode trustedClientNode = configurationDocument.CreateElement("add");
                XmlAttribute storeLocation = configurationDocument.CreateAttribute("storeLocation");
                storeLocation.Value = tc.StoreLocation;
                trustedClientNode.Attributes.Append(storeLocation);
                XmlAttribute storeName = configurationDocument.CreateAttribute("storeName");
                storeName.Value = tc.StoreName;
                trustedClientNode.Attributes.Append(storeName);
                XmlAttribute findType = configurationDocument.CreateAttribute("findType");
                findType.Value = tc.FindType;
                trustedClientNode.Attributes.Append(findType);
                XmlAttribute findValue = configurationDocument.CreateAttribute("findValue");
                findValue.Value = tc.FindValue;
                trustedClientNode.Attributes.Append(findValue);
                if (tc.Description != "<Blank>")
                {
                    XmlAttribute description = configurationDocument.CreateAttribute("description");
                    description.Value = tc.Description;
                    trustedClientNode.Attributes.Append(description);
                }
                trustedClientsNode.AppendChild(trustedClientNode);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void SaveHylandCoreWopiSection(XmlDocument configurationDocument, XmlNode node, webApplicationWebConfigConfiguration core)
    {
        try
        {
            bool wopiEndpointEnabled = false;
            //Still need to add code to figure out if I need to make the Hyland.Core.Wopi section uncommented or not.
            foreach (Key key in core.knownKeys)
            {
                if (key.Section == "appSettings" && key.PathName == "add" && key.AttributeName == "endpoints:Wopi")
                {
                    if (bool.Parse(key.Value))
                    {
                        wopiEndpointEnabled = true;
                    }
                    break;
                }
            }

            if (node.SelectSingleNode("Hyland.Core.Wopi") != null)
            {
                foreach (Key k in core.knownKeys)
                {
                    if (k.Section == "Hyland.Core.Wopi")
                    {
                        node.SelectSingleNode("Hyland.Core.Wopi/" + k.PathName).Attributes[k.AttributeName].Value = k.Value;
                    }
                }

                if (wopiEndpointEnabled)
                {
                    XmlNode cnode = configurationDocument.CreateNode(XmlNodeType.Comment, "", null);
                    cnode.Value = node.SelectSingleNode("Hyland.Core.Wopi").OuterXml;
                    node.ReplaceChild(cnode, node.SelectSingleNode("Hyland.Core.Wopi"));
                }
            }
            else
            {
                foreach (XmlNode cnode in node.ChildNodes)
                {
                    if (cnode.NodeType == XmlNodeType.Comment)
                    {
                        if (IsValidXml(cnode.Value.Trim()))
                        {
                            XmlReader commentReader = XmlReader.Create(new StringReader(cnode.Value.Trim()));
                            XmlNode n = configurationDocument.ReadNode(commentReader);
                            if (n.Name == "Hyland.Core.Wopi")
                            {
                                foreach (Key k in core.knownKeys)
                                {
                                    if (k.Section == "Hyland.Core.Wopi")
                                    {
                                        n.SelectSingleNode(k.PathName).Attributes[k.AttributeName].Value = k.Value;
                                    }
                                }

                                if (wopiEndpointEnabled)
                                {
                                    node.ReplaceChild(n, cnode);
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void SaveNavigationPanelSection(XmlDocument configurationDocument, XmlNode node, webApplicationWebConfigConfiguration core)
    {
        try
        {
            node.SelectSingleNode("DefaultContextInfo/defaultContext").InnerText = core?.navigationPanel.defaultContext;
            node.SelectSingleNode("DefaultContextInfo/defaultControlBar").InnerText = core.navigationPanel.defaultControlBar;
            node.SelectSingleNode("DefaultContextInfo/defaultContextID").InnerText = core.navigationPanel.defaultContextID;

            XmlNodeList contextNodes = node.SelectNodes("Context");

            // Loop through and remove each "Context" element
            foreach (XmlNode contextNode in contextNodes)
            {
                // Remove the "Context" element from its parent
                contextNode.ParentNode.RemoveChild(contextNode);
            }

            foreach (Context c in core.navigationPanel.Contexts)
            {
                if (c.contextInfo.name == "Help")
                {
                    node.SelectSingleNode("HelpContextInfo/name").RemoveAll();
                    node.SelectSingleNode("HelpContextInfo/name").AppendChild(configurationDocument.CreateCDataSection(c.contextInfo.name));
                    node.SelectSingleNode("HelpContextInfo/displayName").RemoveAll();
                    node.SelectSingleNode("HelpContextInfo/displayName").AppendChild(configurationDocument.CreateCDataSection(c.contextInfo.displayName));
                    node.SelectSingleNode("HelpContextInfo/icon").RemoveAll();
                    node.SelectSingleNode("HelpContextInfo/icon").AppendChild(configurationDocument.CreateCDataSection(c.contextInfo.icon));
                    node.SelectSingleNode("HelpContextInfo/enabled").InnerText = capitalizeFirstLetterOfString(c.contextInfo.enabled);
                }
                else
                {
                    //Creates the Context node.
                    XmlNode context = configurationDocument.CreateElement("Context");

                    //Creates the ContextInfo node and all of the child nodes as well as assigns them their appropriate value.
                    XmlNode contextInfo = configurationDocument.CreateElement("ContextInfo");
                    XmlNode contextInfoName = configurationDocument.CreateElement("name");
                    contextInfoName.AppendChild(configurationDocument.CreateCDataSection(c.contextInfo.name));
                    contextInfo.AppendChild(contextInfoName);
                    XmlNode contextInfoDisplayName = configurationDocument.CreateElement("displayName");
                    contextInfoDisplayName.AppendChild(configurationDocument.CreateCDataSection(c.contextInfo.displayName));
                    contextInfo.AppendChild(contextInfoDisplayName);
                    XmlNode contextInfoDisplayOrder = configurationDocument.CreateElement("displayOrder");
                    contextInfoDisplayOrder.InnerText = c.contextInfo.displayOrder;
                    contextInfo.AppendChild(contextInfoDisplayOrder);
                    XmlNode contextInfoIcon = configurationDocument.CreateElement("icon");
                    contextInfoIcon.AppendChild(configurationDocument.CreateCDataSection(c.contextInfo.icon));
                    contextInfo.AppendChild(contextInfoIcon);
                    XmlNode contextInfoEnabled = configurationDocument.CreateElement("enabled");
                    contextInfoEnabled.InnerText = capitalizeFirstLetterOfString(c.contextInfo.enabled);
                    contextInfo.AppendChild(contextInfoEnabled);
                    context.AppendChild(contextInfo);

                    //Creates each of the individual ControlBar elements and their children elements as well as assigning them their appropriate values.
                    foreach (ControlBar cbar in c.ControlBars)
                    {
                        XmlNode controlBar = configurationDocument.CreateElement("ControlBar");
                        XmlNode controlBarName = configurationDocument.CreateElement("name");
                        controlBarName.AppendChild(configurationDocument.CreateCDataSection(cbar.name));
                        controlBar.AppendChild(controlBarName);
                        XmlNode controlBarDisplayName = configurationDocument.CreateElement("displayName");
                        controlBarDisplayName.AppendChild(configurationDocument.CreateCDataSection(cbar.displayName));
                        controlBar.AppendChild(controlBarDisplayName);
                        XmlNode controlBarPath = configurationDocument.CreateElement("path");
                        controlBarPath.AppendChild(configurationDocument.CreateCDataSection(cbar.path));
                        controlBar.AppendChild(controlBarPath);
                        XmlNode controlBarIcon = configurationDocument.CreateElement("icon");
                        controlBarIcon.AppendChild(configurationDocument.CreateCDataSection(cbar.icon));
                        controlBar.AppendChild(controlBarIcon);

                        if (cbar.useSplitView != null)
                        {
                            XmlNode controlBarUseSplitView = configurationDocument.CreateElement("useSplitView");
                            controlBarUseSplitView.InnerText = cbar.useSplitView;
                            controlBar.AppendChild(controlBarUseSplitView);
                        }

                        XmlNode controlBarEnabled = configurationDocument.CreateElement("enabled");
                        controlBarEnabled.InnerText = capitalizeFirstLetterOfString(cbar.enabled);
                        controlBar.AppendChild(controlBarEnabled);
                        context.AppendChild(controlBar);
                    }

                    node.AppendChild(context);
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void SaveCustomValidationSection(XmlDocument configurationDocument, XmlNode node, webApplicationWebConfigConfiguration core)
    {
        try
        {
            XmlNode appLevelCustomValidationNode = node.SelectSingleNode("application/keywords");
            appLevelCustomValidationNode.RemoveAll();
            foreach (Keyword kw in core.customValidation.application.keywords)
            {
                XmlElement appLevelKeyword = configurationDocument.CreateElement("keyword");
                appLevelKeyword.SetAttribute("id", kw.keywordId);
                appLevelKeyword.SetAttribute("validator", kw.validator);
                appLevelCustomValidationNode.AppendChild(appLevelKeyword);
            }

            XmlNode pages = node.SelectSingleNode("pages");
            foreach (Page p in core.customValidation.pages)
            {
                XmlNode p2 = pages.SelectSingleNode("page[@location='" + p.location + "']");

                p2.Attributes["scriptLocation"].Value = p.scriptLocation;
                XmlNode pageLevelPageKeywords = p2.SelectSingleNode("keywords");
                pageLevelPageKeywords.RemoveAll();

                foreach (Keyword k in p.keywords)
                {
                    XmlElement pageLevelKeyword = configurationDocument.CreateElement("keyword");
                    pageLevelKeyword.SetAttribute("id", k.keywordId);
                    pageLevelKeyword.SetAttribute("validator", k.validator);
                    pageLevelPageKeywords.AppendChild(pageLevelKeyword);
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void SaveKeywordDropdownTypeahead(XmlDocument configurationDocument, XmlNode node, webApplicationWebConfigConfiguration core)
    {
        try
        {
            string kwddta = "";
            foreach (CharacterMinimum cm in core.keywordDropdownTypeAhead.characterMinimums)
            {
                if (kwddta == "")
                {
                    kwddta = cm.KeywordID + ":" + cm.CharacterCount;
                    //Console.WriteLine(kwddta);
                }
                else
                {
                    kwddta += "," + cm.KeywordID + ":" + cm.CharacterCount;
                    //Console.WriteLine(kwddta);
                }
            }

            node.SelectSingleNode("add[@key='KeywordDropdownTypeaheadCharacterMinimum']").Attributes["value"].Value = kwddta;
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void SaveHealthcareWebViewerSourceOriginUrl(XmlDocument configurationDocument, XmlNode node, webApplicationWebConfigConfiguration core)
    {
        try
        {
            XmlNode sourceOrigins = node.SelectSingleNode("epicScanViewerApi/sourceOriginWhitelist");
            sourceOrigins.RemoveAll();
            //<add origin="https://example.com" />
            foreach (SourceOrigin so in core.healthcareWebViewer.Origins)
            {
                XmlElement origin = configurationDocument.CreateElement("add");
                origin.SetAttribute("origin", so.origin);
                sourceOrigins.AppendChild(origin);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void SaveAppSettingsSection(XmlNode section, Key key, XmlDocument xmlDoc)
    {
        try
        {
            bool keyfound = false;

            foreach (XmlNode node in section.ChildNodes)
            {
                if (node.NodeType == XmlNodeType.Comment)
                {
                    //Validates the value inside of the comment is valid XML.
                    if (IsValidXml(node.Value.Trim()))
                    {
                        //Since we know that this is valid XML,
                        //need to set the value and uncomment it.
                        XmlReader commentReader = XmlReader.Create(new StringReader(node.Value.Trim()));
                        XmlNode n = xmlDoc.ReadNode(commentReader);
                        if (n.Attributes["key"].Value == key.AttributeName)
                        {
                            n.Attributes["value"].Value = key.Value;
                            node.ParentNode.ReplaceChild(n, node);
                            keyfound = true;
                            break;
                        }
                    }
                }
                else
                {
                    if (node.Attributes["key"].Value == key.AttributeName)
                    {
                        node.Attributes["value"].Value = key.Value;
                        keyfound = true;
                        break;
                    }
                }
            }

            if (!keyfound)
            {
                XmlElement add = xmlDoc.CreateElement("add");
                add.SetAttribute("key", key.AttributeName);
                add.SetAttribute("value", key.Value);
                section.AppendChild(add);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void SaveSystemWeb(XmlNode section, Key key, XmlDocument xmlDoc)
    {
        try
        {
            XmlNode node = section?.SelectSingleNode(key.PathName);
            //Validates the node exists in the first place
            if (node != null)
            {
                XmlAttribute attr = node?.Attributes?[key.AttributeName];
                if (attr != null)
                {
                    attr.Value = key.Value;
                }
                else
                {
                    //Attribute doesn't exist
                    XmlAttribute attr2 = xmlDoc.CreateAttribute(key.AttributeName);
                    attr2.Value = key.Value;
                    node.Attributes.Append(attr2);
                }
            }
            else
            {
                //Node doesn't exist, need to crete it.
                XmlElement add = xmlDoc.CreateElement(key.PathName);
                add.SetAttribute(key.AttributeName, key.Value);
                section.AppendChild(add);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void SaveSpecificKeys(XmlNode section, Key key, XmlDocument xmlDoc)
    {
        try
        {
            XmlNode node = section?.SelectSingleNode(key.PathName);
            //Validates the node exists in the first place
            if (node != null)
            {
                XmlAttribute attr = node?.Attributes?[key.AttributeName];
                if (attr != null)
                {
                    attr.Value = key.Value;
                }
                else
                {
                    //Attribute doesn't exist
                    XmlAttribute attr2 = xmlDoc.CreateAttribute(key.AttributeName);
                    attr2.Value = key.Value;
                    node.Attributes.Append(attr2);
                }
            }
            else
            {
                //Node doesn't exist, so we also need to verify that it isn't commented out.
                bool nodefound = false;
                foreach (XmlNode node2 in section)
                {
                    if (node2.NodeType == XmlNodeType.Comment)
                    {
                        if (IsValidXml(node2.Value.Trim()))
                        {
                            XmlReader commentReader = XmlReader.Create(new StringReader(node2.Value.Trim()));
                            XmlNode n = xmlDoc.ReadNode(commentReader);

                            if (n.Name == key.PathName)
                            {
                                n.Attributes[key.AttributeName].Value = key.Value;
                                node2.ParentNode.ReplaceChild(n, node2);
                                nodefound = true;
                            }
                        }
                    }
                }

                if (!nodefound)
                {
                    XmlElement add = xmlDoc.CreateElement(key.PathName);
                    add.SetAttribute(key.AttributeName, key.Value);
                    section.AppendChild(add);
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void SaveRequireKeywords(XmlDocument configurationDocument, XmlNode RequiredKeywords, webApplicationWebConfigConfiguration core)
    {
        try
        {
            RequiredKeywords.RemoveAll();

            foreach (RequiredKeywords ReqKWConfig in core.requiredKeywords)
            {
                XmlNode Query = configurationDocument.CreateElement("Query");
                XmlAttribute QID = configurationDocument.CreateAttribute("ID");
                QID.Value = ReqKWConfig.QueryID;
                Query.Attributes.Append(QID);

                XmlNode Keyword = configurationDocument.CreateElement("Keyword");
                XmlAttribute KID = configurationDocument.CreateAttribute("ID");
                KID.Value = ReqKWConfig.KeywordID;
                Keyword.Attributes.Append(KID);
                Query.AppendChild(Keyword);
                RequiredKeywords.AppendChild(Query);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void SaveHylandApplicationsAgendaPubAccessPublicCommentExtraKeys(XmlDocument configurationDocument, XmlNode node, webApplicationWebConfigConfiguration core)
    {
        try
        {
            node.SelectSingleNode("integrations/integration/meeting_types").RemoveAll();
            XmlNode mts = node.SelectSingleNode("integrations/integration/meeting_types");
            foreach (MeetingType mt in core.hylandApplicationsAgendaPubAccessPublicComment.meetingTypes)
            {
                XmlElement ele = configurationDocument.CreateElement("meeting_type");
                ele.SetAttribute("name", mt.Name);
                mts.AppendChild(ele);
            }

            node.SelectSingleNode("integrations/integration/agenda_fields").RemoveAll();
            XmlNode afs = node.SelectSingleNode("integrations/integration/agenda_fields");
            foreach (AgendaField af in core.hylandApplicationsAgendaPubAccessPublicComment.agendaUnityFormFields)
            {
                XmlElement ele1 = configurationDocument.CreateElement("field");
                ele1.SetAttribute("name", af.Name);
                ele1.SetAttribute("form_field_id", af.FormFieldID);
                afs.AppendChild(ele1);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void SaveHylandApplicationsAgendaPubAccessPublicComment(XmlDocument xmlDoc, XmlNode node, webApplicationWebConfigConfiguration ds)
    {
        try
        {
            //Remove all child nodes from the "integrations" node.
            node.SelectSingleNode("integrations").RemoveAll();

            XmlNode initialComment = xmlDoc.CreateComment(@"AvailabilityFromMeetingStart: 
     This value is in hours. It is based on the start time of the meeting.
     This value determines when the Make Comment button is no longer available in the meeting.
     This value can be a whole number, decimal, or negative value (a negative value disables the button by the number of hours specified before the meeting start time).
     The default value is 0, meaning that once the meeting start time passes, the button is disabled.");
            node.SelectSingleNode("integrations").AppendChild(initialComment);

            /*Sample Integration XML for structure.
             
             <integration name="Silly Name" url="[URL from Unity forms config]" token="[Token from Unity forms config]" AvailabilityFromMeetingStart="0">
        <meeting_types>
          <meeting_type name="Test" />
        </meeting_types>
        <agenda_fields>
          <field name="meeting_name" form_field_id="" />
          <field name="meeting_date" form_field_id="" />
          <field name="item_id" form_field_id="" />
          <field name="item_title" form_field_id="" />
        </agenda_fields>
      </integration>*/

            if(ds.publicCommentIntegrations.Count > 0)
            {
                foreach(HylandApplicationsAgendaPubAccessPublicComment h in ds.publicCommentIntegrations)
                {
                    XmlNode integration = xmlDoc.CreateElement("integration");
                    XmlAttribute name = xmlDoc.CreateAttribute("name");
                    name.Value = h.Name;
                    integration.Attributes.Append(name);
                    XmlAttribute url = xmlDoc.CreateAttribute("url");
                    url.Value = h.URL;
                    integration.Attributes.Append(url);
                    XmlAttribute token = xmlDoc.CreateAttribute("token");
                    token.Value = h.Token;
                    integration.Attributes.Append(token);
                    XmlAttribute AvailabilityFromMeetingStart = xmlDoc.CreateAttribute("AvailabilityFromMeetingStart");
                    AvailabilityFromMeetingStart.Value = h.AvailabilityFromMeetingStart;
                    integration.Attributes.Append(AvailabilityFromMeetingStart);

                    XmlNode meeting_types = xmlDoc.CreateElement("meeting_types");
                    foreach(MeetingType mt in h.meetingTypes)
                    {
                        XmlNode meeting_type = xmlDoc.CreateElement("meeting_type");
                        XmlAttribute name1 = xmlDoc.CreateAttribute("name");
                        name1.Value = mt.Name;
                        meeting_type.Attributes.Append(name1);
                        meeting_types.AppendChild(meeting_type);
                    }
                    integration.AppendChild(meeting_types);

                    XmlNode agenda_fields = xmlDoc.CreateElement("agenda_fields");
                    foreach(AgendaField af in h.agendaUnityFormFields)
                    {
                        XmlNode field = xmlDoc.CreateElement("field");
                        XmlAttribute name2 = xmlDoc.CreateAttribute("name");
                        name2.Value = af.Name;
                        field.Attributes.Append(name2);
                        XmlAttribute form_field_id = xmlDoc.CreateAttribute("form_field_id");
                        form_field_id.Value = af.FormFieldID;
                        field.Attributes.Append(form_field_id);
                        agenda_fields.AppendChild(field);
                    }
                    integration.AppendChild(agenda_fields);

                    node.SelectSingleNode("integrations").AppendChild(integration);
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            Log.Logger.Warning("Error processing Hyland.Applications.AgendaPubAccessPublicComment keys.");
        }
    }

    public void SaveCoreAdfsSettings(XmlDocument configurationDocument, XmlNode node, HylandAuthenticationADFS haadfs)
    {
        try
        {
            if (node.SelectSingleNode("Hyland.Authentication/adfs") == null)
            {
                string[,] attributes =
                    {
                    {"enabled", haadfs.ADFSEnabled},
                    {"synchronizeUserAttributes", haadfs.SynchronizeUserAttributes},
                    {"authenticationOnly", haadfs.AuthenticationOnly}
                };
                testCreateSetXmlNodePath(configurationDocument, node.SelectSingleNode("Hyland.Authentication/adfs"), "Hyland.Authentication/adfs", attributes);
            }
            else
            {
                testCreateXmlAttribute(configurationDocument, node.SelectSingleNode("Hyland.Authentication/adfs"), "enabled", haadfs.ADFSEnabled);
                //node.SelectSingleNode("Hyland.Authentication/adfs").Attributes["enabled"].Value = haadfs.ADFSEnabled;
                testCreateXmlAttribute(configurationDocument, node.SelectSingleNode("Hyland.Authentication/adfs"), "synchronizeUserAttributes", haadfs.SynchronizeUserAttributes);
                //node.SelectSingleNode("Hyland.Authentication/adfs").Attributes["synchronizeUserAttributes"].Value = haadfs.SynchronizeUserAttributes;
                testCreateXmlAttribute(configurationDocument, node.SelectSingleNode("Hyland.Authentication/adfs"), "authenticationOnly", haadfs.AuthenticationOnly);
                //node.SelectSingleNode("Hyland.Authentication/adfs").Attributes["authenticationOnly"].Value = haadfs.AuthenticationOnly;
            }

            if (node.SelectSingleNode("system.web/httpRuntime") == null)
            {
                string[,] attributes =
                    {
                    {"requestValidationMode", haadfs.RequestValidationMode}
                };
                testCreateSetXmlNodePath(configurationDocument, node, "system.web/httpRuntime", attributes);
            }
            else
            {
                testCreateXmlAttribute(configurationDocument, node.SelectSingleNode("system.web/httpRuntime"), "requestValidationMode", haadfs.RequestValidationMode);
                //node.SelectSingleNode("system.web/httpRuntime").Attributes["requestValidationMode"].Value = haadfs.RequestValidationMode;
            }

            if (node.SelectSingleNode("system.web/authentication") == null)
            {
                string[,] attributes =
                    {
                    {"mode", haadfs.AuthenticationMode}
                };
                testCreateSetXmlNodePath(configurationDocument, node, "system.web/authentication", attributes);
            }
            else
            {
                testCreateXmlAttribute(configurationDocument, node.SelectSingleNode("system.web/authentication"), "mode", haadfs.AuthenticationMode);
                //node.SelectSingleNode("system.web/authentication").Attributes["mode"].Value = haadfs.AuthenticationMode;
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void SaveSystemIdentityModel(XmlDocument configurationDocument, XmlNode node, webApplicationWebConfigConfiguration core)
    {
        try
        {
            XmlNode n = node.SelectSingleNode("identityConfiguration/securityTokenHandlers/securityTokenHandlerConfiguration");
            n.SelectSingleNode("audienceUris").RemoveAll();
            foreach (AudienceUri auri in core.hylandAuthenticationADFS.systemIdentityModel.audienceUris)
            {
                XmlElement a = configurationDocument.CreateElement("add");
                a.SetAttribute("value", auri.URI);
                n.SelectSingleNode("audienceUris").AppendChild(a);
            }

            n.SelectSingleNode("issuerNameRegistry/trustedIssuers").RemoveAll();
            foreach (TrustedIssuer ti in core.hylandAuthenticationADFS.systemIdentityModel.trustedIssuers)
            {
                XmlElement a1 = configurationDocument.CreateElement("add");
                a1.SetAttribute("thumbprint", ti.Thumbprint);
                a1.SetAttribute("name", ti.Name);
                n.SelectSingleNode("issuerNameRegistry/trustedIssuers").AppendChild(a1);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void SaveSystemIdentityModelServices(XmlDocument configurationDocument, XmlNode node, webApplicationWebConfigConfiguration core)
    {
        try
        {
            XmlNode n = node.SelectSingleNode("federationConfiguration/wsFederation");
            n.Attributes["issuer"].Value = core.hylandAuthenticationADFS.systemIdentityModelServices.wsFederation.Issuer;
            n.Attributes["realm"].Value = core.hylandAuthenticationADFS.systemIdentityModelServices.wsFederation.Realm;
            n = node.SelectSingleNode("federationConfiguration/serviceCertificate/certificateReference");
            n.Attributes["x509FindType"].Value = core.hylandAuthenticationADFS.systemIdentityModelServices.serviceCertificate.X509FindType;
            n.Attributes["findValue"].Value = core.hylandAuthenticationADFS.systemIdentityModelServices.serviceCertificate.FindValue;
            n.Attributes["storeLocation"].Value = core.hylandAuthenticationADFS.systemIdentityModelServices.serviceCertificate.StoreLocation;
            n.Attributes["storeName"].Value = core.hylandAuthenticationADFS.systemIdentityModelServices.serviceCertificate.StoreName;
            string[,] attributes =
                {
                { "requireSsl", core.hylandAuthenticationADFS.systemIdentityModelServices.CookieHandlerRequireSSL }
            };
            testCreateSetXmlNodePath(configurationDocument, node, "federationConfiguration", attributes);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void SaveAdfs(XmlDocument configurationDocument, XmlNode root, webApplicationWebConfigConfiguration core)
    {
        try
        {
            if (Boolean.Parse(core.hylandAuthenticationADFS.ADFSEnabled))
            {
                //Checks if the <system.identityModel> is currently an active element or not.
                if (root.SelectSingleNode("system.identityModel") == null)
                {
                    foreach (XmlNode childNode in root.ChildNodes)
                    {
                        if (childNode.NodeType == XmlNodeType.Comment)
                        {
                            string commentValue = childNode.Value.Trim();
                            if (IsValidXml(commentValue))
                            {
                                XmlReader commentReader = XmlReader.Create(new StringReader(commentValue));
                                XmlNode node = configurationDocument.ReadNode(commentReader);

                                switch (node.Name)
                                {
                                    case "system.identityModel":
                                        SaveSystemIdentityModel(configurationDocument, node, core);
                                        childNode.ParentNode.ReplaceChild(node, childNode);
                                        break;
                                        //case "system.identityModel.services":
                                        //    SaveSystemIdentityModelServices(configurationDocument, root, node,core);
                                        //    childNode.ParentNode.ReplaceChild(node, childNode);
                                        //    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    SaveSystemIdentityModel(configurationDocument, root.SelectSingleNode("system.identityModel"), core);
                }

                if (root.SelectSingleNode("system.identityModel.services") == null)
                {
                    foreach (XmlNode childNode in root.ChildNodes)
                    {
                        if (childNode.NodeType == XmlNodeType.Comment)
                        {
                            string commentValue = childNode.Value.Trim();
                            if (IsValidXml(commentValue))
                            {
                                XmlReader commentReader = XmlReader.Create(new StringReader(commentValue));
                                XmlNode node = configurationDocument.ReadNode(commentReader);

                                switch (node.Name)
                                {
                                    //case "system.identityModel":
                                    //    SaveSystemIdentityModel(configurationDocument, root, node, core);
                                    //    childNode.ParentNode.ReplaceChild(node, childNode);
                                    //    break;
                                    case "system.identityModel.services":
                                        SaveSystemIdentityModelServices(configurationDocument, node, core);
                                        childNode.ParentNode.ReplaceChild(node, childNode);
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    SaveSystemIdentityModelServices(configurationDocument, root.SelectSingleNode("system.identityModel.services"), core);
                }
            }
            else
            {
                //Need to make sure that the system.identityModel and system.identityModel.services nodes are commented out.
                if (root.SelectSingleNode("system.identityModel") == null)
                {
                    //Since the system.identityModel element is null, verifying that it is already commented out and updating values accordingly.
                    foreach (XmlNode childNode in root.ChildNodes)
                    {
                        if (childNode.NodeType == XmlNodeType.Comment)
                        {
                            string commentValue = childNode.Value.Trim();
                            if (IsValidXml(commentValue))
                            {
                                XmlReader commentReader = XmlReader.Create(new StringReader(commentValue));
                                XmlNode node = configurationDocument.ReadNode(commentReader);

                                switch (node.Name)
                                {
                                    case "system.identityModel":
                                        SaveSystemIdentityModel(configurationDocument, node, core);
                                        childNode.Value = node.OuterXml;
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    XmlNode sysidentitymodel = root.SelectSingleNode("system.identityModel");
                    SaveSystemIdentityModel(configurationDocument, sysidentitymodel, core);
                    XmlNode ncomment = configurationDocument.CreateNode(XmlNodeType.Comment, "", null);
                    ncomment.Value = sysidentitymodel.OuterXml;
                    root.ReplaceChild(ncomment, sysidentitymodel);
                }

                if (root.SelectSingleNode("system.identityModel.services") == null)
                {
                    foreach (XmlNode childNode in root.ChildNodes)
                    {
                        if (childNode.NodeType == XmlNodeType.Comment)
                        {
                            string commentValue = childNode.Value.Trim();
                            if (IsValidXml(commentValue))
                            {
                                XmlReader commentReader = XmlReader.Create(new StringReader(commentValue));
                                XmlNode node = configurationDocument.ReadNode(commentReader);

                                switch (node.Name)
                                {
                                    case "system.identityModel.services":
                                        SaveSystemIdentityModelServices(configurationDocument, node, core);
                                        childNode.Value = node.OuterXml;
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    XmlNode sysidentitymodelservices = root.SelectSingleNode("system.identityModel.services");
                    SaveSystemIdentityModelServices(configurationDocument, sysidentitymodelservices, core);
                    XmlNode ncomment = configurationDocument.CreateNode(XmlNodeType.Comment, "", null);
                    ncomment.Value = sysidentitymodelservices.OuterXml;
                    root.ReplaceChild(ncomment, sysidentitymodelservices);
                }
            }

            SaveCoreAdfsSettings(configurationDocument, root, core.hylandAuthenticationADFS);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void createMinMaxErrorLevelElements(XmlDocument configurationDocument, Route routeData, XmlElement routeElement)
    {
        try
        {
            //Creates the element, attributes, and sets the values accordingly for the Minimum Error Level element.
            XmlElement minimumErrorLevelElement = configurationDocument.CreateElement("add");
            minimumErrorLevelElement.SetAttribute("key", "minimum-level");
            minimumErrorLevelElement.SetAttribute("value", getMinMaxErrorLevel(routeData, "Min"));
            routeElement.AppendChild(minimumErrorLevelElement);

            //Creates the element, attributes, and sets the values accordingly for the Maximum Error Level element.
            XmlElement maximumErrorLevelElement = configurationDocument.CreateElement("add");
            maximumErrorLevelElement.SetAttribute("key", "maximum-level");
            maximumErrorLevelElement.SetAttribute("value", getMinMaxErrorLevel(routeData, "Max"));
            routeElement.AppendChild(maximumErrorLevelElement);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void createRouteTypeElementAndSubElements(XmlDocument configurationDocument, Route routeData, XmlElement routeElement)
    {
        try
        {
            XmlElement routeTypeElement = configurationDocument.CreateElement("add");
            switch (routeData.RouteType)
            {
                case "Console":
                    routeTypeElement.SetAttribute("key", "Console");
                    routeElement.AppendChild(routeTypeElement);

                    XmlElement consoleOutputFormat = configurationDocument.CreateElement("add");
                    consoleOutputFormat.SetAttribute("key", "OutputFormat");
                    consoleOutputFormat.SetAttribute("value", routeData.console.OutputFormat);
                    routeElement.AppendChild(consoleOutputFormat);
                    break;
                case "DurableHttp":
                    routeTypeElement.SetAttribute("key", "DurableHttp");
                    routeTypeElement.SetAttribute("value", routeData.durablehttp.URL);
                    routeElement.AppendChild(routeTypeElement);
                    break;
                case "EventLog":
                    routeTypeElement.SetAttribute("key", "EventLog");
                    routeTypeElement.SetAttribute("value", routeData.eventlog.SourceName);
                    routeElement.AppendChild(routeTypeElement);
                    break;
                case "File":
                    routeTypeElement.SetAttribute("key", "File");
                    routeTypeElement.SetAttribute("value", routeData.file.FilePath);
                    routeElement.AppendChild(routeTypeElement);

                    //Creates the element, attributes, and sets the values accordingly for the Output Format element.
                    XmlElement fileOutputFormatElement = configurationDocument.CreateElement("add");
                    fileOutputFormatElement.SetAttribute("key", "OutputFormat");
                    fileOutputFormatElement.SetAttribute("value", routeData.file.OutputFormat);
                    routeElement.AppendChild(fileOutputFormatElement);

                    //Creates the element, attributes, and sets the values accordingly for the File Roll On Size element.
                    XmlElement fileRollOnSizeElement = configurationDocument.CreateElement("add");
                    fileOutputFormatElement.SetAttribute("key", "FileRollOnSize");
                    fileOutputFormatElement.SetAttribute("value", routeData.file.RollWhenLimitReached);
                    routeElement.AppendChild(fileRollOnSizeElement);

                    //Creates the element, attributes, and sets the values accordingly for the File Roll Interval element.
                    XmlElement fileRollIntervalElement = configurationDocument.CreateElement("add");
                    fileOutputFormatElement.SetAttribute("key", "FileRollInterval");
                    fileOutputFormatElement.SetAttribute("value", routeData.file.RollInterval);
                    routeElement.AppendChild(fileRollIntervalElement);

                    //Creates the element, attributes, and sets the values accordingly for the File Roll Interval element.
                    //If the value is "0", then it creates the element still, but as a blank value.
                    XmlElement fileRetainedFilesCountElement = configurationDocument.CreateElement("add");
                    fileOutputFormatElement.SetAttribute("key", "FileCountLimit");
                    fileOutputFormatElement.SetAttribute("value", (routeData.file.RetainedFilesCount == "0") ? "" : routeData.file.RetainedFilesCount);
                    routeElement.AppendChild(fileRetainedFilesCountElement);

                    //Creates the element, attributes, and sets the values accordingly for the File Size Limit element.
                    XmlElement fileSizeLimitElement = configurationDocument.CreateElement("add");
                    fileOutputFormatElement.SetAttribute("key", "FileByteLimit");
                    fileOutputFormatElement.SetAttribute("value", routeData.file.FileSizeLimit);
                    routeElement.AppendChild(fileSizeLimitElement);
                    break;
                case "Http":
                    routeTypeElement.SetAttribute("key", "Http");
                    routeTypeElement.SetAttribute("value", routeData.http.URL);
                    routeElement.AppendChild(routeTypeElement);
                    break;
                case "Splunk":
                    routeTypeElement.SetAttribute("key", "Splunk");
                    routeTypeElement.SetAttribute("value", routeData.splunk.ServerUrl);
                    routeElement.AppendChild(routeTypeElement);

                    //Creates the element, attributes, and sets the values accordingly for the Splunk Token element.
                    XmlElement splunkTokenElement = configurationDocument.CreateElement("add");
                    splunkTokenElement.SetAttribute("key", "SplunkToken");
                    splunkTokenElement.SetAttribute("value", routeData.splunk.SplunkToken);
                    routeElement.AppendChild(splunkTokenElement);

                    //Creates the element, attributes, and sets the values accordingly for the Splunk Index element.
                    XmlElement splunkIndexElement = configurationDocument.CreateElement("add");
                    splunkIndexElement.SetAttribute("key", "SplunkIndex");
                    splunkIndexElement.SetAttribute("value", routeData.splunk.SplunkIndex);
                    routeElement.AppendChild(splunkIndexElement);

                    //Creates the element, attributes, and sets the values accordingly for the Splunk Source element.
                    XmlElement splunkSourceElement = configurationDocument.CreateElement("add");
                    splunkSourceElement.SetAttribute("key", "SplunkSource");
                    splunkSourceElement.SetAttribute("value", routeData.splunk.SplunkSource);
                    routeElement.AppendChild(splunkSourceElement);

                    //Creates the element, attributes, and sets the values accordingly for the Splunk Source Type element.
                    XmlElement splunkSourceTypeElement = configurationDocument.CreateElement("add");
                    splunkSourceTypeElement.SetAttribute("key", "SplunkSourceType");
                    splunkSourceTypeElement.SetAttribute("value", routeData.splunk.SplunkSourceType);
                    routeElement.AppendChild(splunkSourceTypeElement);

                    //Creates the element, attributes, and sets the values accordingly for the Splunk Host element.
                    XmlElement splunkHostElement = configurationDocument.CreateElement("add");
                    splunkHostElement.SetAttribute("key", "SplunkHost");
                    splunkHostElement.SetAttribute("value", routeData.splunk.SplunkHost);
                    routeElement.AppendChild(splunkHostElement);
                    break;
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void createDisableIpAddressMaskingElement(XmlDocument configurationDocument, Route routeData, XmlElement routeElement)
    {
        try
        {
            XmlElement disableIpAddressMaskingElement = configurationDocument.CreateElement("add");
            disableIpAddressMaskingElement.SetAttribute("key", "DisableIPAddressMasking");

            if (bool.Parse(routeData.EnableIpAddressMasking))
            {
                disableIpAddressMaskingElement.SetAttribute("value", "False");
            }
            else
            {
                disableIpAddressMaskingElement.SetAttribute("value", "True");
            }
            routeElement.AppendChild(disableIpAddressMaskingElement);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void createIncludeExcludeNeitherProfiles(XmlDocument configurationDocument, Route routeData, XmlElement routeElement)
    {
        try
        {
            XmlElement includeNode = configurationDocument.CreateElement("add");
            includeNode.SetAttribute("key", "include-profiles");
            XmlElement excludeNode = configurationDocument.CreateElement("add");
            excludeNode.SetAttribute("key", "exclude-profiles");

            string includeProfiles = "";
            string excludeProfiles = "";
            string profilesCombinedList = "";
            List<string> profiles = routeData.filter.Profiles;

            switch (routeData.filter.FilterProfilesIncludeExcludeNeither)
            {
                case "Neither":
                    break;
                case "Include":
                    for (int i = 0; i < profiles.Count; i++)
                    {
                        if (i == 0)
                        {
                            includeProfiles += profiles[i];
                        }
                        else
                        {
                            includeProfiles += "," + profiles[i];
                        }
                    }
                    break;
                case "Exclude":
                    for (int i = 0; i < profiles.Count; i++)
                    {
                        if (i == 0)
                        {
                            excludeProfiles += profiles[i];
                        }
                        else
                        {
                            excludeProfiles += "," + profiles[i];
                        }
                    }
                    break;
            }
            includeNode.SetAttribute("value", includeProfiles);
            excludeNode.SetAttribute("value", excludeProfiles);
            routeElement.AppendChild(includeNode);
            routeElement.AppendChild(excludeNode);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void SaveHylandLoggingDiagnosticsRoutes(XmlDocument configurationDocument, XmlNode HylandLogging, webApplicationWebConfigConfiguration core)
    {
        try
        {
            XmlNode xmlRoutes = HylandLogging.SelectSingleNode("Routes");
            xmlRoutes.RemoveAll();
            XmlNode xmlAuditRoutes = HylandLogging.SelectSingleNode("AuditRoutes");
            xmlAuditRoutes.RemoveAll();

            //Checks and sees if the TruncateLogValues attribute exists or not and performs actions accordingly.
            if (HylandLogging?.Attributes?["TruncateLogValues"] != null)
            {
                //Set the attribute value
                HylandLogging.Attributes["TruncateLogValues"].Value = core.hylandLogging.truncateloggingcharacters;
            }
            else
            {
                //Create & append attribute value
                XmlAttribute tlv = configurationDocument.CreateAttribute("TruncateLogValues");
                tlv.Value = core.hylandLogging.truncateloggingcharacters;
                HylandLogging.Attributes.Append(tlv);
            }

            string sourceName = HylandLogging?.SelectSingleNode("WindowsEventLogging")?.Attributes?["sourcename"]?.Value?.ToString();

            if (sourceName != null)
            {
                HylandLogging.SelectSingleNode("WindowsEventLogging").Attributes["sourcename"].Value = core.hylandLogging.windowsEventLogging.SourceName;
            }
            else
            {
                //Create and append the WindowsEventLogging element.
                XmlElement windowsEventLogging = configurationDocument.CreateElement("WindowsEventLogging");
                windowsEventLogging.SetAttribute("sourcename", core.hylandLogging.windowsEventLogging.SourceName);
                HylandLogging.AppendChild(windowsEventLogging);
            }

            foreach (Route routeData in core.hylandLogging.Routes)
            {
                try
                {
                    XmlElement routeElement = configurationDocument.CreateElement("Route");
                    XmlAttribute routeName = configurationDocument.CreateAttribute("name");
                    routeName.Value = routeData.Name;
                    routeElement.Attributes.Append(routeName);

                    switch (routeData.SourceEvents)
                    {
                        case "Diagnostics Events":
                            createMinMaxErrorLevelElements(configurationDocument, routeData, routeElement);
                            createRouteTypeElementAndSubElements(configurationDocument, routeData, routeElement);
                            createDisableIpAddressMaskingElement(configurationDocument, routeData, routeElement);
                            createIncludeExcludeNeitherProfiles(configurationDocument, routeData, routeElement);
                            xmlRoutes.AppendChild(routeElement);
                            break;
                        case "Audit Events":
                            createMinMaxErrorLevelElements(configurationDocument, routeData, routeElement);
                            createRouteTypeElementAndSubElements(configurationDocument, routeData, routeElement);
                            createDisableIpAddressMaskingElement(configurationDocument, routeData, routeElement);
                            createIncludeExcludeNeitherProfiles(configurationDocument, routeData, routeElement);
                            xmlAuditRoutes.AppendChild(routeElement);
                            break;
                    }
                }
                catch (Exception e)
                {
                    Log.Logger.Error(e.Message);
                    Log.Logger.Error(e.StackTrace);
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void SaveIisConfiguration(webApplicationWebConfigConfiguration core, XmlNode systemweb)
    {
        try
        {
            /* Create the ServerManager object to then be able to get the configuration of the Web Application that is passed in. */
            ServerManager manager = new ServerManager();

            /* Get the configuration of the application being saved. */
            Configuration config = manager.GetWebConfiguration(core.SiteName + core.Path + core.ApplicationName);

            /* Create the application object for management of the Application. */
            Application webApplication = manager.Sites[core.SiteName].Applications[core.Path + core.ApplicationName];

            /* Create the application pool object for management of the Application Pool. */
            ApplicationPool appPool = manager.ApplicationPools[webApplication.ApplicationPoolName];


            /* Set the Application Settings */

            /* Set Default Document value */
            setApplicationIisSetting(config, "system.webServer/defaultDocument", "files", "value", core.IisConfiguration.application.defaultDocument);

            /* Set Anonymous Authentication */
            setApplicationIisSetting(config, "system.webServer/security/authentication/anonymousAuthentication", "enabled", core.IisConfiguration.application.anonymousAuthentication);

            /* Set ASP.NET Impersonation */
            setStandardXmlValue(systemweb, "identity", "impersonate", core.IisConfiguration.application.aspNetImpersonation);

            /* Set Windows Authentication */
            setApplicationIisSetting(config, "system.webServer/security/authentication/windowsAuthentication", "enabled", core.IisConfiguration.application.windowsAuthentication);

            /* Set useAppPoolCredentials */
            setApplicationIisSetting(config, "system.webServer/security/authentication/windowsAuthentication", "useAppPoolCredentials", core.IisConfiguration.application.useAppPoolCredentials);

            /* Set Application Pool name */
            setApplicationAppPoolNameIisSetting(webApplication, core.IisConfiguration.application.applicationPoolName);

            /* Set Pre-Load Enabled */
            setApplicationIisSetting(webApplication, "preloadEnabled", core.IisConfiguration.application.preLoadEnabled);


            /* Set the Application Pool Settings */

            /* Set General - .NET Clr Version */
            setApplicationPoolIisSetting(appPool, "General", ".NET Clr Version", core.IisConfiguration.applicationPool.generalNetClrVerson);

            /* Set General - Enabled 32-Bit Applications */
            setApplicationPoolIisSetting(appPool, "General", "Enabled 32-Bit Applications", core.IisConfiguration.applicationPool.generalEnable32BitApplications);

            /* Set General - Managed Pipeline Mode */
            setApplicationPoolIisSetting(appPool, "General", "Managed Pipeline Mode", core.IisConfiguration.applicationPool.generalManagedPilelineMode);

            /* Set General - Queue Length */
            setApplicationPoolIisSetting(appPool, "General", "Queue Length", core.IisConfiguration.applicationPool.generalQueueLength);

            /* Set General - Start Mode */
            setApplicationPoolIisSetting(appPool, "General", "Start Mode", core.IisConfiguration.applicationPool.generalStartMode);

            /* Set CPU - Limit Interval */
            setApplicationPoolIisSetting(appPool, "CPU", "Limit Interval", core.IisConfiguration.applicationPool.cpuLimitInterval);

            /* Set Process Model - Identity Type, Set Process Model - Identity Username, Set Process Model - Identity Password */
            setApplicationPoolIisSetting(appPool, "Process Model", "Identity Type", core.IisConfiguration.applicationPool.processModelIdentityType, core.IisConfiguration.applicationPool.processModelIdentityUsername, core.IisConfiguration.applicationPool.processModelIdentityPassword);

            /* Set Process Model - Idle Timeout */
            setApplicationPoolIisSetting(appPool, "Process Model", "Idle Timeout", core.IisConfiguration.applicationPool.processModelIdleTimeOut, null, null);

            /* Set Process Model - Ping Enabled */
            setApplicationPoolIisSetting(appPool, "Process Model", "Ping Enabled", core.IisConfiguration.applicationPool.processModelPingEnabled, null, null);

            /* Set Rapid-Failover Protection - Enabled */
            setApplicationPoolIisSetting(appPool, "Rapid-Failover Protection", "Enabled", core.IisConfiguration.applicationPool.rapidFailProtectionEnabled, null, null);

            /* Set Recycling - Regular Time Interval */
            setApplicationPoolIisSetting(appPool, "Recycling", "Regular Time Interval", core.IisConfiguration.applicationPool.recyclingRegularTimeInterval, null, null);

            /* Committing the changes made */
            manager.CommitChanges();
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void SaveArrayItems(string section, XmlNode node, webApplicationWebConfigConfiguration webConfigConfiguration, XmlDocument configDoc)
    {
        try
        {
            switch (section)
            {
                case "ResponsiveAppsApps":
                    SaveResponsiveAppsApps(node, webConfigConfiguration.hylandResponsiveApps.responsiveApps, configDoc);
                    break;
                case "DiskGroupAliases":
                    SaveDiskGroupAliases(node, webConfigConfiguration.hylandPlatterManagement.diskGroupAliases, configDoc);
                    break;
                case "Parameters":
                    try
                    {
                        SaveHylandServicesParamters(node, webConfigConfiguration.hylandServicesParameters.parameters, configDoc);
                    }
                    catch (Exception e)
                    {
                        Log.Logger.Error(e.Message);
                        Log.Logger.Error(e.StackTrace);
                    }
                    break;
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void SaveResponsiveAppsApps(XmlNode node, List<ResponsiveApp> responsiveApps, XmlDocument configDoc)
    {
        try
        {
            node.SelectSingleNode("Apps").RemoveAll();
            foreach (ResponsiveApp ra in responsiveApps)
            {
                XmlElement ele = configDoc.CreateElement("App");
                ele.SetAttribute("name", ra.Name);
                ele.SetAttribute("icon", ra.IconURL);
                ele.SetAttribute("url", ra.URL);
                node.SelectSingleNode("Apps").AppendChild(ele);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void SaveDiskGroupAliases(XmlNode node, List<DiskGroupAlias> diskGroupAliases, XmlDocument configDoc)
    {
        try
        {
            node.SelectSingleNode("DiskgroupAlias").RemoveAll();
            foreach (DiskGroupAlias dga in diskGroupAliases)
            {
                XmlElement ele = configDoc.CreateElement("Alias");
                ele.SetAttribute("oldname", dga.oldname);
                ele.SetAttribute("newname", dga.newname);
                ele.SetAttribute("type", dga.type);
                node.SelectSingleNode("DiskgroupAlias").AppendChild(ele);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void SaveHylandServicesParamters(XmlNode node, List<Parameter> parameters, XmlDocument configDoc)
    {
        try
        {
            node.SelectSingleNode("parameters").RemoveAll();
            foreach (Parameter p in parameters)
            {
                XmlElement ele = configDoc.CreateElement("parameter");
                ele.SetAttribute("oldname", p.name);
                ele.SetAttribute("newname", p.value);
                node.SelectSingleNode("parameters").AppendChild(ele);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void createWebApplicationTranslatorToReturn(NETCoreToNetFrameworkTranslator translatortoreturn, string type, webApplicationWebConfigConfiguration core)
    {
        switch (type)
        {
            case "Application Server":
                createApplicationServerTranslatorToReturn(translatortoreturn, core);
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
            case "Public Access - Legacy":
                break;
            case "Public Access - Next Gen":
                break;
            case "Reporting Viewer":
                break;
            case "Web Server":
                break;
        }
    }

    public void createWebApplicationTranslatorToReturnV2(NETCoreToNetFrameworkTranslator translatortoreturn, webApplicationWebConfigConfiguration core)
    {
        try
        {
            foreach (Key keys in core.translatorKnownKeys)
            {
                COMACONTranslationToHelperUtility.Key keys1 = new COMACONTranslationToHelperUtility.Key();
                keys1.Section = keys.Section;
                keys1.PathName = keys.PathName;
                keys1.AttributeName = keys.AttributeName;
                keys1.Type = keys.type;
                keys1.HtmlIdName = keys.htmlIdName;
                keys1.Value = keys.Value;
                keys1.Version = keys.Version;
                translatortoreturn.knownKeys.Add(keys1);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }

        if(core.Type == "Application Server")
        {
            COMACONTranslationToHelperUtility.ConnectionStrings cstrings = new COMACONTranslationToHelperUtility.ConnectionStrings();
            foreach(ConnectionString cstring in core.connectionStrings.connectionStrings)
            {
                COMACONTranslationToHelperUtility.ConnectionStringV2 cstring1 = new COMACONTranslationToHelperUtility.ConnectionStringV2();
                cstring1.Name = cstring.Name;
                cstring1.Provider = cstring.Provider;
                cstring1.IntegratedSecurity = cstring.IntegratedSecurity;
                cstring1.UserId = cstring.UserId;
                cstring1.Password = cstring.Password;
                cstring1.AdditionalOptions = cstring.AdditionalOptions;
                cstring1.sql.DataSource = cstring.sql.DataSource;
                cstring1.sql.Database = cstring.sql.Database;
                cstring1.oracle.TNSConnectionString = cstring.oracle.TNSConnectionString;
                cstring1.oracle.Host = cstring.oracle.Host;
                cstring1.oracle.Database = cstring.oracle.Database;
                cstring1.oracle.Protocol = cstring.oracle.Protocol;
                cstring1.oracle.Port = cstring.oracle.Port;
                cstrings.connectionStrings.Add(cstring1);
            }
            cstrings.EncryptConnectionStrings = core.connectionStrings.EncryptConnectionStrings;
            translatortoreturn.connectionStrings = cstrings;
        }
    }

    private void createApplicationServerTranslatorToReturn(NETCoreToNetFrameworkTranslator translatortoreturn, webApplicationWebConfigConfiguration core)
    {
        //try
        //{
        //    foreach (Key keys in core.knownKeys)
        //    {
        //        if (keys.Section == "Hyland.Web.AppServerPop")
        //        {
        //            switch (keys.PathName)
        //            {
        //                case "EnableChecksum":
        //                    translatortoreturn.ApplicationServer.AppServerPopIntegration.EnableCheckSum = keys.Value;
        //                    break;
        //                case "ChecksumKey":
        //                    translatortoreturn.ApplicationServer.AppServerPopIntegration.ChecksumKey = keys.Value;
        //                    break;
        //                case "EnableLegacyChecksumCreation":
        //                    translatortoreturn.ApplicationServer.AppServerPopIntegration.EnableLegacyChecksumCreation = keys.Value;
        //                    break;
        //                case "IsEncrypted":
        //                    translatortoreturn.ApplicationServer.AppServerPopIntegration.IsEncrypted = keys.Value;
        //                    break;
        //            }
        //        }
        //        else if (keys.Section == "Hyland.Applications.Portals.ExternalAccess")
        //        {
        //            switch (keys.PathName)
        //            {
        //                case "username":
        //                    translatortoreturn.ApplicationServer.ApplicationServerExernalAccess.Username = keys.Value;
        //                    break;
        //                case "password":
        //                    translatortoreturn.ApplicationServer.ApplicationServerExernalAccess.Password = keys.Value;
        //                    break;
        //                case "minPoolSize":
        //                    translatortoreturn.ApplicationServer.ApplicationServerExernalAccess.MinPoolSize = keys.Value;
        //                    break;
        //                case "maxPoolSize":
        //                    translatortoreturn.ApplicationServer.ApplicationServerExernalAccess.MaxPoolSize = keys.Value;
        //                    break;
        //                case "IsEncrypted":
        //                    translatortoreturn.ApplicationServer.ApplicationServerExernalAccess.IsEncrypted = keys.Value;
        //                    break;
        //            }
        //        }
        //        else if (keys.Section == "Hyland.ContentComposer.Core")
        //        {
        //            switch (keys.PathName)
        //            {
        //                case "ClientId":
        //                    translatortoreturn.ApplicationServer.ApplicationServerContentComposer.ClientID = keys.Value;
        //                    break;
        //                case "ClientSecret":
        //                    translatortoreturn.ApplicationServer.ApplicationServerContentComposer.ClientSecret = keys.Value;
        //                    break;
        //                case "Username":
        //                    translatortoreturn.ApplicationServer.ApplicationServerContentComposer.Username = keys.Value;
        //                    break;
        //                case "Password":
        //                    translatortoreturn.ApplicationServer.ApplicationServerContentComposer.Password = keys.Value;
        //                    break;
        //                case "IsEncrypted":
        //                    translatortoreturn.ApplicationServer.ApplicationServerContentComposer.IsEncrypted = keys.Value;
        //                    break;
        //            }
        //        }
        //        else if (keys.Section == "Hyland.Core.Media.HostedApplicationServer")
        //        {
        //            switch (keys.PathName)
        //            {
        //                case "url":
        //                    translatortoreturn.ApplicationServer.ApplicationServerMedia.URL = keys.Value;
        //                    break;
        //                case "datasource":
        //                    translatortoreturn.ApplicationServer.ApplicationServerMedia.Datasource = keys.Value; ;
        //                    break;
        //                case "username":
        //                    translatortoreturn.ApplicationServer.ApplicationServerMedia.Username = keys.Value;
        //                    break;
        //                case "password":
        //                    translatortoreturn.ApplicationServer.ApplicationServerMedia.Password = keys.Value; ;
        //                    break;
        //                case "IsEncrypted":
        //                    translatortoreturn.ApplicationServer.ApplicationServerMedia.IsEncrypted = keys.Value; ;
        //                    break;
        //            }
        //        }
        //    }

        //    foreach (ConnectionString cstring in core.connectionStrings.connectionStrings)
        //    {
        //        COMACONTranslationToHelperUtility.ConnectionString cstring1 = new COMACONTranslationToHelperUtility.ConnectionString();
        //        cstring1.Name = cstring.Name;
        //        cstring1.ProviderName = cstring.Provider;
        //        cstring1.IntegratedSecurity = cstring.IntegratedSecurity;
        //        cstring1.UserID = cstring.UserId;
        //        cstring1.Password = cstring.Password;
        //        cstring1.AdditionalParameters = cstring.AdditionalOptions;
        //        switch (cstring.Provider)
        //        {
        //            case "System.Data.SqlClient":
        //                cstring1.DataSource = cstring.sql.DataSource;
        //                cstring1.Database = cstring.sql.Database;
        //                break;
        //            case "Oracle.ManagedDataAccess.Client":
        //                cstring1.TnsConnectionString = cstring.oracle.TNSConnectionString;
        //                cstring1.OracleHost = cstring.oracle.Host;
        //                cstring1.Database = cstring.oracle.Database;
        //                cstring1.OracleProtocol = cstring.oracle.Protocol;
        //                cstring1.OraclePort = cstring.oracle.Port;
        //                break;
        //        }
        //        translatortoreturn.ApplicationServer.AppServerConnectionStrings.ConnectionStrings.Add(cstring1);
        //    }
        //}
        //catch (Exception e)
        //{
        //    Log.Logger.Error(e.Message);
        //    Log.Logger.Error(e.StackTrace);
        //}
    }



    /********************************************************
     *                   Other Functions
     ********************************************************/
    private Key FindKey(List<Key> knownKeys, string section, string pathName, string attributeName)
    {
        try
        {
#pragma warning disable CS8603 // Possible null reference return.
            return knownKeys.FirstOrDefault(key =>
                key.Section == section &&
                key.PathName == pathName &&
                key.AttributeName == attributeName
            );
#pragma warning restore CS8603 // Possible null reference return.
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
            Log.Logger.Error("Error in FindKey looking for the {0} section, {1} path name, and {2} attribute name.", section, pathName, attributeName);
            return null;
        }
    }

//    private Key FindAppSettingsKey(List<Key> knownKeys, string section, string pathName, XmlNode appSettingsNode)
//    {
//        try
//        {
//            string attributeName = appSettingsNode.Attributes["key"].Value;

//#pragma warning disable CS8603 // Possible null reference return.
//            return knownKeys.FirstOrDefault(key =>
//                key.Section == section &&
//                key.PathName == pathName &&
//                key.AttributeName == attributeName
//            );
//#pragma warning restore CS8603 // Possible null reference return.
//        }
//        catch (Exception e)
//        {
//            Log.Logger.Error(e.Message);
//            Log.Logger.Error(e.StackTrace);
//            return null;
//        }
//    }

    public void testCreateSetXmlNodePath(XmlDocument configurationDocument, XmlNode rootNode, string path, string[,]? attributes)
    {
        try
        {
            string[] pathSegments = path.Split('/');
            XmlNode currentNode = rootNode;
            bool brokenPath = false;

            for (int i = 0; i < pathSegments.Length; i++)
            {
                XmlNode nextNode = currentNode?.SelectSingleNode(pathSegments[i]);

                if (nextNode == null)
                {
                    createXmlElement(configurationDocument, currentNode, pathSegments[i], attributes);
                    brokenPath = true;
                }

                currentNode = nextNode;
            }

            if (!brokenPath)
            {
                for (int i = 0; i < attributes.GetLength(0); i++)
                {
                    testCreateXmlAttribute(configurationDocument, currentNode, attributes[i, 0], attributes[i, 1]);
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void createXmlElement(XmlDocument configurationDocument, XmlNode parentNode, string elementName, string[,] attributes)
    {
        try
        {
            XmlElement node = configurationDocument.CreateElement(elementName);
            if (attributes.GetLength(0) > 0)
            {
                for (int i = 0; i < attributes.GetLength(0); i++)
                {
                    node.SetAttribute(attributes[i, 0], attributes[i, 1]);
                }
            }

            parentNode.AppendChild(node);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void testCreateXmlAttribute(XmlDocument configurationDocument, XmlNode node, string attributeName, string attributeValue)
    {
        try
        {
            if (node?.Attributes?[attributeName]?.Value == null)
            {
                createXmlAttribute(configurationDocument, node, attributeName, attributeValue);
            }
            else
            {
                node.Attributes[attributeName].Value = attributeValue;
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void createXmlAttribute(XmlDocument configurationDocument, XmlNode node, string attributeName, string attributeValue)
    {
        try
        {
            XmlAttribute attr = configurationDocument.CreateAttribute(attributeName);
            attr.Value = attributeValue;
            node.Attributes.Append(attr);
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public bool IsValidXml(string xmlString)
    {
        try
        {
            // Attempt to parse the string as XML
            XElement.Parse(xmlString);
            return true;
        }
        catch (XmlException e)
        {
            // Parsing failed, so it's not valid XML
            Log.Logger.Information("The string is not valid XML: " + xmlString);
            return false;
        }
    }

    public void ParseTranslator(webApplicationWebConfigConfiguration ds, NETCoreToNetFrameworkTranslator translator)
    {
        foreach(COMACONTranslationToHelperUtility.Key key in translator.knownKeys)
        {
            Key newKey = new Key();
            newKey.Section = key.Section;
            newKey.PathName = key.PathName;
            newKey.AttributeName = key.AttributeName;
            newKey.type = key.Type;
            newKey.htmlIdName = key.HtmlIdName;
            newKey.Value = key.Value;
            newKey.Version = key.Version;
            newKey.minimumValue = key.minimumValue;
            newKey.maximumValue = key.maximumValue;
            ds.translatorKnownKeys.Add(newKey);
        }

        if(ds.Type == "Application Server")
        {
            //Parse the connection strings.
            try
            {
                /********************************************************
                 *                  Connection Strings
                 ********************************************************/
                //! Will pull all of this from the translator object due to potential encryption.
                ConnectionStrings connectionStrings = new ConnectionStrings();
                ds.connectionStrings = connectionStrings;
                if (translator.connectionStrings.connectionStrings.Count > 0)
                {
                    //Need to parse the connection strings in the translator.connectionStrings.connectionStrings list.
                    foreach (COMACONTranslationToHelperUtility.ConnectionStringV2 cstring in translator.connectionStrings.connectionStrings)
                    {
                        ConnectionString cstring1 = new ConnectionString();
                        cstring1.Name = cstring.Name;
                        cstring1.Provider = cstring.Provider;
                        cstring1.IntegratedSecurity = cstring.IntegratedSecurity;
                        cstring1.UserId = cstring.UserId;
                        cstring1.Password = cstring.Password;
                        cstring1.AdditionalOptions = cstring.AdditionalOptions;
                        cstring1.sql.DataSource = cstring.sql.DataSource;
                        cstring1.sql.Database = cstring.sql.Database;
                        cstring1.oracle.TNSConnectionString = cstring.oracle.TNSConnectionString;
                        cstring1.oracle.Host = cstring.oracle.Host;
                        cstring1.oracle.Database = cstring.oracle.Database;
                        cstring1.oracle.Protocol = cstring.oracle.Protocol;
                        cstring1.oracle.Port = cstring.oracle.Port;
                        
                        ds.connectionStrings.connectionStrings.Add(cstring1);
                    }
                    connectionStrings.EncryptConnectionStrings = translator.connectionStrings.EncryptConnectionStrings;
                }
            }
            catch (Exception e)
            {
                Log.Logger.Error(e.Message);
                Log.Logger.Error(e.StackTrace);
            }
        }
    }

    public void PrebuildKnownKeys(string[,] translator, webApplicationWebConfigConfiguration ds)
    {
        try
        {
            for (int i = 0; i < translator.GetLength(0); i++)
            {
                Key key = new Key();
                key.Section = translator[i, 0];
                key.PathName = translator[i, 1];
                key.AttributeName = translator[i, 2];
                key.type = translator[i, 3];
                key.htmlIdName = translator[i, 4];
                key.Value = translator[i, 5];
                key.Version = translator[i, 6];
                key.minimumValue = translator[i, 7];
                key.maximumValue = translator[i, 8];
                ds.knownKeys.Add(key);
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error("Error: {0}", e.Message);
            Log.Logger.Error("Error: {0}", e.StackTrace);
            Log.Logger.Error("Web Application Type: {0}", ds.Type);
            Log.Logger.Error("Web Application Version: {0}", ds.Version);
            Log.Logger.Error("Pre-build known keys translator: {0}", JsonConvert.SerializeObject(translator));
            ds.AddCriticalError("Error pre-building the known keys. See the log file for more details.");
        }
    }

    public void processOptimizeForWindowsAuthSelection(List<string> optionsSelected, string siteName, string applicationPath, string applicationName, string applicationType)
    {
        try
        {
            if (optionsSelected.Count == 0)
            {
                optionsSelected.Add("None");
            }

            //Variables
            string[] webServerLoginPages = new string[]
            {
                "AuthService.asmx", "AuthOptServicePipeline.ashx", "Login.aspx", "AccLogin.aspx", "AccSSOLoginPage.aspx", "DKTReader.aspx", "UnityForm.aspx", "Diagnostics/Diagnostics.aspx", "RecoverAppServerSession.aspx", "DocPop/Correction.aspx",
                "DocPop/DocPop.aspx", "DocPop/DocPopURLCreator.aspx", "DocPop/FormPop.aspx", "DocPop/PDFPop.aspx", "DocPop/ReindexPop.aspx", "DocPop/SAPDocPop.aspx", "FolderPop/FolderPop.aspx", "FolderPop/FolderPopURLCreator.aspx", "Workflow/WFLogin.aspx", "WorkView/FilterPop.aspx",
                "WorkView/FilterPopURLCreator.aspx", "WorkView/ObjectPop.aspx", "WorkView/WVLogin.aspx", "SharePointPortal.aspx"
            };
            string[] applicationServerLoginPages = new string[]
            {
                "AuthService.asmx", "AuthOptServicePipeline.ashx"
            };
            string[] reportingViewerLoginPages = new string[]
            {
                "Viewer.aspx"
            };

            ServerManager managerForOptimization = new ServerManager();
            Configuration config = managerForOptimization.GetWebConfiguration(siteName + applicationPath + applicationName + "/");

            switch (applicationType)
            {
                case "Web Server":
                    foreach (string s in optionsSelected)
                    {
                        switch (s)
                        {
                            case "None":
                                revertAllLocationAuthorizationRules(webServerLoginPages, siteName, applicationPath, applicationName, true);
                                revertAllLocationAuthorizationRules(applicationServerLoginPages, siteName, applicationPath, applicationName, true);
                                break;
                            case "WebClient":
                            case "DocPop":
                            case "PdfPop":
                            case "FormPop":
                            case "FolderPop":
                                //Add system.web/authorization deny ? elements.
                                addSystemWebAuthorizationRule(webServerLoginPages, managerForOptimization, config);
                                addSystemWebAuthorizationRule(applicationServerLoginPages, managerForOptimization, config);
                                addSystemWebServerSecurityAuthorizationRule(webServerLoginPages, managerForOptimization, config);
                                addSystemWebServerSecurityAuthorizationRule(applicationServerLoginPages, managerForOptimization, config);

                                //Set impersonation to true.
                                setImpersonationAuthentication(webServerLoginPages, config, true);
                                setImpersonationAuthentication(applicationServerLoginPages, config, true);
                                break;
                        }
                    }
                    break;
                case "Application Server":
                    foreach (string s in optionsSelected)
                    {
                        switch (s)
                        {
                            case "None":
                                revertAllLocationAuthorizationRules(applicationServerLoginPages, siteName, applicationPath, applicationName, true);
                                break;
                            case "ApplicationServer":
                                //Add system.web/authorization deny ? elements.
                                addSystemWebAuthorizationRule(applicationServerLoginPages, managerForOptimization, config);
                                addSystemWebServerSecurityAuthorizationRule(applicationServerLoginPages, managerForOptimization, config);

                                //Set impersonation to true.
                                setImpersonationAuthentication(applicationServerLoginPages, config, true);
                                break;
                        }
                    }
                    break;
                case "Reporting Viewer":
                    foreach (string s in optionsSelected)
                    {
                        switch (s)
                        {
                            case "None":
                                revertAllLocationAuthorizationRules(reportingViewerLoginPages, siteName, applicationPath, applicationName, true);
                                break;
                            case "ReportingViewer":
                                //Add system.web/authorization deny ? elements.
                                addSystemWebAuthorizationRule(reportingViewerLoginPages, managerForOptimization, config);
                                addSystemWebServerSecurityAuthorizationRule(reportingViewerLoginPages, managerForOptimization, config);

                                //Set impersonation to true.
                                setImpersonationAuthentication(reportingViewerLoginPages, config, true);
                                break;
                        }
                    }
                    break;
            }
            managerForOptimization.CommitChanges();
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void setUseAppPoolCredentials(bool value, Configuration config)
    {
        //Console.WriteLine($"Setting the UseAppPoolCredentials value to {value}");
        config.GetSection(@"system.webServer/security/authentication/windowsAuthentication").SetAttributeValue("useAppPoolCredentials", value);
        //Console.WriteLine("Use App Pool Credentials: " + config.GetSection(@"system.webServer/security/authentication/windowsAuthentication").GetAttributeValue("useAppPoolCredentials"));
    }

    private void setAnonymousAuthentication(bool value, Configuration config)
    {
        //Console.WriteLine($"Setting the Anonymous Authentication value to {value}");
        config.GetSection(@"system.webServer/security/authentication/anonymousAuthentication").SetAttributeValue("enabled", value);
        //Console.WriteLine("Anonymous Authentication: " + config.GetSection(@"system.webServer/security/authentication/anonymousAuthentication").GetAttributeValue("enabled"));
    }

    private void setWindowsAuthentication(bool value, Configuration config)
    {
        //Console.WriteLine($"Setting the Windows Authentication value to {value}");
        config.GetSection(@"system.webServer/security/authentication/windowsAuthentication").SetAttributeValue("enabled", value);
        //Console.WriteLine("Windows Authentication: " + config.GetSection(@"system.webServer/security/authentication/windowsAuthentication").GetAttributeValue("enabled"));
    }

    private void revertAllLocationAuthorizationRules(string[] PagesToProcess, string SiteName, string ApplicationPath, string ApplicationName, bool revertImpersonation = false)
    {
        try
        {
            using (ServerManager serverManager = new ServerManager())
            {
                Site defaultSite = serverManager.Sites[SiteName];

                if (defaultSite != null)
                {
                    Microsoft.Web.Administration.Application appNetApp = defaultSite.Applications[ApplicationPath + ApplicationName];

                    if (appNetApp != null)
                    {
                        Configuration config = serverManager.GetWebConfiguration(SiteName + ApplicationPath + ApplicationName);

                        foreach (string page in PagesToProcess)
                        {
                            Microsoft.Web.Administration.ConfigurationSection SystemWebServerSecurityAuthorizationSection = config.GetSection("system.webServer/security/authorization", page);
                            SystemWebServerSecurityAuthorizationSection.RevertToParent();
                            Microsoft.Web.Administration.ConfigurationSection SystemWebAuthorizationSection = config.GetSection("system.web/authorization", page);
                            SystemWebAuthorizationSection.RevertToParent();
                            if (revertImpersonation)
                            {
                                Microsoft.Web.Administration.ConfigurationSection SystemWebIdentityAuthorizationSection = config.GetSection("system.web/identity", page);
                                SystemWebIdentityAuthorizationSection.RevertToParent();
                            }
                        }
                        serverManager.CommitChanges();
                    }
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void addSystemWebAuthorizationRule(string[] PagesToProcess, ServerManager manager, Configuration config, string section = "system.web/authorization", string elementName = "deny", string attributeName = "users", string attributeValue = "?")
    {
        try
        {
            foreach (string page in PagesToProcess)
            {
                Microsoft.Web.Administration.ConfigurationSection authorizationSection = config.GetSection(section, page);
                ConfigurationElementCollection authorizationRules = authorizationSection.GetCollection();

                bool ruleExists = false;

                foreach (ConfigurationElement existingRule in authorizationRules)
                {
                    if (existingRule.Attributes[attributeName].Value.ToString() == attributeValue)
                    {
                        ruleExists = true;
                        break;
                    }
                }

                if (!ruleExists)
                {
                    ConfigurationElement rule = authorizationRules.CreateElement(elementName);
                    rule[attributeName] = attributeValue;
                    authorizationRules.Add(rule);
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void addSystemWebServerSecurityAuthorizationRule(string[] PagesToProcess, ServerManager manager, Configuration config, string section = "system.webServer/security/authorization", string elementName = "add", string attributeName = "accessType", string attributeValue = "Deny", string attributeName2 = "users", string attributeValue2 = "?")
    {
        try
        {
            foreach (string page in PagesToProcess)
            {
                //Console.WriteLine(page);
                Microsoft.Web.Administration.ConfigurationSection authorizationSection = config.GetSection(section, page);
                ConfigurationElementCollection authorizationRules = authorizationSection.GetCollection();

                bool ruleExists = false;

                //Need to chek if the current set of authorizationRules contains the rule that is being added.
                if(authorizationRules.Count > 0)
                {
                    foreach (ConfigurationElement existingRule in authorizationRules)
                    {
                        //Console.WriteLine(existingRule.Attributes[attributeName2].Value.ToString());
                        if (existingRule.Attributes[attributeName2].Value.ToString() == attributeValue2)
                        {
                            //Console.WriteLine("Rule exists!");
                            ruleExists = true;
                        }
                    }
                }

                if (!ruleExists)
                {
                    ConfigurationElement rule = authorizationRules.CreateElement(elementName);
                    rule[attributeName] = attributeValue;
                    rule[attributeName2] = attributeValue2;
                    authorizationRules.Add(rule);
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    private void setImpersonationAuthentication(string[] PagesToProcess, Configuration config, bool impersonateValue = false, string section = "system.web/identity")
    {
        try
        {
            foreach (string page in PagesToProcess)
            {
                Microsoft.Web.Administration.ConfigurationSection identitySection = config.GetSection(section, page);
                if (identitySection.Attributes["impersonate"].Value != impersonateValue.ToString())
                {
                    identitySection["impersonate"] = impersonateValue;
                }
            }
        }
        catch (Exception e)
        {
            Log.Logger.Error(e.Message);
            Log.Logger.Error(e.StackTrace);
        }
    }

    public void CreateOptimizeWindowsAuthenticationForArray(Configuration config, WebApplicationDataStructures webApplicationDataStructures, XmlDocument xmlDoc, webApplicationWebConfigConfiguration webconfigconfig, string webApplicationType, NETCoreToNetFrameworkTranslator translator, XmlNode appSettings)
    {
        bool windowsAuthentication = Convert.ToBoolean(config.GetSection(@"system.webServer/security/authentication/windowsAuthentication").GetAttributeValue("enabled")) ? true : false;
        bool anonymousAuthentication = Convert.ToBoolean(config.GetSection(@"system.webServer/security/authentication/anonymousAuthentication").GetAttributeValue("enabled")) ? true : false;
        bool kernelMode = Convert.ToBoolean(config.GetSection(@"system.webServer/security/authentication/windowsAuthentication").GetAttributeValue("useKernelMode")) ? true : false;
        bool appPoolCredentials = Convert.ToBoolean(config.GetSection(@"system.webServer/security/authentication/windowsAuthentication").GetAttributeValue("useAppPoolCredentials")) ? true : false;
        bool flag2 = true;
        foreach (string text in webApplicationDataStructures.getWebApplicationLoginPages(webApplicationType, "211"))
        {
            XmlNode xmlNode = xmlDoc.DocumentElement.SelectSingleNode("location[@path='" + text + "']");
            if (xmlNode != null)
            {
                XmlNode xmlNode2 = xmlNode.SelectSingleNode("system.webServer/security/authorization/add[@accessType='Deny'][@users='?']");
                if (xmlNode2 == null)
                {
                    flag2 = false;
                    break;
                }
                continue;
            }
            flag2 = false;
            break;
        }

        switch (webApplicationType)
        {
            case "Application Server":
                //Check each set of booleans. If they are all true, then Windows Auth is optimized for that specific item.
                if (windowsAuthentication && anonymousAuthentication && kernelMode && appPoolCredentials && flag2)
                {
                    webconfigconfig.WindowsAuthOptimizeFor.Add("ApplicationServer");
                }
                break;
            case "Web Server":
                if (windowsAuthentication && anonymousAuthentication && kernelMode && appPoolCredentials && flag2 && Convert.ToBoolean(getNonStandardXmlValue(appSettings, "EnableAutoLogin", "")))
                {
                    webconfigconfig.WindowsAuthOptimizeFor.Add("WebClient");
                }
                foreach (COMACONTranslationToHelperUtility.Key key in translator.knownKeys)
                {
                    switch (key.Section)
                    {
                        case "Hyland.Web.DocPop":
                            if (windowsAuthentication && anonymousAuthentication && kernelMode && appPoolCredentials && flag2 && key.PathName == "enableAutoLogin" && Convert.ToBoolean(key.Value))
                            {
                                webconfigconfig.WindowsAuthOptimizeFor.Add("DocPop");
                            }
                            break;
                        case "Hyland.Web.PdfPop":
                            if (windowsAuthentication && anonymousAuthentication && kernelMode && appPoolCredentials && flag2 && key.PathName == "enableAutoLogin" && Convert.ToBoolean(key.Value))
                            {
                                webconfigconfig.WindowsAuthOptimizeFor.Add("PdfPop");
                            }
                            break;
                        case "Hyland.Web.FormPop":
                            if (windowsAuthentication && anonymousAuthentication && kernelMode && appPoolCredentials && flag2 && key.PathName == "enableAutoLogin" && Convert.ToBoolean(key.Value))
                            {
                                webconfigconfig.WindowsAuthOptimizeFor.Add("FormPop");
                            }
                            break;
                        case "Hyland.Web.FolderPop":
                            if (windowsAuthentication && anonymousAuthentication && kernelMode && appPoolCredentials && flag2 && key.PathName == "enableAutoLogin" && Convert.ToBoolean(key.Value))
                            {
                                webconfigconfig.WindowsAuthOptimizeFor.Add("FolderPop");
                            }
                            break;
                    }
                }
                break;
            case "Reporting Viewer":
                if (windowsAuthentication && anonymousAuthentication && kernelMode && appPoolCredentials && flag2)
                {
                    webconfigconfig.WindowsAuthOptimizeFor.Add("ReportingViewer");
                }
                break;
        }
    }

    public void ParseWebApplicationSectionsTranslator(WebApplicationDataStructures webApplicationDataStructures, webApplicationWebConfigConfiguration webconfigconfig, XmlNode root, XmlDocument xmlDoc, string webApplicationType, string version)
    {
        Dictionary<string, string[,]> sectionsTranslator = webApplicationDataStructures.getWebApplicationSectionsTranslator(webApplicationType, version);
        foreach (var section in sectionsTranslator)
        {
            if(section.Value.Length > 0)
            {
                PrebuildKnownKeys(section.Value, webconfigconfig);
            }
            
            XmlNode node = root.SelectSingleNode(section.Key);
            if (node == null)
            {
                ParseKeys(webconfigconfig, root, section.Key, xmlDoc, webApplicationDataStructures);
            }
            else
            {
                ParseKeys(webconfigconfig, node, section.Key, xmlDoc, webApplicationDataStructures);
            }
        }
    }

    public void ParseCoreConfigurationData(webApplicationWebConfigConfiguration webconfigconfig, string webApplicationType, string webApplicationVersion, string applicationName, string siteName, string physicalPath, string applicationPath, string bitness)
    {
        webconfigconfig.Type = webApplicationType;
        webconfigconfig.Version = webApplicationVersion;
        webconfigconfig.ApplicationName = applicationName;
        webconfigconfig.SiteName = siteName;
        webconfigconfig.PhysicalPath = physicalPath;
        webconfigconfig.Path = applicationPath;
        webconfigconfig.Bitness = bitness;
    }

    private void ParseRequiredKeywords(XmlNode RequiredKeywords, webApplicationWebConfigConfiguration webconfigconfig)
    {
        XmlNodeList RequiredKeywordsQuery = RequiredKeywords.SelectNodes("Query");

        foreach (XmlNode ReqKWQuery in RequiredKeywordsQuery)
        {
            try
            {
                RequiredKeywords ReqKWConfig = new RequiredKeywords();
                ReqKWConfig.QueryID = ReqKWQuery.Attributes["ID"].Value;
                ReqKWConfig.KeywordID = ReqKWQuery.SelectSingleNode("Keyword").Attributes["ID"].Value;
                webconfigconfig.requiredKeywords.Add(ReqKWConfig);
            }
            catch
            {
                Log.Logger.Warning("Error parsing the Required Keyword.");
                Log.Logger.Warning("Required Keyword Query: " + ReqKWQuery.OuterXml);
            }
        }
    }

    private void ParseHealthcareWebViewerSourceWhitelist(webApplicationWebConfigConfiguration webconfigconfig, XmlNode HylandWebHealthcareWebViewer)
    {
        HealthcareWebViewer hcwv = new HealthcareWebViewer();
        XmlNode whitelist = HylandWebHealthcareWebViewer.SelectSingleNode("epicScanViewerApi/sourceOriginWhitelist");

        if (whitelist.HasChildNodes)
        {
            foreach (XmlNode wl in whitelist.ChildNodes)
            {
                try
                {
                    if (wl.NodeType != XmlNodeType.Comment)
                    {
                        SourceOrigin so = new SourceOrigin();
                        so.origin = wl.Attributes["origin"].Value;
                        hcwv.Origins.Add(so);
                    }
                }
                catch
                {
                    Log.Logger.Warning("Error processing whitelist node: {0}", wl.OuterXml);
                }
            }
        }

        webconfigconfig.healthcareWebViewer = hcwv;
    }

    public void ParseSessionAdministration(webApplicationWebConfigConfiguration webconfigconfig, string filePath)
    {
        SessionAdministration sa = new SessionAdministration();
        XmlDocument sessionAdministrationXmlDocument = new XmlDocument();
        sessionAdministrationXmlDocument.Load(filePath);
        XmlNode sessionAdminRoot = sessionAdministrationXmlDocument.DocumentElement;
        XmlNodeList allowNodes = sessionAdminRoot.SelectNodes("allow");
        foreach (XmlNode node in allowNodes)
        {
            if (node.Attributes["users"] != null)
            {
                if (node.Attributes["users"].Value != "")
                {
                    string[] userValues = node.Attributes["users"].Value.Split(',');
                    foreach (string userValue in userValues)
                    {
                        ApplicationSessionAdministrationUser user = new ApplicationSessionAdministrationUser();
                        user.user = userValue;
                        sa.users.Add(user);
                    }
                }
            }
            else if (node.Attributes["roles"] != null)
            {
                if (node.Attributes["roles"].Value != "")
                {
                    string[] userValues = node.Attributes["roles"].Value.Split(',');
                    foreach (string userValue in userValues)
                    {
                        ApplicationSessionAdministrationRole role = new ApplicationSessionAdministrationRole();
                        role.role = userValue;
                        sa.roles.Add(role);
                    }
                }
            }
        }
        webconfigconfig.sessionAdministration = sa;
    }

    public void SaveSessionAdministration(webApplicationWebConfigConfiguration webconfigconfig, string filePath)
    {
        XmlDocument sessionAdministrationXmlDocument = new XmlDocument();
        sessionAdministrationXmlDocument.Load(filePath);
        XmlNode sessionAdminRoot = sessionAdministrationXmlDocument.DocumentElement;
        XmlNodeList allowNodes = sessionAdminRoot.SelectNodes("allow");
        string userstostore = "";
        string rolestostore = "";
        foreach (XmlNode node in allowNodes)
        {
            if (node.Attributes["users"] != null)
            {
                foreach(ApplicationSessionAdministrationUser user in webconfigconfig.sessionAdministration.users)
                {
                    if(userstostore == "")
                    {
                        userstostore += user.user;
                    }
                    else
                    {
                        userstostore += "," + user.user;
                    }
                }
                node.Attributes["users"].Value = userstostore;
            }
            else if (node.Attributes["roles"] != null)
            {
                foreach(ApplicationSessionAdministrationRole role in webconfigconfig.sessionAdministration.roles)
                {
                    if(rolestostore == "")
                    {
                        rolestostore += role.role;
                    }
                    else
                    {
                        rolestostore += "," + role.role;
                    }
                }
                node.Attributes["roles"].Value = rolestostore;
            }
        }

        sessionAdministrationXmlDocument.Save(filePath);
    }

    public void getElementsToHide(webApplicationWebConfigConfiguration webconfigconfig, string type, string version, WebApplicationDataStructures wads)
    {
        List<string> elements = wads.getElementsToHideList(type, version);

        foreach(string element in elements)
        {
            try
            {
                Element ele = new Element();
                ele.HtmlName = element;
                webconfigconfig.elementsToHide.elements.Add(ele);
            }
            catch
            {
                Log.Logger.Warning("Error processing element to hide element: {0}", element);
            }
        }
    }

    public void getHealthcareWebViewerEnabled(webApplicationWebConfigConfiguration webconfigconfig, XmlNode systemwebserver)
    {
        try
        {
            if (systemwebserver.SelectSingleNode("httpProtocol/customHeaders/add[@name='X-Frame-Options']") != null)
            {
                return;
            }
        }
        catch(Exception e)
        {
            Log.Logger.Warning(e.Message);
            Log.Logger.Warning(e.StackTrace);
            foreach (Key key in webconfigconfig.knownKeys)
            {
                if (key.Section == "Hyland.Web.HealthcareWebViewer" && key.PathName == "IsEnabled")
                {
                    key.Value = "true";
                }
            }
        }
    }

    public void setHealthcareWebViewerEnabled(webApplicationWebConfigConfiguration webconfigconfig, XmlNode systemwebserver, bool value, XmlDocument xmlDoc)
    {
        if (value)
        {
            try
            {
                XmlNode systemwebserverNode = systemwebserver.SelectSingleNode("httpProtocol/customHeaders/add[@name='X-Frame-Options']");

                XmlNode commentedOutNode = xmlDoc.CreateNode(XmlNodeType.Comment, "", null);
                commentedOutNode.InnerText = "<add name=\"X-Frame-Options\" value=\"SAMEORIGIN\" />";
                //systemwebserver.SelectSingleNode("httpProtocol/customHeaders").ReplaceChild(commentedOutNode, systemwebserverNode);
                systemwebserverNode.ParentNode.ReplaceChild(commentedOutNode, systemwebserverNode);
            }
            catch (Exception e)
            {
                Log.Logger.Information("The <add name=\"X-Frame-Options\" value=\"SAMEORIGIN\" /> element is already commented out.");
            }
        }
        else
        {
            bool nodeFound = false;
            XmlNode n = systemwebserver.SelectSingleNode("httpProtocol/customHeaders/add[@name='X-Frame-Options']");

            if(n == null)
            {
                foreach (XmlNode node in systemwebserver.SelectSingleNode("httpProtocol/customHeaders").ChildNodes)
                {
                    if (node.NodeType == XmlNodeType.Comment)
                    {
                        if (node.InnerText.StartsWith("<add name=\"X-Frame-Options\""))
                        {
                            nodeFound = true;
                            if (IsValidXml(node.InnerText))
                            {
                                XmlDocument doc = new XmlDocument();
                                doc.LoadXml(node.InnerText);
                                XmlElement ele = xmlDoc.CreateElement(doc.DocumentElement.Name);
                                foreach(XmlAttribute a in doc.DocumentElement.Attributes)
                                {
                                    XmlAttribute xmlAttribute = xmlDoc.CreateAttribute(a.Name);
                                    xmlAttribute.Value = a.Value;
                                    ele.Attributes.Append(xmlAttribute);
                                }
                                node.ParentNode.ReplaceChild(ele, node);
                            }
                            break;
                        }
                    }
                }

                if (!nodeFound)
                {
                    XmlElement ele = xmlDoc.CreateElement("add");
                    ele.SetAttribute("name", "X-Frame-Options");
                    ele.SetAttribute("value", "SAMEORIGIN");
                    systemwebserver.SelectSingleNode("httpProtocol/customHeaders").AppendChild(ele);
                }
            }
        }
    }

    public void CheckHylandDllFiles(string physicalPath, string version)
    {
        switch (version)
        {
            case var s when s.StartsWith("21.1") || s.StartsWith("22.1") || s.StartsWith("23.1"):
                //Check if the Hyland.Applications.Web.dll file exists in the OtherDependencies folder.
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\231AndUnder\Hyland.Applications.Web.dll") && File.Exists(physicalPath + @"\bin\Hyland.Applications.Web.dll"))
                {
                    File.Copy(physicalPath + @"\bin\Hyland.Applications.Web.dll", AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\231AndUnder\Hyland.Applications.Web.dll");
                }
                else
                {
                    if (File.Exists(physicalPath + @"\bin\Hyland.Applications.Web.dll"))
                    {
                        FileVersionInfo webAppHylandApplicationsWebDllVersionInfo = FileVersionInfo.GetVersionInfo(physicalPath + @"\bin\Hyland.Applications.Web.dll");
                        FileVersionInfo comaconHylandApplicationsWebDllVersionInfo = FileVersionInfo.GetVersionInfo(AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\231AndUnder\Hyland.Applications.Web.dll");
                        int comparisonResult = (new Version(comaconHylandApplicationsWebDllVersionInfo.FileVersion)).CompareTo(new Version(webAppHylandApplicationsWebDllVersionInfo.FileVersion));

                        if (comparisonResult < 0)
                        {
                            File.Copy(physicalPath + @"\bin\Hyland.Applications.Web.dll", AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\231AndUnder\Hyland.Applications.Web.dll", true);
                        }
                    }
                }

                //Check if the Hyland.Applications.Server.dll file exists in the OtherDependencies folder.
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\231AndUnder\Hyland.Applications.Server.dll") && File.Exists(physicalPath + @"\bin\Hyland.Applications.Server.dll"))
                {
                    File.Copy(physicalPath + @"\bin\Hyland.Applications.Server.dll", AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\231AndUnder\Hyland.Applications.Server.dll");
                }
                else
                {
                    if (File.Exists(physicalPath + @"\bin\Hyland.Applications.Server.dll"))
                    {
                        FileVersionInfo webAppHylandApplicationsServerDllVersionInfo = FileVersionInfo.GetVersionInfo(physicalPath + @"\bin\Hyland.Applications.Server.dll");
                        FileVersionInfo comaconHylandApplicationsServerDllVersionInfo = FileVersionInfo.GetVersionInfo(AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\231AndUnder\Hyland.Applications.Server.dll");
                        int comparisonResult = (new Version(comaconHylandApplicationsServerDllVersionInfo.FileVersion)).CompareTo(new Version(webAppHylandApplicationsServerDllVersionInfo.FileVersion));

                        if (comparisonResult < 0)
                        {
                            File.Copy(physicalPath + @"\bin\Hyland.Applications.Server.dll", AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\231AndUnder\Hyland.Applications.Server.dll", true);
                        }
                    }
                }
                break;
            default:
                //Check if the Hyland.Applications.Web.dll file exists in the OtherDependencies folder.
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Web.dll") && File.Exists(physicalPath + @"\bin\Hyland.Applications.Web.dll"))
                {
                    File.Copy(physicalPath + @"\bin\Hyland.Applications.Web.dll", AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Web.dll");
                }
                else
                {
                    if (File.Exists(physicalPath + @"\bin\Hyland.Applications.Web.dll"))
                    {
                        FileVersionInfo webAppHylandApplicationsWebDllVersionInfo = FileVersionInfo.GetVersionInfo(physicalPath + @"\bin\Hyland.Applications.Web.dll");
                        FileVersionInfo comaconHylandApplicationsWebDllVersionInfo = FileVersionInfo.GetVersionInfo(AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Web.dll");
                        int comparisonResult = (new Version(comaconHylandApplicationsWebDllVersionInfo.FileVersion)).CompareTo(new Version(webAppHylandApplicationsWebDllVersionInfo.FileVersion));

                        if (comparisonResult < 0)
                        {
                            File.Copy(physicalPath + @"\bin\Hyland.Applications.Web.dll", AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Web.dll", true);
                        }
                    }
                }

                //Check if the Hyland.Applications.Server.dll file exists in the OtherDependencies folder.
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Server.dll") && File.Exists(physicalPath + @"\bin\Hyland.Applications.Server.dll"))
                {
                    File.Copy(physicalPath + @"\bin\Hyland.Applications.Server.dll", AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Server.dll");
                }
                else
                {
                    if (File.Exists(physicalPath + @"\bin\Hyland.Applications.Server.dll"))
                    {
                        FileVersionInfo webAppHylandApplicationsServerDllVersionInfo = FileVersionInfo.GetVersionInfo(physicalPath + @"\bin\Hyland.Applications.Server.dll");
                        FileVersionInfo comaconHylandApplicationsServerDllVersionInfo = FileVersionInfo.GetVersionInfo(AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Server.dll");
                        int comparisonResult = (new Version(comaconHylandApplicationsServerDllVersionInfo.FileVersion)).CompareTo(new Version(webAppHylandApplicationsServerDllVersionInfo.FileVersion));

                        if (comparisonResult < 0)
                        {
                            File.Copy(physicalPath + @"\bin\Hyland.Applications.Server.dll", AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Server.dll", true);
                        }
                    }
                }
                break;
        }
        ////Check if the Hyland.Applications.Web.dll file exists in the OtherDependencies folder.
        //if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Web.dll") && File.Exists(physicalPath + @"\bin\Hyland.Applications.Web.dll"))
        //{
        //    File.Copy(physicalPath + @"\bin\Hyland.Applications.Web.dll", AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Web.dll");
        //}
        //else
        //{
        //    if(File.Exists(physicalPath + @"\bin\Hyland.Applications.Web.dll"))
        //    {
        //        FileVersionInfo webAppHylandApplicationsWebDllVersionInfo = FileVersionInfo.GetVersionInfo(physicalPath + @"\bin\Hyland.Applications.Web.dll");
        //        FileVersionInfo comaconHylandApplicationsWebDllVersionInfo = FileVersionInfo.GetVersionInfo(AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Web.dll");
        //        int comparisonResult = (new Version(comaconHylandApplicationsWebDllVersionInfo.FileVersion)).CompareTo(new Version(webAppHylandApplicationsWebDllVersionInfo.FileVersion));

        //        if(comparisonResult < 0)
        //        {
        //            File.Copy(physicalPath + @"\bin\Hyland.Applications.Web.dll", AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Web.dll", true);
        //        }
        //    }
        //}

        ////Check if the Hyland.Applications.Server.dll file exists in the OtherDependencies folder.
        //if(!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Server.dll") && File.Exists(physicalPath + @"\bin\Hyland.Applications.Server.dll"))
        //{
        //    File.Copy(physicalPath + @"\bin\Hyland.Applications.Server.dll", AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Server.dll");
        //}
        //else
        //{
        //    if(File.Exists(physicalPath + @"\bin\Hyland.Applications.Server.dll"))
        //    {
        //        FileVersionInfo webAppHylandApplicationsServerDllVersionInfo = FileVersionInfo.GetVersionInfo(physicalPath + @"\bin\Hyland.Applications.Server.dll");
        //        FileVersionInfo comaconHylandApplicationsServerDllVersionInfo = FileVersionInfo.GetVersionInfo(AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Server.dll");
        //        int comparisonResult = (new Version(comaconHylandApplicationsServerDllVersionInfo.FileVersion)).CompareTo(new Version(webAppHylandApplicationsServerDllVersionInfo.FileVersion));

        //        if (comparisonResult < 0)
        //        {
        //            File.Copy(physicalPath + @"\bin\Hyland.Applications.Server.dll", AppDomain.CurrentDomain.BaseDirectory + @"\OtherDependencies\Hyland.Applications.Server.dll", true);
        //        }
        //    }
        //}
    }
}
