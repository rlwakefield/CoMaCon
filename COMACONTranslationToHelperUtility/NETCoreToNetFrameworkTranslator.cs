using System.Collections.Generic;

namespace COMACONTranslationToHelperUtility
{
    /*
     ******************************
     *       Core Root Class
     ******************************
     */
    public class NETCoreToNetFrameworkTranslator
    {
        public List<Key> knownKeys = new List<Key>();
        public ConnectionStrings connectionStrings;
    }

    /*
     ******************************
     *        Version 2
     ******************************
     */

    public class Key
    {
        public string Section { get; set; }
        public string PathName { get; set; }
        public string AttributeName { get; set; }
        public string Type { get; set; }
        public string HtmlIdName { get; set; }
        public string Value { get; set; }
        public string Version { get; set; }
        public string minimumValue { get; set; }
        public string maximumValue { get; set; }
    }

    public class ConnectionStrings
    {
        public string EncryptConnectionStrings { get; set; } = "False";
        public List<ConnectionStringV2> connectionStrings = new List<ConnectionStringV2>();
    }

    public class ConnectionStringV2
    {
        public string Name { get; set; } = "";
        public string Provider { get; set; }
        public ConnectionStringSql sql = new ConnectionStringSql();
        public ConnectionStringOracle oracle = new ConnectionStringOracle();
        public string IntegratedSecurity { get; set; } = "True";
        public string UserId { get; set; } = "";
        public string Password { get; set; } = "";
        public string AdditionalOptions { get; set; } = "";
        public string id { get; set; } = "";
    }

    public class ConnectionStringSql
    {
        public string DataSource { get; set; } = "";
        public string Database { get; set; } = "";
    }

    public class ConnectionStringOracle
    {
        public string TNSConnectionString = "true";
        public string Host { get; set; } = "";
        public string Database { get; set; } = "";
        public string Protocol { get; set; } = "TCP";
        public string Port { get; set; } = "";
    }
}