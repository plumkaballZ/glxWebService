using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bifrost.ConnMaster_2
{
    public class mySql_Conn : _baseConn, IConn<MySqlConnection>
    {
        public string _connStr { get; set; }

        public MySqlConnection GetOpenConn()
        {
            var conn = new MySqlConnection(_connStr);

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
