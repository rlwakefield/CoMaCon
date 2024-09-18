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

namespace COMACON.config;

public interface SessionManagement
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns>
    /// 
    /// </returns>
    //public string ValidateUserLoggingIn(string username,
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
    /// <param name=""></param>
    /// <returns>
    /// 
    /// </returns>
    //public void StoreSessionInformation(string access_Token,
    //    string token_type,
    //    DateTime issued,
    //    DateTime expires,
    //    SqlConnection connection,
    //    int usernumloggingin);
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""></param>
    /// <returns>
    /// 
    /// </returns>
    //public bool validateAccessTokenStillActive(string access_token);
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
    private string _validateuserlogginginquery = "SELECT * FROM [COMACON].[dbo].[useraccounts] WHERE [username] = @username and [password] = @passwordHash";
    private string _validateaccesstokenstillactivesqlquery = "SELECT [access_token] FROM [COMACON].[dbo].[sessions] WHERE [access_token] = '@access_token'";
    private string _validateaccesstokenquery = "SELECT [access_token] FROM [COMACON].[dbo].[sessions] WHERE [access_token] = '@access_token'";
    private string _updatesessioninformationquery = "UPDATE [COMACON].[dbo].[sessions] SET [expirationdate] = @newSessionExpiration WHERE [access_token] = @access_token";
    private string _getusersessionusernumquery = "SELECT [usernum] FROM [COMACON].[dbo].[sessions] WHERE [access_token] = @access_token";
    private string _resetpasswordquery = "SELECT [usernum] FROM [COMACON].[dbo].[useraccounts] WHERE [username] = '@username' and [password] = '@currentpasswordHash'";
    /* This Dictionary will be used to store the standardized security log messages and their corresponding eventid numbers
     * Different ranges of numbers will represent different types of events.
     * Those ranges are as follows:
     * 1-500 = User Account Events
     * 501-2500 = Web Application Events
     */
    private static string _connectionString = "";
    private readonly SqlQueries _sqlQueries;

    public DefaultSessionManagement(IConfiguration configuration, SqlQueries sqlQueries)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _sqlQueries = sqlQueries;
    }

    //public string ValidateUserLoggingIn(string username, string password)
    //{
    //    /* Returns the results of the Creation.
    //    * 0 = Success
    //    * 1 = Username missing.
    //    * 2 = Password missing.
    //    * 3 = Username or password does not match.
    //    * 4 = Multiple users found with the same username and password.
    //    */
    //    Log.Logger.Information("Authenticating user \"{username}\".", username);
    //    string passwordHash = "";
    //    using (SqlConnection connection = new SqlConnection(_connectionString))
    //    {
    //        // Create a SHA256 instance
    //        using (SHA256 sha256Hash = SHA256.Create())
    //        {
    //            // Compute the hash - returns byte array
    //            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

    //            // Convert byte array to a string
    //            StringBuilder builder = new StringBuilder();
    //            foreach (byte b in bytes)
    //            {
    //                builder.Append(b.ToString("x2"));
    //            }

    //            passwordHash = builder.ToString();
    //        }

    //        connection.Open();
    //        string query = "SELECT [usernum] FROM [COMACON].[dbo].[useraccounts] WHERE [username] = '" + username + "' and [password] = '" + passwordHash + "'";
    //        using (SqlCommand command = new SqlCommand(query, connection))
    //        {
    //            using (SqlDataReader reader = command.ExecuteReader())
    //            {
    //                //Checks if the reader has any rows.
    //                if (!reader.HasRows)
    //                {
    //                    connection.Close();
    //                    return _errorReturnText.Replace("@errorNumber", "3").Replace("@errorMessage", "Invalid Username or Password.");
    //                }

    //                //Checks if there are multiple rows.
    //                int rowCount = 0;
    //                int usernumloggingin = 0;
    //                while (reader.Read())
    //                {
    //                    rowCount++;
    //                    if (rowCount > 1)
    //                    {
    //                        connection.Close();
    //                        return _errorReturnText.Replace("@errorNumber", "4").Replace("@errorMessage", "Multiple users found with the same username and password.");
    //                    }
    //                    usernumloggingin = (int)reader["usernum"];
    //                }

    //                reader.Close();

    //                //Generate a Bearer access token value.
    //                DateTime issued = DateTime.Now;

    //                bool validAccessToken = false;
    //                string access_token = "";
    //                do
    //                {
    //                    access_token = Guid.NewGuid().ToString();
    //                    validAccessToken = validateAccessToken(access_token, connection);
    //                } while (!validAccessToken);

    //                DateTime expires = DateTime.Now.AddSeconds(_expiresIn);
    //                Log.Logger.Information("User \"{username}\" successfully authenticated.", username);
    //                Log.Logger.Information("Storing session information.");

    //                StoreSessionInformation(access_token, _token_type, issued, expires, connection, usernumloggingin);

    //                connection.Close();

    //                _sqlQueries.writeToSecurityLogTable(1, usernumloggingin);

    //                return _successReturnText.Replace("@errorNumber", "0").Replace("@access_token", access_token).Replace("@token_type", _token_type).Replace("@expires_in", _expiresIn.ToString());
    //            }
    //        }
    //    }
    //}

    public string ValidateUserLoggingIn(string username, string password)
    {
        /* Returns the results of the Creation.
        * 0 = Success
        * 1 = Username missing.
        * 2 = Password missing.
        * 3 = Username or password does not match.
        * 4 = Multiple users found with the same username and password.
        */
        Log.Logger.Information("Authenticating user \"{username}\".", username);
        string passwordHash = "";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            // Create a SHA256 instance
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

                passwordHash = builder.ToString();
            }

            connection.Open();
            //string validateuserlogginginquery = "SELECT * FROM [COMACON].[dbo].[useraccounts] WHERE [username] = '" + username + "' and [password] = '" + passwordHash + "'";
            using (SqlCommand command = new SqlCommand(_validateuserlogginginquery, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@passwordHash", passwordHash);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //Checks if the reader has any rows.
                    if (!reader.HasRows)
                    {
                        connection.Close();
                        return _errorReturnText.Replace("@errorNumber", "3").Replace("@errorMessage", "Invalid Username or Password.");
                    }

                    //Checks if there are multiple rows.
                    int rowCount = 0;
                    int usernumloggingin = 0;
                    bool passwordresetonnextlogin = false;
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["status"]);
                        if (!bool.Parse(reader["status"].ToString()))
                        {
                            _sqlQueries.writeToSecurityLogTable(16, (int)reader["usernum"]);
                            connection.Close();
                            return _errorReturnText.Replace("@errorNumber", "5").Replace("@errorMessage", "Your account has been disabled.");
                        }

                        rowCount++;
                        if (rowCount > 1)
                        {
                            connection.Close();
                            return _errorReturnText.Replace("@errorNumber", "4").Replace("@errorMessage", "Multiple users found with the same username and password.");
                        }
                        usernumloggingin = (int)reader["usernum"];
                        passwordresetonnextlogin = bool.Parse(reader["passwordresetonnextlogin"].ToString());
                    }

                    if (passwordresetonnextlogin)
                    {
                        connection.Close();
                        return _errorReturnText.Replace("@errorNumber", "9").Replace("@errorMessage", "You must reset your password before logging in.");
                    }

                    reader.Close();
                    Log.Logger.Information("User \"{username}\" successfully authenticated.", username);
                    _sqlQueries.writeToSecurityLogTable(1, usernumloggingin);
                    return _errorReturnText.Replace("@errorNumber", "0").Replace("@errorMessage", usernumloggingin.ToString());
                }
            }
        }
    }

    public string validateAccessTokenStillActive(string access_token)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            //string validateaccesstokenstillactivesqlquery = "SELECT [access_token] FROM [COMACON].[dbo].[sessions] WHERE [access_token] = '@access_token'";

            using (SqlCommand command = new SqlCommand(_validateaccesstokenstillactivesqlquery, connection))
            {
                command.Parameters.AddWithValue("@access_token", access_token);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return _successReturnText.Replace("@errorNumber", "0").Replace("@access_token", access_token).Replace("@token_type", _token_type).Replace("@expires_in", _expiresIn.ToString());
                }
            }
        }
    }

    public string generateAccessToken(string userloggingin)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            //Generate a Bearer access token value.
            DateTime issued = DateTime.Now;

            bool validAccessToken = false;
            string access_token = "";
            do
            {
                access_token = Guid.NewGuid().ToString();
            } while (!validateAccessToken(access_token, connection));

            DateTime expires = DateTime.Now.AddSeconds(_expiresIn);
            Log.Logger.Information("Storing session information.");

            _sqlQueries.StoreSessionInformation(access_token, _token_type, issued, expires, connection, int.Parse(userloggingin));

            connection.Close();

            return _successReturnText.Replace("@errorNumber", "0").Replace("@access_token", access_token).Replace("@token_type", _token_type).Replace("@expires_in", _expiresIn.ToString());
        }
    }

    private bool validateAccessToken(string access_token, SqlConnection connection)
    {
        Log.Logger.Information("Validating access token.");
        //string validateaccesstokenquery = "SELECT [access_token] FROM [COMACON].[dbo].[sessions] WHERE [access_token] = '@access_token'";
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

    //public bool validateAccessTokenStillActive(string access_token)
    //{
    //    string tokenQuery = "SELECT * FROM [COMACON].[dbo].[sessions] WHERE [access_token] = @access_token";
    //    using (SqlConnection connection = new SqlConnection(_connectionString))
    //    {
    //        connection.Open();
    //        using (SqlCommand command = new SqlCommand(tokenQuery, connection))
    //        {
    //            // Add the parameter to the command
    //            command.Parameters.AddWithValue("@access_token", access_token);

    //            using (SqlDataReader reader = command.ExecuteReader())
    //            {
    //                Console.WriteLine(reader.HasRows);
    //                //Checks if the reader has any rows.
    //                if (!reader.HasRows)
    //                {
    //                    return false;
    //                }

    //                //Checks if there are multiple rows.
    //                int rowCount = 0;
    //                DateTime expirationDate = DateTime.MinValue;

    //                while (reader.Read())
    //                {
    //                    rowCount++;
    //                    if (rowCount > 1)
    //                    {
    //                        return false;
    //                    }

    //                    expirationDate = (DateTime)reader["expirationdate"];
    //                }

    //                if (expirationDate < DateTime.Now)
    //                {
    //                    DeleteSessionInformation(access_token, connection);
    //                    return false;
    //                }

    //                //If the token is still active, update the expiration date.
    //                DateTime newSessionExpiration = DateTime.Now.AddSeconds(_expiresIn);
    //                reader.Close();
    //                UpdateSessionInformation(access_token, connection, newSessionExpiration);
    //                connection.Close();
    //                return true;
    //            }
    //        }
    //    }
    //}

    private void UpdateSessionInformation(string access_token, SqlConnection connection, DateTime newSessionExpiration)
    {
        //string updatesessioninformationquery = "UPDATE [COMACON].[dbo].[sessions] SET [expirationdate] = @newSessionExpiration WHERE [access_token] = @access_token";
        using (SqlCommand command = new SqlCommand(_updatesessioninformationquery, connection))
        {
            command.Parameters.AddWithValue("@access_token", access_token);
            command.Parameters.AddWithValue("@newSessionExpiration", newSessionExpiration);

            command.ExecuteNonQuery();
        }
    }

    public int getUserSessionUserNum(string access_token)
    {
        //string getusersessionusernumquery = "SELECT [usernum] FROM [COMACON].[dbo].[sessions] WHERE [access_token] = @access_token";

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(_getusersessionusernumquery, connection))
            {
                command.Parameters.AddWithValue("@access_token", access_token);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    int usernum = 0;
                    while (reader.Read())
                    {
                        usernum = (int)reader["usernum"];
                    }

                    return usernum;
                }
            }
        }
    }

    public void logoutUser(string access_token)
    {
        Log.Logger.Information("Logging out user and deleting session information.");
        _sqlQueries.writeToSecurityLogTable(2, getUserSessionUserNum(access_token));

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            _sqlQueries.DeleteSessionInformation(access_token, connection);
        }
    }

    public string ResetPassword(string username, string password, string newpassword)
    {
        Log.Logger.Information("Resetting password for user \"{username}\".", username);
        string currentpasswordHash = "";
        string newpasswordHash = "";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            // Create a SHA256 instance
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

                currentpasswordHash = builder.ToString();
            }

            // Create a SHA256 instance
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute the hash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(newpassword));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                newpasswordHash = builder.ToString();
            }

            connection.Open();
            //string resetpasswordquery = "SELECT [usernum] FROM [COMACON].[dbo].[useraccounts] WHERE [username] = '@username' and [password] = '@currentpasswordHash'";
            using (SqlCommand command = new SqlCommand(_resetpasswordquery, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@currentpasswordHash", currentpasswordHash);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //Checks if the reader has any rows.
                    if (!reader.HasRows)
                    {
                        connection.Close();
                        return _errorReturnText.Replace("@errorNumber", "5").Replace("@errorMessage", "Invalid current password.");
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
                            return _errorReturnText.Replace("@errorNumber", "6").Replace("@errorMessage", "Multiple users found with the same username and password.");
                        }
                        usernumloggingin = (int)reader["usernum"];
                    }
                    Console.WriteLine(usernumloggingin);

                    reader.Close();

                    //Update the password.
                    int rowsaffected = 0;
                    string updateQuery = "UPDATE [COMACON].[dbo].[useraccounts] SET [password] = @newpassword,[passwordresetonnextlogin]=0 WHERE [usernum] = @usernum";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@newpassword", newpasswordHash);
                        updateCommand.Parameters.AddWithValue("@usernum", usernumloggingin);
                        Console.WriteLine(updateCommand.CommandText);

                        rowsaffected = updateCommand.ExecuteNonQuery();
                    }

                    //Check the number of rows affected.
                    //If the number of rows affected is 0, return an error.
                    //If the number of rows affected is 1, return a success message.
                    //If the number of rows affected is greater than 1, return an error.
                    //If the number of rows affected is less than 0, return an error.
                    if (rowsaffected == 0)
                    {
                        return _errorReturnText.Replace("@errorNumber", "7").Replace("@errorMessage", "Failed to update password.");
                    }
                    else if (rowsaffected > 1)
                    {
                        return _errorReturnText.Replace("@errorNumber", "8").Replace("@errorMessage", "Multiple rows affected.");
                    }
                    else if (rowsaffected < 0)
                    {
                        return _errorReturnText.Replace("@errorNumber", "9").Replace("@errorMessage", "Less than 0 rows affected.");
                    }
                    else
                    {
                        _sqlQueries.writeToSecurityLogTable(4, usernumloggingin);
                        return _successReturnText.Replace("@errorNumber", "0").Replace("@access_token", "").Replace("@token_type", "").Replace("@expires_in", "");
                    }
                }
            }
        }
    }

    public string ForgotPasswordRequest(string username, string toemailaddress, IConfiguration configuration)
    {
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