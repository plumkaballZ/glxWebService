using GlbXWebService.ConnMaster.ext;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService.ConnMaster
{
    public class ConnMaster_MySql : init_ConnMaster, IConnMaster<MySqlConnection>
    {
        public ConnMaster_MySql(string server, string db, string user, string pw, uint timeout = 60, uint port = 3306, bool allowZeroDateTime = true)
          : base(server, db, user, pw, timeout, port, allowZeroDateTime)
        {
            MySqlConnectionStringBuilder _conStrBuilder = new MySqlConnectionStringBuilder
            {
                Server = server,
                Database = db,
                UserID = user,
                Password = pw,
                ConnectionTimeout = timeout,
                Port = port,
                AllowZeroDateTime = allowZeroDateTime
            };

            ConnStr = _conStrBuilder.ConnectionString;
        }
        public string ConnStr { get; set; }
        public MySqlConnection GetOpenConn()
        {
            var conn = new MySqlConnection(ConnStr);

            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return conn;
        }
    }
}
