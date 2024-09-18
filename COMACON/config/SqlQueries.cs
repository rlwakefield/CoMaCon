using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.SqlClient;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Serilog;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Security.Cryptography;
using System.Reflection.Metadata;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Azure.Core;

namespace COMACON.config;

public interface SqlQueries
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="usernum"></param>
    /// <returns>
    /// 
    /// </returns>
    public string GetUser(int usernum);
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""></param>
    /// <returns>
    /// 
    /// </returns>
    public string GetAllUsers();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="userdoingupdates"></param>
    /// <returns>
    /// 
    /// </returns>
    public string UpdateUser(User user,
        int userdoingupdates);
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""></param>
    /// <returns>
    /// 
    /// </returns>
    public string GetRoles();
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <param name="userdoingcreation"></param>
    /// <returns>
    /// 
    /// </returns>
    public string CreateUser(User user,
        int userdoingcreation);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventid"></param>
    /// <param name="usernumdoingaction"></param>
    /// <returns>
    /// 
    /// </returns>
    public void writeToSecurityLogTable(int eventid,
        int usernumdoingaction);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventid"></param>
    /// <param name="usernumdoingaction"></param>
    /// <param name="usernumbeingaffected"></param>
    /// <returns>
    /// 
    /// </returns>
    public void writeToSecurityLogTable(int eventid,
        int usernumdoingaction,
        int usernumbeingaffected);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventid"></param>
    /// <param name="usernumdoingaction"></param>
    /// <param name="oldvalue"></param>
    /// <param name="newvalue"></param>
    /// <returns>
    /// 
    /// </returns>
    public void writeToSecurityLogTable(int eventid,
        int usernumdoingaction,
        string oldvalue,
        string newvalue);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="eventid"></param>
    /// <param name="usernumdoingaction"></param>
    /// <param name="usernumbeingaffected"></param>
    /// <param name="oldvalue"></param>
    /// <param name="newvalue"></param>
    /// <returns>
    /// 
    /// </returns>
    public void writeToSecurityLogTable(int eventid,
        int usernumdoingaction,
        int usernumbeingaffected,
        string oldvalue,
        string newvalue);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="access_Token"></param>
    /// <param name="token_type"></param>
    /// <param name="issued"></param>
    /// <param name="expires"></param>
    /// <param name="connection"></param>
    /// <param name="usernumloggingin"></param>
    /// <returns>
    /// 
    /// </returns>
    public void StoreSessionInformation(string access_Token,
        string token_type,
        DateTime issued,
        DateTime expires,
        SqlConnection connection,
        int usernumloggingin);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="access_Token"></param>
    /// <param name="connection"></param>
    /// <returns>
    /// 
    /// </returns>
    public void DeleteSessionInformation(string access_token,
        SqlConnection connection);
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""></param>
    /// <returns>
    /// 
    /// </returns>
    public string GetAllPasswordPolicies();
}

internal class DefaultSqlQueries : SqlQueries
{

    private static string _connectionString;
    private readonly Dictionary<int, string> _securityLogs = new()
    {
        //Values 0 through 1000 are User Account actions.
        //{ 1, "User logged in." }, //Used when a user logs in.
        //{ 2, "User logged out." }, //Used when a user logs out.
        //{ 3, "New user created." }, //Used when a new user is created.
        //{ 4, "Username changed from {oldusername} to {newusername}." }, //Used when an admin changes a users username.
        //{ 5, "First Name changed from {oldfirstname} to {newfirstname}." }, //Used when an admin changes a users first name.
        //{ 6, "Last Name changed from {oldlastname} to {newlastname}." }, //Used when an admin changes a users last name.
        //{ 7, "Changed users password." }, //Used when an admin changes a users password.
        //{ 8, "Email Address changed from {oldemailaddress} to {newemailaddress}." }, //Used when an admin changes a users email address.
        //{ 9, "User account enabled." }, //Used when an admin enables a user account.
        //{ 10, "User account disabled." }, //Used when an admin disables a user account.
        //{ 11, "User account password changed." }, //Used when the user changes their own password.
        //{ 12, "Authentication Method changed from {oldauthmethod} to {newauthmethod}." }, //Used when an admin changes a users authentication method.
        //{ 13, "Role changed from {oldroleid} to {newroleid}." }, //Used when an admin changes a users role.
        { 1, "User logged in" },
        { 2, "User logged out" },
        { 3, "User logged in with invalid username/password." },
        { 4, "User reset their own password." },
        { 5, "Users requirement to change password on next login was changed from {0} to {1}." },
        { 6, "Username changed from {0} to {1}." },
        { 7, "First Name changed from {0} to {1}." },
        { 8, "Last Name changed from {0} to {1}." },
        { 9, "Email Address changed from {0} to {1}." },
        { 10, "Authentication Method changed from {0} to {1}." },
        { 11, "Role changed from {0} to {1}." },
        { 12, "New user created" },
        { 13, "Changed users password." },
        { 14, "User account enabled." },
        { 15, "User account disabled." },
        { 16, "User attempted to login with a disabled account." },
        //Values 1001 through 5000 are Web Application actions.
        { 1001, "Created new Web Application from scratch." },
        { 1002, "Created new Web Application from local file." },
        { 1003, "Created new Web Application from existing Web Application." },
        { 1004, "Updated Web Application" },
        { 1005, "Disabled Web Application" },
        { 1006, "Opened Web Application" },
        { 1007, "Closed Web Application" },
        //Values 5001 through 10000 are Client actions.
    };
    private string _storesessioninformationinsert = "INSERT INTO [COMACON].[dbo].[sessions] ([access_token], [token_type], [creationdate], [expirationdate], [usernum]) VALUES (@access_Token, @token_type, @issued, @expires, @usernum)";
    private string _deletesessioninformationquery = "DELETE from [COMACON].[dbo].[sessions] WHERE [access_token] = @access_token";
    private string _securityloginsertdefaultquery = "INSERT INTO [COMACON].[dbo].[securitylog] (eventid, usernum, eventdescription, logdate) VALUES (@eventid, @usernum, @eventdescription, @logdate)";
    private string _securityloginsertaffecteduserquery = "INSERT INTO [COMACON].[dbo].[securitylog] (eventid, usernum, eventdescription, affectedusernum, logdate) VALUES (@eventid, @usernum, @eventdescription, @affectedusernum, @logdate)";
    private string _securityloginsertoldvaluenewvaluequery = "INSERT INTO [COMACON].[dbo].[securitylog] (eventid, usernum, eventdescription, affectedusernum, logdate) VALUES (@eventid, @usernum, @eventdescription, @affectedusernum @logdate)";
    private string _securityloginsertaffecteduseroldvaluenewvaluequery = "INSERT INTO [COMACON].[dbo].[securitylog] (eventid, usernum, eventdescription, affectedusernum, logdate) VALUES (@eventid, @usernum, @eventdescription, @affectedusernum, @logdate)";
    private string _getuserbyusernamequery = "SELECT * FROM [COMACON].[dbo].[useraccounts] WHERE [username] = @username";
    private string _createuserquery = "INSERT INTO [COMACON].[dbo].[useraccounts] (username, firstname, lastname, password, emailaddress, status, passwordresetonnextlogin, passwordlastchanged, authmethod, creationdate, createdby, lastediteddate, lasteditedby, roleid) VALUES (@username, @firstname, @lastname, @password, @emailaddress, @status, @passwordresetonnextlogin, @passwordlastchanged, @authmethod, @creationdate, @createdby, @lastediteddate, @lasteditedby, @roleid)";
    private string _getrolesquery = "SELECT * FROM [COMACON].[dbo].[roles]";
    private string _validateaccesstokenquery = "SELECT * FROM sessions WHERE access_token = '@access_token'";
    private string _updateuserquery = "UPDATE [dbo].[useraccounts] SET {0} WHERE [usernum] = @usernum";
    private string _getallusersquery = "SELECT * FROM [COMACON].[dbo].[useraccounts]";
    private string _getuserquery = "SELECT * FROM [COMACON].[dbo].[useraccounts] WHERE [usernum] = @usernum";
    private string _getallpasswordpoliciesquery = "SELECT * FROM [COMACON].[dbo].[passwordpolicies]";
    private string _getpolicyrulebypswdpolicyidquery = "SELECT * FROM [COMACON].[dbo].[passwordrules] WHERE [pswdpolicyid] = @pswdpolicyid";

    public DefaultSqlQueries(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public string GetUser(int usernum)
    {
        //string _getuserquery = "SELECT * FROM [COMACON].[dbo].[useraccounts] WHERE [usernum] = @usernum";
        Dictionary<string, int> parameters = new Dictionary<string, int>
        {
            { "@usernum", usernum }
        };

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(_getuserquery, connection))
            {
                command.Parameters.AddWithValue("@usernum", usernum);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        UsersDataStructure usersds = new UsersDataStructure();
                        while (reader.Read())
                        {
                            User u = new User();
                            u.usernum = int.Parse(reader["usernum"].ToString());
                            u.username = reader["username"].ToString();
                            u.firstname = reader["firstname"].ToString();
                            u.lastname = reader["lastname"].ToString();
                            u.emailaddress = reader["emailaddress"].ToString();
                            u.enabled = bool.Parse(reader["status"].ToString()) ? 1 : 0;
                            u.passwordresetonnextlogin = bool.Parse(reader["passwordresetonnextlogin"].ToString()) ? 1 : 0;
                            u.passwordlastchanged = DateTime.Parse(reader["passwordlastchanged"].ToString());
                            u.authmethod = reader["authmethod"].ToString();
                            u.creationdate = DateTime.Parse(reader["creationdate"].ToString());
                            u.createdby = int.Parse(reader["createdby"].ToString());
                            u.lastediteddate = DateTime.Parse(reader["lastediteddate"].ToString());
                            u.lasteditedby = int.Parse(reader["lasteditedby"].ToString());
                            u.roleid = int.Parse(reader["roleid"].ToString());
                            usersds.users.Add(u);
                        }

                        return JsonConvert.SerializeObject(usersds);
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }
    }

    public string GetAllUsers()
    {
        //string _getallusersquery = "SELECT * FROM [COMACON].[dbo].[useraccounts]";
        var (reader, connection) = createAndExecuteSqlNoParameters(_getallusersquery);

        using (reader)
        using (connection)
        {
            if (reader.HasRows)
            {
                UsersDataStructure usersds = new UsersDataStructure();
                while (reader.Read())
                {
                    User u = new User();
                    u.usernum = int.Parse(reader["usernum"].ToString());
                    u.username = reader["username"].ToString();
                    u.firstname = reader["firstname"].ToString();
                    u.lastname = reader["lastname"].ToString();
                    u.emailaddress = reader["emailaddress"].ToString();
                    u.enabled = bool.Parse(reader["status"].ToString()) ? 1 : 0;
                    u.passwordresetonnextlogin = bool.Parse(reader["passwordresetonnextlogin"].ToString()) ? 1 : 0;
                    u.passwordlastchanged = DateTime.Parse(reader["passwordlastchanged"].ToString());
                    u.authmethod = reader["authmethod"].ToString();
                    u.creationdate = DateTime.Parse(reader["creationdate"].ToString());
                    u.createdby = int.Parse(reader["createdby"].ToString());
                    u.lastediteddate = DateTime.Parse(reader["lastediteddate"].ToString());
                    u.lasteditedby = int.Parse(reader["lasteditedby"].ToString());
                    u.roleid = int.Parse(reader["roleid"].ToString());
                    usersds.users.Add(u);
                }

                return JsonConvert.SerializeObject(usersds);
            }
            else
            {
                return "";
            }
        }
    }

    public string UpdateUser(User user, int userdoingupdates)
    {
        //string _updateuserquery = "UPDATE [dbo].[useraccounts] SET {0} WHERE [usernum] = @usernum";
        string updateQuery = _updateuserquery;
        User useroriginalvalues = JsonConvert.DeserializeObject<User>(GetUser(user.usernum));
        string columnValueToSet = createUpdateUserSetString(user, userdoingupdates, useroriginalvalues);

        if (string.IsNullOrEmpty(columnValueToSet))
        {
            throw new Exception("No values to update.");
        }

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            updateQuery = string.Format(updateQuery, columnValueToSet);

            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@usernum", user.usernum);
                command.Parameters.AddWithValue("@lasteditedby", userdoingupdates);
                if (user.username != null) command.Parameters.AddWithValue("@username", user.username);
                if (user.firstname != null) command.Parameters.AddWithValue("@firstname", user.firstname);
                if (user.lastname != null) command.Parameters.AddWithValue("@lastname", user.lastname);
                if (user.password != null) command.Parameters.AddWithValue("@password", user.password);
                if (user.emailaddress != null) command.Parameters.AddWithValue("@emailaddress", user.emailaddress);
                if (user.enabled != null) command.Parameters.AddWithValue("@status", user.enabled);
                if (user.passwordresetonnextlogin != null) command.Parameters.AddWithValue("@passwordresetnextlogin", user.passwordresetonnextlogin);
                if (user.authmethod != null) command.Parameters.AddWithValue("@authmethod", user.authmethod);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        return GetUser(user.usernum);
                    }
                    else
                    {
                        Log.Logger.Warning("No rows affected.");
                        throw new Exception("No rows affected.");
                    }
                }
                catch (Exception ex)
                {
                    Log.Logger.Error("Error: " + ex.Message);
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }
    }

    private string createUpdateUserSetString(User user, int userdoingudpates, User useroriginalvalues)
    {
        string columnValueToSet = "";
        if (user.username != null)
        {
            writeToSecurityLogTable(6, userdoingudpates, user.usernum, useroriginalvalues.username, user.username);
            columnValueToSet += "[username] = @username,";
        }
        if (user.firstname != null)
        {
            writeToSecurityLogTable(7, userdoingudpates, user.usernum, useroriginalvalues.firstname, user.firstname);
            columnValueToSet += "[firstname] = @firstname,";
        }
        if (user.lastname != null)
        {
            writeToSecurityLogTable(8, userdoingudpates, user.usernum, useroriginalvalues.lastname, user.lastname);
            columnValueToSet += "[lastname] = @lastname,";
        }
        if (user.password != null)
        {
            writeToSecurityLogTable(13, userdoingudpates, user.usernum);
            columnValueToSet += "[password] = @password, [passwordlastchanged] = GETDATE(),";
        }
        if (user.emailaddress != null)
        {
            writeToSecurityLogTable(9, userdoingudpates, user.usernum, useroriginalvalues.emailaddress, user.emailaddress);
            columnValueToSet += "[emailaddress] = @emailaddress,";
        }
        if (user.enabled != null)
        {
            writeToSecurityLogTable(user.enabled == 1 ? 14 : 15, userdoingudpates, user.usernum);
            columnValueToSet += "[status] = @status,";
        }
        if (user.passwordresetonnextlogin != null)
        {
            writeToSecurityLogTable(5, userdoingudpates, user.usernum, useroriginalvalues.passwordresetonnextlogin == 1 ? "1" : "0", user.passwordresetonnextlogin == 1 ? "1" : "0");
            columnValueToSet += "[passwordresetnextlogin] = @passwordresetnextlogin,";
        }
        if (user.authmethod != null)
        {
            writeToSecurityLogTable(10, userdoingudpates, user.usernum, useroriginalvalues.authmethod, user.authmethod);
            columnValueToSet += "[authmethod] = @authmethod,";
        }
        if(user.roleid != null)
        {
            writeToSecurityLogTable(11, userdoingudpates, user.usernum, useroriginalvalues.roleid.ToString(), user.roleid.ToString());
            columnValueToSet += "[roleid] = @roleid,";
        }
        columnValueToSet += "[lastediteddate] = GETDATE(), [lasteditedby] = @lasteditedby";

        if (columnValueToSet.StartsWith(","))
        {
            columnValueToSet = columnValueToSet.Substring(1);
        }

        if (columnValueToSet.EndsWith(","))
        {
            columnValueToSet = columnValueToSet.Substring(0, columnValueToSet.Length - 1);
        }

        return columnValueToSet;
    }

    public void StoreSessionInformation(string access_Token, string token_type, DateTime issued, DateTime expires, SqlConnection connection, int usernumloggingin)
    {
        int numRowsAffected = 0;

        using (SqlCommand command = new SqlCommand(_storesessioninformationinsert, connection))
        {
            command.Parameters.AddWithValue("@access_token", access_Token);
            command.Parameters.AddWithValue("@token_type", token_type);
            command.Parameters.AddWithValue("@issued", issued);
            command.Parameters.AddWithValue("@expires", expires);
            command.Parameters.AddWithValue("@usernum", usernumloggingin);
            //Console.WriteLine(command.CommandText);
            do
            {
                numRowsAffected = command.ExecuteNonQuery();

                if (numRowsAffected == 0)
                {
                    Log.Logger.Error("Failed to store session information.");
                }
                else
                {
                    Log.Logger.Information("Successfully stored session information.");
                }
            } while (numRowsAffected == 0);
        }
    }

    public bool validateAccessToken(string access_token, SqlConnection connection)
    {
        Log.Logger.Information("Validating access token");
        //string _validateaccesstokenquery = "SELECT * FROM sessions WHERE access_token = '@access_token'";
        using (SqlCommand command = new SqlCommand(_validateaccesstokenquery, connection))
        {
            command.Parameters.AddWithValue("@access_token", access_token);
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (!reader.HasRows)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }

    public string GetRoles()
    {
        //string _getrolesquery = "SELECT * FROM [COMACON].[dbo].[roles]";

        using(SqlCommand command = new SqlCommand(_getrolesquery, new SqlConnection(_connectionString)))
        {
            command.Connection.Open();
            using(SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    Roles rolesds = new Roles();
                    while (reader.Read())
                    {
                        role r = new role();
                        r.roleid = int.Parse(reader["roleid"].ToString());
                        r.rolename = reader["rolename"].ToString();
                        r.roledescription = reader["roledescription"].ToString();
                        rolesds.roles.Add(r);
                    }

                    return JsonConvert.SerializeObject(rolesds);
                }
                else
                {
                    return "";
                }
            }
        }
    }

    public string CreateUser(User user, int userdoingcreation)
    {
        Console.WriteLine(userdoingcreation);
        //string _createuserquery = "INSERT INTO [COMACON].[dbo].[useraccounts] (username, firstname, lastname, password, emailaddress, status, passwordresetonnextlogin, passwordlastchanged, authmethod, creationdate, createdby, lastediteddate, lasteditedby, roleid) VALUES (@username, @firstname, @lastname, @password, @emailaddress, @status, @passwordresetonnextlogin, @passwordlastchanged, @authmethod, @creationdate, @createdby, @lastediteddate, @lasteditedby, @roleid)";

        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using(SqlCommand command = new SqlCommand(_createuserquery, connection))
            {
                command.Parameters.AddWithValue("@username", user.username);
                command.Parameters.AddWithValue("@firstname", user.firstname);
                command.Parameters.AddWithValue("@lastname", user.lastname);
                command.Parameters.AddWithValue("@password", hashpassword(user.password));
                command.Parameters.AddWithValue("@emailaddress", user.emailaddress);
                command.Parameters.AddWithValue("@status", user.enabled);
                command.Parameters.AddWithValue("@passwordresetonnextlogin", user.passwordresetonnextlogin);
                //Create new DateTime variable of current DateTime.
                DateTime currentDateTime = DateTime.Now;
                command.Parameters.AddWithValue("@passwordlastchanged", currentDateTime);
                command.Parameters.AddWithValue("@authmethod", user.authmethod);
                command.Parameters.AddWithValue("@creationdate", currentDateTime);
                command.Parameters.AddWithValue("@createdby", userdoingcreation);
                command.Parameters.AddWithValue("@lastediteddate", currentDateTime);
                command.Parameters.AddWithValue("@lasteditedby", userdoingcreation);
                command.Parameters.AddWithValue("@roleid", user.roleid);

                try
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        string usercreated = GetUserByUsername(user.username);
                        Console.WriteLine(usercreated);
                        Console.WriteLine(JsonConvert.DeserializeObject<UsersDataStructure>(usercreated).users[0].usernum);
                        writeToSecurityLogTable(12, userdoingcreation, JsonConvert.DeserializeObject<UsersDataStructure>(usercreated).users[0].usernum);
                        return usercreated;
                    }
                    else
                    {
                        Log.Logger.Warning("No rows affected.");
                        throw new Exception("No rows affected.");
                    }
                }
                catch (Exception ex)
                {
                    Log.Logger.Error("Error: " + ex.Message);
                    throw new Exception("Error: " + ex.Message);
                }
            }
        }
    }

    private string hashpassword(string password)
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {
            // Compute the hash - returns byte array
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Convert byte array to a string
            StringBuilder builder = new StringBuilder();
            foreach (byte b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }

    private string GetUserByUsername(string username)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            //string getuserbyusernamequery = "SELECT * FROM [COMACON].[dbo].[useraccounts] WHERE [username] = @username";

            using (SqlCommand command = new SqlCommand(_getuserbyusernamequery, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        UsersDataStructure usersds = new UsersDataStructure();
                        while (reader.Read())
                        {
                            User u = new User();
                            u.usernum = int.Parse(reader["usernum"].ToString());
                            u.username = reader["username"].ToString();
                            u.firstname = reader["firstname"].ToString();
                            u.lastname = reader["lastname"].ToString();
                            u.emailaddress = reader["emailaddress"].ToString();
                            u.enabled = bool.Parse(reader["status"].ToString()) ? 1 : 0;
                            u.passwordresetonnextlogin = bool.Parse(reader["passwordresetonnextlogin"].ToString()) ? 1 : 0;
                            u.passwordlastchanged = DateTime.Parse(reader["passwordlastchanged"].ToString());
                            u.authmethod = reader["authmethod"].ToString();
                            u.creationdate = DateTime.Parse(reader["creationdate"].ToString());
                            u.createdby = int.Parse(reader["createdby"].ToString());
                            u.lastediteddate = DateTime.Parse(reader["lastediteddate"].ToString());
                            u.lasteditedby = int.Parse(reader["lasteditedby"].ToString());
                            u.roleid = int.Parse(reader["roleid"].ToString());
                            usersds.users.Add(u);
                        }

                        return JsonConvert.SerializeObject(usersds);
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }
    }

    private (SqlDataReader, SqlConnection) createAndExecuteSqlNoParameters(string query)
    {
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        SqlCommand command = new SqlCommand(query, connection);

        return (command.ExecuteReader(), connection);
    }

    private SqlDataReader createAndExecuteSqlWithParameters(string query, Dictionary<string, int> parameters)
    {
        SqlConnection connection = new SqlConnection(_connectionString);

        connection.Open();

        SqlCommand command = new SqlCommand(query, connection);

        if (parameters != null)
        {
            foreach (KeyValuePair<string, int> kvp in parameters)
            {
                command.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }
        }

        return command.ExecuteReader();
    }

    private SqlDataReader createAndExecuteSqlWithParameters(string query, Dictionary<string, string> parameters)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if (parameters != null)
                {
                    foreach (KeyValuePair<string, string> kvp in parameters)
                    {
                        command.Parameters.AddWithValue(kvp.Key, kvp.Value);
                    }
                }

                return command.ExecuteReader();
            }
        }
    }

    private int executeUpdateSqlQuery(string query)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                return command.ExecuteNonQuery();
            }
        }
    }

    public void writeToSecurityLogTable(int eventid, int usernumdoingaction)
    {
        //string securityloginsert = "INSERT INTO [COMACON].[dbo].[securitylog] (eventid, usernum, eventdescription, logdate) VALUES (@eventid, @usernum, @eventdescription, @logdate)";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(_securityloginsertdefaultquery, connection))
            {
                command.Parameters.AddWithValue("@eventid", eventid);
                command.Parameters.AddWithValue("@usernum", usernumdoingaction);
                _securityLogs.TryGetValue(eventid, out string eventdescriptionvalue);
                command.Parameters.AddWithValue("@eventdescription", eventdescriptionvalue);
                command.Parameters.AddWithValue("@logdate", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }
    }

    public void writeToSecurityLogTable(int eventid, int usernumdoingaction, int affectedusernum)
    {
        //string securityloginsert = "INSERT INTO [COMACON].[dbo].[securitylog] (eventid, usernum, eventdescription, affectedusernum, logdate) VALUES (@eventid, @usernum, @eventdescription, @affectedusernum, @logdate)";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(_securityloginsertaffecteduserquery, connection))
            {
                command.Parameters.AddWithValue("@eventid", eventid);
                command.Parameters.AddWithValue("@usernum", usernumdoingaction);
                _securityLogs.TryGetValue(eventid, out string eventdescriptionvalue);
                command.Parameters.AddWithValue("@eventdescription", eventdescriptionvalue);
                command.Parameters.AddWithValue("@affectedusernum", affectedusernum);
                command.Parameters.AddWithValue("@logdate", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }
    }

    public void writeToSecurityLogTable(int eventid, int usernumdoingaction, string oldvalue, string newvalue)
    {
        //string securityloginsert = "INSERT INTO [COMACON].[dbo].[securitylog] (eventid, usernum, eventdescription, affectedusernum, logdate) VALUES (@eventid, @usernum, @eventdescription, @affectedusernum @logdate)";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(_securityloginsertoldvaluenewvaluequery, connection))
            {
                command.Parameters.AddWithValue("@eventid", eventid);
                command.Parameters.AddWithValue("@usernum", usernumdoingaction);
                _securityLogs.TryGetValue(eventid, out string eventdescriptionvalue);
                command.Parameters.AddWithValue("@eventdescription", string.Format(eventdescriptionvalue, oldvalue, newvalue));
                command.Parameters.AddWithValue("@logdate", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }
    }

    public void writeToSecurityLogTable(int eventid, int usernumdoingaction, int affectedusernum, string oldvalue, string newvalue)
    {
        //string securityloginsert = "INSERT INTO [COMACON].[dbo].[securitylog] (eventid, usernum, eventdescription, affectedusernum, logdate) VALUES (@eventid, @usernum, @eventdescription, @affectedusernum, @logdate)";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(_securityloginsertaffecteduseroldvaluenewvaluequery, connection))
            {
                command.Parameters.AddWithValue("@eventid", eventid);
                command.Parameters.AddWithValue("@usernum", usernumdoingaction);
                _securityLogs.TryGetValue(eventid, out string eventdescriptionvalue);
                command.Parameters.AddWithValue("@eventdescription", string.Format(eventdescriptionvalue,oldvalue,newvalue));
                command.Parameters.AddWithValue("@affectedusernum", affectedusernum);
                command.Parameters.AddWithValue("@logdate", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteSessionInformation(string access_token, SqlConnection connection)
    {
        //string deletesessioninformationquery = "DELETE from [COMACON].[dbo].[sessions] WHERE [access_token] = @access_token";
        using (SqlCommand command = new SqlCommand(_deletesessioninformationquery, connection))
        {
            command.Parameters.AddWithValue("@access_token", access_token);

            command.ExecuteNonQuery();
        }
    }

    public void getSessionInformation(string access_token, SqlConnection connection)
    {
        throw new NotImplementedException();
    }

    public string GetAllPasswordPolicies()
    {
        PasswordPolicies pwp = new PasswordPolicies();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            List<int> passwordpolicyids = new List<int>();
            using (SqlCommand command = new SqlCommand(_getallpasswordpoliciesquery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        throw new Exception("No Policies are configured.");
                    }

                    while (reader.Read())
                    {
                        PasswordPolicy pp = new PasswordPolicy();
                        pp.passwordpolicyid = int.Parse(reader["pswdpolicyid"].ToString());
                        pp.passwordpolicytype = int.Parse(reader["policytype"].ToString());
                        pp.passwordpolicyname = reader["policyname"].ToString();
                        pp.passwordpolicydescription = reader["policydescription"].ToString();
                        pp.passwordpolicyenabled = bool.Parse(reader["policyenabled"].ToString()) ? 1 : 0;
                        pwp.passwordpolicies.Add(pp);
                    }
                }
            }

            foreach(PasswordPolicy pp in pwp.passwordpolicies)
            {
                using (SqlCommand command = new SqlCommand(_getpolicyrulebypswdpolicyidquery, connection))
                {
                    command.Parameters.AddWithValue("@pswdpolicyid", pp.passwordpolicyid);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                PasswordPolicyRule ppr = new PasswordPolicyRule();
                                ppr.ruletype = int.Parse(reader["ruletype"].ToString());
                                ppr.rulevalue = int.Parse(reader["rulevalue"].ToString());
                                ppr.ruleenabled = bool.Parse(reader["ruleenabled"].ToString()) ? 1 : 0;
                                pp.rules.Add(ppr);
                            }
                        }
                    }
                }
            }
        }

        return JsonConvert.SerializeObject(pwp);
    }
}
