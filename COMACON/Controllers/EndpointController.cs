using COMACON.config;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using System.Text.Json;
using Serilog;
using Newtonsoft.Json;
using System.Collections;
using System.Diagnostics;
using Microsoft.Web.Administration;

namespace COMACON.Controllers
{
    [Route("api/Endpoint")]
    [ApiController]
    public class EndpointController : ControllerBase
    {
        private readonly Core Core;
        private readonly LoadSaveWebApplications LoadSaveWebApplications;
        private static string tnsOracle = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL={0})(HOST={1})(PORT={2}))(CONNECT_DATA=(SERVICE_NAME={3})));";
        private static string noTnsOracle = "Data Source={0};";
        private static string userIdAndPassword = "User Id={0};Password={1};";
        private readonly IConfiguration _configuration;

        public EndpointController(Core core,
            LoadSaveWebApplications loadSaveWebApplications,
            IConfiguration configuration)
        {
            Core = core;
            LoadSaveWebApplications = loadSaveWebApplications;
            _configuration = configuration;
        }

        // GET: api/Endpoint/TestConnectionString
        [HttpGet("TestConnectionString")]
        public string TestConnectionString(string cstringobject)
        {
            Log.Logger.Verbose("Testing connection string.");

            ConnectionString cstring = JsonConvert.DeserializeObject<ConnectionString>(cstringobject.ToString());
            TestConnectionStringResult result = new TestConnectionStringResult();

            if (string.Equals(cstring.Provider, "System.Data.SqlClient"))
            {
                string cstringSql = "Data Source=" + cstring.sql.DataSource + ";database=" + cstring.sql.Database + ";";
                if (string.Equals(cstring.IntegratedSecurity, "True", StringComparison.CurrentCultureIgnoreCase))
                {
                    cstringSql += "Integrated Security=True;";
                }
                else
                {
                    cstringSql += string.Format(userIdAndPassword, cstring.UserId, cstring.Password);
                }
                cstringSql += cstring.AdditionalOptions;
                Console.WriteLine(cstringSql);

                try
                {
                    using (SqlConnection connection = new SqlConnection(cstringSql))
                    {
                        connection.Open();
                        result.ResultCode = "0";
                        result.ResultMessage = "Connection successful!";
                        return JsonConvert.SerializeObject(result);
                    }
                }
                catch (Exception ex)
                {
                    Log.Logger.Error("Connection failed: {ex}", ex);
                    result.ResultCode = "1";
                    result.ResultMessage = "SQL connection failed: " + ex.Message;
                    return JsonConvert.SerializeObject(result);
                }
            }
            else
            {
                string cstringOracle = "";
                if (string.Equals(cstring.oracle.TNSConnectionString, "True", StringComparison.CurrentCultureIgnoreCase))
                {
                    cstringOracle += string.Format(tnsOracle, cstring.oracle.Protocol, cstring.oracle.Host, cstring.oracle.Port, cstring.oracle.Database);
                    if (string.Equals(cstring.IntegratedSecurity, "True", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cstringOracle += "User Id=/;";
                    }
                    else
                    {
                        cstringOracle += string.Format(userIdAndPassword, cstring.UserId, cstring.Password);
                    }
                    cstringOracle += cstring.AdditionalOptions;

                    try
                    {
                        using (OracleConnection connection = new OracleConnection(cstringOracle))
                        {
                            connection.Open();
                            result.ResultCode = "0";
                            result.ResultMessage = "Connection successful!";
                            //return JsonConvert.SerializeObject(@"{""ResultCode"":""0"",""ResultMessage"":""Connection successful!""}");
                            return JsonConvert.SerializeObject(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Logger.Error("Oracle Connection failed: {ex}", ex);
                        result.ResultCode = "1";
                        result.ResultMessage = "Oracle connection failed: " + ex.Message;
                        Console.WriteLine(JsonConvert.SerializeObject(@"{""ResultCode"":""1"",""ResultMessage"":""Oracle connection failed: " + ex.Message.Replace("\n", " ") + @"""}"));
                        return JsonConvert.SerializeObject(result);
                    }
                }
                else
                {
                    cstringOracle = string.Format(noTnsOracle, cstring.oracle.Host);
                    if (string.Equals(cstring.IntegratedSecurity, "True", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cstringOracle += "User Id= /";
                    }
                    else
                    {
                        cstringOracle += string.Format(userIdAndPassword, cstring.UserId, cstring.Password);
                    }
                    cstringOracle += cstring.AdditionalOptions;

                    try
                    {
                        using (OracleConnection connection = new OracleConnection(cstringOracle))
                        {
                            connection.Open();
                            //return JsonConvert.SerializeObject(@"{""ResultCode"":""0"",""ResultMessage"":""Connection successful!""}");
                            return JsonConvert.SerializeObject(result);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Logger.Error("Oracle Connection failed: {ex}", ex);
                        result.ResultCode = "1";
                        result.ResultMessage = "Oracle connection failed: " + ex.Message;
                        return JsonConvert.SerializeObject(result);
                    }
                }
            }
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
            return LoadSaveWebApplications.SaveWebApplicationConfiguration(jsonDataStructure.ToString());
        }

        [HttpPost("TestSqlConnectionString")]
        public string TestSqlConnectionString(string DataSource, string Database, bool IntegratedSecurity, string Username, string Password, string AdditionalParameters)
        {
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

        [HttpGet("GetNewConfigurationDetails")]
        public string GetNewConfigurationDetails()
        {
            string[] majorVersions = Directory.GetDirectories(_configuration["LooseFilesLocation"]);
            NewConfigurationDetails newConfigurationDetails = new NewConfigurationDetails();

            foreach (string majorVersionPath in majorVersions)
            {
                string majorVersion = Path.GetFileName(majorVersionPath);

                //Create the new VersionGroup object.
                VersionGroup versionGroup = new VersionGroup();
                //Set the major version variable.
                versionGroup.majorVersion = majorVersion;
                //Add the versionGroup object to the newConfigurationDetails object.
                newConfigurationDetails.webApplicationConfiguration.versionGroups.Add(versionGroup);

                string majorVersionFolderPath = Path.Combine(_configuration["LooseFilesLocation"], majorVersion);
                string[] specificVersionPaths = Directory.GetDirectories(majorVersionFolderPath);
                foreach (string specificVersionPath in specificVersionPaths)
                {
                    string specificVersion = Path.GetFileName(specificVersionPath);

                    //Create the new Ver object.
                    Ver ver = new Ver();
                    //Set the specific version variable.
                    ver.specificVersion = specificVersion;
                    //Add the ver object to the versionGroup object.
                    versionGroup.versions.Add(ver);

                    string[] webApplicationPaths = Directory.GetDirectories(specificVersionPath);
                    foreach (string webApplicationPath in webApplicationPaths)
                    {
                        string webApplicationName = Path.GetFileName(webApplicationPath);

                        //Create the new WebApp object.
                        WebApp webApp = new WebApp();
                        //Set the web application variable.
                        webApp.webApplicationName = webApplicationName;
                        //Add the webApp object to the ver object.
                        ver.webApplications.Add(webApp);
                    }
                }
            }

            ServerManager serverManager = new ServerManager();
            foreach (Site site in serverManager.Sites)
            {
                //Create the new WebSiteDetails object.
                WebSiteDetails siteObject = new WebSiteDetails();
                //Set the siteName variable.
                siteObject.siteName = site.Name;
                //Add the site object to the newConfigurationDetails object.
                newConfigurationDetails.webApplicationConfiguration.webSiteDetails.Add(siteObject);
                //string physicalPath = site.Applications["/"].VirtualDirectories["/"].PhysicalPath;
                foreach(VirtualDirectory virtualDirectory in site.Applications["/"].VirtualDirectories)
                {
                    //Checks if the virtual directory is the root directory.
                    if (virtualDirectory.Path == "/")
                    {
                        //Add the virtual directory path to the site object.
                        siteObject.virtualDirectories.Add("root");
                    }
                    else
                    {
                        //Add the virtual directory path to the site object.
                        siteObject.virtualDirectories.Add(virtualDirectory.Path);
                    }
                }
            }
            
            Console.WriteLine(JsonConvert.SerializeObject(newConfigurationDetails));

            return JsonConvert.SerializeObject(newConfigurationDetails);
        }

        [HttpPut("CheckNewWebApplicationDuplicates")]
        public string CheckNewWebApplicationDuplicates([FromBody] JsonElement webApplicationToCreate)
        {
            Console.WriteLine(webApplicationToCreate);
            /* Returns the results of the checks.
             * 0 = Success
             * 1 = Folder already exists
             * 2 = Application already exists
             * 3 = Application Pool already exists
             */
            WebApplicationToCreate webAppToCreate = JsonConvert.DeserializeObject<WebApplicationToCreate>(webApplicationToCreate.ToString());
            if(webAppToCreate.virtualDirectory == "root")
            {
                webAppToCreate.virtualDirectory = "/";
            }
            ServerManager manager = new ServerManager();
            var filesToCopyFromPath = Path.Combine(_configuration["LooseFilesLocation"], webAppToCreate.webApplicationVersion.Split(".")[0] + webAppToCreate.webApplicationVersion.Split(".")[1], webAppToCreate.webApplicationVersion);
            //string siteFolder = manager.Sites[webAppToCreate.siteName].Applications["/"].VirtualDirectories[webAppToCreate.virtualDirectory].Attributes["physicalPath"].Value.ToString();
            var folderToCopyToPath = Path.Combine(Environment.ExpandEnvironmentVariables(manager.Sites[webAppToCreate.siteName].Applications["/"].VirtualDirectories[webAppToCreate.virtualDirectory].Attributes["physicalPath"].Value.ToString()), webAppToCreate.webApplicationName);
            //Verify if the folder already exists.
            if (Directory.Exists(folderToCopyToPath))
            {
                return "1";
            }

            //Verify if the Application already exists.
            try
            {
                if (manager.Sites[webAppToCreate.siteName].Applications[webAppToCreate.webApplicationName] != null)
                {
                    return "2";
                }
            }
            catch
            {
                
            }

            //Verify if the Application Pool already exists.
            try
            {
                if (manager.ApplicationPools[webAppToCreate.webApplicationPoolName] != null)
                {
                    return "3";
                }
            }
            catch
            {
                
            }

            return "0";
        }

        [HttpPost("CreateNewWebApplication")]
        public string CreateNewWebApplication(string action, [FromBody] JsonElement webApplicationToCreate)
        {
            
            switch (action)
            {
                case "FromFile":
                    break;
                case "FromScratch":
                    WebApplicationToCreate webAppToCreate = JsonConvert.DeserializeObject<WebApplicationToCreate>(webApplicationToCreate.ToString());
                    ServerManager manager = new ServerManager();
                    var filesToCopyFromPath = Path.Combine(_configuration["LooseFilesLocation"], webAppToCreate.webApplicationVersion.Split(".")[0]+ webAppToCreate.webApplicationVersion.Split(".")[1], webAppToCreate.webApplicationVersion);
                    //string siteFolder = manager.Sites[webAppToCreate.siteName].Applications["/"].VirtualDirectories[webAppToCreate.virtualDirectory].Attributes["physicalPath"].Value.ToString();
                    var folderToCopyToPath = Path.Combine(Environment.ExpandEnvironmentVariables(manager.Sites[webAppToCreate.siteName].Applications["/"].VirtualDirectories[webAppToCreate.virtualDirectory].Attributes["physicalPath"].Value.ToString()),webAppToCreate.webApplicationName);
                    //Verify if the folder already exists.
                    if (Directory.Exists(folderToCopyToPath))
                    {
                        return "1";
                    }

                    //Verify if the Application
                    break;
            }

            return "";
        }
    }
}
