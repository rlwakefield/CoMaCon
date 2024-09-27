using Newtonsoft.Json;
using Serilog;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using Microsoft.AspNetCore.Identity;
using Azure.Core;
using Newtonsoft.Json.Linq;
using COMACON.DatabaseContexts.SQLite;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace COMACON.config;

public interface SessionManagement
{
    //    string password);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns>
    /// 
    /// </returns>
    public string ValidateUserLoggingIn(string username,
        string password);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="access_token"></param>
    /// <returns>
    /// 
    /// </returns>
    public string validateAccessTokenStillActive(string access_token);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="userloggingin"></param>
    /// <returns>
    /// 
    /// </returns>
    public string generateAccessToken(string userloggingin);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="access_token"></param>
    /// <returns>
    /// 
    /// </returns>
    public int getUserSessionUserNum(string access_token);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="access_token"></param>
    /// <returns>
    /// 
    /// </returns>
    public void logoutUser(string access_token);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <param name="newpassword"></param>
    /// <returns>
    /// 
    /// </returns>
    public string ResetPassword(string username,
        string password,
        string newpassword);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="toemailaddress"></param>
    /// <param name="configuration"></param>
    /// <returns>
    /// 
    /// </returns>
    public string ForgotPasswordRequest(string username,
        string toemailaddress,
        IConfiguration configuration);
}

internal sealed class DefaultSessionManagement : SessionManagement
{
    private readonly int _expiresIn = 3600;
    private readonly string _token_type = "Bearer";
    private readonly string _errorReturnText = "{\"error\":\"@errorNumber\",\"message\":\"@errorMessage\"}";
    private readonly string _successReturnText = "{\"error\":\"@errorNumber\",\"access_token\":\"@access_token\",\"token_type\":\"@token_type\",\"expires_in\":\"@expires_in\"}";
    private string _validateuserlogginginquery = "SELECT * FROM [dbo].[useraccounts] WHERE [username] = @username and [password] = @passwordHash";
    private string _validateaccesstokenstillactivesqlquery = "SELECT [access_token] FROM [dbo].[sessions] WHERE [access_token] = '@access_token'";
    private string _validateaccesstokenquery = "SELECT [access_token] FROM [dbo].[sessions] WHERE [access_token] = '@access_token'";
    private string _updatesessioninformationquery = "UPDATE [dbo].[sessions] SET [expirationdate] = @newSessionExpiration WHERE [access_token] = @access_token";
    private string _getusersessionusernumquery = "SELECT [usernum] FROM [dbo].[sessions] WHERE [access_token] = @access_token";
    private string _resetpasswordquery = "SELECT [usernum] FROM [dbo].[useraccounts] WHERE [username] = '@username' and [password] = '@currentpasswordHash'";
    /* This Dictionary will be used to store the standardized security log messages and their corresponding eventid numbers
     * Different ranges of numbers will represent different types of events.
     * Those ranges are as follows:
     * 1-500 = User Account Events
     * 501-2500 = Web Application Events
     */
    private static string _connectionString = "";
    private readonly SqlQueries _sqlQueries;
    private readonly COMACONSqliteDbContext _context;

    public DefaultSessionManagement(IConfiguration configuration,
        SqlQueries sqlQueries,
        COMACONSqliteDbContext context)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _sqlQueries = sqlQueries;
        _context = context;
    }

    public string ValidateUserLoggingIn(string username, string password)
    {
        Log.Logger.Information("Authenticating user \"{username}\".", username);
        string passwordHash = _sqlQueries.hashpassword(password);

        var useracct = _context.UserAccounts
            .Where(u => u.Username == username && u.Password == passwordHash)
            .ToList();

        if (useracct.Count == 0)
        {
            return _errorReturnText.Replace("@errorNumber", "3").Replace("@errorMessage", "Invalid Username or Password.");
        }

        if (useracct.Count > 1)
        {
            return _errorReturnText.Replace("@errorNumber", "4").Replace("@errorMessage", "Multiple users found with the same username and password.");
        }

        if (useracct[0].Status == false)
        {
            _sqlQueries.writeToSecurityLogTable(16, useracct[0].UserNum);
            return _errorReturnText.Replace("@errorNumber", "5").Replace("@errorMessage", "Your account has been disabled.");
        }

        if (useracct[0].PasswordResetOnNextLogin == true)
        {
            return _errorReturnText.Replace("@errorNumber", "9").Replace("@errorMessage", "You must reset your password before logging in.");
        }

        Log.Logger.Information("User \"{username}\" successfully authenticated.", username);
        _sqlQueries.writeToSecurityLogTable(1, useracct[0].UserNum);
        return _errorReturnText.Replace("@errorNumber", "0").Replace("@errorMessage", useracct[0].UserNum.ToString());
    }

    public string validateAccessTokenStillActive(string access_token)
    {
        var session = _context.Sessions
            .Where(s => s.AccessToken == access_token)
            .ToList();

        if(session.Count <= 0)
        {
            return _errorReturnText.Replace("@errorNumber", "-1").Replace("@message", "Access token not found.");
        }
        
        if (DateTimeOffset.Now > DateTimeOffset.Parse(session[0].ExpirationDate))
        {
            // DateTime.Now is later than now
            // This means that the access token is expired.
            _sqlQueries.DeleteSessionInformation(access_token, null);
            return _errorReturnText.Replace("@errorNumber", "-1").Replace("@message", "The access token is expired.");
        }

        UpdateSessionInformation(access_token, null, DateTime.Now.AddSeconds(_expiresIn));
        return _successReturnText.Replace("@errorNumber", "0").Replace("@access_token", access_token).Replace("@token_type", _token_type).Replace("@expires_in", _expiresIn.ToString());
    }

    public string generateAccessToken(string userloggingin)
    {
        var sessions = _context.Sessions
            .ToList();
        string access_token = Guid.NewGuid().ToString();
        DateTime issued = DateTime.Now;
        DateTime expires = DateTime.Now.AddSeconds(_expiresIn);

        if (sessions.Count <= 0)
        {
            Log.Logger.Information("No tokens are stored in the system right now. Generating a new one.");
            Log.Logger.Information("Storing session information.");
            _sqlQueries.StoreSessionInformation(access_token, _token_type, issued, expires, null, int.Parse(userloggingin));
            return _successReturnText.Replace("@errorNumber", "0").Replace("@access_token", access_token).Replace("@token_type", _token_type).Replace("@expires_in", _expiresIn.ToString());
        }

        while (sessions.Find(s => s.AccessToken == access_token) != null)
        {
            Log.Logger.Information("Access token already exists. Generating a new one.");
            access_token = Guid.NewGuid().ToString();
        }

        Log.Logger.Information("Storing session information.");
        _sqlQueries.StoreSessionInformation(access_token, _token_type, issued, expires, null, int.Parse(userloggingin));
        return _successReturnText.Replace("@errorNumber", "0").Replace("@access_token", access_token).Replace("@token_type", _token_type).Replace("@expires_in", _expiresIn.ToString());
    }

    private bool validateAccessToken(string access_token, SqlConnection connection)
    {
        Log.Logger.Information("Validating access token.");
        SqlCommand command2 = new SqlCommand(_validateaccesstokenquery, connection);
        command2.Parameters.AddWithValue("@access_token", access_token);
        SqlDataReader reader = command2.ExecuteReader();

        if (reader.HasRows)
        {
            reader.Close();
            return false;
        }
        else
        {
            reader.Close();
            return true;
        }
    }

    private void UpdateSessionInformation(string access_token, SqlConnection connection, DateTimeOffset newSessionExpiration)
    {
        var sessiontoupdate = _context.Sessions
            .Where(s => s.AccessToken == access_token)
            .ToList();

        sessiontoupdate[0].ExpirationDate = newSessionExpiration.ToString();
        _context.SaveChanges();
        return;
    }

    public int getUserSessionUserNum(string access_token)
    {
        var usersessionusernum = _context.Sessions
            .Where(s => s.AccessToken == access_token)
            .Select(s => s.UserNum)
            .ToList();

        return usersessionusernum[0];
    }

    public void logoutUser(string access_token)
    {
        Log.Logger.Information("Logging out user and deleting session information.");
        _sqlQueries.writeToSecurityLogTable(2, getUserSessionUserNum(access_token));
        _sqlQueries.DeleteSessionInformation(access_token, null);
        return;
    }

    public string ResetPassword(string username, string password, string newpassword)
    {
        Log.Logger.Information("Resetting password for user \"{username}\".", username);
        string currentpasswordHash = _sqlQueries.hashpassword(password);
        string newpasswordHash = _sqlQueries.hashpassword(newpassword);

        var usracct = _context.UserAccounts
            .Where(u => u.Username == username)
            .ToList();

        if(usracct.Count <= 0)
        {
            return _errorReturnText.Replace("@errorNumber", "10").Replace("@errorMessage", "User not found by username.");
        }

        if(usracct.Count > 1)
        {
            return _errorReturnText.Replace("@errorNumber", "6").Replace("@errorMessage", "Multiple users found with the same username.");
        }

        if(usracct[0].Password != currentpasswordHash)
        {
            return _errorReturnText.Replace("@errorNumber", "5").Replace("@errorMessage", "Invalid current password.");
        }

        usracct[0].Password = newpasswordHash;
        usracct[0].PasswordResetOnNextLogin = false;
        usracct[0].LastEditedDate = DateTimeOffset.Now.ToString();
        _context.SaveChanges();
        return _successReturnText.Replace("@errorNumber", "0").Replace("@access_token", "").Replace("@token_type", "").Replace("@expires_in", "");
    }

    public string ForgotPasswordRequest(string username, string toemailaddress, IConfiguration configuration)
    {
        //TODO: Need to update this to use the SQLite database context.
        Log.Logger.Information(username + " has requested a password reset.");
        string result = "";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string query = "SELECT [usernum] FROM [COMACON].[dbo].[useraccounts] WHERE [username] = '" + username + "' and [emailaddress] = '" + toemailaddress + "'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //Checks if the reader has any rows.
                    if (!reader.HasRows)
                    {
                        connection.Close();
                        throw new Exception(_errorReturnText.Replace("@errorNumber", "3").Replace("@errorMessage", "Invalid Username or Email Address."));
                    }

                    //Checks if there are multiple rows.
                    int rowCount = 0;
                    int usernumloggingin = 0;
                    while (reader.Read())
                    {
                        rowCount++;
                        if (rowCount > 1)
                        {
                            connection.Close();
                            throw new Exception(_errorReturnText.Replace("@errorNumber", "4").Replace("@errorMessage", "Multiple users found with the same username and email address."));
                        }
                        usernumloggingin = (int)reader["usernum"];
                    }

                    reader.Close();

                    int randompasswordlength = 12;
                    const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";

                    StringBuilder randompassword = new StringBuilder();
                    Random random = new Random();

                    while (0 < randompasswordlength--)
                    {
                        randompassword.Append(validChars[random.Next(validChars.Length)]);
                    }

                    string newpassword = randompassword.ToString();

                    sendEmail(configuration, newpassword, toemailaddress);

                    connection.Close();
                }
            }
        }

        return result;
    }

    private void sendEmail(IConfiguration configuration, string newpassword, string toemailaddress)
    {
        //TODO: Need to update this to use the SQLite database context.
        //Need to send the email with the new password.
        SmtpServerConfiguration smtpconfig = new SmtpServerConfiguration();
        configuration.GetSection("SmtpServerConfiguration").Bind(smtpconfig);

        try
        {
            var smtpClient = new SmtpClient()
            {
                Port = smtpconfig.SmtpServerPort,
                Credentials = new System.Net.NetworkCredential(smtpconfig.SmtpServerUsername, smtpconfig.SmtpServerPassword),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("onbasecomacon@noreply.com"),
                Subject = "Password Reset",
                Body = "Your new password is: " + newpassword,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toemailaddress);

            smtpClient.Send(mailMessage);
        }
        catch (Exception ex)
        {
            Log.Logger.Error("Failed to send email to " + toemailaddress + " with the new password.");
            Log.Logger.Error(ex.StackTrace);
            throw new Exception(_errorReturnText.Replace("@errorNumber", "9").Replace("@errorMessage", "Failed to send email with new password."));
        }
    }
}