using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace Bifrost.ConnMaster_2
{
    public class sql_Conn : _baseConn, IConn<DbConnection>
    {
        public string _connStr { get; set; }

        public DbConnection GetOpenConn()
        {
            var conn = new SqlConnection(_connStr);

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
