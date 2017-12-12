using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;

                MySqlConnectionStringBuilder _conStrBuilder = new MySqlConnectionStringBuilder
                {
                    Server = "62.75.168.220",
                    Database = "Globase",
                    UserID = "superErbz",
                    Password = "Jqi5fqfb",
                    ConnectionTimeout = 60,
                    Port = 3306,
                    AllowZeroDateTime = true
                };

                connection = new MySqlConnection(_conStrBuilder.ConnectionString);
                connection.Open();
            }

            return true;
        }
        public void Close()
        {
            connection.Close();
        }
    }
}
