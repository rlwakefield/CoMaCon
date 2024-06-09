using COMACON.config;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using System.Text.Json;
using Serilog;

namespace COMACON.Controllers
{
    [Route("api/Endpoint")]
    [ApiController]
    public class EndpointController : ControllerBase
    {
        private readonly ApplicationServerConfiguration ApplicationServerConfiguration;
        private readonly AgendaOnlineServerConfiguration AgendaOnlineServerConfiguration;
        private readonly ElectronicPlanReviewConfiguration ElectronicPlanReviewConfiguration;
        private readonly GatewayCachingServerConfiguration GatewayCachingServerConfiguration;
        private readonly HealthcareFormManagerConfiguration HealthcareFormManagerConfiguration;
        private readonly OnBasePatientWindowConfiguration OnBasePatientWindowConfiguration;
        private readonly PublicAccessViewerLegacyConfiguration PublicAccessViewerLegacyConfiguration;
        private readonly PublicAccessViewerNextGenConfiguration PublicAccessViewerNextGenConfiguration;
        private readonly ReportingViewerConfiguration ReportingViewerConfiguration;
        private readonly WebServerConfiguration WebServerConfiguration;
        private readonly Core Core;
        private readonly LoadSaveWebApplications LoadSaveWebApplications;

        public EndpointController(ApplicationServerConfiguration applicationServerConfiguration,
            AgendaOnlineServerConfiguration agendaOnlineServerConfiguration,
            ElectronicPlanReviewConfiguration electronicPlanReviewConfiguration,
            GatewayCachingServerConfiguration gatewayCachingServerConfiguration,
            HealthcareFormManagerConfiguration healthcareFormManagerConfiguration,
            OnBasePatientWindowConfiguration onBasePatientWindowConfiguration,
            PublicAccessViewerLegacyConfiguration publicAccessViewerLegacyConfiguration,
            PublicAccessViewerNextGenConfiguration publicAccessViewerNextGenConfiguration,
            ReportingViewerConfiguration reportingViewerConfiguration,
            WebServerConfiguration webServerConfiguration,
            Core core,
            LoadSaveWebApplications loadSaveWebApplications)
        {
            ApplicationServerConfiguration = applicationServerConfiguration;
            AgendaOnlineServerConfiguration = agendaOnlineServerConfiguration;
            ElectronicPlanReviewConfiguration = electronicPlanReviewConfiguration;
            GatewayCachingServerConfiguration = gatewayCachingServerConfiguration;
            HealthcareFormManagerConfiguration = healthcareFormManagerConfiguration;
            OnBasePatientWindowConfiguration = onBasePatientWindowConfiguration;
            PublicAccessViewerLegacyConfiguration = publicAccessViewerLegacyConfiguration;
            PublicAccessViewerNextGenConfiguration = publicAccessViewerNextGenConfiguration;
            ReportingViewerConfiguration = reportingViewerConfiguration;
            WebServerConfiguration = webServerConfiguration;
            Core = core;
            LoadSaveWebApplications = loadSaveWebApplications;
        }

        // GET: api/Endpoint/UrlValidation
        [HttpGet("UrlValidation")]
        public int TestUrl(Uri url)
        {
            Log.Logger.Verbose("Validating \"{url}\" URL.", url);
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = url;
                client.Timeout = TimeSpan.FromSeconds(5);
                var response = client.GetAsync(url);
                Log.Logger.Verbose("Received a {0} response code.", response);
                return (int)response.Result.StatusCode;
            }
            catch (TaskCanceledException ex)
            {
                Log.Logger.Error("The endpoint didn't respond after 5 seconds..", ex);
                return -1;
            }
            catch
            {
                //Any exception will returns 0.
                Log.Logger.Error("Received an error of some sort with the URL.");
                return 0;
            }
        }

        [HttpGet("GetConfiguration")]
        public string GetConfiguration(string webconfig, string type, string version, string siteName, string applicationName, string applicationPath, string physicalPath, string bitness)
        {
            using var file = new System.IO.StreamReader(webconfig);

            switch (type)
            {
                case "Agenda Online":
                    //return AgendaOnlineServerConfiguration.LoadAgendaOnlineServerConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                    return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                case "Application Server":
                    //return ApplicationServerConfiguration.LoadApplicationServerConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                    return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                case "Electronic Plan Review":
                    //return ElectronicPlanReviewConfiguration.LoadElectronicPlanReviewConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                    return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                case "Gateway Caching Server":
                    //return GatewayCachingServerConfiguration.LoadGatewayCachingServerConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                    return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                case "Healthcare Form Manager":
                    //return HealthcareFormManagerConfiguration.LoadHealthcareFormManagerConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                    return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                case "Patient Window":
                    //return OnBasePatientWindowConfiguration.LoadOnBasePatientWindowConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                    return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                case "Public Access - Legacy":
                    //return PublicAccessViewerLegacyConfiguration.LoadPublicAccessViewerLegacyConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                    return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                case "Public Access - Next Gen":
                    //return PublicAccessViewerNextGenConfiguration.LoadPublicAccessViewerNextGenConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                    return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                case "Reporting Viewer":
                    //return ReportingViewerConfiguration.LoadReportingViewerConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                    return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                case "Web Server":
                    //return WebServerConfiguration.LoadWebServerConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
                    return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
            }

            return null;
        }

        [HttpGet("GetApplications")]
        public string GetApplications()
        {
            return Core.RetrieveWebApplications();
            //return WebApplications.Parse();
        }

        [HttpGet("DuplicateAppPoolCheck")]
        public Boolean DuplicateAppPoolCheck(string appPoolName)
        {
            return Core.CheckDuplicateWebApplicationPool(appPoolName);
            //return WebApplicationPoolDupChecker.Parse(appPoolName);
        }

        [HttpGet("DuplicateApplicationCheck")]
        public Boolean DuplicateApplicationCheck(string applicationName,
                string siteName,
                string applicationPath,
                string physicalPath,
                string currentApplicationName)
        {
            return Core.CheckDuplicateWebApplication(physicalPath, applicationName, siteName, applicationPath, currentApplicationName);
            //return WebApplicationDupChecker.Parse(physicalPath, applicationName, siteName, applicationPath, currentApplicationName);
        }

        [HttpGet("CopyWebApplication")]
        public string? CopyApplication(string webApplicationType, string newApplicationPoolName, string newApplicationName, string newApplicationPathName, string newApplicationSiteName, string newApplicationServerUrl, string currentApplicationPoolName, string currentApplicationName, string currentApplicationPathName, string currentSiteName, string currentPhysicalPath, string webApplicationVersion, string bitness)
        {
            //string newPhysicalPath = WebServerWebApplicationCopy.Parse(newApplicationPoolName, newApplicationName, newApplicationPathName, newApplicationSiteName, newApplicationServerUrl, currentApplicationPoolName, currentApplicationName, currentApplicationPathName, currentSiteName, currentPhysicalPath);
            string newPhysicalPath = Core.CopyWebApplication(newApplicationPoolName, newApplicationName, newApplicationPathName, newApplicationSiteName, newApplicationServerUrl, currentApplicationPoolName, currentApplicationName, currentApplicationPathName, currentSiteName, currentPhysicalPath);
            var file = new StreamReader(newPhysicalPath + @"\web.config");

            switch (webApplicationType)
            {
                case "Application Server":
                    return ApplicationServerConfiguration.LoadApplicationServerConfiguration(file, webApplicationType, webApplicationVersion, newApplicationSiteName, newApplicationName, newApplicationPathName, newPhysicalPath, bitness);
                case "Agenda Online":
                    return AgendaOnlineServerConfiguration.LoadAgendaOnlineServerConfiguration(file, webApplicationType, webApplicationVersion, newApplicationSiteName, newApplicationName, newApplicationPathName, newPhysicalPath, bitness);
                case "Electronic Plan Review":
                    return ElectronicPlanReviewConfiguration.LoadElectronicPlanReviewConfiguration(file, webApplicationType, webApplicationVersion, newApplicationSiteName, newApplicationName, newApplicationPathName, newPhysicalPath, bitness);
                case "Gateway Caching Server":
                    return GatewayCachingServerConfiguration.LoadGatewayCachingServerConfiguration(file, webApplicationType, webApplicationVersion, newApplicationSiteName, newApplicationName, newApplicationPathName, newPhysicalPath, bitness);
                case "Healthcare Form Manager":
                    return HealthcareFormManagerConfiguration.LoadHealthcareFormManagerConfiguration(file, webApplicationType, webApplicationVersion, newApplicationSiteName, newApplicationName, newApplicationPathName, newPhysicalPath, bitness);
                case "Patient Window":
                    return OnBasePatientWindowConfiguration.LoadOnBasePatientWindowConfiguration(file, webApplicationType, webApplicationVersion, newApplicationSiteName, newApplicationName, newApplicationPathName, newPhysicalPath, bitness);
                case "Public Access - Legacy":
                    return PublicAccessViewerLegacyConfiguration.LoadPublicAccessViewerLegacyConfiguration(file, webApplicationType, webApplicationVersion, newApplicationSiteName, newApplicationName, newApplicationPathName, newPhysicalPath, bitness);
                case "Public Access - Next Gen":
                    return PublicAccessViewerNextGenConfiguration.LoadPublicAccessViewerNextGenConfiguration(file, webApplicationType, webApplicationVersion, newApplicationSiteName, newApplicationName, newApplicationPathName, newPhysicalPath, bitness);
                case "Reporting Viewer":
                    return ReportingViewerConfiguration.LoadReportingViewerConfiguration(file, webApplicationType, webApplicationVersion, newApplicationSiteName, newApplicationName, newApplicationPathName, newPhysicalPath, bitness);
                case "Web Server":
                    return WebServerConfiguration.LoadWebServerConfiguration(file, webApplicationType, webApplicationVersion, newApplicationSiteName, newApplicationName, newApplicationPathName, newPhysicalPath, bitness);
            }

            return null;
        }

        [HttpPost("SaveWebApplication")]
        public string SaveWebApplication([FromBody] JsonElement jsonDataStructure)
        {
            //Console.WriteLine(jsonDataStructure);
            var jsonObject = JObject.Parse(jsonDataStructure.ToString());
            switch (jsonObject["Type"].ToString())
            {
                case "Application Server":
                    return ApplicationServerConfiguration.SaveApplicationServerConfiguration(jsonDataStructure.ToString());
                case "Agenda Online":
                    return AgendaOnlineServerConfiguration.SaveAgendaOnlineServerConfiguration(jsonDataStructure.ToString());
                case "Electronic Plan Review":
                    return ElectronicPlanReviewConfiguration.SaveElectronicPlanReviewConfiguration(jsonDataStructure.ToString());
                case "Gateway Caching Server":
                    return GatewayCachingServerConfiguration.SaveGatewayCachingServerConfiguration(jsonDataStructure.ToString());
                case "Healthcare Form Manager":
                    return HealthcareFormManagerConfiguration.SaveHealthcareFormManagerConfiguration(jsonDataStructure.ToString());
                case "Patient Window":
                    return OnBasePatientWindowConfiguration.SaveOnBasePatientWindowConfiguration(jsonDataStructure.ToString());
                case "Public Access - Legacy":
                    return PublicAccessViewerLegacyConfiguration.SavePublicAccessViewerLegacyConfiguration(jsonDataStructure.ToString());
                case "Public Access - Next Gen":
                    return PublicAccessViewerNextGenConfiguration.SavePublicAccessViewerNextGenConfiguration(jsonDataStructure.ToString());
                case "Reporting Viewer":
                    return ReportingViewerConfiguration.SaveReportingViewerServerConfiguration(jsonDataStructure.ToString());
                case "Web Server":
                    return WebServerConfiguration.SaveWebServerConfiguration(jsonDataStructure.ToString());
                default:
                    return "200";
            }
        }

        [HttpPost("TestSqlConnectionString")]
        public string TestSqlConnectionString(string DataSource, string Database, bool IntegratedSecurity, string Username, string Password, string AdditionalParameters)
        {
            /*Data Source = Test; database = Test; Integrated Security = True*/
            string cstringSql = "Data Source=" + DataSource + ";database=" + Database + ";";
            if (IntegratedSecurity)
            {
                cstringSql += "Integrated Security=True";
            }
            else
            {
                cstringSql += "User Id=" + Username + ";Password=" + Password;
            }
            cstringSql += AdditionalParameters;

            try
            {
                using (SqlConnection connection = new SqlConnection(cstringSql))
                {
                    connection.Open();
                    return "Connection successful!";
                }
            }
            catch (Exception ex)
            {
                return "Connection failed: " + ex.ToString();
            }
        }

        [HttpPost("TestOracleConnectionString")]
        public string TestOracleConnectionString(bool TnsConnectionString, string Host, string Database, string Protocol, string Port, bool IntegratedSecurity, string Username, string Password, string AdditionalOptions)
        {
            string cstringOracle = "";
            if (TnsConnectionString)
            {

            }

            if (IntegratedSecurity)
            {
                cstringOracle += "Integrated Security=True";
            }
            else
            {
                cstringOracle += "User Id=" + Username + ";Password=" + Password;
            }
            cstringOracle += AdditionalOptions;

            try
            {
                using (OracleConnection connection = new OracleConnection(cstringOracle))
                {
                    connection.Open();
                    return "Oracle Connection successful!";
                }
            }
            catch (Exception ex)
            {
                return "Oracle Connection failed: " + ex.ToString();
            }
        }
    }
}
