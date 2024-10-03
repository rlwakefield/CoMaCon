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
using COMACON.DatabaseContexts.SQLite;

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
        DateTimeOffset issued,
        DateTimeOffset expires,
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
    /// <summary>
    /// 
    /// </summary>
    /// <param name=""></param>
    /// <returns>
    /// 
    /// </returns>
    public string hashpassword(string password);
}

internal class DefaultSqlQueries : SqlQueries
{

    private static string _connectionString;
    private readonly Dictionary<int, string> _securityLogs = new()
    {
        //Values 0 through 1000 are User Account actions.
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
    private string _storesessioninformationinsert = "INSERT INTO [dbo].[sessions] ([access_token], [token_type], [creationdate], [expirationdate], [usernum]) VALUES (@access_Token, @token_type, @issued, @expires, @usernum)";
    private string _deletesessioninformationquery = "DELETE from [dbo].[sessions] WHERE [access_token] = @access_token";
    private string _securityloginsertdefaultquery = "INSERT INTO [dbo].[securitylog] (eventid, usernum, eventdescription, logdate) VALUES (@eventid, @usernum, @eventdescription, @logdate)";
    private string _securityloginsertaffecteduserquery = "INSERT INTO [dbo].[securitylog] (eventid, usernum, eventdescription, affectedusernum, logdate) VALUES (@eventid, @usernum, @eventdescription, @affectedusernum, @logdate)";
    private string _securityloginsertoldvaluenewvaluequery = "INSERT INTO [dbo].[securitylog] (eventid, usernum, eventdescription, affectedusernum, logdate) VALUES (@eventid, @usernum, @eventdescription, @affectedusernum @logdate)";
    private string _securityloginsertaffecteduseroldvaluenewvaluequery = "INSERT INTO [dbo].[securitylog] (eventid, usernum, eventdescription, affectedusernum, logdate) VALUES (@eventid, @usernum, @eventdescription, @affectedusernum, @logdate)";
    private string _getuserbyusernamequery = "SELECT * FROM [dbo].[useraccounts] WHERE [username] = @username";
    private string _createuserquery = "INSERT INTO [dbo].[useraccounts] (username, firstname, lastname, password, emailaddress, status, passwordresetonnextlogin, passwordlastchanged, authmethod, creationdate, createdby, lastediteddate, lasteditedby, roleid) VALUES (@username, @firstname, @lastname, @password, @emailaddress, @status, @passwordresetonnextlogin, @passwordlastchanged, @authmethod, @creationdate, @createdby, @lastediteddate, @lasteditedby, @roleid)";
    private string _getrolesquery = "SELECT * FROM [dbo].[roles]";
    private string _validateaccesstokenquery = "SELECT * FROM sessions WHERE access_token = '@access_token'";
    private string _updateuserquery = "UPDATE [dbo].[useraccounts] SET {0} WHERE [usernum] = @usernum";
    private string _getallusersquery = "SELECT * FROM [dbo].[useraccounts]";
    private string _getuserquery = "SELECT * FROM [dbo].[useraccounts] WHERE [usernum] = @usernum";
    private string _getallpasswordpoliciesquery = "SELECT * FROM [dbo].[passwordpolicies]";
    private string _getpolicyrulebypswdpolicyidquery = "SELECT * FROM [dbo].[passwordrules] WHERE [pswdpolicyid] = @pswdpolicyid";
    private readonly COMACONSqliteDbContext _context;

    public DefaultSqlQueries(IConfiguration configuration,
        COMACONSqliteDbContext context)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
        _context = context;
    }

    public string GetUser(int usernum)
    {
        var usr = _context.UserAccounts
            .Where(u => u.UserNum == usernum)
            .ToList();

        if(usr.Count <= 0)
        {
            return "";
        }

        //UsersDataStructure usersds = new UsersDataStructure();
        //foreach (UserAccount u in usr)
        //{
        //    User u2 = new User();
        //    u2.usernum = u.UserNum;
        //    u2.username = u.Username;
        //    u2.firstname = u.FirstName;
        //    u2.lastname = u.LastName;
        //    u2.emailaddress = u.EmailAddress;
        //    u2.enabled = u.Status ? 1 : 0;
        //    u2.passwordresetonnextlogin = u.PasswordResetOnNextLogin ? 1 : 0;
        //    u2.passwordlastchanged = DateTimeOffset.Parse(u.PasswordLastChanged);
        //    u2.authmethod = u.AuthMethod;
        //    u2.creationdate = DateTimeOffset.Parse(u.CreationDate);
        //    u2.createdby = u.CreatedBy;
        //    u2.lastediteddate = DateTimeOffset.Parse(u.LastEditedDate);
        //    u2.lasteditedby = u.LastEditedBy;
        //    u2.roleid = u.RoleId;
        //    usersds.users.Add(u2);
        //}

        //return JsonConvert.SerializeObject(usersds);
        return JsonConvert.SerializeObject(createUserDataStructureObject(usr));
    }

    public string GetAllUsers()
    {
        var usr = _context.UserAccounts
            .ToList();

        if (usr.Count <= 0)
        {
            return "";
        }

        //UsersDataStructure usersds = new UsersDataStructure();
        //foreach (UserAccount u in usr)
        //{
        //    User u2 = new User();
        //    u2.usernum = u.UserNum;
        //    u2.username = u.Username;
        //    u2.firstname = u.FirstName;
        //    u2.lastname = u.LastName;
        //    u2.emailaddress = u.EmailAddress;
        //    u2.enabled = u.Status ? 1 : 0;
        //    u2.passwordresetonnextlogin = u.PasswordResetOnNextLogin ? 1 : 0;
        //    u2.passwordlastchanged = DateTimeOffset.Parse(u.PasswordLastChanged);
        //    u2.authmethod = u.AuthMethod;
        //    u2.creationdate = DateTimeOffset.Parse(u.CreationDate);
        //    u2.createdby = u.CreatedBy;
        //    u2.lastediteddate = DateTimeOffset.Parse(u.LastEditedDate);
        //    u2.lasteditedby = u.LastEditedBy;
        //    u2.roleid = u.RoleId;
        //    usersds.users.Add(u2);
        //}

        //return JsonConvert.SerializeObject(usersds);
        return JsonConvert.SerializeObject(createUserDataStructureObject(usr));
    }

    public string UpdateUser(User user, int userdoingupdates)
    {
        var usrtoupdate = _context.UserAccounts
            .Where(u => u.UserNum == user.usernum)
            .ToList();

        if (user.username != null)
        {
            writeToSecurityLogTable(6, userdoingupdates, user.usernum, usrtoupdate[0].Username, user.username);
            usrtoupdate[0].Username = user.username;
        }
        if (user.firstname != null)
        {
            writeToSecurityLogTable(7, userdoingupdates, user.usernum, usrtoupdate[0].FirstName, user.firstname);
            usrtoupdate[0].FirstName = user.firstname;
        }
        if (user.lastname != null)
        {
            writeToSecurityLogTable(8, userdoingupdates, user.usernum, usrtoupdate[0].LastName, user.lastname);
            usrtoupdate[0].LastName = user.lastname;
        }
        if (user.password != null)
        {
            writeToSecurityLogTable(13, userdoingupdates, user.usernum);
            usrtoupdate[0].Password = hashpassword(user.password);
        }
        if (user.emailaddress != null)
        {
            writeToSecurityLogTable(9, userdoingupdates, user.usernum, usrtoupdate[0].EmailAddress, user.emailaddress);
            usrtoupdate[0].EmailAddress = user.emailaddress;
        }
        if (user.enabled != null)
        {
            writeToSecurityLogTable(user.enabled == 1 ? 14 : 15, userdoingupdates, user.usernum);
            usrtoupdate[0].Status = user.enabled == 1;
        }
        if (user.passwordresetonnextlogin != null)
        {
            writeToSecurityLogTable(5, userdoingupdates, user.usernum, usrtoupdate[0].PasswordResetOnNextLogin ? "1" : "0", user.passwordresetonnextlogin == 1 ? "1" : "0");
            usrtoupdate[0].PasswordResetOnNextLogin = user.passwordresetonnextlogin == 1;
        }
        if (user.authmethod != null)
        {
            writeToSecurityLogTable(10, userdoingupdates, user.usernum, usrtoupdate[0].AuthMethod.ToString(), user.authmethod.ToString());
            usrtoupdate[0].AuthMethod = (byte)user.authmethod;
        }
        if (user.roleid != null)
        {
            writeToSecurityLogTable(11, userdoingupdates, user.usernum, usrtoupdate[0].Role.RoleId.ToString(), user.roleid.ToString());
            usrtoupdate[0].Role.RoleId = (int)user.roleid;
        }
        usrtoupdate[0].LastEditedDate = DateTimeOffset.Now.ToString();
        usrtoupdate[0].LastEditedBy = userdoingupdates;

        _context.SaveChanges();

        return GetUser(user.usernum);
    }

    public void StoreSessionInformation(string access_Token, string token_type, DateTimeOffset issued, DateTimeOffset expires, SqlConnection connection, int usernumloggingin)
    {
        Session session = new Session
        {
            AccessToken = access_Token,
            TokenType = token_type,
            CreationDate = issued.ToString(),
            ExpirationDate = expires.ToString(),
            UserNum = usernumloggingin
        };

        _context.Sessions.Add(session);

        _context.SaveChanges();
    }

    public bool validateAccessToken(string access_token, SqlConnection connection)
    {
        var sessionvalidation = _context.Sessions
            .Where(s => s.AccessToken == access_token)
            .ToList();
        
        if(sessionvalidation.Count <= 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public string GetRoles()
    {
        var roles = _context.Roles
            .ToList();

        if(roles.Count <= 0)
        {
            return "";
        }

        Roles rolesds = new Roles();
        foreach (Role r1 in roles)
        {
            role r = new role();
            r.roleid = r1.RoleId;
            r.rolename = r1.RoleName;
            r.roledescription = r1.RoleDescription;
            rolesds.roles.Add(r);
        }

        return JsonConvert.SerializeObject(rolesds);
    }

    public string CreateUser(User user, int userdoingcreation)
    {
        UserAccount ua = new UserAccount
        {
            Username = user.username,
            FirstName = user.firstname,
            LastName = user.lastname,
            Password = hashpassword(user.password),
            EmailAddress = user.emailaddress,
            Status = user.enabled == 1,
            PasswordResetOnNextLogin = user.passwordresetonnextlogin == 1,
            PasswordLastChanged = DateTimeOffset.Now.ToString(),
            AuthMethod = (byte)user.authmethod,
            CreationDate = DateTimeOffset.Now.ToString(),
            CreatedBy = userdoingcreation,
            LastEditedDate = DateTimeOffset.Now.ToString(),
            LastEditedBy = userdoingcreation,
            RoleId = (int)user.roleid
        };

        _context.UserAccounts.Add(ua);

        _context.SaveChanges();

        string usercreated = GetUserByUsername(user.username);
        writeToSecurityLogTable(12, userdoingcreation, JsonConvert.DeserializeObject<UsersDataStructure>(usercreated).users[0].usernum);
        return usercreated;
    }

    public string hashpassword(string password)
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
        var usr = _context.UserAccounts
            .Where(u => u.Username == username)
            .ToList();

        if (usr.Count <= 0)
        {
            return "";
        }
        else
        {
            //UsersDataStructure usersds = new UsersDataStructure();
            //foreach (UserAccount u in usr)
            //{
            //    User u2 = new User();
            //    u2.usernum = u.UserNum;
            //    u2.username = u.Username;
            //    u2.firstname = u.FirstName;
            //    u2.lastname = u.LastName;
            //    u2.emailaddress = u.EmailAddress;
            //    u2.enabled = u.Status ? 1 : 0;
            //    u2.passwordresetonnextlogin = u.PasswordResetOnNextLogin ? 1 : 0;
            //    u2.passwordlastchanged = DateTimeOffset.Parse(u.PasswordLastChanged);
            //    u2.authmethod = u.AuthMethod;
            //    u2.creationdate = DateTimeOffset.Parse(u.CreationDate);
            //    u2.createdby = u.CreatedBy;
            //    u2.lastediteddate = DateTimeOffset.Parse(u.LastEditedDate);
            //    u2.lasteditedby = u.LastEditedBy;
            //    u2.roleid = u.RoleId;
            //    usersds.users.Add(u2);
            //}

            //return JsonConvert.SerializeObject(usersds);
            return JsonConvert.SerializeObject(createUserDataStructureObject(usr));
        }
    }

    public void writeToSecurityLogTable(int eventid, int usernumdoingaction)
    {
        SecurityLog sl = new SecurityLog
        {
            EventId = (short)eventid,
            UserNum = usernumdoingaction,
            EventDescription = _securityLogs[eventid],
            LogDate = DateTimeOffset.Now.ToString()
        };

        _context.SecurityLogs.Add(sl);

        _context.SaveChanges();

        return;
    }

    public void writeToSecurityLogTable(int eventid, int usernumdoingaction, int affectedusernum)
    {
        SecurityLog sl = new SecurityLog
        {
            EventId = (short)eventid,
            UserNum = usernumdoingaction,
            EventDescription = _securityLogs[eventid],
            AffectedUserNum = affectedusernum,
            LogDate = DateTimeOffset.Now.ToString()
        };

        _context.SecurityLogs.Add(sl);

        _context.SaveChanges();

        return;
    }

    public void writeToSecurityLogTable(int eventid, int usernumdoingaction, string oldvalue, string newvalue)
    {
        SecurityLog sl = new SecurityLog
        {
            EventId = (short)eventid,
            UserNum = usernumdoingaction,
            EventDescription = string.Format(_securityLogs[eventid], oldvalue, newvalue),
            LogDate = DateTimeOffset.Now.ToString()
        };

        _context.SecurityLogs.Add(sl);

        _context.SaveChanges();

        return;
    }

    public void writeToSecurityLogTable(int eventid, int usernumdoingaction, int affectedusernum, string oldvalue, string newvalue)
    {
        SecurityLog sl = new SecurityLog
        {
            EventId = (short)eventid,
            UserNum = usernumdoingaction,
            EventDescription = string.Format(_securityLogs[eventid], oldvalue, newvalue),
            AffectedUserNum = affectedusernum,
            LogDate = DateTimeOffset.Now.ToString()
        };

        _context.SecurityLogs.Add(sl);

        _context.SaveChanges();

        return;
    }

    public void DeleteSessionInformation(string access_token, SqlConnection connection)
    {
        var session = _context.Sessions
            .Where(s => s.AccessToken == access_token)
            .ToList();

        if(session.Count <= 0)
        {
            return;
        }
        else
        {
            _context.Sessions.Remove(session[0]);
            _context.SaveChanges();
        }

        return;
    }

    public string GetAllPasswordPolicies()
    {
        //TODO: Need to update this to use the SQLite database context.
        var databasepolicies = _context.PasswordPolicies
            .ToList();

        PasswordPolicies pwp = new PasswordPolicies();
        foreach (COMACON.DatabaseContexts.SQLite.PasswordPolicy pp1 in databasepolicies)
        {
            var rules = _context.PasswordRules
                .Where(pr => pr.PswdPolicyId == pp1.PswdPolicyId)
                .ToList();
            PasswordPolicy pp2 = new PasswordPolicy();
            pp2.passwordpolicyid = (int)pp1.PswdPolicyId;
            pp2.passwordpolicytype = pp1.PolicyType;
            pp2.passwordpolicyname = pp1.PolicyName;
            pp2.passwordpolicydescription = pp1.PolicyDescription;
            pp2.passwordpolicyenabled = pp1.PolicyEnabled ? 1 : 0;

            foreach(PasswordRule pr in pp1.PasswordRules)
            {
                PasswordPolicyRule ppr = new PasswordPolicyRule();
                ppr.ruletype = pr.RuleType;
                ppr.rulevalue = (int)pr.RuleValue;
                ppr.ruleenabled = pr.RuleEnabled ? 1 : 0;
                pp2.rules.Add(ppr);
            }
            pwp.passwordpolicies.Add(pp2);
        }

        
        //using (SqlConnection connection = new SqlConnection(_connectionString))
        //{
        //    connection.Open();
        //    List<int> passwordpolicyids = new List<int>();
        //    using (SqlCommand command = new SqlCommand(_getallpasswordpoliciesquery, connection))
        //    {
        //        using (SqlDataReader reader = command.ExecuteReader())
        //        {
        //            if (!reader.HasRows)
        //            {
        //                throw new Exception("No Policies are configured.");
        //            }

        //            while (reader.Read())
        //            {
        //                PasswordPolicy pp = new PasswordPolicy();
        //                pp.passwordpolicyid = int.Parse(reader["pswdpolicyid"].ToString());
        //                pp.passwordpolicytype = int.Parse(reader["policytype"].ToString());
        //                pp.passwordpolicyname = reader["policyname"].ToString();
        //                pp.passwordpolicydescription = reader["policydescription"].ToString();
        //                pp.passwordpolicyenabled = bool.Parse(reader["policyenabled"].ToString()) ? 1 : 0;
        //                pwp.passwordpolicies.Add(pp);
        //            }
        //        }
        //    }

        //    foreach(PasswordPolicy pp in pwp.passwordpolicies)
        //    {
        //        using (SqlCommand command = new SqlCommand(_getpolicyrulebypswdpolicyidquery, connection))
        //        {
        //            command.Parameters.AddWithValue("@pswdpolicyid", pp.passwordpolicyid);
        //            using (SqlDataReader reader = command.ExecuteReader())
        //            {
        //                if (reader.HasRows)
        //                {
        //                    while (reader.Read())
        //                    {
        //                        PasswordPolicyRule ppr = new PasswordPolicyRule();
        //                        ppr.ruletype = int.Parse(reader["ruletype"].ToString());
        //                        ppr.rulevalue = int.Parse(reader["rulevalue"].ToString());
        //                        ppr.ruleenabled = bool.Parse(reader["ruleenabled"].ToString()) ? 1 : 0;
        //                        pp.rules.Add(ppr);
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        return JsonConvert.SerializeObject(pwp);
    }

    private UsersDataStructure createUserDataStructureObject(List<UserAccount> users)
    {
        UsersDataStructure usersds = new UsersDataStructure();
        foreach (UserAccount u in users)
        {
            User u2 = new User();
            u2.usernum = u.UserNum;
            u2.username = u.Username;
            u2.firstname = u.FirstName;
            u2.lastname = u.LastName;
            u2.emailaddress = u.EmailAddress;
            u2.enabled = u.Status ? 1 : 0;
            u2.passwordresetonnextlogin = u.PasswordResetOnNextLogin ? 1 : 0;
            u2.passwordlastchanged = DateTimeOffset.Parse(u.PasswordLastChanged);
            u2.authmethod = u.AuthMethod;
            u2.creationdate = DateTimeOffset.Parse(u.CreationDate);
            u2.createdby = u.CreatedBy;
            u2.lastediteddate = DateTimeOffset.Parse(u.LastEditedDate);
            u2.lasteditedby = u.LastEditedBy;
            u2.roleid = u.RoleId;
            usersds.users.Add(u2);
        }

        return usersds;
    }
}
