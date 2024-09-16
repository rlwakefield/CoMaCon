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
    /// <param name="usernumbeingaffected"></param>
    /// <returns>
    /// 
    /// </returns>
    public void writeToSecurityLogTable(int eventid,
        int usernumdoingaction,
        int usernumbeingaffected = 0);
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
        { 3, "User logged in with the wrong password." },
        { 4, "User reset their own password after it being expired." },
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

    public DefaultSqlQueries(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public string GetUser(int usernum)
    {
        string query = "SELECT * FROM [COMACON].[dbo].[useraccounts] WHERE [usernum] = @usernum";
        Dictionary<string, int> parameters = new Dictionary<string, int>
        {
            { "@usernum", usernum }
        };

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(query, connection))
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
        string query = "SELECT * FROM [COMACON].[dbo].[useraccounts]";
        var (reader, connection) = createAndExecuteSqlNoParameters(query);

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
        string updateQuery = "UPDATE [dbo].[useraccounts] SET {0} WHERE [usernum] = @usernum";
        string columnValueToSet = createUpdateUserSetString(user);

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

    private string createUpdateUserSetString(User user)
    {
        string columnValueToSet = "";
        if (user.username != null)
        {
            columnValueToSet += "[username] = @username,";
        }
        if (user.firstname != null)
        {
            columnValueToSet += "[firstname] = @firstname,";
        }
        if (user.lastname != null)
        {
            columnValueToSet += "[lastname] = @lastname,";
        }
        if (user.password != null)
        {
            columnValueToSet += "[password] = @password, [passwordlastchanged] = GETDATE(),";
        }
        if (user.emailaddress != null)
        {
            columnValueToSet += "[emailaddress] = @emailaddress,";
        }
        if (user.enabled != null)
        {
            columnValueToSet += "[status] = @status,";
        }
        if (user.passwordresetonnextlogin != null)
        {
            columnValueToSet += "[passwordresetnextlogin] = @passwordresetnextlogin,";
        }
        if (user.authmethod != null)
        {
            columnValueToSet += "[authmethod] = @authmethod,";
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

    public void StoreSessionInformation(string access_token, string token_type, DateTime creationdate, DateTime expirationdate, SqlConnection connection, int usernum)
    {
        Log.Logger.Information("Storing session information");

        string query = "INSERT INTO sessions (access_token, token_type, creationdate, expirationdate, usernum) VALUES ('" + access_token + "', '" + token_type + "', " + creationdate + ", " + expirationdate + ", " + usernum + ");";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.ExecuteNonQuery();
        }
    }

    public bool validateAccessToken(string access_token, SqlConnection connection)
    {
        Log.Logger.Information("Validating access token");
        string query = "SELECT * FROM sessions WHERE access_token = '" + access_token + "'";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
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
        string query = "SELECT * FROM [COMACON].[dbo].[roles]";

        using(SqlCommand command = new SqlCommand(query, new SqlConnection(_connectionString)))
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
        string query = "INSERT INTO [COMACON].[dbo].[useraccounts] (username, firstname, lastname, password, emailaddress, status, passwordresetonnextlogin, passwordlastchanged, authmethod, creationdate, createdby, lastediteddate, lasteditedby, roleid) VALUES (@username, @firstname, @lastname, @password, @emailaddress, @status, @passwordresetonnextlogin, @passwordlastchanged, @authmethod, @creationdate, @createdby, @lastediteddate, @lasteditedby, @roleid)";

        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using(SqlCommand command = new SqlCommand(query, connection))
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
                        return GetUserByUsername(user.username);
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
            string query = "SELECT * FROM [COMACON].[dbo].[useraccounts] WHERE [username] = @username";

            using (SqlCommand command = new SqlCommand(query, connection))
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

    public void writeToSecurityLogTable(int eventid, int usernumdoingaction, int usernumbeingaffected=0)
    {
        string securityloginsert = "INSERT INTO [COMACON].[dbo].[securitylog] (eventid, usernum, eventdescription, logdate) VALUES (@eventid, @usernum, @eventdescription, @logdate)";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            using (SqlCommand command = new SqlCommand(securityloginsert, connection))
            {
                command.Parameters.AddWithValue("@eventid", eventid);
                command.Parameters.AddWithValue("@usernum", usernumdoingaction);
                command.Parameters.AddWithValue("@eventdescription", _securityLogs[eventid]);
                command.Parameters.AddWithValue("@logdate", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }
    }
}
