using Newtonsoft.Json;
using Serilog;
using System.Data.SqlClient;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;

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
    public string ValidateUserLoggingIn(string username,
        string password);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="username"></param>
    /// <param name="password"></param>
    /// <returns>
    /// 
    /// </returns>
    public string ValidateUserLoggingInV2(string username,
        string password);
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""></param>
    /// <returns>
    /// 
    /// </returns>
    public void StoreSessionInformation(string access_Token,
        string token_type,
        DateTime issued,
        DateTime expires,
        SqlConnection connection);
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""></param>
    /// <returns>
    /// 
    /// </returns>
    public bool validateAccessTokenStillActive(string access_token);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="access_token"></param>
    /// <returns>
    /// 
    /// </returns>
    public string validateAccessTokenStillActiveV2(string access_token);
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""></param>
    /// <returns>
    /// 
    /// </returns>
    public string generateAccessToken();
}

internal sealed class DefaultSessionManagement : SessionManagement
{
    private readonly int _expiresIn = 3600;
    private readonly string _token_type = "Bearer";
    private readonly string _errorReturnText = "{\"error\":\"@errorNumber\",\"message\":\"@errorMessage\"}";
    private readonly string _successReturnText = "{\"error\":\"@errorNumber\",\"access_token\":\"@access_token\",\"token_type\":\"@token_type\",\"expires_in\":\"@expires_in\"}";

    public string ValidateUserLoggingIn(string username, string password)
    {
        /* Returns the results of the Creation.
        * 0 = Success
        * 1 = Username missing.
        * 2 = Password missing.
        * 3 = Username or password does not match.
        * 4 = Multiple users found with the same username and password.
        */
        //Console.WriteLine("Authenticating user \""+username+"\".");
        Log.Logger.Information("Authenticating user \"{username}\".", username);
        string connectionString = "Server=DESKTOP-6I1HC77\\COMACON;Database=COMACON;Trusted_Connection=yes;";
        string passwordHash = "";
        using (SqlConnection connection = new SqlConnection(connectionString))
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
            string query = "SELECT [usernum] FROM [COMACON].[dbo].[useraccounts] WHERE [username] = '" + username + "' and [password] = '" + passwordHash + "'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //Checks if the reader has any rows.
                    if (!reader.HasRows)
                    {
                        connection.Close();
                        return _errorReturnText.Replace("@errorNumber", "3").Replace("@errorMessage", "Invalid Username or Password.");
                            //"{\"error\":\"3\",\"message\":\"Invalid Username or Password.\"}";
                    }

                    //Checks if there are multiple rows.
                    int rowCount = 0;
                    while (reader.Read())
                    {
                        rowCount++;
                        //Console.WriteLine(rowCount);
                        if (rowCount > 1)
                        {
                            connection.Close();
                            return _errorReturnText.Replace("@errorNumber", "4").Replace("@errorMessage", "Multiple users found with the same username and password.");
                                //"{\"error\":\"4\",\"message\":\"Invalid Username or Password.\"}";
                        }
                    }

                    //command.CommandText = "SELECT * FROM [COMACON].[dbo].[sessions] WHERE [username] = '" + username + "'";
                    reader.Close();

                    //Generate a Bearer access token value.
                    DateTime issued = DateTime.Now;

                    bool validAccessToken = false;
                    string access_token = "";
                    do
                    {
                        access_token = Guid.NewGuid().ToString();
                        validAccessToken = validateAccessToken(access_token, connection);
                    } while (!validAccessToken);

                    //string token_type = "Bearer";
                    //int expiresIn = 3600;
                    DateTime expires = DateTime.Now.AddSeconds(_expiresIn);
                    Log.Logger.Information("User \"{username}\" successfully authenticated.", username);
                    Log.Logger.Information("Storing session information.");

                    StoreSessionInformation(access_token, _token_type, issued, expires, connection);

                    connection.Close();

                    return _successReturnText.Replace("@errorNumber", "0").Replace("@access_token", access_token).Replace("@token_type", _token_type).Replace("@expires_in", _expiresIn.ToString());
                        /*"{" +
                                "\"error\": \"0\"" + "," +
                                "\"access_token\":\"" + access_token + "\"," +
                                "\"token_type\":\"" + _token_type + "\"," +
                                "\"expires_in\":\"" + _expiresIn + "\"" +
                            "}";*/
                }
            }
        }
    }

    public string ValidateUserLoggingInV2(string username, string password)
    {
        /* Returns the results of the Creation.
        * 0 = Success
        * 1 = Username missing.
        * 2 = Password missing.
        * 3 = Username or password does not match.
        * 4 = Multiple users found with the same username and password.
        */
        //Console.WriteLine("Authenticating user \""+username+"\".");
        Log.Logger.Information("Authenticating user \"{username}\".", username);
        string connectionString = "Server=DESKTOP-6I1HC77\\COMACON;Database=COMACON;Trusted_Connection=yes;";
        string passwordHash = "";
        using (SqlConnection connection = new SqlConnection(connectionString))
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
            string query = "SELECT [usernum] FROM [COMACON].[dbo].[useraccounts] WHERE [username] = '" + username + "' and [password] = '" + passwordHash + "'";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //Checks if the reader has any rows.
                    if (!reader.HasRows)
                    {
                        connection.Close();
                        return _errorReturnText.Replace("@errorNumber", "3").Replace("@errorMessage", "Invalid Username or Password.");
                        //"{\"error\":\"3\",\"message\":\"Invalid Username or Password.\"}";
                    }

                    //Checks if there are multiple rows.
                    int rowCount = 0;
                    while (reader.Read())
                    {
                        rowCount++;
                        //Console.WriteLine(rowCount);
                        if (rowCount > 1)
                        {
                            connection.Close();
                            return _errorReturnText.Replace("@errorNumber", "4").Replace("@errorMessage", "Multiple users found with the same username and password.");
                            //"{\"error\":\"4\",\"message\":\"Invalid Username or Password.\"}";
                        }
                    }

                    //command.CommandText = "SELECT * FROM [COMACON].[dbo].[sessions] WHERE [username] = '" + username + "'";
                    reader.Close();
                    Log.Logger.Information("User \"{username}\" successfully authenticated.", username);
                    //connection.Close();
                    return _errorReturnText.Replace("@errorNumber", "0").Replace("@errorMessage", "Success");

                    /*"{" +
                            "\"error\": \"0\"" + "," +
                            "\"access_token\":\"" + access_token + "\"," +
                            "\"token_type\":\"" + _token_type + "\"," +
                            "\"expires_in\":\"" + _expiresIn + "\"" +
                        "}";*/
                }
            }
        }
    }

    public string validateAccessTokenStillActiveV2(string access_token)
    {
        string connectionString = "Server=DESKTOP-6I1HC77\\COMACON;Database=COMACON;Trusted_Connection=yes;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string accessTokenSqlQuery = "SELECT [access_token] FROM [COMACON].[dbo].[sessions] WHERE [access_token] = '@access_token'";

            using(SqlCommand command = new SqlCommand(accessTokenSqlQuery, connection))
            {
                command.Parameters.AddWithValue("@access_token", access_token);

                using(SqlDataReader reader = command.ExecuteReader())
                {
                    return _successReturnText.Replace("@errorNumber", "0").Replace("@access_token", access_token).Replace("@token_type", _token_type).Replace("@expires_in", _expiresIn.ToString());
                }
            }
        }
    }

    public string generateAccessToken()
    {
        string connectionString = "Server=DESKTOP-6I1HC77\\COMACON;Database=COMACON;Trusted_Connection=yes;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            //Generate a Bearer access token value.
            DateTime issued = DateTime.Now;

            bool validAccessToken = false;
            string access_token = "";
            do
            {
                access_token = Guid.NewGuid().ToString();
                validAccessToken = validateAccessToken(access_token, connection);
            } while (!validAccessToken);

            //string token_type = "Bearer";
            //int expiresIn = 3600;
            DateTime expires = DateTime.Now.AddSeconds(_expiresIn);
            Log.Logger.Information("Storing session information.");

            StoreSessionInformation(access_token, _token_type, issued, expires, connection);

            connection.Close();

            return _successReturnText.Replace("@errorNumber", "0").Replace("@access_token", access_token).Replace("@token_type", _token_type).Replace("@expires_in", _expiresIn.ToString());
        }
    }

    public void StoreSessionInformation(string access_Token, string token_type, DateTime issued, DateTime expires, SqlConnection connection)
    {
        string query = "INSERT INTO [COMACON].[dbo].[sessions] ([access_token], [token_type], [creationdate], [expirationdate]) VALUES ('" + access_Token + "', '" + token_type + "', '" + issued + "', '" + expires + "')";
        int numRowsAffected = 0;

        using (SqlCommand command = new SqlCommand(query, connection))
        {
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

    private bool validateAccessToken(string access_token, SqlConnection connection)
    {
        Log.Logger.Information("Validating access token.");
        string guidSqlQuery = "SELECT [access_token] FROM [COMACON].[dbo].[sessions] WHERE [access_token] = '" + access_token + "'";
        SqlCommand command2 = new SqlCommand(guidSqlQuery, connection);
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

    public bool validateAccessTokenStillActive(string access_token)
    {
        string tokenQuery = "SELECT * FROM [COMACON].[dbo].[sessions] WHERE [access_token] = @access_token";
        string connectionString = "Server=DESKTOP-6I1HC77\\COMACON;Database=COMACON;Trusted_Connection=yes;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand(tokenQuery, connection))
            {
                // Add the parameter to the command
                command.Parameters.AddWithValue("@access_token", access_token);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine(reader.HasRows);
                    //Checks if the reader has any rows.
                    if (!reader.HasRows)
                    {
                        //connection.Close();
                        return false;
                    }

                    //Checks if there are multiple rows.
                    int rowCount = 0;
                    DateTime expirationDate = DateTime.MinValue;

                    while (reader.Read())
                    {
                        rowCount++;
                        if (rowCount > 1)
                        {
                            //connection.Close();
                            return false;
                        }

                        expirationDate = (DateTime)reader["expirationdate"];
                    }

                    if (expirationDate < DateTime.Now)
                    {
                        DeleteSessionInformation(access_token, connection);
                        return false;
                    }

                    //If the token is still active, update the expiration date.
                    DateTime newSessionExpiration = DateTime.Now.AddSeconds(_expiresIn);
                    reader.Close();
                    UpdateSessionInformation(access_token, connection, newSessionExpiration);
                    connection.Close();
                    return true;
                }
            }
        }

        //return true;
    }

    private void UpdateSessionInformation(string access_token, SqlConnection connection, DateTime newSessionExpiration)
    {
        //@access_token
        //@newSessionExpiration
        string updateQuery = "UPDATE [COMACON].[dbo].[sessions] SET [expirationdate] = @newSessionExpiration WHERE [access_token] = @access_token";
        using (SqlCommand command = new SqlCommand(updateQuery, connection))
        {
            command.Parameters.AddWithValue("@access_token", access_token);
            command.Parameters.AddWithValue("@newSessionExpiration", newSessionExpiration);

            command.ExecuteNonQuery();
        }
    }

    private void DeleteSessionInformation(string access_token, SqlConnection connection)
    {
        string deleteQuery = "DELETE from [COMACON].[dbo].[sessions] WHERE [access_token] = @access_token";
        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
        {
            command.Parameters.AddWithValue("@access_token", access_token);

            command.ExecuteNonQuery();
        }
    }
}
