﻿using COMACON.config;
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
        private readonly Core Core;
        private readonly LoadSaveWebApplications LoadSaveWebApplications;

        public EndpointController(Core core,
            LoadSaveWebApplications loadSaveWebApplications)
        {
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
            return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
        }

        [HttpGet("GetApplications")]
        public string GetApplications()
        {
            return Core.RetrieveWebApplications();
        }

        [HttpGet("DuplicateAppPoolCheck")]
        public Boolean DuplicateAppPoolCheck(string appPoolName)
        {
            return Core.CheckDuplicateWebApplicationPool(appPoolName);
        }

        [HttpGet("DuplicateApplicationCheck")]
        public Boolean DuplicateApplicationCheck(string applicationName,
                string siteName,
                string applicationPath,
                string physicalPath,
                string currentApplicationName)
        {
            return Core.CheckDuplicateWebApplication(physicalPath, applicationName, siteName, applicationPath, currentApplicationName);
        }

        [HttpGet("CopyWebApplication")]
        public string? CopyApplication(string webApplicationType, string newApplicationPoolName, string newApplicationName, string newApplicationPathName, string newApplicationSiteName, string newApplicationServerUrl, string currentApplicationPoolName, string currentApplicationName, string currentApplicationPathName, string currentSiteName, string currentPhysicalPath, string webApplicationVersion, string bitness)
        {
            string newPhysicalPath = Core.CopyWebApplication(newApplicationPoolName, newApplicationName, newApplicationPathName, newApplicationSiteName, newApplicationServerUrl, currentApplicationPoolName, currentApplicationName, currentApplicationPathName, currentSiteName, currentPhysicalPath);
            var file = new StreamReader(newPhysicalPath + @"\web.config");

            return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, webApplicationType, webApplicationVersion, newApplicationSiteName, newApplicationName, newApplicationPathName, newPhysicalPath, bitness);
        }

        [HttpPost("SaveWebApplication")]
        public string SaveWebApplication([FromBody] JsonElement jsonDataStructure)
        {
            //Console.WriteLine(jsonDataStructure);
            return LoadSaveWebApplications.SaveWebApplicationConfiguration(jsonDataStructure.ToString());
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
