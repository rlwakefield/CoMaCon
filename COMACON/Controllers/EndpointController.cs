using COMACON.config;
using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using System.Text.Json;
using Serilog;
using Newtonsoft.Json;
//using System.Collections;
//using System.Diagnostics;
using Microsoft.Web.Administration;
using System.Text.Json.Nodes;
using System.ComponentModel.DataAnnotations;
//using System.IO;
//using Microsoft.AspNetCore.Builder;
using System.Web;
using COMACON.DatabaseContexts.SQLite;

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
        private readonly SqlQueries _SqlQueries;
        private readonly SessionManagement _sessionManagement;
        private static string authorizationResponse = "{\"error\":\"@errorNumber\",\"message\":\"@errorMessage\",\"timestamp\":\"\"}";
        private static string genericResponse = "{\"result\":\"@result\",\"message\":\"@message\"}";
        private readonly COMACONSqliteDbContext _context;
        private readonly IWebHostEnvironment _webhostenvironment;

        public EndpointController(Core core,
            LoadSaveWebApplications loadSaveWebApplications,
            IConfiguration configuration,
            SessionManagement sessionManagement,
            SqlQueries sqlQueries,
            COMACONSqliteDbContext context,
            IWebHostEnvironment webhostenvironment)
        {
            Core = core;
            LoadSaveWebApplications = loadSaveWebApplications;
            _configuration = configuration;
            _sessionManagement = sessionManagement;
            _SqlQueries = sqlQueries;
            _context = context;
            _webhostenvironment = webhostenvironment;
        }

        // GET: api/Endpoint/GetRootUrl
        [HttpGet("GetRootUrl")]
        public string GetRootUrl()
        {
            Log.Logger.Information("Getting root URL.");
            var request = HttpContext.Request;
            var scheme = request.Scheme;
            Log.Logger.Information("Path: " + request.Path);
            Log.Logger.Information("BasePath: " + request.PathBase);
            var host = request.Host.ToUriComponent();
            var pathbase = request.PathBase.ToUriComponent();

            var rootUrl = "";

            if (_webhostenvironment.EnvironmentName == "Development")
            {
                rootUrl = $"{scheme}://{host}";
            }
            else
            {
                rootUrl = $"{scheme}://{host}{pathbase}";
            }
            Log.Logger.Information($"The root URL is {rootUrl}.");

            return "{\"rooturl\":\""+rootUrl+"\"}";
        }

        /**************************************
        *      Authentication Endpoints
        **************************************/
        // POST: api/Endpoint/Authentication
        [HttpPost("Authentication")]
        public IActionResult Authentication([FromBody] JsonElement credentials)
        {
            /* Returns the results of the Creation.
            * 0 = Success
            * 1 = Username missing.
            * 2 = Password missing.
            * 3 = Username or password does not match.
            * 4 = Multiple users found with the same username and password.
            */
            string username = credentials.GetProperty("username").ToString();
            string password = credentials.GetProperty("password").ToString();

            //Checks if the username field is an empty string or not.
            if (username == "")
            {
                Log.Logger.Warning("Username is required.");
                return BadRequest(authorizationResponse.Replace("@errorNumber", "1").Replace("@errorMessage", "Username is required."));
            }

            if (password == "")
            {
                Log.Logger.Warning("Password is required.");
                return BadRequest(authorizationResponse.Replace("@errorNumber", "2").Replace("@errorMessage", "Password is required."));
            }

            JsonNode validationResults = JsonNode.Parse(_sessionManagement.ValidateUserLoggingIn(username, password));

            switch (validationResults["error"].ToString())
            {
                case "0":
                    Log.Logger.Information("User is authenticated.");
                    return Ok(_sessionManagement.generateAccessToken(validationResults["message"].ToString()));
                default:
                    Log.Logger.Warning("User is not authenticated.");
                    Log.Logger.Warning("Error: {error}", validationResults["error"].ToString());
                    Log.Logger.Warning("Message: {message}", validationResults["message"].ToString());
                    return Unauthorized(authorizationResponse.Replace("@errorNumber", validationResults["error"].ToString()).Replace("@errorMessage", validationResults["message"].ToString()));
            }
        }

        // GET: api/Endpoint/VerifyToken
        [HttpGet("VerifyToken")]
        public IActionResult VerifyToken([FromHeader(Name = "Authorization")] string authorizationHeader)
        {
            //string rooturl = GetRootUrl();
            //Console.WriteLine("Root URL: " + rooturl);
            //JsonDocument jsonDocument = JsonDocument.Parse(rooturl);
            //Console.WriteLine("Root URL Value: " + jsonDocument.RootElement.GetProperty("rooturl"));
            //Console.WriteLine("Root URL Value: " + JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl"));

            if (string.IsNullOrEmpty(authorizationHeader))
            {
                Log.Logger.Warning("No authorization token provided.");
                return Redirect(JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl") + "/core/login");
            }

            if (!authorizationHeader.StartsWith("Bearer "))
            {
                Log.Logger.Warning("Invalid authorization token type.");
                return Redirect(JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl") + "/core/login");
            }

            JsonNode validationResults = JsonNode.Parse(_sessionManagement.validateAccessTokenStillActive(authorizationHeader.Substring("Bearer ".Length).Trim()));

            switch(validationResults["error"].ToString())
            {
                case "0":
                    Log.Logger.Information("Token is still active.");
                    return Ok(validationResults);
                default:
                    Log.Logger.Warning("Token is expired.");
                    return Unauthorized(JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl") + "/core/login");
            }
        }

        // GET: api/Endpoint/Logout
        [HttpGet("Logout")]
        public IActionResult Logout([FromHeader(Name = "Authorization")] string authorizationHeader)
        {
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                Log.Logger.Warning("No authorization token provided.");
                return Unauthorized("No authorization token provided.");
            }

            if (!authorizationHeader.StartsWith("Bearer "))
            {
                Log.Logger.Warning("Invalid authorization token type.");
                return Unauthorized("Invalid authorization token type.");
            }

            JsonNode validationResults = JsonNode.Parse(_sessionManagement.validateAccessTokenStillActive(authorizationHeader.Substring("Bearer ".Length).Trim()));

            switch (validationResults["error"].ToString())
            {
                case "0":
                    Log.Logger.Information("Logging out user.");

                    _sessionManagement.logoutUser(authorizationHeader.Substring("Bearer ".Length).Trim());
                    return Redirect(JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl") + "/core/login");
                default:
                    Log.Logger.Warning("Token is expired.");
                    return Unauthorized(authorizationResponse.Replace("@errorNumber", validationResults["error"].ToString()).Replace("@errorMessage", validationResults["message"].ToString()));
            }
        }

        // POST: api/Endpoint/ResetPassword
        [HttpPost("ResetPassword")]
        public IActionResult ResetPassword([FromBody] JsonElement credentials)
        {
            string username = credentials.GetProperty("username").ToString();
            string currentpassword = credentials.GetProperty("currentpassword").ToString();
            string newPassword = credentials.GetProperty("newpassword").ToString();
            string errorReturnText = "{\"error\":\"@errorNumber\",\"message\":\"@errorMessage\"}";

            if (string.Equals(currentpassword, newPassword))
            {
                Log.Logger.Warning("New password cannot be the same as the current password.");
                return BadRequest(errorReturnText.Replace("@errorNumber", "4").Replace("@errorMessage", "New password cannot be the same as the current password."));
            }

            //Checks if the username field is an empty string or not.
            if (username == "")
            {
                Log.Logger.Warning("Username is required.");
                return BadRequest(errorReturnText.Replace("@errorNumber", "1").Replace("@errorMessage", "Username is required."));
            }

            if (currentpassword == "")
            {
                Log.Logger.Warning("Password is required.");
                return BadRequest(errorReturnText.Replace("@errorNumber", "2").Replace("@errorMessage", "Password is required."));
            }

            if (newPassword == "")
            {
                Log.Logger.Warning("New Password is required.");
                return BadRequest(errorReturnText.Replace("@errorNumber", "3").Replace("@errorMessage", "New Password is required."));
            }

            JsonNode passwordresetresults = JsonNode.Parse(_sessionManagement.ResetPassword(username, currentpassword, newPassword));

            if(passwordresetresults["error"].ToString() == "0")
            {
                Log.Logger.Information("Password reset successful.");
                return Ok();
            }
            else
            {
                Log.Logger.Warning("Password reset failed.");
                return BadRequest(passwordresetresults);
            }
        }

        //POST: api/Endpoint/ForgotPassword
        [HttpPost("ForgotPassword")]
        public IActionResult ForgotPassword([FromBody] JsonElement credentials)
        {
            string username = credentials.GetProperty("username").ToString();
            string emailaddress = credentials.GetProperty("emailaddress").ToString();
            string errorReturnText = "{\"error\":\"@errorNumber\",\"message\":\"@errorMessage\",\"timestamp\":}";

            //Checks if the username field is an empty string or not.
            if (username == "")
            {
                Log.Logger.Warning("Username is required.");
                return BadRequest(errorReturnText.Replace("@errorNumber", "1").Replace("@errorMessage", "Username is required."));
            }

            if (emailaddress == "")
            {
                Log.Logger.Warning("Email Address is required.");
                return BadRequest(errorReturnText.Replace("@errorNumber", "2").Replace("@errorMessage", "Email Address is required."));
            }

            JsonNode passwordresetresults = JsonNode.Parse(_sessionManagement.ForgotPasswordRequest(username, emailaddress, _configuration));

            if (passwordresetresults["error"].ToString() == "0")
            {
                Log.Logger.Information("Password reset successful.");
                return Ok(passwordresetresults);
            }
            else
            {
                Log.Logger.Warning("Password reset failed.");
                return BadRequest(passwordresetresults);
            }
        }


        /**************************************
         * Settings - User Management Endpoints
         **************************************/
        // GET: api/Endpoint/GetUser
        [HttpGet("GetUser")]
        public IActionResult GetUser([FromHeader(Name = "Authorization")] string authorization, [Required] string version, string usernum = "0")
        {
            if(version == "v1")
            {
                if (string.IsNullOrEmpty(authorization))
                {
                    Log.Logger.Warning("No authorization token provided.");
                    return Unauthorized("No authorization token provided.");
                }

                if (!authorization.StartsWith("Bearer "))
                {
                    Log.Logger.Warning("Invalid authorization token type.");
                    return Unauthorized("Invalid authorization token type.");
                }

                JsonNode validationResults = JsonNode.Parse(_sessionManagement.validateAccessTokenStillActive(authorization.Substring("Bearer ".Length).Trim()));

                if (validationResults["error"].ToString() != "0")
                {
                    Log.Logger.Warning("Token is expired. ");
                    return Unauthorized("Token is expired. ");
                }

                int unum = 0;
                try
                {
                    unum = int.Parse(usernum);
                }
                catch
                {
                    Log.Logger.Warning("Invalid user number.");
                    return BadRequest("Invalid user number.");
                }

                Log.Logger.Information("Getting user with user number: {unum}", unum);
                return Ok(_SqlQueries.GetUser(unum));
            }
            else
            {
                Log.Logger.Error("Invalid version number.");
                return BadRequest("Invalid version number.");
            }
        }

        // GET: api/Endpoint/GetAllUsers
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers([FromHeader(Name = "Authorization")] string authorization, [Required] string version)
        {
            if (version == "v1")
            {
                if (string.IsNullOrEmpty(authorization))
                {
                    Log.Logger.Warning("No authorization token provided.");
                    return Unauthorized("No authorization token provided.");
                }

                if (!authorization.StartsWith("Bearer "))
                {
                    Log.Logger.Warning("Invalid authorization token type.");
                    return Unauthorized("Invalid authorization token type.");
                }

                JsonNode validationResults = JsonNode.Parse(_sessionManagement.validateAccessTokenStillActive(authorization.Substring("Bearer ".Length).Trim()));

                if (validationResults["error"].ToString() != "0")
                {
                    Log.Logger.Warning("Token is expired.");
                    return Unauthorized("Token is expired. ");
                }

                try
                {
                    Log.Logger.Information("Getting all users.");
                    return Ok(_SqlQueries.GetAllUsers());
                }
                catch (Exception ex)
                {
                    Log.Logger.Error("Bad Request: " + ex.Message);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                return BadRequest("Invalid version number.");
            }
        }

        // GET: api/Endpoint/UpdateUser
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromHeader(Name = "Authorization")] string authorization, [Required] string version, [FromBody] JsonElement user)
        {
            if (version == "v1")
            {
                if (string.IsNullOrEmpty(authorization))
                {
                    return Unauthorized("No authorization token provided.");
                }

                if (!authorization.StartsWith("Bearer "))
                {
                    return Unauthorized("Invalid authorization token type.");
                }

                JsonNode validationResults = JsonNode.Parse(_sessionManagement.validateAccessTokenStillActive(authorization.Substring("Bearer ".Length).Trim()));

                if (validationResults["error"].ToString() != "0")
                {
                    return Unauthorized("Token is expired.");
                }

                try
                {
                    User userObject = JsonConvert.DeserializeObject<User>(user.ToString());
                    return Ok(_SqlQueries.UpdateUser(userObject, _sessionManagement.getUserSessionUserNum(authorization.Substring("Bearer ".Length).Trim())));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                    Log.Logger.Error(ex.Message);
                    Log.Logger.Error(ex.StackTrace);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                Log.Logger.Error("Invalid version number.");
                return BadRequest("Invalid version number.");
            }
        }

        // GET: api/Endpoint/GetRoles
        [HttpGet("GetRoles")]
        public IActionResult GetRoles([FromHeader(Name = "Authorization")] string authorization, [Required] string version)
        {
            switch (version)
            {
                case "v1":
                    return Ok(_SqlQueries.GetRoles());
                default:
                    Log.Logger.Error("Invalid version number.");
                    return BadRequest("Invalid version number.");
            }
        }

        // POST: api/Endpoint/CreateUser
        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromHeader(Name = "Authorization")] string authorization, [Required] string version, [FromBody] JsonElement user)
        {
            if (version == "v1")
            {
                if (string.IsNullOrEmpty(authorization))
                {
                    Log.Logger.Warning("No authorization token provided.");
                    return Unauthorized("No authorization token provided.");
                }

                if (!authorization.StartsWith("Bearer "))
                {
                    Log.Logger.Warning("Invalid authorization token type.");
                    return Unauthorized("Invalid authorization token type.");
                }

                JsonNode validationResults = JsonNode.Parse(_sessionManagement.validateAccessTokenStillActive(authorization.Substring("Bearer ".Length).Trim()));

                if (validationResults["error"].ToString() != "0")
                {
                    Log.Logger.Warning("Token is expired.");
                    return Unauthorized("Token is expired.");
                }

                //Need to add code to query the database to validate that the username doesn't exist.

                try
                {
                    User userObject = JsonConvert.DeserializeObject<User>(user.ToString());
                    return Ok(_SqlQueries.CreateUser(userObject, _sessionManagement.getUserSessionUserNum(authorization.Substring("Bearer ".Length).Trim())));
                }
                catch (Exception ex)
                {
                    Log.Logger.Error(ex.Message);
                    Log.Logger.Error(ex.StackTrace);
                    return BadRequest(ex.Message);
                }
            }
            else
            {
                Log.Logger.Error("Invalid version number.");
                return BadRequest("Invalid version number.");
            }
        }


        /**************************************
         *    Settings - General Endpoints
         **************************************/
        // GET: api/Endpoint/GetPasswordPolicies
        [HttpGet("GetPasswordPolicies")]
        public IActionResult GetPasswordPolicies(string version,
            [FromHeader(Name = "Authorization")] string authorization)
        {
            if (string.IsNullOrEmpty(authorization))
            {
                Log.Logger.Warning("No authorization token provided.");
                return Redirect(JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl") + "/core/login");
            }

            if (!authorization.StartsWith("Bearer "))
            {
                Log.Logger.Warning("Invalid authorization token type.");
                return Redirect(JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl") + "/core/login");
            }

            JsonNode validationResults = JsonNode.Parse(_sessionManagement.validateAccessTokenStillActive(authorization.Substring("Bearer ".Length).Trim()));

            if (validationResults["error"].ToString() != "0")
            {
                Log.Logger.Warning("Token is expired.");
                return Redirect(JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl") + "/core/login");
            }

            switch (version)
            {
                case "v1":
                    try
                    {
                        return Ok(_SqlQueries.GetAllPasswordPolicies());
                    }
                    catch (Exception ex)
                    {
                        Log.Logger.Error("Error: " + ex.Message);
                        Log.Logger.Error(ex.StackTrace);
                        return BadRequest(ex.Message);
                    }
                default:
                    Log.Logger.Error("Invalid version number.");
                    return BadRequest("Invalid version number.");
            }
        }

        // GET: api/Endpoint/TestConnectionString
        [HttpGet("TestConnectionString")]
        public IActionResult TestConnectionString(string cstringobject,
            [FromHeader(Name = "Authorization")] string authorization)
        {
            if(string.IsNullOrEmpty(authorization))
            {
                Log.Logger.Warning("No authorization token provided.");
                return Redirect(JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl") + "/core/login");
            }

            if(!authorization.StartsWith("Bearer "))
            {
                Log.Logger.Warning("Invalid authorization token type.");
                return Redirect(JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl") + "/core/login");
            }

            JsonNode validationResults = JsonNode.Parse(_sessionManagement.validateAccessTokenStillActive(authorization.Substring("Bearer ".Length).Trim()));

            if(validationResults["error"].ToString() != "0")
            {
                Log.Logger.Warning("Token is expired.");
                return Redirect(JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl") + "/core/login");
            }

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

                try
                {
                    using (SqlConnection connection = new SqlConnection(cstringSql))
                    {
                        connection.Open();
                        result.ResultCode = "0";
                        result.ResultMessage = "Connection successful!";
                        return Ok(JsonConvert.SerializeObject(result));
                    }
                }
                catch (Exception ex)
                {
                    Log.Logger.Error("Connection failed: {ex}", ex);
                    result.ResultCode = "1";
                    result.ResultMessage = "SQL connection failed: " + ex.Message;
                    return Ok(JsonConvert.SerializeObject(result));
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
                            return Ok(JsonConvert.SerializeObject(result));
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Logger.Error("Oracle Connection failed: {ex}", ex);
                        result.ResultCode = "1";
                        result.ResultMessage = "Oracle connection failed: " + ex.Message;
                        return Ok(JsonConvert.SerializeObject(result));
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
                            return Ok(JsonConvert.SerializeObject(result));
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Logger.Error("Oracle Connection failed: {ex}", ex);
                        result.ResultCode = "1";
                        result.ResultMessage = "Oracle connection failed: " + ex.Message;
                        return Ok(JsonConvert.SerializeObject(result));
                    }
                }
            }
        }

        // GET: api/Endpoint/UrlValidation
        [HttpGet("UrlValidation")]
        public async Task<IActionResult> TestUrl(Uri url,
            [FromHeader(Name = "Authorization")] string authorization)
        {
            if (string.IsNullOrEmpty(authorization))
            {
                Log.Logger.Warning("No authorization token provided.");
                return Redirect(JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl") + "/core/login");
            }

            if (!authorization.StartsWith("Bearer "))
            {
                Log.Logger.Warning("Invalid authorization token type.");
                return Redirect(JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl") + "/core/login");
            }

            JsonNode validationResults = JsonNode.Parse(_sessionManagement.validateAccessTokenStillActive(authorization.Substring("Bearer ".Length).Trim()));

            if (validationResults["error"].ToString() != "0")
            {
                Log.Logger.Warning("Token is expired.");
                return Redirect(JsonDocument.Parse(GetRootUrl()).RootElement.GetProperty("rooturl") + "/core/login");
            }

            Log.Logger.Verbose("Validating \"{url}\" URL.", url.ToString());

            HttpClient client = new HttpClient();
            client.BaseAddress = url;
            client.Timeout = TimeSpan.FromSeconds(5);

            try
            {
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException("Failed to connect.");
                }

                Log.Logger.Verbose("Received a success response from {url}.", url);
                return Ok(genericResponse.Replace("@result","0").Replace("@message", ""));
            }
            catch (HttpRequestException ex)
            {
                // You can also log the error or return a specific error message
                string errorResponse = genericResponse.Replace("@result", "-1")
                                                       .Replace("@message", ex.Message);
                return BadRequest(errorResponse);
            }
        }

        [HttpGet("GetConfiguration")]
        public string GetConfiguration(string type,
            string version,
            string siteName,
            string applicationName,
            string applicationPath,
            string bitness,
            [FromHeader(Name = "Authorization")] string authorizationHeader = "",
            string physicalPath = "",
            string webconfig = "")
        {
            ServerManager manager = new ServerManager();
            if(webconfig == "")
            {
                webconfig = Path.Combine(Environment.ExpandEnvironmentVariables(manager.Sites[siteName].Applications["/"].VirtualDirectories[applicationPath].Attributes["physicalPath"].Value.ToString()), applicationName,"web.config");
                physicalPath = Environment.ExpandEnvironmentVariables(manager.Sites[siteName].Applications[applicationPath+applicationName].VirtualDirectories["/"].PhysicalPath);
            }
            using var file = new System.IO.StreamReader(webconfig);
            return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, type, version, siteName, applicationName, applicationPath, physicalPath, bitness);
        }

        [HttpGet("GetApplications")]
        public string GetApplications([FromHeader(Name = "Authorization")] string authorizationHeader = "")
        {
            return Core.RetrieveWebApplications();
        }

        [HttpGet("DuplicateAppPoolCheck")]
        public Boolean DuplicateAppPoolCheck(string appPoolName,
            [FromHeader(Name = "Authorization")] string authorizationHeader = "")
        {
            return Core.CheckDuplicateWebApplicationPool(appPoolName);
        }

        [HttpGet("DuplicateApplicationCheck")]
        public Boolean DuplicateApplicationCheck(string applicationName,
            string siteName,
            string applicationPath,
            string physicalPath,
            string currentApplicationName,
            [FromHeader(Name = "Authorization")] string authorizationHeader = "")
        {
            return Core.CheckDuplicateWebApplication(physicalPath, applicationName, siteName, applicationPath, currentApplicationName);
        }

        [HttpGet("CopyWebApplication")]
        public string? CopyApplication(string webApplicationType,
            string newApplicationPoolName,
            string newApplicationName,
            string newApplicationPathName,
            string newApplicationSiteName,
            string newApplicationServerUrl,
            string currentApplicationPoolName,
            string currentApplicationName,
            string currentApplicationPathName,
            string currentSiteName,
            string currentPhysicalPath,
            string webApplicationVersion,
            string bitness,
            [FromHeader(Name = "Authorization")] string authorizationHeader = "")
        {
            string newPhysicalPath = Core.CopyWebApplication(newApplicationPoolName, newApplicationName, newApplicationPathName, newApplicationSiteName, newApplicationServerUrl, currentApplicationPoolName, currentApplicationName, currentApplicationPathName, currentSiteName, currentPhysicalPath);
            var file = new StreamReader(newPhysicalPath + @"\web.config");

            return LoadSaveWebApplications.LoadWebApplicationConfiguration(file, webApplicationType, webApplicationVersion, newApplicationSiteName, newApplicationName, newApplicationPathName, newPhysicalPath, bitness);
        }

        [HttpPost("SaveWebApplication")]
        public string SaveWebApplication([FromBody] JsonElement jsonDataStructure,
            [FromHeader(Name = "Authorization")] string authorizationHeader = "")
        {
            return LoadSaveWebApplications.SaveWebApplicationConfiguration(jsonDataStructure.ToString());
        }

        [HttpPost("TestSqlConnectionString")]
        public string TestSqlConnectionString(string DataSource,
            string Database,
            bool IntegratedSecurity,
            string Username,
            string Password,
            string AdditionalParameters,
            [FromHeader(Name = "Authorization")] string authorizationHeader = "")
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
        public string TestOracleConnectionString(bool TnsConnectionString,
            string Host,
            string Database,
            string Protocol,
            string Port,
            bool IntegratedSecurity,
            string Username,
            string Password,
            string AdditionalOptions,
            [FromHeader(Name = "Authorization")] string authorizationHeader = "")
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
        public string GetNewConfigurationDetails([FromHeader(Name = "Authorization")] string authorizationHeader = "")
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
            
            return JsonConvert.SerializeObject(newConfigurationDetails);
        }

        [HttpPut("CheckNewWebApplicationDuplicates")]
        public string CheckNewWebApplicationDuplicates([FromBody] JsonElement webApplicationToCreate,
            [FromHeader(Name = "Authorization")] string authorizationHeader = "")
        {
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
        public string CreateNewWebApplication(string action,
            [FromBody] JsonElement webApplicationToCreate,
            [FromHeader(Name = "Authorization")] string authorizationHeader = "")
        {
            Log.Information("Action being performed: {action}", action);
            /* Returns the results of the Creation.
             * 0 = Success
             * 1 = Failed to create the directory.
             * 2 = Failed to copy the files.
             * 3 = Failed to create the Application Pool.
             * 4 = Failed to create the Application.
             * 5 = Failed to set the SessionAdmin.asmx authentication settings.
             */
            switch (action)
            {
                case "FromFile":
                    break;
                case "FromScratch":
                    WebApplicationToCreate webAppToCreate = JsonConvert.DeserializeObject<WebApplicationToCreate>(webApplicationToCreate.ToString());
                    if (webAppToCreate.virtualDirectory == "root")
                    {
                        webAppToCreate.virtualDirectory = "/";
                    }
                    ServerManager manager = new ServerManager();
                    var filesToCopyFromPath = Path.Combine(_configuration["LooseFilesLocation"], webAppToCreate.webApplicationVersion.Split(".")[0] + "." + webAppToCreate.webApplicationVersion.Split(".")[1], webAppToCreate.webApplicationVersion, webAppToCreate.webApplicationType);
                    Log.Information("Copying the files from \"{filesToCopyFromPath}\"", filesToCopyFromPath);
                    var folderToCopyToPath = Path.Combine(Environment.ExpandEnvironmentVariables(manager.Sites[webAppToCreate.siteName].Applications["/"].VirtualDirectories[webAppToCreate.virtualDirectory].Attributes["physicalPath"].Value.ToString()),webAppToCreate.webApplicationName);
                    Log.Information("Copying the files to \"{folderToCopyToPath}\"", folderToCopyToPath);

                    //Create the new folder for the new web application.
                    try
                    {
                        Log.Information("Creating the new folder for the new web application.");
                        Directory.CreateDirectory(folderToCopyToPath);
                    }
                    catch(Exception ex)
                    {
                        Log.Error("Failed to create the directory.");
                        Log.Error(ex.Message);
                        Log.Error(ex.StackTrace);
                        return "1";
                    }

                    //Copy the files from the loose files location to the new folder.
                    try
                    {
                        Log.Information("Creating all of the directories in the new folder.");
                        //Create all of the directories in the new folder.
                        foreach (string dirPath in Directory.GetDirectories(filesToCopyFromPath, "*", SearchOption.AllDirectories))
                        {
                            Directory.CreateDirectory(dirPath.Replace(filesToCopyFromPath, folderToCopyToPath));
                        }

                        Log.Information("Copying the files from the loose files location to the new folder.");
                        //Copy all the files from the loose files location to the new folder.
                        foreach (string newPath in Directory.GetFiles(filesToCopyFromPath, "*.*", SearchOption.AllDirectories))
                        {
                            System.IO.File.Copy(newPath, newPath.Replace(filesToCopyFromPath, folderToCopyToPath), true);
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Failed to copy the files.");
                        Log.Error(ex.Message);
                        Log.Error(ex.StackTrace);
                        Directory.Delete(folderToCopyToPath, true);
                        return "2";
                    }

                    try
                    {
                        Log.Information("Creating the new Application Pool.");
                        //Create the new Application Pool.
                        ApplicationPool newAppPool = manager.ApplicationPools.Add(webAppToCreate.webApplicationPoolName);

                        Log.Information("Setting the new Application Pool properties.");
                        //Set the new Application Pool properties.
                        //General Settings
                        newAppPool.ManagedRuntimeVersion = "v4.0";
                        if (webAppToCreate.webApplicationBitness == "32-Bit")
                        {
                            newAppPool.Enable32BitAppOnWin64 = true;
                        }
                        else
                        {
                            newAppPool.Enable32BitAppOnWin64 = false;
                        }
                        newAppPool.ManagedPipelineMode = ManagedPipelineMode.Integrated;
                        newAppPool.QueueLength = 65535;
                        newAppPool.StartMode = StartMode.AlwaysRunning;

                        //CPU Settings
                        TimeSpan timeSpan = TimeSpan.FromMinutes(5);
                        newAppPool.Cpu.ResetInterval = timeSpan;

                        //Process Model Settings
                        newAppPool.ProcessModel.IdentityType = ProcessModelIdentityType.ApplicationPoolIdentity;
                        newAppPool.ProcessModel.IdleTimeout = TimeSpan.FromMinutes(0);
                        newAppPool.ProcessModel.PingingEnabled = false;

                        //Rapid Fail Protection Settings
                        newAppPool.Failure.RapidFailProtection = false;

                        //Recycling Settings
                        newAppPool.Recycling.PeriodicRestart.Time = TimeSpan.FromMinutes(0);
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Failed to create the Application Pool.");
                        Log.Error(ex.Message);
                        Log.Error(ex.StackTrace);
                        Directory.Delete(folderToCopyToPath, true);
                        //Delete the newAppPool if it was created.
                        manager.ApplicationPools.Remove(manager.ApplicationPools[webAppToCreate.webApplicationPoolName]);
                        return "3";
                    }

                    //Create the new Application.
                    try
                    {
                        Log.Information("Creating the new Application.");
                        //Create the new Application.
                        Application newApplication = manager.Sites[webAppToCreate.siteName].Applications.Add(webAppToCreate.virtualDirectory + webAppToCreate.webApplicationName, folderToCopyToPath);
                        newApplication.ApplicationPoolName = webAppToCreate.webApplicationPoolName;
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Failed to create the Application.");
                        Log.Error(ex.Message);
                        Log.Error(ex.StackTrace);
                        Directory.Delete(folderToCopyToPath, true);
                        //Delete the newAppPool if it was created.
                        return "4";
                    }

                    //Set the authentication on the SessionAdmin.asmx file if it is an Application Server only though.
                    //TODO: Need to figure this out still.
                    //if (webAppToCreate.webApplicationType == "Application Server (32-Bit)" || webAppToCreate.webApplicationType == "Application Server (64-bit)")
                    //{
                    //    try
                    //    {

                    //        Microsoft.Web.Administration.ConfigurationSection sessionAdminAnonymousAuthenticationSection = manager.GetWebConfiguration("Default Web Site", webAppToCreate.webApplicationName + "/Admin/SessionAdmin.asmx").GetSection("system.webServer/security/authentication/anonymousAuthentication");
                    //        sessionAdminAnonymousAuthenticationSection["enabled"] = false;
                    //        Microsoft.Web.Administration.ConfigurationSection sessionAdminWindowsAuthenticationSection = manager.GetWebConfiguration("Default Web Site", webAppToCreate.webApplicationName + "/Admin/SessionAdmin.asmx").GetSection("system.webServer/security/authentication/windowsAuthentication");
                    //        sessionAdminWindowsAuthenticationSection["enabled"] = true;
                    //    }
                    //    catch (Exception ex)
                    //    {
                    //        Log.Error("Failed to create the Application Pool.");
                    //        Log.Error(ex.Message);
                    //        Log.Error(ex.StackTrace);
                    //        Directory.Delete(folderToCopyToPath, true);
                    //        //Delete the newAppPool if it was created.
                    //        manager.ApplicationPools.Remove(manager.ApplicationPools[webAppToCreate.webApplicationPoolName]);
                    //        return "5";
                    //    }
                    //}

                    Log.Information("Committing the changes.");
                    //Commit the changes.
                    manager.CommitChanges();
                    break;
            }

            return "0";
        }
    }
}
