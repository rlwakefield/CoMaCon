using COMACONTranslationToHelperUtility;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Configuration;
using System.Xml;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;


namespace COMACON_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //This tells me whether to get or set sections
            string action = "";
            try
            {
                action = args[0];
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Argument1 Error: " + ex.Message);
            }

            //This is the application+path to pull in the web.config file.
            string applicationPath = "";
            try
            {
                applicationPath = args[1];
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Argument2 Error: " + ex.Message);
            }

            //This is to know what the application is that we are doing the work for so we don't try and do something that isn't needed.
            string applicationType = "";
            try
            {
                applicationType = args[2];
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Argument3 Error: " + ex.Message);
            }

            //This is the translation utility string that will need to be deserialized.
            string serializedInputObject = "";
            try
            {
                serializedInputObject = args[3];
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Argument4 Error: " + ex.Message);
            }

            //This is the Translation Array to pull back the values needed.
            string TranslationArray = "";
            try
            {
                TranslationArray = args[4];
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Argument5 Error: " + ex.Message);
            }

            //This is the encrypted value of all of the sections above.
            string encryptedValue = "";
            try
            {
                encryptedValue = args[5];
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Argument6 Error: " + ex.Message);
            }

            Configuration config = WebConfigurationManager.OpenWebConfiguration(applicationPath);

            switch (action)
            {
                case "get":
                    Dictionary<string, List<List<string>>> TranslationArrayToParse = JsonConvert.DeserializeObject<Dictionary<string, List<List<string>>>>(TranslationArray);
                    var translatorToReturn = new NETCoreToNetFrameworkTranslator();

                    foreach (var key in TranslationArrayToParse.Keys)
                    {
                        //Gets the configuration section
                        ConfigurationSection section = config.GetSection(key);

                        //Checks if the section is encrypted or not. If it is, then it decrypts it so that the values can be read.
                        if (section.SectionInformation.IsProtected)
                        {
                            section.SectionInformation.UnprotectSection();
                            var encryptedList = TranslationArrayToParse[key]
                                .FirstOrDefault(list => list.Count > 0 && list[0] == "IsEncrypted");
                            encryptedList[4] = "True";
                        }

                        //Creates a blank XmlDocument and loads the raw XML into it.
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.LoadXml(section.SectionInformation.GetRawXml());

                        //Attempts to select each of the different elements and then assigns the value to the appropriate variable.
                        foreach (var elements in TranslationArrayToParse[key])
                        {
                            if (elements[0] != "IsEncrypted")
                            {
                                elements[4] = xmlDocument.SelectSingleNode(key + "/" + elements[0]).Attributes[elements[1]].Value;
                            }
                        }
                    }

                    if (applicationType == "Application Server")
                    {
                        //Creates the new ConnectionStrings object and assigns it the appropriate values.
                        ConnectionStrings cstrings = new ConnectionStrings();

                        //Create the XmlDocument object.
                        XmlDocument xmlDocument = new XmlDocument();

                        //Gets the configuration section
                        ConfigurationSection section = config.GetSection("connectionStrings");

                        if (section.SectionInformation.IsProtected)
                        {
                            section.SectionInformation.UnprotectSection();
                            cstrings.EncryptConnectionStrings = "True";
                        }

                        xmlDocument.LoadXml(section.SectionInformation.GetRawXml());
                        XmlNodeList connStrings = xmlDocument.SelectSingleNode("connectionStrings").SelectNodes("add");
                        foreach (XmlNode connString in connStrings)
                        {
                            if(connString.Attributes["providerName"].Value == "Oracle.ManagedDataAccess.Client" || connString.Attributes["providerName"].Value == "System.Data.SqlClient")
                            {
                                ConnectionStringV2 connectionStringV2 = new ConnectionStringV2();
                                switch (connString.Attributes["providerName"].Value)
                                {
                                    case "Oracle.ManagedDataAccess.Client":
                                        OracleConnectionStringBuilder oracleBuilder = new OracleConnectionStringBuilder(connString.Attributes["connectionString"].Value);
                                        connectionStringV2.Provider = "Oracle.ManagedDataAccess.Client";
                                        connectionStringV2.Name = connString.Attributes["name"].Value;
                                        connectionStringV2.IntegratedSecurity = oracleBuilder.UserID == "/" ? "True" : "False";

                                        if (bool.Parse(connectionStringV2.IntegratedSecurity))
                                        {
                                            connectionStringV2.UserId = "";
                                            connectionStringV2.Password = "";
                                        }
                                        else
                                        {
                                            connectionStringV2.UserId = oracleBuilder.UserID;
                                            connectionStringV2.Password = oracleBuilder.Password;
                                        }

                                        string pattern = @"(\w+=\w+)(?=\))";
                                        MatchCollection matches = Regex.Matches(oracleBuilder.ConnectionString, pattern);

                                        Dictionary<string, string> connectionStringValues = new Dictionary<string, string>();
                                        foreach (Match match in matches)
                                        {
                                            string[] connectionStringArray = match.ToString().Split('=');
                                            connectionStringValues.Add(connectionStringArray[0], connectionStringArray[1]);
                                        }

                                        try
                                        {
                                            connectionStringV2.oracle.TNSConnectionString = "True";
                                            connectionStringV2.oracle.Host = connectionStringValues["HOST"];
                                            connectionStringV2.oracle.Port = connectionStringValues["PORT"];
                                            connectionStringV2.oracle.Database = connectionStringValues["SERVICE_NAME"];
                                            connectionStringV2.oracle.Protocol = connectionStringValues["PROTOCOL"];
                                        }
                                        catch (Exception e)
                                        {
                                            connectionStringV2.oracle.TNSConnectionString = "False";
                                            connectionStringV2.oracle.Host = oracleBuilder.DataSource;
                                        }

                                        break;
                                    case "System.Data.SqlClient":
                                        connectionStringV2.Provider = "System.Data.SqlClient";
                                        connectionStringV2.Name = connString.Attributes["name"].Value;
                                        SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder(connString.Attributes["connectionString"].Value);
                                        connectionStringV2.sql.DataSource = sqlBuilder.DataSource;
                                        connectionStringV2.sql.Database = sqlBuilder.InitialCatalog;
                                        connectionStringV2.IntegratedSecurity = sqlBuilder.IntegratedSecurity.ToString();
                                        connectionStringV2.UserId = sqlBuilder.UserID;
                                        connectionStringV2.Password = sqlBuilder.Password;

                                        break;
                                }
                                cstrings.connectionStrings.Add(connectionStringV2);
                            }
                        }
                        translatorToReturn.connectionStrings = cstrings;
                    }

                    foreach (var key in TranslationArrayToParse.Keys)
                    {
                        foreach (var elements in TranslationArrayToParse[key])
                        {
                            Key k = new Key();
                            k.Section = key;
                            k.PathName = elements[0];
                            k.AttributeName = elements[1];
                            k.Type = elements[2];
                            k.HtmlIdName = elements[3];
                            k.Value = elements[4];
                            k.Version = elements[5];
                            k.minimumValue = elements[6];
                            k.maximumValue = elements[7];
                            translatorToReturn.knownKeys.Add(k);
                        }
                    }

                    //var data = JsonConvert.SerializeObject(translatorToReturn);
                    //var encryptedBytes = Convert.ToBase64String(ProtectedData.Protect(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(translatorToReturn)), null, DataProtectionScope.CurrentUser));
                    //var encryptedString = Convert.ToBase64String(encryptedBytes);
                    Console.WriteLine(Convert.ToBase64String(ProtectedData.Protect(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(translatorToReturn)), null, DataProtectionScope.LocalMachine)));
                    break;
                case "set":
                    serializedInputObject = Encoding.UTF8.GetString(ProtectedData.Unprotect(Convert.FromBase64String(serializedInputObject), null, DataProtectionScope.LocalMachine));
                    var translatorToSet = JsonConvert.DeserializeObject<NETCoreToNetFrameworkTranslator>(serializedInputObject);
                    //I have a list of Key objects underneath the translatorToSet.knownKeys object. However, I need to be able to group them by the section name and then process them in that way. How would I do so?
                    var groupedKeys = translatorToSet.knownKeys.GroupBy(key => key.Section);

                    foreach (var group in groupedKeys)
                    {
                        //Console.WriteLine($"Section: {group.Key}");
                        ConfigurationSection section = config.GetSection(group.Key);
                        if (section.SectionInformation.IsProtected)
                        {
                            section.SectionInformation.UnprotectSection();
                        }

                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.LoadXml(section.SectionInformation.GetRawXml());

                        foreach (var key in group)
                        {
                            //Verifies that the key is not the "IsEncrypted" key.
                            if(key.PathName != "IsEncrypted")
                            {
                                xmlDocument.SelectSingleNode(group.Key + "/" + key.PathName).Attributes[key.AttributeName].Value = key.Value;
                                //Console.WriteLine($"{key.PathName}: {key.Value}");
                                //Console.WriteLine(xmlDocument.SelectSingleNode(group.Key + "/" + key.PathName).Attributes[key.AttributeName].Value);
                            }
                        }

                        foreach (var key in group)
                        {
                            //Verifies that the key is the "IsEncrypted" key.
                            if (key.PathName == "IsEncrypted" && bool.Parse(key.Value))
                            {
                                section.SectionInformation.ProtectSection("DpapiProvider");
                            }
                        }
                        section.SectionInformation.SetRawXml(xmlDocument.OuterXml);
                    }

                    if(applicationType == "Application Server")
                    {
                        //Creates the new ConnectionStrings object and assigns it the appropriate values.
                        ConnectionStrings cstrings = new ConnectionStrings();

                        //Create the XmlDocument object.
                        XmlDocument xmlDocument = new XmlDocument();

                        //Gets the configuration section
                        ConfigurationSection section = config.GetSection("connectionStrings");

                        if (section.SectionInformation.IsProtected)
                        {
                            section.SectionInformation.UnprotectSection();
                        }

                        xmlDocument.LoadXml(section.SectionInformation.GetRawXml());
                        XmlNode xmlNode = xmlDocument.SelectSingleNode("connectionStrings");
                        xmlNode.RemoveAll();

                        foreach (ConnectionStringV2 connectionStringV2 in translatorToSet.connectionStrings.connectionStrings)
                        {
                            XmlElement addElement = xmlDocument.CreateElement("add");
                            //Build and set the name attribute.
                            addElement.SetAttribute("name", connectionStringV2.Name);
                            XmlAttribute providerName = xmlDocument.CreateAttribute("providerName");
                            providerName.Value = connectionStringV2.Provider;

                            switch (connectionStringV2.Provider)
                            {
                                case "System.Data.SqlClient":
                                    //Build the connection string attribute value.
                                    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                                    builder.DataSource = connectionStringV2.sql.DataSource;
                                    builder.InitialCatalog = connectionStringV2.sql.Database;

                                    if (bool.Parse(connectionStringV2.IntegratedSecurity))
                                    {
                                        builder.IntegratedSecurity = bool.Parse(connectionStringV2.IntegratedSecurity);
                                    }
                                    else
                                    {
                                        builder.UserID = connectionStringV2.UserId;
                                        builder.Password = connectionStringV2.Password;
                                    }

                                    addElement.SetAttribute("connectionString", builder.ConnectionString.Replace("Initial Catalog", "database").Replace("User ID", "User Id"));
                                    addElement.SetAttribute("providerName", connectionStringV2.Provider);
                                    break;
                                case "Oracle.ManagedDataAccess.Client":
                                    string oracleConnectionString = "";
                                    if (bool.Parse(connectionStringV2.oracle.TNSConnectionString))
                                    {
                                        if(bool.Parse(connectionStringV2.IntegratedSecurity))
                                        {
                                            oracleConnectionString = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL={connectionStringV2.oracle.Protocol})(HOST={connectionStringV2.oracle.Host})(PORT={connectionStringV2.oracle.Port}))(CONNECT_DATA=(SERVICE_NAME={connectionStringV2.oracle.Database})));User Id= /;";
                                        }
                                        else
                                        {
                                            oracleConnectionString = $"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL={connectionStringV2.oracle.Protocol})(HOST={connectionStringV2.oracle.Host})(PORT={connectionStringV2.oracle.Port}))(CONNECT_DATA=(SERVICE_NAME={connectionStringV2.oracle.Database})));User Id={connectionStringV2.UserId};Password={connectionStringV2.Password};";
                                        }
                                    }
                                    else
                                    {
                                        if (bool.Parse(connectionStringV2.IntegratedSecurity))
                                        {
                                            oracleConnectionString = $"Data Source={connectionStringV2.oracle.Host};User Id= /;";
                                        }
                                        else
                                        {
                                            oracleConnectionString = $"Data Source={connectionStringV2.oracle.Host};User Id={connectionStringV2.UserId};Password={connectionStringV2.Password};";
                                        }
                                    }

                                    addElement.SetAttribute("connectionString", oracleConnectionString);
                                    addElement.SetAttribute("providerName", connectionStringV2.Provider);
                                    break;
                            }
                            xmlNode.AppendChild(addElement);
                        }
                        section.SectionInformation.SetRawXml(xmlDocument.OuterXml);

                        if (bool.Parse(translatorToSet.connectionStrings.EncryptConnectionStrings))
                        {
                            section.SectionInformation.ProtectSection("DpapiProvider");
                        }
                    }
                    config.Save();
                    break;
            }
        }
    }
}