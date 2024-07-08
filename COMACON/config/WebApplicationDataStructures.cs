using COMACONTranslationToHelperUtility;
using Newtonsoft.Json;
using System.Security.Policy;

namespace COMACON.config;

public interface WebApplicationDataStructures
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="version"></param>
    /// <returns>
    /// 
    /// </returns>
    public Dictionary<string, string[,]> getWebApplicationSectionsTranslator(string type,
        string version);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="version"></param>
    /// <returns>
    /// 
    /// </returns>
    public string getWebApplicationDataStructureDictionary(string type,
        string version);
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""></param>
    /// <returns>
    /// 
    /// </returns>
    public Dictionary<string, string[]> getCustomValidationPagesDictionary(string version);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="version"></param>
    /// <returns>
    /// 
    /// </returns>
    public string[] getWebApplicationLoginPages(string type,
        string version);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="version"></param>
    /// <returns>
    /// 
    /// </returns>
    public string[] getDiagnosticsSettingsProfiles(string version);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="version"></param>
    /// <returns>
    /// 
    /// </returns>
    public List<string> getElementsToHideList(string type,
        string version);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="version"></param>
    /// <returns>
    /// 
    /// </returns>
    public List<string> getElementsToSave(string type,
        string version);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="version"></param>
    /// <returns>
    /// 
    /// </returns>
    public List<List<string>> getTooltips(string type,
        string version);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="type"></param>
    /// <param name="version"></param>
    /// <returns>
    /// 
    /// </returns>
    public Dictionary<string,string> getGenericWebApplicationTooltips(string type,
        string version);
}


internal sealed class  DefaultWebApplicationDataStructures : WebApplicationDataStructures
{
    /*
     ***********************************************************
     *       web.config Ecnrypted Sections Translators
     ***********************************************************
     */
    /* These are the translators for the sections that can be encrypted as they have to pass to the COMACON Helper.exe file since they need to be run in the .NET Framework version. */
    /* Version 21.1 Translators */
    private readonly Dictionary<string, List<List<string>>> ApplicationServer211Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.ContentComposer.Core", new List<List<string>>
            {
                new List<string> { "ClientId", "value", "2", "Content-Composer-Client-ID", "", "" ,"",""},
                new List<string> { "ClientSecret", "value", "2", "Content-Composer-Client-Secret", "", "" ,"",""},
                new List<string> { "Username", "value", "2", "Content-Composer-Username", "", "" ,"",""},
                new List<string> { "Password", "value", "2", "Content-Composer-Password", "", "" ,"",""},
                new List<string> { "IsEncrypted", "", "1", "Encrypt-Content-Composer-Settings", "false", "" ,"",""}
            }
        },
        {
            "Hyland.Web.AppServerPop", new List<List<string>>
            {
                new List<string> { "EnableChecksum", "value", "1", "Pop-Integrations-Validate-Against-Checksum", "false", "" ,"",""},
                new List<string> { "ChecksumKey", "value", "2", "Pop-Integrations-Checksum-Key", "", "" ,"",""},
                new List<string> { "EnableLegacyChecksumCreation", "value", "1", "Pop-Integrations-Enable-Legacy-Checksum-Creation", "false", "" ,"",""},
                new List<string> { "IsEncrypted", "", "1", "Pop-Integrations-Encrypt-Configuration", "false", "" ,"",""}
            }
        },
        {
            "Hyland.Core.Media.HostedApplicationServer", new List<List<string>>
            {
                new List<string> { "url", "value", "2", "Integrations-Media-URL", "", "" ,"",""},
                new List<string> { "datasource", "value", "2", "Integrations-Media-Datasource", "", "" ,"",""},
                new List<string> { "username", "value", "2", "Integrations-Media-Username", "", "" ,"",""},
                new List<string> { "password", "value", "2", "Integrations-Media-Password", "", "" ,"","" },
                new List<string> { "IsEncrypted", "", "1", "Integrations-Media-Encrypt-OnBase-Cloud-Settings", "false", "" ,"",""}
            }
        },
        {
            "Hyland.Applications.Portals.ExternalAccess", new List<List<string>>
            {
                new List<string> { "username", "value", "2", "EAC-Username", "", "" ,"",""},
                new List<string> { "password", "value", "2", "EAC-Password", "", "" ,"",""},
                new List<string> { "minPoolSize", "value", "2", "EAC-UserLevel-Minimum-Pool-Size", "0", "" ,"",""},
                new List<string> { "maxPoolSize", "value", "2", "EAC-UserLevel-Maximum-Pool-Size", "0", "" ,"",""},
                new List<string> { "IsEncrypted", "", "1", "Encrypt-EAC", "false", "","",""},
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> AgendaOnline211Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Applications.AgendaPubAccess.Client", new List<List<string>>
            {
                new List<string> {"SessionUser","value","2","Session-Username","","","",""},
                new List<string> {"SessionPassword","value","2","Session-Password","","","",""},
                new List<string> {"DataSource","value","2","Data-Source","","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Agenda-Online-Access","","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> ElectronicPlanReview211Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Applications.PlanReview.Client", new List<List<string>>
            {
                new List<string> {"SessionUser","value","2","EPR-Username","","","",""},
                new List<string> {"SessionPassword","value","2","EPR-Password","","","",""},
                new List<string> {"DataSource","value","2","Data-Source","","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Electronic-Plan-Review","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> GatewayCachingServer211Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Applications.ApplicationServerGateway", new List<List<string>>
            {
                new List<string> {"username","value","2","GWCS-Username","[SERVICEACCOUNT]","","",""},
                new List<string> {"password","value","2","GWCS-Password","[SERVICEACCOUNT_PASSWORD]","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Login-Settings","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> HealthcareFormManager211Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.HealthcarePop", new List<List<string>>
            {
                new List<string> {"EnableChecksum","value","1","Validate-Against-Checksum","false","","",""},
                new List<string> {"ChecksumKey","value","2","Checksum-Key","","","",""},
                new List<string> {"EnableLegacyChecksumFallback","value","1","Enable-Legacy-Checksum-Fallback","false","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Healthcare-Pop-Integration-Configuration","","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> PatientWindow211Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.HealthcarePop", new List<List<string>>
            {
                new List<string> {"EnableChecksum","value","1","Validate-Against-Checksum","false","","",""},
                new List<string> {"ChecksumKey","value","2","Checksum-Key","","","",""},
                new List<string> {"EnableLegacyChecksumFallback","value","1","Enable-Legacy-Checksum-Fallback","false","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Healthcare-Pop-Integration-Configuration","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> PublicAccessLegacy211Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.PublicAccess", new List<List<string>>
            {
                new List<string> {"user","value","2","PAVL-Username","[USERNAME]","","",""},
                new List<string> {"password","value","2","PAVL-Password","[PASSWORD]","","",""},
                new List<string> {"datasource","value","2","Data-Source","[DATASOURCE]","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Public-Access-Configuration","false", "", "", "" }
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> PublicAccessNextGen211Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.PublicAccess", new List<List<string>>
            {
                new List<string> {"user","value","2","PAVNG-Username","[USERNAME]","","",""},
                new List<string> {"password","value","2","PAVNG-Password","[PASSWORD]","","",""},
                new List<string> {"datasource","value","2","Data-Source","[DATASOURCE]","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Public-Access-Configuration","false", "", "", "" }
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> ReportingViewer211Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.DashboardViewer", new List<List<string>>
            {
                new List<string> {"username","value","2","OB-Username","","","",""},
                new List<string> {"password","value","2","OB-Password","","","",""},
                new List<string> {"useTheme","value","2","Dashboard-Theme","dark","","",""},
                new List<string> {"enableExportDashboard","value","1","Export-Dashboard","true","","",""},
                new List<string> {"enableExportDashboardItems","value","1","Export-Dashboard-Items","true","","",""},
                new List<string> {"acceptHttpParams","value","1","Allow-HTTP-Parameters","false","","",""},
                new List<string> {"sessionTraceLevel","value","2","Dashboard-Tracing-Info-Level","0","","0","4"},
                new List<string> {"enableAutoLogin","value","1","Autologin","false","","",""},
                new List<string> {"reportPagingLimit","value","2","Report-Paging-Limit","50","","50",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Dashboard-Viewer-Settings","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> WebServer211Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.DocPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-DocPop-Username","","","",""},
                new List<string> {"password","value","2","Default-DocPop-Password","","","",""},
                new List<string> {"datasource","value","2","DocPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-DocPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-DocPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-DocPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","DocPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","DocPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","DocPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","DocPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","DocPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","DocPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","DocPop-Core-Query-API-License","false","","",""},
                new List<string> {"AutoDisplayOneDocument","value","1","DocPop-Auto-Display-One-Document","true","","",""},
                new List<string> {"disableContextMenu","value","1","Disable-Context-Menus-in-DocPop","false","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-DocPop","false","","",""}
            }
        },
        {
            "Hyland.Web.PdfPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-PdfPop-Username","","","",""},
                new List<string> {"password","value","2","Default-PdfPop-Password","","","",""},
                new List<string> {"datasource","value","2","PdfPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-PdfPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-PdfPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-PdfPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","PdfPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","PdfPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","PdfPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","PdfPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","PdfPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","PdfPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","PdfPop-Core-Query-API-License","false","","",""},
                new List<string> {"AutoDisplayOneDocument","value","1","PdfPop-Auto-Display-One-Document","true","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-PdfPop","false","","",""}
            }
        },
        {
            "Hyland.Web.FormPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-FormPop-Username","","","",""},
                new List<string> {"password","value","2","Default-FormPop-Password","","","",""},
                new List<string> {"datasource","value","2","FormPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-FormPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-FormPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-FormPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","FormPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","FormPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","FormPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","FormPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","FormPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","FormPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","FormPop-Core-Query-API-License","false","","",""},
                new List<string> {"autoDisplayOneDocument","value","1","FormPop-Auto-Display-One-Document","true","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-FormPop","false","","",""}
            }
        },
        {
            "Hyland.Web.FolderPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-FolderPop-Username","","","",""},
                new List<string> {"password","value","2","Default-FolderPop-Password","","","",""},
                new List<string> {"datasource","value","2","FolderPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-FolderPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-FolderPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-FolderPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","FolderPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","FolderPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","FolderPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","FolderPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","FolderPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","FolderPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","FolderPop-Core-Query-API-License","false","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-FolderPop","false","","",""}
            }
        },
        {
            "Hyland.Web.PacketPop", new List<List<string>>
            {
                new List<string> {"datasource","value","2","PacketPop-Data-Source","","","",""},
                new List<string> {"enableChecksum","value","1","PacketPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","PacketPop-Checksum-Key","","","",""}
            }
        },
        {
            "Hyland.Web.LoginFormProc", new List<List<string>>
            {
                new List<string> {"username","value","2","LoginFormProc-Username","","","",""},
                new List<string> {"password","value","2","LoginFormProc-Password","","","",""},
                new List<string> {"datasource","value","2","LoginFormProc-Data-Source","","","",""},
                new List<string> {"prompt","value","2","LoginFormProc-Prompt-For-New-Form","enable","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-LoginFormProc","false","","",""}
            }
        }
    };

    /* Version 22.1 Translators */
    private readonly Dictionary<string, List<List<string>>> ApplicationServer221Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.ContentComposer.Core", new List<List<string>>
            {
                new List<string> { "ClientId", "value", "2", "Content-Composer-Client-ID","","","",""},
                new List<string> { "ClientSecret", "value", "2", "Content-Composer-Client-Secret","","","",""},
                new List<string> { "Username", "value", "2", "Content-Composer-Username","","","",""},
                new List<string> { "Password", "value", "2", "Content-Composer-Password","","","",""},
                new List<string> { "IsEncrypted", "", "1", "Encrypt-Content-Composer-Settings", "false", "", "", "" }
            }
        },
        {
            "Hyland.Web.AppServerPop", new List<List<string>>
            {
                new List<string> { "EnableChecksum", "value", "1", "Pop-Integrations-Validate-Against-Checksum", "false", "", "", "" },
                new List<string> { "ChecksumKey", "value", "2", "Pop-Integrations-Checksum-Key","","","",""},
                new List<string> { "EnableLegacyChecksumCreation", "value", "1", "Pop-Integrations-Enable-Legacy-Checksum-Creation", "false", "", "", "" },
                new List<string> { "IsEncrypted", "", "1", "Pop-Integrations-Encrypt-Configuration", "false", "", "", "" }
            }
        },
        {
            "Hyland.Core.Media.HostedApplicationServer", new List<List<string>>
            {
                new List<string> { "url", "value", "2", "Integrations-Media-URL","","","",""},
                new List<string> { "datasource", "value", "2", "Integrations-Media-Datasource","","","",""},
                new List<string> { "username", "value", "2", "Integrations-Media-Username","","","",""},
                new List<string> { "password", "value", "2", "Integrations-Media-Password","","","",""},
                new List<string> { "IsEncrypted", "", "1", "Integrations-Media-Encrypt-OnBase-Cloud-Settings", "false", "", "", "" }
            }
        },
        {
            "Hyland.Applications.Portals.ExternalAccess", new List<List<string>>
            {
                new List<string> { "username", "value", "2", "EAC-Username","","","",""},
                new List<string> { "password", "value", "2", "EAC-Password","","","",""},
                new List<string> { "minPoolSize", "value", "2", "EAC-UserLevel-Minimum-Pool-Size", "0", "", "", "" },
                new List<string> { "maxPoolSize", "value", "2", "EAC-UserLevel-Maximum-Pool-Size", "0", "", "", "" },
                new List<string> { "IsEncrypted", "", "1", "Encrypt-EAC", "false", "", "", "" }
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> AgendaOnline221Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Applications.AgendaPubAccess.Client", new List<List<string>>
            {
                new List<string> {"SessionUser","value","2","Session-Username","","","",""},
                new List<string> {"SessionPassword","value","2","Session-Password","","","",""},
                new List<string> {"DataSource","value","2","Data-Source","","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Agenda-Online-Access","","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> ElectronicPlanReview221Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Applications.PlanReview.Client", new List<List<string>>
            {
                new List<string> {"SessionUser","value","2","EPR-Username","","","",""},
                new List<string> {"SessionPassword","value","2","EPR-Password","","","",""},
                new List<string> {"DataSource","value","2","Data-Source","","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Electronic-Plan-Review","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> GatewayCachingServer221Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Applications.ApplicationServerGateway", new List<List<string>>
            {
                new List<string> {"username","value","2","GWCS-Username","[SERVICEACCOUNT]","","",""},
                new List<string> {"password","value","2","GWCS-Password","[SERVICEACCOUNT_PASSWORD]","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Login-Settings","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> HealthcareFormManager221Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.HealthcarePop", new List<List<string>>
            {
                new List<string> {"EnableChecksum","value","1","Validate-Against-Checksum","false","","",""},
                new List<string> {"ChecksumKey","value","2","Checksum-Key","","","",""},
                new List<string> {"EnableLegacyChecksumFallback","value","1","Enable-Legacy-Checksum-Fallback","false","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Healthcare-Pop-Integration-Configuration","","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> PatientWindow221Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.HealthcarePop", new List<List<string>>
            {
                new List<string> {"EnableChecksum","value","1","Validate-Against-Checksum","false","","",""},
                new List<string> {"ChecksumKey","value","2","Checksum-Key","","","",""},
                new List<string> {"EnableLegacyChecksumFallback","value","1","Enable-Legacy-Checksum-Fallback","false","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Healthcare-Pop-Integration-Configuration","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> PublicAccessNextGen221Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.PublicAccess", new List<List<string>>
            {
                new List<string> {"user","value","2","PAVNG-Username","[USERNAME]","","",""},
                new List<string> {"password","value","2","PAVNG-Password","[PASSWORD]","","",""},
                new List<string> {"datasource","value","2","Data-Source","[DATASOURCE]","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Public-Access-Configuration","false", "", "", "" }
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> ReportingViewer221Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.DashboardViewer", new List<List<string>>
            {
                new List<string> {"username","value","2","OB-Username","","","",""},
                new List<string> {"password","value","2","OB-Password","","","",""},
                new List<string> {"useTheme","value","2","Dashboard-Theme","dark","","",""},
                new List<string> {"enableExportDashboard","value","1","Export-Dashboard","true","","",""},
                new List<string> {"enableExportDashboardItems","value","1","Export-Dashboard-Items","true","","",""},
                new List<string> {"acceptHttpParams","value","1","Allow-HTTP-Parameters","false","","",""},
                new List<string> {"sessionTraceLevel","value","2","Dashboard-Tracing-Info-Level","","","0",""},
                new List<string> {"enableAutoLogin","value","1","Autologin","false","","",""},
                new List<string> {"reportPagingLimit","value","2","Report-Paging-Limit","50","","50",""},
                new List<string> {"dashboardCacheTimeoutSeconds", "value","2", "Dashboard-Cache-Timeout", "2","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Dashboard-Viewer-Settings","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> WebServer221Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.DocPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-DocPop-Username","","","",""},
                new List<string> {"password","value","2","Default-DocPop-Password","","","",""},
                new List<string> {"datasource","value","2","DocPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-DocPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-DocPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-DocPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","DocPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","DocPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","DocPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","DocPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","DocPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","DocPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","DocPop-Core-Query-API-License","false","","",""},
                new List<string> {"AutoDisplayOneDocument","value","1","DocPop-Auto-Display-One-Document","true","","",""},
                new List<string> {"disableContextMenu","value","1","Disable-Context-Menus-in-DocPop","false","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-DocPop","false","","",""}
            }
        },
        {
            "Hyland.Web.PdfPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-PdfPop-Username","","","",""},
                new List<string> {"password","value","2","Default-PdfPop-Password","","","",""},
                new List<string> {"datasource","value","2","PdfPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-PdfPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-PdfPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-PdfPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","PdfPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","PdfPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","PdfPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","PdfPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","PdfPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","PdfPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","PdfPop-Core-Query-API-License","false","","",""},
                new List<string> {"AutoDisplayOneDocument","value","1","PdfPop-Auto-Display-One-Document","true","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-PdfPop","false","","",""}
            }
        },
        {
            "Hyland.Web.FormPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-FormPop-Username","","","",""},
                new List<string> {"password","value","2","Default-FormPop-Password","","","",""},
                new List<string> {"datasource","value","2","FormPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-FormPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-FormPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-FormPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","FormPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","FormPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","FormPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","FormPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","FormPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","FormPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","FormPop-Core-Query-API-License","false","","",""},
                new List<string> {"autoDisplayOneDocument","value","1","FormPop-Auto-Display-One-Document","true","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-FormPop","false","","",""}
            }
        },
        {
            "Hyland.Web.FolderPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-FolderPop-Username","","","",""},
                new List<string> {"password","value","2","Default-FolderPop-Password","","","",""},
                new List<string> {"datasource","value","2","FolderPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-FolderPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-FolderPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-FolderPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","FolderPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","FolderPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","FolderPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","FolderPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","FolderPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","FolderPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","FolderPop-Core-Query-API-License","false","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-FolderPop","false","","",""}
            }
        },
        {
            "Hyland.Web.PacketPop", new List<List<string>>
            {
                new List<string> {"datasource","value","2","PacketPop-Data-Source","","","",""},
                new List<string> {"enableChecksum","value","1","PacketPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","PacketPop-Checksum-Key","","","",""}
            }
        },
        {
            "Hyland.Web.LoginFormProc", new List<List<string>>
            {
                new List<string> {"username","value","2","LoginFormProc-Username","","","",""},
                new List<string> {"password","value","2","LoginFormProc-Password","","","",""},
                new List<string> {"datasource","value","2","LoginFormProc-Data-Source","","","",""},
                new List<string> {"prompt","value","2","LoginFormProc-Prompt-For-New-Form","enable","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-LoginFormProc","false","","",""}
            }
        }
    };

    /* Version 23.1 Translators */
    private readonly Dictionary<string, List<List<string>>> ApplicationServer231Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.ContentComposer.Core", new List<List<string>>
            {
                new List<string> { "ClientId", "value", "2", "Content-Composer-Client-ID","","","",""},
                new List<string> { "ClientSecret", "value", "2", "Content-Composer-Client-Secret","","","",""},
                new List<string> { "Username", "value", "2", "Content-Composer-Username","","","",""},
                new List<string> { "Password", "value", "2", "Content-Composer-Password","","","",""},
                new List<string> { "IsEncrypted", "", "1", "Encrypt-Content-Composer-Settings", "false", "", "", "" }
            }
        },
        {
            "Hyland.Web.AppServerPop", new List<List<string>>
            {
                new List<string> { "EnableChecksum", "value", "1", "Pop-Integrations-Validate-Against-Checksum", "false", "", "", "" },
                new List<string> { "ChecksumKey", "value", "2", "Pop-Integrations-Checksum-Key","","","",""},
                new List<string> { "EnableLegacyChecksumCreation", "value", "1", "Pop-Integrations-Enable-Legacy-Checksum-Creation", "false", "", "", "" },
                new List<string> { "IsEncrypted", "", "1", "Pop-Integrations-Encrypt-Configuration", "false", "", "", "" }
            }
        },
        {
            "Hyland.Core.Media.HostedApplicationServer", new List<List<string>>
            {
                new List<string> { "url", "value", "2", "Integrations-Media-URL","","","",""},
                new List<string> { "datasource", "value", "2", "Integrations-Media-Datasource","","","",""},
                new List<string> { "username", "value", "2", "Integrations-Media-Username","","","",""},
                new List<string> { "password", "value", "2", "Integrations-Media-Password","","","",""},
                new List<string> { "IsEncrypted", "", "1", "Integrations-Media-Encrypt-OnBase-Cloud-Settings", "false", "", "", "" }
            }
        },
        {
            "Hyland.Applications.Portals.ExternalAccess", new List<List<string>>
            {
                new List<string> { "username", "value", "2", "EAC-Username","","","",""},
                new List<string> { "password", "value", "2", "EAC-Password","","","",""},
                new List<string> { "minPoolSize", "value", "2", "EAC-UserLevel-Minimum-Pool-Size", "0", "", "", "" },
                new List<string> { "maxPoolSize", "value", "2", "EAC-UserLevel-Maximum-Pool-Size", "0", "", "", "" },
                new List<string> { "IsEncrypted", "", "1", "Encrypt-EAC", "false", "", "", "" }
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> AgendaOnline231Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Applications.AgendaPubAccess.Client", new List<List<string>>
            {
                new List<string> {"SessionUser","value","2","Session-Username","","","",""},
                new List<string> {"SessionPassword","value","2","Session-Password","","","",""},
                new List<string> {"DataSource","value","2","Data-Source","","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Agenda-Online-Access","","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> ElectronicPlanReview231Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Applications.PlanReview.Client", new List<List<string>>
            {
                new List<string> {"SessionUser","value","2","EPR-Username","","","",""},
                new List<string> {"SessionPassword","value","2","EPR-Password","","","",""},
                new List<string> {"DataSource","value","2","Data-Source","","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Electronic-Plan-Review","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> GatewayCachingServer231Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Applications.ApplicationServerGateway", new List<List<string>>
            {
                new List<string> {"username","value","2","GWCS-Username","[SERVICEACCOUNT]","","",""},
                new List<string> {"password","value","2","GWCS-Password","[SERVICEACCOUNT_PASSWORD]","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Login-Settings","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> HealthcareFormManager231Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.HealthcarePop", new List<List<string>>
            {
                new List<string> {"EnableChecksum","value","1","Validate-Against-Checksum","false","","",""},
                new List<string> {"ChecksumKey","value","2","Checksum-Key","","","",""},
                new List<string> {"EnableLegacyChecksumFallback","value","1","Enable-Legacy-Checksum-Fallback","false","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Healthcare-Pop-Integration-Configuration","","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> PatientWindow231Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.HealthcarePop", new List<List<string>>
            {
                new List<string> {"EnableChecksum","value","1","Validate-Against-Checksum","false","","",""},
                new List<string> {"ChecksumKey","value","2","Checksum-Key","","","",""},
                new List<string> {"EnableLegacyChecksumFallback","value","1","Enable-Legacy-Checksum-Fallback","false","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Healthcare-Pop-Integration-Configuration","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> PublicAccessNextGen231Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.PublicAccess", new List<List<string>>
            {
                new List<string> {"user","value","2","PAVNG-Username","[USERNAME]","","",""},
                new List<string> {"password","value","2","PAVNG-Password","[PASSWORD]","","",""},
                new List<string> {"datasource","value","2","Data-Source","[DATASOURCE]","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Public-Access-Configuration","false", "", "", "" }
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> ReportingViewer231Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.DashboardViewer", new List<List<string>>
            {
                new List<string> {"username","value","2","OB-Username","","","",""},
                new List<string> {"password","value","2","OB-Password","","","",""},
                new List<string> {"useTheme","value","2","Dashboard-Theme","dark","","",""},
                new List<string> {"enableExportDashboard","value","1","Export-Dashboard","true","","",""},
                new List<string> {"enableExportDashboardItems","value","1","Export-Dashboard-Items","true","","",""},
                new List<string> {"acceptHttpParams","value","1","Allow-HTTP-Parameters","false","","",""},
                new List<string> {"sessionTraceLevel","value","2","Dashboard-Tracing-Info-Level","0","","0","4"},
                new List<string> {"enableAutoLogin","value","1","Autologin","false","","",""},
                new List<string> {"reportPagingLimit","value","2","Report-Paging-Limit","50","","50",""},
                new List<string> {"dashboardCacheTimeoutSeconds", "value","2", "Dashboard-Cache-Timeout", "2","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Dashboard-Viewer-Settings","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> WebServer231Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.DocPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-DocPop-Username","","","",""},
                new List<string> {"password","value","2","Default-DocPop-Password","","","",""},
                new List<string> {"datasource","value","2","DocPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-DocPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-DocPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-DocPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","DocPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","DocPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","DocPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","DocPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","DocPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","DocPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","DocPop-Core-Query-API-License","false","","",""},
                new List<string> {"AutoDisplayOneDocument","value","1","DocPop-Auto-Display-One-Document","true","","",""},
                new List<string> {"disableContextMenu","value","1","Disable-Context-Menus-in-DocPop","false","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-DocPop","false","","",""}
            }
        },
        {
            "Hyland.Web.PdfPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-PdfPop-Username","","","",""},
                new List<string> {"password","value","2","Default-PdfPop-Password","","","",""},
                new List<string> {"datasource","value","2","PdfPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-PdfPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-PdfPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-PdfPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","PdfPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","PdfPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","PdfPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","PdfPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","PdfPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","PdfPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","PdfPop-Core-Query-API-License","false","","",""},
                new List<string> {"AutoDisplayOneDocument","value","1","PdfPop-Auto-Display-One-Document","true","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-PdfPop","false","","",""}
            }
        },
        {
            "Hyland.Web.FormPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-FormPop-Username","","","",""},
                new List<string> {"password","value","2","Default-FormPop-Password","","","",""},
                new List<string> {"datasource","value","2","FormPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-FormPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-FormPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-FormPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","FormPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","FormPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","FormPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","FormPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","FormPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","FormPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","FormPop-Core-Query-API-License","false","","",""},
                new List<string> {"autoDisplayOneDocument","value","1","FormPop-Auto-Display-One-Document","true","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-FormPop","false","","",""}
            }
        },
        {
            "Hyland.Web.FolderPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-FolderPop-Username","","","",""},
                new List<string> {"password","value","2","Default-FolderPop-Password","","","",""},
                new List<string> {"datasource","value","2","FolderPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-FolderPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-FolderPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-FolderPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","FolderPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","FolderPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","FolderPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","FolderPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","FolderPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","FolderPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","FolderPop-Core-Query-API-License","false","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-FolderPop","false","","",""}
            }
        },
        {
            "Hyland.Web.PacketPop", new List<List<string>>
            {
                new List<string> {"datasource","value","2","PacketPop-Data-Source","","","",""},
                new List<string> {"enableChecksum","value","1","PacketPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","PacketPop-Checksum-Key","","","",""}
            }
        },
        {
            "Hyland.Web.LoginFormProc", new List<List<string>>
            {
                new List<string> {"username","value","2","LoginFormProc-Username","","","",""},
                new List<string> {"password","value","2","LoginFormProc-Password","","","",""},
                new List<string> {"datasource","value","2","LoginFormProc-Data-Source","","","",""},
                new List<string> {"prompt","value","2","LoginFormProc-Prompt-For-New-Form","enable","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-LoginFormProc","false","","",""}
            }
        }
    };

    /* Version 24.1 Translators */
    private readonly Dictionary<string, List<List<string>>> ApplicationServer241Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.ContentComposer.Core", new List<List<string>>
            {
                new List<string> { "ClientId", "value", "2", "Content-Composer-Client-ID","","","",""},
                new List<string> { "ClientSecret", "value", "2", "Content-Composer-Client-Secret","","","",""},
                new List<string> { "Username", "value", "2", "Content-Composer-Username","","","",""},
                new List<string> { "Password", "value", "2", "Content-Composer-Password","","","",""},
                new List<string> { "IsEncrypted", "", "1", "Encrypt-Content-Composer-Settings", "false", "", "", "" }
            }
        },
        {
            "Hyland.Web.AppServerPop", new List<List<string>>
            {
                new List<string> { "EnableChecksum", "value", "1", "Pop-Integrations-Validate-Against-Checksum", "false", "", "", "" },
                new List<string> { "ChecksumKey", "value", "2", "Pop-Integrations-Checksum-Key","","","",""},
                new List<string> { "EnableLegacyChecksumCreation", "value", "1", "Pop-Integrations-Enable-Legacy-Checksum-Creation", "false", "", "", "" },
                new List<string> { "IsEncrypted", "", "1", "Pop-Integrations-Encrypt-Configuration", "false", "", "", "" }
            }
        },
        {
            "Hyland.Core.Media.HostedApplicationServer", new List<List<string>>
            {
                new List<string> { "url", "value", "2", "Integrations-Media-URL","","","",""},
                new List<string> { "datasource", "value", "2", "Integrations-Media-Datasource","","","",""},
                new List<string> { "username", "value", "2", "Integrations-Media-Username","","","",""},
                new List<string> { "password", "value", "2", "Integrations-Media-Password","","","",""},
                new List<string> { "IsEncrypted", "", "1", "Integrations-Media-Encrypt-OnBase-Cloud-Settings", "false", "", "", "" }
            }
        },
        {
            "Hyland.Applications.Portals.ExternalAccess", new List<List<string>>
            {
                new List<string> { "username", "value", "2", "EAC-Username","","","",""},
                new List<string> { "password", "value", "2", "EAC-Password","","","",""},
                new List<string> { "minPoolSize", "value", "2", "EAC-UserLevel-Minimum-Pool-Size", "0", "", "", "" },
                new List<string> { "maxPoolSize", "value", "2", "EAC-UserLevel-Maximum-Pool-Size", "0", "", "", "" },
                new List<string> { "IsEncrypted", "", "1", "Encrypt-EAC", "false", "", "", "" }
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> AgendaOnline241Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Applications.AgendaPubAccess.Client", new List<List<string>>
            {
                new List<string> {"SessionUser","value","2","Session-Username","","","",""},
                new List<string> {"SessionPassword","value","2","Session-Password","","","",""},
                new List<string> {"DataSource","value","2","Data-Source","","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Agenda-Online-Access","","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> ElectronicPlanReview241Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Applications.PlanReview.Client", new List<List<string>>
            {
                new List<string> {"SessionUser","value","2","EPR-Username","","","",""},
                new List<string> {"SessionPassword","value","2","EPR-Password","","","",""},
                new List<string> {"DataSource","value","2","Data-Source","","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Electronic-Plan-Review","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> HealthcareFormManager241Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.HealthcarePop", new List<List<string>>
            {
                new List<string> {"EnableChecksum","value","1","Validate-Against-Checksum","false","","",""},
                new List<string> {"ChecksumKey","value","2","Checksum-Key","","","",""},
                new List<string> {"EnableLegacyChecksumFallback","value","1","Enable-Legacy-Checksum-Fallback","false","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Healthcare-Pop-Integration-Configuration","","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> PatientWindow241Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.HealthcarePop", new List<List<string>>
            {
                new List<string> {"EnableChecksum","value","1","Validate-Against-Checksum","false","","",""},
                new List<string> {"ChecksumKey","value","2","Checksum-Key","","","",""},
                new List<string> {"EnableLegacyChecksumFallback","value","1","Enable-Legacy-Checksum-Fallback","false","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Healthcare-Pop-Integration-Configuration","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> PublicAccessNextGen241Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.PublicAccess", new List<List<string>>
            {
                new List<string> {"user","value","2","PAVNG-Username","[USERNAME]","","",""},
                new List<string> {"password","value","2","PAVNG-Password","[PASSWORD]","","",""},
                new List<string> {"datasource","value","2","Data-Source","[DATASOURCE]","","",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Public-Access-Configuration","false", "", "", "" }
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> ReportingViewer241Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.DashboardViewer", new List<List<string>>
            {
                new List<string> {"username","value","2","OB-Username","","","",""},
                new List<string> {"password","value","2","OB-Password","","","",""},
                new List<string> {"useTheme","value","2","Dashboard-Theme","dark","","",""},
                new List<string> {"enableExportDashboard","value","1","Export-Dashboard","true","","",""},
                new List<string> {"enableExportDashboardItems","value","1","Export-Dashboard-Items","true","","",""},
                new List<string> {"acceptHttpParams","value","1","Allow-HTTP-Parameters","false","","",""},
                new List<string> {"sessionTraceLevel","value","2","Dashboard-Tracing-Info-Level","0","","0","4"},
                new List<string> {"enableAutoLogin","value","1","Autologin","false","","",""},
                new List<string> {"reportPagingLimit","value","2","Report-Paging-Limit","50","","50",""},
                new List<string> {"IsEncrypted","","1","Encrypt-Dashboard-Viewer-Settings","false","","",""}
            }
        }
    };

    private readonly Dictionary<string, List<List<string>>> WebServer241Translator = new Dictionary<string, List<List<string>>>
    {
        {
            "Hyland.Web.DocPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-DocPop-Username","","","",""},
                new List<string> {"password","value","2","Default-DocPop-Password","","","",""},
                new List<string> {"datasource","value","2","DocPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-DocPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-DocPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-DocPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","DocPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","DocPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","DocPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","DocPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","DocPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","DocPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","DocPop-Core-Query-API-License","false","","",""},
                new List<string> {"AutoDisplayOneDocument","value","1","DocPop-Auto-Display-One-Document","true","","",""},
                new List<string> {"disableContextMenu","value","1","Disable-Context-Menus-in-DocPop","false","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-DocPop","false","","",""}
            }
        },
        {
            "Hyland.Web.PdfPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-PdfPop-Username","","","",""},
                new List<string> {"password","value","2","Default-PdfPop-Password","","","",""},
                new List<string> {"datasource","value","2","PdfPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-PdfPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-PdfPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-PdfPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","PdfPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","PdfPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","PdfPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","PdfPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","PdfPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","PdfPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","PdfPop-Core-Query-API-License","false","","",""},
                new List<string> {"AutoDisplayOneDocument","value","1","PdfPop-Auto-Display-One-Document","true","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-PdfPop","false","","",""}
            }
        },
        {
            "Hyland.Web.FormPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-FormPop-Username","","","",""},
                new List<string> {"password","value","2","Default-FormPop-Password","","","",""},
                new List<string> {"datasource","value","2","FormPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-FormPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-FormPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-FormPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","FormPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","FormPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","FormPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","FormPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","FormPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","FormPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","FormPop-Core-Query-API-License","false","","",""},
                new List<string> {"autoDisplayOneDocument","value","1","FormPop-Auto-Display-One-Document","true","","",""},
                new List<string> {"targetOrigin","value","2","Target-Origin","","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-FormPop","false","","",""}
            }
        },
        {
            "Hyland.Web.FolderPop", new List<List<string>>
            {
                new List<string> {"username","value","2","Default-FolderPop-Username","","","",""},
                new List<string> {"password","value","2","Default-FolderPop-Password","","","",""},
                new List<string> {"datasource","value","2","FolderPop-Data-Source","","","",""},
                new List<string> {"domain","value","2","Default-FolderPop-Domain-Name","","","",""},
                new List<string> {"institution","value","2","Default-FolderPop-Institution","","","",""},
                new List<string> {"embedded","value","1","Embedded-FolderPop","false","","",""},
                new List<string> {"enableDefaultLogin","value","1","FolderPop-Default-Login","false","","",""},
                new List<string> {"enableHTTPLogin","value","1","FolderPop-HTTP-Login","false","","",""},
                new List<string> {"enableAutoLogin","value","1","FolderPop-Auto-Login","false","","",""},
                new List<string> {"enableHTTPDataSource","value","1","FolderPop-HTTP-Data-Source","false","","",""},
                new List<string> {"enableChecksum","value","1","FolderPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","FolderPop-Checksum-Key","","","",""},
                new List<string> {"enableCoreQueryAPILicense","value","1","FolderPop-Core-Query-API-License","false","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-FolderPop","false","","",""}
            }
        },
        {
            "Hyland.Web.PacketPop", new List<List<string>>
            {
                new List<string> {"datasource","value","2","PacketPop-Data-Source","","","",""},
                new List<string> {"enableChecksum","value","1","PacketPop-Validate-Against-Checksum","false","","",""},
                new List<string> {"checksum","value","2","PacketPop-Checksum-Key","","","",""}
            }
        },
        {
            "Hyland.Web.LoginFormProc", new List<List<string>>
            {
                new List<string> {"username","value","2","LoginFormProc-Username","","","",""},
                new List<string> {"password","value","2","LoginFormProc-Password","","","",""},
                new List<string> {"datasource","value","2","LoginFormProc-Data-Source","","","",""},
                new List<string> {"prompt","value","2","LoginFormProc-Prompt-For-New-Form","enable","","",""},
                new List<string> {"IsEncrypted","value","1","Encrypt-LoginFormProc","false","","",""}
            }
        }
    };


    /*
     ***********************************************************
     *               web.config Section Translators
     ***********************************************************
     */
    /* These are the translators for each of the individual sections in the web.config files for the Web Applications */
    /* Translator field data structure legend:
        Position1: Section of the xml the key is coming from.
        Position2: Element name, or path to the element needing parsed/read.
        Position3: Attribute in question that is being read.
        Position4: Value type:
            0 = Unknown
            1 = boolean
            2 = string
        Position5: HTML ID of the id attribute in the HTML page for reference
        Position6: Default value of the Element/Attribute being referenced.
        Position7: Version to be filled in if a missing key/element is found.
        Position8: Minimum value of the Element/Attribute being referenced.
        Position9: Maximum value of the Element/Attribute being referenced.
    */
    /* Version 21.1 Translators */
    private readonly Dictionary<string, string[,]> AgendaOnline211SectionsTranslator = new Dictionary<string, string[,]> {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://localhost/AppServer/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
            }
        },
        {
            "Hyland.Applications.AgendaPubAccess.PublicComment", new string[,]
            {
                
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","StreamChunkSize","2","Stream-Chunk-Size","65536","","",""},
                {"appSettings","add","PlayerSourceFilePath","2","Player-Source-File-Path","../Scripts/jwplayer","","",""},
                {"appSettings","add","PlayerVersion","2","Player-Version","JWPlayer 8.8.5","","",""},
                {"appSettings","add","MinPoolSize","2","Min-Pool-Size","1","","",""},
                {"appSettings","add","MaxPoolSize","2","Max-Pool-Size","5","","",""},
                {"appSettings","add","webpages:Enabled","1","webpages-Enabled","false","","",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> ElectronicPlanReview211SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[server]/[virtual directory]/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","StyleSheetPath","2","Stylesheet-Directory-Location","BasicBlue/","","",""},
                {"appSettings","add","AllowSignon","1","Allow-Sign-On","true","","",""},
                {"appSettings","add","AllowSignoff","1","Allow-Sign-Off","true","","",""},
                {"appSettings","add","DefaultTimeZone","2","Default-User-Time-Zone","4","","",""},
                {"appSettings","add","SearchStartYear","2","Search-Start-Year","2012","","",""},
                {"appSettings","add","DisplayDocumentsPerPage","2","Items-Per-Page","20","","",""},
                {"appSettings","add","MaxLookupResults","2","Max-Lookup-Results","20","","",""},
                {"appSettings","add","ResetPasswordLinkExpiration","2","Reset-Password-Link-Lifetime","60","","",""},
                {"appSettings","add","FileUploadDirectory","2","File-Upload-Directory","~/Upload","","",""},
                {"appSettings","add","FileUploadValidator","2","File-Upload-Validator","","","",""},
                {"appSettings","add","TokenAuthentication","1","Token-Authentication","false","","",""},
                {"appSettings","add","SingleSignOn","1","Allow-Single-Sign-On","false","","",""},
                {"appSettings","add","SingleSignOnSourceID","2","Source-ID","1","","",""},
                {"appSettings","add","SSOUserResolutionMode","2","Resolution-Mode","0","","",""},
                {"appSettings","add","CAPTCHAPublicKey","2","Public-CAPTCHA-Key","","","",""},
                {"appSettings","add","CAPTCHAPrivateKey","2","Private-CAPTCHA-Key","","","",""},
                {"appSettings","add","PasswordStrengthPattern","2","Password-Strength-Pattern","^(?=.{4,}).*$","","",""},
                {"appSettings","add","PasswordStrengthMessage","2","Password-Strength-Message","","","",""},
                {"appSettings","add","UsernameValidationPattern","2","Username-Validation-Pattern","[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+","","",""},
                {"appSettings","add","DisciplineItemsPerMenu","2","Discipline-Items-Per-Menu","15","","",""},
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> GatewayCachingServer211SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://localhost/AppServer/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""},
                {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
                {"Hyland.Services.Client","OptimizedServicePipeline","Enabled","1","Optimized-Service-Pipeline","true","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","gatewayName","2","Gateway-Name","[GATEWAYNAME]","","",""},
                {"appSettings","add","dataSource","2","DataSource","[DATABASENAME]","","",""},
                {"appSettings","add","cachePath","2","Cache-Path","[CACHEPATH]","","",""},
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> HealthcareFormManager211SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[server]/[virtual directory]/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""},
                {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "appSettings", new string[,]
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
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""},
                {"system.web","sessionState","timeout","2","Session-Timeout","20","","2","1440"},
                {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> PatientWindow211SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "appSettings", new string[,]
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
            }
        },
        {
            "Hyland.Authentication", new string[,]
            {
                {"Hyland.Authentication","adfs","enabled","1","ADFS-Enabled","false","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""},
                {"system.web","sessionState","timeout","2","Session-Timeout","20","","2","1440"},
                {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        },
        {
            "ADFS", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> PublicAccessLegacy211SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","EncryptDocId","1","Encrypt-Doc-ID","true","","",""},
                {"appSettings","add","EncryptFolderId","1","Encrypt-Folder-ID","false","","",""},
                {"appSettings","add","CheckSumKey","2","Checksum-Key","","","",""},
                {"appSettings","add","UseDisplayColumns","1","Use-Display-Columns","true","","",""},
                {"appSettings","add","QueryLimit","2","Query-Limit","0","","",""},
                {"appSettings","add","ChunkSize","2","Chunk-Size","512000","","",""},
                {"appSettings","add","ViewerMode","2","Viewer-Mode","PDF","","",""},
                {"appSettings","add","CachePath","2","Cache-Path","C:\\DocCache","","",""},
                {"appSettings","add","ExpireTime","2","Expiration-Time","1","","0",""},
                {"appSettings","add","MaxCacheSize","2","Max-Cache-Size","10","","0",""},
                {"appSettings","add","SizeToCache","2","Size-to-Cache","1","","0",""},
                {"appSettings","add","SizeToPrompt","2","Size-to-Prompt","20","","0",""}
            }
        },
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://localhost/AppServer/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
                {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","SOAP-Client-Request-Timeout","100","","10",""},
                {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","100","","10",""}
            }
        },
        {
            "RequiredKeywords", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> PublicAccessNextGen211SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","EncryptDocId","1","Encrypt-Doc-ID","true","","",""},
                {"appSettings","add","UseDisplayColumns","1","Use-Display-Columns","true","","",""},
                {"appSettings","add","QueryLimit","2","Query-Limit","0","","",""},
                {"appSettings","add","ChunkSize","2","Chunk-Size","512000","","",""},
                {"appSettings","add","ViewerMode","2","Viewer-Mode","PDF","","",""},
                {"appSettings","add","OverlayMode","2","Default-Overlay-Mode","Print","","",""},
                {"appSettings","add","CachePath","2","Cache-Path","C:\\DocCache","","",""},
                {"appSettings","add","ExpireTime","2","Expiration-Time","1","","",""},
                {"appSettings","add","MaxCacheSize","2","Max-Cache-Size","10","","",""},
                {"appSettings","add","SizeToCache","2","Size-to-Cache","1","","",""},
                {"appSettings","add","SizeToPrompt","2","Size-to-Prompt","20","","",""},
                {"appSettings","add","ThrottleResetTimer","2","Interval-Between-Throttle-Cache-Resets","5","","",""},
                {"appSettings","add","ThrottleThreshold","2","Amount-of-Requests-During-Each-Throttle-Interval","1000","","",""},
                {"appSettings","add","EnableBrowserCaching","1","Enable-Local-Browser-Caching","true","","",""},
                {"appSettings","add","DecorateDocumentNames","1","Decorate-Document-Names","true","","",""}
            }
        },
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://localhost/AppServer/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
                {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","SOAP-Client-Request-Timeout","100","","10",""},
                {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","False","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","100","","10",""}
            }
        },
        {
            "RequiredKeywords", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> ReportingViewer211SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
                {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
                {"Hyland.Services.Client","OptimizedServicePipeline","Enabled","1","Optimized-Service-Pipeline","true","","",""},
                {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","Request-Timeout","300","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
                {"appSettings","add","dmsVirtualRoot","2","Web-Virtual-Directory","http://[HOSTNAME]/[VIRTUAL ROOT]","","",""},
                {"appSettings","add","dmsDataSource","2","Core-Data-Source","[DATASOURCE NAME]","","",""},
                {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""},
                {"appSettings","add","IdPUrl","2","","","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "system.web.extensions", new string[,]
            {
                {"system.web.extensions","scripting/webServices/jsonSerialization","maxJsonLength","2","JSON-Serialization-Max-Length","50000000","","",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> ApplicationServer211SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""},
                {"appSettings","add","dmsdatasource","2","Data-Source","[Datasource]","","",""},
                {"appSettings","add","UseOSAuthentication","1","Use-OS-Authentication","false","","",""},
                {"appSettings","add","DocumentQueryWarningThreshold","2","Document-Query-Warning-Threshold","500","","",""},
                {"appSettings","add","DocumentQueryLimit","2","Document-Query-Limit","2000","","0","10000"},
                {"appSettings","add","ItemCacheTimeout","2","Item-Cache-Timeout","60","","",""},
                {"appSettings","add","RawImagesAllowed","1","Raw-Images","true","","",""},
                {"appSettings","add","UseIsolatedImageProcess","1","Use-Isolated-Image-Process","true","","",""},
                {"appSettings","add","CompressionQuality","2","Compression-Quality","70","","",""},
                {"appSettings","add","EnableIsolatedChromiumProcess","1","Enable-Isolated-Chromium-Process","true","","",""},
                {"appSettings","add","FormSaveToTiffTimeout","2","Form-Save-To-TIFF-Timeout","60","","",""},
                {"appSettings","add","PrintImageFormViaPDF","1","Print-Image-Form-Via-PDF","false","","",""},
                {"appSettings","add","TPCFWorkerLocationOverride","2","TPCF-Worker-Location-Override","","","",""},
                {"appSettings","add","DefaultStoragePath","2","Default-Storage-Path","","","",""},
                {"appSettings","add","watchFolder","2","Watch-Folder","","","",""},
                {"appSettings","add","siteIDKeywordType","2","Site-ID-Keyword-Type","Site ID","","",""},
                {"appSettings","add","cleanupTimerInterval","2","Cleanup-Timer-Interval","15","","",""},
                {"appSettings","add","maxFileAgeInHours","2","Max-File-Age","4","","",""},
                {"appSettings","add","ValidateMessageSchema","1","Integrations-EIS-Validate-Message-Schema","true","","",""},
                {"appSettings","add","ContinueOnValidationError","1","Integrations-EIS-Continue-On-Validation-Error","false","","",""},
                {"appSettings","add","DataSetCacheCleanUpIntervalInMins","2","Integrations-EIS-Data-Set-Cache-Cleanup-Interval","60","","",""},
                {"appSettings","add","AppNetDirectory","2","Integrations-EIS-AppNet-Directory","[virtualRoot]","","",""},
                {"appSettings","add","UseHTMLClientType","1","Integrations-EIS-Use-HTML-Client-Type","false","","",""},
                {"appSettings","add","MessageBrokerMonitorStartDelayInMinutes","2","Message-Broker-Monitor-Start-Delay","","","",""},
                {"appSettings","add","GCSUsername","2","GCS-Username","","","",""},
                {"appSettings","add","GCSPassword","2","GCS-Password","","","",""},
                {"appSettings","add","useLegacyKeyForUsageBasedBilling","2","Use-Legacy-Key-For-Usage-Based-Billing","false","","",""},
                {"appSettings","add","GCSPhoneHomeIntervalInMinutes","2","GCS-Phone-Home-Interval","60","","",""},
                {"appSettings","add","DataCaptureServerWCFEndpointAddress","2","Data-Capture-Server-WCF-Endpoint-Address","net.tcp://localhost:9050/Hyland.DataCapture.ServiceManager/service","","",""},
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
                {"appSettings","add","AppServerOrigin","2","OWIN-Application-Server-Origin","[virtualRoot]","","",""},
                {"appSettings","add","owin:AutomaticAppStartup","1","OWIN-Automatic-App-Startup","false","","",""},
                {"appSettings","add","owin:appStartup","2","OWIN-App-Startup","Hyland.Owin.Core.Startup, Hyland.Owin.Core","","",""},
                {"appSettings","add","IdentityModelServerURI","2","Identity-Model-Server-URI","","","",""},
                {"appSettings","add","mobileAppsPath","2","Mobile-Apps-Path","[unc path]","","",""},
                {"appSettings","add","corsPolicy","2","CORS-Policy","*","","",""},
                {"appSettings","add","endpoints:WorkViewMobile","1","WorkView-Mobile-Endpoint","false","","",""},
                {"appSettings","add","endpoints:ResponsiveApps","1","Responsive-Apps-Endpoint","false","","",""},
                {"appSettings","add","endpoints:Wopi","1","WOPI-Endpoint","false","","",""},
                {"appSettings","add","endpoints:Sesame","1","Sesame-Endpoint","false","","",""},
                {"appSettings","add","endpoints:GovernanceRulesAsAService","1","Governance-Rules-As-A-Service-Endpoint","false","","",""},
                {"appSettings","add","endpoints:FHIR","1","Web-BLOB-Passthrough-FHIR-Endpoint","false","","",""},
                {"appSettings","add","SMARTonFHIRApplicationId","2","SMART-On-FHIR-Application-ID","[GUID]","","",""},
                {"appSettings","add","endpoints:PPL","1","PPL-Endpoint-Enabled","false","","",""},
                {"appSettings","add","endpoints:Forms","1","Forms-Endpoint","false","","",""},
                {"appSettings","add","DocPopUrl","2","PPL-DocPop-URL","","","",""},
                {"appSettings","add","StatementCompCacheLimit","2","Statement-Composition-Cache-Limit","","","",""},
                {"appSettings","add","UnityFormsToggleMaxFormWidth","1","Unity-Forms-Toggle-Max-Form-Width","false","","",""},
                {"appSettings","add","owin:oia:msgItemTypeId","2","owin:oia:msgItemTypeId","[Message Item Type ID]","","",""},
                {"appSettings","add","owin:oia:lifeCycleId","2","owin:oia:lifeCycleId","[Lifecycle ID]","","",""},
                {"appSettings","add","owin:oia:tmpFilePath","2","owin:oia:tmpFilePath","[UNC Path]","","",""},
                {"appSettings","add","owin:oia:tmpFileAgeInMs","2","owin:oia:tmpFileAgeInMs","[Temp File Age ms]","","",""},
                {"appSettings","add","owin:oia:cleanupIntervalInMs","2","owin:oia:cleanupIntervalInMs","[Cleanup Interval ms]","","",""},
                {"appSettings","add","UseOnBaseFulltext","1","Use-OnBase-Full-Text","false","","",""},
                {"appSettings","add","ContentComposerIdpPath","2","Content-Composer-IdP-Path","","","",""},
                {"appSettings","add","KeywordDataCacheTimeout","2","Keyword-Data-Cache-Timeout","20","","",""},
                {"appSettings","add","AllowInsecureExternalXsl ","1","Allow-Insecure-External-XSL","false","","",""}
            }
        },
        {
            "Hyland.ResponsiveApps", new string[,]
            {
                {"Hyland.ResponsiveApps","WorkViewApi","url","2","Responsive-Apps-WorkView-API-URL","https://[Server]/[AppServer]/private/workview/api/","","",""},
                {"Hyland.ResponsiveApps","WorkViewFiles","url","2","Responsive-Apps-WorkView-Files-URL","https://[Server]/[AppServer]/private/workview/files/","","",""},
                {"Hyland.ResponsiveApps","ResponsiveAppsApi","url","2","Responsive-Apps-API-URL","https://[Server]/[AppServer]/private/responsive-apps/api/","","",""},
                {"Hyland.ResponsiveApps","IdentityProvider","url","2","Identity-Provider-URL","https://[Server]/idp/[tenant]/[population]","","",""},
                {"Hyland.ResponsiveApps","CoreAccessTokenLifetime","value","2","Core-Access-Token-Lifetime","691200","","",""}
            }
        },
        {
            "Hyland.PlatterManagement", new string[,]
            {
                {"Hyland.PlatterManagement","Logging/FileIODetail","value","1","File-IO-Detail","false","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/EMCTHRESHOLD","value","2","Foreign-Storage-EMC-Threshold","","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/PmCacheLocation","value","2","Foreign-Storage-PM-Cache-Location","","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/PmCacheTimeout","value","2","Foreign-Storage-PM-Cache-Timeout","","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/PmCacheSize","value","2","Foreign-Storage-PM-Cache-Size","","","",""},
                {"Hyland.PlatterManagement","FileAccess/PMAccessLevel","value","2","PM-File-Access-Level","0","","",""},
                {"Hyland.PlatterManagement","TemporaryFiles/TempFileExpirationThreshold","value","2","Temp-File-Expiration-Threshold-Time","","","",""}
            }
        },
        {
            "Hyland.Services", new string[,]
            {
                {"Hyland.Services","poolSettings","minSessions","2","Hyland-Services-AppPool-Minimum-Sessions","0","","",""},
                {"Hyland.Services","poolSettings","maxSessions","2","Hyland-Services-AppPool-Maximum-Sessions","10","","",""},
                {"Hyland.Services","serviceLogin","username","2","Hyland-Services-AppPool-Username","[serviceUserName]","","",""},
                {"Hyland.Services","serviceLogin","password","2","Hyland-Services-AppPool-Password","[servicePassword]","","",""},
                {"Hyland.Services","securitySettings","useQueryContext","1","Use-Query-Context","false","","",""},
                {"Hyland.Services","securitySettings","filterExceptions","1","Filter-Exceptions","true","","",""},
                {"Hyland.Services","Endpoint","useRemoting","1","Endpoint-Use-Remoting","true","","",""},
                {"Hyland.Services","session","enableTimeout","1","Session-Enable-Timeout","false","","",""},
                {"Hyland.Services","applicationServerCallback","url","2","Application-Server-Callback-URL","","","",""},
                {"Hyland.Services","webServerBaseUrl","url","2","Web-Server-Base-URL","","","",""},
                {"Hyland.Services","requestValidation","minVersion","2","Request-Validation-Minimum-Version","0","","",""}
            }
        },
        {
            "Hyland.XMLServices.DocumentConnector", new string[,]
            {
                {"Hyland.XMLServices.DocumentConnector","loginId","name","2","Login-ID","","","",""},
                {"Hyland.XMLServices.DocumentConnector","loginPassword","name","2","Login-Password","","","",""},
                {"Hyland.XMLServices.DocumentConnector","loginDatasource","name","2","Login-Datasource","","","",""},
                {"Hyland.XMLServices.DocumentConnector","pool","min","2","Pool-Min","0","","",""},
                {"Hyland.XMLServices.DocumentConnector","pool","max","2","Pool-Max","5","","",""}
            }
        },
        {
            "Hyland.Core.FullText", new string[,]
            {
                {"Hyland.Core.FullText","SearchTimeout","value","2","Search-Timeout","30","","",""},
                {"Hyland.Core.FullText","SearchLog","enableSearchlog","1","Enable-Search-Log","false","","",""},
                {"Hyland.Core.FullText","SearchLog","path","2","Search-Log-Path","","","",""}
            }
        },
        {
            "Hyland.WorkView.Core", new string[,]
            {
                {"Hyland.WorkView.Core","UnityEditableFilterMaxRows","value","2","Unity-Editable-Filter-Max-Rows","20","","",""},
                {"Hyland.WorkView.Core","ERPDateFormat","value","2","ERP-Date-Format-LOB-Broker","yyyyMMdd","","",""},
                {"Hyland.WorkView.Core","FormattedTextIframeSupportedDomains","value","2","Formatted-Text-Iframe-Supported-Domains","","","",""}
            }
        },
        {
            "Hyland.Core.IDOL", new string[,]
            {
                {"Hyland.Core.IDOL","RemoteOCREngine","remoteServer","2","Remote-OCR-Engine-Remote-Server","localhost","","",""},
                {"Hyland.Core.IDOL","RemoteOCREngine","port","2","Remote-OCR-Engine-Port","9050","","",""},
                {"Hyland.Core.IDOL","RemoteOCREngine","timeOut","2","Remote-OCR-Engine-Timeout","5","","",""}
            }
        },
        {
            "Hyland.Core.Wopi", new string[,]
            {
                {"Hyland.Core.Wopi","useOfficeWebAppServer","value","2","Use-Office-Online-Server","false","","",""},
                {"Hyland.Core.Wopi","owaServerUri","value","2","Office-Online-Server-URI","https://[servername]/","","",""},
                {"Hyland.Core.Wopi","owaProxyBase","value","2","Office-Online-Server-Proxy-Base","https://[servername]/[appserver]/private","","",""}
            }
        },
        {
            "Hyland.Integrations.LOBBroker.LOBBrokerConfigSection", new string[,]
            {
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorCacheSearchMinChars","2","Vendor-Cache-Search-Minimum-Characters","1","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorMasterKeyedLookupOp","2","Vendor-Master-Keyed-Lookup-Op","GetVenMasterRecordbyVenIDNCompID","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorMasterLookupSequence","2","Vendor-Master-Lookup-Sequence","GetVenMasterRecordbyVenIDNCompID, GetVenMasterRecordbyPONumNCompID, GetVenMasterRecordbyPhoneNCompID, GetVenMasterRecordbyTaxID, GetVenMasterRecordbyVATID, GetVenMasterRecordbyZipCodeNCompID, GetVenMasterRecordByVenAddressNCompID, GetVenMasterRecordbyWebSiteNCompID, GetVenMasterRecordbyBankAccountNumber, GetVenMasterRecordbyVenNameNCompID","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorMasterLookupReturnMultiple","1","Vendor-Master-Lookup-Return-Multiple","false","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorCacheAutoCompleteResultsMax","2","Vendor-Cache-AutoComplete-Result-Max","30","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","IsEnabled","","1","Enable-LOB-Broker-Accounts-Payable","false","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","Http-Runtime-Maximum-Request-Length","30000","","",""},
                {"system.web","httpRuntime","executionTimeout","2","Http-Runtime-Execution-Timeout","300","","",""},
                {"system.web","sessionState","timeout","2","Session-Timeout-Length","20","","",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "root", new string[,]
            {
                {"root","Hyland.Core.IDOL","ImageCompression","2","Image-Compression","70","","",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        },
        {
            "ADFS", new string[,]
            {

            }
        },
        {
            "Hyland.Authentication", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> WebServer211SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://localhost/appserver/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","remoting","","",""},
                {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","dmsDataSource","2","Core-Data-Source","[DATASOURCE]","","",""},
                {"appSettings","add","dmsVirtualRoot","2","Web-Virtual-Directory","https://[WEB SERVER]/[VIRTUAL ROOT]","","",""},
                {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""},
                {"appSettings","add","default_domainname","2","Default-Domain-Name","","","",""},
                {"appSettings","add","default_username","2","Default-Username","","","",""},
                {"appSettings","add","default_password","2","Default-Password","","","",""},
                {"appSettings","add","default_institution","2","Default-Institution","0","","0",""},
                {"appSettings","add","EnableAutoLogin","1","Autologin","false","","",""},
                {"appSettings","add","IdPUrl","2","","","","",""},
                {"appSettings","add","forceSSOAutoLoginOverDomain","1","Force-OnBase-Authentication","false","","",""},
                {"appSettings","add","CustomSSOAuthenticationFailurePage","2","Custom-SSO-Authentication-Page-Failure","","","",""},
                {"appSettings","add","LogoutClose","1","Close-On-Logout","false","","",""},
                {"appSettings","add","logoutRedirectURL","2","Logout-Redirect-URL","","","",""},
                {"appSettings","add","webtheme","2","Web-Theme","XP","","",""},
                {"appSettings","add","targetPage","2","Target-Page","NavPanel.aspx","","",""},
                {"appSettings","add","loginPage","2","Login-Page","Login.aspx","","",""},
                {"appSettings","add","SPViewerShowWorkflow","1","SharePoint-Viewer-Show-Workflow","false","","",""},
                {"appSettings","add","SharepointOnline","1","SharePoint-Online","false","","",""},
                {"appSettings","add","defaultPrintRange","2","Default-Print-Range","all","","",""},
                {"appSettings","add","promptUserQueries","1","Prompt-User-Queries","false","","",""},
                {"appSettings","add","showQueueCounts","1","Show-Queue-Counts","false","","",""},
                {"appSettings","add","reselectDelta","2","Reselect-Delta","15","","",""},
                {"appSettings","add","textSearchAutoView","1","Text-Search-Auto-View","false","","",""},
                {"appSettings","add","MaxResults","2","Max-Results","1000","","",""},
                {"appSettings","add","WorkflowMaxResults","2","Workflow-Max-Results","2000","","",""},
                {"appSettings","add","KeywordPanelViewType","2","Keyword-Panel-View-Type","flat","","",""},
                {"appSettings","add","EnableKeywordOperators","1","Enable-Keyword-Operators","true","","",""},
                {"appSettings","add","EnableSessionExpiration","1","Enable-Session-Expiration","true","","",""},
                {"appSettings","add","PromptOnSessionExpire","1","Prompt-On-Session-Expire","true","","",""},
                {"appSettings","add","displaySingleDocument","1","Display-Single-Document","true","","",""},
                {"appSettings","add","EnableBriefcaseEDM","1","EDM-Briefcase","true","","",""},
                {"appSettings","add","DisplayRelatedDocuments","2","Display-Related-Documents","always","","",""},
                {"appSettings","add","WorkflowUserInteractionHeight","2","Workflow-Height-px","375","","",""},
                {"appSettings","add","ShowCombinedInbox","1","Show-Combined-Inbox","true","","",""},
                {"appSettings","add","OverrideUILanguage","1","Override-UI-Language","false","","",""},
                {"appSettings","add","DefaultUILocale","2","Default-UI-Local","default","","",""},
                {"appSettings","add","NativeMailSystem","2","Native-Mail-System","0","","",""},
                {"appSettings","add","UseWebMail","1","Use-Web-Mail","false","","",""},
                {"appSettings","add","enableVirtualPrintDriver","1","Enable-Virtual-Print-Driver","false","","",""},
                {"appSettings","add","autoDisplayNotePanelPDFOffice","1","Auto-Display-Note-Panel-PDF-Office","true","","",""},
                {"appSettings","add","ClearDocumentTypeAfterImport","1","Clear-Document-Type-After-Import","false","","",""},
                {"appSettings","add","ClearKeywordsAfterImport","1","Clear-Keywords-After-Import","false","","",""},
                {"appSettings","add","AlwaysGeneratePreviewAfterUpload","1","Always-Generate-Preview","true","","",""},
                {"appSettings","add","WebClientType","2","Web-Client-Type","activex","","",""},
                {"appSettings","add","RememberHitListHeight","1","Remember-Hitlist-Height","false","","",""},
                {"appSettings","add","NumDisplayedDocumentTypes","2","Number-of-Docuemnt-Types-to-Display","6","","",""},
                {"appSettings","add","CollapseCheckSelect","1","Collapse-Check-Select-Lists","false","","",""},
                {"appSettings","add","addNoteMenu","1","Add-Note-Menu","true","","",""},
                {"appSettings","add","createDocumentMenu","1","Create-New-Document-Menu","true","","",""},
                {"appSettings","add","documentPropertiesMenu","1","Document-Properties-Menu","true","","",""},
                {"appSettings","add","fileMenu","1","File-Menu","true","","",""},
                {"appSettings","add","historyMenu","1","History-Menu","true","","",""},
                {"appSettings","add","keywordsMenu","1","Keywords-Menu","true","","",""},
                {"appSettings","add","printMenu","1","Print-Menu","true","","",""},
                {"appSettings","add","reindexMenu","1","Reindex-Menu","true","","",""},
                {"appSettings","add","workflowMenu","1","Workflow-Menu","true","","",""},
                {"appSettings","add","sendToPrintQueueMenu","1","Send-To-Print-Queue-Menu","true","","",""},
                {"appSettings","add","clipBoardMenu","1","Clipboard-Menu","true","","",""},
                {"appSettings","add","firstPageMenu","1","First-Page-Menu","true","","",""},
                {"appSettings","add","gotoPageMenu","1","Goto-Page-Menu","true","","",""},
                {"appSettings","add","lastPageMenu","1","Last-Page-Menu","true","","",""},
                {"appSettings","add","mailRecipientMenu","1","Mail-Recipient-Menu","true","","",""},
                {"appSettings","add","nextPageMenu","1","Next-Page-Menu","true","","",""},
                {"appSettings","add","pagesMenu","1","Pages-Menu","true","","",""},
                {"appSettings","add","previousPageMenu","1","Previous-Page-Menu","true","","",""},
                {"appSettings","add","textSearchMenu","1","Text-Search-Menu","true","","",""},
                {"appSettings","add","viewerControlMenu","1","Viewer-Control-Menu","true","","",""},
                {"appSettings","add","zoomInMenu","1","Zoom-In-Menu","true","","",""},
                {"appSettings","add","zoomOutMenu","1","Zoom-Out-Menu","true","","",""},
                {"appSettings","add","gotoPageOR","2","Go-To-Page","0","","0",""},
                {"appSettings","add","overlayOR","2","Overlay","","","",""},
                {"appSettings","add","zoomLevelOR","2","Zoom-Level","","","",""},
                {"appSettings","add","rectLeftOR","2","Left-Border","0","","0",""},
                {"appSettings","add","rectRightOR","2","Right-Border","0","","0",""},
                {"appSettings","add","rectTopOR","2","Top-Border","0","","0",""},
                {"appSettings","add","rectBottomOR","2","Bottom-Border","0","","0",""},
                {"appSettings","add","enableAnnotationToolbar","1","Annotation-Toolbar","true","","",""},
                {"appSettings","add","enableNoteToolbar","1","Notes-Toolbar","true","","",""},
                {"appSettings","add","enableThumbnailPages","1","Thumbnail-Pages","true","","",""},
                {"appSettings","add","enableViewerControlToolbar","1","Viewer-Control-Toolbar","true","","",""},
                {"appSettings","add","DisableContextMenu","1","Disable-Context-Menu","false","","",""},
                {"appSettings","add","PathFormProc","2","Path-Form-Proc","/FormProc.ashx","","",""},
                {"appSettings","add","PathPrint","2","Path-Print","/PrintHandler.ashx","","",""},
                {"appSettings","add","PreventViewerClientCaching","1","Prevent-Viewer-Client-Caching","false","","",""},
                {"appSettings","add","autoOrientPrinting","1","Auto-Orient-Printing","false","","",""},
                {"appSettings","add","autoZoomThumbnail","2","Autozoom-Thumbnail-Configuration","local","","",""},
                {"appSettings","add","RetrieveTransaction","1","Enable-Retrieve-Transactions","false","","",""},
                {"appSettings","add","RetrieveTransactionSortByDocId","1","Sort-by-Document-ID","false","","",""},
                {"appSettings","add","AllowSecurityKeywordsAdmin","1","Admin-Security-Keywords","true","","",""},
                {"appSettings","add","WorkflowLayout","2","Default-Workflow-Layout","selectable","","",""},
                {"appSettings","add","enableRowColoring","1","Row-Coloring","false","","",""},
                {"appSettings","add","FolderTreeWidth","2","Folder-Tree-Width","30%","","0","100"},
                {"appSettings","add","FolderTreeHeight","2","Folder-Tree-Height","60%","","0","100"},
                {"appSettings","add","DocumentListHeight","2","Document-List-Height","20%","","0","100"},
                {"appSettings","add","FolderListHeight","2","Folder-List-Height","20%","","0","100"},
                {"appSettings","add","WVMaxResults","2","WorkView-Max-Results","1000","","0",""},
                {"appSettings","add","WVFilterCount","1","WorkView-Filter-Count","false","","",""},
                {"appSettings","add","displayCreatedEForms","1","Display-Created-EForms","true","","",""},
                {"appSettings","add","EnableStandaloneWorkViewClient","1","Enable-Standalone-WorkView-Client","false","","",""},
                {"appSettings","add","WorkViewClientURL","2","WorkView-Client-URL","","","",""},
                {"appSettings","add","sv_AppEnableIntegration","1","Application-Enabler-Integration","false","","",""},
                {"appSettings","add","sv_LaunchAppEnabler","1","Launch-Application-Enabler","false","","",""},
                {"appSettings","add","enableDataMine","1","Data-Mining","false","","",""},
                {"appSettings","add","DataMiningTempDirectory","2","Data-Mining-Temp-Directory","","","",""},
                {"appSettings","add","DataMiningReportServerName","2","Data-Mining-Report-Server-Name","","","",""},
                {"appSettings","add","DataMiningURL","2","Data-Mining-URL","","","",""},
                {"appSettings","add","DataMiningAdditionalModels","2","Additional-Models","","","",""},
                {"appSettings","add","AllowViewSource","1","Allow-View-Source","false","","",""},
                {"appSettings","add","pmCacheLocation","2","Platter-Management-Cache-Location","","","",""},
                {"appSettings","add","pmCacheTimeout","2","Platter-Management-Cache-Timeout","60","","",""},
                {"appSettings","add","pmCacheSize","2","Platter-Management-Cache-Size","500","","",""},
                {"appSettings","add","openOfficeDocumentsInSeparateWindow","1","Open-Microsoft-Office-Documents-in-Separate-Window","true","","",""},
                {"appSettings","add","OpenRTFasMSWord","1","Open-Rich-Text-Format-Documents-With-Microsoft-Word","true","","",""},
                {"appSettings","add","ThumbnailHitListAllowCaching","1","Allow-Caching","false","","",""},
                {"appSettings","add","ThumbnailHitListShowPreviews","1","Show-Previews","false","","",""},
                {"appSettings","add","ThumbnailHitListUserConfigurable","1","User-Configurable","false","","",""},
                {"appSettings","add","ThumbnailHitListColumns","2","Number-of-Columns","3","","",""},
                {"appSettings","add","ThumbnailHitListThumbnailMaxWidth","2","Maximum-Width","50","","",""},
                {"appSettings","add","ThumbnailHitListThumbnailMaxHeight","2","Maximum-Height","50","","",""},
                {"appSettings","add","ThumbnailHitListPreviewMaxWidth","2","Preview-Maxiumum-Width","400","","",""},
                {"appSettings","add","ThumbnailHitListPreviewMaxHeight","2","Preview-Maxiumum-Height","400","","",""},
                {"appSettings","add","UseFolderPopViewer","1","Use-FolderPop-Viewer","true","","",""},
                {"appSettings","add","SLDefaultUsername","2","Silverlight-Default-Username","","","",""},
                {"appSettings","add","SLDefaultPassword","2","Silverlight-Default-Password","","","",""},
                {"appSettings","add","PromptWithUnreadDKTDocs","1","Prompt-with-Unread-DKT-Docs","true","","",""},
                {"appSettings","add","InternalMailTimerSeconds","2","Internal-Mail-Timer-In-Seconds","300","","0",""},
                {"appSettings","add","AllowedFunctionKeyList","2","Allowed-Function-Key-List","","","",""},
                {"appSettings","add","aspnet:MaxJsonDeserializerMembers","2","Max-JSON-Deserialized-Members","40000","","",""},
                {"appSettings","add","ValidationSettings:UnobtrusiveValidationMode","2","Validation-Settings-Unobtrusive-Validation-Mode","None","","",""},
                {"appSettings","add","owin:AutomaticAppStartup","1","OWIN-Automatic-App-Startup","false","","",""},
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
                {"appSettings","add","EnableLegacyChecksumFallback","1","Enabled-Legacy-Checksum-Fallback","false","","",""},
                {"appSettings","add","EnableLoginAutocomplete","1","Enable-Login-Autocomplete","false","","",""},
                {"appSettings","add","WindowsServerLocaleFormat","2","Windows-Server-Locale-Format","","","",""},
                {"appSettings","add","MaxImportQueueSize","2","Maximum-Import-Queue-Size","5","","",""},
                {"appSettings","add","EnableDesktopHost","1","Enable-Desktop-Host","true","","",""},
                {"appSettings","add","EnableBrowserPdfViewer","1","Enable-Browser-PDF-Viewer","true","","",""},
                {"appSettings","add","MultiFormViewerOrigin","2","Multi-Form-Viewer-Origin","[origin]","","",""}
            }
        },
        {
            "Hyland.Web.DashboardViewer", new string[,]
            {
                {"Hyland.Web.DashboardViewer","useTheme","value","2","Use-Theme","light","","",""},
                {"Hyland.Web.DashboardViewer","enableExportDashboard","value","1","Enable-Export-Dashboard","true","","",""},
                {"Hyland.Web.DashboardViewer","enableExportDashboardItems","value","1","Enable-Export-Dashboard-Items","true","","",""},
                {"Hyland.Web.DashboardViewer","reportPagingLimit","value","2","Reporting-Page-Limit","50","","",""}
            }
        },
        {
            "Hyland.Web.HealthcareWebViewer", new string[,]
            {
                {"Hyland.Web.HealthcareWebViewer","sessionTimeout","value","2","Healthcare-Web-Viewer-Session-Timeout","30","","",""},
                {"Hyland.Web.HealthcareWebViewer","datasource","value","2","Healthcare-Web-Viewer-Data-Source","","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableHTTPDataSource","value","1","Healthcare-Web-Viewer-Enable-HTTP-Data-Source","false","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableDeficiencyViewing","value","1","Healthcare-Web-Viewer-Enable-Deficiency-Viewing","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","enablePhysicianAcknowledgment","value","1","Healthcare-Web-Viewer-Enable-Physician-Acknowledgement","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableDocumentCorrection","value","1","Healthcare-Web-Viewer-Enable-Document-Correction","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","readonlyHTMLForms","value","2","Healthcare-Web-Viewer-Read-Only-HTML-Forms","all","","",""},
                {"Hyland.Web.HealthcareWebViewer","readonlyUnityForms","value","2","Healthcare-Web-Viewer-Read-Only-Unity-Forms","all","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableEpicWebViewerApi","value","1","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","epicScanViewerApi/enabled","value","1","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Interoperability-Enabled","false","","",""},
                {"Hyland.Web.HealthcareWebViewer","epicScanViewerApi/displayDocumentFailedTimeout","value","2","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Failed-Timeout","10","","",""},
                {"Hyland.Web.HealthcareWebViewer","epicScanViewerApi/displayDocumentMessageInterval","value","2","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Message-Interval","1","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","sessionState","timeout","2","Session-Timeout","20","","2","1440"},
                {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""},
                {"system.web","authentication","mode","2","Authentication-Mode","Windows","","",""},
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length-KB","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout-Seconds","90","","10",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {
                
            }
        },
        {
            "ADFS", new string[,]
            {

            }
        },
        {
            "NavigationPanel", new string[,]
            {

            }
        },
        {
            "CustomValidation", new string[,]
            {

            }
        }
    };

    /* Version 22.1 Translators */
    private readonly Dictionary<string, string[,]> AgendaOnline221SectionsTranslator = new Dictionary<string, string[,]> {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://localhost/AppServer/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
            }
        },
        {
            "Hyland.Applications.AgendaPubAccess.PublicComment", new string[,]
            {
                
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","StreamChunkSize","2","Stream-Chunk-Size","65536","","",""},
                {"appSettings","add","PlayerSourceFilePath","2","Player-Source-File-Path","../Scripts/jwplayer","","",""},
                {"appSettings","add","PlayerVersion","2","Player-Version","JWPlayer 8.24.6","","",""},
                {"appSettings","add","MinPoolSize","2","Min-Pool-Size","1","","",""},
                {"appSettings","add","MaxPoolSize","2","Max-Pool-Size","5","","",""},
                {"appSettings","add","webpages:Enabled","1","webpages-Enabled","false","","",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> ElectronicPlanReview221SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[server]/[virtual directory]/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","StyleSheetPath","2","Stylesheet-Directory-Location","BasicBlue/","","",""},
                {"appSettings","add","AllowSignon","1","Allow-Sign-On","true","","",""},
                {"appSettings","add","AllowSignoff","1","Allow-Sign-Off","true","","",""},
                {"appSettings","add","DefaultTimeZone","2","Default-User-Time-Zone","64","","",""},
                {"appSettings","add","SearchStartYear","2","Search-Start-Year","2012","","",""},
                {"appSettings","add","DisplayDocumentsPerPage","2","Items-Per-Page","20","","",""},
                {"appSettings","add","MaxLookupResults","2","Max-Lookup-Results","20","","",""},
                {"appSettings","add","ResetPasswordLinkExpiration","2","Reset-Password-Link-Lifetime","60","","",""},
                {"appSettings","add","FileUploadDirectory","2","File-Upload-Directory","~/Upload","","",""},
                {"appSettings","add","FileUploadValidator","2","File-Upload-Validator","","","",""},
                {"appSettings","add","TokenAuthentication","1","Token-Authentication","false","","",""},
                {"appSettings","add","SingleSignOn","1","Allow-Single-Sign-On","false","","",""},
                {"appSettings","add","SingleSignOnSourceID","2","Source-ID","1","","",""},
                {"appSettings","add","SSOUserResolutionMode","2","Resolution-Mode","0","","",""},
                {"appSettings","add","CAPTCHAPublicKey","2","Public-CAPTCHA-Key","","","",""},
                {"appSettings","add","CAPTCHAPrivateKey","2","Private-CAPTCHA-Key","","","",""},
                {"appSettings","add","PasswordStrengthPattern","2","Password-Strength-Pattern","^(?=.{4,}).*$","","",""},
                {"appSettings","add","PasswordStrengthMessage","2","Password-Strength-Message","","","",""},
                {"appSettings","add","UsernameValidationPattern","2","Username-Validation-Pattern","[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+","","",""},
                {"appSettings","add","DisciplineItemsPerMenu","2","Discipline-Items-Per-Menu","15","","",""},
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> GatewayCachingServer221SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://localhost/AppServer/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""},
                {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
                {"Hyland.Services.Client","OptimizedServicePipeline","Enabled","1","Optimized-Service-Pipeline","true","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","gatewayName","2","Gateway-Name","[GATEWAYNAME]","","",""},
                {"appSettings","add","dataSource","2","DataSource","[DATABASENAME]","","",""},
                {"appSettings","add","cachePath","2","Cache-Path","[CACHEPATH]","","",""},
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> HealthcareFormManager221SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[server]/[virtual directory]/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "appSettings", new string[,]
            {
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
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""},
                {"system.web","sessionState","timeout","2","Session-Timeout","20","","2","1440"},
                {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> PatientWindow221SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "appSettings", new string[,]
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
            }
        },
        {
            "Hyland.Authentication", new string[,]
            {
                {"Hyland.Authentication","adfs","enabled","1","ADFS-Enabled","false","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""},
                {"system.web","sessionState","timeout","2","Session-Timeout","20","","2","1440"},
                {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        },
        {
            "ADFS", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> PublicAccessNextGen221SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","EncryptDocId","1","Encrypt-Doc-ID","true","","",""},
                {"appSettings","add","UseDisplayColumns","1","Use-Display-Columns","true","","",""},
                {"appSettings","add","QueryLimit","2","Query-Limit","0","","",""},
                {"appSettings","add","ChunkSize","2","Chunk-Size","512000","","",""},
                {"appSettings","add","ViewerMode","2","Viewer-Mode","PDF","","",""},
                {"appSettings","add","OverlayMode","2","Default-Overlay-Mode","Print","","",""},
                {"appSettings","add","CachePath","2","Cache-Path","C:\\DocCache","","",""},
                {"appSettings","add","ExpireTime","2","Expiration-Time","1","","0",""},
                {"appSettings","add","MaxCacheSize","2","Max-Cache-Size","10","","0",""},
                {"appSettings","add","SizeToCache","2","Size-to-Cache","1","","0",""},
                {"appSettings","add","SizeToPrompt","2","Size-to-Prompt","20","","0",""},
                {"appSettings","add","ThrottleResetTimer","2","Interval-Between-Throttle-Cache-Resets","5","","",""},
                {"appSettings","add","ThrottleThreshold","2","Amount-of-Requests-During-Each-Throttle-Interval","1000","","",""},
                {"appSettings","add","EnableBrowserCaching","1","Enable-Local-Browser-Caching","true","","",""},
                {"appSettings","add","DecorateDocumentNames","1","Decorate-Document-Names","true","","",""}
            }
        },
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://localhost/AppServer/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
                {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","SOAP-Client-Request-Timeout","100","","10",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","100","","10",""}
            }
        },
        {
            "RequiredKeywords", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> ReportingViewer221SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
                {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
                {"Hyland.Services.Client","OptimizedServicePipeline","Enabled","1","Optimized-Service-Pipeline","true","","",""},
                {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","Request-Timeout","300","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
                {"appSettings","add","dmsVirtualRoot","2","Web-Virtual-Directory","http://[HOSTNAME]/[VIRTUAL ROOT]","","",""},
                {"appSettings","add","dmsDataSource","2","Core-Data-Source","[DATASOURCE NAME]","","",""},
                {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""},
                {"appSettings","add","IdPUrl","2","","","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "system.web.extensions", new string[,]
            {
                {"system.web.extensions","scripting/webServices/jsonSerialization","maxJsonLength","2","JSON-Serialization-Max-Length","50000000","","",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> ApplicationServer221SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""},
                {"appSettings","add","dmsdatasource","2","Data-Source","[Datasource]","","",""},
                {"appSettings","add","UseOSAuthentication","1","Use-OS-Authentication","false","","",""},
                {"appSettings","add","DocumentQueryWarningThreshold","2","Document-Query-Warning-Threshold","500","","",""},
                {"appSettings","add","DocumentQueryLimit","2","Document-Query-Limit","2000","","","10000"},
                {"appSettings","add","ItemCacheTimeout","2","Item-Cache-Timeout","60","","",""},
                {"appSettings","add","RawImagesAllowed","1","Raw-Images","true","","",""},
                {"appSettings","add","UseIsolatedImageProcess","1","Use-Isolated-Image-Process","true","","",""},
                {"appSettings","add","CompressionQuality","2","Compression-Quality","70","","",""},
                {"appSettings","add","EnableIsolatedChromiumProcess","1","Enable-Isolated-Chromium-Process","true","","",""},
                {"appSettings","add","FormSaveToTiffTimeout","2","Form-Save-To-TIFF-Timeout","60","","",""},
                {"appSettings","add","PrintImageFormViaPDF","1","Print-Image-Form-Via-PDF","false","","",""},
                {"appSettings","add","TPCFWorkerLocationOverride","2","TPCF-Worker-Location-Override","","","",""},
                {"appSettings","add","DefaultStoragePath","2","Default-Storage-Path","","","",""},
                {"appSettings","add","watchFolder","2","Watch-Folder","","","",""},
                {"appSettings","add","siteIDKeywordType","2","Site-ID-Keyword-Type","Site ID","","",""},
                {"appSettings","add","cleanupTimerInterval","2","Cleanup-Timer-Interval","15","","",""},
                {"appSettings","add","maxFileAgeInHours","2","Max-File-Age","4","","",""},
                {"appSettings","add","ValidateMessageSchema","1","Integrations-EIS-Validate-Message-Schema","true","","",""},
                {"appSettings","add","ContinueOnValidationError","1","Integrations-EIS-Continue-On-Validation-Error","false","","",""},
                {"appSettings","add","DataSetCacheCleanUpIntervalInMins","2","Integrations-EIS-Data-Set-Cache-Cleanup-Interval","60","","",""},
                {"appSettings","add","AppNetDirectory","2","Integrations-EIS-AppNet-Directory","[virtualRoot]","","",""},
                {"appSettings","add","UseHTMLClientType","1","Integrations-EIS-Use-HTML-Client-Type","false","","",""},
                {"appSettings","add","MessageBrokerMonitorStartDelayInMinutes","2","Message-Broker-Monitor-Start-Delay","","","",""},
                {"appSettings","add","GCSUsername","2","GCS-Username","","","",""},
                {"appSettings","add","GCSPassword","2","GCS-Password","","","",""},
                {"appSettings","add","useLegacyKeyForUsageBasedBilling","2","Use-Legacy-Key-For-Usage-Based-Billing","false","","",""},
                {"appSettings","add","GCSPhoneHomeIntervalInMinutes","2","GCS-Phone-Home-Interval","60","","",""},
                {"appSettings","add","DataCaptureServerWCFEndpointAddress","2","Data-Capture-Server-WCF-Endpoint-Address","net.tcp://localhost:9050/Hyland.DataCapture.ServiceManager/service","","",""},
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
                {"appSettings","add","AppServerOrigin","2","OWIN-Application-Server-Origin","[virtualRoot]","","",""},
                {"appSettings","add","owin:AutomaticAppStartup","1","OWIN-Automatic-App-Startup","false","","",""},
                {"appSettings","add","owin:appStartup","2","OWIN-App-Startup","Hyland.Owin.Core.Startup, Hyland.Owin.Core","","",""},
                {"appSettings","add","IdentityModelServerURI","2","Identity-Model-Server-URI","","","",""},
                {"appSettings","add","mobileAppsPath","2","Mobile-Apps-Path","[unc path]","","",""},
                {"appSettings","add","corsPolicy","2","CORS-Policy","*","","",""},
                {"appSettings","add","endpoints:WorkViewMobile","1","WorkView-Mobile-Endpoint","false","","",""},
                {"appSettings","add","endpoints:ResponsiveApps","1","Responsive-Apps-Endpoint","false","","",""},
                {"appSettings","add","endpoints:Wopi","1","WOPI-Endpoint","false","","",""},
                {"appSettings","add","endpoints:Sesame","1","Sesame-Endpoint","false","","",""},
                {"appSettings","add","endpoints:GovernanceRulesAsAService","1","Governance-Rules-As-A-Service-Endpoint","false","","",""},
                {"appSettings","add","endpoints:FHIR","1","Web-BLOB-Passthrough-FHIR-Endpoint","false","","",""},
                {"appSettings","add","SMARTonFHIRApplicationId","2","SMART-On-FHIR-Application-ID","[GUID]","","",""},
                {"appSettings","add","endpoints:PPL","1","PPL-Endpoint-Enabled","false","","",""},
                {"appSettings","add","endpoints:Forms","1","Forms-Endpoint","false","","",""},
                {"appSettings","add","DocPopUrl","2","PPL-DocPop-URL","","","",""},
                {"appSettings","add","StatementCompCacheLimit","2","Statement-Composition-Cache-Limit","","","",""},
                {"appSettings","add","UnityFormsToggleMaxFormWidth","1","Unity-Forms-Toggle-Max-Form-Width","false","","",""},
                {"appSettings","add","owin:oia:msgItemTypeId","2","owin:oia:msgItemTypeId","[Message Item Type ID]","","",""},
                {"appSettings","add","owin:oia:lifeCycleId","2","owin:oia:lifeCycleId","[Lifecycle ID]","","",""},
                {"appSettings","add","owin:oia:tmpFilePath","2","owin:oia:tmpFilePath","[UNC Path]","","",""},
                {"appSettings","add","owin:oia:tmpFileAgeInMs","2","owin:oia:tmpFileAgeInMs","[Temp File Age ms]","","",""},
                {"appSettings","add","owin:oia:cleanupIntervalInMs","2","owin:oia:cleanupIntervalInMs","[Cleanup Interval ms]","","",""},
                {"appSettings","add","UseOnBaseFulltext","1","Use-OnBase-Full-Text","false","","",""},
                {"appSettings","add","ContentComposerIdpPath","2","Content-Composer-IdP-Path","","","",""},
                {"appSettings","add","KeywordDataCacheTimeout","2","Keyword-Data-Cache-Timeout","20","","",""},
                {"appSettings","add","AllowInsecureExternalXsl ","1","Allow-Insecure-External-XSL","false","","",""},
                {"appSettings","add","SB_MaxQueryExecutionParallelism","2","Max-Query-Execution-Parallelism","10","","",""},
                {"appSettings","add","SB_FolderFetchBatchSize","2","Folder-Fetch-Batch-Size","300","","",""},
                {"appSettings","add","SB_DatabaseCommandTimeOut","2","Database-Command-TimeOut","300","","",""}
            }
        },
        {
            "Hyland.ResponsiveApps", new string[,]
            {
                {"Hyland.ResponsiveApps","WorkViewApi","url","2","Responsive-Apps-WorkView-API-URL","https://[Server]/[AppServer]/private/workview/api/","","",""},
                {"Hyland.ResponsiveApps","WorkViewFiles","url","2","Responsive-Apps-WorkView-Files-URL","https://[Server]/[AppServer]/private/workview/files/","","",""},
                {"Hyland.ResponsiveApps","ResponsiveAppsApi","url","2","Responsive-Apps-API-URL","https://[Server]/[AppServer]/private/responsive-apps/api/","","",""},
                {"Hyland.ResponsiveApps","IdentityProvider","url","2","Identity-Provider-URL","https://[Server]/idp/[tenant]/[population]","","",""},
                {"Hyland.ResponsiveApps","CoreAccessTokenLifetime","value","2","Core-Access-Token-Lifetime","691200","","",""}
            }
        },
        {
            "Hyland.PlatterManagement", new string[,]
            {
                {"Hyland.PlatterManagement","Logging/FileIODetail","value","1","File-IO-Detail","false","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/EMCTHRESHOLD","value","2","Foreign-Storage-EMC-Threshold","","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/PmCacheLocation","value","2","Foreign-Storage-PM-Cache-Location","","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/PmCacheTimeout","value","2","Foreign-Storage-PM-Cache-Timeout","","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/PmCacheSize","value","2","Foreign-Storage-PM-Cache-Size","","","",""},
                {"Hyland.PlatterManagement","FileAccess/PMAccessLevel","value","2","PM-File-Access-Level","0","","",""},
                {"Hyland.PlatterManagement","TemporaryFiles/TempFileExpirationThreshold","value","2","Temp-File-Expiration-Threshold-Time","","","",""}
            }
        },
        {
            "Hyland.Services", new string[,]
            {
                {"Hyland.Services","poolSettings","minSessions","2","Hyland-Services-AppPool-Minimum-Sessions","0","","",""},
                {"Hyland.Services","poolSettings","maxSessions","2","Hyland-Services-AppPool-Maximum-Sessions","10","","",""},
                {"Hyland.Services","securitySettings","useQueryContext","1","Use-Query-Context","false","","",""},
                {"Hyland.Services","securitySettings","filterExceptions","1","Filter-Exceptions","true","","",""},
                {"Hyland.Services","Endpoint","useRemoting","1","Endpoint-Use-Remoting","true","","",""},
                {"Hyland.Services","session","enableTimeout","1","Session-Enable-Timeout","false","","",""},
                {"Hyland.Services","applicationServerCallback","url","2","Application-Server-Callback-URL","","","",""},
                {"Hyland.Services","webServerBaseUrl","url","2","Web-Server-Base-URL","","","",""},
                {"Hyland.Services","requestValidation","minVersion","2","Request-Validation-Minimum-Version","0","","",""}
            }
        },
        {
            "Hyland.XMLServices.DocumentConnector", new string[,]
            {
                {"Hyland.XMLServices.DocumentConnector","loginId","name","2","Login-ID","","","",""},
                {"Hyland.XMLServices.DocumentConnector","loginPassword","name","2","Login-Password","","","",""},
                {"Hyland.XMLServices.DocumentConnector","loginDatasource","name","2","Login-Datasource","","","",""},
                {"Hyland.XMLServices.DocumentConnector","pool","min","2","Pool-Min","0","","",""},
                {"Hyland.XMLServices.DocumentConnector","pool","max","2","Pool-Max","5","","",""}
            }
        },
        {
            "Hyland.Core.FullText", new string[,]
            {
                {"Hyland.Core.FullText","SearchTimeout","value","2","Search-Timeout","30","","",""},
                {"Hyland.Core.FullText","SearchLog","enableSearchlog","1","Enable-Search-Log","false","","",""},
                {"Hyland.Core.FullText","SearchLog","path","2","Search-Log-Path","","","",""}
            }
        },
        {
            "Hyland.WorkView.Core", new string[,]
            {
                {"Hyland.WorkView.Core","UnityEditableFilterMaxRows","value","2","Unity-Editable-Filter-Max-Rows","20","","",""},
                {"Hyland.WorkView.Core","ERPDateFormat","value","2","ERP-Date-Format-LOB-Broker","yyyyMMdd","","",""},
                {"Hyland.WorkView.Core","FormattedTextIframeSupportedDomains","value","2","Formatted-Text-Iframe-Supported-Domains","","","",""}
            }
        },
        {
            "Hyland.Core.Wopi", new string[,]
            {
                {"Hyland.Core.Wopi","useOfficeWebAppServer","value","2","Use-Office-Online-Server","false","","",""},
                {"Hyland.Core.Wopi","owaServerUri","value","2","Office-Online-Server-URI","https://[servername]/","","",""},
                {"Hyland.Core.Wopi","owaProxyBase","value","2","Office-Online-Server-Proxy-Base","https://[servername]/[appserver]/private","","",""}
            }
        },
        {
            "Hyland.Integrations.LOBBroker.LOBBrokerConfigSection", new string[,]
            {
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorCacheSearchMinChars","2","Vendor-Cache-Search-Minimum-Characters","1","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorMasterKeyedLookupOp","2","Vendor-Master-Keyed-Lookup-Op","GetVenMasterRecordbyVenIDNCompID","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorMasterLookupSequence","2","Vendor-Master-Lookup-Sequence","GetVenMasterRecordbyVenIDNCompID, GetVenMasterRecordbyPONumNCompID, GetVenMasterRecordbyPhoneNCompID, GetVenMasterRecordbyTaxID, GetVenMasterRecordbyVATID, GetVenMasterRecordbyZipCodeNCompID, GetVenMasterRecordByVenAddressNCompID, GetVenMasterRecordbyWebSiteNCompID, GetVenMasterRecordbyBankAccountNumber, GetVenMasterRecordbyVenNameNCompID","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorMasterLookupReturnMultiple","1","Vendor-Master-Lookup-Return-Multiple","false","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorCacheAutoCompleteResultsMax","2","Vendor-Cache-AutoComplete-Result-Max","30","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","IsEnabled","","1","Enable-LOB-Broker-Accounts-Payable","false","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","Http-Runtime-Maximum-Request-Length","30000","","",""},
                {"system.web","httpRuntime","executionTimeout","2","Http-Runtime-Execution-Timeout","300","","",""},
                {"system.web","sessionState","timeout","2","Session-Timeout-Length","20","","",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "root", new string[,]
            {
                
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        },
        {
            "ADFS", new string[,]
            {

            }
        },
        {
            "Hyland.Authentication", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> WebServer221SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://localhost/appserver/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","remoting","","",""},
                {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","dmsDataSource","2","Core-Data-Source","[DATASOURCE]","","",""},
                {"appSettings","add","dmsVirtualRoot","2","Web-Virtual-Directory","https://[WEB SERVER]/[VIRTUAL ROOT]","","",""},
                {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""},
                {"appSettings","add","default_domainname","2","Default-Domain-Name","","","",""},
                {"appSettings","add","default_username","2","Default-Username","","","",""},
                {"appSettings","add","default_password","2","Default-Password","","","",""},
                {"appSettings","add","default_institution","2","Default-Institution","0","","0",""},
                {"appSettings","add","EnableAutoLogin","1","Autologin","false","","",""},
                {"appSettings","add","IdPUrl","2","","","","",""},
                {"appSettings","add","forceSSOAutoLoginOverDomain","1","Force-OnBase-Authentication","false","","",""},
                {"appSettings","add","CustomSSOAuthenticationFailurePage","2","Custom-SSO-Authentication-Page-Failure","","","",""},
                {"appSettings","add","LogoutClose","1","Close-On-Logout","false","","",""},
                {"appSettings","add","logoutRedirectURL","2","Logout-Redirect-URL","","","",""},
                {"appSettings","add","webtheme","2","Web-Theme","XP","","",""},
                {"appSettings","add","targetPage","2","Target-Page","NavPanel.aspx","","",""},
                {"appSettings","add","loginPage","2","Login-Page","Login.aspx","","",""},
                {"appSettings","add","SPViewerShowWorkflow","1","SharePoint-Viewer-Show-Workflow","false","","",""},
                {"appSettings","add","SharepointOnline","1","SharePoint-Online","false","","",""},
                {"appSettings","add","promptUserQueries","1","Prompt-User-Queries","false","","",""},
                {"appSettings","add","showQueueCounts","1","Show-Queue-Counts","false","","",""},
                {"appSettings","add","reselectDelta","2","Reselect-Delta","15","","",""},
                {"appSettings","add","textSearchAutoView","1","Text-Search-Auto-View","false","","",""},
                {"appSettings","add","MaxResults","2","Max-Results","1000","","",""},
                {"appSettings","add","WorkflowMaxResults","2","Workflow-Max-Results","2000","","",""},
                {"appSettings","add","KeywordPanelViewType","2","Keyword-Panel-View-Type","flat","","",""},
                {"appSettings","add","EnableKeywordOperators","1","Enable-Keyword-Operators","true","","",""},
                {"appSettings","add","EnableSessionExpiration","1","Enable-Session-Expiration","true","","",""},
                {"appSettings","add","PromptOnSessionExpire","1","Prompt-On-Session-Expire","true","","",""},
                {"appSettings","add","displaySingleDocument","1","Display-Single-Document","true","","",""},
                {"appSettings","add","DisplayRelatedDocuments","2","Display-Related-Documents","always","","",""},
                {"appSettings","add","WorkflowUserInteractionHeight","2","Workflow-Height-px","375","","",""},
                {"appSettings","add","ShowCombinedInbox","1","Show-Combined-Inbox","true","","",""},
                {"appSettings","add","OverrideUILanguage","1","Override-UI-Language","false","","",""},
                {"appSettings","add","DefaultUILocale","2","Default-UI-Local","default","","",""},
                {"appSettings","add","enableVirtualPrintDriver","1","Enable-Virtual-Print-Driver","false","","",""},
                {"appSettings","add","autoDisplayNotePanelPDFOffice","1","Auto-Display-Note-Panel-PDF-Office","true","","",""},
                {"appSettings","add","ClearDocumentTypeAfterImport","1","Clear-Document-Type-After-Import","false","","",""},
                {"appSettings","add","ClearKeywordsAfterImport","1","Clear-Keywords-After-Import","false","","",""},
                {"appSettings","add","AlwaysGeneratePreviewAfterUpload","1","Always-Generate-Preview","true","","",""},
                {"appSettings","add","RememberHitListHeight","1","Remember-Hitlist-Height","false","","",""},
                {"appSettings","add","NumDisplayedDocumentTypes","2","Number-of-Docuemnt-Types-to-Display","6","","",""},
                {"appSettings","add","CollapseCheckSelect","1","Collapse-Check-Select-Lists","false","","",""},
                {"appSettings","add","addNoteMenu","1","Add-Note-Menu","true","","",""},
                {"appSettings","add","createDocumentMenu","1","Create-New-Document-Menu","true","","",""},
                {"appSettings","add","documentPropertiesMenu","1","Document-Properties-Menu","true","","",""},
                {"appSettings","add","fileMenu","1","File-Menu","true","","",""},
                {"appSettings","add","historyMenu","1","History-Menu","true","","",""},
                {"appSettings","add","keywordsMenu","1","Keywords-Menu","true","","",""},
                {"appSettings","add","printMenu","1","Print-Menu","true","","",""},
                {"appSettings","add","reindexMenu","1","Reindex-Menu","true","","",""},
                {"appSettings","add","workflowMenu","1","Workflow-Menu","true","","",""},
                {"appSettings","add","sendToPrintQueueMenu","1","Send-To-Print-Queue-Menu","true","","",""},
                {"appSettings","add","clipBoardMenu","1","Clipboard-Menu","true","","",""},
                {"appSettings","add","gotoPageOR","2","Go-To-Page","0","","0",""},
                {"appSettings","add","overlayOR","2","Overlay","","","",""},
                {"appSettings","add","zoomLevelOR","2","Zoom-Level","","","",""},
                {"appSettings","add","rectLeftOR","2","Left-Border","0","","0",""},
                {"appSettings","add","rectRightOR","2","Right-Border","0","","0",""},
                {"appSettings","add","rectTopOR","2","Top-Border","0","","0",""},
                {"appSettings","add","rectBottomOR","2","Bottom-Border","0","","0",""},
                {"appSettings","add","enableAnnotationToolbar","1","Annotation-Toolbar","true","","",""},
                {"appSettings","add","enableNoteToolbar","1","Notes-Toolbar","true","","",""},
                {"appSettings","add","enableThumbnailPages","1","Thumbnail-Pages","true","","",""},
                {"appSettings","add","enableViewerControlToolbar","1","Viewer-Control-Toolbar","true","","",""},
                {"appSettings","add","DisableContextMenu","1","Disable-Context-Menu","false","","",""},
                {"appSettings","add","PathFormProc","2","Path-Form-Proc","/FormProc.ashx","","",""},
                {"appSettings","add","PathPrint","2","Path-Print","/PrintHandler.ashx","","",""},
                {"appSettings","add","PreventViewerClientCaching","1","Prevent-Viewer-Client-Caching","false","","",""},
                {"appSettings","add","RetrieveTransaction","1","Enable-Retrieve-Transactions","false","","",""},
                {"appSettings","add","RetrieveTransactionSortByDocId","1","Sort-by-Document-ID","false","","",""},
                {"appSettings","add","AllowSecurityKeywordsAdmin","1","Admin-Security-Keywords","true","","",""},
                {"appSettings","add","WorkflowLayout","2","Default-Workflow-Layout","selectable","","",""},
                {"appSettings","add","enableRowColoring","1","Row-Coloring","false","","",""},
                {"appSettings","add","FolderTreeWidth","2","Folder-Tree-Width","30%","","0","100"},
                {"appSettings","add","FolderTreeHeight","2","Folder-Tree-Height","60%","","0","100"},
                {"appSettings","add","DocumentListHeight","2","Document-List-Height","20%","","0","100"},
                {"appSettings","add","FolderListHeight","2","Folder-List-Height","20%","","0","100"},
                {"appSettings","add","WVMaxResults","2","WorkView-Max-Results","1000","","0",""},
                {"appSettings","add","WVFilterCount","1","WorkView-Filter-Count","false","","",""},
                {"appSettings","add","displayCreatedEForms","1","Display-Created-EForms","true","","",""},
                {"appSettings","add","EnableStandaloneWorkViewClient","1","Enable-Standalone-WorkView-Client","false","","",""},
                {"appSettings","add","WorkViewClientURL","2","WorkView-Client-URL","","","",""},
                {"appSettings","add","sv_AppEnableIntegration","1","Application-Enabler-Integration","false","","",""},
                {"appSettings","add","sv_LaunchAppEnabler","1","Launch-Application-Enabler","false","","",""},
                {"appSettings","add","enableDataMine","1","Data-Mining","false","","",""},
                {"appSettings","add","DataMiningTempDirectory","2","Data-Mining-Temp-Directory","","","",""},
                {"appSettings","add","DataMiningReportServerName","2","Data-Mining-Report-Server-Name","","","",""},
                {"appSettings","add","DataMiningURL","2","Data-Mining-URL","","","",""},
                {"appSettings","add","DataMiningAdditionalModels","2","Additional-Models","","","",""},
                {"appSettings","add","AllowViewSource","1","Allow-View-Source","false","","",""},
                {"appSettings","add","pmCacheLocation","2","Platter-Management-Cache-Location","","","",""},
                {"appSettings","add","pmCacheTimeout","2","Platter-Management-Cache-Timeout","60","","",""},
                {"appSettings","add","pmCacheSize","2","Platter-Management-Cache-Size","500","","",""},
                {"appSettings","add","OpenRTFasMSWord","1","Open-Rich-Text-Format-Documents-With-Microsoft-Word","true","","",""},
                {"appSettings","add","ThumbnailHitListAllowCaching","1","Allow-Caching","false","","",""},
                {"appSettings","add","ThumbnailHitListShowPreviews","1","Show-Previews","false","","",""},
                {"appSettings","add","ThumbnailHitListUserConfigurable","1","User-Configurable","false","","",""},
                {"appSettings","add","ThumbnailHitListColumns","2","Number-of-Columns","3","","",""},
                {"appSettings","add","ThumbnailHitListThumbnailMaxWidth","2","Maximum-Width","50","","",""},
                {"appSettings","add","ThumbnailHitListThumbnailMaxHeight","2","Maximum-Height","50","","",""},
                {"appSettings","add","ThumbnailHitListPreviewMaxWidth","2","Preview-Maxiumum-Width","400","","",""},
                {"appSettings","add","ThumbnailHitListPreviewMaxHeight","2","Preview-Maxiumum-Height","400","","",""},
                {"appSettings","add","UseFolderPopViewer","1","Use-FolderPop-Viewer","true","","",""},
                {"appSettings","add","PromptWithUnreadDKTDocs","1","Prompt-with-Unread-DKT-Docs","true","","",""},
                {"appSettings","add","InternalMailTimerSeconds","2","Internal-Mail-Timer-In-Seconds","300","","0",""},
                {"appSettings","add","AllowedFunctionKeyList","2","Allowed-Function-Key-List","","","",""},
                {"appSettings","add","aspnet:MaxJsonDeserializerMembers","2","Max-JSON-Deserialized-Members","40000","","",""},
                {"appSettings","add","ValidationSettings:UnobtrusiveValidationMode","2","Validation-Settings-Unobtrusive-Validation-Mode","None","","",""},
                {"appSettings","add","owin:AutomaticAppStartup","1","OWIN-Automatic-App-Startup","false","","",""},
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
                {"appSettings","add","EnableLegacyChecksumFallback","1","Enabled-Legacy-Checksum-Fallback","false","","",""},
                {"appSettings","add","EnableLoginAutocomplete","1","Enable-Login-Autocomplete","false","","",""},
                {"appSettings","add","WindowsServerLocaleFormat","2","Windows-Server-Locale-Format","","","",""},
                {"appSettings","add","MaxImportQueueSize","2","Maximum-Import-Queue-Size","5","","",""},
                {"appSettings","add","EnableBrowserPdfViewer","1","Enable-Browser-PDF-Viewer","true","","",""},
                {"appSettings","add","pingTimerForScanServiceInSeconds","2","Ping-Timer-For-Scan-Service","10","","",""}
            }
        },
        {
            "Hyland.Web.DashboardViewer", new string[,]
            {
                {"Hyland.Web.DashboardViewer","useTheme","value","2","Use-Theme","light","","",""},
                {"Hyland.Web.DashboardViewer","enableExportDashboard","value","1","Enable-Export-Dashboard","true","","",""},
                {"Hyland.Web.DashboardViewer","enableExportDashboardItems","value","1","Enable-Export-Dashboard-Items","true","","",""},
                {"Hyland.Web.DashboardViewer","reportPagingLimit","value","2","Reporting-Page-Limit","50","","",""}
                //{"Hyland.Web.DashboardViewer","dashboardCacheTimeoutSeconds","value","2","Dashboard-Cache-Timeout","2","","",""}
            }
        },
        {
            "Hyland.Web.HealthcareWebViewer", new string[,]
            {
                {"Hyland.Web.HealthcareWebViewer","sessionTimeout","value","2","Healthcare-Web-Viewer-Session-Timeout","30","","",""},
                {"Hyland.Web.HealthcareWebViewer","datasource","value","2","Healthcare-Web-Viewer-Data-Source","","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableHTTPDataSource","value","1","Healthcare-Web-Viewer-Enable-HTTP-Data-Source","false","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableDeficiencyViewing","value","1","Healthcare-Web-Viewer-Enable-Deficiency-Viewing","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","enablePhysicianAcknowledgment","value","1","Healthcare-Web-Viewer-Enable-Physician-Acknowledgement","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableDocumentCorrection","value","1","Healthcare-Web-Viewer-Enable-Document-Correction","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","readonlyHTMLForms","value","2","Healthcare-Web-Viewer-Read-Only-HTML-Forms","all","","",""},
                {"Hyland.Web.HealthcareWebViewer","readonlyUnityForms","value","2","Healthcare-Web-Viewer-Read-Only-Unity-Forms","all","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableEpicWebViewerApi","value","1","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","epicScanViewerApi/enabled","value","1","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Interoperability-Enabled","false","","",""},
                {"Hyland.Web.HealthcareWebViewer","epicScanViewerApi/displayDocumentFailedTimeout","value","2","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Failed-Timeout","10","","",""},
                {"Hyland.Web.HealthcareWebViewer","epicScanViewerApi/displayDocumentMessageInterval","value","2","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Message-Interval","1","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","sessionState","timeout","2","Session-Timeout","20","","2","1440"},
                {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""},
                {"system.web","authentication","mode","2","Authentication-Mode","Windows","","",""},
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length-KB","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout-Seconds","90","","10",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        },
        {
            "ADFS", new string[,]
            {

            }
        },
        {
            "NavigationPanel", new string[,]
            {

            }
        },
        {
            "CustomValidation", new string[,]
            {

            }
        }
    };

    /* Version 23.1 Translators */
    private readonly Dictionary<string, string[,]> AgendaOnline231SectionsTranslator = new Dictionary<string, string[,]> {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://localhost/AppServer/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
            }
        },
        {
            "Hyland.Applications.AgendaPubAccess.PublicComment", new string[,]
            {
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","StreamChunkSize","2","Stream-Chunk-Size","65536","","",""},
                {"appSettings","add","PlayerSourceFilePath","2","Player-Source-File-Path","../Scripts/jwplayer","","",""},
                {"appSettings","add","PlayerVersion","2","Player-Version","JWPlayer 8.24.6","","",""},
                {"appSettings","add","MinPoolSize","2","Min-Pool-Size","1","","",""},
                {"appSettings","add","MaxPoolSize","2","Max-Pool-Size","5","","",""},
                {"appSettings","add","webpages:Enabled","1","webpages-Enabled","false","","",""},
                {"appSettings","add","GoogleAnalytics","2","Google-Analytics","","","",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> ElectronicPlanReview231SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[server]/[virtual directory]/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","StyleSheetPath","2","Stylesheet-Directory-Location","BasicBlue/","","",""},
                {"appSettings","add","AllowSignon","1","Allow-Sign-On","true","","",""},
                {"appSettings","add","AllowSignoff","1","Allow-Sign-Off","true","","",""},
                {"appSettings","add","DefaultTimeZone","2","Default-User-Time-Zone","64","","",""},
                {"appSettings","add","SearchStartYear","2","Search-Start-Year","2012","","",""},
                {"appSettings","add","DisplayDocumentsPerPage","2","Items-Per-Page","20","","",""},
                {"appSettings","add","MaxLookupResults","2","Max-Lookup-Results","20","","",""},
                {"appSettings","add","ResetPasswordLinkExpiration","2","Reset-Password-Link-Lifetime","60","","",""},
                {"appSettings","add","FileUploadDirectory","2","File-Upload-Directory","~/Upload","","",""},
                {"appSettings","add","FileUploadValidator","2","File-Upload-Validator","","","",""},
                {"appSettings","add","TokenAuthentication","1","Token-Authentication","false","","",""},
                {"appSettings","add","SingleSignOn","1","Allow-Single-Sign-On","false","","",""},
                {"appSettings","add","SingleSignOnSourceID","2","Source-ID","1","","",""},
                {"appSettings","add","SSOUserResolutionMode","2","Resolution-Mode","0","","",""},
                {"appSettings","add","CAPTCHAPublicKey","2","Public-CAPTCHA-Key","","","",""},
                {"appSettings","add","CAPTCHAPrivateKey","2","Private-CAPTCHA-Key","","","",""},
                {"appSettings","add","PasswordStrengthPattern","2","Password-Strength-Pattern","^(?=.{4,}).*$","","",""},
                {"appSettings","add","PasswordStrengthMessage","2","Password-Strength-Message","","","",""},
                {"appSettings","add","UsernameValidationPattern","2","Username-Validation-Pattern","[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+","","",""},
                {"appSettings","add","DisciplineItemsPerMenu","2","Discipline-Items-Per-Menu","15","","",""},
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> GatewayCachingServer231SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://localhost/AppServer/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""},
                {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
                {"Hyland.Services.Client","OptimizedServicePipeline","Enabled","1","Optimized-Service-Pipeline","true","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","gatewayName","2","Gateway-Name","[GATEWAYNAME]","","",""},
                {"appSettings","add","dataSource","2","DataSource","[DATABASENAME]","","",""},
                {"appSettings","add","cachePath","2","Cache-Path","[CACHEPATH]","","",""},
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> HealthcareFormManager231SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[server]/[virtual directory]/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "appSettings", new string[,]
            {
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
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""},
                {"system.web","sessionState","timeout","2","Session-Timeout","20","","2","1440"},
                {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> PatientWindow231SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "appSettings", new string[,]
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
            }
        },
        {
            "Hyland.Authentication", new string[,]
            {
                {"Hyland.Authentication","adfs","enabled","1","ADFS-Enabled","false","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""},
                {"system.web","sessionState","timeout","2","Session-Timeout","20","","2","1440"},
                {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""}
            }
        },
        {
            "system.web.extensions", new string[,]
            {
                {"system.web.extensions","scripting/webServices/jsonSerialization","maxJsonLength","2","JSON-Serialization-Max-Length","2097152","","",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        },
        {
            "ADFS", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> PublicAccessNextGen231SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","EncryptDocId","1","Encrypt-Doc-ID","true","","",""},
                {"appSettings","add","UseDisplayColumns","1","Use-Display-Columns","true","","",""},
                {"appSettings","add","QueryLimit","2","Query-Limit","0","","",""},
                {"appSettings","add","ChunkSize","2","Chunk-Size","512000","","",""},
                {"appSettings","add","ViewerMode","2","Viewer-Mode","PDF","","",""},
                {"appSettings","add","OverlayMode","2","Default-Overlay-Mode","Print","","",""},
                {"appSettings","add","CachePath","2","Cache-Path","C:\\DocCache","","",""},
                {"appSettings","add","ExpireTime","2","Expiration-Time","1","","0",""},
                {"appSettings","add","MaxCacheSize","2","Max-Cache-Size","10","","0",""},
                {"appSettings","add","SizeToCache","2","Size-to-Cache","1","","0",""},
                {"appSettings","add","SizeToPrompt","2","Size-to-Prompt","20","","0",""},
                {"appSettings","add","ThrottleResetTimer","2","Interval-Between-Throttle-Cache-Resets","5","","",""},
                {"appSettings","add","ThrottleThreshold","2","Amount-of-Requests-During-Each-Throttle-Interval","1000","","",""},
                {"appSettings","add","EnableBrowserCaching","1","Enable-Local-Browser-Caching","true","","",""},
                {"appSettings","add","DecorateDocumentNames","1","Decorate-Document-Names","true","","",""},
                {"appSettings","add","AlwaysWildcardAlphanumericKeywords","1","Always-Wildcard-Alphanumeric-Keywords","false","","",""}
            }
        },
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://localhost/AppServer/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
                {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","SOAP-Client-Request-Timeout","100","","10",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","100","","10",""}
            }
        },
        {
            "RequiredKeywords", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> ReportingViewer231SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
                {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
                {"Hyland.Services.Client","OptimizedServicePipeline","Enabled","1","Optimized-Service-Pipeline","true","","",""},
                {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","Request-Timeout","300","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
                {"appSettings","add","dmsVirtualRoot","2","Web-Virtual-Directory","http://[HOSTNAME]/[VIRTUAL ROOT]","","",""},
                {"appSettings","add","dmsDataSource","2","Core-Data-Source","[DATASOURCE NAME]","","",""},
                {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""},
                {"appSettings","add","IdPUrl","2","","","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "system.web.extensions", new string[,]
            {
                {"system.web.extensions","scripting/webServices/jsonSerialization","maxJsonLength","2","JSON-Serialization-Max-Length","50000000","","",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> ApplicationServer231SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""},
                {"appSettings","add","dmsdatasource","2","Data-Source","[Datasource]","","",""},
                {"appSettings","add","UseOSAuthentication","1","Use-OS-Authentication","false","","",""},
                {"appSettings","add","DocumentQueryWarningThreshold","2","Document-Query-Warning-Threshold","500","","",""},
                {"appSettings","add","DocumentQueryLimit","2","Document-Query-Limit","2000","","","10000"},
                {"appSettings","add","ItemCacheTimeout","2","Item-Cache-Timeout","60","","",""},
                {"appSettings","add","RawImagesAllowed","1","Raw-Images","true","","",""},
                {"appSettings","add","UseIsolatedImageProcess","1","Use-Isolated-Image-Process","true","","",""},
                {"appSettings","add","CompressionQuality","2","Compression-Quality","70","","",""},
                {"appSettings","add","EnableIsolatedChromiumProcess","1","Enable-Isolated-Chromium-Process","true","","",""},
                {"appSettings","add","FormSaveToTiffTimeout","2","Form-Save-To-TIFF-Timeout","60","","",""},
                {"appSettings","add","PrintImageFormViaPDF","1","Print-Image-Form-Via-PDF","false","","",""},
                {"appSettings","add","TPCFWorkerLocationOverride","2","TPCF-Worker-Location-Override","","","",""},
                {"appSettings","add","DefaultStoragePath","2","Default-Storage-Path","","","",""},
                {"appSettings","add","watchFolder","2","Watch-Folder","","","",""},
                {"appSettings","add","siteIDKeywordType","2","Site-ID-Keyword-Type","Site ID","","",""},
                {"appSettings","add","cleanupTimerInterval","2","Cleanup-Timer-Interval","15","","",""},
                {"appSettings","add","maxFileAgeInHours","2","Max-File-Age","4","","",""},
                {"appSettings","add","ValidateMessageSchema","1","Integrations-EIS-Validate-Message-Schema","true","","",""},
                {"appSettings","add","ContinueOnValidationError","1","Integrations-EIS-Continue-On-Validation-Error","false","","",""},
                {"appSettings","add","DataSetCacheCleanUpIntervalInMins","2","Integrations-EIS-Data-Set-Cache-Cleanup-Interval","60","","",""},
                {"appSettings","add","AppNetDirectory","2","Integrations-EIS-AppNet-Directory","[virtualRoot]","","",""},
                {"appSettings","add","MessageBrokerMonitorStartDelayInMinutes","2","Message-Broker-Monitor-Start-Delay","","","",""},
                {"appSettings","add","GCSUsername","2","GCS-Username","","","",""},
                {"appSettings","add","GCSPassword","2","GCS-Password","","","",""},
                {"appSettings","add","useLegacyKeyForUsageBasedBilling","2","Use-Legacy-Key-For-Usage-Based-Billing","false","","",""},
                {"appSettings","add","GCSPhoneHomeIntervalInMinutes","2","GCS-Phone-Home-Interval","60","","",""},
                {"appSettings","add","DataCaptureServerWCFEndpointAddress","2","Data-Capture-Server-WCF-Endpoint-Address","net.tcp://localhost:9050/Hyland.DataCapture.ServiceManager/service","","",""},
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
                {"appSettings","add","AppServerOrigin","2","OWIN-Application-Server-Origin","[virtualRoot]","","",""},
                {"appSettings","add","owin:AutomaticAppStartup","1","OWIN-Automatic-App-Startup","false","","",""},
                {"appSettings","add","owin:appStartup","2","OWIN-App-Startup","Hyland.Owin.Core.Startup, Hyland.Owin.Core","","",""},
                {"appSettings","add","IdentityModelServerURI","2","Identity-Model-Server-URI","","","",""},
                {"appSettings","add","mobileAppsPath","2","Mobile-Apps-Path","[unc path]","","",""},
                {"appSettings","add","corsPolicy","2","CORS-Policy","*","","",""},
                {"appSettings","add","endpoints:WorkViewMobile","1","WorkView-Mobile-Endpoint","false","","",""},
                {"appSettings","add","endpoints:ResponsiveApps","1","Responsive-Apps-Endpoint","false","","",""},
                {"appSettings","add","endpoints:Wopi","1","WOPI-Endpoint","false","","",""},
                {"appSettings","add","endpoints:Sesame","1","Sesame-Endpoint","false","","",""},
                {"appSettings","add","endpoints:GovernanceRulesAsAService","1","Governance-Rules-As-A-Service-Endpoint","false","","",""},
                {"appSettings","add","endpoints:FHIR","1","Web-BLOB-Passthrough-FHIR-Endpoint","false","","",""},
                {"appSettings","add","SMARTonFHIRApplicationId","2","SMART-On-FHIR-Application-ID","[GUID]","","",""},
                {"appSettings","add","endpoints:PPL","1","PPL-Endpoint-Enabled","false","","",""},
                {"appSettings","add","endpoints:Forms","1","Forms-Endpoint","false","","",""},
                {"appSettings","add","DocPopUrl","2","PPL-DocPop-URL","","","",""},
                {"appSettings","add","StatementCompCacheLimit","2","Statement-Composition-Cache-Limit","","","",""},
                {"appSettings","add","UnityFormsToggleMaxFormWidth","1","Unity-Forms-Toggle-Max-Form-Width","false","","",""},
                {"appSettings","add","owin:oia:msgItemTypeId","2","owin:oia:msgItemTypeId","[Message Item Type ID]","","",""},
                {"appSettings","add","owin:oia:lifeCycleId","2","owin:oia:lifeCycleId","[Lifecycle ID]","","",""},
                {"appSettings","add","owin:oia:tmpFilePath","2","owin:oia:tmpFilePath","[UNC Path]","","",""},
                {"appSettings","add","owin:oia:tmpFileAgeInMs","2","owin:oia:tmpFileAgeInMs","[Temp File Age ms]","","",""},
                {"appSettings","add","owin:oia:cleanupIntervalInMs","2","owin:oia:cleanupIntervalInMs","[Cleanup Interval ms]","","",""},
                {"appSettings","add","UseOnBaseFulltext","1","Use-OnBase-Full-Text","false","","",""},
                {"appSettings","add","ContentComposerIdpPath","2","Content-Composer-IdP-Path","","","",""},
                {"appSettings","add","KeywordDataCacheTimeout","2","Keyword-Data-Cache-Timeout","20","","",""},
                {"appSettings","add","AllowInsecureExternalXsl ","1","Allow-Insecure-External-XSL","false","","",""},
                {"appSettings","add","SB_MaxQueryExecutionParallelism","2","Max-Query-Execution-Parallelism","10","","",""},
                {"appSettings","add","SB_FolderFetchBatchSize","2","Folder-Fetch-Batch-Size","300","","",""},
                {"appSettings","add","SB_DatabaseCommandTimeOut","2","Database-Command-TimeOut","300","","",""},
                {"appSettings","add","DocLinkerSMARTonFHIRApplicationId","2","Doc-Linker-SMART-On-FHIR-Application-ID","[GUID]","","",""},
                {"appSettings","add","UseNewKeywordDataCacheImplementation","1","Use-New-Keyword-Data-Cache-Implementation","false","","",""},
                {"appSettings","add","ConfigurationImport_DatabaseTimeout","2","Configuration-Import-Database-Timeout","300","","",""},
                {"appSettings","add","PIM:HyRCS:ExternalBaseUri","2","PIM:HyRCS:ExternalBaseUri","","","",""},
                {"appSettings","add","PIM:HyRCS:Port","2","PIM:HyRCS:Port","","","",""},
                {"appSettings","add","PIM:ImageProcess","1","PIM:ImageProcess","false","","",""},
                {"appSettings","add","PIM:ChromiumProcess","1","PIM:ChromiumProcess","false","","",""},
                {"appSettings","add","HyRCS:PageCountLimit","2","HyRCS:PageCountLimit","10000","","",""}
            }
        },
        {
            "Hyland.ResponsiveApps", new string[,]
            {
                {"Hyland.ResponsiveApps","WorkViewApi","url","2","Responsive-Apps-WorkView-API-URL","https://[Server]/[AppServer]/private/workview/api/","","",""},
                {"Hyland.ResponsiveApps","WorkViewFiles","url","2","Responsive-Apps-WorkView-Files-URL","https://[Server]/[AppServer]/private/workview/files/","","",""},
                {"Hyland.ResponsiveApps","ResponsiveAppsApi","url","2","Responsive-Apps-API-URL","https://[Server]/[AppServer]/private/responsive-apps/api/","","",""},
                {"Hyland.ResponsiveApps","IdentityProvider","url","2","Identity-Provider-URL","https://[Server]/idp/[tenant]/[population]","","",""},
                {"Hyland.ResponsiveApps","CoreAccessTokenLifetime","value","2","Core-Access-Token-Lifetime","691200","","",""}
            }
        },
        {
            "Hyland.PlatterManagement", new string[,]
            {
                {"Hyland.PlatterManagement","Logging/FileIODetail","value","1","File-IO-Detail","false","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/EMCTHRESHOLD","value","2","Foreign-Storage-EMC-Threshold","","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/PmCacheLocation","value","2","Foreign-Storage-PM-Cache-Location","","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/PmCacheTimeout","value","2","Foreign-Storage-PM-Cache-Timeout","","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/PmCacheSize","value","2","Foreign-Storage-PM-Cache-Size","","","",""},
                {"Hyland.PlatterManagement","FileAccess/PMAccessLevel","value","2","PM-File-Access-Level","0","","",""},
                {"Hyland.PlatterManagement","TemporaryFiles/TempFileExpirationThreshold","value","2","Temp-File-Expiration-Threshold-Time","","","",""}
            }
        },
        {
            "Hyland.Services", new string[,]
            {
                {"Hyland.Services","poolSettings","minSessions","2","Hyland-Services-AppPool-Minimum-Sessions","0","","",""},
                {"Hyland.Services","poolSettings","maxSessions","2","Hyland-Services-AppPool-Maximum-Sessions","10","","",""},
                {"Hyland.Services","securitySettings","useQueryContext","1","Use-Query-Context","false","","",""},
                {"Hyland.Services","securitySettings","filterExceptions","1","Filter-Exceptions","true","","",""},
                {"Hyland.Services","Endpoint","useRemoting","1","Endpoint-Use-Remoting","true","","",""},
                {"Hyland.Services","session","enableTimeout","1","Session-Enable-Timeout","false","","",""},
                {"Hyland.Services","applicationServerCallback","url","2","Application-Server-Callback-URL","","","",""},
                {"Hyland.Services","webServerBaseUrl","url","2","Web-Server-Base-URL","","","",""},
                {"Hyland.Services","requestValidation","minVersion","2","Request-Validation-Minimum-Version","0","","",""}
            }
        },
        {
            "Hyland.XMLServices.DocumentConnector", new string[,]
            {
                {"Hyland.XMLServices.DocumentConnector","loginId","name","2","Login-ID","","","",""},
                {"Hyland.XMLServices.DocumentConnector","loginPassword","name","2","Login-Password","","","",""},
                {"Hyland.XMLServices.DocumentConnector","loginDatasource","name","2","Login-Datasource","","","",""},
                {"Hyland.XMLServices.DocumentConnector","pool","min","2","Pool-Min","0","","",""},
                {"Hyland.XMLServices.DocumentConnector","pool","max","2","Pool-Max","5","","",""}
            }
        },
        {
            "Hyland.Core.FullText", new string[,]
            {
                {"Hyland.Core.FullText","SearchTimeout","value","2","Search-Timeout","30","","",""},
                {"Hyland.Core.FullText","SearchLog","enableSearchlog","1","Enable-Search-Log","false","","",""},
                {"Hyland.Core.FullText","SearchLog","path","2","Search-Log-Path","","","",""}
            }
        },
        {
            "Hyland.WorkView.Core", new string[,]
            {
                {"Hyland.WorkView.Core","UnityEditableFilterMaxRows","value","2","Unity-Editable-Filter-Max-Rows","20","","",""},
                {"Hyland.WorkView.Core","ERPDateFormat","value","2","ERP-Date-Format-LOB-Broker","yyyyMMdd","","",""},
                {"Hyland.WorkView.Core","FormattedTextIframeSupportedDomains","value","2","Formatted-Text-Iframe-Supported-Domains","","","",""}
            }
        },
        {
            "Hyland.Core.Wopi", new string[,]
            {
                {"Hyland.Core.Wopi","useOfficeWebAppServer","value","2","Use-Office-Online-Server","false","","",""},
                {"Hyland.Core.Wopi","owaServerUri","value","2","Office-Online-Server-URI","https://[servername]/","","",""},
                {"Hyland.Core.Wopi","owaProxyBase","value","2","Office-Online-Server-Proxy-Base","https://[servername]/[appserver]/private","","",""}
            }
        },
        {
            "Hyland.Integrations.LOBBroker.LOBBrokerConfigSection", new string[,]
            {
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorCacheSearchMinChars","2","Vendor-Cache-Search-Minimum-Characters","1","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorMasterKeyedLookupOp","2","Vendor-Master-Keyed-Lookup-Op","GetVenMasterRecordbyVenIDNCompID","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorMasterLookupSequence","2","Vendor-Master-Lookup-Sequence","GetVenMasterRecordbyVenIDNCompID, GetVenMasterRecordbyPONumNCompID, GetVenMasterRecordbyPhoneNCompID, GetVenMasterRecordbyTaxID, GetVenMasterRecordbyVATID, GetVenMasterRecordbyZipCodeNCompID, GetVenMasterRecordByVenAddressNCompID, GetVenMasterRecordbyWebSiteNCompID, GetVenMasterRecordbyBankAccountNumber, GetVenMasterRecordbyVenNameNCompID","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorMasterLookupReturnMultiple","1","Vendor-Master-Lookup-Return-Multiple","false","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorCacheAutoCompleteResultsMax","2","Vendor-Cache-AutoComplete-Result-Max","30","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","IsEnabled","","1","Enable-LOB-Broker-Accounts-Payable","false","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","Http-Runtime-Maximum-Request-Length","30000","","",""},
                {"system.web","httpRuntime","executionTimeout","2","Http-Runtime-Execution-Timeout","300","","",""},
                {"system.web","sessionState","timeout","2","Session-Timeout-Length","20","","",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "root", new string[,]
            {
                
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        },
        {
            "ADFS", new string[,]
            {

            }
        },
        {
            "Hyland.Authentication", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> WebServer231SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://localhost/appserver/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","remoting","","",""},
                {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","dmsDataSource","2","Core-Data-Source","[DATASOURCE]","","",""},
                {"appSettings","add","dmsVirtualRoot","2","Web-Virtual-Directory","https://[WEB SERVER]/[VIRTUAL ROOT]","","",""},
                {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""},
                {"appSettings","add","default_domainname","2","Default-Domain-Name","","","",""},
                {"appSettings","add","default_username","2","Default-Username","","","",""},
                {"appSettings","add","default_password","2","Default-Password","","","",""},
                {"appSettings","add","default_institution","2","Default-Institution","0","","0",""},
                {"appSettings","add","EnableAutoLogin","1","Autologin","false","","",""},
                {"appSettings","add","IdPUrl","2","","","","",""},
                {"appSettings","add","forceSSOAutoLoginOverDomain","1","Force-OnBase-Authentication","false","","",""},
                {"appSettings","add","CustomSSOAuthenticationFailurePage","2","Custom-SSO-Authentication-Page-Failure","","","",""},
                {"appSettings","add","LogoutClose","1","Close-On-Logout","false","","",""},
                {"appSettings","add","logoutRedirectURL","2","Logout-Redirect-URL","","","",""},
                {"appSettings","add","webtheme","2","Web-Theme","XP","","",""},
                {"appSettings","add","targetPage","2","Target-Page","NavPanel.aspx","","",""},
                {"appSettings","add","loginPage","2","Login-Page","Login.aspx","","",""},
                {"appSettings","add","SPViewerShowWorkflow","1","SharePoint-Viewer-Show-Workflow","false","","",""},
                {"appSettings","add","SharepointOnline","1","SharePoint-Online","false","","",""},
                {"appSettings","add","promptUserQueries","1","Prompt-User-Queries","false","","",""},
                {"appSettings","add","showQueueCounts","1","Show-Queue-Counts","false","","",""},
                {"appSettings","add","textSearchAutoView","1","Text-Search-Auto-View","false","","",""},
                {"appSettings","add","MaxResults","2","Max-Results","1000","","",""},
                {"appSettings","add","WorkflowMaxResults","2","Workflow-Max-Results","2000","","",""},
                {"appSettings","add","KeywordPanelViewType","2","Keyword-Panel-View-Type","flat","","",""},
                {"appSettings","add","EnableKeywordOperators","1","Enable-Keyword-Operators","true","","",""},
                {"appSettings","add","EnableSessionExpiration","1","Enable-Session-Expiration","true","","",""},
                {"appSettings","add","PromptOnSessionExpire","1","Prompt-On-Session-Expire","true","","",""},
                {"appSettings","add","displaySingleDocument","1","Display-Single-Document","true","","",""},
                {"appSettings","add","DisplayRelatedDocuments","2","Display-Related-Documents","always","","",""},
                {"appSettings","add","WorkflowUserInteractionHeight","2","Workflow-Height-px","375","","",""},
                {"appSettings","add","ShowCombinedInbox","1","Show-Combined-Inbox","true","","",""},
                {"appSettings","add","OverrideUILanguage","1","Override-UI-Language","false","","",""},
                {"appSettings","add","DefaultUILocale","2","Default-UI-Local","default","","",""},
                {"appSettings","add","enableVirtualPrintDriver","1","Enable-Virtual-Print-Driver","false","","",""},
                {"appSettings","add","autoDisplayNotePanelPDFOffice","1","Auto-Display-Note-Panel-PDF-Office","true","","",""},
                {"appSettings","add","ClearDocumentTypeAfterImport","1","Clear-Document-Type-After-Import","false","","",""},
                {"appSettings","add","ClearKeywordsAfterImport","1","Clear-Keywords-After-Import","false","","",""},
                {"appSettings","add","AlwaysGeneratePreviewAfterUpload","1","Always-Generate-Preview","true","","",""},
                {"appSettings","add","RememberHitListHeight","1","Remember-Hitlist-Height","false","","",""},
                {"appSettings","add","NumDisplayedDocumentTypes","2","Number-of-Docuemnt-Types-to-Display","6","","",""},
                {"appSettings","add","CollapseCheckSelect","1","Collapse-Check-Select-Lists","false","","",""},
                {"appSettings","add","addNoteMenu","1","Add-Note-Menu","true","","",""},
                {"appSettings","add","createDocumentMenu","1","Create-New-Document-Menu","true","","",""},
                {"appSettings","add","documentPropertiesMenu","1","Document-Properties-Menu","true","","",""},
                {"appSettings","add","fileMenu","1","File-Menu","true","","",""},
                {"appSettings","add","historyMenu","1","History-Menu","true","","",""},
                {"appSettings","add","keywordsMenu","1","Keywords-Menu","true","","",""},
                {"appSettings","add","printMenu","1","Print-Menu","true","","",""},
                {"appSettings","add","reindexMenu","1","Reindex-Menu","true","","",""},
                {"appSettings","add","workflowMenu","1","Workflow-Menu","true","","",""},
                {"appSettings","add","sendToPrintQueueMenu","1","Send-To-Print-Queue-Menu","true","","",""},
                {"appSettings","add","clipBoardMenu","1","Clipboard-Menu","true","","",""},
                {"appSettings","add","gotoPageOR","2","Go-To-Page","0","","0",""},
                {"appSettings","add","overlayOR","2","Overlay","","","",""},
                {"appSettings","add","zoomLevelOR","2","Zoom-Level","","","",""},
                {"appSettings","add","rectLeftOR","2","Left-Border","0","","0",""},
                {"appSettings","add","rectRightOR","2","Right-Border","0","","0",""},
                {"appSettings","add","rectTopOR","2","Top-Border","0","","0",""},
                {"appSettings","add","rectBottomOR","2","Bottom-Border","0","","0",""},
                {"appSettings","add","enableAnnotationToolbar","1","Annotation-Toolbar","true","","",""},
                {"appSettings","add","enableNoteToolbar","1","Notes-Toolbar","true","","",""},
                {"appSettings","add","enableThumbnailPages","1","Thumbnail-Pages","true","","",""},
                {"appSettings","add","enableViewerControlToolbar","1","Viewer-Control-Toolbar","true","","",""},
                {"appSettings","add","DisableContextMenu","1","Disable-Context-Menu","false","","",""},
                {"appSettings","add","PathFormProc","2","Path-Form-Proc","/FormProc.ashx","","",""},
                {"appSettings","add","PathPrint","2","Path-Print","/PrintHandler.ashx","","",""},
                {"appSettings","add","PreventViewerClientCaching","1","Prevent-Viewer-Client-Caching","false","","",""},
                {"appSettings","add","RetrieveTransaction","1","Enable-Retrieve-Transactions","false","","",""},
                {"appSettings","add","RetrieveTransactionSortByDocId","1","Sort-by-Document-ID","false","","",""},
                {"appSettings","add","AllowSecurityKeywordsAdmin","1","Admin-Security-Keywords","true","","",""},
                {"appSettings","add","WorkflowLayout","2","Default-Workflow-Layout","selectable","","",""},
                {"appSettings","add","enableRowColoring","1","Row-Coloring","false","","",""},
                {"appSettings","add","FolderTreeWidth","2","Folder-Tree-Width","30%","","0","100"},
                {"appSettings","add","FolderTreeHeight","2","Folder-Tree-Height","60%","","0","100"},
                {"appSettings","add","DocumentListHeight","2","Document-List-Height","20%","","0","100"},
                {"appSettings","add","FolderListHeight","2","Folder-List-Height","20%","","0","100"},
                {"appSettings","add","WVMaxResults","2","WorkView-Max-Results","1000","","0",""},
                {"appSettings","add","WVFilterCount","1","WorkView-Filter-Count","false","","",""},
                {"appSettings","add","displayCreatedEForms","1","Display-Created-EForms","true","","",""},
                {"appSettings","add","EnableStandaloneWorkViewClient","1","Enable-Standalone-WorkView-Client","false","","",""},
                {"appSettings","add","sv_AppEnableIntegration","1","Application-Enabler-Integration","false","","",""},
                {"appSettings","add","sv_LaunchAppEnabler","1","Launch-Application-Enabler","false","","",""},
                {"appSettings","add","enableDataMine","1","Data-Mining","false","","",""},
                {"appSettings","add","DataMiningTempDirectory","2","Data-Mining-Temp-Directory","","","",""},
                {"appSettings","add","DataMiningReportServerName","2","Data-Mining-Report-Server-Name","","","",""},
                {"appSettings","add","DataMiningURL","2","Data-Mining-URL","","","",""},
                {"appSettings","add","DataMiningAdditionalModels","2","Additional-Models","","","",""},
                {"appSettings","add","AllowViewSource","1","Allow-View-Source","false","","",""},
                {"appSettings","add","pmCacheLocation","2","Platter-Management-Cache-Location","","","",""},
                {"appSettings","add","pmCacheTimeout","2","Platter-Management-Cache-Timeout","60","","",""},
                {"appSettings","add","pmCacheSize","2","Platter-Management-Cache-Size","500","","",""},
                {"appSettings","add","OpenRTFasMSWord","1","Open-Rich-Text-Format-Documents-With-Microsoft-Word","true","","",""},
                {"appSettings","add","ThumbnailHitListAllowCaching","1","Allow-Caching","false","","",""},
                {"appSettings","add","ThumbnailHitListShowPreviews","1","Show-Previews","false","","",""},
                {"appSettings","add","ThumbnailHitListUserConfigurable","1","User-Configurable","false","","",""},
                {"appSettings","add","ThumbnailHitListColumns","2","Number-of-Columns","3","","",""},
                {"appSettings","add","ThumbnailHitListThumbnailMaxWidth","2","Maximum-Width","50","","",""},
                {"appSettings","add","ThumbnailHitListThumbnailMaxHeight","2","Maximum-Height","50","","",""},
                {"appSettings","add","ThumbnailHitListPreviewMaxWidth","2","Preview-Maxiumum-Width","400","","",""},
                {"appSettings","add","ThumbnailHitListPreviewMaxHeight","2","Preview-Maxiumum-Height","400","","",""},
                {"appSettings","add","UseFolderPopViewer","1","Use-FolderPop-Viewer","true","","",""},
                {"appSettings","add","PromptWithUnreadDKTDocs","1","Prompt-with-Unread-DKT-Docs","true","","",""},
                {"appSettings","add","InternalMailTimerSeconds","2","Internal-Mail-Timer-In-Seconds","300","","0",""},
                {"appSettings","add","AllowedFunctionKeyList","2","Allowed-Function-Key-List","","","",""},
                {"appSettings","add","aspnet:MaxJsonDeserializerMembers","2","Max-JSON-Deserialized-Members","40000","","",""},
                {"appSettings","add","ValidationSettings:UnobtrusiveValidationMode","2","Validation-Settings-Unobtrusive-Validation-Mode","None","","",""},
                {"appSettings","add","owin:AutomaticAppStartup","1","OWIN-Automatic-App-Startup","false","","",""},
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
                {"appSettings","add","EnableLegacyChecksumFallback","1","Enabled-Legacy-Checksum-Fallback","false","","",""},
                {"appSettings","add","EnableLoginAutocomplete","1","Enable-Login-Autocomplete","false","","",""},
                {"appSettings","add","WindowsServerLocaleFormat","2","Windows-Server-Locale-Format","","","",""},
                {"appSettings","add","MaxImportQueueSize","2","Maximum-Import-Queue-Size","5","","",""},
                {"appSettings","add","EnableBrowserPdfViewer","1","Enable-Browser-PDF-Viewer","true","","",""},
                {"appSettings","add","pingTimerForScanServiceInSeconds","2","Ping-Timer-For-Scan-Service","10","","",""},
                {"appSettings","add","UseLegacySharePointAuthentication","1","Use-Legacy-SharePoint-Authentication","false","","",""},
                {"appSettings","add","MultiFormViewerOrigin","2","Multi-Form-Viewer-Origin","[origin]","","",""}
            }
        },
        {
            "Hyland.Web.DashboardViewer", new string[,]
            {
                {"Hyland.Web.DashboardViewer","useTheme","value","2","Use-Theme","light","","",""},
                {"Hyland.Web.DashboardViewer","enableExportDashboard","value","1","Enable-Export-Dashboard","true","","",""},
                {"Hyland.Web.DashboardViewer","enableExportDashboardItems","value","1","Enable-Export-Dashboard-Items","true","","",""},
                {"Hyland.Web.DashboardViewer","reportPagingLimit","value","2","Reporting-Page-Limit","50","","",""}
                //{"Hyland.Web.DashboardViewer","dashboardCacheTimeoutSeconds","value","2","Dashboard-Cache-Timeout","2","","",""}
            }
        },
        {
            "Hyland.Web.HealthcareWebViewer", new string[,]
            {
                {"Hyland.Web.HealthcareWebViewer","sessionTimeout","value","2","Healthcare-Web-Viewer-Session-Timeout","30","","",""},
                {"Hyland.Web.HealthcareWebViewer","datasource","value","2","Healthcare-Web-Viewer-Data-Source","","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableHTTPDataSource","value","1","Healthcare-Web-Viewer-Enable-HTTP-Data-Source","false","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableDeficiencyViewing","value","1","Healthcare-Web-Viewer-Enable-Deficiency-Viewing","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","enablePhysicianAcknowledgment","value","1","Healthcare-Web-Viewer-Enable-Physician-Acknowledgement","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableDocumentCorrection","value","1","Healthcare-Web-Viewer-Enable-Document-Correction","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","readonlyHTMLForms","value","2","Healthcare-Web-Viewer-Read-Only-HTML-Forms","all","","",""},
                {"Hyland.Web.HealthcareWebViewer","readonlyUnityForms","value","2","Healthcare-Web-Viewer-Read-Only-Unity-Forms","all","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableEpicWebViewerApi","value","1","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","epicScanViewerApi/enabled","value","1","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Interoperability-Enabled","false","","",""},
                {"Hyland.Web.HealthcareWebViewer","epicScanViewerApi/displayDocumentFailedTimeout","value","2","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Failed-Timeout","10","","",""},
                {"Hyland.Web.HealthcareWebViewer","epicScanViewerApi/displayDocumentMessageInterval","value","2","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Message-Interval","1","","",""},
                {"Hyland.Web.HealthcareWebViewer","IsEnabled","","1","Enable-Healthcare-Web-Viewer","false","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","sessionState","timeout","2","Session-Timeout","20","","2","1440"},
                {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""},
                {"system.web","authentication","mode","2","Authentication-Mode","Windows","","",""},
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length-KB","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout-Seconds","90","","10",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        },
        {
            "ADFS", new string[,]
            {

            }
        },
        {
            "NavigationPanel", new string[,]
            {

            }
        },
        {
            "CustomValidation", new string[,]
            {

            }
        }
    };

    /* Version 24.1 Translators */
    private readonly Dictionary<string, string[,]> AgendaOnline241SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://localhost/AppServer/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
            }
        },
        {
            "Hyland.Applications.AgendaPubAccess.PublicComment", new string[,]
            {
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","StreamChunkSize","2","Stream-Chunk-Size","65536","","",""},
                {"appSettings","add","PlayerSourceFilePath","2","Player-Source-File-Path","../Scripts/jwplayer","","",""},
                {"appSettings","add","PlayerVersion","2","Player-Version","JWPlayer 8.24.6","","",""},
                {"appSettings","add","MinPoolSize","2","Min-Pool-Size","1","","",""},
                {"appSettings","add","MaxPoolSize","2","Max-Pool-Size","5","","",""},
                {"appSettings","add","webpages:Enabled","1","webpages-Enabled","false","","",""},
                {"appSettings","add","GoogleAnalytics","2","Google-Analytics","","","",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> ElectronicPlanReview241SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[server]/[virtual directory]/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","StyleSheetPath","2","Stylesheet-Directory-Location","BasicBlue/","","",""},
                {"appSettings","add","AllowSignon","1","Allow-Sign-On","true","","",""},
                {"appSettings","add","AllowSignoff","1","Allow-Sign-Off","true","","",""},
                {"appSettings","add","DefaultTimeZone","2","Default-User-Time-Zone","64","","",""},
                {"appSettings","add","SearchStartYear","2","Search-Start-Year","2012","","",""},
                {"appSettings","add","DisplayDocumentsPerPage","2","Items-Per-Page","20","","",""},
                {"appSettings","add","MaxLookupResults","2","Max-Lookup-Results","20","","",""},
                {"appSettings","add","ResetPasswordLinkExpiration","2","Reset-Password-Link-Lifetime","60","","",""},
                {"appSettings","add","FileUploadDirectory","2","File-Upload-Directory","~/Upload","","",""},
                {"appSettings","add","FileUploadValidator","2","File-Upload-Validator","","","",""},
                {"appSettings","add","TokenAuthentication","1","Token-Authentication","false","","",""},
                {"appSettings","add","SingleSignOn","1","Allow-Single-Sign-On","false","","",""},
                {"appSettings","add","SingleSignOnSourceID","2","Source-ID","1","","",""},
                {"appSettings","add","SSOUserResolutionMode","2","Resolution-Mode","0","","",""},
                {"appSettings","add","CAPTCHAPublicKey","2","Public-CAPTCHA-Key","","","",""},
                {"appSettings","add","CAPTCHAPrivateKey","2","Private-CAPTCHA-Key","","","",""},
                {"appSettings","add","PasswordStrengthPattern","2","Password-Strength-Pattern","^(?=.{4,}).*$","","",""},
                {"appSettings","add","PasswordStrengthMessage","2","Password-Strength-Message","","","",""},
                {"appSettings","add","UsernameValidationPattern","2","Username-Validation-Pattern","[\\da-zA-Z\\u00C0-\\u00D6\\u00D8-\\u00F6\\u00F8-\\u00FF]+","","",""},
                {"appSettings","add","DisciplineItemsPerMenu","2","Discipline-Items-Per-Menu","15","","",""},
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> HealthcareFormManager241SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[server]/[virtual directory]/Service.asmx","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","SOAP","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "appSettings", new string[,]
            {
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
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""},
                {"system.web","sessionState","timeout","2","Session-Timeout","20","","2","1440"},
                {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> PatientWindow241SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://[APP SERVER]/[VIRTUAL ROOT]/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "appSettings", new string[,]
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
            }
        },
        {
            "Hyland.Authentication", new string[,]
            {
                {"Hyland.Authentication","adfs","enabled","1","ADFS-Enabled","false","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""},
                {"system.web","sessionState","timeout","2","Session-Timeout","20","","2","1440"},
                {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""}
            }
        },
        {
            "system.web.extensions", new string[,]
            {
                {"system.web.extensions","scripting/webServices/jsonSerialization","maxJsonLength","2","JSON-Serialization-Max-Length","2097152","","",""}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        },
        {
            "ADFS", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> PublicAccessNextGen241SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","EncryptDocId","1","Encrypt-Doc-ID","true","","",""},
                {"appSettings","add","UseDisplayColumns","1","Use-Display-Columns","true","","",""},
                {"appSettings","add","QueryLimit","2","Query-Limit","0","","",""},
                {"appSettings","add","ChunkSize","2","Chunk-Size","512000","","",""},
                {"appSettings","add","ViewerMode","2","Viewer-Mode","PDF","","",""},
                {"appSettings","add","OverlayMode","2","Default-Overlay-Mode","Print","","",""},
                {"appSettings","add","CachePath","2","Cache-Path","C:\\DocCache","","",""},
                {"appSettings","add","ExpireTime","2","Expiration-Time","1","","0",""},
                {"appSettings","add","MaxCacheSize","2","Max-Cache-Size","10","","0",""},
                {"appSettings","add","SizeToCache","2","Size-to-Cache","1","","0",""},
                {"appSettings","add","SizeToPrompt","2","Size-to-Prompt","20","","0",""},
                {"appSettings","add","ThrottleResetTimer","2","Interval-Between-Throttle-Cache-Resets","5","","",""},
                {"appSettings","add","ThrottleThreshold","2","Amount-of-Requests-During-Each-Throttle-Interval","1000","","",""},
                {"appSettings","add","EnableBrowserCaching","1","Enable-Local-Browser-Caching","true","","",""},
                {"appSettings","add","DecorateDocumentNames","1","Decorate-Document-Names","true","","",""},
                {"appSettings","add","AlwaysWildcardAlphanumericKeywords","1","Always-Wildcard-Alphanumeric-Keywords","false","","",""}
            }
        },
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://localhost/AppServer/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
                {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","SOAP-Client-Request-Timeout","100","","10",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","100","","10",""}
            }
        },
        {
            "RequiredKeywords", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> ReportingViewer241SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","http://[HOSTNAME]/[VIRTUAL ROOT]/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","Remoting","","",""},
                {"Hyland.Services.Client","AllowNTAuthenticationOnForwarding","Enabled","1","Allow-NT-Authentication-On-Forwarding","false","","",""},
                {"Hyland.Services.Client","OptimizedServicePipeline","Enabled","1","Optimized-Service-Pipeline","true","","",""},
                {"Hyland.Services.Client","RequestTimeoutSeconds","Value","2","Request-Timeout","300","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
                {"appSettings","add","dmsVirtualRoot","2","Web-Virtual-Directory","http://[HOSTNAME]/[VIRTUAL ROOT]","","",""},
                {"appSettings","add","dmsDataSource","2","Core-Data-Source","[DATASOURCE NAME]","","",""},
                {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""},
                {"appSettings","add","IdPUrl","2","","","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout","90","","10",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "system.web.extensions", new string[,]
            {
                {"system.web.extensions","scripting/webServices/jsonSerialization","maxJsonLength","2","JSON-Serialization-Max-Length","50000000","","",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> ApplicationServer241SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""},
                {"appSettings","add","dmsdatasource","2","Data-Source","[Datasource]","","",""},
                {"appSettings","add","UseOSAuthentication","1","Use-OS-Authentication","false","","",""},
                {"appSettings","add","DocumentQueryWarningThreshold","2","Document-Query-Warning-Threshold","500","","",""},
                {"appSettings","add","DocumentQueryLimit","2","Document-Query-Limit","2000","","","10000"},
                {"appSettings","add","ItemCacheTimeout","2","Item-Cache-Timeout","60","","",""},
                {"appSettings","add","RawImagesAllowed","1","Raw-Images","true","","",""},
                {"appSettings","add","UseIsolatedImageProcess","1","Use-Isolated-Image-Process","true","","",""},
                {"appSettings","add","CompressionQuality","2","Compression-Quality","70","","",""},
                {"appSettings","add","EnableIsolatedChromiumProcess","1","Enable-Isolated-Chromium-Process","true","","",""},
                {"appSettings","add","FormSaveToTiffTimeout","2","Form-Save-To-TIFF-Timeout","60","","",""},
                {"appSettings","add","PrintImageFormViaPDF","1","Print-Image-Form-Via-PDF","false","","",""},
                {"appSettings","add","TPCFWorkerLocationOverride","2","TPCF-Worker-Location-Override","","","",""},
                {"appSettings","add","DefaultStoragePath","2","Default-Storage-Path","","","",""},
                {"appSettings","add","watchFolder","2","Watch-Folder","","","",""},
                {"appSettings","add","siteIDKeywordType","2","Site-ID-Keyword-Type","Site ID","","",""},
                {"appSettings","add","cleanupTimerInterval","2","Cleanup-Timer-Interval","15","","",""},
                {"appSettings","add","maxFileAgeInHours","2","Max-File-Age","4","","",""},
                {"appSettings","add","ValidateMessageSchema","1","Integrations-EIS-Validate-Message-Schema","true","","",""},
                {"appSettings","add","ContinueOnValidationError","1","Integrations-EIS-Continue-On-Validation-Error","false","","",""},
                {"appSettings","add","DataSetCacheCleanUpIntervalInMins","2","Integrations-EIS-Data-Set-Cache-Cleanup-Interval","60","","",""},
                {"appSettings","add","AppNetDirectory","2","Integrations-EIS-AppNet-Directory","[virtualRoot]","","",""},
                {"appSettings","add","MessageBrokerMonitorStartDelayInMinutes","2","Message-Broker-Monitor-Start-Delay","","","",""},
                {"appSettings","add","GCSUsername","2","GCS-Username","","","",""},
                {"appSettings","add","GCSPassword","2","GCS-Password","","","",""},
                {"appSettings","add","useLegacyKeyForUsageBasedBilling","2","Use-Legacy-Key-For-Usage-Based-Billing","false","","",""},
                {"appSettings","add","GCSPhoneHomeIntervalInMinutes","2","GCS-Phone-Home-Interval","60","","",""},
                {"appSettings","add","DataCaptureServerWCFEndpointAddress","2","Data-Capture-Server-WCF-Endpoint-Address","net.tcp://localhost:9050/Hyland.DataCapture.ServiceManager/service","","",""},
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
                {"appSettings","add","AppServerOrigin","2","OWIN-Application-Server-Origin","[virtualRoot]","","",""},
                {"appSettings","add","owin:AutomaticAppStartup","1","OWIN-Automatic-App-Startup","false","","",""},
                {"appSettings","add","owin:appStartup","2","OWIN-App-Startup","Hyland.Owin.Core.Startup, Hyland.Owin.Core","","",""},
                {"appSettings","add","IdentityModelServerURI","2","Identity-Model-Server-URI","","","",""},
                {"appSettings","add","mobileAppsPath","2","Mobile-Apps-Path","[unc path]","","",""},
                {"appSettings","add","corsPolicy","2","CORS-Policy","*","","",""},
                {"appSettings","add","endpoints:WorkViewMobile","1","WorkView-Mobile-Endpoint","false","","",""},
                {"appSettings","add","endpoints:ResponsiveApps","1","Responsive-Apps-Endpoint","false","","",""},
                {"appSettings","add","endpoints:Wopi","1","WOPI-Endpoint","false","","",""},
                {"appSettings","add","endpoints:Sesame","1","Sesame-Endpoint","false","","",""},
                {"appSettings","add","endpoints:GovernanceRulesAsAService","1","Governance-Rules-As-A-Service-Endpoint","false","","",""},
                {"appSettings","add","endpoints:FHIR","1","Web-BLOB-Passthrough-FHIR-Endpoint","false","","",""},
                {"appSettings","add","SMARTonFHIRApplicationId","2","SMART-On-FHIR-Application-ID","[GUID]","","",""},
                {"appSettings","add","endpoints:PPL","1","PPL-Endpoint-Enabled","false","","",""},
                {"appSettings","add","endpoints:Forms","1","Forms-Endpoint","false","","",""},
                {"appSettings","add","DocPopUrl","2","PPL-DocPop-URL","","","",""},
                {"appSettings","add","StatementCompCacheLimit","2","Statement-Composition-Cache-Limit","","","",""},
                {"appSettings","add","UnityFormsToggleMaxFormWidth","1","Unity-Forms-Toggle-Max-Form-Width","false","","",""},
                {"appSettings","add","owin:oia:msgItemTypeId","2","owin:oia:msgItemTypeId","[Message Item Type ID]","","",""},
                {"appSettings","add","owin:oia:lifeCycleId","2","owin:oia:lifeCycleId","[Lifecycle ID]","","",""},
                {"appSettings","add","owin:oia:tmpFilePath","2","owin:oia:tmpFilePath","[UNC Path]","","",""},
                {"appSettings","add","owin:oia:tmpFileAgeInMs","2","owin:oia:tmpFileAgeInMs","[Temp File Age ms]","","",""},
                {"appSettings","add","owin:oia:cleanupIntervalInMs","2","owin:oia:cleanupIntervalInMs","[Cleanup Interval ms]","","",""},
                {"appSettings","add","UseOnBaseFulltext","1","Use-OnBase-Full-Text","false","","",""},
                {"appSettings","add","ContentComposerIdpPath","2","Content-Composer-IdP-Path","","","",""},
                {"appSettings","add","KeywordDataCacheTimeout","2","Keyword-Data-Cache-Timeout","20","","",""},
                {"appSettings","add","AllowInsecureExternalXsl ","1","Allow-Insecure-External-XSL","false","","",""},
                {"appSettings","add","SB_MaxQueryExecutionParallelism","2","Max-Query-Execution-Parallelism","10","","",""},
                {"appSettings","add","SB_FolderFetchBatchSize","2","Folder-Fetch-Batch-Size","300","","",""},
                {"appSettings","add","SB_DatabaseCommandTimeOut","2","Database-Command-TimeOut","300","","",""},
                {"appSettings","add","DocLinkerSMARTonFHIRApplicationId","2","Doc-Linker-SMART-On-FHIR-Application-ID","[GUID]","","",""},
                {"appSettings","add","UseNewKeywordDataCacheImplementation","1","Use-New-Keyword-Data-Cache-Implementation","false","","",""},
                {"appSettings","add","ConfigurationImport_DatabaseTimeout","2","Configuration-Import-Database-Timeout","300","","",""},
                {"appSettings","add","PIM:HyRCS:ExternalBaseUri","2","PIM:HyRCS:ExternalBaseUri","","","",""},
                {"appSettings","add","PIM:HyRCS:Port","2","PIM:HyRCS:Port","","","",""},
                {"appSettings","add","PIM:ImageProcess","1","PIM:ImageProcess","false","","",""},
                {"appSettings","add","PIM:ChromiumProcess","1","PIM:ChromiumProcess","false","","",""},
                {"appSettings","add","HyRCS:PageCountLimit","2","HyRCS:PageCountLimit","10000","","",""}
            }
        },
        {
            "Hyland.ResponsiveApps", new string[,]
            {
                {"Hyland.ResponsiveApps","WorkViewApi","url","2","Responsive-Apps-WorkView-API-URL","https://[Server]/[AppServer]/private/workview/api/","","",""},
                {"Hyland.ResponsiveApps","WorkViewFiles","url","2","Responsive-Apps-WorkView-Files-URL","https://[Server]/[AppServer]/private/workview/files/","","",""},
                {"Hyland.ResponsiveApps","ResponsiveAppsApi","url","2","Responsive-Apps-API-URL","https://[Server]/[AppServer]/private/responsive-apps/api/","","",""},
                {"Hyland.ResponsiveApps","IdentityProvider","url","2","Identity-Provider-URL","https://[Server]/idp/[tenant]/[population]","","",""},
                {"Hyland.ResponsiveApps","CoreAccessTokenLifetime","value","2","Core-Access-Token-Lifetime","691200","","",""}
            }
        },
        {
            "Hyland.PlatterManagement", new string[,]
            {
                {"Hyland.PlatterManagement","Logging/FileIODetail","value","1","File-IO-Detail","false","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/EMCTHRESHOLD","value","2","Foreign-Storage-EMC-Threshold","","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/PmCacheLocation","value","2","Foreign-Storage-PM-Cache-Location","","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/PmCacheTimeout","value","2","Foreign-Storage-PM-Cache-Timeout","","","",""},
                {"Hyland.PlatterManagement","ForeignStorageDevices/PmCacheSize","value","2","Foreign-Storage-PM-Cache-Size","","","",""},
                {"Hyland.PlatterManagement","FileAccess/PMAccessLevel","value","2","PM-File-Access-Level","0","","",""},
                {"Hyland.PlatterManagement","TemporaryFiles/TempFileExpirationThreshold","value","2","Temp-File-Expiration-Threshold-Time","","","",""}
            }
        },
        {
            "Hyland.Services", new string[,]
            {
                {"Hyland.Services","poolSettings","minSessions","2","Hyland-Services-AppPool-Minimum-Sessions","0","","",""},
                {"Hyland.Services","poolSettings","maxSessions","2","Hyland-Services-AppPool-Maximum-Sessions","10","","",""},
                {"Hyland.Services","securitySettings","useQueryContext","1","Use-Query-Context","false","","",""},
                {"Hyland.Services","securitySettings","filterExceptions","1","Filter-Exceptions","true","","",""},
                {"Hyland.Services","Endpoint","useRemoting","1","Endpoint-Use-Remoting","true","","",""},
                {"Hyland.Services","session","enableTimeout","1","Session-Enable-Timeout","false","","",""},
                {"Hyland.Services","applicationServerCallback","url","2","Application-Server-Callback-URL","","","",""},
                {"Hyland.Services","webServerBaseUrl","url","2","Web-Server-Base-URL","","","",""},
                {"Hyland.Services","requestValidation","minVersion","2","Request-Validation-Minimum-Version","0","","",""}
            }
        },
        {
            "Hyland.XMLServices.DocumentConnector", new string[,]
            {
                {"Hyland.XMLServices.DocumentConnector","loginId","name","2","Login-ID","","","",""},
                {"Hyland.XMLServices.DocumentConnector","loginPassword","name","2","Login-Password","","","",""},
                {"Hyland.XMLServices.DocumentConnector","loginDatasource","name","2","Login-Datasource","","","",""},
                {"Hyland.XMLServices.DocumentConnector","pool","min","2","Pool-Min","0","","",""},
                {"Hyland.XMLServices.DocumentConnector","pool","max","2","Pool-Max","5","","",""}
            }
        },
        {
            "Hyland.Core.FullText", new string[,]
            {
                {"Hyland.Core.FullText","SearchTimeout","value","2","Search-Timeout","30","","",""},
                {"Hyland.Core.FullText","SearchLog","enableSearchlog","1","Enable-Search-Log","false","","",""},
                {"Hyland.Core.FullText","SearchLog","path","2","Search-Log-Path","","","",""}
            }
        },
        {
            "Hyland.WorkView.Core", new string[,]
            {
                {"Hyland.WorkView.Core","UnityEditableFilterMaxRows","value","2","Unity-Editable-Filter-Max-Rows","20","","",""},
                {"Hyland.WorkView.Core","ERPDateFormat","value","2","ERP-Date-Format-LOB-Broker","yyyyMMdd","","",""},
                {"Hyland.WorkView.Core","FormattedTextIframeSupportedDomains","value","2","Formatted-Text-Iframe-Supported-Domains","","","",""}
            }
        },
        {
            "Hyland.Core.Wopi", new string[,]
            {
                {"Hyland.Core.Wopi","useOfficeWebAppServer","value","2","Use-Office-Online-Server","false","","",""},
                {"Hyland.Core.Wopi","owaServerUri","value","2","Office-Online-Server-URI","https://[servername]/","","",""},
                {"Hyland.Core.Wopi","owaProxyBase","value","2","Office-Online-Server-Proxy-Base","https://[servername]/[appserver]/private","","",""}
            }
        },
        {
            "Hyland.Integrations.LOBBroker.LOBBrokerConfigSection", new string[,]
            {
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorCacheSearchMinChars","2","Vendor-Cache-Search-Minimum-Characters","1","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorMasterKeyedLookupOp","2","Vendor-Master-Keyed-Lookup-Op","GetVenMasterRecordbyVenIDNCompID","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorMasterLookupSequence","2","Vendor-Master-Lookup-Sequence","GetVenMasterRecordbyVenIDNCompID, GetVenMasterRecordbyPONumNCompID, GetVenMasterRecordbyPhoneNCompID, GetVenMasterRecordbyTaxID, GetVenMasterRecordbyVATID, GetVenMasterRecordbyZipCodeNCompID, GetVenMasterRecordByVenAddressNCompID, GetVenMasterRecordbyWebSiteNCompID, GetVenMasterRecordbyBankAccountNumber, GetVenMasterRecordbyVenNameNCompID","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorMasterLookupReturnMultiple","1","Vendor-Master-Lookup-Return-Multiple","false","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","AccountsPayableAPI","VendorCacheAutoCompleteResultsMax","2","Vendor-Cache-AutoComplete-Result-Max","30","","",""},
                {"Hyland.Integrations.LOBBroker.LOBBrokerConfigSection","IsEnabled","","1","Enable-LOB-Broker-Accounts-Payable","false","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","httpRuntime","maxRequestLength","2","Http-Runtime-Maximum-Request-Length","30000","","",""},
                {"system.web","httpRuntime","executionTimeout","2","Http-Runtime-Execution-Timeout","300","","",""},
                {"system.web","sessionState","timeout","2","Session-Timeout-Length","20","","",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "root", new string[,]
            {
                
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        },
        {
            "ADFS", new string[,]
            {

            }
        },
        {
            "Hyland.Authentication", new string[,]
            {

            }
        }
    };

    private readonly Dictionary<string, string[,]> WebServer241SectionsTranslator = new Dictionary<string, string[,]>
    {
        {
            "Hyland.Services.Client", new string[,]
            {
                {"Hyland.Services.Client","ApplicationServer","Url","2","Application-Server-URL","https://localhost/appserver/Service.rem","","",""},
                {"Hyland.Services.Client","ApplicationServer","ServiceClientType","2","Service-Client-Type","remoting","","",""},
                {"Hyland.Services.Client","StreamingSettings","BufferSize","2","Stream-Settings","64000","","",""}
            }
        },
        {
            "appSettings", new string[,]
            {
                {"appSettings","add","dmsDataSource","2","Core-Data-Source","[DATASOURCE]","","",""},
                {"appSettings","add","dmsVirtualRoot","2","Web-Virtual-Directory","https://[WEB SERVER]/[VIRTUAL ROOT]","","",""},
                {"appSettings","add","ServerDesignation","2","Server-Designation","","","",""},
                {"appSettings","add","default_domainname","2","Default-Domain-Name","","","",""},
                {"appSettings","add","default_username","2","Default-Username","","","",""},
                {"appSettings","add","default_password","2","Default-Password","","","",""},
                {"appSettings","add","default_institution","2","Default-Institution","0","","0",""},
                {"appSettings","add","EnableAutoLogin","1","Autologin","false","","",""},
                {"appSettings","add","IdPUrl","2","","","","",""},
                {"appSettings","add","forceSSOAutoLoginOverDomain","1","Force-OnBase-Authentication","false","","",""},
                {"appSettings","add","CustomSSOAuthenticationFailurePage","2","Custom-SSO-Authentication-Page-Failure","","","",""},
                {"appSettings","add","LogoutClose","1","Close-On-Logout","false","","",""},
                {"appSettings","add","logoutRedirectURL","2","Logout-Redirect-URL","","","",""},
                {"appSettings","add","webtheme","2","Web-Theme","XP","","",""},
                {"appSettings","add","targetPage","2","Target-Page","NavPanel.aspx","","",""},
                {"appSettings","add","loginPage","2","Login-Page","Login.aspx","","",""},
                {"appSettings","add","SPViewerShowWorkflow","1","SharePoint-Viewer-Show-Workflow","false","","",""},
                {"appSettings","add","SharepointOnline","1","SharePoint-Online","false","","",""},
                {"appSettings","add","promptUserQueries","1","Prompt-User-Queries","false","","",""},
                {"appSettings","add","showQueueCounts","1","Show-Queue-Counts","false","","",""},
                {"appSettings","add","textSearchAutoView","1","Text-Search-Auto-View","false","","",""},
                {"appSettings","add","MaxResults","2","Max-Results","1000","","",""},
                {"appSettings","add","WorkflowMaxResults","2","Workflow-Max-Results","2000","","",""},
                {"appSettings","add","KeywordPanelViewType","2","Keyword-Panel-View-Type","flat","","",""},
                {"appSettings","add","EnableKeywordOperators","1","Enable-Keyword-Operators","true","","",""},
                {"appSettings","add","EnableSessionExpiration","1","Enable-Session-Expiration","true","","",""},
                {"appSettings","add","PromptOnSessionExpire","1","Prompt-On-Session-Expire","true","","",""},
                {"appSettings","add","displaySingleDocument","1","Display-Single-Document","true","","",""},
                {"appSettings","add","DisplayRelatedDocuments","2","Display-Related-Documents","always","","",""},
                {"appSettings","add","WorkflowUserInteractionHeight","2","Workflow-Height-px","375","","",""},
                {"appSettings","add","ShowCombinedInbox","1","Show-Combined-Inbox","true","","",""},
                {"appSettings","add","OverrideUILanguage","1","Override-UI-Language","false","","",""},
                {"appSettings","add","DefaultUILocale","2","Default-UI-Local","default","","",""},
                {"appSettings","add","enableVirtualPrintDriver","1","Enable-Virtual-Print-Driver","false","","",""},
                {"appSettings","add","autoDisplayNotePanelPDFOffice","1","Auto-Display-Note-Panel-PDF-Office","true","","",""},
                {"appSettings","add","ClearDocumentTypeAfterImport","1","Clear-Document-Type-After-Import","false","","",""},
                {"appSettings","add","ClearKeywordsAfterImport","1","Clear-Keywords-After-Import","false","","",""},
                {"appSettings","add","AlwaysGeneratePreviewAfterUpload","1","Always-Generate-Preview","true","","",""},
                {"appSettings","add","RememberHitListHeight","1","Remember-Hitlist-Height","false","","",""},
                {"appSettings","add","NumDisplayedDocumentTypes","2","Number-of-Docuemnt-Types-to-Display","6","","",""},
                {"appSettings","add","CollapseCheckSelect","1","Collapse-Check-Select-Lists","false","","",""},
                {"appSettings","add","addNoteMenu","1","Add-Note-Menu","true","","",""},
                {"appSettings","add","createDocumentMenu","1","Create-New-Document-Menu","true","","",""},
                {"appSettings","add","documentPropertiesMenu","1","Document-Properties-Menu","true","","",""},
                {"appSettings","add","fileMenu","1","File-Menu","true","","",""},
                {"appSettings","add","historyMenu","1","History-Menu","true","","",""},
                {"appSettings","add","keywordsMenu","1","Keywords-Menu","true","","",""},
                {"appSettings","add","printMenu","1","Print-Menu","true","","",""},
                {"appSettings","add","reindexMenu","1","Reindex-Menu","true","","",""},
                {"appSettings","add","workflowMenu","1","Workflow-Menu","true","","",""},
                {"appSettings","add","sendToPrintQueueMenu","1","Send-To-Print-Queue-Menu","true","","",""},
                {"appSettings","add","clipBoardMenu","1","Clipboard-Menu","true","","",""},
                {"appSettings","add","gotoPageOR","2","Go-To-Page","0","","0",""},
                {"appSettings","add","overlayOR","2","Overlay","","","",""},
                {"appSettings","add","zoomLevelOR","2","Zoom-Level","","","",""},
                {"appSettings","add","rectLeftOR","2","Left-Border","0","","0",""},
                {"appSettings","add","rectRightOR","2","Right-Border","0","","0",""},
                {"appSettings","add","rectTopOR","2","Top-Border","0","","0",""},
                {"appSettings","add","rectBottomOR","2","Bottom-Border","0","","0",""},
                {"appSettings","add","enableAnnotationToolbar","1","Annotation-Toolbar","true","","",""},
                {"appSettings","add","enableNoteToolbar","1","Notes-Toolbar","true","","",""},
                {"appSettings","add","enableThumbnailPages","1","Thumbnail-Pages","true","","",""},
                {"appSettings","add","enableViewerControlToolbar","1","Viewer-Control-Toolbar","true","","",""},
                {"appSettings","add","DisableContextMenu","1","Disable-Context-Menu","false","","",""},
                {"appSettings","add","PathFormProc","2","Path-Form-Proc","/FormProc.ashx","","",""},
                {"appSettings","add","PathPrint","2","Path-Print","/PrintHandler.ashx","","",""},
                {"appSettings","add","PreventViewerClientCaching","1","Prevent-Viewer-Client-Caching","false","","",""},
                {"appSettings","add","RetrieveTransaction","1","Enable-Retrieve-Transactions","false","","",""},
                {"appSettings","add","RetrieveTransactionSortByDocId","1","Sort-by-Document-ID","false","","",""},
                {"appSettings","add","AllowSecurityKeywordsAdmin","1","Admin-Security-Keywords","true","","",""},
                {"appSettings","add","WorkflowLayout","2","Default-Workflow-Layout","selectable","","",""},
                {"appSettings","add","enableRowColoring","1","Row-Coloring","false","","",""},
                {"appSettings","add","FolderTreeWidth","2","Folder-Tree-Width","30%","","0","100"},
                {"appSettings","add","FolderTreeHeight","2","Folder-Tree-Height","60%","","0","100"},
                {"appSettings","add","DocumentListHeight","2","Document-List-Height","20%","","0","100"},
                {"appSettings","add","FolderListHeight","2","Folder-List-Height","20%","","0","100"},
                {"appSettings","add","WVMaxResults","2","WorkView-Max-Results","1000","","0",""},
                {"appSettings","add","WVFilterCount","1","WorkView-Filter-Count","false","","",""},
                {"appSettings","add","displayCreatedEForms","1","Display-Created-EForms","true","","",""},
                {"appSettings","add","EnableStandaloneWorkViewClient","1","Enable-Standalone-WorkView-Client","false","","",""},
                {"appSettings","add","sv_AppEnableIntegration","1","Application-Enabler-Integration","false","","",""},
                {"appSettings","add","sv_LaunchAppEnabler","1","Launch-Application-Enabler","false","","",""},
                {"appSettings","add","enableDataMine","1","Data-Mining","false","","",""},
                {"appSettings","add","DataMiningTempDirectory","2","Data-Mining-Temp-Directory","","","",""},
                {"appSettings","add","DataMiningReportServerName","2","Data-Mining-Report-Server-Name","","","",""},
                {"appSettings","add","DataMiningURL","2","Data-Mining-URL","","","",""},
                {"appSettings","add","DataMiningAdditionalModels","2","Additional-Models","","","",""},
                {"appSettings","add","AllowViewSource","1","Allow-View-Source","false","","",""},
                {"appSettings","add","pmCacheLocation","2","Platter-Management-Cache-Location","","","",""},
                {"appSettings","add","pmCacheTimeout","2","Platter-Management-Cache-Timeout","60","","",""},
                {"appSettings","add","pmCacheSize","2","Platter-Management-Cache-Size","500","","",""},
                {"appSettings","add","OpenRTFasMSWord","1","Open-Rich-Text-Format-Documents-With-Microsoft-Word","true","","",""},
                {"appSettings","add","ThumbnailHitListAllowCaching","1","Allow-Caching","false","","",""},
                {"appSettings","add","ThumbnailHitListShowPreviews","1","Show-Previews","false","","",""},
                {"appSettings","add","ThumbnailHitListUserConfigurable","1","User-Configurable","false","","",""},
                {"appSettings","add","ThumbnailHitListColumns","2","Number-of-Columns","3","","",""},
                {"appSettings","add","ThumbnailHitListThumbnailMaxWidth","2","Maximum-Width","50","","",""},
                {"appSettings","add","ThumbnailHitListThumbnailMaxHeight","2","Maximum-Height","50","","",""},
                {"appSettings","add","ThumbnailHitListPreviewMaxWidth","2","Preview-Maxiumum-Width","400","","",""},
                {"appSettings","add","ThumbnailHitListPreviewMaxHeight","2","Preview-Maxiumum-Height","400","","",""},
                {"appSettings","add","UseFolderPopViewer","1","Use-FolderPop-Viewer","true","","",""},
                {"appSettings","add","PromptWithUnreadDKTDocs","1","Prompt-with-Unread-DKT-Docs","true","","",""},
                {"appSettings","add","InternalMailTimerSeconds","2","Internal-Mail-Timer-In-Seconds","300","","0",""},
                {"appSettings","add","AllowedFunctionKeyList","2","Allowed-Function-Key-List","","","",""},
                {"appSettings","add","aspnet:MaxJsonDeserializerMembers","2","Max-JSON-Deserialized-Members","40000","","",""},
                {"appSettings","add","ValidationSettings:UnobtrusiveValidationMode","2","Validation-Settings-Unobtrusive-Validation-Mode","None","","",""},
                {"appSettings","add","owin:AutomaticAppStartup","1","OWIN-Automatic-App-Startup","false","","",""},
                {"appSettings","add","AllowInsecureConnection","1","Allow-Insecure-Connections","false","","",""},
                {"appSettings","add","EnableLegacyChecksumFallback","1","Enabled-Legacy-Checksum-Fallback","false","","",""},
                {"appSettings","add","EnableLoginAutocomplete","1","Enable-Login-Autocomplete","false","","",""},
                {"appSettings","add","WindowsServerLocaleFormat","2","Windows-Server-Locale-Format","","","",""},
                {"appSettings","add","MaxImportQueueSize","2","Maximum-Import-Queue-Size","5","","",""},
                {"appSettings","add","EnableBrowserPdfViewer","1","Enable-Browser-PDF-Viewer","true","","",""},
                {"appSettings","add","pingTimerForScanServiceInSeconds","2","Ping-Timer-For-Scan-Service","10","","",""},
                {"appSettings","add","UseLegacySharePointAuthentication","1","Use-Legacy-SharePoint-Authentication","false","","",""},
                {"appSettings","add","MultiFormViewerOrigin","2","Multi-Form-Viewer-Origin","[origin]","","",""}
            }
        },
        {
            "Hyland.Web.DashboardViewer", new string[,]
            {
                {"Hyland.Web.DashboardViewer","enableExportDashboard","value","1","Enable-Export-Dashboard","true","","",""},
                {"Hyland.Web.DashboardViewer","enableExportDashboardItems","value","1","Enable-Export-Dashboard-Items","true","","",""},
                {"Hyland.Web.DashboardViewer","reportPagingLimit","value","2","Reporting-Page-Limit","50","","",""}
            }
        },
        {
            "Hyland.Web.HealthcareWebViewer", new string[,]
            {
                {"Hyland.Web.HealthcareWebViewer","datasource","value","2","Healthcare-Web-Viewer-Data-Source","","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableHTTPDataSource","value","1","Healthcare-Web-Viewer-Enable-HTTP-Data-Source","false","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableDeficiencyViewing","value","1","Healthcare-Web-Viewer-Enable-Deficiency-Viewing","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","enablePhysicianAcknowledgment","value","1","Healthcare-Web-Viewer-Enable-Physician-Acknowledgement","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableDocumentCorrection","value","1","Healthcare-Web-Viewer-Enable-Document-Correction","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","readonlyHTMLForms","value","2","Healthcare-Web-Viewer-Read-Only-HTML-Forms","all","","",""},
                {"Hyland.Web.HealthcareWebViewer","readonlyUnityForms","value","2","Healthcare-Web-Viewer-Read-Only-Unity-Forms","all","","",""},
                {"Hyland.Web.HealthcareWebViewer","enableEpicWebViewerApi","value","1","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API","true","","",""},
                {"Hyland.Web.HealthcareWebViewer","epicScanViewerApi/enabled","value","1","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Interoperability-Enabled","false","","",""},
                {"Hyland.Web.HealthcareWebViewer","epicScanViewerApi/displayDocumentFailedTimeout","value","2","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Failed-Timeout","10","","",""},
                {"Hyland.Web.HealthcareWebViewer","epicScanViewerApi/displayDocumentMessageInterval","value","2","Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Message-Interval","1","","",""},
                {"Hyland.Web.HealthcareWebViewer","IsEnabled","","1","Enable-Healthcare-Web-Viewer","false","","",""}
            }
        },
        {
            "system.web", new string[,]
            {
                {"system.web","sessionState","timeout","2","Session-Timeout","20","","2","1440"},
                {"system.web","sessionState","cookieSameSite","2","Samesite-Cookie-Policy","Lax","","",""},
                {"system.web","authentication","mode","2","Authentication-Mode","Windows","","",""},
                {"system.web","httpRuntime","maxRequestLength","2","HTTP-Runtime-Maximum-Request-Length-KB","4096","","0",""},
                {"system.web","httpRuntime","executionTimeout","2","HTTP-Runtime-Execution-Timeout-Seconds","90","","10",""}
            }
        },
        {
            "system.webServer", new string[,]
            {
                {"system.webServer","security/requestFiltering/requestLimits","maxAllowedContentLength","2","Max-Allowed-Content-Length","30000000","","0",""}
            }
        },
        {
            "system.diagnostics", new string[,]
            {
                {"system.diagnostics","switches/add[@name='hylandTracing']","value","2","Tracing-Info-Level","0","","0","4"}
            }
        },
        {
            "Hyland.Logging", new string[,]
            {

            }
        },
        {
            "ADFS", new string[,]
            {

            }
        },
        {
            "NavigationPanel", new string[,]
            {

            }
        },
        {
            "CustomValidation", new string[,]
            {

            }
        }
    };



    /*
     ***********************************************************
     *              Custom Validation Dictionaries
     ***********************************************************
     */
    private readonly Dictionary<string, string[]> customValidationPagesDictionary211 = new Dictionary<string, string[]>
    {
        {"/BatchIndexing/Indexing.aspx", new[] {"/BatchIndexing/Indexing.aspx", "Indexing scanned documents", "Custom-Validation-Index-Scanned-Documents"}},
        {"/BatchIndexing/IndexingCreateNew.aspx", new[] {"/BatchIndexing/IndexingCreateNew.aspx", "Creating a new document during indexing", "Custom-Validation-Create-New-Document-During-Indexing"}},
        {"/BriefcaseUpload.aspx", new[] {"/BriefcaseUpload.aspx", "Importing a document into a briefcase", "Custom-Validation-Importing-A-Document-Into-A-Briefcase"}},
        {"/Collaboration/CollabRetrieve.aspx", new[] {"/Collaboration/CollabRetrieve.aspx", "Attaching a document to a discussion post in Collaboration", "Custom-Validation-Attaching-A-Document-To-A-Discussion-Post-In-Collaboration"}},
        {"/CustomQuery.aspx", new[] {"/CustomQuery.aspx", "Using custom queries", "Custom-Validation-Using-Custom-Queries"}},
        {"/docpop/docpopURLCreator.aspx", new[] {"/docpop/docpopURLCreator.aspx", "Creating URLs for DocPop", "Custom-Validation-Creating-URLs-For-DocPop"}},
        {"/EmbeddedPage/CreateNewDocument.aspx", new[] {"/EmbeddedPage/CreateNewDocument.aspx", "Creating a new document from the context menu", "Custom-Validation-Creating-A-New-Document-From-The-Context-Menu"}},
        {"/EmbeddedPage/Reindex.aspx", new[] {"/EmbeddedPage/Reindex.aspx", "Reindexing a document from the context menu or from Workflow", "Custom-Validation-Reindexing-A-Document-From-The-Context-Menu-From-Workflow"}},
        {"/EmbeddedPage/ViewKeywords.aspx", new[] {"/EmbeddedPage/ViewKeywords.aspx", "Viewing a document's keywords", "Custom-Validation-Viewing-A-Documents-Keywords"}},
        {"/FileUploadEnhanced.aspx", new[] {"/FileUploadEnhanced.aspx", "Importing a document", "Custom-Validation-Importing-A-Document"}},
        {"/Foldering/CreateNewFolder.aspx", new[] {"/Foldering/CreateNewFolder.aspx", "Creating a new folder", "Custom-Validation-Creating-A-New-Folder"}},
        {"/Foldering/FolderQuery.aspx", new[] {"/Foldering/FolderQuery.aspx", "Performing a folder query", "Custom-Validation-Performing-A-Folder-Query"}},
        {"/Foldering/ModifyFolderKeywords.aspx", new[] {"/Foldering/ModifyFolderKeywords.aspx", "Modifying folder keywords", "Custom-Validation-Modifying-Folder-Keywords"}},
        {"/Foldering/ModifyFolderContentsKeywords.aspx", new[] {"/Foldering/ModifyFolderContentsKeywords.aspx", "Modifying folder contents keywords", "Custom-Validation-Modifying-Folder-Contents-Keywords"}},
        {"/PhysicalRecords/ViewRecord.aspx", new[] {"/PhysicalRecords/ViewRecord.aspx", "Viewing an item in Physical Records Management", "Custom-Validation-Viewing-An-Item-In-Physicial-Records-Management"}},
        {"/Retrieve.aspx", new[] {"/Retrieve.aspx", "Standard document retrieval", "Custom-Validation-Standard-Document-Retrieval"}},
        {"/Scan.aspx", new[] {"/Scan.aspx", "Scanning a document", "Custom-Validation-Scanning-A-Document"}},
        {"/WFFileUpload.aspx", new[] {"/WFFileUpload.aspx", "Uploading a file in Workflow", "Custom-Validation-Uploading-A-File-In-Workflow"}}
    };

    private readonly Dictionary<string, string[]> customValidationPagesDictionary221 = new Dictionary<string, string[]>
    {
        {"/BatchIndexing/Indexing.aspx", new[] {"/BatchIndexing/Indexing.aspx", "Indexing scanned documents", "Custom-Validation-Index-Scanned-Documents"}},
        {"/BatchIndexing/IndexingCreateNew.aspx", new[] {"/BatchIndexing/IndexingCreateNew.aspx", "Creating a new document during indexing", "Custom-Validation-Create-New-Document-During-Indexing"}},
        {"/BriefcaseUpload.aspx", new[] {"/BriefcaseUpload.aspx", "Importing a document into a briefcase", "Custom-Validation-Importing-A-Document-Into-A-Briefcase"}},
        {"/Collaboration/CollabRetrieve.aspx", new[] {"/Collaboration/CollabRetrieve.aspx", "Attaching a document to a discussion post in Collaboration", "Custom-Validation-Attaching-A-Document-To-A-Discussion-Post-In-Collaboration"}},
        {"/CustomQuery.aspx", new[] {"/CustomQuery.aspx", "Using custom queries", "Custom-Validation-Using-Custom-Queries"}},
        {"/docpop/docpopURLCreator.aspx", new[] {"/docpop/docpopURLCreator.aspx", "Creating URLs for DocPop", "Custom-Validation-Creating-URLs-For-DocPop"}},
        {"/EmbeddedPage/CreateNewDocument.aspx", new[] {"/EmbeddedPage/CreateNewDocument.aspx", "Creating a new document from the context menu", "Custom-Validation-Creating-A-New-Document-From-The-Context-Menu"}},
        {"/EmbeddedPage/Reindex.aspx", new[] {"/EmbeddedPage/Reindex.aspx", "Reindexing a document from the context menu or from Workflow", "Custom-Validation-Reindexing-A-Document-From-The-Context-Menu-From-Workflow"}},
        {"/EmbeddedPage/ViewKeywords.aspx", new[] {"/EmbeddedPage/ViewKeywords.aspx", "Viewing a document's keywords", "Custom-Validation-Viewing-A-Documents-Keywords"}},
        {"/FileUploadEnhanced.aspx", new[] {"/FileUploadEnhanced.aspx", "Importing a document", "Custom-Validation-Importing-A-Document"}},
        {"/Foldering/CreateNewFolder.aspx", new[] {"/Foldering/CreateNewFolder.aspx", "Creating a new folder", "Custom-Validation-Creating-A-New-Folder"}},
        {"/Foldering/FolderQuery.aspx", new[] {"/Foldering/FolderQuery.aspx", "Performing a folder query", "Custom-Validation-Performing-A-Folder-Query"}},
        {"/Foldering/ModifyFolderKeywords.aspx", new[] {"/Foldering/ModifyFolderKeywords.aspx", "Modifying folder keywords", "Custom-Validation-Modifying-Folder-Keywords"}},
        {"/Foldering/ModifyFolderContentsKeywords.aspx", new[] {"/Foldering/ModifyFolderContentsKeywords.aspx", "Modifying folder contents keywords", "Custom-Validation-Modifying-Folder-Contents-Keywords"}},
        {"/PhysicalRecords/ViewRecord.aspx", new[] {"/PhysicalRecords/ViewRecord.aspx", "Viewing an item in Physical Records Management", "Custom-Validation-Viewing-An-Item-In-Physicial-Records-Management"}},
        {"/Retrieve.aspx", new[] {"/Retrieve.aspx", "Standard document retrieval", "Custom-Validation-Standard-Document-Retrieval"}},
        {"/Scan.aspx", new[] {"/Scan.aspx", "Scanning a document", "Custom-Validation-Scanning-A-Document"}},
        {"/WFFileUpload.aspx", new[] {"/WFFileUpload.aspx", "Uploading a file in Workflow", "Custom-Validation-Uploading-A-File-In-Workflow"}}
    };

    private readonly Dictionary<string, string[]> customValidationPagesDictionary231 = new Dictionary<string, string[]>
    {
        {"/BatchIndexing/Indexing.aspx", new[] {"/BatchIndexing/Indexing.aspx", "Indexing scanned documents", "Custom-Validation-Index-Scanned-Documents"}},
        {"/BatchIndexing/IndexingCreateNew.aspx", new[] {"/BatchIndexing/IndexingCreateNew.aspx", "Creating a new document during indexing", "Custom-Validation-Create-New-Document-During-Indexing"}},
        {"/Collaboration/CollabRetrieve.aspx", new[] {"/Collaboration/CollabRetrieve.aspx", "Attaching a document to a discussion post in Collaboration", "Custom-Validation-Attaching-A-Document-To-A-Discussion-Post-In-Collaboration"}},
        {"/CustomQuery.aspx", new[] {"/CustomQuery.aspx", "Using custom queries", "Custom-Validation-Using-Custom-Queries"}},
        {"/docpop/docpopURLCreator.aspx", new[] {"/docpop/docpopURLCreator.aspx", "Creating URLs for DocPop", "Custom-Validation-Creating-URLs-For-DocPop"}},
        {"/EmbeddedPage/CreateNewDocument.aspx", new[] {"/EmbeddedPage/CreateNewDocument.aspx", "Creating a new document from the context menu", "Custom-Validation-Creating-A-New-Document-From-The-Context-Menu"}},
        {"/EmbeddedPage/Reindex.aspx", new[] {"/EmbeddedPage/Reindex.aspx", "Reindexing a document from the context menu or from Workflow", "Custom-Validation-Reindexing-A-Document-From-The-Context-Menu-From-Workflow"}},
        {"/EmbeddedPage/ViewKeywords.aspx", new[] {"/EmbeddedPage/ViewKeywords.aspx", "Viewing a document's keywords", "Custom-Validation-Viewing-A-Documents-Keywords"}},
        {"/FileUploadEnhanced.aspx", new[] {"/FileUploadEnhanced.aspx", "Importing a document", "Custom-Validation-Importing-A-Document"}},
        {"/Foldering/CreateNewFolder.aspx", new[] {"/Foldering/CreateNewFolder.aspx", "Creating a new folder", "Custom-Validation-Creating-A-New-Folder"}},
        {"/Foldering/FolderQuery.aspx", new[] {"/Foldering/FolderQuery.aspx", "Performing a folder query", "Custom-Validation-Performing-A-Folder-Query"}},
        {"/Foldering/ModifyFolderKeywords.aspx", new[] {"/Foldering/ModifyFolderKeywords.aspx", "Modifying folder keywords", "Custom-Validation-Modifying-Folder-Keywords"}},
        {"/Foldering/ModifyFolderContentsKeywords.aspx", new[] {"/Foldering/ModifyFolderContentsKeywords.aspx", "Modifying folder contents keywords", "Custom-Validation-Modifying-Folder-Contents-Keywords"}},
        {"/PhysicalRecords/ViewRecord.aspx", new[] {"/PhysicalRecords/ViewRecord.aspx", "Viewing an item in Physical Records Management", "Custom-Validation-Viewing-An-Item-In-Physicial-Records-Management"}},
        {"/Retrieve.aspx", new[] {"/Retrieve.aspx", "Standard document retrieval", "Custom-Validation-Standard-Document-Retrieval"}},
        {"/Scan.aspx", new[] {"/Scan.aspx", "Scanning a document", "Custom-Validation-Scanning-A-Document"}},
        {"/WFFileUpload.aspx", new[] {"/WFFileUpload.aspx", "Uploading a file in Workflow", "Custom-Validation-Uploading-A-File-In-Workflow"}}
    };

    private readonly Dictionary<string, string[]> customValidationPagesDictionary241 = new Dictionary<string, string[]>
    {
        {"/BatchIndexing/Indexing.aspx", new[] {"/BatchIndexing/Indexing.aspx", "Indexing scanned documents", "Custom-Validation-Index-Scanned-Documents"}},
        {"/BatchIndexing/IndexingCreateNew.aspx", new[] {"/BatchIndexing/IndexingCreateNew.aspx", "Creating a new document during indexing", "Custom-Validation-Create-New-Document-During-Indexing"}},
        {"/Collaboration/CollabRetrieve.aspx", new[] {"/Collaboration/CollabRetrieve.aspx", "Attaching a document to a discussion post in Collaboration", "Custom-Validation-Attaching-A-Document-To-A-Discussion-Post-In-Collaboration"}},
        {"/CustomQuery.aspx", new[] {"/CustomQuery.aspx", "Using custom queries", "Custom-Validation-Using-Custom-Queries"}},
        {"/docpop/docpopURLCreator.aspx", new[] {"/docpop/docpopURLCreator.aspx", "Creating URLs for DocPop", "Custom-Validation-Creating-URLs-For-DocPop"}},
        {"/EmbeddedPage/CreateNewDocument.aspx", new[] {"/EmbeddedPage/CreateNewDocument.aspx", "Creating a new document from the context menu", "Custom-Validation-Creating-A-New-Document-From-The-Context-Menu"}},
        {"/EmbeddedPage/Reindex.aspx", new[] {"/EmbeddedPage/Reindex.aspx", "Reindexing a document from the context menu or from Workflow", "Custom-Validation-Reindexing-A-Document-From-The-Context-Menu-From-Workflow"}},
        {"/EmbeddedPage/ViewKeywords.aspx", new[] {"/EmbeddedPage/ViewKeywords.aspx", "Viewing a document's keywords", "Custom-Validation-Viewing-A-Documents-Keywords"}},
        {"/FileUploadEnhanced.aspx", new[] {"/FileUploadEnhanced.aspx", "Importing a document", "Custom-Validation-Importing-A-Document"}},
        {"/Foldering/CreateNewFolder.aspx", new[] {"/Foldering/CreateNewFolder.aspx", "Creating a new folder", "Custom-Validation-Creating-A-New-Folder"}},
        {"/Foldering/FolderQuery.aspx", new[] {"/Foldering/FolderQuery.aspx", "Performing a folder query", "Custom-Validation-Performing-A-Folder-Query"}},
        {"/Foldering/ModifyFolderKeywords.aspx", new[] {"/Foldering/ModifyFolderKeywords.aspx", "Modifying folder keywords", "Custom-Validation-Modifying-Folder-Keywords"}},
        {"/Foldering/ModifyFolderContentsKeywords.aspx", new[] {"/Foldering/ModifyFolderContentsKeywords.aspx", "Modifying folder contents keywords", "Custom-Validation-Modifying-Folder-Contents-Keywords"}},
        {"/PhysicalRecords/ViewRecord.aspx", new[] {"/PhysicalRecords/ViewRecord.aspx", "Viewing an item in Physical Records Management", "Custom-Validation-Viewing-An-Item-In-Physicial-Records-Management"}},
        {"/Retrieve.aspx", new[] {"/Retrieve.aspx", "Standard document retrieval", "Custom-Validation-Standard-Document-Retrieval"}},
        {"/Scan.aspx", new[] {"/Scan.aspx", "Scanning a document", "Custom-Validation-Scanning-A-Document"}},
        {"/WFFileUpload.aspx", new[] {"/WFFileUpload.aspx", "Uploading a file in Workflow", "Custom-Validation-Uploading-A-File-In-Workflow"}}
    };


    /*
     ***********************************************************
     *                  Login Pages Arrays
     ***********************************************************
     */
    /* 21.1 Login Pages */
    private readonly string[] ApplicationServer211LoginPages = new string[]
    {
        "AuthService.asmx", "AuthOptServicePipeline.ashx"
    };

    private readonly string[] ReportingViewer211LoginPages = new string[]
    {
        "Viewer.aspx"
    };

    private readonly string[] WebServer211LoginPages = new string[]
    {
        "AuthService.asmx", "AuthOptServicePipeline.ashx", "Login.aspx", "AccLogin.aspx", "AccSSOLoginPage.aspx", "DKTReader.aspx", "UnityForm.aspx", "Diagnostics/Diagnostics.aspx", "RecoverAppServerSession.aspx", "DocPop/Correction.aspx",
        "DocPop/DocPop.aspx", "DocPop/DocPopURLCreator.aspx", "DocPop/FormPop.aspx", "DocPop/PDFPop.aspx", "DocPop/ReindexPop.aspx", "DocPop/SAPDocPop.aspx", "FolderPop/FolderPop.aspx", "FolderPop/FolderPopURLCreator.aspx", "Workflow/WFLogin.aspx", "WorkView/FilterPop.aspx",
        "WorkView/FilterPopURLCreator.aspx", "WorkView/ObjectPop.aspx", "WorkView/WVLogin.aspx", "SharePointPortal.aspx"
    };

    /* 22.1 Login Pages */
    private readonly string[] ApplicationServer221LoginPages = new string[]
    {
        "AuthService.asmx", "AuthOptServicePipeline.ashx"
    };

    private readonly string[] ReportingViewer221LoginPages = new string[]
    {
        "Viewer.aspx"
    };

    private readonly string[] WebServer221LoginPages = new string[]
    {
        "AuthService.asmx", "AuthOptServicePipeline.ashx", "Login.aspx", "AccLogin.aspx", "AccSSOLoginPage.aspx", "DKTReader.aspx", "UnityForm.aspx", "Diagnostics/Diagnostics.aspx", "RecoverAppServerSession.aspx", "DocPop/Correction.aspx",
        "DocPop/DocPop.aspx", "DocPop/DocPopURLCreator.aspx", "DocPop/FormPop.aspx", "DocPop/PDFPop.aspx", "DocPop/ReindexPop.aspx", "DocPop/SAPDocPop.aspx", "FolderPop/FolderPop.aspx", "FolderPop/FolderPopURLCreator.aspx", "Workflow/WFLogin.aspx", "WorkView/FilterPop.aspx",
        "WorkView/FilterPopURLCreator.aspx", "WorkView/ObjectPop.aspx", "WorkView/WVLogin.aspx", "SharePointPortal.aspx"
    };

    /* 23.1 Login Pages */
    private readonly string[] ApplicationServer231LoginPages = new string[]
    {
        "AuthService.asmx", "AuthOptServicePipeline.ashx"
    };

    private readonly string[] ReportingViewer231LoginPages = new string[]
    {
        "Viewer.aspx"
    };

    private readonly string[] WebServer231LoginPages = new string[]
    {
        "AuthService.asmx", "AuthOptServicePipeline.ashx", "Login.aspx", "AccLogin.aspx", "AccSSOLoginPage.aspx", "DKTReader.aspx", "UnityForm.aspx", "Diagnostics/Diagnostics.aspx", "RecoverAppServerSession.aspx", "DocPop/Correction.aspx",
        "DocPop/DocPop.aspx", "DocPop/DocPopURLCreator.aspx", "DocPop/FormPop.aspx", "DocPop/PDFPop.aspx", "DocPop/ReindexPop.aspx", "DocPop/SAPDocPop.aspx", "FolderPop/FolderPop.aspx", "FolderPop/FolderPopURLCreator.aspx", "Workflow/WFLogin.aspx", "WorkView/FilterPop.aspx",
        "WorkView/FilterPopURLCreator.aspx", "WorkView/ObjectPop.aspx", "WorkView/WVLogin.aspx", "SharePointPortal.aspx"
    };


    /* 24.1 Login Pages */
    private readonly string[] ApplicationServer241LoginPages = new string[]
    {
        "AuthService.asmx", "AuthOptServicePipeline.ashx"
    };

    private readonly string[] ReportingViewer241LoginPages = new string[]
    {
        "Viewer.aspx"
    };

    private readonly string[] WebServer241LoginPages = new string[]
    {
        "AuthService.asmx", "AuthOptServicePipeline.ashx", "Login.aspx", "AccLogin.aspx", "AccSSOLoginPage.aspx", "DKTReader.aspx", "UnityForm.aspx", "Diagnostics/Diagnostics.aspx", "RecoverAppServerSession.aspx", "DocPop/Correction.aspx",
        "DocPop/DocPop.aspx", "DocPop/DocPopURLCreator.aspx", "DocPop/FormPop.aspx", "DocPop/PDFPop.aspx", "DocPop/ReindexPop.aspx", "DocPop/SAPDocPop.aspx", "FolderPop/FolderPop.aspx", "FolderPop/FolderPopURLCreator.aspx", "Workflow/WFLogin.aspx", "WorkView/FilterPop.aspx",
        "WorkView/FilterPopURLCreator.aspx", "WorkView/ObjectPop.aspx", "WorkView/WVLogin.aspx", "SharePointPortal.aspx"
    };


    /*
     ***********************************************************
     *           Diagnostics Settings Profiles Arrays
     ***********************************************************
     */
    private readonly string[] diagnosticsSettingsProfiles211 = new string[] {
        "asp.net", "ChangeTracking", "client", "configuration", "error", "EpicSettings", "fulltext", "ihe", "ldap", "logging", "mobile.service", "None", "Patient-Window", "report.services", "service", "tcservices", "timer", "undefined", "vbscript", "wcf", "workflow", "cache", "chromium-service-pim", "configuration", "db", "file", "hl7", "image-rendering-pim", "locking", "mobile.raw", "named-pipe-core", "OnBase", "pim-manager", "scriptexecution", "TC", "tcverbose", "trace", "unity", "warnings", "web.service"
    };

    private readonly string[] diagnosticsSettingsProfiles221 = new string[] {
        "asp.net", "ChangeTracking", "client", "configuration", "error", "EpicSettings", "fulltext", "ihe", "ldap", "logging", "mobile.service", "None", "Patient-Window", "report.services", "service", "tcservices", "timer", "undefined", "vbscript", "wcf", "workflow", "cache", "chromium-service-pim", "configuration", "db", "file", "hl7", "image-rendering-pim", "locking", "mobile.raw", "named-pipe-core", "OnBase", "pim-manager", "scriptexecution", "TC", "tcverbose", "trace", "unity", "warnings", "web.service"
    };

    private readonly string[] diagnosticsSettingsProfiles231 = new string[] {
        "asp.net", "ChangeTracking", "client", "configuration", "error", "EpicSettings", "fulltext", "ihe", "ldap", "logging", "mobile.service", "None", "Patient-Window", "report.services", "service", "tcservices", "timer", "undefined", "vbscript", "wcf", "workflow", "cache", "chromium-service-pim", "configuration", "db", "file", "hl7", "image-rendering-pim", "locking", "mobile.raw", "named-pipe-core", "OnBase", "pim-manager", "scriptexecution", "TC", "tcverbose", "trace", "unity", "warnings", "web.service"
    };

    private readonly string[] diagnosticsSettingsProfiles241 = new string[] {
        "asp.net", "ChangeTracking", "client", "configuration", "error", "EpicSettings", "fulltext", "ihe", "ldap", "logging", "mobile.service", "None", "Patient-Window", "report.services", "service", "tcservices", "timer", "undefined", "vbscript", "wcf", "workflow", "cache", "chromium-service-pim", "configuration", "db", "file", "hl7", "image-rendering-pim", "locking", "mobile.raw", "named-pipe-core", "OnBase", "pim-manager", "scriptexecution", "TC", "tcverbose", "trace", "unity", "warnings", "web.service"
    };


    /*
     ***********************************************************
     *                Elements To Hide Arrays
     ***********************************************************
     */
    /* Version 21.1 Arrays */
    private readonly List<string> AgendaOnline211ElementsToHide = new List<string>
    {
        "Google-Analytics"
    };

    private readonly List<string> ApplicationServer211ElementsToHide = new List<string>
    {
        "ShareBaseLink-SettingElement",
        "ShareBaseSection",
        "Doc-Linker-SMART-On-FHIR-Application-ID-SettingElement",
        "Use-New-Keyword-Data-Cache-Implementation-SettingElement",
        "Configuration-Import-Database-Timeout-SettingElement",
        "PIM:HyRCS:ExternalBaseUri-SettingElement",
        "PIM:HyRCS:Port-SettingElement",
        "PIM:ImageProcess-SettingElement",
        "PIM:ChromiumProcess-SettingElement",
        "HyRCS:PageCountLimit-SettingElement"
    };

    private readonly List<string> ElectronicPlanReview211ElementsToHide = new List<string>
    {

    };

    private readonly List<string> GatewayCachingServer211ElementsToHide = new List<string>
    {

    };

    private readonly List<string> HealthcareFormManager211ElementsToHide = new List<string>
    {

    };

    private readonly List<string> PatientWindow211ElementsToHide = new List<string>
    {
        "Enable-Bowser-PDF-Viewer-Setting-Element",
        "Keyword-Panel-View-Type-Setting-Element",
        "Re-Index-Menu-Setting-Element",
        "Send-To-Print-Queue-Menu-Setting-Element",
        "File-Menu-Setting-Element",
        "Create-Document-Menu-Setting-Element",
        "Workflow-Menu-Setting-Element",
        "JSON-Serialization-Max-Length",
        "Menus-SettingElement"
    };

    private readonly List<string> PublicAccessLegacy211ElementsToHide = new List<string>
    {

    };

    private readonly List<string> PublicAccessNextGen211ElementsToHide = new List<string>
    {
        "Always-Wildcard-Alphanumeric-Keywords-SettingElement"
    };

    private readonly List<string> ReportingViewer211ElementsToHide = new List<string>
    {
        "Dashboard-Cache-Timeout-SettingElement"
    };

    private readonly List<string> WebServer211ElementsToHide = new List<string>
    {
        "Ping-Timer-For-Scan-Service-SettingElement",
        "Use-Legacy-SharePoint-Authentication-SettingElement",
        "Target-Origin-SettingElement"
    };

    /* Version 22.1 Arrays */
    private readonly List<string> AgendaOnline221ElementsToHide = new List<string>
    {
        "Google-Analytics"
    };

    private readonly List<string> ApplicationServer221ElementsToHide = new List<string>
    {
        "Hyland-Services-AppPool-Username-ElementSection",
        "Hyland-Services-AppPool-Password-ElementSection",
        "Doc-Linker-SMART-On-FHIR-Application-ID-SettingElement",
        "Use-New-Keyword-Data-Cache-Implementation-SettingElement",
        "Configuration-Import-Database-Timeout-SettingElement",
        "PIM:HyRCS:ExternalBaseUri-SettingElement",
        "PIM:HyRCS:Port-SettingElement",
        "PIM:ImageProcess-SettingElement",
        "PIM:ChromiumProcess-SettingElement",
        "HyRCS:PageCountLimit-SettingElement",
        "IDOLLink-SettingElement",
        "IDOLSection"
    };

    private readonly List<string> ElectronicPlanReview221ElementsToHide = new List<string>
    {

    };

    private readonly List<string> GatewayCachingServer221ElementsToHide = new List<string>
    {

    };

    private readonly List<string> HealthcareFormManager221ElementsToHide = new List<string>
    {
        "Allowed-Domain-SectionElement",
        "Allow-NT-Authentication-On-Forwarding-SettingElement"
    };

    private readonly List<string> PatientWindow221ElementsToHide = new List<string>
    {
        "Enable-Bowser-PDF-Viewer-Setting-Element",
        "Keyword-Panel-View-Type-Setting-Element",
        "Re-Index-Menu-Setting-Element",
        "Send-To-Print-Queue-Menu-Setting-Element",
        "File-Menu-Setting-Element",
        "Create-Document-Menu-Setting-Element",
        "Workflow-Menu-Setting-Element",
        "JSON-Serialization-Max-Length",
        "Menus-SettingElement"
    };

    private readonly List<string> PublicAccessNextGen221ElementsToHide = new List<string>
    {
        "Always-Wildcard-Alphanumeric-Keywords-SettingElement",
        "Allow-NT-Authentication-On-Forwarding-SettingElement"
    };

    private readonly List<string> ReportingViewer221ElementsToHide = new List<string>
    {

    };

    private readonly List<string> WebServer221ElementsToHide = new List<string>
    {
        "EDM-Briefcase-SettingElement",
        "Native-Mail-System-SettingElement",
        "Use-Web-Mail-SettingElement",
        "Web-Client-Type-SettingElement",
        "First-Page-Menu-SettingElement",
        "Goto-Page-Menu-SettingElement",
        "Last-Page-Menu-SettingElement",
        "Mail-Recipient-Menu-SettingElement",
        "Next-Page-Menu-SettingElement",
        "Pages-Menu-SettingElement",
        "Previous-Page-Menu-SettingElement",
        "Text-Search-Menu-SettingElement",
        "Viewer-Control-Menu-SettingElement",
        "Zoom-In-Menu-SettingElement",
        "Zoom-Out-Menu-SettingElement",
        "Autozoom-Thumbnail-Configuration-SettingElement",
        "Open-Microsoft-Office-Documents-in-Separate-Window-SettingElement",
        "Silverlight-SectionElement",
        "Enable-Desktop-Host-SettingElement",
        "Multi-Form-Viewer-Origin-SettingElement",
        "ActiveXSection",
        "ActiveXLink-SettingElement",
        "Use-Legacy-SharePoint-Authentication-SettingElement",
        "Target-Origin-SettingElement",
        "ActiveXOnlySection"
    };

    /* Version 23.1 Arrays */
    private readonly List<string> AgendaOnline231ElementsToHide = new List<string>
    {

    };

    private readonly List<string> ApplicationServer231ElementsToHide = new List<string>
    {
        "Hyland-Services-AppPool-Username-ElementSection",
        "Hyland-Services-AppPool-Password-ElementSection",
        "Integrations-EIS-Use-HTML-Client-Type-SettingElement",
        "WOPISection",
        "WOPILink-SettingElement",
        "IDOLLink-SettingElement",
        "IDOLSection"
    };

    private readonly List<string> ElectronicPlanReview231ElementsToHide = new List<string>
    {

    };

    private readonly List<string> GatewayCachingServer231ElementsToHide = new List<string>
    {

    };

    private readonly List<string> HealthcareFormManager231ElementsToHide = new List<string>
    {
        "Allowed-Domain-SectionElement",
        "Allow-NT-Authentication-On-Forwarding-SettingElement"
    };

    private readonly List<string> PatientWindow231ElementsToHide = new List<string>
    {

    };

    private readonly List<string> PublicAccessNextGen231ElementsToHide = new List<string>
    {
        "Allow-NT-Authentication-On-Forwarding-SettingElement"
    };

    private readonly List<string> ReportingViewer231ElementsToHide = new List<string>
    {

    };

    private readonly List<string> WebServer231ElementsToHide = new List<string>
    {
        "EDM-Briefcase-SettingElement",
        "Native-Mail-System-SettingElement",
        "Use-Web-Mail-SettingElement",
        "Web-Client-Type-SettingElement",
        "First-Page-Menu-SettingElement",
        "Goto-Page-Menu-SettingElement",
        "Last-Page-Menu-SettingElement",
        "Mail-Recipient-Menu-SettingElement",
        "Next-Page-Menu-SettingElement",
        "Pages-Menu-SettingElement",
        "Previous-Page-Menu-SettingElement",
        "Text-Search-Menu-SettingElement",
        "Viewer-Control-Menu-SettingElement",
        "Zoom-In-Menu-SettingElement",
        "Zoom-Out-Menu-SettingElement",
        "Autozoom-Thumbnail-Configuration-SettingElement",
        "Open-Microsoft-Office-Documents-in-Separate-Window-SettingElement",
        "Silverlight-SectionElement",
        "Enable-Desktop-Host-SettingElement",
        "ActiveXSection",
        "ActiveXLink-SettingElement",
        "Reselect-Delta-SectionElement",
        "WorkView-Client-URL-SettingElement",
        "Target-Origin-SettingElement",
        "ActiveXOnlySection"
    };

    /* Version 24.1 Arrays */
    private readonly List<string> AgendaOnline241ElementsToHide = new List<string>
    {

    };

    private readonly List<string> ApplicationServer241ElementsToHide = new List<string>
    {
        "Hyland-Services-AppPool-Username-ElementSection",
        "Hyland-Services-AppPool-Password-ElementSection",
        "IDOLLink-SettingElement",
        "IDOLSection"
    };

    private readonly List<string> ElectronicPlanReview241ElementsToHide = new List<string>
    {

    };

    private readonly List<string> HealthcareFormManager241ElementsToHide = new List<string>
    {
        "Allowed-Domain-SectionElement",
        "Allow-NT-Authentication-On-Forwarding-SettingElement"
    };

    private readonly List<string> PatientWindow241ElementsToHide = new List<string>
    {

    };

    private readonly List<string> PublicAccessNextGen241ElementsToHide = new List<string>
    {
        "Allow-NT-Authentication-On-Forwarding-SettingElement"
    };

    private readonly List<string> ReportingViewer241ElementsToHide = new List<string>
    {

    };

    private readonly List<string> WebServer241ElementsToHide = new List<string>
    {
        "EDM-Briefcase-SettingElement",
        "Native-Mail-System-SettingElement",
        "Use-Web-Mail-SettingElement",
        "Web-Client-Type-SettingElement",
        "First-Page-Menu-SettingElement",
        "Goto-Page-Menu-SettingElement",
        "Last-Page-Menu-SettingElement",
        "Mail-Recipient-Menu-SettingElement",
        "Next-Page-Menu-SettingElement",
        "Pages-Menu-SettingElement",
        "Previous-Page-Menu-SettingElement",
        "Text-Search-Menu-SettingElement",
        "Viewer-Control-Menu-SettingElement",
        "Zoom-In-Menu-SettingElement",
        "Zoom-Out-Menu-SettingElement",
        "Autozoom-Thumbnail-Configuration-SettingElement",
        "Open-Microsoft-Office-Documents-in-Separate-Window-SettingElement",
        "Silverlight-SectionElement",
        "Enable-Desktop-Host-SettingElement",
        "ActiveXSection",
        "ActiveXLink-SettingElement",
        "Reselect-Delta-SectionElement",
        "WorkView-Client-URL-SettingElement",
        //"Dashboard-Cache-Timeout-SettingElement",
        "Use-Theme-SettingElement",
        "Healthcare-Web-Viewer-Session-Timeout-SettingElement",
        "Allow-NT-Authentication-On-Forwarding-SettingElement",
        "ActiveXOnlySection"
    };


    /*
     ***********************************************************
     *                   Elements To Save
     ***********************************************************
     */
    /* Version 21.1 Arrays */
    private readonly List<string> AgendaOnline211ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "Hyland.Applications.AgendaPubAccess.PublicComment",
        "Hyland.Logging"
    };

    private readonly List<string> ApplicationServer211ElementsToSave = new List<string>
    {
        "appSettings",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "ADFS",
        "Hyland.ResponsiveApps",
        "Hyland.PlatterManagement",
        "Hyland.Services",
        "Hyland.XMLServices.DocumentConnector",
        "Hyland.Core.FullText",
        "Hyland.WorkView.Core",
        "Hyland.Core.IDOL",
        "root",
        "Hyland.Core.Wopi",
        "Hyland.Integrations.LOBBroker.LOBBRokerConfigSection",
        "Hyland.Authentication",
        "Hyland.Authentication-TrustedClients"
    };

    private readonly List<string> ElectronicPlanReview211ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging"
    };

    private readonly List<string> GatewayCachingServer211ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging"
    };

    private readonly List<string> HealthcareFormManager211ElementsToSave = new List<string>
    {
        "appSettings",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "system.diagnostics",
        "Hyland.Services.Client"
    };

    private readonly List<string> PatientWindow211ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "Hyland.Logging",
        "ADFS"
    };

    private readonly List<string> PublicAccessViewerLegacy211ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web"
    };

    private readonly List<string> PublicAccessViewerNextGen211ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web"
    };

    private readonly List<string> ReportingViewer211ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "system.diagnostics",
        "system.web.extensions"
    };

    private readonly List<string> WebServer211ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "Hyland.Web.DashboardViewer",
        "Hyland.Web.HealthcareWebViewer",
        "system.diagnostics",
        "ADFS",
        "CustomValidation",
        "NavigationPanel"
    };

    /* Version 22.1 Arrays */
    private readonly List<string> AgendaOnline221ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "Hyland.Applications.AgendaPubAccess.PublicComment",
        "Hyland.Logging"
    };

    private readonly List<string> ApplicationServer221ElementsToSave = new List<string>
    {
        "appSettings",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "ADFS",
        "Hyland.ResponsiveApps",
        "Hyland.PlatterManagement",
        "Hyland.Services",
        "Hyland.XMLServices.DocumentConnector",
        "Hyland.Core.FullText",
        "Hyland.WorkView.Core",
        "root",
        "Hyland.Core.Wopi",
        "Hyland.Integrations.LOBBroker.LOBBRokerConfigSection",
        "Hyland.Authentication",
        "Hyland.Authentication-TrustedClients"
    };

    private readonly List<string> ElectronicPlanReview221ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging"
    };

    private readonly List<string> GatewayCachingServer221ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging"
    };

    private readonly List<string> HealthcareFormManager221ElementsToSave = new List<string>
    {
        "appSettings",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "system.diagnostics",
        "Hyland.Services.Client"
    };

    private readonly List<string> PatientWindow221ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "Hyland.Logging",
        "ADFS"
    };

    private readonly List<string> PublicAccessViewerNextGen221ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web"
    };

    private readonly List<string> ReportingViewer221ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "system.diagnostics",
        "system.web.extensions"
    };

    private readonly List<string> WebServer221ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "Hyland.Web.DashboardViewer",
        "Hyland.Web.HealthcareWebViewer",
        "system.diagnostics",
        "ADFS",
        "CustomValidation",
        "NavigationPanel"
    };

    /* Version 23.1 Arrays */
    private readonly List<string> AgendaOnline231ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "Hyland.Applications.AgendaPubAccess.PublicComment",
        "Hyland.Logging"
    };

    private readonly List<string> ApplicationServer231ElementsToSave = new List<string>
    {
        "appSettings",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "ADFS",
        "Hyland.ResponsiveApps",
        "Hyland.PlatterManagement",
        "Hyland.Services",
        "Hyland.XMLServices.DocumentConnector",
        "Hyland.Core.FullText",
        "Hyland.WorkView.Core",
        "root",
        "Hyland.Integrations.LOBBroker.LOBBRokerConfigSection",
        "Hyland.Authentication",
        "Hyland.Authentication-TrustedClients"
    };

    private readonly List<string> ElectronicPlanReview231ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging"
    };

    private readonly List<string> GatewayCachingServer231ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging"
    };

    private readonly List<string> HealthcareFormManager231ElementsToSave = new List<string>
    {
        "appSettings",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "system.diagnostics",
        "Hyland.Services.Client"
    };

    private readonly List<string> PatientWindow231ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "Hyland.Logging",
        "ADFS"
    };

    private readonly List<string> PublicAccessViewerNextGen231ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web"
    };

    private readonly List<string> ReportingViewer231ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "system.diagnostics",
        "system.web.extensions"
    };

    private readonly List<string> WebServer231ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "Hyland.Web.DashboardViewer",
        "Hyland.Web.HealthcareWebViewer",
        "system.diagnostics",
        "ADFS",
        "CustomValidation",
        "NavigationPanel"
    };

    /* Version 24.1 Arrays */
    private readonly List<string> AgendaOnline241ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "Hyland.Applications.AgendaPubAccess.PublicComment",
        "Hyland.Logging"
    };

    private readonly List<string> ApplicationServer241ElementsToSave = new List<string>
    {
        "appSettings",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "ADFS",
        "Hyland.ResponsiveApps",
        "Hyland.PlatterManagement",
        "Hyland.Services",
        "Hyland.XMLServices.DocumentConnector",
        "Hyland.Core.FullText",
        "Hyland.WorkView.Core",
        "root",
        "Hyland.Integrations.LOBBroker.LOBBRokerConfigSection",
        "Hyland.Authentication",
        "Hyland.Authentication-TrustedClients"
    };

    private readonly List<string> ElectronicPlanReview241ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging"
    };

    private readonly List<string> HealthcareFormManager241ElementsToSave = new List<string>
    {
        "appSettings",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "system.diagnostics",
        "Hyland.Services.Client"
    };

    private readonly List<string> PatientWindow241ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "Hyland.Logging",
        "ADFS"
    };

    private readonly List<string> PublicAccessViewerNextGen241ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web"
    };

    private readonly List<string> ReportingViewer241ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "system.diagnostics",
        "system.web.extensions"
    };

    private readonly List<string> WebServer241ElementsToSave = new List<string>
    {
        "appSettings",
        "Hyland.Services.Client",
        "system.web",
        "system.webServer",
        "Hyland.Logging",
        "Hyland.Web.DashboardViewer",
        "Hyland.Web.HealthcareWebViewer",
        "system.diagnostics",
        "ADFS",
        "CustomValidation",
        "NavigationPanel"
    };


    /*
     ***********************************************************
     *         Web Application Tooltip Data Structures
     ***********************************************************
     */
    /* 211 Tooltip Objects */
    private readonly List<List<string>> AgendaOnline211Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stream-Chunk-Size-Tooltip",""},
        new List<string> {"Player-Source-File-Path-Tooltip","Path to directory where the media player resides."},
        new List<string> {"Player-Version-Tooltip","Version key of the media player."},
        new List<string> {"Min-Pool-Size-Tooltip","Minimum Pool Size"},
        new List<string> {"Max-Pool-Size-Tooltip","Maximum Pool Size"},
        new List<string> {"webpages-Enabled-Tooltip",""},
        new List<string> {"Session-Username-Tooltip","The OnBase user name for authentication."},
        new List<string> {"Session-Password-Tooltip","The OnBase password for authentication."},
        new List<string> {"Data-Source-Tooltip","The ODBC datasource utilized by the Application Server."},
        new List<string> {"Encrypt-Agenda-Online-Access-Tooltip", "Encrypt Agenda Public Access keys for enhanced security." }
    };

    private readonly List<List<string>> ApplicationServer211Tooltips = new List<List<string>>
    {
        new List<string> {"Server-Designation-Tooltip","(Optional) Enter a value to designate which server the user is connecting to, which will display in Web Diagnostics. This is helpful in a load balanced environment."},
        new List<string> {"Data-Source-Tooltip","The ODBC datasource utilized by the Application Server."},
        new List<string> {"Use-OS-Authentication-Tooltip","Set to true if the connection to the database should be made with OS Authentication instead of SQL Authentication. This requires an OS/domain user with access to the database to be configured as the user for this Application Server."},
        new List<string> {"Document-Query-Warning-Threshold-Tooltip","Display a warning message if the number of documents returned from a query exceeds this value. If Document Query Warning Threshold is greater than Document Query Limit, no warning message will be displayed."},
        new List<string> {"Document-Query-Limit-Tooltip","Document queries are limited when the number of returned documents exceeds this value."},
        new List<string> {"Item-Cache-Timeout-Tooltip","The number of seconds an item will exist within the item cache before it will be expired."},
        new List<string> {"Raw-Images-Tooltip","Images are sent directly to the viewer from the database instead of first being processed by ASP.NET on the server."},
        new List<string> {"Use-Isolated-Image-Process-Tooltip","Setting for initializing the out of process image rendering service."},
        new List<string> {"Compression-Quality-Tooltip","Controls the compression quality of color images and can be used to reduce memory usage when viewed. The default setting is 80 (measured in percent)."},
        new List<string> {"Enable-Isolated-Chromium-Process-Tooltip","Setting for initializing the Chromium Image service used by Unity Forms."},
        new List<string> {"Form-Save-To-TIFF-Timeout-Tooltip","Timeout in seconds for sending a Form to a TIFF file using the process image rendering service."},
        new List<string> {"Print-Image-Form-Via-PDF-Tooltip","Configuration to print image form via PDF. \"TRUE\" means printing via PDF else \"FALSE\" means printing via screenshot."},
        new List<string> {"TPCF-Worker-Location-Override-Tooltip","Specify a custom path for TPCF Worker directory"},
        new List<string> {"Default-Storage-Path-Tooltip","Default storage path for the File Monitoring Engine."},
        new List<string> {"Watch-Folder-Tooltip","The folder to monitor in Front Office Scanning."},
        new List<string> {"Site-ID-Keyword-Type-Tooltip","Site ID Keyword Type"},
        new List<string> {"Cleanup-Timer-Interval-Tooltip","Sets the time span (in seconds) after which the file monitoring system looks for changes."},
        new List<string> {"Max-File-Age-Tooltip","Maximum file age (in hours)."},
        new List<string> {"Integrations-EIS-Validate-Message-Schema-Tooltip","Set to true to perform validation on the Message Schema."},
        new List<string> {"Integrations-EIS-Continue-On-Validation-Error-Tooltip","Set to true to log an error and continue when Message Schema validation fails."},
        new List<string> {"Integrations-EIS-Data-Set-Cache-Cleanup-Interval-Tooltip","Data Set Cache Cleanup Interval (Minutes)."},
        new List<string> {"Integrations-EIS-AppNet-Directory-Tooltip","The location of the virtual directory where the Web Server resides. This setting is needed to generate DocPop URLs."},
        new List<string> {"Integrations-EIS-Use-HTML-Client-Type-Tooltip","Set to true to use HTML as the client type when generating DocPop links."},
        new List<string> {"Message-Broker-Monitor-Start-Delay-Tooltip","Delay in minutes to start the timer used by the Message Broker to monitor for message issues and completed messages needing archiving."},
        new List<string> {"GCS-Username-Tooltip","User Name to connect to GCS. Can be in plain text or use ASPNET_SETREG.exe to encrypt. For example: \"registry:HKLM\\SOFTWARE\\Hyland\\GCS\\UsageBasedBilling\\identity\\ASPNET_SETREG,userName\""},
        new List<string> {"GCS-Password-Tooltip","Password to connect to GCS. Can be in plain text or use ASPNET_SETREG.exe to encrypt. For example: \"registry:HKLM\\SOFTWARE\\Hyland\\GCS\\UsageBasedBilling\\identity\\ASPNET_SETREG,password\""},
        new List<string> {"Use-Legacy-Key-For-Usage-Based-Billing-Tooltip",""},
        new List<string> {"GCS-Phone-Home-Interval-Tooltip","Time interval (in minutes) to perform phone home to GCS server."},
        new List<string> {"Data-Capture-Server-WCF-Endpoint-Address-Tooltip","Data Capture Server WCF Endpoint Address"},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"OWIN-Application-Server-Origin-Tooltip","The application server origin used to create absolute links. In a load-balanced environment, hostname would be the load-balancer. Example: https://hostname/AppServer"},
        new List<string> {"OWIN-Automatic-App-Startup-Tooltip","Automatic App Startup"},
        new List<string> {"OWIN-App-Startup-Tooltip","Location of the OWIN startup class"},
        new List<string> {"Identity-Model-Server-URI-Tooltip",""},
        new List<string> {"Mobile-Apps-Path-Tooltip","Mobile Apps Path"},
        new List<string> {"CORS-Policy-Tooltip","CORS Policy"},
        new List<string> {"WorkView-Mobile-Endpoint-Tooltip","Check this box to enable this application as a WorkView Mobile Endpoint."},
        new List<string> {"Responsive-Apps-Endpoint-Tooltip","Check this box to enable this application as a Responsive Apps Endpoint."},
        new List<string> {"WOPI-Endpoint-Tooltip","Endpoint setting for Office Online Server"},
        new List<string> {"Sesame-Endpoint-Tooltip","Check this box to enable this application as a Sesame Endpoint."},
        new List<string> {"Governance-Rules-As-A-Service-Endpoint-Tooltip","Check this box to enable this application as a Governance Rules As A Service (GRAAS Endpoint."},
        new List<string> {"Web-BLOB-Passthrough-FHIR-Endpoint-Tooltip","Check this box to enable this application as a Web BLOB Passthrough (WBPT) FHIR Endpoint."},
        new List<string> {"SMART-On-FHIR-Application-ID-Tooltip",""},
        new List<string> {"PPL-Endpoint-Enabled-Tooltip","Check this box to enable this application as a PPL Endpoint."},
        new List<string> {"Forms-Endpoint-Tooltip","Check this box to enable this application as a Forms Endpoint."},
        new List<string> {"PPL-DocPop-URL-Tooltip","This is the URL for viewing Unity Forms in Patient Portal Link. Do not add a trailing slash."},
        new List<string> {"Statement-Composition-Cache-Limit-Tooltip","Maximum number of cached statement composition documents."},
        new List<string> {"Unity-Forms-Toggle-Max-Form-Width-Tooltip","Changes the Unity forms rendering behavior when form elements exceed the width of the form.<br>Set this to \"true\" to prevent the form from expanding to match the width of the largest element."},
        new List<string> {"owin:oia:msgItemTypeId-Tooltip",""},
        new List<string> {"owin:oia:lifeCycleId-Tooltip",""},
        new List<string> {"owin:oia:tmpFilePath-Tooltip",""},
        new List<string> {"owin:oia:tmpFileAgeInMs-Tooltip",""},
        new List<string> {"owin:oia:cleanupIntervalInMs-Tooltip",""},
        new List<string> {"Use-OnBase-Full-Text-Tooltip",""},
        new List<string> {"Content-Composer-IdP-Path-Tooltip",""},
        new List<string> {"Keyword-Data-Cache-Timeout-Tooltip","Timeout in minutes used to determine how long keyword metadata is stored in memory. WARNING, increasing this value over the default of 20 minutes will increase memory consumption on the application server. Lowering this value can result in undesirable behavior."},
        new List<string> {"Allow-Insecure-External-XSL-Tooltip",""},
        new List<string> {"Responsive-Apps-WorkView-API-URL-Tooltip","WorkViewApi is the path to the WorkView web api facet. Example: \"https://hostname/AppServer/private/workview/api/\""},
        new List<string> {"Responsive-Apps-WorkView-Files-URL-Tooltip","WorkViewFiles is the path to the WorkView static file server facet. Example: \"https://hostname/AppServer/private/workview/files/\""},
        new List<string> {"Responsive-Apps-API-URL-Tooltip","ResponsiveAppsApi is the path to the Responsive Apps web api facet. Example: \"https://hostname/AppServer/private/responsive-apps/api/\""},
        new List<string> {"Identity-Provider-URL-Tooltip","IdentityProvider is the path to the Identity Provider including tenant and user population. Example: \"https://hostname/idp/workview/mobile/\""},
        new List<string> {"Core-Access-Token-Lifetime-Tooltip","CoreAccessTokenLifetime is the property that is used for configuring the default length (in seconds) that a ReAuth token is good for when accessed through resonsive-apps."},
        new List<string> {"File-IO-Detail-Tooltip",""},
        new List<string> {"Foreign-Storage-EMC-Threshold-Tooltip","Setting for Centera inline blobs in KB.  Default is 75."},
        new List<string> {"Foreign-Storage-PM-Cache-Location-Tooltip","Path to cache location."},
        new List<string> {"Foreign-Storage-PM-Cache-Timeout-Tooltip","Timeout in minutes.  Default is 60 minutes."},
        new List<string> {"Foreign-Storage-PM-Cache-Size-Tooltip","Cache size in MB.  Default is 500."},
        new List<string> {"PM-File-Access-Level-Tooltip","0 or empty for Default, 1 to Always use UNC, 2 to Never to UNC."},
        new List<string> {"Temp-File-Expiration-Threshold-Time-Tooltip","The minimum amount of time a temporary file should exist without being accessed before it expires. Default is 00:05:00 (five minutes)."},
        new List<string> {"Hyland-Services-AppPool-Minimum-Sessions-Tooltip","This parameter dictates the minimum number of OnBase sessions available in the session pool. (default 0)"},
        new List<string> {"Hyland-Services-AppPool-Maximum-Sessions-Tooltip","This parameter dictates the maximum number of OnBase sessions available in the session pool.  Requests from the pool that exceed this value will block until another session is placed back into the pool. (default 10)"},
        new List<string> {"Hyland-Services-AppPool-Username-Tooltip",""},
        new List<string> {"Hyland-Services-AppPool-Password-Tooltip",""},
        new List<string> {"Use-Query-Context-Tooltip","This parameter indicates if query context security will be used during the course of retrieval. Query context means that a document must be retrieved through a document query before the document itself is accessible via another call. If this parameter is omitted, the default is true. Note: this value should be set to false when being used for disconnected web services. (default false)"},
        new List<string> {"Filter-Exceptions-Tooltip","This parameter indicates if the application server should not send detailed information about exception. For example, the exact stack trace of the exception will be filtered. This reduces the amount of information revealed to a malicious attacker when the server is attacked. The information is still available via Diagnostics Console and Diagnostics Server for an authorized user. (default true)"},
        new List<string> {"Endpoint-Use-Remoting-Tooltip",""},
        new List<string> {"Session-Enable-Timeout-Tooltip","Controls the timeout behavior for unused sessions. If enableTimeout is set to true the AppServer will timeout unused sessions and disconnect them. The timeout period is based on the ASP.NET session timeout found in the system.web\\session section with a minimum of 10 minutes. (default false)"},
        new List<string> {"Application-Server-Callback-URL-Tooltip",""},
        new List<string> {"Web-Server-Base-URL-Tooltip",""},
        new List<string> {"Request-Validation-Minimum-Version-Tooltip",""},
        new List<string> {"Login-ID-Tooltip",""},
        new List<string> {"Login-Password-Tooltip",""},
        new List<string> {"Login-Datasource-Tooltip",""},
        new List<string> {"Pool-Min-Tooltip",""},
        new List<string> {"Pool-Max-Tooltip",""},
        new List<string> {"Search-Timeout-Tooltip","The length of time (in seconds) before the search will timeout."},
        new List<string> {"Enable-Search-Log-Tooltip","Enables Full Text search logs in the specified path(<SearchLog enableSearchlog=\"true\" path=\"<HostName>/SearchLogs\"/>). Path should have full access rights for 'Everyone'."},
        new List<string> {"Search-Log-Path-Tooltip",""},
        new List<string> {"Unity-Editable-Filter-Max-Rows-Tooltip","Sets Max results for Unity client editable embedded filters (Default: 250, Max: 2000)."},
        new List<string> {"ERP-Date-Format-LOB-Broker-Tooltip","Sets the ERP date format for processing results for LOB Broker classes."},
        new List<string> {"Formatted-Text-Iframe-Supported-Domains-Tooltip","Adds additional domains that should be supported by iframes in the formatted text attribute control. Adding a domain to this list will add `allow-scripts`, `allow-same-origin`, and `allow-forms` overrides to the sandbox attribute on the iframe. Add domains as a comma separated list.<br><br>Examples:<br>&nbsp;&nbsp;&nbsp;&nbsp;*.mydomain.com<br>&nbsp;&nbsp;&nbsp;&nbsp;sub.myotherdomain.com<br><br>In this example *.mydomain.com will enable all sub-domains for mydomain.com (Ex: www.mydomain.com and test.mydomain.com would be valid), sub.myotherdomain.com would only allow sandbox overrides for that specific domain and sub-domain."},
        new List<string> {"Remote-OCR-Engine-Remote-Server-Tooltip",""},
        new List<string> {"Remote-OCR-Engine-Port-Tooltip",""},
        new List<string> {"Remote-OCR-Engine-Timeout-Tooltip",""},
        new List<string> {"Use-Office-Online-Server-Tooltip","Set to true to use the WOPI viewer. Set to false to continue using the legacy viewer."},
        new List<string> {"Office-Online-Server-URI-Tooltip","Points to the Office Online Server."},
        new List<string> {"Office-Online-Server-Proxy-Base-Tooltip","Points to the WOPI Service. Example: \"https://localhost/AppServer/private\""},
        new List<string> {"Vendor-Cache-Search-Minimum-Characters-Tooltip",""},
        new List<string> {"Vendor-Master-Keyed-Lookup-Op-Tooltip",""},
        new List<string> {"Vendor-Master-Lookup-Sequence-Tooltip",""},
        new List<string> {"Vendor-Master-Lookup-Return-Multiple-Tooltip",""},
        new List<string> {"Vendor-Cache-AutoComplete-Result-Max-Tooltip",""},
        new List<string> {"Enable-LOB-Broker-Accounts-Payable-Tooltip",""},
        new List<string> {"Http-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"Http-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Session-Timeout-Length-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"Image-Compression-Tooltip",""},
        new List<string> {"Content-Composer-Client-ID-Tooltip","Client ID provided by the Hyland Identity Provider (IdP)."},
        new List<string> {"Content-Composer-Client-Secret-Tooltip","Client secret provided by the Hyland Identity Provider (IdP)."},
        new List<string> {"Content-Composer-Username-Tooltip","Hyland IdP user with Content Composer access."},
        new List<string> {"Content-Composer-Password-Tooltip","Password for Hyland IdP user with Content Composer access."},
        new List<string> {"Encrypt-Content-Composer-Settings-Tooltip","Checking this will encrypt the Content Composer section in configuration."},
        new List<string> {"Pop-Integrations-Validate-Against-Checksum-Tooltip","Validate a Pop URL with the checksum value."},
        new List<string> {"Pop-Integrations-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"Pop-Integrations-Enable-Legacy-Checksum-Creation-Tooltip","Creates checksums using the legacy checksum validation."},
        new List<string> {"Pop-Integrations-Encrypt-Configuration-Tooltip","Encrypt configuration information for improved security."},
        new List<string> {"Integrations-Media-URL-Tooltip","URL to the OnBase Cloud"},
        new List<string> {"Integrations-Media-Datasource-Tooltip","Customer Datasource"},
        new List<string> {"Integrations-Media-Username-Tooltip","Customer username to OnBase Cloud"},
        new List<string> {"Integrations-Media-Password-Tooltip","Customer password to OnBase Cloud"},
        new List<string> {"Integrations-Media-Encrypt-OnBase-Cloud-Settings-Tooltip","When checked, url, datasource, username and password will be encrypted."},
        new List<string> {"EAC-Username-Tooltip","The OnBase User (usually a service account) that the Application Server uses to process EAC logon requests."},
        new List<string> {"EAC-Password-Tooltip","The password to the account handling EAC logons."},
        new List<string> {"EAC-UserLevel-Minimum-Pool-Size-Tooltip","The minimum number of OnBase user sessions maintained for this pool while the EAC Application Server is running."},
        new List<string> {"EAC-UserLevel-Maximum-Pool-Size-Tooltip","The maximum number of OnBase user sessions maintained for this pool while the EAC Application Server is running.  If the number of concurrent users accessing this pool is greater than this number, user requests will be queued."},
        new List<string> {"Encrypt-EAC-Tooltip","Encrypt EAC configuration settings for enhanced security."},
        new List<string> {"Authentication-Mode-Tooltip","This section sets the authentication policies of the application. Possible modes are \"Windows\" and \"None\".<br><br>\"None\" - No authentication is performed.<br>\"Windows\" - IIS performs authentication (Basic, Digest, or Integrated Windows) according to its settings for the application. Anonymous access must be disabled in IIS."},
        new List<string> {"ADFS-Enabled-Tooltip","This checkbox indicates whether the ADFS node is set to enabled."},
        new List<string> {"Request-Validation-Mode-Tooltip","The Request Validation Mode must be set to 2.0 for ADFS."},
        new List<string> {"Synchronize-User-Attributes-Tooltip",""},
        new List<string> {"Authentication-Only-Tooltip",""},
        new List<string> {"Cookie-Handler-Require-SSL-Tooltip","Configures the CookieHandler that the SessionAuthenticationModule (SAM) uses to read and write cookies."},
        new List<string> {"Audience-URI-Tooltip","Audience URI. As configured on the Endpoints tab of the Relying Party Trust. Requires trailing slash."},
        new List<string> {"Trusted-Issuer-Thumbprint-Tooltip","The issuer of the certificate used to validate the signature on responses from ADFS."},
        new List<string> {"Trusted-Issuer-Name-Tooltip",""},
        new List<string> {"wsFederation-Issuer-Tooltip","The URI of the token issuer. Also referred to as security token service (STS)."},
        new List<string> {"wsFederation-Realm-Tooltip","The URI of the requesting realm (Relying Party), which identifies the relying party (RP) to the security token service (STS)."},
        new List<string> {"Certificate-X509-Find-Type-Tooltip","Specifies the type of X.509 search to be executed."},
        new List<string> {"Certificate-Find-Value-Tooltip","Specifies the value to search for in the X.509 certificate store."},
        new List<string> {"Certificate-Store-Location-Tooltip","A StoreLocation value that specifies the location of the X.509 certificate store. The default value is \"LocalMachine\"."},
        new List<string> {"Certificate-Store-Name-Tooltip","The name of the X.509 certificate store. The default is \"My\"."},
        new List<string> {"Hyland-Idp-Url-Tooltip",""},
        new List<string> {"Hyland-IdP-Audience-URL-Tooltip",""},
        new List<string> {"Hyland-IdP-Name-Claim-Type-Tooltip",""},
        new List<string> {"Hyland-IdP-Api-Name-Tooltip",""},
        new List<string> {"Hyland-IdP-Api-Secret-Tooltip",""},
        new List<string> {"Alias-Old-Name-Tooltip",""},
        new List<string> {"Alias-New-Name-Tooltip",""},
        new List<string> {"Alias-Type-Tooltip",""},
        new List<string> {"SessionAdministration-User-Tooltip",""},
        new List<string> {"SessionAdministration-Role-Tooltip",""},
        new List<string> {"Trust-Mode-Tooltip",""},
        new List<string> {"Store-Location-Tooltip",""},
        new List<string> {"Store-Name-Tooltip",""},
        new List<string> {"Find-Type-Tooltip",""},
        new List<string> {"Find-Value-Tooltip",""},
        new List<string> {"Description-Tooltip",""},
        new List<string> {"App-Name-Tooltip",""},
        new List<string> {"App-Icon-URL-Tooltip",""},
        new List<string> {"App-URL-Tooltip",""}
    };

    private readonly List<List<string>> ElectronicPlanReview211Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stylesheet-Directory-Location-Tooltip","The directory containing files that add a specific look and feel to the site. Default location is BasicBlue."},
        new List<string> {"Allow-Sign-On-Tooltip","Allows users to sign on for access to create plan projects."},
        new List<string> {"Allow-Sign-Off-Tooltip","Allows users to sign off."},
        new List<string> {"Default-User-Time-Zone-Tooltip","Provides a way to set the initial time zone."},
        new List<string> {"Search-Start-Year-Tooltip","For Users searching plan project history, the Yearly search option list limits the list with this item."},
        new List<string> {"Items-Per-Page-Tooltip","The number of items to display on a project list or paged list of documents."},
        new List<string> {"Max-Lookup-Results-Tooltip",""},
        new List<string> {"Reset-Password-Link-Lifetime-Tooltip","Controls how long a reset link remains active, before it will not be allowed to reset a password. This is specified in minutes."},
        new List<string> {"File-Upload-Directory-Tooltip","The directory that stages plan documents while they are received from the client before forwarding them onto app server."},
        new List<string> {"File-Upload-Validator-Tooltip","File Upload Validator Format: Assembly Path,Class Name,Method Name."},
        new List<string> {"Token-Authentication-Tooltip",""},
        new List<string> {"Allow-Single-Sign-On-Tooltip","Enables the use of SSO.  This enables a user to login to a single system and automatically login to the plan review site."},
        new List<string> {"Source-ID-Tooltip","Source ID"},
        new List<string> {"Resolution-Mode-Tooltip","Resolution Mode"},
        new List<string> {"Public-CAPTCHA-Key-Tooltip","Public CAPTCHA API key provided by 3rd party CAPTCHA service."},
        new List<string> {"Private-CAPTCHA-Key-Tooltip","Private CAPTCHA API key provided by 3rd party CAPTCHA service."},
        new List<string> {"Password-Strength-Pattern-Tooltip","The password strength regular expression determines the minimum character length and characters/symbols that a password must contain in order to be a valid password."},
        new List<string> {"Password-Strength-Message-Tooltip","An optional password strength message that is displayed when the password requested during registration does not meet the required strength."},
        new List<string> {"Username-Validation-Pattern-Tooltip",""},
        new List<string> {"Discipline-Items-Per-Menu-Tooltip","Number of discipline items displayed in menu in the Plan review web client."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"EPR-Username-Tooltip","The OnBase user that Application Server uses to process Plan Review requests."},
        new List<string> {"EPR-Password-Tooltip","The OnBase user password that Application Server uses to process Plan Review requests."},
        new List<string> {"Data-Source-Tooltip","The OnBase Data Source that Application Server uses to process Plan Review Requests."},
        new List<string> {"Encrypt-Electronic-Plan-Review-Tooltip", "Determines whether or not the user name and password will be encrypted in the web.config file."}
    };

    private readonly List<List<string>> GatewayCachingServer211Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Allow-NT-Authentication-On-Forwarding-Tooltip","If enabled, allows the web server to forward NT credentials to the Application Server. Only turn this flag on when using NT authentication."},
        new List<string> {"Optimized-Service-Pipeline-Tooltip",""},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Gateway-Name-Tooltip","Name of the Gateway Caching Server configured in Gateway Caching Server Configuration."},
        new List<string> {"DataSource-Tooltip","The OnBase database this ASG is connecting to on the Application Server."},
        new List<string> {"Cache-Path-Tooltip","This is the local disk path for the ASG cache. This should not be a UNC path."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"GWCS-Username-Tooltip","Service Account that connects ASG to the Application Server. This user retrieves the documents that cache automatically."},
        new List<string> {"GWCS-Password-Tooltip","Password for the Service Account."},
        new List<string> {"Encrypt-Login-Settings-Tooltip", "Encrypt ASG settings for enhanced security." }
    };

    private readonly List<List<string>> HealthcareFormManager211Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"Allowed-Domain-Tooltip",""},
        new List<string> {"Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Allow-View-Source-Tooltip","Enables/disables view source."},
        new List<string> {"Enable-Session-Expiration-Tooltip","The end user will be logged out when no activity is detected."},
        new List<string> {"Prompt-On-Session-Expire-Tooltip","Prompts the user with a warning 30 seconds before the session expires."},
        new List<string> {"Web-Theme-Tooltip",""},
        new List<string> {"Default-Username-Tooltip","Default User Name."},
        new List<string> {"Default-Password-Tooltip","Default Password."},
        new List<string> {"Default-Login-Tooltip","Uses the web.config user name and password for Healthcare FormPop login."},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using the default user name and password."},
        new List<string> {"Force-OnBase-Authentication-Tooltip","Ignores database domain authentication settings and uses OnBase authentication instead."},
        new List<string> {"Web-Client-Type-Tooltip","Determines which type of Web Client to use.<br>activex - This will enable the ActiveX web client.<br>html - This will enable the HTML Only web client.<br>selectable - This will provide users an option upon login to select which client type (ActiveX or HTML Only) to use."},
        new List<string> {"Row-Coloring-Tooltip","Set to true to give every other row a shaded background in the document select list. Set to false to turn off row coloring."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"Prevent-Viewer-Client-Caching-Tooltip","Enable Prevent Viewer Client Caching to direct the HTML Web Client Viewer to not cache page data on the client for a brief period of time. Preventing caching will negatively impact performance. Recommended setting is false."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"Allow-NT-Authentication-On-Forwarding-Tooltip","If enabled, allows the web server to forward NT credentials to the Application Server. Only turn this flag on when using NT authentication."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Session-Timeout-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Samesite-Cookie-Policy-Tooltip","The Web Server can use a strict, lax, or none policy for samesite cookies."},
        new List<string> {"Validate-Against-Checksum-Tooltip","Validate a Pop URL with the checksum value."},
        new List<string> {"Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"Enable-Legacy-Checksum-Fallback-Tooltip","Attempts to use the legacy checksum validation if the most recent validation fails to validate."},
        new List<string> {"Encrypt-Healthcare-Pop-Integration-Configuration-Tooltip","Encrypt configuration information for improved security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"}
    };

    private readonly List<List<string>> PatientWindow211Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Allow-View-Source-Tooltip","Enables/disables view source."},
        new List<string> {"Enable-Session-Expiration-Tooltip","The end user will be logged out when no activity is detected."},
        new List<string> {"Prompt-On-Session-Expire-Tooltip","Prompts the user with a warning 30 seconds before the session expires."},
        new List<string> {"Web-Theme-Tooltip",""},
        new List<string> {"Default-Username-Tooltip","Default User Name"},
        new List<string> {"Default-Password-Tooltip","Default Password"},
        new List<string> {"Enable-Default-Login-Tooltip",""},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using the default user name and password."},
        new List<string> {"Force-OnBase-Authentication-Tooltip","Ignores database domain authentication settings and uses OnBase authentication instead."},
        new List<string> {"Enable-Split-View-Tooltip",""},
        new List<string> {"Enable-Patient-Search-Tooltip",""},
        new List<string> {"Enable-Patient-Context-Syncing-Tooltip",""},
        new List<string> {"Enable-Timestamp-Tooltip",""},
        new List<string> {"Timestamp-Time-Limit-Tooltip",""},
        new List<string> {"Enable-Workstation-Name-DNS-Lookup-Tooltip",""},
        new List<string> {"Row-Coloring-Tooltip","Set to true to give every other row a shaded background in the document select list. Set to false to turn off row coloring."},
        new List<string> {"Allow-Caching-Tooltip","Specifies whether caching should be enabled."},
        new List<string> {"Maximum-Width-Tooltip","Maximum width, in pixels."},
        new List<string> {"Maximum-Height-Tooltip","Maximum height, in pixels."},
        new List<string> {"Preview-Maximum-Width-Tooltip","Maximum width for the preview, in pixels."},
        new List<string> {"Preview-Maximum-Height-Tooltip","Maximum height for the preview, in pixels."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"Prevent-Viewer-Client-Caching-Tooltip","Enable Prevent Viewer Client Caching to direct the HTML Web Client Viewer to not cache page data on the client for a brief period of time. Preventing caching will negatively impact performance. Recommended setting is false."},
        new List<string> {"HTML-Only-Documents-Print-As-PDFs-Tooltip",""},
        new List<string> {"System-List-Display-Label-Tooltip",""},
        new List<string> {"Personal-List-Display-Label-Tooltip",""},
        new List<string> {"Selected-Tab-Single-Color-Tooltip",""},
        new List<string> {"Enable-EForm-Standard-Printing-Tooltip",""},
        new List<string> {"Federated-Search-With-MPI-Tooltip",""},
        new List<string> {"Hide-Toolbar-Print-Button-Tooltip",""},
        new List<string> {"Auto-Display-Note-Panel-PDF-Office-Tooltip",""},
        new List<string> {"Emergency-Access-Dialog-Title-Tooltip",""},
        new List<string> {"Emergency-Access-Dialog-Message-Tooltip",""},
        new List<string> {"Emergency-Access-Dialog-Other-Reason-Label-Tooltip",""},
        new List<string> {"Show-Emergency-Access-Show-Documents-Checkboxes-Tooltip",""},
        new List<string> {"Show-Other-Reason-In-Emergency-Access-Dialog-Tooltip",""},
        new List<string> {"Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog-Tooltip",""},
        new List<string> {"ADFS-Enabled-Tooltip",""},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Session-Timeout-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Samesite-Cookie-Policy-Tooltip","The Web Server can use a strict, lax, or none policy for samesite cookies."},
        new List<string> {"Validate-Against-Checksum-Tooltip","Validate a Pop URL with the checksum value."},
        new List<string> {"Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"Enable-Legacy-Checksum-Fallback-Tooltip","Attempts to use the legacy checksum validation if the most recent validation fails to validate."},
        new List<string> {"Encrypt-Healthcare-Pop-Integration-Configuration-Tooltip","Encrypt configuration information for improved security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"}
    };

    private readonly List<List<string>> PublicAccessLegacy211Tooltips = new List<List<string>>
    {
        new List<string> {"Encrypt-Doc-ID-Tooltip","Set to true to encrypt the document ID when displaying search results."},
        new List<string> {"Encrypt-Folder-ID-Tooltip","Encrypt Folder ID"},
        new List<string> {"Checksum-Key-Tooltip","The checksum key to use when document ID encryption is enabled."},
        new List<string> {"Use-Display-Columns-Tooltip","Set to true to use the configured Custom Query display columns when displaying search results."},
        new List<string> {"Query-Limit-Tooltip","Search results will be limited to this number. Set to 0 for unlimited queries."},
        new List<string> {"Chunk-Size-Tooltip","Chunk size (in bytes) to use when downloading documents."},
        new List<string> {"Viewer-Mode-Tooltip","Set to PDF to convert documents to PDF format and stream to the viewer. Set to Native to download files in their native format. Set to Native Optional to stream files as PDF and provide a link in the viewer to download the file in its native format."},
        new List<string> {"Cache-Path-Tooltip","Cache path"},
        new List<string> {"Expiration-Time-Tooltip","Expiration time (in days)"},
        new List<string> {"Max-Cache-Size-Tooltip","Maximum cache size on disk (GB)"},
        new List<string> {"Size-to-Cache-Tooltip","Documents with a file size equal to or greater than Size to Cache (MB) should be cached."},
        new List<string> {"Size-to-Prompt-Tooltip","Documents with a file size equal to or greater than Size to Prompt (MB) will display the browser's open/save dialog."},
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"SOAP-Client-Request-Timeout-Tooltip","Timeout (in seconds) for service requests when using the SOAP client. The HttpRuntime Execution Timeout on the Application Server must be greater than or equal to this value."},
        new List<string> {"Allow-NT-Authentication-On-Forwarding-Tooltip","If enabled, allows the web server to forward NT credentials to the Application Server. Only turn this flag on when using NT authentication."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"PAVL-Username-Tooltip","Default User Name"},
        new List<string> {"PAVL-Password-Tooltip","Default Password"},
        new List<string> {"Data-Source-Tooltip","Default Data Source"},
        new List<string> {"Encrypt-Public-Access-Configuration-Tooltip", "Encrypt Public Access keys for enhanced security." },
        new List<string> {"Query-ID-Tooltip","The ID Number of the query as noted inside of the Configuration Client. A Query ID of * indicates that the keyword is required by all queries."},
        new List<string> {"Keyword-ID-Tooltip","The Keyword ID Number of the keyword as noted inside of the Configuration Client."}
    };

    private readonly List<List<string>> PublicAccessNextGen211Tooltips = new List<List<string>>
    {
        new List<string> {"Encrypt-Doc-ID-Tooltip","Set to true to encrypt the document ID when displaying search results."},
        new List<string> {"Use-Display-Columns-Tooltip","Set to true to use the configured Custom Query display columns when displaying search results."},
        new List<string> {"Query-Limit-Tooltip","Search results will be limited to this number. Set to 0 for unlimited queries."},
        new List<string> {"Chunk-Size-Tooltip","Chunk size (in bytes) to use when downloading documents."},
        new List<string> {"Viewer-Mode-Tooltip","Set to PDF to convert documents to PDF format and stream to the viewer. Set to Native to download files in their native format. Set to Native Optional to stream files as PDF and provide a link in the viewer to download the file in its native format."},
        new List<string> {"Default-Overlay-Mode-Tooltip","The default overlay mode to render documents in, if applicable. Possible values are Print, View, and Off. Defaults to Print, was used by the past versions of Public Access."},
        new List<string> {"Cache-Path-Tooltip","Cache path"},
        new List<string> {"Expiration-Time-Tooltip","Expiration time (in days)"},
        new List<string> {"Max-Cache-Size-Tooltip","Maximum cache size on disk (GB)."},
        new List<string> {"Size-to-Cache-Tooltip","Documents with a file size equal to or greater than Size to Cache (MB) should be cached."},
        new List<string> {"Size-to-Prompt-Tooltip","Documents with a file size equal to or greater than Size to Prompt (MB) will display the browser's open/save dialog."},
        new List<string> {"Interval-Between-Throttle-Cache-Resets-Tooltip","The amount of time, in minutes, between each iteration of clearing the throttle cache. If a user is blocked from making requests, they will have to wait until this timer expires to make any more requests, or their requests will be denied. Users will only be blocked if they exceed the threshold, and if throttling is enabled. A value of 0 or less disables this behavior."},
        new List<string> {"Amount-of-Requests-During-Each-Throttle-Interval-Tooltip","The amount of requests that can be received before the host from which these requests originate is blocked for an amount of time specified in the throttle reset interval. This is to reduce the potential attack vector of a denial of service attack."},
        new List<string> {"Enable-Local-Browser-Caching-Tooltip","Whether or not to allow browsers to privately and locally cache documents returned from the public access toolkit for a short period of time in order to reduce the amount of repeated requests."},
        new List<string> {"Decorate-Document-Names-Tooltip","Whether or not to show decoration/formatting for document names (i.e. <yellow>). Only works on autonames. Decoration will always be applied to display columns, regardless of this setting."},
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"SOAP-Client-Request-Timeout-Tooltip","Timeout (in seconds) for service requests when using the SOAP client. The HttpRuntime Execution Timeout on the Application Server must be greater than or equal to this value."},
        new List<string> {"Allow-NT-Authentication-On-Forwarding-Tooltip","If enabled, allows the web server to forward NT credentials to the Application Server. Only turn this flag on when using NT authentication."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"PAVNG-Username-Tooltip","Default User Name"},
        new List<string> {"PAVNG-Password-Tooltip","Default Password"},
        new List<string> {"Data-Source-Tooltip","Default Data Source"},
        new List<string> {"Encrypt-Public-Access-Configuration-Tooltip", "Encrypt Public Access keys for enhanced security."},
        new List<string> {"Query-ID-Tooltip","The ID Number of the query as noted inside of the Configuration Client. A Query ID of * indicates that the keyword is required by all queries."},
        new List<string> {"Keyword-ID-Tooltip","The Keyword ID Number of the keyword as noted inside of the Configuration Client."}
    };

    private readonly List<List<string>> ReportingViewer211Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Allow-NT-Authentication-On-Forwarding-Tooltip","If enabled, allows the web server to forward NT credentials to the Application Server. Only turn this flag on when using NT authentication."},
        new List<string> {"Optimized-Service-Pipeline-Tooltip","Use the optimized service pipeline for more efficient communication of results."},
        new List<string> {"Request-Timeout-Tooltip","Determines how long the service client should wait for a response from the application server."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"Web-Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Core-Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Server-Designation-Tooltip","(Optional) Enter a value to designate which server the user is connecting to, which will display in the window title. This is helpful in a load balanced environment."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"JSON-Serialization-Max-Length-Tooltip",""},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"OB-Username-Tooltip","This user name along with the associated password will be used to automatically log the user into the Dashboard Web Viewer."},
        new List<string> {"OB-Password-Tooltip","This password along with the associated user name will be used to automatically log the user into the Dashboard Web Viewer."},
        new List<string> {"Dashboard-Theme-Tooltip","Determines the theme that the dashboard uses when it is rendered."},
        new List<string> {"Export-Dashboard-Tooltip","Allows users to export the dashboard as an image or a PDF."},
        new List<string> {"Export-Dashboard-Items-Tooltip","Allows users to export each dashboard item as an image or a PDF."},
        new List<string> {"Allow-HTTP-Parameters-Tooltip","Allows the dashboard viewer to accept dashboard parameters from the HTTP request query string."},
        new List<string> {"Dashboard-Tracing-Info-Level-Tooltip",""},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using NT Authorization or SSO."},
        new List<string> {"Report-Paging-Limit-Tooltip","This option controls the number of records that will be shown per page for a given report.  The minimum value is 50."},
        new List<string> {"Encrypt-Dashboard-Viewer-Settings-Tooltip","Encrypt Dashboard Viewer keys for enhanced security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"}
    };

    private readonly List<List<string>> WebServer211Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Allow-NT-Authentication-On-Forwarding-Tooltip","If enabled, allows the web server to forward NT credentials to the Application Server. Only turn this flag on when using NT authentication."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Core-Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Web-Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Server-Designation-Tooltip","(Optional) Enter a value to designate which server the user is connecting to, which will display in the window title. This is helpful in a load balanced environment."},
        new List<string> {"Default-Domain-Name-Tooltip","Default domain name displayed/entered on the login page."},
        new List<string> {"Default-Username-Tooltip","Default User Name"},
        new List<string> {"Default-Password-Tooltip","Default Password"},
        new List<string> {"Default-Institution-Tooltip","Default Institution"},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using the default user name and password."},
        new List<string> {"Force-OnBase-Authentication-Tooltip","Ignores database domain authentication settings and uses OnBase authentication instead."},
        new List<string> {"Custom-SSO-Authentication-Page-Failure-Tooltip","URL of a specific page that the user is redirected to if login fails while using Single Sign On."},
        new List<string> {"Close-On-Logout-Tooltip","If set to true, the window is automatically closed when the user logs out. Otherwise, the user is returned to the login screen."},
        new List<string> {"Logout-Redirect-URL-Tooltip","Redirects the user to a specific page upon logout."},
        new List<string> {"Web-Theme-Tooltip",""},
        new List<string> {"Target-Page-Tooltip",""},
        new List<string> {"Login-Page-Tooltip",""},
        new List<string> {"SharePoint-Viewer-Show-Workflow-Tooltip","Turn on/off the Workflow header bar in SharePoint."},
        new List<string> {"SharePoint-Online-Tooltip","Toggling SharePoint Online changes the authentication scheme used. If set to true, it uses OAuth. If set to false, it uses the provided certificate."},
        new List<string> {"Default-Print-Range-Tooltip","The default print range when printing from the viewer: all, currentPage, #, or #-#. Please refer to the admin manual for further description of the options."},
        new List<string> {"Prompt-User-Queries-Tooltip","Checks to see if constraints have been applied to custom queries."},
        new List<string> {"Show-Queue-Counts-Tooltip","Enables/disables queue counts in workflow (may hinder system performance if set to true)."},
        new List<string> {"Reselect-Delta-Tooltip","This key controls how many places before and after the previous index to search for the document to re-select after performing an ad-hoc task."},
        new List<string> {"Text-Search-Auto-View-Tooltip","Enables/disables text search auto view."},
        new List<string> {"Max-Results-Tooltip","The maximum number of documents displayed in a results list."},
        new List<string> {"Workflow-Max-Results-Tooltip","The maximum number of items displayed in the Workflow Inbox."},
        new List<string> {"Keyword-Panel-View-Type-Tooltip","This key controls how KeywordType names and Keyword operators are displayed. Please refer to the admin manual for detailed descriptions."},
        new List<string> {"Enable-Keyword-Operators-Tooltip","Enables or disables the use of keyword operators in the keyword panel."},
        new List<string> {"Enable-Session-Expiration-Tooltip","The end user will be logged out when no activity is detected."},
        new List<string> {"Prompt-On-Session-Expire-Tooltip","Prompts the user with a warning 30 seconds before the session expires."},
        new List<string> {"Display-Single-Document-Tooltip","Automatically opens a document if only one document is returned in the hitlist."},
        new List<string> {"EDM-Briefcase-Tooltip","Enables/disables the EDM briefcase. Ensure all users who will be checking out documents have the EDM briefcase installed on their workstation."},
        new List<string> {"Display-Related-Documents-Tooltip","Determines when to display the Work Folder tab: always, never, or document. If set to document, the tab will only display when a selected document in a queue has at least one related document."},
        new List<string> {"Workflow-Height-px-Tooltip","The height, in pixels, of the Workflow user interaction area. This value must be greater than 150."},
        new List<string> {"Show-Combined-Inbox-Tooltip","Specifies whether or not the combined inbox should be displayed."},
        new List<string> {"Override-UI-Language-Tooltip","The language select option appears on the login page instead of using the default language for your locale."},
        new List<string> {"Default-UI-Local-Tooltip","When Override UI Language is set to true, this key sets the behavior of the UI. To have a specific language be the default, regardless of locale setting, set this value to the locale."},
        new List<string> {"Native-Mail-System-Tooltip","Set to 11 to enable sending external mail through Lotus Notes."},
        new List<string> {"Use-Web-Mail-Tooltip","Use Web Mail"},
        new List<string> {"Enable-Virtual-Print-Driver-Tooltip","Enables support for importing documents using the Virtual Print Driver."},
        new List<string> {"Auto-Display-Note-Panel-PDF-Office-Tooltip","Automatically display the note panel when viewing PDF and Office documents."},
        new List<string> {"Clear-Document-Type-After-Import-Tooltip","Clear Document Type After Import."},
        new List<string> {"Clear-Keywords-After-Import-Tooltip","Clear Keywords After Import."},
        new List<string> {"Always-Generate-Preview-Tooltip","Always generate preview of an uploaded document."},
        new List<string> {"Web-Client-Type-Tooltip","Determines which type of Web Client to use. Selectable will allow users to select the client type upon login. Please refer to the admin manual for information regarding features that may not be enabled in HTML Only mode."},
        new List<string> {"Remember-Hitlist-Height-Tooltip","The Web Client remembers the size of the document search results list, even after Internet Explorer has been closed."},
        new List<string> {"Number-of-Docuemnt-Types-to-Display-Tooltip","The number of document types to display in the select list in Document Retrieval without the need to scroll."},
        new List<string> {"Collapse-Check-Select-Lists-Tooltip","When set to true, all Check Select List controls will begin in a collapsed state."},
        new List<string> {"Add-Note-Menu-Tooltip","Enables/disables the Notes | Add Note right-click option."},
        new List<string> {"Create-New-Document-Menu-Tooltip","Enables/disables the Send To | Create New Document right-click option."},
        new List<string> {"Document-Properties-Menu-Tooltip","Enables/disables the Document Properties right-click option."},
        new List<string> {"File-Menu-Tooltip","Enables/disables the Send To | File right-click option."},
        new List<string> {"History-Menu-Tooltip","Enables/disables the History right-click option."},
        new List<string> {"Keywords-Menu-Tooltip","Enables/disables the Keywords right-click option."},
        new List<string> {"Print-Menu-Tooltip","Enables/disables the Print right-click option."},
        new List<string> {"Reindex-Menu-Tooltip","Enables/disables the Re-Index right-click option."},
        new List<string> {"Workflow-Menu-Tooltip","Enables/disables the Workflow right-click option."},
        new List<string> {"Send-To-Print-Queue-Menu-Tooltip","Enables/disables the Send To | Server Print Queue right-click option."},
        new List<string> {"Clipboard-Menu-Tooltip","Enables/disables the Send To | Clipboard right-click option."},
        new List<string> {"First-Page-Menu-Tooltip","Enables/disables the Navigate | First Page right-click option."},
        new List<string> {"Goto-Page-Menu-Tooltip","Enables/disables the Navigate | Goto Page right-click option."},
        new List<string> {"Last-Page-Menu-Tooltip","Enables/disables the Navigate | Last Page right-click option."},
        new List<string> {"Mail-Recipient-Menu-Tooltip","Enables/disables the Send To | Mail Recipient right-click option."},
        new List<string> {"Next-Page-Menu-Tooltip","Enables/disables the Navigate | Next Page right-click option."},
        new List<string> {"Pages-Menu-Tooltip","Enables/disables the Toolbars | Pages right-click option."},
        new List<string> {"Previous-Page-Menu-Tooltip","Enables/disables the Navigate | Previous Page right-click option."},
        new List<string> {"Text-Search-Menu-Tooltip","Enables/disables the Toolbars | Text Search right-click option."},
        new List<string> {"Viewer-Control-Menu-Tooltip","Enables/disables the Toolbars | Viewer Control right-click option."},
        new List<string> {"Zoom-In-Menu-Tooltip","Enables/disables the Scale | Zoom In right-click option."},
        new List<string> {"Zoom-Out-Menu-Tooltip","Enables/disables the Scale | Zoom Out right-click option."},
        new List<string> {"Go-To-Page-Tooltip","Goto page position."},
        new List<string> {"Overlay-Tooltip","Set to true or false to turn the default overlay display on or off."},
        new List<string> {"Zoom-Level-Tooltip","Zoom level when opening a document."},
        new List<string> {"Left-Border-Tooltip","Pixel position for the left border when using zoomrect."},
        new List<string> {"Right-Border-Tooltip","Pixel position for the right border when using zoomrect."},
        new List<string> {"Top-Border-Tooltip","Pixel position for the top border when using zoomrect."},
        new List<string> {"Bottom-Border-Tooltip","Pixel position for the bottom border when using zoomrect."},
        new List<string> {"Annotation-Toolbar-Tooltip","Enables/disables the Annotation toolbar."},
        new List<string> {"Notes-Toolbar-Tooltip","Enables/disables the Notes toolbar."},
        new List<string> {"Thumbnail-Pages-Tooltip","Enables/disables the Pages toolbar."},
        new List<string> {"Viewer-Control-Toolbar-Tooltip","Enables/disables the Viewer Control toolbar."},
        new List<string> {"Disable-Context-Menu-Tooltip","Disables the context menu on the web client Viewer."},
        new List<string> {"Path-Form-Proc-Tooltip",""},
        new List<string> {"Path-Print-Tooltip",""},
        new List<string> {"Prevent-Viewer-Client-Caching-Tooltip","Enable Prevent Viewer Client Caching to direct the HTML Web Client Viewer to not cache page data on the client for a brief period of time. Preventing caching will negatively impact performance. Recommended setting is false."},
        new List<string> {"Auto-Orient-Printing-Tooltip","If a page is wider than it is tall, printing will default to landscape mode. If a page is taller than it is wide, printing will default to portrait mode."},
        new List<string> {"Autozoom-Thumbnail-Configuration-Tooltip","Set the autozoom thumbnail configuration to true or false to always/never autozoom. Set it to local to have the autozoom depend upon local settings."},
        new List<string> {"Enable-Retrieve-Transactions-Tooltip","Enables/disables retrieving transactions for the selected document."},
        new List<string> {"Sort-by-Document-ID-Tooltip","Sort by Document ID when using the Retrieve Transaction functionality."},
        new List<string> {"Admin-Security-Keywords-Tooltip","Globally toggles whether an admin can assign security keywords."},
        new List<string> {"Default-Workflow-Layout-Tooltip","Specifies the way in which the Workflow interface will display: horizontal, vertical, separateviewer, or selectable.  When set to selectable, users can choose the layout they prefer."},
        new List<string> {"Row-Coloring-Tooltip","Set to true to give every other row a shaded background in the document select list. Set to false to turn off row coloring."},
        new List<string> {"Folder-Tree-Width-Tooltip","The folder tree width, represented as a percentage. This value must end in %."},
        new List<string> {"Folder-Tree-Height-Tooltip","The folder tree height, represented as a percentage. This value must end in %."},
        new List<string> {"Document-List-Height-Tooltip","The document list height, represented as a percentage. This value must end in %."},
        new List<string> {"Folder-List-Height-Tooltip","The folder list height, represented as a percentage. This value must end in %."},
        new List<string> {"WorkView-Max-Results-Tooltip","The maximum number of objects displayed for unconstrained filter results."},
        new List<string> {"WorkView-Filter-Count-Tooltip","Displays object count for all filters."},
        new List<string> {"Display-Created-EForms-Tooltip","Select the 'View E-Form Before Creating' option by default when users create e-forms from within WorkView."},
        new List<string> {"Enable-Standalone-WorkView-Client-Tooltip",""},
        new List<string> {"WorkView-Client-URL-Tooltip",""},
        new List<string> {"Application-Enabler-Integration-Tooltip","Allows Application Enabler to work with the Web Client."},
        new List<string> {"Launch-Application-Enabler-Tooltip","Launches the Application Enabler client by default."},
        new List<string> {"Data-Mining-Tooltip","Enable Data Mining content menu"},
        new List<string> {"Data-Mining-Temp-Directory-Tooltip","Fully qualified path to the data mining temporary directory."},
        new List<string> {"Data-Mining-Report-Server-Name-Tooltip","Enter the server name (host name) for where the Data Mining Reports reside."},
        new List<string> {"Data-Mining-URL-Tooltip","Location of Rms.aspx."},
        new List<string> {"Additional-Models-Tooltip","Enter a semicolon-delimited list of fully qualified pathnames to external model files. Do not use any spaces."},
        new List<string> {"Allow-View-Source-Tooltip","Enables/disables view source."},
        new List<string> {"Platter-Management-Cache-Location-Tooltip","Location on the Web Server where the cache files will be stored."},
        new List<string> {"Platter-Management-Cache-Timeout-Tooltip","The amount of time, in minutes, that files will exist in the cache."},
        new List<string> {"Platter-Management-Cache-Size-Tooltip","Cache size in MB."},
        new List<string> {"Open-Microsoft-Office-Documents-in-Separate-Window-Tooltip","Indicates if Microsoft Office documents (Word, Excel, PowerPoint etc.) should be opened in a separate window. This setting should be set to true when running Office 2000, XP, and 2003 with the Office Add-In."},
        new List<string> {"Open-Rich-Text-Format-Documents-With-Microsoft-Word-Tooltip","Enable this option to open Rich Text Format Documents with Microsoft Word."},
        new List<string> {"Allow-Caching-Tooltip","Specifies whether caching should be enabled."},
        new List<string> {"Show-Previews-Tooltip","Specifies whether or not previews of the thumbnails should be displayed."},
        new List<string> {"User-Configurable-Tooltip","Specifies whether or not the user is able to configure options for the Thumbnail Hit List Viewer."},
        new List<string> {"Number-of-Columns-Tooltip","The number of columns for the Hit List."},
        new List<string> {"Maximum-Width-Tooltip","Maximum width, in pixels."},
        new List<string> {"Maximum-Height-Tooltip","Maximum height, in pixels."},
        new List<string> {"Preview-Maxiumum-Width-Tooltip","Maximum width for the preview, in pixels."},
        new List<string> {"Preview-Maxiumum-Height-Tooltip","Maximum height for the preview, in pixels."},
        new List<string> {"Use-FolderPop-Viewer-Tooltip","Set to true to use FolderPop as the Document Viewer within ACC."},
        new List<string> {"Silverlight-Default-Username-Tooltip","Silverlight Default User Name"},
        new List<string> {"Silverlight-Default-Password-Tooltip","Silverlight Default Password"},
        new List<string> {"Prompt-with-Unread-DKT-Docs-Tooltip","When set to true, the user is prompted at login to review any unacknowledged documents in DKT."},
        new List<string> {"Internal-Mail-Timer-In-Seconds-Tooltip","This timer controls how often the Web Client checks for new Internal Mail messages if the \"Notify on New Mail\" user option is enabled. By default, it checks every 300 seconds (5 minutes). This is the minimum allowed value. Setting Internal Mail Timer to 0 will disable mail notifications for all users."},
        new List<string> {"Allowed-Function-Key-List-Tooltip","Comma separated list of function key shortcuts that should not be blocked or overridden by the Web Client."},
        new List<string> {"Max-JSON-Deserialized-Members-Tooltip","The maximum number of form keys, files, and JSON members that can be used in an HTTP request. This setting is used in StatusView when configuring Foldering and WorkView portlets."},
        new List<string> {"Validation-Settings-Unobtrusive-Validation-Mode-Tooltip",""},
        new List<string> {"OWIN-Automatic-App-Startup-Tooltip","Open Web Interface for .NET (OWIN) automatic app startup enables the Administrator System Message feature."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections"},
        new List<string> {"Enabled-Legacy-Checksum-Fallback-Tooltip","Attempts to use the legacy checksum validation if the most recent validation fails to validate."},
        new List<string> {"Enable-Login-Autocomplete-Tooltip","Enable to have all login forms set as autocomplete on. Default value is false to have autocomplete off."},
        new List<string> {"Windows-Server-Locale-Format-Tooltip","Which version of Windows Server locale formats to use for data validation. A blank value will let the web client detect what version of Windows Server is running."},
        new List<string> {"Maximum-Import-Queue-Size-Tooltip","The number of documents to allow users to queue for import at a time. This value may not exceed 25, and may not be lower than 1."},
        new List<string> {"Enable-Desktop-Host-Tooltip","Enables the Desktop Host connection for the Web Client."},
        new List<string> {"Enable-Browser-PDF-Viewer-Tooltip","Use PDF viewer provided by browser to view PDF documents, set to false will use onbase viewer. This setting will override user preferences setting. Leaving this value empty will allow users to choose which PDF viewer to use via user preferences"},
        new List<string> {"Multi-Form-Viewer-Origin-Tooltip","The origin from which the HMH Angular app which consumes MultiFormViewer is served."},
        new List<string> {"Use-Theme-Tooltip",""},
        new List<string> {"Enable-Export-Dashboard-Tooltip",""},
        new List<string> {"Enable-Export-Dashboard-Items-Tooltip",""},
        new List<string> {"Reporting-Page-Limit-Tooltip",""},
        //new List<string> {"Dashboard-Cache-Timeout-Tooltip",""},
        new List<string> {"Healthcare-Web-Viewer-Session-Timeout-Tooltip","Time (in minutes) before viewer will auto log out. (default: 30)"},
        new List<string> {"Healthcare-Web-Viewer-Data-Source-Tooltip","ODBC data source to use with the Healthcare Web Viewer. This value overrides value for key 'dmsDataSource' above."},
        new List<string> {"Healthcare-Web-Viewer-Enable-HTTP-Data-Source-Tooltip","Set to true to set the data source from the query string. This value overrides datasource and dmsDataSource. (default: false)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Deficiency-Viewing-Tooltip","Set to true to allow deficiency viewing. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Physician-Acknowledgement-Tooltip","Set to true to allow physician acknowledgment. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Document-Correction-Tooltip","Set to true to allow document corrections. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Read-Only-HTML-Forms-Tooltip","Allowed Values are \"all\", \"medical\", or \"none\". Set to All for all HTML Forms read only. Set to Medical for medical document type html forms read only. Set to none for no html forms read only. (default: all)"},
        new List<string> {"Healthcare-Web-Viewer-Read-Only-Unity-Forms-Tooltip","Allowed Values are \"all\", \"medical\", or \"none\". Set to All for all Unity Forms read only. Set to Medical for medical document type unity forms read only. Set to none for no unity forms read only. (default: all)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Tooltip","Set to true to allow the Epic Web Viewer COM integration to interop with Healthcare Web Viewer. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Interoperability-Enabled-Tooltip","Set to true to allow the Epic Hyperdrive client's Scan Viewer integration to interop with Healthcare Web Viewer. (default: false)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Failed-Timeout-Tooltip","Time (in seconds) to wait for the document to load before sending the DisplayDocument message to Epic. (default: 10)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Message-Interval-Tooltip","Time (in seconds) to wait for Epic to send a response upon sending the DisplayDocument message. (default: 1)"},
        new List<string> {"Session-Timeout-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Samesite-Cookie-Policy-Tooltip","The Web Server can use a strict, lax, or none policy for samesite cookies."},
        new List<string> {"Authentication-Mode-Tooltip",""},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-KB-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Seconds-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"Default-DocPop-Username-Tooltip","Default DocPop User Name"},
        new List<string> {"Default-DocPop-Password-Tooltip","Default DocPop Password"},
        new List<string> {"DocPop-Data-Source-Tooltip","ODBC data source to use with DocPop"},
        new List<string> {"Default-DocPop-Domain-Name-Tooltip","DocPop domain name (used with NT Authentication)"},
        new List<string> {"Default-DocPop-Institution-Tooltip","DocPop institution"},
        new List<string> {"Embedded-DocPop-Tooltip","Set to true when embedding DocPop in an Frame or IFrame."},
        new List<string> {"DocPop-Default-Login-Tooltip","Uses the web.config user name and password for DocPop login"},
        new List<string> {"DocPop-HTTP-Login-Tooltip","Get DocPop login credentials from the query string."},
        new List<string> {"DocPop-Auto-Login-Tooltip","Enables/disables DocPop auto login."},
        new List<string> {"DocPop-HTTP-Data-Source-Tooltip","Gets the DocPop data source from the query string."},
        new List<string> {"DocPop-Validate-Against-Checksum-Tooltip","Validate DocPop URLs against a checksum value."},
        new List<string> {"DocPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"DocPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"DocPop-Auto-Display-One-Document-Tooltip","If the search result contains a single document, only display the viewer and hide the select list."},
        new List<string> {"Disable-Context-Menus-in-DocPop-Tooltip","Set to true to disable context menus on Document Select and Viewer in DocPop."},
        new List<string> {"Encrypt-DocPop-Tooltip","Encrypt DocPop keys for enhanced security."},
        new List<string> {"Default-PdfPop-Username-Tooltip","Default PdfPop User Name"},
        new List<string> {"Default-PdfPop-Password-Tooltip","Default PdfPop Password"},
        new List<string> {"PdfPop-Data-Source-Tooltip","ODBC data source to use with PdfPop"},
        new List<string> {"Default-PdfPop-Domain-Name-Tooltip","PdfPop domain name (used with NT Authentication)"},
        new List<string> {"Default-PdfPop-Institution-Tooltip","PdfPop institution"},
        new List<string> {"Embedded-PdfPop-Tooltip","Set to true when embedding PdfPop in an Frame or IFrame."},
        new List<string> {"PdfPop-Default-Login-Tooltip","Uses the web.config user name and password for PdfPop login"},
        new List<string> {"PdfPop-HTTP-Login-Tooltip","Get PdfPop login credentials from the query string."},
        new List<string> {"PdfPop-Auto-Login-Tooltip","Enables/disables PdfPop auto login."},
        new List<string> {"PdfPop-HTTP-Data-Source-Tooltip","Gets the PdfPop data source from the query string."},
        new List<string> {"PdfPop-Validate-Against-Checksum-Tooltip","Validate PdfPop URLs against a checksum value."},
        new List<string> {"PdfPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"PdfPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"PdfPop-Auto-Display-One-Document-Tooltip","If the search result contains a single document, only display the viewer and hide the select list."},
        new List<string> {"Encrypt-PdfPop-Tooltip","Encrypt PdfPop keys for enhanced security."},
        new List<string> {"Default-FormPop-Username-Tooltip","Default FormPop User Name"},
        new List<string> {"Default-FormPop-Password-Tooltip","Default FormPop Password"},
        new List<string> {"FormPop-Data-Source-Tooltip","ODBC data source to use with FormPop"},
        new List<string> {"Default-FormPop-Domain-Name-Tooltip","FormPop domain name (used with NT Authentication)"},
        new List<string> {"Default-FormPop-Institution-Tooltip","FormPop institution"},
        new List<string> {"Embedded-FormPop-Tooltip","Set to true when embedding FormPop in an Frame or IFrame."},
        new List<string> {"FormPop-Default-Login-Tooltip","Uses the web.config user name and password for FormPop login"},
        new List<string> {"FormPop-HTTP-Login-Tooltip","Get FormPop login credentials from the query string."},
        new List<string> {"FormPop-Auto-Login-Tooltip","Enables/disables FormPop auto login."},
        new List<string> {"FormPop-HTTP-Data-Source-Tooltip","Gets the FormPop data source from the query string."},
        new List<string> {"FormPop-Validate-Against-Checksum-Tooltip","Validate FormPop URLs against a checksum value."},
        new List<string> {"FormPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"FormPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"FormPop-Auto-Display-One-Document-Tooltip","If the search result contains a single document, only display the viewer and hide the select list."},
        new List<string> {"Encrypt-FormPop-Tooltip","Encrypt FormPop keys for enhanced security."},
        new List<string> {"Default-FolderPop-Username-Tooltip","Default FolderPop User Name"},
        new List<string> {"Default-FolderPop-Password-Tooltip","Default FolderPop Password"},
        new List<string> {"FolderPop-Data-Source-Tooltip","ODBC data source to use with FolderPop"},
        new List<string> {"Default-FolderPop-Domain-Name-Tooltip","FolderPop domain name (used with NT Authentication)"},
        new List<string> {"Default-FolderPop-Institution-Tooltip","FolderPop institution"},
        new List<string> {"Embedded-FolderPop-Tooltip","Set to true when embedding FolderPop in an Frame or IFrame."},
        new List<string> {"FolderPop-Default-Login-Tooltip","Uses the web.config user name and password for FolderPop login"},
        new List<string> {"FolderPop-HTTP-Login-Tooltip","Get FolderPop login credentials from the query string."},
        new List<string> {"FolderPop-Auto-Login-Tooltip","Enables/disables FolderPop auto login."},
        new List<string> {"FolderPop-HTTP-Data-Source-Tooltip","Gets the FolderPop data source from the query string."},
        new List<string> {"FolderPop-Validate-Against-Checksum-Tooltip","Validate FolderPop URLs against a checksum value."},
        new List<string> {"FolderPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"FolderPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"Encrypt-FolderPop-Tooltip","Encrypt FolderPop keys for enhanced security."},
        new List<string> {"PacketPop-Data-Source-Tooltip","ODBC data source to use with PacketPop."},
        new List<string> {"PacketPop-Validate-Against-Checksum-Tooltip","Validate PacketPop URLs against a checksum value."},
        new List<string> {"PacketPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"LoginFormProc-Username-Tooltip","User name used for creating forms."},
        new List<string> {"LoginFormProc-Password-Tooltip","Password used for creating forms."},
        new List<string> {"LoginFormProc-Data-Source-Tooltip","ODBC data source name used when creating forms."},
        new List<string> {"LoginFormProc-Prompt-For-New-Form-Tooltip","Prompts the user to complete another form."},
        new List<string> {"Encrypt-LoginFormProc-Tooltip","Encrypt Login Form Proc keys for enhanced security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"},
        new List<string> {"ADFS-Enabled-Tooltip",""},
        new List<string> {"Synchronize-User-Attributes-Tooltip",""},
        new List<string> {"Authentication-Only-Tooltip",""},
        new List<string> {"Cookie-Handler-Require-SSL-Tooltip",""},
        new List<string> {"Trusted-Issuer-Name-Tooltip",""},
        new List<string> {"wsFederation-Issuer-Tooltip","The URI of the token issuer. Also referred to as security token service (STS)."},
        new List<string> {"wsFederation-Realm-Tooltip","The URI of the requesting realm (Relying Party), which identifies the relying party (RP) to the security token service (STS)."},
        new List<string> {"Certificate-X509-Find-Type-Tooltip","Specifies the type of X.509 search to be executed."},
        new List<string> {"Certificate-Find-Value-Tooltip","Specifies the value to search for in the X.509 certificate store."},
        new List<string> {"Certificate-Store-Location-Tooltip","A StoreLocation value that specifies the location of the X.509 certificate store. The default value is \"LocalMachine\"."},
        new List<string> {"Certificate-Store-Name-Tooltip","The name of the X.509 certificate store. The default is \"My\"."},
        new List<string> {"Application-Script-Location-Tooltip",""},
        new List<string> {"Application-Keyword-ID-Tooltip",""},
        new List<string> {"Application-Keyword-Validator-Tooltip",""},
        new List<string> {"Page-Location-Tooltip",""},
        new List<string> {"Page-Script-Location-Tooltip",""},
        new List<string> {"Page-Keyword-ID-Tooltip",""},
        new List<string> {"Page-Keyword-Validator-Tooltip",""},
        new List<string> {"Enable-Healthcare-Web-Viewer-Tooltip",""},
        new List<string> {"KeywordTypeahead-KeywordIDNumber-Tooltip","The unique Keyword Type ID# for the keyword that you are wanting to target."},
        new List<string> {"KeywordTypeahead-TypeaheadCharacterCount-Tooltip","The minimum number of characters that will need to be typed in before the drop down field will start showing potential matches."},
        new List<string> {"NavPanel-ContextEnabled-Tooltip",""},
        new List<string> {"NavPanel-Icon-Tooltip",""},
        new List<string> {"NavPanel-DisplayOrder-Tooltip",""},
        new List<string> {"NavPanel-DisplayName-Tooltip",""},
        new List<string> {"NavPanel-Name-Tooltip",""}
    };

    /* 221 Tooltip Objects */
    private readonly List<List<string>> AgendaOnline221Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stream-Chunk-Size-Tooltip",""},
        new List<string> {"Player-Source-File-Path-Tooltip","Path to directory where the media player resides."},
        new List<string> {"Player-Version-Tooltip","Version key of the media player."},
        new List<string> {"Min-Pool-Size-Tooltip","Minimum Pool Size"},
        new List<string> {"Max-Pool-Size-Tooltip","Maximum Pool Size"},
        new List<string> {"webpages-Enabled-Tooltip",""},
        new List<string> {"Session-Username-Tooltip","The OnBase user name for authentication."},
        new List<string> {"Session-Password-Tooltip","The OnBase password for authentication."},
        new List<string> {"Data-Source-Tooltip","The ODBC datasource utilized by the Application Server."},
        new List<string> {"Encrypt-Agenda-Online-Access-Tooltip", "Encrypt Agenda Public Access keys for enhanced security." }
    };

    private readonly List<List<string>> ApplicationServer221Tooltips = new List<List<string>>
    {
        new List<string> {"Server-Designation-Tooltip","(Optional) Enter a value to designate which server the user is connecting to, which will display in Web Diagnostics. This is helpful in a load balanced environment."},
        new List<string> {"Data-Source-Tooltip","The ODBC datasource utilized by the Application Server."},
        new List<string> {"Use-OS-Authentication-Tooltip","Set to true if the connection to the database should be made with OS Authentication instead of SQL Authentication. This requires an OS/domain user with access to the database to be configured as the user for this Application Server."},
        new List<string> {"Document-Query-Warning-Threshold-Tooltip","Display a warning message if the number of documents returned from a query exceeds this value. If Document Query Warning Threshold is greater than Document Query Limit, no warning message will be displayed."},
        new List<string> {"Document-Query-Limit-Tooltip","Document queries are limited when the number of returned documents exceeds this value."},
        new List<string> {"Item-Cache-Timeout-Tooltip","The number of seconds an item will exist within the item cache before it will be expired."},
        new List<string> {"Raw-Images-Tooltip","Images are sent directly to the viewer from the database instead of first being processed by ASP.NET on the server."},
        new List<string> {"Use-Isolated-Image-Process-Tooltip","Setting for initializing the out of process image rendering service."},
        new List<string> {"Compression-Quality-Tooltip","Controls the compression quality of color images and can be used to reduce memory usage when viewed. The default setting is 80 (measured in percent)."},
        new List<string> {"Enable-Isolated-Chromium-Process-Tooltip","Setting for initializing the Chromium Image service used by Unity Forms."},
        new List<string> {"Form-Save-To-TIFF-Timeout-Tooltip","Timeout in seconds for sending a Form to a TIFF file using the process image rendering service."},
        new List<string> {"Print-Image-Form-Via-PDF-Tooltip","Configuration to print image form via PDF. \"TRUE\" means printing via PDF else \"FALSE\" means printing via screenshot."},
        new List<string> {"TPCF-Worker-Location-Override-Tooltip","Specify a custom path for TPCF Worker directory"},
        new List<string> {"Default-Storage-Path-Tooltip","Default storage path for the File Monitoring Engine."},
        new List<string> {"Watch-Folder-Tooltip","The folder to monitor in Front Office Scanning."},
        new List<string> {"Site-ID-Keyword-Type-Tooltip","Site ID Keyword Type"},
        new List<string> {"Cleanup-Timer-Interval-Tooltip","Sets the time span (in seconds) after which the file monitoring system looks for changes."},
        new List<string> {"Max-File-Age-Tooltip","Maximum file age (in hours)."},
        new List<string> {"Integrations-EIS-Validate-Message-Schema-Tooltip","Set to true to perform validation on the Message Schema."},
        new List<string> {"Integrations-EIS-Continue-On-Validation-Error-Tooltip","Set to true to log an error and continue when Message Schema validation fails."},
        new List<string> {"Integrations-EIS-Data-Set-Cache-Cleanup-Interval-Tooltip","Data Set Cache Cleanup Interval (Minutes)."},
        new List<string> {"Integrations-EIS-AppNet-Directory-Tooltip","The location of the virtual directory where the Web Server resides. This setting is needed to generate DocPop URLs."},
        new List<string> {"Integrations-EIS-Use-HTML-Client-Type-Tooltip","Set to true to use HTML as the client type when generating DocPop links."},
        new List<string> {"Message-Broker-Monitor-Start-Delay-Tooltip","Delay in minutes to start the timer used by the Message Broker to monitor for message issues and completed messages needing archiving."},
        new List<string> {"GCS-Username-Tooltip","User Name to connect to GCS. Can be in plain text or use ASPNET_SETREG.exe to encrypt. For example: \"registry:HKLM\\SOFTWARE\\Hyland\\GCS\\UsageBasedBilling\\identity\\ASPNET_SETREG,userName\""},
        new List<string> {"GCS-Password-Tooltip","Password to connect to GCS. Can be in plain text or use ASPNET_SETREG.exe to encrypt. For example: \"registry:HKLM\\SOFTWARE\\Hyland\\GCS\\UsageBasedBilling\\identity\\ASPNET_SETREG,password\""},
        new List<string> {"Use-Legacy-Key-For-Usage-Based-Billing-Tooltip",""},
        new List<string> {"GCS-Phone-Home-Interval-Tooltip","Time interval (in minutes) to perform phone home to GCS server."},
        new List<string> {"Data-Capture-Server-WCF-Endpoint-Address-Tooltip","Data Capture Server WCF Endpoint Address"},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"OWIN-Application-Server-Origin-Tooltip","The application server origin used to create absolute links. In a load-balanced environment, hostname would be the load-balancer. Example: https://hostname/AppServer"},
        new List<string> {"OWIN-Automatic-App-Startup-Tooltip","Automatic App Startup"},
        new List<string> {"OWIN-App-Startup-Tooltip","Location of the OWIN startup class"},
        new List<string> {"Identity-Model-Server-URI-Tooltip",""},
        new List<string> {"Mobile-Apps-Path-Tooltip","Mobile Apps Path"},
        new List<string> {"CORS-Policy-Tooltip","CORS Policy"},
        new List<string> {"WorkView-Mobile-Endpoint-Tooltip","Check this box to enable this application as a WorkView Mobile Endpoint."},
        new List<string> {"Responsive-Apps-Endpoint-Tooltip","Check this box to enable this application as a Responsive Apps Endpoint."},
        new List<string> {"WOPI-Endpoint-Tooltip","Endpoint setting for Office Online Server"},
        new List<string> {"Sesame-Endpoint-Tooltip","Check this box to enable this application as a Sesame Endpoint."},
        new List<string> {"Governance-Rules-As-A-Service-Endpoint-Tooltip","Check this box to enable this application as a Governance Rules As A Service (GRAAS Endpoint."},
        new List<string> {"Web-BLOB-Passthrough-FHIR-Endpoint-Tooltip","Check this box to enable this application as a Web BLOB Passthrough (WBPT) FHIR Endpoint."},
        new List<string> {"SMART-On-FHIR-Application-ID-Tooltip",""},
        new List<string> {"PPL-Endpoint-Enabled-Tooltip","Check this box to enable this application as a PPL Endpoint."},
        new List<string> {"Forms-Endpoint-Tooltip","Check this box to enable this application as a Forms Endpoint."},
        new List<string> {"PPL-DocPop-URL-Tooltip","This is the URL for viewing Unity Forms in Patient Portal Link. Do not add a trailing slash."},
        new List<string> {"Statement-Composition-Cache-Limit-Tooltip","Maximum number of cached statement composition documents."},
        new List<string> {"Unity-Forms-Toggle-Max-Form-Width-Tooltip","Changes the Unity forms rendering behavior when form elements exceed the width of the form.<br>Set this to \"true\" to prevent the form from expanding to match the width of the largest element."},
        new List<string> {"owin:oia:msgItemTypeId-Tooltip",""},
        new List<string> {"owin:oia:lifeCycleId-Tooltip",""},
        new List<string> {"owin:oia:tmpFilePath-Tooltip",""},
        new List<string> {"owin:oia:tmpFileAgeInMs-Tooltip",""},
        new List<string> {"owin:oia:cleanupIntervalInMs-Tooltip",""},
        new List<string> {"Use-OnBase-Full-Text-Tooltip",""},
        new List<string> {"Content-Composer-IdP-Path-Tooltip",""},
        new List<string> {"Keyword-Data-Cache-Timeout-Tooltip","Timeout in minutes used to determine how long keyword metadata is stored in memory. WARNING, increasing this value over the default of 20 minutes will increase memory consumption on the application server. Lowering this value can result in undesirable behavior."},
        new List<string> {"Allow-Insecure-External-XSL-Tooltip",""},
        new List<string> {"Max-Query-Execution-Parallelism-Tooltip",""},
        new List<string> {"Folder-Fetch-Batch-Size-Tooltip",""},
        new List<string> {"Database-Command-TimeOut-Tooltip","Sharebase folder Database Command Time Out in Seconds."},
        new List<string> {"Responsive-Apps-WorkView-API-URL-Tooltip","WorkViewApi is the path to the WorkView web api facet. Example: \"https://hostname/AppServer/private/workview/api/\""},
        new List<string> {"Responsive-Apps-WorkView-Files-URL-Tooltip","WorkViewFiles is the path to the WorkView static file server facet. Example: \"https://hostname/AppServer/private/workview/files/\""},
        new List<string> {"Responsive-Apps-API-URL-Tooltip","ResponsiveAppsApi is the path to the Responsive Apps web api facet. Example: \"https://hostname/AppServer/private/responsive-apps/api/\""},
        new List<string> {"Identity-Provider-URL-Tooltip","IdentityProvider is the path to the Identity Provider including tenant and user population. Example: \"https://hostname/idp/workview/mobile/\""},
        new List<string> {"Core-Access-Token-Lifetime-Tooltip","CoreAccessTokenLifetime is the property that is used for configuring the default length (in seconds) that a ReAuth token is good for when accessed through resonsive-apps."},
        new List<string> {"File-IO-Detail-Tooltip",""},
        new List<string> {"Foreign-Storage-EMC-Threshold-Tooltip","Setting for Centera inline blobs in KB.  Default is 75."},
        new List<string> {"Foreign-Storage-PM-Cache-Location-Tooltip","Path to cache location."},
        new List<string> {"Foreign-Storage-PM-Cache-Timeout-Tooltip","Timeout in minutes.  Default is 60 minutes."},
        new List<string> {"Foreign-Storage-PM-Cache-Size-Tooltip","Cache size in MB.  Default is 500."},
        new List<string> {"PM-File-Access-Level-Tooltip","0 or empty for Default, 1 to Always use UNC, 2 to Never to UNC."},
        new List<string> {"Temp-File-Expiration-Threshold-Time-Tooltip","The minimum amount of time a temporary file should exist without being accessed before it expires. Default is 00:05:00 (five minutes)."},
        new List<string> {"Hyland-Services-AppPool-Minimum-Sessions-Tooltip","This parameter dictates the minimum number of OnBase sessions available in the session pool. (default 0)"},
        new List<string> {"Hyland-Services-AppPool-Maximum-Sessions-Tooltip","This parameter dictates the maximum number of OnBase sessions available in the session pool.  Requests from the pool that exceed this value will block until another session is placed back into the pool. (default 10)"},
        new List<string> {"Use-Query-Context-Tooltip","This parameter indicates if query context security will be used during the course of retrieval. Query context means that a document must be retrieved through a document query before the document itself is accessible via another call. If this parameter is omitted, the default is true. Note: this value should be set to false when being used for disconnected web services. (default false)"},
        new List<string> {"Filter-Exceptions-Tooltip","This parameter indicates if the application server should not send detailed information about exception. For example, the exact stack trace of the exception will be filtered. This reduces the amount of information revealed to a malicious attacker when the server is attacked. The information is still available via Diagnostics Console and Diagnostics Server for an authorized user. (default true)"},
        new List<string> {"Endpoint-Use-Remoting-Tooltip",""},
        new List<string> {"Session-Enable-Timeout-Tooltip","Controls the timeout behavior for unused sessions. If enableTimeout is set to true the AppServer will timeout unused sessions and disconnect them. The timeout period is based on the ASP.NET session timeout found in the system.web\\session section with a minimum of 10 minutes. (default false)"},
        new List<string> {"Application-Server-Callback-URL-Tooltip",""},
        new List<string> {"Web-Server-Base-URL-Tooltip",""},
        new List<string> {"Request-Validation-Minimum-Version-Tooltip",""},
        new List<string> {"Login-ID-Tooltip",""},
        new List<string> {"Login-Password-Tooltip",""},
        new List<string> {"Login-Datasource-Tooltip",""},
        new List<string> {"Pool-Min-Tooltip",""},
        new List<string> {"Pool-Max-Tooltip",""},
        new List<string> {"Search-Timeout-Tooltip","The length of time (in seconds) before the search will timeout."},
        new List<string> {"Enable-Search-Log-Tooltip","Enables Full Text search logs in the specified path(<SearchLog enableSearchlog=\"true\" path=\"<HostName>/SearchLogs\"/>). Path should have full access rights for 'Everyone'."},
        new List<string> {"Search-Log-Path-Tooltip",""},
        new List<string> {"Unity-Editable-Filter-Max-Rows-Tooltip","Sets Max results for Unity client editable embedded filters (Default: 250, Max: 2000)."},
        new List<string> {"ERP-Date-Format-LOB-Broker-Tooltip","Sets the ERP date format for processing results for LOB Broker classes."},
        new List<string> {"Formatted-Text-Iframe-Supported-Domains-Tooltip","Adds additional domains that should be supported by iframes in the formatted text attribute control. Adding a domain to this list will add `allow-scripts`, `allow-same-origin`, and `allow-forms` overrides to the sandbox attribute on the iframe. Add domains as a comma separated list.<br><br>Examples:<br>&nbsp;&nbsp;&nbsp;&nbsp;*.mydomain.com<br>&nbsp;&nbsp;&nbsp;&nbsp;sub.myotherdomain.com<br><br>In this example *.mydomain.com will enable all sub-domains for mydomain.com (Ex: www.mydomain.com and test.mydomain.com would be valid), sub.myotherdomain.com would only allow sandbox overrides for that specific domain and sub-domain."},
        new List<string> {"Use-Office-Online-Server-Tooltip","Set to true to use the WOPI viewer. Set to false to continue using the legacy viewer."},
        new List<string> {"Office-Online-Server-URI-Tooltip","Points to the Office Online Server."},
        new List<string> {"Office-Online-Server-Proxy-Base-Tooltip","Points to the WOPI Service. Example: \"https://localhost/AppServer/private\""},
        new List<string> {"Vendor-Cache-Search-Minimum-Characters-Tooltip",""},
        new List<string> {"Vendor-Master-Keyed-Lookup-Op-Tooltip",""},
        new List<string> {"Vendor-Master-Lookup-Sequence-Tooltip",""},
        new List<string> {"Vendor-Master-Lookup-Return-Multiple-Tooltip",""},
        new List<string> {"Vendor-Cache-AutoComplete-Result-Max-Tooltip",""},
        new List<string> {"Enable-LOB-Broker-Accounts-Payable-Tooltip",""},
        new List<string> {"Http-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"Http-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Session-Timeout-Length-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"Content-Composer-Client-ID-Tooltip","Client ID provided by the Hyland Identity Provider (IdP)."},
        new List<string> {"Content-Composer-Client-Secret-Tooltip","Client secret provided by the Hyland Identity Provider (IdP)."},
        new List<string> {"Content-Composer-Username-Tooltip","Hyland IdP user with Content Composer access."},
        new List<string> {"Content-Composer-Password-Tooltip","Password for Hyland IdP user with Content Composer access."},
        new List<string> {"Encrypt-Content-Composer-Settings-Tooltip","Checking this will encrypt the Content Composer section in configuration."},
        new List<string> {"Pop-Integrations-Validate-Against-Checksum-Tooltip","Validate a Pop URL with the checksum value."},
        new List<string> {"Pop-Integrations-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"Pop-Integrations-Enable-Legacy-Checksum-Creation-Tooltip","Creates checksums using the legacy checksum validation."},
        new List<string> {"Pop-Integrations-Encrypt-Configuration-Tooltip","Encrypt configuration information for improved security."},
        new List<string> {"Integrations-Media-URL-Tooltip","URL to the OnBase Cloud"},
        new List<string> {"Integrations-Media-Datasource-Tooltip","Customer Datasource"},
        new List<string> {"Integrations-Media-Username-Tooltip","Customer username to OnBase Cloud"},
        new List<string> {"Integrations-Media-Password-Tooltip","Customer password to OnBase Cloud"},
        new List<string> {"Integrations-Media-Encrypt-OnBase-Cloud-Settings-Tooltip","When checked, url, datasource, username and password will be encrypted."},
        new List<string> {"EAC-Username-Tooltip","The OnBase User (usually a service account) that the Application Server uses to process EAC logon requests."},
        new List<string> {"EAC-Password-Tooltip","The password to the account handling EAC logons."},
        new List<string> {"EAC-UserLevel-Minimum-Pool-Size-Tooltip","The minimum number of OnBase user sessions maintained for this pool while the EAC Application Server is running."},
        new List<string> {"EAC-UserLevel-Maximum-Pool-Size-Tooltip","The maximum number of OnBase user sessions maintained for this pool while the EAC Application Server is running.  If the number of concurrent users accessing this pool is greater than this number, user requests will be queued."},
        new List<string> {"Encrypt-EAC-Tooltip","Encrypt EAC configuration settings for enhanced security."},
        new List<string> {"Authentication-Mode-Tooltip","This section sets the authentication policies of the application. Possible modes are \"Windows\" and \"None\".<br><br>\"None\" - No authentication is performed.<br>\"Windows\" - IIS performs authentication (Basic, Digest, or Integrated Windows) according to its settings for the application. Anonymous access must be disabled in IIS."},
        new List<string> {"ADFS-Enabled-Tooltip","This checkbox indicates whether the ADFS node is set to enabled."},
        new List<string> {"Request-Validation-Mode-Tooltip","The Request Validation Mode must be set to 2.0 for ADFS."},
        new List<string> {"Synchronize-User-Attributes-Tooltip",""},
        new List<string> {"Authentication-Only-Tooltip",""},
        new List<string> {"Cookie-Handler-Require-SSL-Tooltip","Configures the CookieHandler that the SessionAuthenticationModule (SAM) uses to read and write cookies."},
        new List<string> {"Audience-URI-Tooltip","Audience URI. As configured on the Endpoints tab of the Relying Party Trust. Requires trailing slash."},
        new List<string> {"Trusted-Issuer-Thumbprint-Tooltip","The issuer of the certificate used to validate the signature on responses from ADFS."},
        new List<string> {"Trusted-Issuer-Name-Tooltip",""},
        new List<string> {"wsFederation-Issuer-Tooltip","The URI of the token issuer. Also referred to as security token service (STS)."},
        new List<string> {"wsFederation-Realm-Tooltip","The URI of the requesting realm (Relying Party), which identifies the relying party (RP) to the security token service (STS)."},
        new List<string> {"Certificate-X509-Find-Type-Tooltip","Specifies the type of X.509 search to be executed."},
        new List<string> {"Certificate-Find-Value-Tooltip","Specifies the value to search for in the X.509 certificate store."},
        new List<string> {"Certificate-Store-Location-Tooltip","A StoreLocation value that specifies the location of the X.509 certificate store. The default value is \"LocalMachine\"."},
        new List<string> {"Certificate-Store-Name-Tooltip","The name of the X.509 certificate store. The default is \"My\"."},
        new List<string> {"Hyland-Idp-Url-Tooltip",""},
        new List<string> {"Hyland-IdP-Audience-URL-Tooltip",""},
        new List<string> {"Hyland-IdP-Name-Claim-Type-Tooltip",""},
        new List<string> {"Hyland-IdP-Api-Name-Tooltip",""},
        new List<string> {"Hyland-IdP-Api-Secret-Tooltip",""},
        new List<string> {"Alias-Old-Name-Tooltip",""},
        new List<string> {"Alias-New-Name-Tooltip",""},
        new List<string> {"Alias-Type-Tooltip",""},
        new List<string> {"SessionAdministration-User-Tooltip",""},
        new List<string> {"SessionAdministration-Role-Tooltip",""},
        new List<string> {"Trust-Mode-Tooltip",""},
        new List<string> {"Store-Location-Tooltip",""},
        new List<string> {"Store-Name-Tooltip",""},
        new List<string> {"Find-Type-Tooltip",""},
        new List<string> {"Find-Value-Tooltip",""},
        new List<string> {"Description-Tooltip",""},
        new List<string> {"App-Name-Tooltip",""},
        new List<string> {"App-Icon-URL-Tooltip",""},
        new List<string> {"App-URL-Tooltip",""}
    };

    private readonly List<List<string>> ElectronicPlanReview221Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stylesheet-Directory-Location-Tooltip","The directory containing files that add a specific look and feel to the site. Default location is BasicBlue."},
        new List<string> {"Allow-Sign-On-Tooltip","Allows users to sign on for access to create plan projects."},
        new List<string> {"Allow-Sign-Off-Tooltip","Allows users to sign off."},
        new List<string> {"Default-User-Time-Zone-Tooltip","Provides a way to set the initial time zone."},
        new List<string> {"Search-Start-Year-Tooltip","For Users searching plan project history, the Yearly search option list limits the list with this item."},
        new List<string> {"Items-Per-Page-Tooltip","The number of items to display on a project list or paged list of documents."},
        new List<string> {"Max-Lookup-Results-Tooltip",""},
        new List<string> {"Reset-Password-Link-Lifetime-Tooltip","Controls how long a reset link remains active, before it will not be allowed to reset a password. This is specified in minutes."},
        new List<string> {"File-Upload-Directory-Tooltip","The directory that stages plan documents while they are received from the client before forwarding them onto app server."},
        new List<string> {"File-Upload-Validator-Tooltip","File Upload Validator Format: Assembly Path,Class Name,Method Name."},
        new List<string> {"Token-Authentication-Tooltip",""},
        new List<string> {"Allow-Single-Sign-On-Tooltip","Enables the use of SSO.  This enables a user to login to a single system and automatically login to the plan review site."},
        new List<string> {"Source-ID-Tooltip","Source ID"},
        new List<string> {"Resolution-Mode-Tooltip","Resolution Mode"},
        new List<string> {"Public-CAPTCHA-Key-Tooltip","Public CAPTCHA API key provided by 3rd party CAPTCHA service."},
        new List<string> {"Private-CAPTCHA-Key-Tooltip","Private CAPTCHA API key provided by 3rd party CAPTCHA service."},
        new List<string> {"Password-Strength-Pattern-Tooltip","The password strength regular expression determines the minimum character length and characters/symbols that a password must contain in order to be a valid password."},
        new List<string> {"Password-Strength-Message-Tooltip","An optional password strength message that is displayed when the password requested during registration does not meet the required strength."},
        new List<string> {"Username-Validation-Pattern-Tooltip",""},
        new List<string> {"Discipline-Items-Per-Menu-Tooltip","Number of discipline items displayed in menu in the Plan review web client."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"EPR-Username-Tooltip","The OnBase user that Application Server uses to process Plan Review requests."},
        new List<string> {"EPR-Password-Tooltip","The OnBase user password that Application Server uses to process Plan Review requests."},
        new List<string> {"Data-Source-Tooltip","The OnBase Data Source that Application Server uses to process Plan Review Requests."},
        new List<string> {"Encrypt-Electronic-Plan-Review-Tooltip", "Determines whether or not the user name and password will be encrypted in the web.config file."}
    };

    private readonly List<List<string>> GatewayCachingServer221Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Allow-NT-Authentication-On-Forwarding-Tooltip","If enabled, allows the web server to forward NT credentials to the Application Server. Only turn this flag on when using NT authentication."},
        new List<string> {"Optimized-Service-Pipeline-Tooltip",""},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Gateway-Name-Tooltip","Name of the Gateway Caching Server configured in Gateway Caching Server Configuration."},
        new List<string> {"DataSource-Tooltip","The OnBase database this ASG is connecting to on the Application Server."},
        new List<string> {"Cache-Path-Tooltip","This is the local disk path for the ASG cache. This should not be a UNC path."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"GWCS-Username-Tooltip","Service Account that connects ASG to the Application Server. This user retrieves the documents that cache automatically."},
        new List<string> {"GWCS-Password-Tooltip","Password for the Service Account."},
        new List<string> {"Encrypt-Login-Settings-Tooltip", "Encrypt ASG settings for enhanced security." }
    };

    private readonly List<List<string>> HealthcareFormManager221Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Allow-View-Source-Tooltip","Enables/disables view source."},
        new List<string> {"Enable-Session-Expiration-Tooltip","The end user will be logged out when no activity is detected."},
        new List<string> {"Prompt-On-Session-Expire-Tooltip","Prompts the user with a warning 30 seconds before the session expires."},
        new List<string> {"Web-Theme-Tooltip",""},
        new List<string> {"Default-Username-Tooltip","Default User Name."},
        new List<string> {"Default-Password-Tooltip","Default Password."},
        new List<string> {"Default-Login-Tooltip","Uses the web.config user name and password for Healthcare FormPop login."},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using the default user name and password."},
        new List<string> {"Force-OnBase-Authentication-Tooltip","Ignores database domain authentication settings and uses OnBase authentication instead."},
        new List<string> {"Web-Client-Type-Tooltip","Determines which type of Web Client to use.<br>activex - This will enable the ActiveX web client.<br>html - This will enable the HTML Only web client.<br>selectable - This will provide users an option upon login to select which client type (ActiveX or HTML Only) to use."},
        new List<string> {"Row-Coloring-Tooltip","Set to true to give every other row a shaded background in the document select list. Set to false to turn off row coloring."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"Prevent-Viewer-Client-Caching-Tooltip","Enable Prevent Viewer Client Caching to direct the HTML Web Client Viewer to not cache page data on the client for a brief period of time. Preventing caching will negatively impact performance. Recommended setting is false."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Session-Timeout-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Samesite-Cookie-Policy-Tooltip","The Web Server can use a strict, lax, or none policy for samesite cookies."},
        new List<string> {"Validate-Against-Checksum-Tooltip","Validate a Pop URL with the checksum value."},
        new List<string> {"Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"Enable-Legacy-Checksum-Fallback-Tooltip","Attempts to use the legacy checksum validation if the most recent validation fails to validate."},
        new List<string> {"Encrypt-Healthcare-Pop-Integration-Configuration-Tooltip","Encrypt configuration information for improved security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"}
    };

    private readonly List<List<string>> PatientWindow221Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Allow-View-Source-Tooltip","Enables/disables view source."},
        new List<string> {"Enable-Session-Expiration-Tooltip","The end user will be logged out when no activity is detected."},
        new List<string> {"Prompt-On-Session-Expire-Tooltip","Prompts the user with a warning 30 seconds before the session expires."},
        new List<string> {"Web-Theme-Tooltip",""},
        new List<string> {"Default-Username-Tooltip","Default User Name"},
        new List<string> {"Default-Password-Tooltip","Default Password"},
        new List<string> {"Enable-Default-Login-Tooltip",""},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using the default user name and password."},
        new List<string> {"Force-OnBase-Authentication-Tooltip","Ignores database domain authentication settings and uses OnBase authentication instead."},
        new List<string> {"Enable-Split-View-Tooltip",""},
        new List<string> {"Enable-Patient-Search-Tooltip",""},
        new List<string> {"Enable-Patient-Context-Syncing-Tooltip",""},
        new List<string> {"Enable-Timestamp-Tooltip",""},
        new List<string> {"Timestamp-Time-Limit-Tooltip",""},
        new List<string> {"Enable-Workstation-Name-DNS-Lookup-Tooltip",""},
        new List<string> {"Row-Coloring-Tooltip","Set to true to give every other row a shaded background in the document select list. Set to false to turn off row coloring."},
        new List<string> {"Allow-Caching-Tooltip","Specifies whether caching should be enabled."},
        new List<string> {"Maximum-Width-Tooltip","Maximum width, in pixels."},
        new List<string> {"Maximum-Height-Tooltip","Maximum height, in pixels."},
        new List<string> {"Preview-Maximum-Width-Tooltip","Maximum width for the preview, in pixels."},
        new List<string> {"Preview-Maximum-Height-Tooltip","Maximum height for the preview, in pixels."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"Prevent-Viewer-Client-Caching-Tooltip","Enable Prevent Viewer Client Caching to direct the HTML Web Client Viewer to not cache page data on the client for a brief period of time. Preventing caching will negatively impact performance. Recommended setting is false."},
        new List<string> {"HTML-Only-Documents-Print-As-PDFs-Tooltip",""},
        new List<string> {"System-List-Display-Label-Tooltip",""},
        new List<string> {"Personal-List-Display-Label-Tooltip",""},
        new List<string> {"Selected-Tab-Single-Color-Tooltip",""},
        new List<string> {"Enable-EForm-Standard-Printing-Tooltip",""},
        new List<string> {"Federated-Search-With-MPI-Tooltip",""},
        new List<string> {"Hide-Toolbar-Print-Button-Tooltip",""},
        new List<string> {"Auto-Display-Note-Panel-PDF-Office-Tooltip",""},
        new List<string> {"Emergency-Access-Dialog-Title-Tooltip",""},
        new List<string> {"Emergency-Access-Dialog-Message-Tooltip",""},
        new List<string> {"Emergency-Access-Dialog-Other-Reason-Label-Tooltip",""},
        new List<string> {"Show-Emergency-Access-Show-Documents-Checkboxes-Tooltip",""},
        new List<string> {"Show-Other-Reason-In-Emergency-Access-Dialog-Tooltip",""},
        new List<string> {"Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog-Tooltip",""},
        new List<string> {"ADFS-Enabled-Tooltip",""},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Session-Timeout-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Samesite-Cookie-Policy-Tooltip","The Web Server can use a strict, lax, or none policy for samesite cookies."},
        new List<string> {"Validate-Against-Checksum-Tooltip","Validate a Pop URL with the checksum value."},
        new List<string> {"Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"Enable-Legacy-Checksum-Fallback-Tooltip","Attempts to use the legacy checksum validation if the most recent validation fails to validate."},
        new List<string> {"Encrypt-Healthcare-Pop-Integration-Configuration-Tooltip","Encrypt configuration information for improved security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"}
    };

    private readonly List<List<string>> PublicAccessNextGen221Tooltips = new List<List<string>>
    {
        new List<string> {"Encrypt-Doc-ID-Tooltip","Set to true to encrypt the document ID when displaying search results."},
        new List<string> {"Use-Display-Columns-Tooltip","Set to true to use the configured Custom Query display columns when displaying search results."},
        new List<string> {"Query-Limit-Tooltip","Search results will be limited to this number. Set to 0 for unlimited queries."},
        new List<string> {"Chunk-Size-Tooltip","Chunk size (in bytes) to use when downloading documents."},
        new List<string> {"Viewer-Mode-Tooltip","Set to PDF to convert documents to PDF format and stream to the viewer. Set to Native to download files in their native format. Set to Native Optional to stream files as PDF and provide a link in the viewer to download the file in its native format."},
        new List<string> {"Default-Overlay-Mode-Tooltip","The default overlay mode to render documents in, if applicable. Possible values are Print, View, and Off. Defaults to Print, was used by the past versions of Public Access."},
        new List<string> {"Cache-Path-Tooltip","Cache path"},
        new List<string> {"Expiration-Time-Tooltip","Expiration time (in days)"},
        new List<string> {"Max-Cache-Size-Tooltip","Maximum cache size on disk (GB)."},
        new List<string> {"Size-to-Cache-Tooltip","Documents with a file size equal to or greater than Size to Cache (MB) should be cached."},
        new List<string> {"Size-to-Prompt-Tooltip","Documents with a file size equal to or greater than Size to Prompt (MB) will display the browser's open/save dialog."},
        new List<string> {"Interval-Between-Throttle-Cache-Resets-Tooltip","The amount of time, in minutes, between each iteration of clearing the throttle cache. If a user is blocked from making requests, they will have to wait until this timer expires to make any more requests, or their requests will be denied. Users will only be blocked if they exceed the threshold, and if throttling is enabled. A value of 0 or less disables this behavior."},
        new List<string> {"Amount-of-Requests-During-Each-Throttle-Interval-Tooltip","The amount of requests that can be received before the host from which these requests originate is blocked for an amount of time specified in the throttle reset interval. This is to reduce the potential attack vector of a denial of service attack."},
        new List<string> {"Enable-Local-Browser-Caching-Tooltip","Whether or not to allow browsers to privately and locally cache documents returned from the public access toolkit for a short period of time in order to reduce the amount of repeated requests."},
        new List<string> {"Decorate-Document-Names-Tooltip","Whether or not to show decoration/formatting for document names (i.e. <yellow>). Only works on autonames. Decoration will always be applied to display columns, regardless of this setting."},
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"SOAP-Client-Request-Timeout-Tooltip","Timeout (in seconds) for service requests when using the SOAP client. The HttpRuntime Execution Timeout on the Application Server must be greater than or equal to this value."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"PAVNG-Username-Tooltip","Default User Name"},
        new List<string> {"PAVNG-Password-Tooltip","Default Password"},
        new List<string> {"Data-Source-Tooltip","Default Data Source"},
        new List<string> {"Encrypt-Public-Access-Configuration-Tooltip", "Encrypt Public Access keys for enhanced security."},
        new List<string> {"Query-ID-Tooltip","The ID Number of the query as noted inside of the Configuration Client. A Query ID of * indicates that the keyword is required by all queries."},
        new List<string> {"Keyword-ID-Tooltip","The Keyword ID Number of the keyword as noted inside of the Configuration Client."}
    };

    private readonly List<List<string>> ReportingViewer221Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Optimized-Service-Pipeline-Tooltip","Use the optimized service pipeline for more efficient communication of results."},
        new List<string> {"Request-Timeout-Tooltip","Determines how long the service client should wait for a response from the application server."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"Web-Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Core-Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Server-Designation-Tooltip","(Optional) Enter a value to designate which server the user is connecting to, which will display in the window title. This is helpful in a load balanced environment."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"JSON-Serialization-Max-Length-Tooltip",""},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"OB-Username-Tooltip","This user name along with the associated password will be used to automatically log the user into the Dashboard Web Viewer."},
        new List<string> {"OB-Password-Tooltip","This password along with the associated user name will be used to automatically log the user into the Dashboard Web Viewer."},
        new List<string> {"Dashboard-Theme-Tooltip","Determines the theme that the dashboard uses when it is rendered."},
        new List<string> {"Export-Dashboard-Tooltip","Allows users to export the dashboard as an image or a PDF."},
        new List<string> {"Export-Dashboard-Items-Tooltip","Allows users to export each dashboard item as an image or a PDF."},
        new List<string> {"Allow-HTTP-Parameters-Tooltip","Allows the dashboard viewer to accept dashboard parameters from the HTTP request query string."},
        new List<string> {"Dashboard-Tracing-Info-Level-Tooltip",""},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using NT Authorization or SSO."},
        new List<string> {"Report-Paging-Limit-Tooltip","This option controls the number of records that will be shown per page for a given report.  The minimum value is 50."},
        new List<string> {"Dashboard-Cache-Timeout-Tooltip",""},
        new List<string> {"Encrypt-Dashboard-Viewer-Settings-Tooltip","Encrypt Dashboard Viewer keys for enhanced security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"}
    };

    private readonly List<List<string>> WebServer221Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Allow-NT-Authentication-On-Forwarding-Tooltip","If enabled, allows the web server to forward NT credentials to the Application Server. Only turn this flag on when using NT authentication."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Core-Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Web-Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Server-Designation-Tooltip","(Optional) Enter a value to designate which server the user is connecting to, which will display in the window title. This is helpful in a load balanced environment."},
        new List<string> {"Default-Domain-Name-Tooltip","Default domain name displayed/entered on the login page."},
        new List<string> {"Default-Username-Tooltip","Default User Name"},
        new List<string> {"Default-Password-Tooltip","Default Password"},
        new List<string> {"Default-Institution-Tooltip","Default Institution"},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using the default user name and password."},
        new List<string> {"Force-OnBase-Authentication-Tooltip","Ignores database domain authentication settings and uses OnBase authentication instead."},
        new List<string> {"Custom-SSO-Authentication-Page-Failure-Tooltip","URL of a specific page that the user is redirected to if login fails while using Single Sign On."},
        new List<string> {"Close-On-Logout-Tooltip","If set to true, the window is automatically closed when the user logs out. Otherwise, the user is returned to the login screen."},
        new List<string> {"Logout-Redirect-URL-Tooltip","Redirects the user to a specific page upon logout."},
        new List<string> {"Web-Theme-Tooltip",""},
        new List<string> {"Target-Page-Tooltip",""},
        new List<string> {"Login-Page-Tooltip",""},
        new List<string> {"SharePoint-Viewer-Show-Workflow-Tooltip","Turn on/off the Workflow header bar in SharePoint."},
        new List<string> {"SharePoint-Online-Tooltip","Toggling SharePoint Online changes the authentication scheme used. If set to true, it uses OAuth. If set to false, it uses the provided certificate."},
        new List<string> {"Prompt-User-Queries-Tooltip","Checks to see if constraints have been applied to custom queries."},
        new List<string> {"Show-Queue-Counts-Tooltip","Enables/disables queue counts in workflow (may hinder system performance if set to true)."},
        new List<string> {"Reselect-Delta-Tooltip","This key controls how many places before and after the previous index to search for the document to re-select after performing an ad-hoc task."},
        new List<string> {"Text-Search-Auto-View-Tooltip","Enables/disables text search auto view."},
        new List<string> {"Max-Results-Tooltip","The maximum number of documents displayed in a results list."},
        new List<string> {"Workflow-Max-Results-Tooltip","The maximum number of items displayed in the Workflow Inbox."},
        new List<string> {"Keyword-Panel-View-Type-Tooltip","This key controls how KeywordType names and Keyword operators are displayed. Please refer to the admin manual for detailed descriptions."},
        new List<string> {"Enable-Keyword-Operators-Tooltip","Enables or disables the use of keyword operators in the keyword panel."},
        new List<string> {"Enable-Session-Expiration-Tooltip","The end user will be logged out when no activity is detected."},
        new List<string> {"Prompt-On-Session-Expire-Tooltip","Prompts the user with a warning 30 seconds before the session expires."},
        new List<string> {"Display-Single-Document-Tooltip","Automatically opens a document if only one document is returned in the hitlist."},
        new List<string> {"Display-Related-Documents-Tooltip","Determines when to display the Work Folder tab: always, never, or document. If set to document, the tab will only display when a selected document in a queue has at least one related document."},
        new List<string> {"Workflow-Height-px-Tooltip","The height, in pixels, of the Workflow user interaction area. This value must be greater than 150."},
        new List<string> {"Show-Combined-Inbox-Tooltip","Specifies whether or not the combined inbox should be displayed."},
        new List<string> {"Override-UI-Language-Tooltip","The language select option appears on the login page instead of using the default language for your locale."},
        new List<string> {"Default-UI-Local-Tooltip","When Override UI Language is set to true, this key sets the behavior of the UI. To have a specific language be the default, regardless of locale setting, set this value to the locale."},
        new List<string> {"Enable-Virtual-Print-Driver-Tooltip","Enables support for importing documents using the Virtual Print Driver."},
        new List<string> {"Auto-Display-Note-Panel-PDF-Office-Tooltip","Automatically display the note panel when viewing PDF and Office documents."},
        new List<string> {"Clear-Document-Type-After-Import-Tooltip","Clear Document Type After Import."},
        new List<string> {"Clear-Keywords-After-Import-Tooltip","Clear Keywords After Import."},
        new List<string> {"Always-Generate-Preview-Tooltip","Always generate preview of an uploaded document."},
        new List<string> {"Remember-Hitlist-Height-Tooltip","The Web Client remembers the size of the document search results list, even after Internet Explorer has been closed."},
        new List<string> {"Number-of-Docuemnt-Types-to-Display-Tooltip","The number of document types to display in the select list in Document Retrieval without the need to scroll."},
        new List<string> {"Collapse-Check-Select-Lists-Tooltip","When set to true, all Check Select List controls will begin in a collapsed state."},
        new List<string> {"Add-Note-Menu-Tooltip","Enables/disables the Notes | Add Note right-click option."},
        new List<string> {"Create-New-Document-Menu-Tooltip","Enables/disables the Send To | Create New Document right-click option."},
        new List<string> {"Document-Properties-Menu-Tooltip","Enables/disables the Document Properties right-click option."},
        new List<string> {"File-Menu-Tooltip","Enables/disables the Send To | File right-click option."},
        new List<string> {"History-Menu-Tooltip","Enables/disables the History right-click option."},
        new List<string> {"Keywords-Menu-Tooltip","Enables/disables the Keywords right-click option."},
        new List<string> {"Print-Menu-Tooltip","Enables/disables the Print right-click option."},
        new List<string> {"Reindex-Menu-Tooltip","Enables/disables the Re-Index right-click option."},
        new List<string> {"Workflow-Menu-Tooltip","Enables/disables the Workflow right-click option."},
        new List<string> {"Send-To-Print-Queue-Menu-Tooltip","Enables/disables the Send To | Server Print Queue right-click option."},
        new List<string> {"Clipboard-Menu-Tooltip","Enables/disables the Send To | Clipboard right-click option."},
        new List<string> {"Go-To-Page-Tooltip","Goto page position."},
        new List<string> {"Overlay-Tooltip","Set to true or false to turn the default overlay display on or off."},
        new List<string> {"Zoom-Level-Tooltip","Zoom level when opening a document."},
        new List<string> {"Left-Border-Tooltip","Pixel position for the left border when using zoomrect."},
        new List<string> {"Right-Border-Tooltip","Pixel position for the right border when using zoomrect."},
        new List<string> {"Top-Border-Tooltip","Pixel position for the top border when using zoomrect."},
        new List<string> {"Bottom-Border-Tooltip","Pixel position for the bottom border when using zoomrect."},
        new List<string> {"Annotation-Toolbar-Tooltip","Enables/disables the Annotation toolbar."},
        new List<string> {"Notes-Toolbar-Tooltip","Enables/disables the Notes toolbar."},
        new List<string> {"Thumbnail-Pages-Tooltip","Enables/disables the Pages toolbar."},
        new List<string> {"Viewer-Control-Toolbar-Tooltip","Enables/disables the Viewer Control toolbar."},
        new List<string> {"Disable-Context-Menu-Tooltip","Disables the context menu on the web client Viewer."},
        new List<string> {"Path-Form-Proc-Tooltip",""},
        new List<string> {"Path-Print-Tooltip",""},
        new List<string> {"Prevent-Viewer-Client-Caching-Tooltip","Enable Prevent Viewer Client Caching to direct the HTML Web Client Viewer to not cache page data on the client for a brief period of time. Preventing caching will negatively impact performance. Recommended setting is false."},
        new List<string> {"Enable-Retrieve-Transactions-Tooltip","Enables/disables retrieving transactions for the selected document."},
        new List<string> {"Sort-by-Document-ID-Tooltip","Sort by Document ID when using the Retrieve Transaction functionality."},
        new List<string> {"Admin-Security-Keywords-Tooltip","Globally toggles whether an admin can assign security keywords."},
        new List<string> {"Default-Workflow-Layout-Tooltip","Specifies the way in which the Workflow interface will display: horizontal, vertical, separateviewer, or selectable.  When set to selectable, users can choose the layout they prefer."},
        new List<string> {"Row-Coloring-Tooltip","Set to true to give every other row a shaded background in the document select list. Set to false to turn off row coloring."},
        new List<string> {"Folder-Tree-Width-Tooltip","The folder tree width, represented as a percentage. This value must end in %."},
        new List<string> {"Folder-Tree-Height-Tooltip","The folder tree height, represented as a percentage. This value must end in %."},
        new List<string> {"Document-List-Height-Tooltip","The document list height, represented as a percentage. This value must end in %."},
        new List<string> {"Folder-List-Height-Tooltip","The folder list height, represented as a percentage. This value must end in %."},
        new List<string> {"WorkView-Max-Results-Tooltip","The maximum number of objects displayed for unconstrained filter results."},
        new List<string> {"WorkView-Filter-Count-Tooltip","Displays object count for all filters."},
        new List<string> {"Display-Created-EForms-Tooltip","Select the 'View E-Form Before Creating' option by default when users create e-forms from within WorkView."},
        new List<string> {"Enable-Standalone-WorkView-Client-Tooltip",""},
        new List<string> {"WorkView-Client-URL-Tooltip",""},
        new List<string> {"Application-Enabler-Integration-Tooltip","Allows Application Enabler to work with the Web Client."},
        new List<string> {"Launch-Application-Enabler-Tooltip","Launches the Application Enabler client by default."},
        new List<string> {"Data-Mining-Tooltip","Enable Data Mining content menu"},
        new List<string> {"Data-Mining-Temp-Directory-Tooltip","Fully qualified path to the data mining temporary directory."},
        new List<string> {"Data-Mining-Report-Server-Name-Tooltip","Enter the server name (host name) for where the Data Mining Reports reside."},
        new List<string> {"Data-Mining-URL-Tooltip","Location of Rms.aspx."},
        new List<string> {"Additional-Models-Tooltip","Enter a semicolon-delimited list of fully qualified pathnames to external model files. Do not use any spaces."},
        new List<string> {"Allow-View-Source-Tooltip","Enables/disables view source."},
        new List<string> {"Platter-Management-Cache-Location-Tooltip","Location on the Web Server where the cache files will be stored."},
        new List<string> {"Platter-Management-Cache-Timeout-Tooltip","The amount of time, in minutes, that files will exist in the cache."},
        new List<string> {"Platter-Management-Cache-Size-Tooltip","Cache size in MB."},
        new List<string> {"Open-Rich-Text-Format-Documents-With-Microsoft-Word-Tooltip","Enable this option to open Rich Text Format Documents with Microsoft Word."},
        new List<string> {"Allow-Caching-Tooltip","Specifies whether caching should be enabled."},
        new List<string> {"Show-Previews-Tooltip","Specifies whether or not previews of the thumbnails should be displayed."},
        new List<string> {"User-Configurable-Tooltip","Specifies whether or not the user is able to configure options for the Thumbnail Hit List Viewer."},
        new List<string> {"Number-of-Columns-Tooltip","The number of columns for the Hit List."},
        new List<string> {"Maximum-Width-Tooltip","Maximum width, in pixels."},
        new List<string> {"Maximum-Height-Tooltip","Maximum height, in pixels."},
        new List<string> {"Preview-Maxiumum-Width-Tooltip","Maximum width for the preview, in pixels."},
        new List<string> {"Preview-Maxiumum-Height-Tooltip","Maximum height for the preview, in pixels."},
        new List<string> {"Use-FolderPop-Viewer-Tooltip","Set to true to use FolderPop as the Document Viewer within ACC."},
        new List<string> {"Prompt-with-Unread-DKT-Docs-Tooltip","When set to true, the user is prompted at login to review any unacknowledged documents in DKT."},
        new List<string> {"Internal-Mail-Timer-In-Seconds-Tooltip","This timer controls how often the Web Client checks for new Internal Mail messages if the \"Notify on New Mail\" user option is enabled. By default, it checks every 300 seconds (5 minutes). This is the minimum allowed value. Setting Internal Mail Timer to 0 will disable mail notifications for all users."},
        new List<string> {"Allowed-Function-Key-List-Tooltip","Comma separated list of function key shortcuts that should not be blocked or overridden by the Web Client."},
        new List<string> {"Max-JSON-Deserialized-Members-Tooltip","The maximum number of form keys, files, and JSON members that can be used in an HTTP request. This setting is used in StatusView when configuring Foldering and WorkView portlets."},
        new List<string> {"Validation-Settings-Unobtrusive-Validation-Mode-Tooltip",""},
        new List<string> {"OWIN-Automatic-App-Startup-Tooltip","Open Web Interface for .NET (OWIN) automatic app startup enables the Administrator System Message feature."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections"},
        new List<string> {"Enabled-Legacy-Checksum-Fallback-Tooltip","Attempts to use the legacy checksum validation if the most recent validation fails to validate."},
        new List<string> {"Enable-Login-Autocomplete-Tooltip","Enable to have all login forms set as autocomplete on. Default value is false to have autocomplete off."},
        new List<string> {"Windows-Server-Locale-Format-Tooltip","Which version of Windows Server locale formats to use for data validation. A blank value will let the web client detect what version of Windows Server is running."},
        new List<string> {"Maximum-Import-Queue-Size-Tooltip","The number of documents to allow users to queue for import at a time. This value may not exceed 25, and may not be lower than 1."},
        new List<string> {"Enable-Browser-PDF-Viewer-Tooltip","Use PDF viewer provided by browser to view PDF documents, set to false will use onbase viewer. This setting will override user preferences setting. Leaving this value empty will allow users to choose which PDF viewer to use via user preferences"},
        new List<string> {"Multi-Form-Viewer-Origin-Tooltip","The origin from which the HMH Angular app which consumes MultiFormViewer is served."},
        new List<string> {"Use-Theme-Tooltip",""},
        new List<string> {"Enable-Export-Dashboard-Tooltip",""},
        new List<string> {"Enable-Export-Dashboard-Items-Tooltip",""},
        new List<string> {"Reporting-Page-Limit-Tooltip",""},
        //new List<string> {"Dashboard-Cache-Timeout-Tooltip",""},
        new List<string> {"Healthcare-Web-Viewer-Session-Timeout-Tooltip","Time (in minutes) before viewer will auto log out. (default: 30)"},
        new List<string> {"Healthcare-Web-Viewer-Data-Source-Tooltip","ODBC data source to use with the Healthcare Web Viewer. This value overrides value for key 'dmsDataSource' above."},
        new List<string> {"Healthcare-Web-Viewer-Enable-HTTP-Data-Source-Tooltip","Set to true to set the data source from the query string. This value overrides datasource and dmsDataSource. (default: false)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Deficiency-Viewing-Tooltip","Set to true to allow deficiency viewing. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Physician-Acknowledgement-Tooltip","Set to true to allow physician acknowledgment. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Document-Correction-Tooltip","Set to true to allow document corrections. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Read-Only-HTML-Forms-Tooltip","Allowed Values are \"all\", \"medical\", or \"none\". Set to All for all HTML Forms read only. Set to Medical for medical document type html forms read only. Set to none for no html forms read only. (default: all)"},
        new List<string> {"Healthcare-Web-Viewer-Read-Only-Unity-Forms-Tooltip","Allowed Values are \"all\", \"medical\", or \"none\". Set to All for all Unity Forms read only. Set to Medical for medical document type unity forms read only. Set to none for no unity forms read only. (default: all)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Tooltip","Set to true to allow the Epic Web Viewer COM integration to interop with Healthcare Web Viewer. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Interoperability-Enabled-Tooltip","Set to true to allow the Epic Hyperdrive client's Scan Viewer integration to interop with Healthcare Web Viewer. (default: false)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Failed-Timeout-Tooltip","Time (in seconds) to wait for the document to load before sending the DisplayDocument message to Epic. (default: 10)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Message-Interval-Tooltip","Time (in seconds) to wait for Epic to send a response upon sending the DisplayDocument message. (default: 1)"},
        new List<string> {"Session-Timeout-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Samesite-Cookie-Policy-Tooltip","The Web Server can use a strict, lax, or none policy for samesite cookies."},
        new List<string> {"Authentication-Mode-Tooltip",""},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-KB-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Seconds-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"Default-DocPop-Username-Tooltip","Default DocPop User Name"},
        new List<string> {"Default-DocPop-Password-Tooltip","Default DocPop Password"},
        new List<string> {"DocPop-Data-Source-Tooltip","ODBC data source to use with DocPop"},
        new List<string> {"Default-DocPop-Domain-Name-Tooltip","DocPop domain name (used with NT Authentication)"},
        new List<string> {"Default-DocPop-Institution-Tooltip","DocPop institution"},
        new List<string> {"Embedded-DocPop-Tooltip","Set to true when embedding DocPop in an Frame or IFrame."},
        new List<string> {"DocPop-Default-Login-Tooltip","Uses the web.config user name and password for DocPop login"},
        new List<string> {"DocPop-HTTP-Login-Tooltip","Get DocPop login credentials from the query string."},
        new List<string> {"DocPop-Auto-Login-Tooltip","Enables/disables DocPop auto login."},
        new List<string> {"DocPop-HTTP-Data-Source-Tooltip","Gets the DocPop data source from the query string."},
        new List<string> {"DocPop-Validate-Against-Checksum-Tooltip","Validate DocPop URLs against a checksum value."},
        new List<string> {"DocPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"DocPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"DocPop-Auto-Display-One-Document-Tooltip","If the search result contains a single document, only display the viewer and hide the select list."},
        new List<string> {"Disable-Context-Menus-in-DocPop-Tooltip","Set to true to disable context menus on Document Select and Viewer in DocPop."},
        new List<string> {"Encrypt-DocPop-Tooltip","Encrypt DocPop keys for enhanced security."},
        new List<string> {"Default-PdfPop-Username-Tooltip","Default PdfPop User Name"},
        new List<string> {"Default-PdfPop-Password-Tooltip","Default PdfPop Password"},
        new List<string> {"PdfPop-Data-Source-Tooltip","ODBC data source to use with PdfPop"},
        new List<string> {"Default-PdfPop-Domain-Name-Tooltip","PdfPop domain name (used with NT Authentication)"},
        new List<string> {"Default-PdfPop-Institution-Tooltip","PdfPop institution"},
        new List<string> {"Embedded-PdfPop-Tooltip","Set to true when embedding PdfPop in an Frame or IFrame."},
        new List<string> {"PdfPop-Default-Login-Tooltip","Uses the web.config user name and password for PdfPop login"},
        new List<string> {"PdfPop-HTTP-Login-Tooltip","Get PdfPop login credentials from the query string."},
        new List<string> {"PdfPop-Auto-Login-Tooltip","Enables/disables PdfPop auto login."},
        new List<string> {"PdfPop-HTTP-Data-Source-Tooltip","Gets the PdfPop data source from the query string."},
        new List<string> {"PdfPop-Validate-Against-Checksum-Tooltip","Validate PdfPop URLs against a checksum value."},
        new List<string> {"PdfPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"PdfPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"PdfPop-Auto-Display-One-Document-Tooltip","If the search result contains a single document, only display the viewer and hide the select list."},
        new List<string> {"Encrypt-PdfPop-Tooltip","Encrypt PdfPop keys for enhanced security."},
        new List<string> {"Default-FormPop-Username-Tooltip","Default FormPop User Name"},
        new List<string> {"Default-FormPop-Password-Tooltip","Default FormPop Password"},
        new List<string> {"FormPop-Data-Source-Tooltip","ODBC data source to use with FormPop"},
        new List<string> {"Default-FormPop-Domain-Name-Tooltip","FormPop domain name (used with NT Authentication)"},
        new List<string> {"Default-FormPop-Institution-Tooltip","FormPop institution"},
        new List<string> {"Embedded-FormPop-Tooltip","Set to true when embedding FormPop in an Frame or IFrame."},
        new List<string> {"FormPop-Default-Login-Tooltip","Uses the web.config user name and password for FormPop login"},
        new List<string> {"FormPop-HTTP-Login-Tooltip","Get FormPop login credentials from the query string."},
        new List<string> {"FormPop-Auto-Login-Tooltip","Enables/disables FormPop auto login."},
        new List<string> {"FormPop-HTTP-Data-Source-Tooltip","Gets the FormPop data source from the query string."},
        new List<string> {"FormPop-Validate-Against-Checksum-Tooltip","Validate FormPop URLs against a checksum value."},
        new List<string> {"FormPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"FormPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"FormPop-Auto-Display-One-Document-Tooltip","If the search result contains a single document, only display the viewer and hide the select list."},
        new List<string> {"Encrypt-FormPop-Tooltip","Encrypt FormPop keys for enhanced security."},
        new List<string> {"Default-FolderPop-Username-Tooltip","Default FolderPop User Name"},
        new List<string> {"Default-FolderPop-Password-Tooltip","Default FolderPop Password"},
        new List<string> {"FolderPop-Data-Source-Tooltip","ODBC data source to use with FolderPop"},
        new List<string> {"Default-FolderPop-Domain-Name-Tooltip","FolderPop domain name (used with NT Authentication)"},
        new List<string> {"Default-FolderPop-Institution-Tooltip","FolderPop institution"},
        new List<string> {"Embedded-FolderPop-Tooltip","Set to true when embedding FolderPop in an Frame or IFrame."},
        new List<string> {"FolderPop-Default-Login-Tooltip","Uses the web.config user name and password for FolderPop login"},
        new List<string> {"FolderPop-HTTP-Login-Tooltip","Get FolderPop login credentials from the query string."},
        new List<string> {"FolderPop-Auto-Login-Tooltip","Enables/disables FolderPop auto login."},
        new List<string> {"FolderPop-HTTP-Data-Source-Tooltip","Gets the FolderPop data source from the query string."},
        new List<string> {"FolderPop-Validate-Against-Checksum-Tooltip","Validate FolderPop URLs against a checksum value."},
        new List<string> {"FolderPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"FolderPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"Encrypt-FolderPop-Tooltip","Encrypt FolderPop keys for enhanced security."},
        new List<string> {"PacketPop-Data-Source-Tooltip","ODBC data source to use with PacketPop."},
        new List<string> {"PacketPop-Validate-Against-Checksum-Tooltip","Validate PacketPop URLs against a checksum value."},
        new List<string> {"PacketPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"LoginFormProc-Username-Tooltip","User name used for creating forms."},
        new List<string> {"LoginFormProc-Password-Tooltip","Password used for creating forms."},
        new List<string> {"LoginFormProc-Data-Source-Tooltip","ODBC data source name used when creating forms."},
        new List<string> {"LoginFormProc-Prompt-For-New-Form-Tooltip","Prompts the user to complete another form."},
        new List<string> {"Encrypt-LoginFormProc-Tooltip","Encrypt Login Form Proc keys for enhanced security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"},
        new List<string> {"ADFS-Enabled-Tooltip",""},
        new List<string> {"Synchronize-User-Attributes-Tooltip",""},
        new List<string> {"Authentication-Only-Tooltip",""},
        new List<string> {"Cookie-Handler-Require-SSL-Tooltip",""},
        new List<string> {"Trusted-Issuer-Name-Tooltip",""},
        new List<string> {"wsFederation-Issuer-Tooltip","The URI of the token issuer. Also referred to as security token service (STS)."},
        new List<string> {"wsFederation-Realm-Tooltip","The URI of the requesting realm (Relying Party), which identifies the relying party (RP) to the security token service (STS)."},
        new List<string> {"Certificate-X509-Find-Type-Tooltip","Specifies the type of X.509 search to be executed."},
        new List<string> {"Certificate-Find-Value-Tooltip","Specifies the value to search for in the X.509 certificate store."},
        new List<string> {"Certificate-Store-Location-Tooltip","A StoreLocation value that specifies the location of the X.509 certificate store. The default value is \"LocalMachine\"."},
        new List<string> {"Certificate-Store-Name-Tooltip","The name of the X.509 certificate store. The default is \"My\"."},
        new List<string> {"Application-Script-Location-Tooltip",""},
        new List<string> {"Application-Keyword-ID-Tooltip",""},
        new List<string> {"Application-Keyword-Validator-Tooltip",""},
        new List<string> {"Page-Location-Tooltip",""},
        new List<string> {"Page-Script-Location-Tooltip",""},
        new List<string> {"Page-Keyword-ID-Tooltip",""},
        new List<string> {"Page-Keyword-Validator-Tooltip",""},
        new List<string> {"Enable-Healthcare-Web-Viewer-Tooltip",""},
        new List<string> {"KeywordTypeahead-KeywordIDNumber-Tooltip","The unique Keyword Type ID# for the keyword that you are wanting to target."},
        new List<string> {"KeywordTypeahead-TypeaheadCharacterCount-Tooltip","The minimum number of characters that will need to be typed in before the drop down field will start showing potential matches."},
        new List<string> {"NavPanel-ContextEnabled-Tooltip",""},
        new List<string> {"NavPanel-Icon-Tooltip",""},
        new List<string> {"NavPanel-DisplayOrder-Tooltip",""},
        new List<string> {"NavPanel-DisplayName-Tooltip",""},
        new List<string> {"NavPanel-Name-Tooltip",""}
    };

    /* 231 Tooltip Objects */
    private readonly List<List<string>> AgendaOnline231Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stream-Chunk-Size-Tooltip",""},
        new List<string> {"Player-Source-File-Path-Tooltip","Path to directory where the media player resides."},
        new List<string> {"Player-Version-Tooltip","Version key of the media player."},
        new List<string> {"Min-Pool-Size-Tooltip","Minimum Pool Size"},
        new List<string> {"Max-Pool-Size-Tooltip","Maximum Pool Size"},
        new List<string> {"webpages-Enabled-Tooltip",""},
        new List<string> {"Google-Analytics-Tooltip",""},
        new List<string> {"Session-Username-Tooltip","The OnBase user name for authentication."},
        new List<string> {"Session-Password-Tooltip","The OnBase password for authentication."},
        new List<string> {"Data-Source-Tooltip","The ODBC datasource utilized by the Application Server."},
        new List<string> {"Encrypt-Agenda-Online-Access-Tooltip", "Encrypt Agenda Public Access keys for enhanced security." }
    };

    private readonly List<List<string>> ApplicationServer231Tooltips = new List<List<string>>
    {
        new List<string> {"Server-Designation-Tooltip","(Optional) Enter a value to designate which server the user is connecting to, which will display in Web Diagnostics. This is helpful in a load balanced environment."},
        new List<string> {"Data-Source-Tooltip","The ODBC datasource utilized by the Application Server."},
        new List<string> {"Use-OS-Authentication-Tooltip","Set to true if the connection to the database should be made with OS Authentication instead of SQL Authentication. This requires an OS/domain user with access to the database to be configured as the user for this Application Server."},
        new List<string> {"Document-Query-Warning-Threshold-Tooltip","Display a warning message if the number of documents returned from a query exceeds this value. If Document Query Warning Threshold is greater than Document Query Limit, no warning message will be displayed."},
        new List<string> {"Document-Query-Limit-Tooltip","Document queries are limited when the number of returned documents exceeds this value."},
        new List<string> {"Item-Cache-Timeout-Tooltip","The number of seconds an item will exist within the item cache before it will be expired."},
        new List<string> {"Raw-Images-Tooltip","Images are sent directly to the viewer from the database instead of first being processed by ASP.NET on the server."},
        new List<string> {"Use-Isolated-Image-Process-Tooltip","Setting for initializing the out of process image rendering service."},
        new List<string> {"Compression-Quality-Tooltip","Controls the compression quality of color images and can be used to reduce memory usage when viewed. The default setting is 80 (measured in percent)."},
        new List<string> {"Enable-Isolated-Chromium-Process-Tooltip","Setting for initializing the Chromium Image service used by Unity Forms."},
        new List<string> {"Form-Save-To-TIFF-Timeout-Tooltip","Timeout in seconds for sending a Form to a TIFF file using the process image rendering service."},
        new List<string> {"Print-Image-Form-Via-PDF-Tooltip","Configuration to print image form via PDF. \"TRUE\" means printing via PDF else \"FALSE\" means printing via screenshot."},
        new List<string> {"TPCF-Worker-Location-Override-Tooltip","Specify a custom path for TPCF Worker directory"},
        new List<string> {"Default-Storage-Path-Tooltip","Default storage path for the File Monitoring Engine."},
        new List<string> {"Watch-Folder-Tooltip","The folder to monitor in Front Office Scanning."},
        new List<string> {"Site-ID-Keyword-Type-Tooltip","Site ID Keyword Type"},
        new List<string> {"Cleanup-Timer-Interval-Tooltip","Sets the time span (in seconds) after which the file monitoring system looks for changes."},
        new List<string> {"Max-File-Age-Tooltip","Maximum file age (in hours)."},
        new List<string> {"Integrations-EIS-Validate-Message-Schema-Tooltip","Set to true to perform validation on the Message Schema."},
        new List<string> {"Integrations-EIS-Continue-On-Validation-Error-Tooltip","Set to true to log an error and continue when Message Schema validation fails."},
        new List<string> {"Integrations-EIS-Data-Set-Cache-Cleanup-Interval-Tooltip","Data Set Cache Cleanup Interval (Minutes)."},
        new List<string> {"Integrations-EIS-AppNet-Directory-Tooltip","The location of the virtual directory where the Web Server resides. This setting is needed to generate DocPop URLs."},
        new List<string> {"Message-Broker-Monitor-Start-Delay-Tooltip","Delay in minutes to start the timer used by the Message Broker to monitor for message issues and completed messages needing archiving."},
        new List<string> {"GCS-Username-Tooltip","User Name to connect to GCS. Can be in plain text or use ASPNET_SETREG.exe to encrypt. For example: \"registry:HKLM\\SOFTWARE\\Hyland\\GCS\\UsageBasedBilling\\identity\\ASPNET_SETREG,userName\""},
        new List<string> {"GCS-Password-Tooltip","Password to connect to GCS. Can be in plain text or use ASPNET_SETREG.exe to encrypt. For example: \"registry:HKLM\\SOFTWARE\\Hyland\\GCS\\UsageBasedBilling\\identity\\ASPNET_SETREG,password\""},
        new List<string> {"Use-Legacy-Key-For-Usage-Based-Billing-Tooltip",""},
        new List<string> {"GCS-Phone-Home-Interval-Tooltip","Time interval (in minutes) to perform phone home to GCS server."},
        new List<string> {"Data-Capture-Server-WCF-Endpoint-Address-Tooltip","Data Capture Server WCF Endpoint Address"},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"OWIN-Application-Server-Origin-Tooltip","The application server origin used to create absolute links. In a load-balanced environment, hostname would be the load-balancer. Example: https://hostname/AppServer"},
        new List<string> {"OWIN-Automatic-App-Startup-Tooltip","Automatic App Startup"},
        new List<string> {"OWIN-App-Startup-Tooltip","Location of the OWIN startup class"},
        new List<string> {"Identity-Model-Server-URI-Tooltip",""},
        new List<string> {"Mobile-Apps-Path-Tooltip","Mobile Apps Path"},
        new List<string> {"CORS-Policy-Tooltip","CORS Policy"},
        new List<string> {"WorkView-Mobile-Endpoint-Tooltip","Check this box to enable this application as a WorkView Mobile Endpoint."},
        new List<string> {"Responsive-Apps-Endpoint-Tooltip","Check this box to enable this application as a Responsive Apps Endpoint."},
        new List<string> {"WOPI-Endpoint-Tooltip","Endpoint setting for Office Online Server"},
        new List<string> {"Sesame-Endpoint-Tooltip","Check this box to enable this application as a Sesame Endpoint."},
        new List<string> {"Governance-Rules-As-A-Service-Endpoint-Tooltip","Check this box to enable this application as a Governance Rules As A Service (GRAAS Endpoint."},
        new List<string> {"Web-BLOB-Passthrough-FHIR-Endpoint-Tooltip","Check this box to enable this application as a Web BLOB Passthrough (WBPT) FHIR Endpoint."},
        new List<string> {"SMART-On-FHIR-Application-ID-Tooltip",""},
        new List<string> {"PPL-Endpoint-Enabled-Tooltip","Check this box to enable this application as a PPL Endpoint."},
        new List<string> {"Forms-Endpoint-Tooltip","Check this box to enable this application as a Forms Endpoint."},
        new List<string> {"PPL-DocPop-URL-Tooltip","This is the URL for viewing Unity Forms in Patient Portal Link. Do not add a trailing slash."},
        new List<string> {"Statement-Composition-Cache-Limit-Tooltip","Maximum number of cached statement composition documents."},
        new List<string> {"Unity-Forms-Toggle-Max-Form-Width-Tooltip","Changes the Unity forms rendering behavior when form elements exceed the width of the form.<br>Set this to \"true\" to prevent the form from expanding to match the width of the largest element."},
        new List<string> {"owin:oia:msgItemTypeId-Tooltip",""},
        new List<string> {"owin:oia:lifeCycleId-Tooltip",""},
        new List<string> {"owin:oia:tmpFilePath-Tooltip",""},
        new List<string> {"owin:oia:tmpFileAgeInMs-Tooltip",""},
        new List<string> {"owin:oia:cleanupIntervalInMs-Tooltip",""},
        new List<string> {"Use-OnBase-Full-Text-Tooltip",""},
        new List<string> {"Content-Composer-IdP-Path-Tooltip",""},
        new List<string> {"Keyword-Data-Cache-Timeout-Tooltip","Timeout in minutes used to determine how long keyword metadata is stored in memory. WARNING, increasing this value over the default of 20 minutes will increase memory consumption on the application server. Lowering this value can result in undesirable behavior."},
        new List<string> {"Allow-Insecure-External-XSL-Tooltip",""},
        new List<string> {"Max-Query-Execution-Parallelism-Tooltip",""},
        new List<string> {"Folder-Fetch-Batch-Size-Tooltip",""},
        new List<string> {"Database-Command-TimeOut-Tooltip","Sharebase folder Database Command Time Out in Seconds."},
        new List<string> {"Doc-Linker-SMART-On-FHIR-Application-ID-Tooltip","DocLinkerSMARTonFHIRApplicationId is only used with the Epic LaunchLinkDocumentsActivities API."},
        new List<string> {"Use-New-Keyword-Data-Cache-Implementation-Tooltip","Feature Flag setting for selecting the implementation of the Keyword Data Cache."},
        new List<string> {"Configuration-Import-Database-Timeout-Tooltip","Set the default timeout in seconds for Import actions. Values below 120 will be ignored."},
        new List<string> {"PIM:HyRCS:ExternalBaseUri-Tooltip","Set an external URI for HyRCS instead of using the out of process localhost instance."},
        new List<string> {"PIM:HyRCS:Port-Tooltip","Set a custom port for HyRCS. This will ONLY be applied if using the out of process localhost instance. For an external instance, specify the port in the PIM:HyRCS:ExternalBaseUri value."},
        new List<string> {"PIM:ImageProcess-Tooltip","SET TO REPLACE 'UseIsolatedImageProcess' - Setting for initializing the out of process image rendering service."},
        new List<string> {"PIM:ChromiumProcess-Tooltip","SET TO REPLACE 'EnableIsolatedChromiumProcess' - Setting for initializing the Chromium Image service used by Unity Forms."},
        new List<string> {"HyRCS:PageCountLimit-Tooltip","Set the page count limit for HyRCS"},
        new List<string> {"Responsive-Apps-WorkView-API-URL-Tooltip","WorkViewApi is the path to the WorkView web api facet. Example: \"https://hostname/AppServer/private/workview/api/\""},
        new List<string> {"Responsive-Apps-WorkView-Files-URL-Tooltip","WorkViewFiles is the path to the WorkView static file server facet. Example: \"https://hostname/AppServer/private/workview/files/\""},
        new List<string> {"Responsive-Apps-API-URL-Tooltip","ResponsiveAppsApi is the path to the Responsive Apps web api facet. Example: \"https://hostname/AppServer/private/responsive-apps/api/\""},
        new List<string> {"Identity-Provider-URL-Tooltip","IdentityProvider is the path to the Identity Provider including tenant and user population. Example: \"https://hostname/idp/workview/mobile/\""},
        new List<string> {"Core-Access-Token-Lifetime-Tooltip","CoreAccessTokenLifetime is the property that is used for configuring the default length (in seconds) that a ReAuth token is good for when accessed through resonsive-apps."},
        new List<string> {"File-IO-Detail-Tooltip",""},
        new List<string> {"Foreign-Storage-EMC-Threshold-Tooltip","Setting for Centera inline blobs in KB.  Default is 75."},
        new List<string> {"Foreign-Storage-PM-Cache-Location-Tooltip","Path to cache location."},
        new List<string> {"Foreign-Storage-PM-Cache-Timeout-Tooltip","Timeout in minutes.  Default is 60 minutes."},
        new List<string> {"Foreign-Storage-PM-Cache-Size-Tooltip","Cache size in MB.  Default is 500."},
        new List<string> {"PM-File-Access-Level-Tooltip","0 or empty for Default, 1 to Always use UNC, 2 to Never to UNC."},
        new List<string> {"Temp-File-Expiration-Threshold-Time-Tooltip","The minimum amount of time a temporary file should exist without being accessed before it expires. Default is 00:05:00 (five minutes)."},
        new List<string> {"Hyland-Services-AppPool-Minimum-Sessions-Tooltip","This parameter dictates the minimum number of OnBase sessions available in the session pool. (default 0)"},
        new List<string> {"Hyland-Services-AppPool-Maximum-Sessions-Tooltip","This parameter dictates the maximum number of OnBase sessions available in the session pool.  Requests from the pool that exceed this value will block until another session is placed back into the pool. (default 10)"},
        new List<string> {"Use-Query-Context-Tooltip","This parameter indicates if query context security will be used during the course of retrieval. Query context means that a document must be retrieved through a document query before the document itself is accessible via another call. If this parameter is omitted, the default is true. Note: this value should be set to false when being used for disconnected web services. (default false)"},
        new List<string> {"Filter-Exceptions-Tooltip","This parameter indicates if the application server should not send detailed information about exception. For example, the exact stack trace of the exception will be filtered. This reduces the amount of information revealed to a malicious attacker when the server is attacked. The information is still available via Diagnostics Console and Diagnostics Server for an authorized user. (default true)"},
        new List<string> {"Endpoint-Use-Remoting-Tooltip",""},
        new List<string> {"Session-Enable-Timeout-Tooltip","Controls the timeout behavior for unused sessions. If enableTimeout is set to true the AppServer will timeout unused sessions and disconnect them. The timeout period is based on the ASP.NET session timeout found in the system.web\\session section with a minimum of 10 minutes. (default false)"},
        new List<string> {"Application-Server-Callback-URL-Tooltip",""},
        new List<string> {"Web-Server-Base-URL-Tooltip",""},
        new List<string> {"Request-Validation-Minimum-Version-Tooltip",""},
        new List<string> {"Login-ID-Tooltip",""},
        new List<string> {"Login-Password-Tooltip",""},
        new List<string> {"Login-Datasource-Tooltip",""},
        new List<string> {"Pool-Min-Tooltip",""},
        new List<string> {"Pool-Max-Tooltip",""},
        new List<string> {"Search-Timeout-Tooltip","The length of time (in seconds) before the search will timeout."},
        new List<string> {"Enable-Search-Log-Tooltip","Enables Full Text search logs in the specified path(<SearchLog enableSearchlog=\"true\" path=\"<HostName>/SearchLogs\"/>). Path should have full access rights for 'Everyone'."},
        new List<string> {"Search-Log-Path-Tooltip",""},
        new List<string> {"Unity-Editable-Filter-Max-Rows-Tooltip","Sets Max results for Unity client editable embedded filters (Default: 250, Max: 2000)."},
        new List<string> {"ERP-Date-Format-LOB-Broker-Tooltip","Sets the ERP date format for processing results for LOB Broker classes."},
        new List<string> {"Formatted-Text-Iframe-Supported-Domains-Tooltip","Adds additional domains that should be supported by iframes in the formatted text attribute control. Adding a domain to this list will add `allow-scripts`, `allow-same-origin`, and `allow-forms` overrides to the sandbox attribute on the iframe. Add domains as a comma separated list.<br><br>Examples:<br>&nbsp;&nbsp;&nbsp;&nbsp;*.mydomain.com<br>&nbsp;&nbsp;&nbsp;&nbsp;sub.myotherdomain.com<br><br>In this example *.mydomain.com will enable all sub-domains for mydomain.com (Ex: www.mydomain.com and test.mydomain.com would be valid), sub.myotherdomain.com would only allow sandbox overrides for that specific domain and sub-domain."},
        new List<string> {"Use-Office-Online-Server-Tooltip","Set to true to use the WOPI viewer. Set to false to continue using the legacy viewer."},
        new List<string> {"Office-Online-Server-URI-Tooltip","Points to the Office Online Server."},
        new List<string> {"Office-Online-Server-Proxy-Base-Tooltip","Points to the WOPI Service. Example: \"https://localhost/AppServer/private\""},
        new List<string> {"Vendor-Cache-Search-Minimum-Characters-Tooltip",""},
        new List<string> {"Vendor-Master-Keyed-Lookup-Op-Tooltip",""},
        new List<string> {"Vendor-Master-Lookup-Sequence-Tooltip",""},
        new List<string> {"Vendor-Master-Lookup-Return-Multiple-Tooltip",""},
        new List<string> {"Vendor-Cache-AutoComplete-Result-Max-Tooltip",""},
        new List<string> {"Enable-LOB-Broker-Accounts-Payable-Tooltip",""},
        new List<string> {"Http-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"Http-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Session-Timeout-Length-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"Content-Composer-Client-ID-Tooltip","Client ID provided by the Hyland Identity Provider (IdP)."},
        new List<string> {"Content-Composer-Client-Secret-Tooltip","Client secret provided by the Hyland Identity Provider (IdP)."},
        new List<string> {"Content-Composer-Username-Tooltip","Hyland IdP user with Content Composer access."},
        new List<string> {"Content-Composer-Password-Tooltip","Password for Hyland IdP user with Content Composer access."},
        new List<string> {"Encrypt-Content-Composer-Settings-Tooltip","Checking this will encrypt the Content Composer section in configuration."},
        new List<string> {"Pop-Integrations-Validate-Against-Checksum-Tooltip","Validate a Pop URL with the checksum value."},
        new List<string> {"Pop-Integrations-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"Pop-Integrations-Enable-Legacy-Checksum-Creation-Tooltip","Creates checksums using the legacy checksum validation."},
        new List<string> {"Pop-Integrations-Encrypt-Configuration-Tooltip","Encrypt configuration information for improved security."},
        new List<string> {"Integrations-Media-URL-Tooltip","URL to the OnBase Cloud"},
        new List<string> {"Integrations-Media-Datasource-Tooltip","Customer Datasource"},
        new List<string> {"Integrations-Media-Username-Tooltip","Customer username to OnBase Cloud"},
        new List<string> {"Integrations-Media-Password-Tooltip","Customer password to OnBase Cloud"},
        new List<string> {"Integrations-Media-Encrypt-OnBase-Cloud-Settings-Tooltip","When checked, url, datasource, username and password will be encrypted."},
        new List<string> {"EAC-Username-Tooltip","The OnBase User (usually a service account) that the Application Server uses to process EAC logon requests."},
        new List<string> {"EAC-Password-Tooltip","The password to the account handling EAC logons."},
        new List<string> {"EAC-UserLevel-Minimum-Pool-Size-Tooltip","The minimum number of OnBase user sessions maintained for this pool while the EAC Application Server is running."},
        new List<string> {"EAC-UserLevel-Maximum-Pool-Size-Tooltip","The maximum number of OnBase user sessions maintained for this pool while the EAC Application Server is running.  If the number of concurrent users accessing this pool is greater than this number, user requests will be queued."},
        new List<string> {"Encrypt-EAC-Tooltip","Encrypt EAC configuration settings for enhanced security."},
        new List<string> {"Authentication-Mode-Tooltip","This section sets the authentication policies of the application. Possible modes are \"Windows\" and \"None\".<br><br>\"None\" - No authentication is performed.<br>\"Windows\" - IIS performs authentication (Basic, Digest, or Integrated Windows) according to its settings for the application. Anonymous access must be disabled in IIS."},
        new List<string> {"ADFS-Enabled-Tooltip","This checkbox indicates whether the ADFS node is set to enabled."},
        new List<string> {"Request-Validation-Mode-Tooltip","The Request Validation Mode must be set to 2.0 for ADFS."},
        new List<string> {"Synchronize-User-Attributes-Tooltip",""},
        new List<string> {"Authentication-Only-Tooltip",""},
        new List<string> {"Cookie-Handler-Require-SSL-Tooltip","Configures the CookieHandler that the SessionAuthenticationModule (SAM) uses to read and write cookies."},
        new List<string> {"Audience-URI-Tooltip","Audience URI. As configured on the Endpoints tab of the Relying Party Trust. Requires trailing slash."},
        new List<string> {"Trusted-Issuer-Thumbprint-Tooltip","The issuer of the certificate used to validate the signature on responses from ADFS."},
        new List<string> {"Trusted-Issuer-Name-Tooltip",""},
        new List<string> {"wsFederation-Issuer-Tooltip","The URI of the token issuer. Also referred to as security token service (STS)."},
        new List<string> {"wsFederation-Realm-Tooltip","The URI of the requesting realm (Relying Party), which identifies the relying party (RP) to the security token service (STS)."},
        new List<string> {"Certificate-X509-Find-Type-Tooltip","Specifies the type of X.509 search to be executed."},
        new List<string> {"Certificate-Find-Value-Tooltip","Specifies the value to search for in the X.509 certificate store."},
        new List<string> {"Certificate-Store-Location-Tooltip","A StoreLocation value that specifies the location of the X.509 certificate store. The default value is \"LocalMachine\"."},
        new List<string> {"Certificate-Store-Name-Tooltip","The name of the X.509 certificate store. The default is \"My\"."},
        new List<string> {"Hyland-Idp-Url-Tooltip",""},
        new List<string> {"Hyland-IdP-Audience-URL-Tooltip",""},
        new List<string> {"Hyland-IdP-Name-Claim-Type-Tooltip",""},
        new List<string> {"Hyland-IdP-Api-Name-Tooltip",""},
        new List<string> {"Hyland-IdP-Api-Secret-Tooltip",""},
        new List<string> {"Alias-Old-Name-Tooltip",""},
        new List<string> {"Alias-New-Name-Tooltip",""},
        new List<string> {"Alias-Type-Tooltip",""},
        new List<string> {"SessionAdministration-User-Tooltip",""},
        new List<string> {"SessionAdministration-Role-Tooltip",""},
        new List<string> {"Trust-Mode-Tooltip",""},
        new List<string> {"Store-Location-Tooltip",""},
        new List<string> {"Store-Name-Tooltip",""},
        new List<string> {"Find-Type-Tooltip",""},
        new List<string> {"Find-Value-Tooltip",""},
        new List<string> {"Description-Tooltip",""},
        new List<string> {"App-Name-Tooltip",""},
        new List<string> {"App-Icon-URL-Tooltip",""},
        new List<string> {"App-URL-Tooltip",""}
    };

    private readonly List<List<string>> ElectronicPlanReview231Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stylesheet-Directory-Location-Tooltip","The directory containing files that add a specific look and feel to the site. Default location is BasicBlue."},
        new List<string> {"Allow-Sign-On-Tooltip","Allows users to sign on for access to create plan projects."},
        new List<string> {"Allow-Sign-Off-Tooltip","Allows users to sign off."},
        new List<string> {"Default-User-Time-Zone-Tooltip","Provides a way to set the initial time zone."},
        new List<string> {"Search-Start-Year-Tooltip","For Users searching plan project history, the Yearly search option list limits the list with this item."},
        new List<string> {"Items-Per-Page-Tooltip","The number of items to display on a project list or paged list of documents."},
        new List<string> {"Max-Lookup-Results-Tooltip",""},
        new List<string> {"Reset-Password-Link-Lifetime-Tooltip","Controls how long a reset link remains active, before it will not be allowed to reset a password. This is specified in minutes."},
        new List<string> {"File-Upload-Directory-Tooltip","The directory that stages plan documents while they are received from the client before forwarding them onto app server."},
        new List<string> {"File-Upload-Validator-Tooltip","File Upload Validator Format: Assembly Path,Class Name,Method Name."},
        new List<string> {"Token-Authentication-Tooltip",""},
        new List<string> {"Allow-Single-Sign-On-Tooltip","Enables the use of SSO.  This enables a user to login to a single system and automatically login to the plan review site."},
        new List<string> {"Source-ID-Tooltip","Source ID"},
        new List<string> {"Resolution-Mode-Tooltip","Resolution Mode"},
        new List<string> {"Public-CAPTCHA-Key-Tooltip","Public CAPTCHA API key provided by 3rd party CAPTCHA service."},
        new List<string> {"Private-CAPTCHA-Key-Tooltip","Private CAPTCHA API key provided by 3rd party CAPTCHA service."},
        new List<string> {"Password-Strength-Pattern-Tooltip","The password strength regular expression determines the minimum character length and characters/symbols that a password must contain in order to be a valid password."},
        new List<string> {"Password-Strength-Message-Tooltip","An optional password strength message that is displayed when the password requested during registration does not meet the required strength."},
        new List<string> {"Username-Validation-Pattern-Tooltip",""},
        new List<string> {"Discipline-Items-Per-Menu-Tooltip","Number of discipline items displayed in menu in the Plan review web client."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"EPR-Username-Tooltip","The OnBase user that Application Server uses to process Plan Review requests."},
        new List<string> {"EPR-Password-Tooltip","The OnBase user password that Application Server uses to process Plan Review requests."},
        new List<string> {"Data-Source-Tooltip","The OnBase Data Source that Application Server uses to process Plan Review Requests."},
        new List<string> {"Encrypt-Electronic-Plan-Review-Tooltip", "Determines whether or not the user name and password will be encrypted in the web.config file."}
    };

    private readonly List<List<string>> GatewayCachingServer231Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Allow-NT-Authentication-On-Forwarding-Tooltip","If enabled, allows the web server to forward NT credentials to the Application Server. Only turn this flag on when using NT authentication."},
        new List<string> {"Optimized-Service-Pipeline-Tooltip",""},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Gateway-Name-Tooltip","Name of the Gateway Caching Server configured in Gateway Caching Server Configuration."},
        new List<string> {"DataSource-Tooltip","The OnBase database this ASG is connecting to on the Application Server."},
        new List<string> {"Cache-Path-Tooltip","This is the local disk path for the ASG cache. This should not be a UNC path."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"GWCS-Username-Tooltip","Service Account that connects ASG to the Application Server. This user retrieves the documents that cache automatically."},
        new List<string> {"GWCS-Password-Tooltip","Password for the Service Account."},
        new List<string> {"Encrypt-Login-Settings-Tooltip", "Encrypt ASG settings for enhanced security." }
    };

    private readonly List<List<string>> HealthcareFormManager231Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Allow-View-Source-Tooltip","Enables/disables view source."},
        new List<string> {"Enable-Session-Expiration-Tooltip","The end user will be logged out when no activity is detected."},
        new List<string> {"Prompt-On-Session-Expire-Tooltip","Prompts the user with a warning 30 seconds before the session expires."},
        new List<string> {"Web-Theme-Tooltip",""},
        new List<string> {"Default-Username-Tooltip","Default User Name."},
        new List<string> {"Default-Password-Tooltip","Default Password."},
        new List<string> {"Default-Login-Tooltip","Uses the web.config user name and password for Healthcare FormPop login."},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using the default user name and password."},
        new List<string> {"Force-OnBase-Authentication-Tooltip","Ignores database domain authentication settings and uses OnBase authentication instead."},
        new List<string> {"Web-Client-Type-Tooltip","Determines which type of Web Client to use.<br>activex - This will enable the ActiveX web client.<br>html - This will enable the HTML Only web client.<br>selectable - This will provide users an option upon login to select which client type (ActiveX or HTML Only) to use."},
        new List<string> {"Row-Coloring-Tooltip","Set to true to give every other row a shaded background in the document select list. Set to false to turn off row coloring."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"Prevent-Viewer-Client-Caching-Tooltip","Enable Prevent Viewer Client Caching to direct the HTML Web Client Viewer to not cache page data on the client for a brief period of time. Preventing caching will negatively impact performance. Recommended setting is false."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Session-Timeout-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Samesite-Cookie-Policy-Tooltip","The Web Server can use a strict, lax, or none policy for samesite cookies."},
        new List<string> {"Validate-Against-Checksum-Tooltip","Validate a Pop URL with the checksum value."},
        new List<string> {"Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"Enable-Legacy-Checksum-Fallback-Tooltip","Attempts to use the legacy checksum validation if the most recent validation fails to validate."},
        new List<string> {"Encrypt-Healthcare-Pop-Integration-Configuration-Tooltip","Encrypt configuration information for improved security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"}
    };

    private readonly List<List<string>> PatientWindow231Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Allow-View-Source-Tooltip","Enables/disables view source."},
        new List<string> {"Enable-Session-Expiration-Tooltip","The end user will be logged out when no activity is detected."},
        new List<string> {"Prompt-On-Session-Expire-Tooltip","Prompts the user with a warning 30 seconds before the session expires."},
        new List<string> {"Web-Theme-Tooltip",""},
        new List<string> {"Default-Username-Tooltip","Default User Name"},
        new List<string> {"Default-Password-Tooltip","Default Password"},
        new List<string> {"Enable-Default-Login-Tooltip",""},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using the default user name and password."},
        new List<string> {"Force-OnBase-Authentication-Tooltip","Ignores database domain authentication settings and uses OnBase authentication instead."},
        new List<string> {"Enable-Split-View-Tooltip",""},
        new List<string> {"Enable-Patient-Search-Tooltip",""},
        new List<string> {"Enable-Patient-Context-Syncing-Tooltip",""},
        new List<string> {"Enable-Timestamp-Tooltip",""},
        new List<string> {"Timestamp-Time-Limit-Tooltip",""},
        new List<string> {"Enable-Workstation-Name-DNS-Lookup-Tooltip",""},
        new List<string> {"Allow-Caching-Tooltip","Specifies whether caching should be enabled."},
        new List<string> {"Maximum-Width-Tooltip","Maximum width, in pixels."},
        new List<string> {"Maximum-Height-Tooltip","Maximum height, in pixels."},
        new List<string> {"Preview-Maximum-Width-Tooltip","Maximum width for the preview, in pixels."},
        new List<string> {"Preview-Maximum-Height-Tooltip","Maximum height for the preview, in pixels."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"Prevent-Viewer-Client-Caching-Tooltip",""},
        new List<string> {"HTML-Only-Documents-Print-As-PDFs-Tooltip",""},
        new List<string> {"System-List-Display-Label-Tooltip",""},
        new List<string> {"Personal-List-Display-Label-Tooltip",""},
        new List<string> {"Selected-Tab-Single-Color-Tooltip",""},
        new List<string> {"Enable-EForm-Standard-Printing-Tooltip",""},
        new List<string> {"Federated-Search-With-MPI-Tooltip",""},
        new List<string> {"Hide-Toolbar-Print-Button-Tooltip",""},
        new List<string> {"Auto-Display-Note-Panel-PDF-Office-Tooltip",""},
        new List<string> {"Emergency-Access-Dialog-Title-Tooltip",""},
        new List<string> {"Emergency-Access-Dialog-Message-Tooltip",""},
        new List<string> {"Emergency-Access-Dialog-Other-Reason-Label-Tooltip",""},
        new List<string> {"Show-Emergency-Access-Show-Documents-Checkboxes-Tooltip",""},
        new List<string> {"Show-Other-Reason-In-Emergency-Access-Dialog-Tooltip",""},
        new List<string> {"Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog-Tooltip",""},
        new List<string> {"Enable-Bowser-PDF-Viewer-Tooltip",""},
        new List<string> {"Keyword-Panel-View-Type-Tooltip",""},
        new List<string> {"Workflow-Menu-Tooltip",""},
        new List<string> {"Create-Document-Menu-Tooltip",""},
        new List<string> {"File-Menu-Tooltip",""},
        new List<string> {"Send-To-Print-Queue-Menu-Tooltip",""},
        new List<string> {"Re-Index-Menu-Tooltip",""},
        new List<string> {"ADFS-Enabled-Tooltip",""},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Session-Timeout-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Samesite-Cookie-Policy-Tooltip","The Web Server can use a strict, lax, or none policy for samesite cookies."},
        new List<string> {"JSON-Serialization-Max-Length-Tooltip",""},
        new List<string> {"Validate-Against-Checksum-Tooltip","Validate a Pop URL with the checksum value."},
        new List<string> {"Checksum-Key-Tooltip",""},
        new List<string> {"Enable-Legacy-Checksum-Fallback-Tooltip","Attempts to use the legacy checksum validation if the most recent validation fails to validate."},
        new List<string> {"Encrypt-Healthcare-Pop-Integration-Configuration-Tooltip","Encrypt configuration information for improved security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"}
    };

    private readonly List<List<string>> PublicAccessNextGen231Tooltips = new List<List<string>>
    {
        new List<string> {"Encrypt-Doc-ID-Tooltip","Set to true to encrypt the document ID when displaying search results."},
        new List<string> {"Use-Display-Columns-Tooltip","Set to true to use the configured Custom Query display columns when displaying search results."},
        new List<string> {"Query-Limit-Tooltip","Search results will be limited to this number. Set to 0 for unlimited queries."},
        new List<string> {"Chunk-Size-Tooltip","Chunk size (in bytes) to use when downloading documents."},
        new List<string> {"Viewer-Mode-Tooltip","Set to PDF to convert documents to PDF format and stream to the viewer. Set to Native to download files in their native format. Set to Native Optional to stream files as PDF and provide a link in the viewer to download the file in its native format."},
        new List<string> {"Default-Overlay-Mode-Tooltip","The default overlay mode to render documents in, if applicable. Possible values are Print, View, and Off. Defaults to Print, was used by the past versions of Public Access."},
        new List<string> {"Cache-Path-Tooltip","Cache path"},
        new List<string> {"Expiration-Time-Tooltip","Expiration time (in days)"},
        new List<string> {"Max-Cache-Size-Tooltip","Maximum cache size on disk (GB)."},
        new List<string> {"Size-to-Cache-Tooltip","Documents with a file size equal to or greater than Size to Cache (MB) should be cached."},
        new List<string> {"Size-to-Prompt-Tooltip","Documents with a file size equal to or greater than Size to Prompt (MB) will display the browser's open/save dialog."},
        new List<string> {"Interval-Between-Throttle-Cache-Resets-Tooltip","The amount of time, in minutes, between each iteration of clearing the throttle cache. If a user is blocked from making requests, they will have to wait until this timer expires to make any more requests, or their requests will be denied. Users will only be blocked if they exceed the threshold, and if throttling is enabled. A value of 0 or less disables this behavior."},
        new List<string> {"Amount-of-Requests-During-Each-Throttle-Interval-Tooltip","The amount of requests that can be received before the host from which these requests originate is blocked for an amount of time specified in the throttle reset interval. This is to reduce the potential attack vector of a denial of service attack."},
        new List<string> {"Enable-Local-Browser-Caching-Tooltip","Whether or not to allow browsers to privately and locally cache documents returned from the public access toolkit for a short period of time in order to reduce the amount of repeated requests."},
        new List<string> {"Decorate-Document-Names-Tooltip","Whether or not to show decoration/formatting for document names (i.e. <yellow>). Only works on autonames. Decoration will always be applied to display columns, regardless of this setting."},
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"SOAP-Client-Request-Timeout-Tooltip","Timeout (in seconds) for service requests when using the SOAP client. The HttpRuntime Execution Timeout on the Application Server must be greater than or equal to this value."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"PAVNG-Username-Tooltip","Default User Name"},
        new List<string> {"PAVNG-Password-Tooltip","Default Password"},
        new List<string> {"Data-Source-Tooltip","Default Data Source"},
        new List<string> {"Encrypt-Public-Access-Configuration-Tooltip", "Encrypt Public Access keys for enhanced security."},
        new List<string> {"Query-ID-Tooltip","The ID Number of the query as noted inside of the Configuration Client. A Query ID of * indicates that the keyword is required by all queries."},
        new List<string> {"Keyword-ID-Tooltip","The Keyword ID Number of the keyword as noted inside of the Configuration Client."}
    };

    private readonly List<List<string>> ReportingViewer231Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Optimized-Service-Pipeline-Tooltip","Use the optimized service pipeline for more efficient communication of results."},
        new List<string> {"Request-Timeout-Tooltip","Determines how long the service client should wait for a response from the application server."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"Web-Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Core-Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Server-Designation-Tooltip","(Optional) Enter a value to designate which server the user is connecting to, which will display in the window title. This is helpful in a load balanced environment."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"JSON-Serialization-Max-Length-Tooltip",""},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"OB-Username-Tooltip","This user name along with the associated password will be used to automatically log the user into the Dashboard Web Viewer."},
        new List<string> {"OB-Password-Tooltip","This password along with the associated user name will be used to automatically log the user into the Dashboard Web Viewer."},
        new List<string> {"Dashboard-Theme-Tooltip","Determines the theme that the dashboard uses when it is rendered."},
        new List<string> {"Export-Dashboard-Tooltip","Allows users to export the dashboard as an image or a PDF."},
        new List<string> {"Export-Dashboard-Items-Tooltip","Allows users to export each dashboard item as an image or a PDF."},
        new List<string> {"Allow-HTTP-Parameters-Tooltip","Allows the dashboard viewer to accept dashboard parameters from the HTTP request query string."},
        new List<string> {"Dashboard-Tracing-Info-Level-Tooltip",""},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using NT Authorization or SSO."},
        new List<string> {"Report-Paging-Limit-Tooltip","This option controls the number of records that will be shown per page for a given report.  The minimum value is 50."},
        new List<string> {"Dashboard-Cache-Timeout-Tooltip",""},
        new List<string> {"Encrypt-Dashboard-Viewer-Settings-Tooltip","Encrypt Dashboard Viewer keys for enhanced security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"}
    };

    private readonly List<List<string>> WebServer231Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Allow-NT-Authentication-On-Forwarding-Tooltip","If enabled, allows the web server to forward NT credentials to the Application Server. Only turn this flag on when using NT authentication."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Core-Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Web-Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Server-Designation-Tooltip","(Optional) Enter a value to designate which server the user is connecting to, which will display in the window title. This is helpful in a load balanced environment."},
        new List<string> {"Default-Domain-Name-Tooltip","Default domain name displayed/entered on the login page."},
        new List<string> {"Default-Username-Tooltip","Default User Name"},
        new List<string> {"Default-Password-Tooltip","Default Password"},
        new List<string> {"Default-Institution-Tooltip","Default Institution"},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using the default user name and password."},
        new List<string> {"Force-OnBase-Authentication-Tooltip","Ignores database domain authentication settings and uses OnBase authentication instead."},
        new List<string> {"Custom-SSO-Authentication-Page-Failure-Tooltip","URL of a specific page that the user is redirected to if login fails while using Single Sign On."},
        new List<string> {"Close-On-Logout-Tooltip","If set to true, the window is automatically closed when the user logs out. Otherwise, the user is returned to the login screen."},
        new List<string> {"Logout-Redirect-URL-Tooltip","Redirects the user to a specific page upon logout."},
        new List<string> {"Web-Theme-Tooltip",""},
        new List<string> {"Target-Page-Tooltip",""},
        new List<string> {"Login-Page-Tooltip",""},
        new List<string> {"SharePoint-Viewer-Show-Workflow-Tooltip","Turn on/off the Workflow header bar in SharePoint."},
        new List<string> {"SharePoint-Online-Tooltip","Toggling SharePoint Online changes the authentication scheme used. If set to true, it uses OAuth. If set to false, it uses the provided certificate."},
        new List<string> {"Prompt-User-Queries-Tooltip","Checks to see if constraints have been applied to custom queries."},
        new List<string> {"Show-Queue-Counts-Tooltip","Enables/disables queue counts in workflow (may hinder system performance if set to true)."},
        new List<string> {"Text-Search-Auto-View-Tooltip","Enables/disables text search auto view."},
        new List<string> {"Max-Results-Tooltip","The maximum number of documents displayed in a results list."},
        new List<string> {"Workflow-Max-Results-Tooltip","The maximum number of items displayed in the Workflow Inbox."},
        new List<string> {"Keyword-Panel-View-Type-Tooltip","This key controls how KeywordType names and Keyword operators are displayed. Please refer to the admin manual for detailed descriptions."},
        new List<string> {"Enable-Keyword-Operators-Tooltip","Enables or disables the use of keyword operators in the keyword panel."},
        new List<string> {"Enable-Session-Expiration-Tooltip","The end user will be logged out when no activity is detected."},
        new List<string> {"Prompt-On-Session-Expire-Tooltip","Prompts the user with a warning 30 seconds before the session expires."},
        new List<string> {"Display-Single-Document-Tooltip","Automatically opens a document if only one document is returned in the hitlist."},
        new List<string> {"Display-Related-Documents-Tooltip","Determines when to display the Work Folder tab: always, never, or document. If set to document, the tab will only display when a selected document in a queue has at least one related document."},
        new List<string> {"Workflow-Height-px-Tooltip","The height, in pixels, of the Workflow user interaction area. This value must be greater than 150."},
        new List<string> {"Show-Combined-Inbox-Tooltip","Specifies whether or not the combined inbox should be displayed."},
        new List<string> {"Override-UI-Language-Tooltip","The language select option appears on the login page instead of using the default language for your locale."},
        new List<string> {"Default-UI-Local-Tooltip","When Override UI Language is set to true, this key sets the behavior of the UI. To have a specific language be the default, regardless of locale setting, set this value to the locale."},
        new List<string> {"Enable-Virtual-Print-Driver-Tooltip","Enables support for importing documents using the Virtual Print Driver."},
        new List<string> {"Auto-Display-Note-Panel-PDF-Office-Tooltip","Automatically display the note panel when viewing PDF and Office documents."},
        new List<string> {"Clear-Document-Type-After-Import-Tooltip","Clear Document Type After Import."},
        new List<string> {"Clear-Keywords-After-Import-Tooltip","Clear Keywords After Import."},
        new List<string> {"Always-Generate-Preview-Tooltip","Always generate preview of an uploaded document."},
        new List<string> {"Remember-Hitlist-Height-Tooltip","The Web Client remembers the size of the document search results list, even after Internet Explorer has been closed."},
        new List<string> {"Number-of-Docuemnt-Types-to-Display-Tooltip","The number of document types to display in the select list in Document Retrieval without the need to scroll."},
        new List<string> {"Collapse-Check-Select-Lists-Tooltip","When set to true, all Check Select List controls will begin in a collapsed state."},
        new List<string> {"Add-Note-Menu-Tooltip","Enables/disables the Notes | Add Note right-click option."},
        new List<string> {"Create-New-Document-Menu-Tooltip","Enables/disables the Send To | Create New Document right-click option."},
        new List<string> {"Document-Properties-Menu-Tooltip","Enables/disables the Document Properties right-click option."},
        new List<string> {"File-Menu-Tooltip","Enables/disables the Send To | File right-click option."},
        new List<string> {"History-Menu-Tooltip","Enables/disables the History right-click option."},
        new List<string> {"Keywords-Menu-Tooltip","Enables/disables the Keywords right-click option."},
        new List<string> {"Print-Menu-Tooltip","Enables/disables the Print right-click option."},
        new List<string> {"Reindex-Menu-Tooltip","Enables/disables the Re-Index right-click option."},
        new List<string> {"Workflow-Menu-Tooltip","Enables/disables the Workflow right-click option."},
        new List<string> {"Send-To-Print-Queue-Menu-Tooltip","Enables/disables the Send To | Server Print Queue right-click option."},
        new List<string> {"Clipboard-Menu-Tooltip","Enables/disables the Send To | Clipboard right-click option."},
        new List<string> {"Go-To-Page-Tooltip","Goto page position."},
        new List<string> {"Overlay-Tooltip","Set to true or false to turn the default overlay display on or off."},
        new List<string> {"Zoom-Level-Tooltip","Zoom level when opening a document."},
        new List<string> {"Left-Border-Tooltip","Pixel position for the left border when using zoomrect."},
        new List<string> {"Right-Border-Tooltip","Pixel position for the right border when using zoomrect."},
        new List<string> {"Top-Border-Tooltip","Pixel position for the top border when using zoomrect."},
        new List<string> {"Bottom-Border-Tooltip","Pixel position for the bottom border when using zoomrect."},
        new List<string> {"Annotation-Toolbar-Tooltip","Enables/disables the Annotation toolbar."},
        new List<string> {"Notes-Toolbar-Tooltip","Enables/disables the Notes toolbar."},
        new List<string> {"Thumbnail-Pages-Tooltip","Enables/disables the Pages toolbar."},
        new List<string> {"Viewer-Control-Toolbar-Tooltip","Enables/disables the Viewer Control toolbar."},
        new List<string> {"Disable-Context-Menu-Tooltip","Disables the context menu on the web client Viewer."},
        new List<string> {"Path-Form-Proc-Tooltip",""},
        new List<string> {"Path-Print-Tooltip",""},
        new List<string> {"Prevent-Viewer-Client-Caching-Tooltip","Enable Prevent Viewer Client Caching to direct the HTML Web Client Viewer to not cache page data on the client for a brief period of time. Preventing caching will negatively impact performance. Recommended setting is false."},
        new List<string> {"Enable-Retrieve-Transactions-Tooltip","Enables/disables retrieving transactions for the selected document."},
        new List<string> {"Sort-by-Document-ID-Tooltip","Sort by Document ID when using the Retrieve Transaction functionality."},
        new List<string> {"Admin-Security-Keywords-Tooltip","Globally toggles whether an admin can assign security keywords."},
        new List<string> {"Default-Workflow-Layout-Tooltip","Specifies the way in which the Workflow interface will display: horizontal, vertical, separateviewer, or selectable.  When set to selectable, users can choose the layout they prefer."},
        new List<string> {"Row-Coloring-Tooltip","Set to true to give every other row a shaded background in the document select list. Set to false to turn off row coloring."},
        new List<string> {"Folder-Tree-Width-Tooltip","The folder tree width, represented as a percentage. This value must end in %."},
        new List<string> {"Folder-Tree-Height-Tooltip","The folder tree height, represented as a percentage. This value must end in %."},
        new List<string> {"Document-List-Height-Tooltip","The document list height, represented as a percentage. This value must end in %."},
        new List<string> {"Folder-List-Height-Tooltip","The folder list height, represented as a percentage. This value must end in %."},
        new List<string> {"WorkView-Max-Results-Tooltip","The maximum number of objects displayed for unconstrained filter results."},
        new List<string> {"WorkView-Filter-Count-Tooltip","Displays object count for all filters."},
        new List<string> {"Display-Created-EForms-Tooltip","Select the 'View E-Form Before Creating' option by default when users create e-forms from within WorkView."},
        new List<string> {"Enable-Standalone-WorkView-Client-Tooltip",""},
        new List<string> {"Application-Enabler-Integration-Tooltip","Allows Application Enabler to work with the Web Client."},
        new List<string> {"Launch-Application-Enabler-Tooltip","Launches the Application Enabler client by default."},
        new List<string> {"Data-Mining-Tooltip","Enable Data Mining content menu"},
        new List<string> {"Data-Mining-Temp-Directory-Tooltip","Fully qualified path to the data mining temporary directory."},
        new List<string> {"Data-Mining-Report-Server-Name-Tooltip","Enter the server name (host name) for where the Data Mining Reports reside."},
        new List<string> {"Data-Mining-URL-Tooltip","Location of Rms.aspx."},
        new List<string> {"Additional-Models-Tooltip","Enter a semicolon-delimited list of fully qualified pathnames to external model files. Do not use any spaces."},
        new List<string> {"Allow-View-Source-Tooltip","Enables/disables view source."},
        new List<string> {"Platter-Management-Cache-Location-Tooltip","Location on the Web Server where the cache files will be stored."},
        new List<string> {"Platter-Management-Cache-Timeout-Tooltip","The amount of time, in minutes, that files will exist in the cache."},
        new List<string> {"Platter-Management-Cache-Size-Tooltip","Cache size in MB."},
        new List<string> {"Open-Rich-Text-Format-Documents-With-Microsoft-Word-Tooltip","Enable this option to open Rich Text Format Documents with Microsoft Word."},
        new List<string> {"Allow-Caching-Tooltip","Specifies whether caching should be enabled."},
        new List<string> {"Show-Previews-Tooltip","Specifies whether or not previews of the thumbnails should be displayed."},
        new List<string> {"User-Configurable-Tooltip","Specifies whether or not the user is able to configure options for the Thumbnail Hit List Viewer."},
        new List<string> {"Number-of-Columns-Tooltip","The number of columns for the Hit List."},
        new List<string> {"Maximum-Width-Tooltip","Maximum width, in pixels."},
        new List<string> {"Maximum-Height-Tooltip","Maximum height, in pixels."},
        new List<string> {"Preview-Maxiumum-Width-Tooltip","Maximum width for the preview, in pixels."},
        new List<string> {"Preview-Maxiumum-Height-Tooltip","Maximum height for the preview, in pixels."},
        new List<string> {"Use-FolderPop-Viewer-Tooltip","Set to true to use FolderPop as the Document Viewer within ACC."},
        new List<string> {"Prompt-with-Unread-DKT-Docs-Tooltip","When set to true, the user is prompted at login to review any unacknowledged documents in DKT."},
        new List<string> {"Internal-Mail-Timer-In-Seconds-Tooltip","This timer controls how often the Web Client checks for new Internal Mail messages if the \"Notify on New Mail\" user option is enabled. By default, it checks every 300 seconds (5 minutes). This is the minimum allowed value. Setting Internal Mail Timer to 0 will disable mail notifications for all users."},
        new List<string> {"Allowed-Function-Key-List-Tooltip","Comma separated list of function key shortcuts that should not be blocked or overridden by the Web Client."},
        new List<string> {"Max-JSON-Deserialized-Members-Tooltip","The maximum number of form keys, files, and JSON members that can be used in an HTTP request. This setting is used in StatusView when configuring Foldering and WorkView portlets."},
        new List<string> {"Validation-Settings-Unobtrusive-Validation-Mode-Tooltip",""},
        new List<string> {"OWIN-Automatic-App-Startup-Tooltip","Open Web Interface for .NET (OWIN) automatic app startup enables the Administrator System Message feature."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections"},
        new List<string> {"Enabled-Legacy-Checksum-Fallback-Tooltip","Attempts to use the legacy checksum validation if the most recent validation fails to validate."},
        new List<string> {"Enable-Login-Autocomplete-Tooltip","Enable to have all login forms set as autocomplete on. Default value is false to have autocomplete off."},
        new List<string> {"Windows-Server-Locale-Format-Tooltip","Which version of Windows Server locale formats to use for data validation. A blank value will let the web client detect what version of Windows Server is running."},
        new List<string> {"Maximum-Import-Queue-Size-Tooltip","The number of documents to allow users to queue for import at a time. This value may not exceed 25, and may not be lower than 1."},
        new List<string> {"Enable-Browser-PDF-Viewer-Tooltip","Use PDF viewer provided by browser to view PDF documents, set to false will use onbase viewer. This setting will override user preferences setting. Leaving this value empty will allow users to choose which PDF viewer to use via user preferences"},
        new List<string> {"Ping-Timer-For-Scan-Service-Tooltip","The Scan Control Service using Desktop Host timeout value. The service will run indefinitely for 0 and negetive values."},
        new List<string> {"Use-Legacy-SharePoint-Authentication-Tooltip",""},
        new List<string> {"Multi-Form-Viewer-Origin-Tooltip","The origin from which the HMH Angular app which consumes MultiFormViewer is served."},
        new List<string> {"Use-Theme-Tooltip",""},
        new List<string> {"Enable-Export-Dashboard-Tooltip",""},
        new List<string> {"Enable-Export-Dashboard-Items-Tooltip",""},
        new List<string> {"Reporting-Page-Limit-Tooltip",""},
        //new List<string> {"Dashboard-Cache-Timeout-Tooltip",""},
        new List<string> {"Healthcare-Web-Viewer-Session-Timeout-Tooltip","Time (in minutes) before viewer will auto log out. (default: 30)"},
        new List<string> {"Healthcare-Web-Viewer-Data-Source-Tooltip","ODBC data source to use with the Healthcare Web Viewer. This value overrides value for key 'dmsDataSource' above."},
        new List<string> {"Healthcare-Web-Viewer-Enable-HTTP-Data-Source-Tooltip","Set to true to set the data source from the query string. This value overrides datasource and dmsDataSource. (default: false)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Deficiency-Viewing-Tooltip","Set to true to allow deficiency viewing. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Physician-Acknowledgement-Tooltip","Set to true to allow physician acknowledgment. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Document-Correction-Tooltip","Set to true to allow document corrections. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Read-Only-HTML-Forms-Tooltip","Allowed Values are \"all\", \"medical\", or \"none\". Set to All for all HTML Forms read only. Set to Medical for medical document type html forms read only. Set to none for no html forms read only. (default: all)"},
        new List<string> {"Healthcare-Web-Viewer-Read-Only-Unity-Forms-Tooltip","Allowed Values are \"all\", \"medical\", or \"none\". Set to All for all Unity Forms read only. Set to Medical for medical document type unity forms read only. Set to none for no unity forms read only. (default: all)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Tooltip","Set to true to allow the Epic Web Viewer COM integration to interop with Healthcare Web Viewer. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Interoperability-Enabled-Tooltip","Set to true to allow the Epic Hyperdrive client's Scan Viewer integration to interop with Healthcare Web Viewer. (default: false)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Failed-Timeout-Tooltip","Time (in seconds) to wait for the document to load before sending the DisplayDocument message to Epic. (default: 10)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Message-Interval-Tooltip","Time (in seconds) to wait for Epic to send a response upon sending the DisplayDocument message. (default: 1)"},
        new List<string> {"Session-Timeout-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Samesite-Cookie-Policy-Tooltip","The Web Server can use a strict, lax, or none policy for samesite cookies."},
        new List<string> {"Authentication-Mode-Tooltip",""},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-KB-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Seconds-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"Default-DocPop-Username-Tooltip","Default DocPop User Name"},
        new List<string> {"Default-DocPop-Password-Tooltip","Default DocPop Password"},
        new List<string> {"DocPop-Data-Source-Tooltip","ODBC data source to use with DocPop"},
        new List<string> {"Default-DocPop-Domain-Name-Tooltip","DocPop domain name (used with NT Authentication)"},
        new List<string> {"Default-DocPop-Institution-Tooltip","DocPop institution"},
        new List<string> {"Embedded-DocPop-Tooltip","Set to true when embedding DocPop in an Frame or IFrame."},
        new List<string> {"DocPop-Default-Login-Tooltip","Uses the web.config user name and password for DocPop login"},
        new List<string> {"DocPop-HTTP-Login-Tooltip","Get DocPop login credentials from the query string."},
        new List<string> {"DocPop-Auto-Login-Tooltip","Enables/disables DocPop auto login."},
        new List<string> {"DocPop-HTTP-Data-Source-Tooltip","Gets the DocPop data source from the query string."},
        new List<string> {"DocPop-Validate-Against-Checksum-Tooltip","Validate DocPop URLs against a checksum value."},
        new List<string> {"DocPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"DocPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"DocPop-Auto-Display-One-Document-Tooltip","If the search result contains a single document, only display the viewer and hide the select list."},
        new List<string> {"Disable-Context-Menus-in-DocPop-Tooltip","Set to true to disable context menus on Document Select and Viewer in DocPop."},
        new List<string> {"Encrypt-DocPop-Tooltip","Encrypt DocPop keys for enhanced security."},
        new List<string> {"Default-PdfPop-Username-Tooltip","Default PdfPop User Name"},
        new List<string> {"Default-PdfPop-Password-Tooltip","Default PdfPop Password"},
        new List<string> {"PdfPop-Data-Source-Tooltip","ODBC data source to use with PdfPop"},
        new List<string> {"Default-PdfPop-Domain-Name-Tooltip","PdfPop domain name (used with NT Authentication)"},
        new List<string> {"Default-PdfPop-Institution-Tooltip","PdfPop institution"},
        new List<string> {"Embedded-PdfPop-Tooltip","Set to true when embedding PdfPop in an Frame or IFrame."},
        new List<string> {"PdfPop-Default-Login-Tooltip","Uses the web.config user name and password for PdfPop login"},
        new List<string> {"PdfPop-HTTP-Login-Tooltip","Get PdfPop login credentials from the query string."},
        new List<string> {"PdfPop-Auto-Login-Tooltip","Enables/disables PdfPop auto login."},
        new List<string> {"PdfPop-HTTP-Data-Source-Tooltip","Gets the PdfPop data source from the query string."},
        new List<string> {"PdfPop-Validate-Against-Checksum-Tooltip","Validate PdfPop URLs against a checksum value."},
        new List<string> {"PdfPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"PdfPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"PdfPop-Auto-Display-One-Document-Tooltip","If the search result contains a single document, only display the viewer and hide the select list."},
        new List<string> {"Encrypt-PdfPop-Tooltip","Encrypt PdfPop keys for enhanced security."},
        new List<string> {"Default-FormPop-Username-Tooltip","Default FormPop User Name"},
        new List<string> {"Default-FormPop-Password-Tooltip","Default FormPop Password"},
        new List<string> {"FormPop-Data-Source-Tooltip","ODBC data source to use with FormPop"},
        new List<string> {"Default-FormPop-Domain-Name-Tooltip","FormPop domain name (used with NT Authentication)"},
        new List<string> {"Default-FormPop-Institution-Tooltip","FormPop institution"},
        new List<string> {"Embedded-FormPop-Tooltip","Set to true when embedding FormPop in an Frame or IFrame."},
        new List<string> {"FormPop-Default-Login-Tooltip","Uses the web.config user name and password for FormPop login"},
        new List<string> {"FormPop-HTTP-Login-Tooltip","Get FormPop login credentials from the query string."},
        new List<string> {"FormPop-Auto-Login-Tooltip","Enables/disables FormPop auto login."},
        new List<string> {"FormPop-HTTP-Data-Source-Tooltip","Gets the FormPop data source from the query string."},
        new List<string> {"FormPop-Validate-Against-Checksum-Tooltip","Validate FormPop URLs against a checksum value."},
        new List<string> {"FormPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"FormPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"FormPop-Auto-Display-One-Document-Tooltip","If the search result contains a single document, only display the viewer and hide the select list."},
        new List<string> {"Encrypt-FormPop-Tooltip","Encrypt FormPop keys for enhanced security."},
        new List<string> {"Default-FolderPop-Username-Tooltip","Default FolderPop User Name"},
        new List<string> {"Default-FolderPop-Password-Tooltip","Default FolderPop Password"},
        new List<string> {"FolderPop-Data-Source-Tooltip","ODBC data source to use with FolderPop"},
        new List<string> {"Default-FolderPop-Domain-Name-Tooltip","FolderPop domain name (used with NT Authentication)"},
        new List<string> {"Default-FolderPop-Institution-Tooltip","FolderPop institution"},
        new List<string> {"Embedded-FolderPop-Tooltip","Set to true when embedding FolderPop in an Frame or IFrame."},
        new List<string> {"FolderPop-Default-Login-Tooltip","Uses the web.config user name and password for FolderPop login"},
        new List<string> {"FolderPop-HTTP-Login-Tooltip","Get FolderPop login credentials from the query string."},
        new List<string> {"FolderPop-Auto-Login-Tooltip","Enables/disables FolderPop auto login."},
        new List<string> {"FolderPop-HTTP-Data-Source-Tooltip","Gets the FolderPop data source from the query string."},
        new List<string> {"FolderPop-Validate-Against-Checksum-Tooltip","Validate FolderPop URLs against a checksum value."},
        new List<string> {"FolderPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"FolderPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"Encrypt-FolderPop-Tooltip","Encrypt FolderPop keys for enhanced security."},
        new List<string> {"PacketPop-Data-Source-Tooltip","ODBC data source to use with PacketPop."},
        new List<string> {"PacketPop-Validate-Against-Checksum-Tooltip","Validate PacketPop URLs against a checksum value."},
        new List<string> {"PacketPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"LoginFormProc-Username-Tooltip","User name used for creating forms."},
        new List<string> {"LoginFormProc-Password-Tooltip","Password used for creating forms."},
        new List<string> {"LoginFormProc-Data-Source-Tooltip","ODBC data source name used when creating forms."},
        new List<string> {"LoginFormProc-Prompt-For-New-Form-Tooltip","Prompts the user to complete another form."},
        new List<string> {"Encrypt-LoginFormProc-Tooltip","Encrypt Login Form Proc keys for enhanced security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"},
        new List<string> {"ADFS-Enabled-Tooltip",""},
        new List<string> {"Synchronize-User-Attributes-Tooltip",""},
        new List<string> {"Authentication-Only-Tooltip",""},
        new List<string> {"Cookie-Handler-Require-SSL-Tooltip",""},
        new List<string> {"Trusted-Issuer-Name-Tooltip",""},
        new List<string> {"wsFederation-Issuer-Tooltip","The URI of the token issuer. Also referred to as security token service (STS)."},
        new List<string> {"wsFederation-Realm-Tooltip","The URI of the requesting realm (Relying Party), which identifies the relying party (RP) to the security token service (STS)."},
        new List<string> {"Certificate-X509-Find-Type-Tooltip","Specifies the type of X.509 search to be executed."},
        new List<string> {"Certificate-Find-Value-Tooltip","Specifies the value to search for in the X.509 certificate store."},
        new List<string> {"Certificate-Store-Location-Tooltip","A StoreLocation value that specifies the location of the X.509 certificate store. The default value is \"LocalMachine\"."},
        new List<string> {"Certificate-Store-Name-Tooltip","The name of the X.509 certificate store. The default is \"My\"."},
        new List<string> {"Application-Script-Location-Tooltip",""},
        new List<string> {"Application-Keyword-ID-Tooltip",""},
        new List<string> {"Application-Keyword-Validator-Tooltip",""},
        new List<string> {"Page-Location-Tooltip",""},
        new List<string> {"Page-Script-Location-Tooltip",""},
        new List<string> {"Page-Keyword-ID-Tooltip",""},
        new List<string> {"Page-Keyword-Validator-Tooltip",""},
        new List<string> {"Enable-Healthcare-Web-Viewer-Tooltip",""},
        new List<string> {"KeywordTypeahead-KeywordIDNumber-Tooltip","The unique Keyword Type ID# for the keyword that you are wanting to target."},
        new List<string> {"KeywordTypeahead-TypeaheadCharacterCount-Tooltip","The minimum number of characters that will need to be typed in before the drop down field will start showing potential matches."},
        new List<string> {"NavPanel-ContextEnabled-Tooltip",""},
        new List<string> {"NavPanel-Icon-Tooltip",""},
        new List<string> {"NavPanel-DisplayOrder-Tooltip",""},
        new List<string> {"NavPanel-DisplayName-Tooltip",""},
        new List<string> {"NavPanel-Name-Tooltip",""}
    };

    /* 241 Tooltip Objects */
    private readonly List<List<string>> AgendaOnline241Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stream-Chunk-Size-Tooltip",""},
        new List<string> {"Player-Source-File-Path-Tooltip","Path to directory where the media player resides."},
        new List<string> {"Player-Version-Tooltip","Version key of the media player."},
        new List<string> {"Min-Pool-Size-Tooltip","Minimum Pool Size"},
        new List<string> {"Max-Pool-Size-Tooltip","Maximum Pool Size"},
        new List<string> {"webpages-Enabled-Tooltip",""},
        new List<string> {"Google-Analytics-Tooltip",""},
        new List<string> {"Session-Username-Tooltip","The OnBase user name for authentication."},
        new List<string> {"Session-Password-Tooltip","The OnBase password for authentication."},
        new List<string> {"Data-Source-Tooltip","The ODBC datasource utilized by the Application Server."},
        new List<string> {"Encrypt-Agenda-Online-Access-Tooltip", "Encrypt Agenda Public Access keys for enhanced security." },
        new List<string> {"Integration-Name-Tooltip", ""},
        new List<string> {"Integration-URL-Tooltip", ""},
        new List<string> {"Integration-Token-Tooltip", ""},
        new List<string> {"Availability-From-Meeting-Start-Tooltip", "-This value is in hours. It is based on the start time of the meeting.<br>-This value determines when the Make Comment button is no longer available in the meeting.<br>-This value can be a whole number, decimal, or negative value (a negative value disables the button by the number of hours specified before the meeting start time).<br>-The default value is 0, meaning that once the meeting start time passes, the button is disabled."},
        new List<string> {"Form-Field-Name", ""},
        new List<string> {"Form-Field-ID-Tooltip", ""},
        new List<string> {"Meeting-Type-Name-Tooltip", ""}
    };

    private readonly List<List<string>> ApplicationServer241Tooltips = new List<List<string>>
    {
        new List<string> {"Server-Designation-Tooltip","(Optional) Enter a value to designate which server the user is connecting to, which will display in Web Diagnostics. This is helpful in a load balanced environment."},
        new List<string> {"Data-Source-Tooltip","The ODBC datasource utilized by the Application Server."},
        new List<string> {"Use-OS-Authentication-Tooltip","Set to true if the connection to the database should be made with OS Authentication instead of SQL Authentication. This requires an OS/domain user with access to the database to be configured as the user for this Application Server."},
        new List<string> {"Document-Query-Warning-Threshold-Tooltip","Display a warning message if the number of documents returned from a query exceeds this value. If Document Query Warning Threshold is greater than Document Query Limit, no warning message will be displayed."},
        new List<string> {"Document-Query-Limit-Tooltip","Document queries are limited when the number of returned documents exceeds this value."},
        new List<string> {"Item-Cache-Timeout-Tooltip","The number of seconds an item will exist within the item cache before it will be expired."},
        new List<string> {"Raw-Images-Tooltip","Images are sent directly to the viewer from the database instead of first being processed by ASP.NET on the server."},
        new List<string> {"Use-Isolated-Image-Process-Tooltip","Setting for initializing the out of process image rendering service."},
        new List<string> {"Compression-Quality-Tooltip","Controls the compression quality of color images and can be used to reduce memory usage when viewed. The default setting is 80 (measured in percent)."},
        new List<string> {"Enable-Isolated-Chromium-Process-Tooltip","Setting for initializing the Chromium Image service used by Unity Forms."},
        new List<string> {"Form-Save-To-TIFF-Timeout-Tooltip","Timeout in seconds for sending a Form to a TIFF file using the process image rendering service."},
        new List<string> {"Print-Image-Form-Via-PDF-Tooltip","Configuration to print image form via PDF. \"TRUE\" means printing via PDF else \"FALSE\" means printing via screenshot."},
        new List<string> {"TPCF-Worker-Location-Override-Tooltip","Specify a custom path for TPCF Worker directory"},
        new List<string> {"Default-Storage-Path-Tooltip","Default storage path for the File Monitoring Engine."},
        new List<string> {"Watch-Folder-Tooltip","The folder to monitor in Front Office Scanning."},
        new List<string> {"Site-ID-Keyword-Type-Tooltip","Site ID Keyword Type"},
        new List<string> {"Cleanup-Timer-Interval-Tooltip","Sets the time span (in seconds) after which the file monitoring system looks for changes."},
        new List<string> {"Max-File-Age-Tooltip","Maximum file age (in hours)."},
        new List<string> {"Integrations-EIS-Validate-Message-Schema-Tooltip","Set to true to perform validation on the Message Schema."},
        new List<string> {"Integrations-EIS-Continue-On-Validation-Error-Tooltip","Set to true to log an error and continue when Message Schema validation fails."},
        new List<string> {"Integrations-EIS-Data-Set-Cache-Cleanup-Interval-Tooltip","Data Set Cache Cleanup Interval (Minutes)."},
        new List<string> {"Integrations-EIS-AppNet-Directory-Tooltip","The location of the virtual directory where the Web Server resides. This setting is needed to generate DocPop URLs."},
        new List<string> {"Message-Broker-Monitor-Start-Delay-Tooltip","Delay in minutes to start the timer used by the Message Broker to monitor for message issues and completed messages needing archiving."},
        new List<string> {"GCS-Username-Tooltip","User Name to connect to GCS. Can be in plain text or use ASPNET_SETREG.exe to encrypt. For example: \"registry:HKLM\\SOFTWARE\\Hyland\\GCS\\UsageBasedBilling\\identity\\ASPNET_SETREG,userName\""},
        new List<string> {"GCS-Password-Tooltip","Password to connect to GCS. Can be in plain text or use ASPNET_SETREG.exe to encrypt. For example: \"registry:HKLM\\SOFTWARE\\Hyland\\GCS\\UsageBasedBilling\\identity\\ASPNET_SETREG,password\""},
        new List<string> {"Use-Legacy-Key-For-Usage-Based-Billing-Tooltip",""},
        new List<string> {"GCS-Phone-Home-Interval-Tooltip","Time interval (in minutes) to perform phone home to GCS server."},
        new List<string> {"Data-Capture-Server-WCF-Endpoint-Address-Tooltip","Data Capture Server WCF Endpoint Address"},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"OWIN-Application-Server-Origin-Tooltip","The application server origin used to create absolute links. In a load-balanced environment, hostname would be the load-balancer. Example: https://hostname/AppServer"},
        new List<string> {"OWIN-Automatic-App-Startup-Tooltip","Automatic App Startup"},
        new List<string> {"OWIN-App-Startup-Tooltip","Location of the OWIN startup class"},
        new List<string> {"Identity-Model-Server-URI-Tooltip",""},
        new List<string> {"Mobile-Apps-Path-Tooltip","Mobile Apps Path"},
        new List<string> {"CORS-Policy-Tooltip","CORS Policy"},
        new List<string> {"WorkView-Mobile-Endpoint-Tooltip","Check this box to enable this application as a WorkView Mobile Endpoint."},
        new List<string> {"Responsive-Apps-Endpoint-Tooltip","Check this box to enable this application as a Responsive Apps Endpoint."},
        new List<string> {"WOPI-Endpoint-Tooltip","Endpoint setting for Office Online Server"},
        new List<string> {"Sesame-Endpoint-Tooltip","Check this box to enable this application as a Sesame Endpoint."},
        new List<string> {"Governance-Rules-As-A-Service-Endpoint-Tooltip","Check this box to enable this application as a Governance Rules As A Service (GRAAS Endpoint."},
        new List<string> {"Web-BLOB-Passthrough-FHIR-Endpoint-Tooltip","Check this box to enable this application as a Web BLOB Passthrough (WBPT) FHIR Endpoint."},
        new List<string> {"SMART-On-FHIR-Application-ID-Tooltip",""},
        new List<string> {"PPL-Endpoint-Enabled-Tooltip","Check this box to enable this application as a PPL Endpoint."},
        new List<string> {"Forms-Endpoint-Tooltip","Check this box to enable this application as a Forms Endpoint."},
        new List<string> {"PPL-DocPop-URL-Tooltip","This is the URL for viewing Unity Forms in Patient Portal Link. Do not add a trailing slash."},
        new List<string> {"Statement-Composition-Cache-Limit-Tooltip","Maximum number of cached statement composition documents."},
        new List<string> {"Unity-Forms-Toggle-Max-Form-Width-Tooltip","Changes the Unity forms rendering behavior when form elements exceed the width of the form.<br>Set this to \"true\" to prevent the form from expanding to match the width of the largest element."},
        new List<string> {"owin:oia:msgItemTypeId-Tooltip",""},
        new List<string> {"owin:oia:lifeCycleId-Tooltip",""},
        new List<string> {"owin:oia:tmpFilePath-Tooltip",""},
        new List<string> {"owin:oia:tmpFileAgeInMs-Tooltip",""},
        new List<string> {"owin:oia:cleanupIntervalInMs-Tooltip",""},
        new List<string> {"Use-OnBase-Full-Text-Tooltip",""},
        new List<string> {"Content-Composer-IdP-Path-Tooltip",""},
        new List<string> {"Keyword-Data-Cache-Timeout-Tooltip","Timeout in minutes used to determine how long keyword metadata is stored in memory. WARNING, increasing this value over the default of 20 minutes will increase memory consumption on the application server. Lowering this value can result in undesirable behavior."},
        new List<string> {"Allow-Insecure-External-XSL-Tooltip",""},
        new List<string> {"Max-Query-Execution-Parallelism-Tooltip",""},
        new List<string> {"Folder-Fetch-Batch-Size-Tooltip",""},
        new List<string> {"Database-Command-TimeOut-Tooltip","Sharebase folder Database Command Time Out in Seconds."},
        new List<string> {"Doc-Linker-SMART-On-FHIR-Application-ID-Tooltip","DocLinkerSMARTonFHIRApplicationId is only used with the Epic LaunchLinkDocumentsActivities API."},
        new List<string> {"Use-New-Keyword-Data-Cache-Implementation-Tooltip","Feature Flag setting for selecting the implementation of the Keyword Data Cache."},
        new List<string> {"Configuration-Import-Database-Timeout-Tooltip","Set the default timeout in seconds for Import actions. Values below 120 will be ignored."},
        new List<string> {"PIM:HyRCS:ExternalBaseUri-Tooltip","Set an external URI for HyRCS instead of using the out of process localhost instance."},
        new List<string> {"PIM:HyRCS:Port-Tooltip","Set a custom port for HyRCS. This will ONLY be applied if using the out of process localhost instance. For an external instance, specify the port in the PIM:HyRCS:ExternalBaseUri value."},
        new List<string> {"PIM:ImageProcess-Tooltip","SET TO REPLACE 'UseIsolatedImageProcess' - Setting for initializing the out of process image rendering service."},
        new List<string> {"PIM:ChromiumProcess-Tooltip","SET TO REPLACE 'EnableIsolatedChromiumProcess' - Setting for initializing the Chromium Image service used by Unity Forms."},
        new List<string> {"HyRCS:PageCountLimit-Tooltip","Set the page count limit for HyRCS"},
        new List<string> {"Responsive-Apps-WorkView-API-URL-Tooltip","WorkViewApi is the path to the WorkView web api facet. Example: \"https://hostname/AppServer/private/workview/api/\""},
        new List<string> {"Responsive-Apps-WorkView-Files-URL-Tooltip","WorkViewFiles is the path to the WorkView static file server facet. Example: \"https://hostname/AppServer/private/workview/files/\""},
        new List<string> {"Responsive-Apps-API-URL-Tooltip","ResponsiveAppsApi is the path to the Responsive Apps web api facet. Example: \"https://hostname/AppServer/private/responsive-apps/api/\""},
        new List<string> {"Identity-Provider-URL-Tooltip","IdentityProvider is the path to the Identity Provider including tenant and user population. Example: \"https://hostname/idp/workview/mobile/\""},
        new List<string> {"Core-Access-Token-Lifetime-Tooltip","CoreAccessTokenLifetime is the property that is used for configuring the default length (in seconds) that a ReAuth token is good for when accessed through resonsive-apps."},
        new List<string> {"File-IO-Detail-Tooltip",""},
        new List<string> {"Foreign-Storage-EMC-Threshold-Tooltip","Setting for Centera inline blobs in KB.  Default is 75."},
        new List<string> {"Foreign-Storage-PM-Cache-Location-Tooltip","Path to cache location."},
        new List<string> {"Foreign-Storage-PM-Cache-Timeout-Tooltip","Timeout in minutes.  Default is 60 minutes."},
        new List<string> {"Foreign-Storage-PM-Cache-Size-Tooltip","Cache size in MB.  Default is 500."},
        new List<string> {"PM-File-Access-Level-Tooltip","0 or empty for Default, 1 to Always use UNC, 2 to Never to UNC."},
        new List<string> {"Temp-File-Expiration-Threshold-Time-Tooltip","The minimum amount of time a temporary file should exist without being accessed before it expires. Default is 00:05:00 (five minutes)."},
        new List<string> {"Hyland-Services-AppPool-Minimum-Sessions-Tooltip","This parameter dictates the minimum number of OnBase sessions available in the session pool. (default 0)"},
        new List<string> {"Hyland-Services-AppPool-Maximum-Sessions-Tooltip","This parameter dictates the maximum number of OnBase sessions available in the session pool.  Requests from the pool that exceed this value will block until another session is placed back into the pool. (default 10)"},
        new List<string> {"Use-Query-Context-Tooltip","This parameter indicates if query context security will be used during the course of retrieval. Query context means that a document must be retrieved through a document query before the document itself is accessible via another call. If this parameter is omitted, the default is true. Note: this value should be set to false when being used for disconnected web services. (default false)"},
        new List<string> {"Filter-Exceptions-Tooltip","This parameter indicates if the application server should not send detailed information about exception. For example, the exact stack trace of the exception will be filtered. This reduces the amount of information revealed to a malicious attacker when the server is attacked. The information is still available via Diagnostics Console and Diagnostics Server for an authorized user. (default true)"},
        new List<string> {"Endpoint-Use-Remoting-Tooltip",""},
        new List<string> {"Session-Enable-Timeout-Tooltip","Controls the timeout behavior for unused sessions. If enableTimeout is set to true the AppServer will timeout unused sessions and disconnect them. The timeout period is based on the ASP.NET session timeout found in the system.web\\session section with a minimum of 10 minutes. (default false)"},
        new List<string> {"Application-Server-Callback-URL-Tooltip",""},
        new List<string> {"Web-Server-Base-URL-Tooltip",""},
        new List<string> {"Request-Validation-Minimum-Version-Tooltip",""},
        new List<string> {"Login-ID-Tooltip",""},
        new List<string> {"Login-Password-Tooltip",""},
        new List<string> {"Login-Datasource-Tooltip",""},
        new List<string> {"Pool-Min-Tooltip",""},
        new List<string> {"Pool-Max-Tooltip",""},
        new List<string> {"Search-Timeout-Tooltip","The length of time (in seconds) before the search will timeout."},
        new List<string> {"Enable-Search-Log-Tooltip","Enables Full Text search logs in the specified path(<SearchLog enableSearchlog=\"true\" path=\"<HostName>/SearchLogs\"/>). Path should have full access rights for 'Everyone'."},
        new List<string> {"Search-Log-Path-Tooltip",""},
        new List<string> {"Unity-Editable-Filter-Max-Rows-Tooltip","Sets Max results for Unity client editable embedded filters (Default: 250, Max: 2000)."},
        new List<string> {"ERP-Date-Format-LOB-Broker-Tooltip","Sets the ERP date format for processing results for LOB Broker classes."},
        new List<string> {"Formatted-Text-Iframe-Supported-Domains-Tooltip","Adds additional domains that should be supported by iframes in the formatted text attribute control. Adding a domain to this list will add `allow-scripts`, `allow-same-origin`, and `allow-forms` overrides to the sandbox attribute on the iframe. Add domains as a comma separated list.<br><br>Examples:<br>&nbsp;&nbsp;&nbsp;&nbsp;*.mydomain.com<br>&nbsp;&nbsp;&nbsp;&nbsp;sub.myotherdomain.com<br><br>In this example *.mydomain.com will enable all sub-domains for mydomain.com (Ex: www.mydomain.com and test.mydomain.com would be valid), sub.myotherdomain.com would only allow sandbox overrides for that specific domain and sub-domain."},
        new List<string> {"Use-Office-Online-Server-Tooltip","Set to true to use the WOPI viewer. Set to false to continue using the legacy viewer."},
        new List<string> {"Office-Online-Server-URI-Tooltip","Points to the Office Online Server."},
        new List<string> {"Office-Online-Server-Proxy-Base-Tooltip","Points to the WOPI Service. Example: \"https://localhost/AppServer/private\""},
        new List<string> {"Vendor-Cache-Search-Minimum-Characters-Tooltip",""},
        new List<string> {"Vendor-Master-Keyed-Lookup-Op-Tooltip",""},
        new List<string> {"Vendor-Master-Lookup-Sequence-Tooltip",""},
        new List<string> {"Vendor-Master-Lookup-Return-Multiple-Tooltip",""},
        new List<string> {"Vendor-Cache-AutoComplete-Result-Max-Tooltip",""},
        new List<string> {"Enable-LOB-Broker-Accounts-Payable-Tooltip",""},
        new List<string> {"Http-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"Http-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Session-Timeout-Length-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"Content-Composer-Client-ID-Tooltip","Client ID provided by the Hyland Identity Provider (IdP)."},
        new List<string> {"Content-Composer-Client-Secret-Tooltip","Client secret provided by the Hyland Identity Provider (IdP)."},
        new List<string> {"Content-Composer-Username-Tooltip","Hyland IdP user with Content Composer access."},
        new List<string> {"Content-Composer-Password-Tooltip","Password for Hyland IdP user with Content Composer access."},
        new List<string> {"Encrypt-Content-Composer-Settings-Tooltip","Checking this will encrypt the Content Composer section in configuration."},
        new List<string> {"Pop-Integrations-Validate-Against-Checksum-Tooltip","Validate a Pop URL with the checksum value."},
        new List<string> {"Pop-Integrations-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"Pop-Integrations-Enable-Legacy-Checksum-Creation-Tooltip","Creates checksums using the legacy checksum validation."},
        new List<string> {"Pop-Integrations-Encrypt-Configuration-Tooltip","Encrypt configuration information for improved security."},
        new List<string> {"Integrations-Media-URL-Tooltip","URL to the OnBase Cloud"},
        new List<string> {"Integrations-Media-Datasource-Tooltip","Customer Datasource"},
        new List<string> {"Integrations-Media-Username-Tooltip","Customer username to OnBase Cloud"},
        new List<string> {"Integrations-Media-Password-Tooltip","Customer password to OnBase Cloud"},
        new List<string> {"Integrations-Media-Encrypt-OnBase-Cloud-Settings-Tooltip","When checked, url, datasource, username and password will be encrypted."},
        new List<string> {"EAC-Username-Tooltip","The OnBase User (usually a service account) that the Application Server uses to process EAC logon requests."},
        new List<string> {"EAC-Password-Tooltip","The password to the account handling EAC logons."},
        new List<string> {"EAC-UserLevel-Minimum-Pool-Size-Tooltip","The minimum number of OnBase user sessions maintained for this pool while the EAC Application Server is running."},
        new List<string> {"EAC-UserLevel-Maximum-Pool-Size-Tooltip","The maximum number of OnBase user sessions maintained for this pool while the EAC Application Server is running.  If the number of concurrent users accessing this pool is greater than this number, user requests will be queued."},
        new List<string> {"Encrypt-EAC-Tooltip","Encrypt EAC configuration settings for enhanced security."},
        new List<string> {"Authentication-Mode-Tooltip","This section sets the authentication policies of the application. Possible modes are \"Windows\" and \"None\".<br><br>\"None\" - No authentication is performed.<br>\"Windows\" - IIS performs authentication (Basic, Digest, or Integrated Windows) according to its settings for the application. Anonymous access must be disabled in IIS."},
        new List<string> {"ADFS-Enabled-Tooltip","This checkbox indicates whether the ADFS node is set to enabled."},
        new List<string> {"Request-Validation-Mode-Tooltip","The Request Validation Mode must be set to 2.0 for ADFS."},
        new List<string> {"Synchronize-User-Attributes-Tooltip",""},
        new List<string> {"Authentication-Only-Tooltip",""},
        new List<string> {"Cookie-Handler-Require-SSL-Tooltip","Configures the CookieHandler that the SessionAuthenticationModule (SAM) uses to read and write cookies."},
        new List<string> {"Audience-URI-Tooltip","Audience URI. As configured on the Endpoints tab of the Relying Party Trust. Requires trailing slash."},
        new List<string> {"Trusted-Issuer-Thumbprint-Tooltip","The issuer of the certificate used to validate the signature on responses from ADFS."},
        new List<string> {"Trusted-Issuer-Name-Tooltip",""},
        new List<string> {"wsFederation-Issuer-Tooltip","The URI of the token issuer. Also referred to as security token service (STS)."},
        new List<string> {"wsFederation-Realm-Tooltip","The URI of the requesting realm (Relying Party), which identifies the relying party (RP) to the security token service (STS)."},
        new List<string> {"Certificate-X509-Find-Type-Tooltip","Specifies the type of X.509 search to be executed."},
        new List<string> {"Certificate-Find-Value-Tooltip","Specifies the value to search for in the X.509 certificate store."},
        new List<string> {"Certificate-Store-Location-Tooltip","A StoreLocation value that specifies the location of the X.509 certificate store. The default value is \"LocalMachine\"."},
        new List<string> {"Certificate-Store-Name-Tooltip","The name of the X.509 certificate store. The default is \"My\"."},
        new List<string> {"Hyland-Idp-Url-Tooltip",""},
        new List<string> {"Hyland-IdP-Audience-URL-Tooltip",""},
        new List<string> {"Hyland-IdP-Name-Claim-Type-Tooltip",""},
        new List<string> {"Hyland-IdP-Api-Name-Tooltip",""},
        new List<string> {"Hyland-IdP-Api-Secret-Tooltip",""},
        new List<string> {"Alias-Old-Name-Tooltip",""},
        new List<string> {"Alias-New-Name-Tooltip",""},
        new List<string> {"Alias-Type-Tooltip",""},
        new List<string> {"SessionAdministration-User-Tooltip",""},
        new List<string> {"SessionAdministration-Role-Tooltip",""},
        new List<string> {"Trust-Mode-Tooltip",""},
        new List<string> {"Store-Location-Tooltip",""},
        new List<string> {"Store-Name-Tooltip",""},
        new List<string> {"Find-Type-Tooltip",""},
        new List<string> {"Find-Value-Tooltip",""},
        new List<string> {"Description-Tooltip",""},
        new List<string> {"App-Name-Tooltip",""},
        new List<string> {"App-Icon-URL-Tooltip",""},
        new List<string> {"App-URL-Tooltip",""}
    };

    private readonly List<List<string>> ElectronicPlanReview241Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stylesheet-Directory-Location-Tooltip","The directory containing files that add a specific look and feel to the site. Default location is BasicBlue."},
        new List<string> {"Allow-Sign-On-Tooltip","Allows users to sign on for access to create plan projects."},
        new List<string> {"Allow-Sign-Off-Tooltip","Allows users to sign off."},
        new List<string> {"Default-User-Time-Zone-Tooltip","Provides a way to set the initial time zone."},
        new List<string> {"Search-Start-Year-Tooltip","For Users searching plan project history, the Yearly search option list limits the list with this item."},
        new List<string> {"Items-Per-Page-Tooltip","The number of items to display on a project list or paged list of documents."},
        new List<string> {"Max-Lookup-Results-Tooltip",""},
        new List<string> {"Reset-Password-Link-Lifetime-Tooltip","Controls how long a reset link remains active, before it will not be allowed to reset a password. This is specified in minutes."},
        new List<string> {"File-Upload-Directory-Tooltip","The directory that stages plan documents while they are received from the client before forwarding them onto app server."},
        new List<string> {"File-Upload-Validator-Tooltip","File Upload Validator Format: Assembly Path,Class Name,Method Name."},
        new List<string> {"Token-Authentication-Tooltip",""},
        new List<string> {"Allow-Single-Sign-On-Tooltip","Enables the use of SSO.  This enables a user to login to a single system and automatically login to the plan review site."},
        new List<string> {"Source-ID-Tooltip","Source ID"},
        new List<string> {"Resolution-Mode-Tooltip","Resolution Mode"},
        new List<string> {"Public-CAPTCHA-Key-Tooltip","Public CAPTCHA API key provided by 3rd party CAPTCHA service."},
        new List<string> {"Private-CAPTCHA-Key-Tooltip","Private CAPTCHA API key provided by 3rd party CAPTCHA service."},
        new List<string> {"Password-Strength-Pattern-Tooltip","The password strength regular expression determines the minimum character length and characters/symbols that a password must contain in order to be a valid password."},
        new List<string> {"Password-Strength-Message-Tooltip","An optional password strength message that is displayed when the password requested during registration does not meet the required strength."},
        new List<string> {"Username-Validation-Pattern-Tooltip",""},
        new List<string> {"Discipline-Items-Per-Menu-Tooltip","Number of discipline items displayed in menu in the Plan review web client."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"EPR-Username-Tooltip","The OnBase user that Application Server uses to process Plan Review requests."},
        new List<string> {"EPR-Password-Tooltip","The OnBase user password that Application Server uses to process Plan Review requests."},
        new List<string> {"Data-Source-Tooltip","The OnBase Data Source that Application Server uses to process Plan Review Requests."},
        new List<string> {"Encrypt-Electronic-Plan-Review-Tooltip", "Determines whether or not the user name and password will be encrypted in the web.config file."}
    };

    private readonly List<List<string>> HealthcareFormManager241Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Allow-View-Source-Tooltip","Enables/disables view source."},
        new List<string> {"Enable-Session-Expiration-Tooltip","The end user will be logged out when no activity is detected."},
        new List<string> {"Prompt-On-Session-Expire-Tooltip","Prompts the user with a warning 30 seconds before the session expires."},
        new List<string> {"Web-Theme-Tooltip",""},
        new List<string> {"Default-Username-Tooltip","Default User Name."},
        new List<string> {"Default-Password-Tooltip","Default Password."},
        new List<string> {"Default-Login-Tooltip","Uses the web.config user name and password for Healthcare FormPop login."},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using the default user name and password."},
        new List<string> {"Force-OnBase-Authentication-Tooltip","Ignores database domain authentication settings and uses OnBase authentication instead."},
        new List<string> {"Web-Client-Type-Tooltip","Determines which type of Web Client to use.<br>activex - This will enable the ActiveX web client.<br>html - This will enable the HTML Only web client.<br>selectable - This will provide users an option upon login to select which client type (ActiveX or HTML Only) to use."},
        new List<string> {"Row-Coloring-Tooltip","Set to true to give every other row a shaded background in the document select list. Set to false to turn off row coloring."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"Prevent-Viewer-Client-Caching-Tooltip","Enable Prevent Viewer Client Caching to direct the HTML Web Client Viewer to not cache page data on the client for a brief period of time. Preventing caching will negatively impact performance. Recommended setting is false."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Session-Timeout-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Samesite-Cookie-Policy-Tooltip","The Web Server can use a strict, lax, or none policy for samesite cookies."},
        new List<string> {"Validate-Against-Checksum-Tooltip","Validate a Pop URL with the checksum value."},
        new List<string> {"Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"Enable-Legacy-Checksum-Fallback-Tooltip","Attempts to use the legacy checksum validation if the most recent validation fails to validate."},
        new List<string> {"Encrypt-Healthcare-Pop-Integration-Configuration-Tooltip","Encrypt configuration information for improved security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"}
    };

    private readonly List<List<string>> PatientWindow241Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Allow-View-Source-Tooltip","Enables/disables view source."},
        new List<string> {"Enable-Session-Expiration-Tooltip","The end user will be logged out when no activity is detected."},
        new List<string> {"Prompt-On-Session-Expire-Tooltip","Prompts the user with a warning 30 seconds before the session expires."},
        new List<string> {"Web-Theme-Tooltip",""},
        new List<string> {"Default-Username-Tooltip","Default User Name"},
        new List<string> {"Default-Password-Tooltip","Default Password"},
        new List<string> {"Enable-Default-Login-Tooltip",""},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using the default user name and password."},
        new List<string> {"Force-OnBase-Authentication-Tooltip","Ignores database domain authentication settings and uses OnBase authentication instead."},
        new List<string> {"Enable-Split-View-Tooltip",""},
        new List<string> {"Enable-Patient-Search-Tooltip",""},
        new List<string> {"Enable-Patient-Context-Syncing-Tooltip",""},
        new List<string> {"Enable-Timestamp-Tooltip",""},
        new List<string> {"Timestamp-Time-Limit-Tooltip",""},
        new List<string> {"Enable-Workstation-Name-DNS-Lookup-Tooltip",""},
        new List<string> {"Row-Coloring-Tooltip",""},
        new List<string> {"Allow-Caching-Tooltip","Specifies whether caching should be enabled."},
        new List<string> {"Maximum-Width-Tooltip","Maximum width, in pixels."},
        new List<string> {"Maximum-Height-Tooltip","Maximum height, in pixels."},
        new List<string> {"Preview-Maximum-Width-Tooltip","Maximum width for the preview, in pixels."},
        new List<string> {"Preview-Maximum-Height-Tooltip","Maximum height for the preview, in pixels."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"Prevent-Viewer-Client-Caching-Tooltip",""},
        new List<string> {"HTML-Only-Documents-Print-As-PDFs-Tooltip",""},
        new List<string> {"System-List-Display-Label-Tooltip",""},
        new List<string> {"Personal-List-Display-Label-Tooltip",""},
        new List<string> {"Selected-Tab-Single-Color-Tooltip",""},
        new List<string> {"Enable-EForm-Standard-Printing-Tooltip",""},
        new List<string> {"Federated-Search-With-MPI-Tooltip",""},
        new List<string> {"Hide-Toolbar-Print-Button-Tooltip",""},
        new List<string> {"Auto-Display-Note-Panel-PDF-Office-Tooltip",""},
        new List<string> {"Emergency-Access-Dialog-Title-Tooltip",""},
        new List<string> {"Emergency-Access-Dialog-Message-Tooltip",""},
        new List<string> {"Emergency-Access-Dialog-Other-Reason-Label-Tooltip",""},
        new List<string> {"Show-Emergency-Access-Show-Documents-Checkboxes-Tooltip",""},
        new List<string> {"Show-Other-Reason-In-Emergency-Access-Dialog-Tooltip",""},
        new List<string> {"Other-Reason-Text-Box-Always-Available-In-Emergency-Access-Dialog-Tooltip",""},
        new List<string> {"Enable-Bowser-PDF-Viewer-Tooltip",""},
        new List<string> {"Keyword-Panel-View-Type-Tooltip",""},
        new List<string> {"Workflow-Menu-Tooltip",""},
        new List<string> {"Create-Document-Menu-Tooltip",""},
        new List<string> {"File-Menu-Tooltip",""},
        new List<string> {"Send-To-Print-Queue-Menu-Tooltip",""},
        new List<string> {"Re-Index-Menu-Tooltip",""},
        new List<string> {"ADFS-Enabled-Tooltip",""},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Session-Timeout-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Samesite-Cookie-Policy-Tooltip","The Web Server can use a strict, lax, or none policy for samesite cookies."},
        new List<string> {"JSON-Serialization-Max-Length-Tooltip",""},
        new List<string> {"Validate-Against-Checksum-Tooltip","Validate a Pop URL with the checksum value."},
        new List<string> {"Checksum-Key-Tooltip",""},
        new List<string> {"Enable-Legacy-Checksum-Fallback-Tooltip","Attempts to use the legacy checksum validation if the most recent validation fails to validate."},
        new List<string> {"Encrypt-Healthcare-Pop-Integration-Configuration-Tooltip","Encrypt configuration information for improved security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"}
    };

    private readonly List<List<string>> PublicAccessNextGen241Tooltips = new List<List<string>>
    {
        new List<string> {"Encrypt-Doc-ID-Tooltip","Set to true to encrypt the document ID when displaying search results."},
        new List<string> {"Use-Display-Columns-Tooltip","Set to true to use the configured Custom Query display columns when displaying search results."},
        new List<string> {"Query-Limit-Tooltip","Search results will be limited to this number. Set to 0 for unlimited queries."},
        new List<string> {"Chunk-Size-Tooltip","Chunk size (in bytes) to use when downloading documents."},
        new List<string> {"Viewer-Mode-Tooltip","Set to PDF to convert documents to PDF format and stream to the viewer. Set to Native to download files in their native format. Set to Native Optional to stream files as PDF and provide a link in the viewer to download the file in its native format."},
        new List<string> {"Default-Overlay-Mode-Tooltip","The default overlay mode to render documents in, if applicable. Possible values are Print, View, and Off. Defaults to Print, was used by the past versions of Public Access."},
        new List<string> {"Cache-Path-Tooltip","Cache path"},
        new List<string> {"Expiration-Time-Tooltip","Expiration time (in days)"},
        new List<string> {"Max-Cache-Size-Tooltip","Maximum cache size on disk (GB)."},
        new List<string> {"Size-to-Cache-Tooltip","Documents with a file size equal to or greater than Size to Cache (MB) should be cached."},
        new List<string> {"Size-to-Prompt-Tooltip","Documents with a file size equal to or greater than Size to Prompt (MB) will display the browser's open/save dialog."},
        new List<string> {"Interval-Between-Throttle-Cache-Resets-Tooltip","The amount of time, in minutes, between each iteration of clearing the throttle cache. If a user is blocked from making requests, they will have to wait until this timer expires to make any more requests, or their requests will be denied. Users will only be blocked if they exceed the threshold, and if throttling is enabled. A value of 0 or less disables this behavior."},
        new List<string> {"Amount-of-Requests-During-Each-Throttle-Interval-Tooltip","The amount of requests that can be received before the host from which these requests originate is blocked for an amount of time specified in the throttle reset interval. This is to reduce the potential attack vector of a denial of service attack."},
        new List<string> {"Enable-Local-Browser-Caching-Tooltip","Whether or not to allow browsers to privately and locally cache documents returned from the public access toolkit for a short period of time in order to reduce the amount of repeated requests."},
        new List<string> {"Decorate-Document-Names-Tooltip","Whether or not to show decoration/formatting for document names (i.e. <yellow>). Only works on autonames. Decoration will always be applied to display columns, regardless of this setting."},
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"SOAP-Client-Request-Timeout-Tooltip","Timeout (in seconds) for service requests when using the SOAP client. The HttpRuntime Execution Timeout on the Application Server must be greater than or equal to this value."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"PAVNG-Username-Tooltip","Default User Name"},
        new List<string> {"PAVNG-Password-Tooltip","Default Password"},
        new List<string> {"Data-Source-Tooltip","Default Data Source"},
        new List<string> {"Encrypt-Public-Access-Configuration-Tooltip", "Encrypt Public Access keys for enhanced security."},
        new List<string> {"Query-ID-Tooltip","The ID Number of the query as noted inside of the Configuration Client. A Query ID of * indicates that the keyword is required by all queries."},
        new List<string> {"Keyword-ID-Tooltip","The Keyword ID Number of the keyword as noted inside of the Configuration Client."}
    };

    private readonly List<List<string>> ReportingViewer241Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Optimized-Service-Pipeline-Tooltip","Use the optimized service pipeline for more efficient communication of results."},
        new List<string> {"Request-Timeout-Tooltip","Determines how long the service client should wait for a response from the application server."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections."},
        new List<string> {"Web-Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Core-Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Server-Designation-Tooltip","(Optional) Enter a value to designate which server the user is connecting to, which will display in the window title. This is helpful in a load balanced environment."},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"JSON-Serialization-Max-Length-Tooltip",""},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"OB-Username-Tooltip","This user name along with the associated password will be used to automatically log the user into the Dashboard Web Viewer."},
        new List<string> {"OB-Password-Tooltip","This password along with the associated user name will be used to automatically log the user into the Dashboard Web Viewer."},
        new List<string> {"Dashboard-Theme-Tooltip","Determines the theme that the dashboard uses when it is rendered."},
        new List<string> {"Export-Dashboard-Tooltip","Allows users to export the dashboard as an image or a PDF."},
        new List<string> {"Export-Dashboard-Items-Tooltip","Allows users to export each dashboard item as an image or a PDF."},
        new List<string> {"Allow-HTTP-Parameters-Tooltip","Allows the dashboard viewer to accept dashboard parameters from the HTTP request query string."},
        new List<string> {"Dashboard-Tracing-Info-Level-Tooltip",""},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using NT Authorization or SSO."},
        new List<string> {"Report-Paging-Limit-Tooltip","This option controls the number of records that will be shown per page for a given report.  The minimum value is 50."},
        new List<string> {"Dashboard-Cache-Timeout-Tooltip",""},
        new List<string> {"Encrypt-Dashboard-Viewer-Settings-Tooltip","Encrypt Dashboard Viewer keys for enhanced security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"}
    };

    private readonly List<List<string>> WebServer241Tooltips = new List<List<string>>
    {
        new List<string> {"Application-Server-URL-Tooltip","The URL of the Application Server must end with 'Service.asmx' for SOAP or 'Service.rem' for Remoting."},
        new List<string> {"Service-Client-Type-Tooltip","The service client can use a remote or SOAP server."},
        new List<string> {"Stream-Settings-Tooltip","This will regulate Streaming Services to a certain maximum buffer size no matter what the calling code asks for."},
        new List<string> {"Core-Data-Source-Tooltip","The ODBC data source for the Web Server."},
        new List<string> {"Web-Virtual-Directory-Tooltip","The root location of the virtual directory where the Web Server resides."},
        new List<string> {"Server-Designation-Tooltip","(Optional) Enter a value to designate which server the user is connecting to, which will display in the window title. This is helpful in a load balanced environment."},
        new List<string> {"Default-Domain-Name-Tooltip","Default domain name displayed/entered on the login page."},
        new List<string> {"Default-Username-Tooltip","Default User Name"},
        new List<string> {"Default-Password-Tooltip","Default Password"},
        new List<string> {"Default-Institution-Tooltip","Default Institution"},
        new List<string> {"Autologin-Tooltip","Enables/disables auto login using the default user name and password."},
        new List<string> {"Force-OnBase-Authentication-Tooltip","Ignores database domain authentication settings and uses OnBase authentication instead."},
        new List<string> {"Custom-SSO-Authentication-Page-Failure-Tooltip","URL of a specific page that the user is redirected to if login fails while using Single Sign On."},
        new List<string> {"Close-On-Logout-Tooltip","If set to true, the window is automatically closed when the user logs out. Otherwise, the user is returned to the login screen."},
        new List<string> {"Logout-Redirect-URL-Tooltip","Redirects the user to a specific page upon logout."},
        new List<string> {"Web-Theme-Tooltip",""},
        new List<string> {"Target-Page-Tooltip",""},
        new List<string> {"Login-Page-Tooltip",""},
        new List<string> {"SharePoint-Viewer-Show-Workflow-Tooltip","Turn on/off the Workflow header bar in SharePoint."},
        new List<string> {"SharePoint-Online-Tooltip","Toggling SharePoint Online changes the authentication scheme used. If set to true, it uses OAuth. If set to false, it uses the provided certificate."},
        new List<string> {"Prompt-User-Queries-Tooltip","Checks to see if constraints have been applied to custom queries."},
        new List<string> {"Show-Queue-Counts-Tooltip","Enables/disables queue counts in workflow (may hinder system performance if set to true)."},
        new List<string> {"Text-Search-Auto-View-Tooltip","Enables/disables text search auto view."},
        new List<string> {"Max-Results-Tooltip","The maximum number of documents displayed in a results list."},
        new List<string> {"Workflow-Max-Results-Tooltip","The maximum number of items displayed in the Workflow Inbox."},
        new List<string> {"Keyword-Panel-View-Type-Tooltip","This key controls how KeywordType names and Keyword operators are displayed. Please refer to the admin manual for detailed descriptions."},
        new List<string> {"Enable-Keyword-Operators-Tooltip","Enables or disables the use of keyword operators in the keyword panel."},
        new List<string> {"Enable-Session-Expiration-Tooltip","The end user will be logged out when no activity is detected."},
        new List<string> {"Prompt-On-Session-Expire-Tooltip","Prompts the user with a warning 30 seconds before the session expires."},
        new List<string> {"Display-Single-Document-Tooltip","Automatically opens a document if only one document is returned in the hitlist."},
        new List<string> {"Display-Related-Documents-Tooltip","Determines when to display the Work Folder tab: always, never, or document. If set to document, the tab will only display when a selected document in a queue has at least one related document."},
        new List<string> {"Workflow-Height-px-Tooltip","The height, in pixels, of the Workflow user interaction area. This value must be greater than 150."},
        new List<string> {"Show-Combined-Inbox-Tooltip","Specifies whether or not the combined inbox should be displayed."},
        new List<string> {"Override-UI-Language-Tooltip","The language select option appears on the login page instead of using the default language for your locale."},
        new List<string> {"Default-UI-Local-Tooltip","When Override UI Language is set to true, this key sets the behavior of the UI. To have a specific language be the default, regardless of locale setting, set this value to the locale."},
        new List<string> {"Enable-Virtual-Print-Driver-Tooltip","Enables support for importing documents using the Virtual Print Driver."},
        new List<string> {"Auto-Display-Note-Panel-PDF-Office-Tooltip","Automatically display the note panel when viewing PDF and Office documents."},
        new List<string> {"Clear-Document-Type-After-Import-Tooltip","Clear Document Type After Import."},
        new List<string> {"Clear-Keywords-After-Import-Tooltip","Clear Keywords After Import."},
        new List<string> {"Always-Generate-Preview-Tooltip","Always generate preview of an uploaded document."},
        new List<string> {"Remember-Hitlist-Height-Tooltip","The Web Client remembers the size of the document search results list, even after Internet Explorer has been closed."},
        new List<string> {"Number-of-Docuemnt-Types-to-Display-Tooltip","The number of document types to display in the select list in Document Retrieval without the need to scroll."},
        new List<string> {"Collapse-Check-Select-Lists-Tooltip","When set to true, all Check Select List controls will begin in a collapsed state."},
        new List<string> {"Add-Note-Menu-Tooltip","Enables/disables the Notes | Add Note right-click option."},
        new List<string> {"Create-New-Document-Menu-Tooltip","Enables/disables the Send To | Create New Document right-click option."},
        new List<string> {"Document-Properties-Menu-Tooltip","Enables/disables the Document Properties right-click option."},
        new List<string> {"File-Menu-Tooltip","Enables/disables the Send To | File right-click option."},
        new List<string> {"History-Menu-Tooltip","Enables/disables the History right-click option."},
        new List<string> {"Keywords-Menu-Tooltip","Enables/disables the Keywords right-click option."},
        new List<string> {"Print-Menu-Tooltip","Enables/disables the Print right-click option."},
        new List<string> {"Reindex-Menu-Tooltip","Enables/disables the Re-Index right-click option."},
        new List<string> {"Workflow-Menu-Tooltip","Enables/disables the Workflow right-click option."},
        new List<string> {"Send-To-Print-Queue-Menu-Tooltip","Enables/disables the Send To | Server Print Queue right-click option."},
        new List<string> {"Clipboard-Menu-Tooltip","Enables/disables the Send To | Clipboard right-click option."},
        new List<string> {"Go-To-Page-Tooltip","Goto page position."},
        new List<string> {"Overlay-Tooltip","Set to true or false to turn the default overlay display on or off."},
        new List<string> {"Zoom-Level-Tooltip","Zoom level when opening a document."},
        new List<string> {"Left-Border-Tooltip","Pixel position for the left border when using zoomrect."},
        new List<string> {"Right-Border-Tooltip","Pixel position for the right border when using zoomrect."},
        new List<string> {"Top-Border-Tooltip","Pixel position for the top border when using zoomrect."},
        new List<string> {"Bottom-Border-Tooltip","Pixel position for the bottom border when using zoomrect."},
        new List<string> {"Annotation-Toolbar-Tooltip","Enables/disables the Annotation toolbar."},
        new List<string> {"Notes-Toolbar-Tooltip","Enables/disables the Notes toolbar."},
        new List<string> {"Thumbnail-Pages-Tooltip","Enables/disables the Pages toolbar."},
        new List<string> {"Viewer-Control-Toolbar-Tooltip","Enables/disables the Viewer Control toolbar."},
        new List<string> {"Disable-Context-Menu-Tooltip","Disables the context menu on the web client Viewer."},
        new List<string> {"Path-Form-Proc-Tooltip",""},
        new List<string> {"Path-Print-Tooltip",""},
        new List<string> {"Prevent-Viewer-Client-Caching-Tooltip","Enable Prevent Viewer Client Caching to direct the HTML Web Client Viewer to not cache page data on the client for a brief period of time. Preventing caching will negatively impact performance. Recommended setting is false."},
        new List<string> {"Enable-Retrieve-Transactions-Tooltip","Enables/disables retrieving transactions for the selected document."},
        new List<string> {"Sort-by-Document-ID-Tooltip","Sort by Document ID when using the Retrieve Transaction functionality."},
        new List<string> {"Admin-Security-Keywords-Tooltip","Globally toggles whether an admin can assign security keywords."},
        new List<string> {"Default-Workflow-Layout-Tooltip","Specifies the way in which the Workflow interface will display: horizontal, vertical, separateviewer, or selectable.  When set to selectable, users can choose the layout they prefer."},
        new List<string> {"Row-Coloring-Tooltip","Set to true to give every other row a shaded background in the document select list. Set to false to turn off row coloring."},
        new List<string> {"Folder-Tree-Width-Tooltip","The folder tree width, represented as a percentage. This value must end in %."},
        new List<string> {"Folder-Tree-Height-Tooltip","The folder tree height, represented as a percentage. This value must end in %."},
        new List<string> {"Document-List-Height-Tooltip","The document list height, represented as a percentage. This value must end in %."},
        new List<string> {"Folder-List-Height-Tooltip","The folder list height, represented as a percentage. This value must end in %."},
        new List<string> {"WorkView-Max-Results-Tooltip","The maximum number of objects displayed for unconstrained filter results."},
        new List<string> {"WorkView-Filter-Count-Tooltip","Displays object count for all filters."},
        new List<string> {"Display-Created-EForms-Tooltip","Select the 'View E-Form Before Creating' option by default when users create e-forms from within WorkView."},
        new List<string> {"Enable-Standalone-WorkView-Client-Tooltip",""},
        new List<string> {"Application-Enabler-Integration-Tooltip","Allows Application Enabler to work with the Web Client."},
        new List<string> {"Launch-Application-Enabler-Tooltip","Launches the Application Enabler client by default."},
        new List<string> {"Data-Mining-Tooltip","Enable Data Mining content menu"},
        new List<string> {"Data-Mining-Temp-Directory-Tooltip","Fully qualified path to the data mining temporary directory."},
        new List<string> {"Data-Mining-Report-Server-Name-Tooltip","Enter the server name (host name) for where the Data Mining Reports reside."},
        new List<string> {"Data-Mining-URL-Tooltip","Location of Rms.aspx."},
        new List<string> {"Additional-Models-Tooltip","Enter a semicolon-delimited list of fully qualified pathnames to external model files. Do not use any spaces."},
        new List<string> {"Allow-View-Source-Tooltip","Enables/disables view source."},
        new List<string> {"Platter-Management-Cache-Location-Tooltip","Location on the Web Server where the cache files will be stored."},
        new List<string> {"Platter-Management-Cache-Timeout-Tooltip","The amount of time, in minutes, that files will exist in the cache."},
        new List<string> {"Platter-Management-Cache-Size-Tooltip","Cache size in MB."},
        new List<string> {"Open-Rich-Text-Format-Documents-With-Microsoft-Word-Tooltip","Enable this option to open Rich Text Format Documents with Microsoft Word."},
        new List<string> {"Allow-Caching-Tooltip","Specifies whether caching should be enabled."},
        new List<string> {"Show-Previews-Tooltip","Specifies whether or not previews of the thumbnails should be displayed."},
        new List<string> {"User-Configurable-Tooltip","Specifies whether or not the user is able to configure options for the Thumbnail Hit List Viewer."},
        new List<string> {"Number-of-Columns-Tooltip","The number of columns for the Hit List."},
        new List<string> {"Maximum-Width-Tooltip","Maximum width, in pixels."},
        new List<string> {"Maximum-Height-Tooltip","Maximum height, in pixels."},
        new List<string> {"Preview-Maxiumum-Width-Tooltip","Maximum width for the preview, in pixels."},
        new List<string> {"Preview-Maxiumum-Height-Tooltip","Maximum height for the preview, in pixels."},
        new List<string> {"Use-FolderPop-Viewer-Tooltip","Set to true to use FolderPop as the Document Viewer within ACC."},
        new List<string> {"Prompt-with-Unread-DKT-Docs-Tooltip","When set to true, the user is prompted at login to review any unacknowledged documents in DKT."},
        new List<string> {"Internal-Mail-Timer-In-Seconds-Tooltip","This timer controls how often the Web Client checks for new Internal Mail messages if the \"Notify on New Mail\" user option is enabled. By default, it checks every 300 seconds (5 minutes). This is the minimum allowed value. Setting Internal Mail Timer to 0 will disable mail notifications for all users."},
        new List<string> {"Allowed-Function-Key-List-Tooltip","Comma separated list of function key shortcuts that should not be blocked or overridden by the Web Client."},
        new List<string> {"Max-JSON-Deserialized-Members-Tooltip","The maximum number of form keys, files, and JSON members that can be used in an HTTP request. This setting is used in StatusView when configuring Foldering and WorkView portlets."},
        new List<string> {"Validation-Settings-Unobtrusive-Validation-Mode-Tooltip",""},
        new List<string> {"OWIN-Automatic-App-Startup-Tooltip","Open Web Interface for .NET (OWIN) automatic app startup enables the Administrator System Message feature."},
        new List<string> {"Allow-Insecure-Connections-Tooltip","Allow non-HTTPS connections"},
        new List<string> {"Enabled-Legacy-Checksum-Fallback-Tooltip","Attempts to use the legacy checksum validation if the most recent validation fails to validate."},
        new List<string> {"Enable-Login-Autocomplete-Tooltip","Enable to have all login forms set as autocomplete on. Default value is false to have autocomplete off."},
        new List<string> {"Windows-Server-Locale-Format-Tooltip","Which version of Windows Server locale formats to use for data validation. A blank value will let the web client detect what version of Windows Server is running."},
        new List<string> {"Maximum-Import-Queue-Size-Tooltip","The number of documents to allow users to queue for import at a time. This value may not exceed 25, and may not be lower than 1."},
        new List<string> {"Enable-Browser-PDF-Viewer-Tooltip","Use PDF viewer provided by browser to view PDF documents, set to false will use onbase viewer. This setting will override user preferences setting. Leaving this value empty will allow users to choose which PDF viewer to use via user preferences"},
        new List<string> {"Ping-Timer-For-Scan-Service-Tooltip","The Scan Control Service using Desktop Host timeout value. The service will run indefinitely for 0 and negetive values."},
        new List<string> {"Use-Legacy-SharePoint-Authentication-Tooltip",""},
        new List<string> {"Multi-Form-Viewer-Origin-Tooltip","The origin from which the HMH Angular app which consumes MultiFormViewer is served."},
        new List<string> {"Enable-Export-Dashboard-Tooltip",""},
        new List<string> {"Enable-Export-Dashboard-Items-Tooltip",""},
        new List<string> {"Reporting-Page-Limit-Tooltip",""},
        //new List<string> {"Dashboard-Cache-Timeout-Tooltip",""},
        new List<string> {"Healthcare-Web-Viewer-Session-Timeout-Tooltip","Time (in minutes) before viewer will auto log out. (default: 30)"},
        new List<string> {"Healthcare-Web-Viewer-Data-Source-Tooltip","ODBC data source to use with the Healthcare Web Viewer. This value overrides value for key 'dmsDataSource' above."},
        new List<string> {"Healthcare-Web-Viewer-Enable-HTTP-Data-Source-Tooltip","Set to true to set the data source from the query string. This value overrides datasource and dmsDataSource. (default: false)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Deficiency-Viewing-Tooltip","Set to true to allow deficiency viewing. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Physician-Acknowledgement-Tooltip","Set to true to allow physician acknowledgment. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Document-Correction-Tooltip","Set to true to allow document corrections. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Read-Only-HTML-Forms-Tooltip","Allowed Values are \"all\", \"medical\", or \"none\". Set to All for all HTML Forms read only. Set to Medical for medical document type html forms read only. Set to none for no html forms read only. (default: all)"},
        new List<string> {"Healthcare-Web-Viewer-Read-Only-Unity-Forms-Tooltip","Allowed Values are \"all\", \"medical\", or \"none\". Set to All for all Unity Forms read only. Set to Medical for medical document type unity forms read only. Set to none for no unity forms read only. (default: all)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Tooltip","Set to true to allow the Epic Web Viewer COM integration to interop with Healthcare Web Viewer. (default: true)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Interoperability-Enabled-Tooltip","Set to true to allow the Epic Hyperdrive client's Scan Viewer integration to interop with Healthcare Web Viewer. (default: false)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Failed-Timeout-Tooltip","Time (in seconds) to wait for the document to load before sending the DisplayDocument message to Epic. (default: 10)"},
        new List<string> {"Healthcare-Web-Viewer-Enable-Epic-Web-Viewer-API-Display-Document-Message-Interval-Tooltip","Time (in seconds) to wait for Epic to send a response upon sending the DisplayDocument message. (default: 1)"},
        new List<string> {"Session-Timeout-Tooltip","Session timeout (in minutes) (minimum 2 minutes, maximum 1440 minutes)."},
        new List<string> {"Samesite-Cookie-Policy-Tooltip","The Web Server can use a strict, lax, or none policy for samesite cookies."},
        new List<string> {"Authentication-Mode-Tooltip",""},
        new List<string> {"HTTP-Runtime-Maximum-Request-Length-KB-Tooltip","Increase this setting if you need to upload large files."},
        new List<string> {"HTTP-Runtime-Execution-Timeout-Seconds-Tooltip","Execution timeout (in seconds) for requests to the Application Server."},
        new List<string> {"Max-Allowed-Content-Length-Tooltip","This setting only applies to IIS7. Both maxRequestLength and maxAllowedContentLength must be increased to allow large file uploads using IIS7."},
        new List<string> {"Tracing-Info-Level-Tooltip","This switch controls tracing globally through Hyland.Diagnostics.  It configures the level of information from Trace that is logged.  For no information set the value to zero. Set the value to 1, 2, 3, or 4 for minimal, normal, detailed, or verbose messages, respectively."},
        new List<string> {"Default-DocPop-Username-Tooltip","Default DocPop User Name"},
        new List<string> {"Default-DocPop-Password-Tooltip","Default DocPop Password"},
        new List<string> {"DocPop-Data-Source-Tooltip","ODBC data source to use with DocPop"},
        new List<string> {"Default-DocPop-Domain-Name-Tooltip","DocPop domain name (used with NT Authentication)"},
        new List<string> {"Default-DocPop-Institution-Tooltip","DocPop institution"},
        new List<string> {"Embedded-DocPop-Tooltip","Set to true when embedding DocPop in an Frame or IFrame."},
        new List<string> {"DocPop-Default-Login-Tooltip","Uses the web.config user name and password for DocPop login"},
        new List<string> {"DocPop-HTTP-Login-Tooltip","Get DocPop login credentials from the query string."},
        new List<string> {"DocPop-Auto-Login-Tooltip","Enables/disables DocPop auto login."},
        new List<string> {"DocPop-HTTP-Data-Source-Tooltip","Gets the DocPop data source from the query string."},
        new List<string> {"DocPop-Validate-Against-Checksum-Tooltip","Validate DocPop URLs against a checksum value."},
        new List<string> {"DocPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"DocPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"DocPop-Auto-Display-One-Document-Tooltip","If the search result contains a single document, only display the viewer and hide the select list."},
        new List<string> {"Disable-Context-Menus-in-DocPop-Tooltip","Set to true to disable context menus on Document Select and Viewer in DocPop."},
        new List<string> {"Encrypt-DocPop-Tooltip","Encrypt DocPop keys for enhanced security."},
        new List<string> {"Default-PdfPop-Username-Tooltip","Default PdfPop User Name"},
        new List<string> {"Default-PdfPop-Password-Tooltip","Default PdfPop Password"},
        new List<string> {"PdfPop-Data-Source-Tooltip","ODBC data source to use with PdfPop"},
        new List<string> {"Default-PdfPop-Domain-Name-Tooltip","PdfPop domain name (used with NT Authentication)"},
        new List<string> {"Default-PdfPop-Institution-Tooltip","PdfPop institution"},
        new List<string> {"Embedded-PdfPop-Tooltip","Set to true when embedding PdfPop in an Frame or IFrame."},
        new List<string> {"PdfPop-Default-Login-Tooltip","Uses the web.config user name and password for PdfPop login"},
        new List<string> {"PdfPop-HTTP-Login-Tooltip","Get PdfPop login credentials from the query string."},
        new List<string> {"PdfPop-Auto-Login-Tooltip","Enables/disables PdfPop auto login."},
        new List<string> {"PdfPop-HTTP-Data-Source-Tooltip","Gets the PdfPop data source from the query string."},
        new List<string> {"PdfPop-Validate-Against-Checksum-Tooltip","Validate PdfPop URLs against a checksum value."},
        new List<string> {"PdfPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"PdfPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"PdfPop-Auto-Display-One-Document-Tooltip","If the search result contains a single document, only display the viewer and hide the select list."},
        new List<string> {"Encrypt-PdfPop-Tooltip","Encrypt PdfPop keys for enhanced security."},
        new List<string> {"Default-FormPop-Username-Tooltip","Default FormPop User Name"},
        new List<string> {"Default-FormPop-Password-Tooltip","Default FormPop Password"},
        new List<string> {"FormPop-Data-Source-Tooltip","ODBC data source to use with FormPop"},
        new List<string> {"Default-FormPop-Domain-Name-Tooltip","FormPop domain name (used with NT Authentication)"},
        new List<string> {"Default-FormPop-Institution-Tooltip","FormPop institution"},
        new List<string> {"Embedded-FormPop-Tooltip","Set to true when embedding FormPop in an Frame or IFrame."},
        new List<string> {"FormPop-Default-Login-Tooltip","Uses the web.config user name and password for FormPop login"},
        new List<string> {"FormPop-HTTP-Login-Tooltip","Get FormPop login credentials from the query string."},
        new List<string> {"FormPop-Auto-Login-Tooltip","Enables/disables FormPop auto login."},
        new List<string> {"FormPop-HTTP-Data-Source-Tooltip","Gets the FormPop data source from the query string."},
        new List<string> {"FormPop-Validate-Against-Checksum-Tooltip","Validate FormPop URLs against a checksum value."},
        new List<string> {"FormPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"FormPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"FormPop-Auto-Display-One-Document-Tooltip","If the search result contains a single document, only display the viewer and hide the select list."},
        new List<string> {"Target-Origin-Tooltip",""},
        new List<string> {"Encrypt-FormPop-Tooltip","Encrypt FormPop keys for enhanced security."},
        new List<string> {"Default-FolderPop-Username-Tooltip","Default FolderPop User Name"},
        new List<string> {"Default-FolderPop-Password-Tooltip","Default FolderPop Password"},
        new List<string> {"FolderPop-Data-Source-Tooltip","ODBC data source to use with FolderPop"},
        new List<string> {"Default-FolderPop-Domain-Name-Tooltip","FolderPop domain name (used with NT Authentication)"},
        new List<string> {"Default-FolderPop-Institution-Tooltip","FolderPop institution"},
        new List<string> {"Embedded-FolderPop-Tooltip","Set to true when embedding FolderPop in an Frame or IFrame."},
        new List<string> {"FolderPop-Default-Login-Tooltip","Uses the web.config user name and password for FolderPop login"},
        new List<string> {"FolderPop-HTTP-Login-Tooltip","Get FolderPop login credentials from the query string."},
        new List<string> {"FolderPop-Auto-Login-Tooltip","Enables/disables FolderPop auto login."},
        new List<string> {"FolderPop-HTTP-Data-Source-Tooltip","Gets the FolderPop data source from the query string."},
        new List<string> {"FolderPop-Validate-Against-Checksum-Tooltip","Validate FolderPop URLs against a checksum value."},
        new List<string> {"FolderPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"FolderPop-Core-Query-API-License-Tooltip","Set to true to use Core Query API (retrievals per hour) license (must be licensed to use this option)."},
        new List<string> {"Encrypt-FolderPop-Tooltip","Encrypt FolderPop keys for enhanced security."},
        new List<string> {"PacketPop-Data-Source-Tooltip","ODBC data source to use with PacketPop."},
        new List<string> {"PacketPop-Validate-Against-Checksum-Tooltip","Validate PacketPop URLs against a checksum value."},
        new List<string> {"PacketPop-Checksum-Key-Tooltip","Enter a unique secret key used for checksum creation and validation. For successful validation, configuration of the key must match each component in the creation and validation process. A key is required when enabling checksums."},
        new List<string> {"LoginFormProc-Username-Tooltip","User name used for creating forms."},
        new List<string> {"LoginFormProc-Password-Tooltip","Password used for creating forms."},
        new List<string> {"LoginFormProc-Data-Source-Tooltip","ODBC data source name used when creating forms."},
        new List<string> {"LoginFormProc-Prompt-For-New-Form-Tooltip","Prompts the user to complete another form."},
        new List<string> {"Encrypt-LoginFormProc-Tooltip","Encrypt Login Form Proc keys for enhanced security."},
        new List<string> {"IdP-Server-Location-Tooltip","Identity Provider (IdP) URL"},
        new List<string> {"IdP-Tenant-Tooltip","Tenant"},
        new List<string> {"IdP-Client-Tooltip","Client"},
        new List<string> {"IdP-Secret-Tooltip","Client Secret"},
        new List<string> {"ADFS-Enabled-Tooltip",""},
        new List<string> {"Synchronize-User-Attributes-Tooltip",""},
        new List<string> {"Authentication-Only-Tooltip",""},
        new List<string> {"Cookie-Handler-Require-SSL-Tooltip",""},
        new List<string> {"Trusted-Issuer-Name-Tooltip",""},
        new List<string> {"wsFederation-Issuer-Tooltip","The URI of the token issuer. Also referred to as security token service (STS)."},
        new List<string> {"wsFederation-Realm-Tooltip","The URI of the requesting realm (Relying Party), which identifies the relying party (RP) to the security token service (STS)."},
        new List<string> {"Certificate-X509-Find-Type-Tooltip","Specifies the type of X.509 search to be executed."},
        new List<string> {"Certificate-Find-Value-Tooltip","Specifies the value to search for in the X.509 certificate store."},
        new List<string> {"Certificate-Store-Location-Tooltip","A StoreLocation value that specifies the location of the X.509 certificate store. The default value is \"LocalMachine\"."},
        new List<string> {"Certificate-Store-Name-Tooltip","The name of the X.509 certificate store. The default is \"My\"."},
        new List<string> {"Application-Script-Location-Tooltip",""},
        new List<string> {"Application-Keyword-ID-Tooltip",""},
        new List<string> {"Application-Keyword-Validator-Tooltip",""},
        new List<string> {"Page-Location-Tooltip",""},
        new List<string> {"Page-Script-Location-Tooltip",""},
        new List<string> {"Page-Keyword-ID-Tooltip",""},
        new List<string> {"Page-Keyword-Validator-Tooltip",""},
        new List<string> {"Enable-Healthcare-Web-Viewer-Tooltip",""},
        new List<string> {"KeywordTypeahead-KeywordIDNumber-Tooltip","The unique Keyword Type ID# for the keyword that you are wanting to target."},
        new List<string> {"KeywordTypeahead-TypeaheadCharacterCount-Tooltip","The minimum number of characters that will need to be typed in before the drop down field will start showing potential matches."},
        new List<string> {"NavPanel-ContextEnabled-Tooltip",""},
        new List<string> {"NavPanel-Icon-Tooltip",""},
        new List<string> {"NavPanel-DisplayOrder-Tooltip",""},
        new List<string> {"NavPanel-DisplayName-Tooltip",""},
        new List<string> {"NavPanel-Name-Tooltip",""}
    };


    /*
     ***********************************************************
     *     Generic Web Application Tooltip Data Structures
     ***********************************************************
     */
    private readonly Dictionary<string, string> DiagnosticSettingsTooltips = new Dictionary<string, string>
    {
        {"DiagnosticsSettings-TruncateLogValues-Tooltip","The number of characters to truncate log values to. The default value is 1024."},
        {"DiagnosticsSettings-WindowsEventLogging-SourceName-Tooltip","The name that is used when writing logs to the Windows Event Log logging."}
    };

    private readonly Dictionary<string, string> IisSettingsTooltips = new Dictionary<string, string>
    {
        {"IIS-Configuration-Application-Application-Pool-Tooltip",""},
        {"IIS-Configuration-Application-Default-Document-Tooltip",""},
        {"IIS-Configuration-Application-PreLoad-Enabled-Tooltip",""},
        {"IIS-Configuration-Application-Anonymous-Authentication-RootSpecific-Tooltip",""},
        {"IIS-Configuration-Application-ASPNET-Impersonation-RootSpecific-Tooltip",""},
        {"IIS-Configuration-Application-Windows-Authentication-RootSpecific-Tooltip",""},
        {"IIS-Configuration-Application-Use-Application-Pool-Credentials-Tooltip",""},
        {"Iis-Configuration-Application-AppPool-General-Net-CLR-Version-Tooltip",""},
        {"Iis-Configuration-Application-AppPool-General-Enable-32-Bit-Applications-Tooltip",""},
        {"Iis-Configuration-Application-AppPool-General-Managed-Pipeline-Mode-Tooltip",""},
        {"Iis-Configuration-Application-AppPool-General-Queue-Length-Tooltip",""},
        {"Iis-Configuration-Application-AppPool-General-Start-Mode-Tooltip",""},
        {"Iis-Configuration-Application-AppPool-Process-Model-Identity-Type-Tooltip",""},
        {"Iis-Configuration-Application-AppPool-Process-Model-Identity-Username-Tooltip",""},
        {"Iis-Configuration-Application-AppPool-Process-Model-Identity-Password-Tooltip",""},
        {"Iis-Configuration-Application-AppPool-Process-Model-Idle-Time-out-Tooltip",""},
        {"Iis-Configuration-Application-AppPool-Process-Model-Ping-Enabled-Tooltip",""},
        {"Iis-Configuration-Application-AppPool-Cpu-Limit-Interval-Tooltip",""},
        {"Iis-Configuration-Application-AppPool-Rapid-Fail-Protection-Enabled-Tooltip",""},
        {"Iis-Configuration-Application-AppPool-Regular-Time-Interval-Tooltip",""}
    };



    /*
     ***********************************************************
     *                      Methods!!!
     ***********************************************************
     */
    public Dictionary<string, string[,]> getWebApplicationSectionsTranslator(string type, string version)
    {
        Dictionary<string, Dictionary<string, string[,]>> allSectionDictionaries = new Dictionary<string, Dictionary<string, string[,]>>
        {
            { "AgendaOnline211SectionsTranslator", AgendaOnline211SectionsTranslator },
            { "ElectronicPlanReview211SectionsTranslator", ElectronicPlanReview211SectionsTranslator },
            { "GatewayCachingServer211SectionsTranslator", GatewayCachingServer211SectionsTranslator },
            { "HealthcareFormManager211SectionsTranslator", HealthcareFormManager211SectionsTranslator },
            { "PatientWindow211SectionsTranslator", PatientWindow211SectionsTranslator },
            { "PublicAccessLegacy211SectionsTranslator", PublicAccessLegacy211SectionsTranslator },
            { "PublicAccessNextGen211SectionsTranslator", PublicAccessNextGen211SectionsTranslator },
            { "ReportingViewer211SectionsTranslator", ReportingViewer211SectionsTranslator },
            { "ApplicationServer211SectionsTranslator", ApplicationServer211SectionsTranslator },
            { "WebServer211SectionsTranslator", WebServer211SectionsTranslator },
            { "AgendaOnline221SectionsTranslator", AgendaOnline221SectionsTranslator },
            { "ElectronicPlanReview221SectionsTranslator", ElectronicPlanReview221SectionsTranslator },
            { "GatewayCachingServer221SectionsTranslator", GatewayCachingServer221SectionsTranslator },
            { "HealthcareFormManager221SectionsTranslator", HealthcareFormManager221SectionsTranslator },
            { "PatientWindow221SectionsTranslator", PatientWindow221SectionsTranslator },
            { "PublicAccessNextGen221SectionsTranslator", PublicAccessNextGen221SectionsTranslator },
            { "ReportingViewer221SectionsTranslator", ReportingViewer221SectionsTranslator },
            { "ApplicationServer221SectionsTranslator", ApplicationServer221SectionsTranslator },
            { "WebServer221SectionsTranslator", WebServer221SectionsTranslator },
            { "AgendaOnline231SectionsTranslator", AgendaOnline231SectionsTranslator },
            { "ElectronicPlanReview231SectionsTranslator", ElectronicPlanReview231SectionsTranslator },
            { "GatewayCachingServer231SectionsTranslator", GatewayCachingServer231SectionsTranslator },
            { "HealthcareFormManager231SectionsTranslator", HealthcareFormManager231SectionsTranslator },
            { "PatientWindow231SectionsTranslator", PatientWindow231SectionsTranslator },
            { "PublicAccessNextGen231SectionsTranslator", PublicAccessNextGen231SectionsTranslator },
            { "ReportingViewer231SectionsTranslator", ReportingViewer231SectionsTranslator },
            { "ApplicationServer231SectionsTranslator", ApplicationServer231SectionsTranslator },
            { "WebServer231SectionsTranslator", WebServer231SectionsTranslator },
            { "AgendaOnline241SectionsTranslator", AgendaOnline241SectionsTranslator },
            { "ElectronicPlanReview241SectionsTranslator", ElectronicPlanReview241SectionsTranslator },
            { "HealthcareFormManager241SectionsTranslator", HealthcareFormManager241SectionsTranslator },
            { "PatientWindow241SectionsTranslator", PatientWindow241SectionsTranslator },
            { "PublicAccessNextGen241SectionsTranslator", PublicAccessNextGen241SectionsTranslator },
            { "ReportingViewer241SectionsTranslator", ReportingViewer241SectionsTranslator },
            { "ApplicationServer241SectionsTranslator", ApplicationServer241SectionsTranslator },
            { "WebServer241SectionsTranslator", WebServer241SectionsTranslator}
            // Add other dictionaries as needed
        };

        // Return the appropriate dictionary
        if (allSectionDictionaries.TryGetValue(type.Replace(" ", "").Replace("-","") + version + "SectionsTranslator", out var result))
        {
            return result;
        }
        else
        {
            throw new KeyNotFoundException($"No dictionary found with the key {type.Replace(" ", "").Replace("-", "") + version + "SectionsTranslator"}");
        }
    }

    public string getWebApplicationDataStructureDictionary(string type, string version)
    {
        Dictionary<string, Dictionary<string, List<List<string>>>> allDictionaries = new Dictionary<string, Dictionary<string, List<List<string>>>>
        {
            { "ApplicationServer211Translator", ApplicationServer211Translator },
            { "AgendaOnline211Translator", AgendaOnline211Translator },
            { "ElectronicPlanReview211Translator", ElectronicPlanReview211Translator },
            { "GatewayCachingServer211Translator", GatewayCachingServer211Translator },
            { "HealthcareFormManager211Translator", HealthcareFormManager211Translator },
            { "PatientWindow211Translator", PatientWindow211Translator },
            { "PublicAccessLegacy211Translator", PublicAccessLegacy211Translator },
            { "PublicAccessNextGen211Translator", PublicAccessNextGen211Translator },
            { "ReportingViewer211Translator", ReportingViewer211Translator },
            { "WebServer211Translator", WebServer211Translator },
            { "AgendaOnline221Translator", AgendaOnline221Translator },
            { "ApplicationServer221Translator", ApplicationServer221Translator },
            { "ElectronicPlanReview221Translator", ElectronicPlanReview221Translator },
            { "GatewayCachingServer221Translator", GatewayCachingServer221Translator },
            { "HealthcareFormManager221Translator", HealthcareFormManager221Translator },
            { "PatientWindow221Translator", PatientWindow221Translator },
            { "PublicAccessNextGen221Translator", PublicAccessNextGen221Translator },
            { "ReportingViewer221Translator", ReportingViewer221Translator },
            { "WebServer221Translator", WebServer221Translator },
            { "AgendaOnline231Translator", AgendaOnline231Translator },
            { "ElectronicPlanReview231Translator", ElectronicPlanReview231Translator },
            { "GatewayCachingServer231Translator", GatewayCachingServer231Translator },
            { "HealthcareFormManager231Translator", HealthcareFormManager231Translator },
            { "PatientWindow231Translator", PatientWindow231Translator },
            { "PublicAccessNextGen231Translator", PublicAccessNextGen231Translator },
            { "ReportingViewer231Translator", ReportingViewer231Translator },
            { "ApplicationServer231Translator", ApplicationServer231Translator },
            { "WebServer231Translator", WebServer231Translator },
            { "AgendaOnline241Translator", AgendaOnline241Translator },
            { "ElectronicPlanReview241Translator", ElectronicPlanReview241Translator },
            { "HealthcareFormManager241Translator", HealthcareFormManager241Translator },
            { "PatientWindow241Translator", PatientWindow241Translator },
            { "PublicAccessNextGen241Translator", PublicAccessNextGen241Translator },
            { "ReportingViewer241Translator", ReportingViewer241Translator },
            { "ApplicationServer241Translator", ApplicationServer241Translator },
            { "WebServer241Translator", WebServer241Translator }
            // Add other dictionaries as needed
        };

        // Return the appropriate dictionary
        if (allDictionaries.TryGetValue(type.Replace(" ", "").Replace("-","") + version + "Translator", out var result))
        {
            return JsonConvert.SerializeObject(result);
        }
        else
        {
            throw new KeyNotFoundException($"No dictionary found with the key {type.Replace(" ", "").Replace("-", "") + version + "Translator"}");
        }
    }

    public Dictionary<string, string[]> getCustomValidationPagesDictionary(string version)
    {
        Dictionary<string, Dictionary<string, string[]>> dictionaries = new Dictionary<string, Dictionary<string, string[]>>
        {
            { "customValidationPagesDictionary211", customValidationPagesDictionary211 },
            { "customValidationPagesDictionary221", customValidationPagesDictionary221 },
            { "customValidationPagesDictionary231", customValidationPagesDictionary231 },
            { "customValidationPagesDictionary241", customValidationPagesDictionary241 }
            // Add other dictionaries as needed
        };

        if(dictionaries.TryGetValue("customValidationPagesDictionary" + version, out var result))
        {
            return result;
        }
        else
        {
            throw new KeyNotFoundException($"No dictionary found with the key customValidationPagesDictionary{version}");
        }
    }

    public string[] getWebApplicationLoginPages(string type, string version)
    {
        Dictionary<string, string[]> dictionaries = new Dictionary<string, string[]>
        {
            { "ApplicationServer211LoginPages", ApplicationServer211LoginPages },
            { "ReportingViewer211LoginPages", ReportingViewer211LoginPages },
            { "WebServer211LoginPages", WebServer211LoginPages },
            { "ApplicationServer221LoginPages", ApplicationServer221LoginPages },
            { "ReportingViewer221LoginPages", ReportingViewer221LoginPages },
            { "WebServer221LoginPages", WebServer221LoginPages },
            { "ApplicationServer231LoginPages", ApplicationServer231LoginPages },
            { "ReportingViewer231LoginPages", ReportingViewer231LoginPages },
            { "WebServer231LoginPages", WebServer231LoginPages },
            { "ApplicationServer241LoginPages", ApplicationServer241LoginPages },
            { "ReportingViewer241LoginPages", ReportingViewer241LoginPages },
            { "WebServer241LoginPages", WebServer241LoginPages }
            // Add other dictionaries as needed
        };

        if (dictionaries.TryGetValue(type.Replace(" ", "").Replace("-", "") + version + "LoginPages", out var result))
        {
            return result;
        }
        else
        {
            throw new KeyNotFoundException($"No dictionary found with the key {type.Replace(" ", "").Replace("-", "") + version + "LoginPages"}");
        }
    }

    public string[] getDiagnosticsSettingsProfiles(string version)
    {
        Dictionary<string, string[]> dictionaries = new Dictionary<string, string[]>
        {
            { "diagnosticsSettingsProfiles211", diagnosticsSettingsProfiles211 },
            { "diagnosticsSettingsProfiles221", diagnosticsSettingsProfiles221 },
            { "diagnosticsSettingsProfiles231", diagnosticsSettingsProfiles231 },
            { "diagnosticsSettingsProfiles241", diagnosticsSettingsProfiles241 }
            // Add other dictionaries as needed
        };
        string majorVersion = version.Substring(0, version.IndexOf("."));
        string extraString = version.Substring(version.IndexOf(".") + 1);
        string minorVersion = extraString.Substring(0, extraString.IndexOf("."));

        if (dictionaries.TryGetValue("diagnosticsSettingsProfiles" + majorVersion + minorVersion, out var result))
        {
            return result;
        }
        else
        {
            throw new KeyNotFoundException($"No dictionary found with the key diagnosticsSettingsProfiles{version}");
        }
    }

    public List<string> getElementsToHideList(string type, string version)
    {
        Dictionary<string, List<string>> lists = new Dictionary<string, List<string>>
        {
            { "AgendaOnline211ElementsToHide", AgendaOnline211ElementsToHide },
            { "ApplicationServer211ElementsToHide", ApplicationServer211ElementsToHide },
            { "ElectronicPlanReview211ElementsToHide", ElectronicPlanReview211ElementsToHide },
            { "GatewayCachingServer211ElementsToHide", GatewayCachingServer211ElementsToHide },
            { "HealthcareFormManager211ElementsToHide", HealthcareFormManager211ElementsToHide },
            { "PatientWindow211ElementsToHide", PatientWindow211ElementsToHide },
            { "PublicAccessLegacy211ElementsToHide", PublicAccessLegacy211ElementsToHide },
            { "PublicAccessNextGen211ElementsToHide", PublicAccessNextGen211ElementsToHide },
            { "ReportingViewer211ElementsToHide", ReportingViewer211ElementsToHide },
            { "WebServer211ElementsToHide", WebServer211ElementsToHide },
            { "AgendaOnline221ElementsToHide", AgendaOnline221ElementsToHide },
            { "ApplicationServer221ElementsToHide", ApplicationServer221ElementsToHide },
            { "ElectronicPlanReview221ElementsToHide", ElectronicPlanReview221ElementsToHide },
            { "GatewayCachingServer221ElementsToHide", GatewayCachingServer221ElementsToHide },
            { "HealthcareFormManager221ElementsToHide", HealthcareFormManager221ElementsToHide },
            { "PatientWindow221ElementsToHide", PatientWindow221ElementsToHide },
            { "PublicAccessNextGen221ElementsToHide", PublicAccessNextGen221ElementsToHide },
            { "ReportingViewer221ElementsToHide", ReportingViewer221ElementsToHide },
            { "WebServer221ElementsToHide", WebServer221ElementsToHide },
            { "AgendaOnline231ElementsToHide", AgendaOnline231ElementsToHide },
            { "ApplicationServer231ElementsToHide", ApplicationServer231ElementsToHide },
            { "ElectronicPlanReview231ElementsToHide", ElectronicPlanReview231ElementsToHide },
            { "GatewayCachingServer231ElementsToHide", GatewayCachingServer231ElementsToHide },
            { "HealthcareFormManager231ElementsToHide", HealthcareFormManager231ElementsToHide },
            { "PatientWindow231ElementsToHide", PatientWindow231ElementsToHide },
            { "PublicAccessNextGen231ElementsToHide", PublicAccessNextGen231ElementsToHide },
            { "ReportingViewer231ElementsToHide", ReportingViewer231ElementsToHide },
            { "WebServer231ElementsToHide", WebServer231ElementsToHide },
            { "AgendaOnline241ElementsToHide", AgendaOnline241ElementsToHide },
            { "ApplicationServer241ElementsToHide", ApplicationServer241ElementsToHide },
            { "ElectronicPlanReview241ElementsToHide", ElectronicPlanReview241ElementsToHide },
            { "HealthcareFormManager241ElementsToHide", HealthcareFormManager241ElementsToHide },
            { "PatientWindow241ElementsToHide", PatientWindow241ElementsToHide },
            { "PublicAccessNextGen241ElementsToHide", PublicAccessNextGen241ElementsToHide },
            { "ReportingViewer241ElementsToHide", ReportingViewer241ElementsToHide },
            { "WebServer241ElementsToHide", WebServer241ElementsToHide }
            // Add other lists as needed
        };

        if (lists.TryGetValue(type.Replace(" ", "").Replace("-", "") + version + "ElementsToHide", out var result))
        {
            return result;
        }
        else
        {
            throw new KeyNotFoundException($"No dictionary found with the key {type.Replace(" ", "").Replace("-", "") + version + "ElementsToHide"}");
        }
    }

    public List<string> getElementsToSave(string type, string version)
    {
        Dictionary<string, List<string>> elements = new Dictionary<string, List<string>>
        {
            { "AgendaOnline211ElementsToSave", AgendaOnline211ElementsToSave },
            { "ApplicationServer211ElementsToSave", ApplicationServer211ElementsToSave },
            { "ElectronicPlanReview211ElementsToSave", ElectronicPlanReview211ElementsToSave },
            { "GatewayCachingServer211ElementsToSave", GatewayCachingServer211ElementsToSave },
            { "HealthcareFormManager211ElementsToSave", HealthcareFormManager211ElementsToSave },
            { "PatientWindow211ElementsToSave", PatientWindow211ElementsToSave },
            { "PublicAccessLegacy211ElementsToSave", PublicAccessViewerLegacy211ElementsToSave },
            { "PublicAccessNextGen211ElementsToSave", PublicAccessViewerNextGen211ElementsToSave },
            { "ReportingViewer211ElementsToSave", ReportingViewer211ElementsToSave },
            { "WebServer211ElementsToSave", WebServer211ElementsToSave },
            { "AgendaOnline221ElementsToSave", AgendaOnline221ElementsToSave },
            { "ApplicationServer221ElementsToSave", ApplicationServer221ElementsToSave },
            { "ElectronicPlanReview221ElementsToSave", ElectronicPlanReview221ElementsToSave },
            { "GatewayCachingServer221ElementsToSave", GatewayCachingServer221ElementsToSave },
            { "HealthcareFormManager221ElementsToSave", HealthcareFormManager221ElementsToSave },
            { "PatientWindow221ElementsToSave", PatientWindow221ElementsToSave },
            { "PublicAccessNextGen221ElementsToSave", PublicAccessViewerNextGen221ElementsToSave },
            { "ReportingViewer221ElementsToSave", ReportingViewer221ElementsToSave },
            { "WebServer221ElementsToSave", WebServer221ElementsToSave },
            { "AgendaOnline231ElementsToSave", AgendaOnline231ElementsToSave },
            { "ApplicationServer231ElementsToSave", ApplicationServer231ElementsToSave },
            { "ElectronicPlanReview231ElementsToSave", ElectronicPlanReview231ElementsToSave },
            { "GatewayCachingServer231ElementsToSave", GatewayCachingServer231ElementsToSave },
            { "HealthcareFormManager231ElementsToSave", HealthcareFormManager231ElementsToSave },
            { "PatientWindow231ElementsToSave", PatientWindow231ElementsToSave },
            { "PublicAccessNextGen231ElementsToSave", PublicAccessViewerNextGen231ElementsToSave },
            { "ReportingViewer231ElementsToSave", ReportingViewer231ElementsToSave },
            { "WebServer231ElementsToSave", WebServer231ElementsToSave },
            { "AgendaOnline241ElementsToSave", AgendaOnline241ElementsToSave },
            { "ApplicationServer241ElementsToSave", ApplicationServer241ElementsToSave },
            { "ElectronicPlanReview241ElementsToSave", ElectronicPlanReview241ElementsToSave },
            { "HealthcareFormManager241ElementsToSave", HealthcareFormManager241ElementsToSave },
            { "PatientWindow241ElementsToSave", PatientWindow241ElementsToSave },
            { "PublicAccessNextGen241ElementsToSave", PublicAccessViewerNextGen241ElementsToSave },
            { "ReportingViewer241ElementsToSave", ReportingViewer241ElementsToSave },
            { "WebServer241ElementsToSave", WebServer241ElementsToSave }
        };

        if (elements.TryGetValue(type.Replace(" ", "").Replace("-", "") + version + "ElementsToSave", out var result))
        {
            return result;
        }
        else
        {
            throw new KeyNotFoundException($"No dictionary found with the key {type.Replace(" ", "").Replace("-", "") + version + "ElementsToSave"}");
        }
    }

    public List<List<string>> getTooltips(string type, string version)
    {
        Dictionary<string, List<List<string>>> elements = new Dictionary<string, List<List<string>>>
        {
            { "AgendaOnline211Tooltips", AgendaOnline211Tooltips },
            { "ApplicationServer211Tooltips", ApplicationServer211Tooltips },
            { "ElectronicPlanReview211Tooltips", ElectronicPlanReview211Tooltips },
            { "GatewayCachingServer211Tooltips", GatewayCachingServer211Tooltips },
            { "HealthcareFormManager211Tooltips", HealthcareFormManager211Tooltips },
            { "PatientWindow211Tooltips", PatientWindow211Tooltips },
            { "PublicAccessLegacy211Tooltips", PublicAccessLegacy211Tooltips },
            { "PublicAccessNextGen211Tooltips", PublicAccessNextGen211Tooltips },
            { "ReportingViewer211Tooltips", ReportingViewer211Tooltips },
            { "WebServer211Tooltips", WebServer211Tooltips },
            { "AgendaOnline221Tooltips", AgendaOnline221Tooltips },
            { "ApplicationServer221Tooltips", ApplicationServer221Tooltips },
            { "ElectronicPlanReview221Tooltips", ElectronicPlanReview221Tooltips },
            { "GatewayCachingServer221Tooltips", GatewayCachingServer221Tooltips },
            { "HealthcareFormManager221Tooltips", HealthcareFormManager221Tooltips },
            { "PatientWindow221Tooltips", PatientWindow221Tooltips },
            { "PublicAccessNextGen221Tooltips", PublicAccessNextGen221Tooltips },
            { "ReportingViewer221Tooltips", ReportingViewer221Tooltips },
            { "WebServer221Tooltips", WebServer221Tooltips },
            { "AgendaOnline231Tooltips", AgendaOnline231Tooltips },
            { "ApplicationServer231Tooltips", ApplicationServer231Tooltips },
            { "ElectronicPlanReview231Tooltips", ElectronicPlanReview231Tooltips },
            { "GatewayCachingServer231Tooltips", GatewayCachingServer231Tooltips },
            { "HealthcareFormManager231Tooltips", HealthcareFormManager231Tooltips },
            { "PatientWindow231Tooltips", PatientWindow231Tooltips },
            { "PublicAccessNextGen231Tooltips", PublicAccessNextGen231Tooltips },
            { "ReportingViewer231Tooltips", ReportingViewer231Tooltips },
            { "WebServer231Tooltips", WebServer231Tooltips },
            { "AgendaOnline241Tooltips", AgendaOnline241Tooltips },
            { "ApplicationServer241Tooltips", ApplicationServer241Tooltips },
            { "ElectronicPlanReview241Tooltips", ElectronicPlanReview241Tooltips },
            { "HealthcareFormManager241Tooltips", HealthcareFormManager241Tooltips },
            { "PatientWindow241Tooltips", PatientWindow241Tooltips },
            { "PublicAccessNextGen241Tooltips", PublicAccessNextGen241Tooltips },
            { "ReportingViewer241Tooltips", ReportingViewer241Tooltips },
            { "WebServer241Tooltips", WebServer241Tooltips }
        };

        if (elements.TryGetValue(type.Replace(" ", "").Replace("-", "") + version + "Tooltips", out var result))
        {
            return result;
        }
        else
        {
            throw new KeyNotFoundException($"No dictionary found with the key {type.Replace(" ", "").Replace("-", "") + version + "Tooltips"}");
        }
    }

    public Dictionary<string,string> getGenericWebApplicationTooltips(string type, string version)
    {
        List<string> diagnosticsSettingsWebApplications = new List<string>
        {
            "Application Server",
            "Agenda Online",
            "Electronic Plan Review",
            "Gateway Caching Server",
            "Healthcare Form Manager",
            "Patient Window",
            "Reporting Viewer",
            "Web Server"
        };

        Dictionary<string, string> elements = IisSettingsTooltips;

        if (diagnosticsSettingsWebApplications.Contains(type))
        {
            foreach(var tooltip in DiagnosticSettingsTooltips)
            {
                elements.Add(tooltip.Key, tooltip.Value);
            }
        }

        return elements;
    }
}
