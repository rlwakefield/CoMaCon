﻿using COMACONTranslationToHelperUtility;
using Newtonsoft.Json;

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
                {"Hyland.Web.DashboardViewer","reportPagingLimit","value","2","Reporting-Page-Limit","50","","",""},
                {"Hyland.Web.DashboardViewer","dashboardCacheTimeoutSeconds","value","2","Dashboard-Cache-Timeout","2","","",""}
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
                {"Hyland.Web.DashboardViewer","reportPagingLimit","value","2","Reporting-Page-Limit","50","","",""},
                {"Hyland.Web.DashboardViewer","dashboardCacheTimeoutSeconds","value","2","Dashboard-Cache-Timeout","2","","",""}
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
        "Allowed-Domain-SectionElement"
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
        "Allowed-Domain-SectionElement"
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
        "Allowed-Domain-SectionElement"
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
        "Dashboard-Cache-Timeout-SettingElement",
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
}
