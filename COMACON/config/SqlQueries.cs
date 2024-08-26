using Newtonsoft.Json;
using System.Data.SqlClient;

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
    public string GetUsers(int usernum = 0);
}

internal class DefaultSqlQueries : SqlQueries
{
    public string ValidateUser(string username, string password, SqlConnection connection)
    {
        string query = "SELECT * FROM [COMACON].[dbo].[useraccounts] WHERE [username] = '" + username + "' and [password] = '" + password + "'";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            //results = command.ExecuteReader();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                //Checks if the reader has any rows.
                if (!reader.HasRows)
                {
                    return JsonConvert.SerializeObject("{'error':'3','message':'Username and password don't match.'}");
                }
                else
                {
                    //Checks if there are multiple rows.
                    int rowCount = 0;
                    while (reader.Read())
                    {
                        rowCount++;
                        if (rowCount > 1)
                        {
                            return JsonConvert.SerializeObject("{'error':'3','message':'Multiple users found with the same username and password.'}");
                        }
                    }

                    //Generate a Bearer access token value.
                    string access_Token = "";

                    do
                    {
                        access_Token = Guid.NewGuid().ToString();
                    } while (!validateAccessToken(Guid.NewGuid().ToString(), connection));

                    DateTime issued = DateTime.Now;
                    string token_type = "Bearer";
                    int expiresIn = 3600;
                    DateTime expires = DateTime.Now.AddSeconds(expiresIn);
                    //string refresh_token = Guid.NewGuid().ToString();

                    StoreSessionInformation(access_Token, token_type, issued, expires, connection);

                    return JsonConvert.SerializeObject("" +
                        "{" +
                            "'access_Token':" + access_Token + "," +
                            "'token_type':" + token_type + "," +
                            "'expires_in':" + expiresIn +
                        "}");

                    //return JsonConvert.SerializeObject("{'error':'0','message':'Success'}");
                }

                //while (reader.Read())
                //{
                //    databaseusername = reader["username"].ToString();
                //    databasepassword = reader["password"].ToString();
                //}
            }
        }
    }

    public string GetUsers(int usernum = 0)
    {
        string connectionString = "Server=DESKTOP-6I1HC77\\COMACON;Database=COMACON;Trusted_Connection=yes;";

        using(SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT * FROM [COMACON].[dbo].[useraccounts]";
            if(usernum != 0)
            {
                query = "SELECT * FROM [COMACON].[dbo].[useraccounts] WHERE [usernum] = @usernum";
            }

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                if(usernum != 0)
                {
                    command.Parameters.AddWithValue("@usernum", usernum);
                }
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
                            u.enabled = int.Parse(reader["status"].ToString());
                            u.passwordresetnextlogin = int.Parse(reader["passwordresetnextlogin"].ToString());
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

        //return "";
    }

    public void StoreSessionInformation(string access_token, string token_type, DateTime creationdate, DateTime expirationdate, SqlConnection connection)
    {
        Console.WriteLine("Storing session information");

        string query = "INSERT INTO sessions (access_token, token_type, creationdate, expirationdate) VALUES ('" + access_token + "', '" + token_type + "', " + creationdate + ", " + expirationdate + ");";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.ExecuteNonQuery();
        }
    }

    public bool validateAccessToken(string access_token, SqlConnection connection)
    {
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
}
