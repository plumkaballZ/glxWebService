using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace Bifrost.ConnMaster
{
    public class ConnMaster_Sql : init_ConnMaster, IConnMaster<DbConnection>
    {
        public ConnMaster_Sql(string dataSoruce, string db, string user, string pw, string initialCatalog, int timeout = 1440) : base(dataSoruce, db, user, pw, initialCatalog, timeout)
        {
            var DbConnectionStringBuilder = new DbConnectionStringBuilder();

            DbConnectionStringBuilder builder = new DbConnectionStringBuilder();

            builder["Data Source"] = dataSoruce;
            builder["Database"] = db;
            builder["User ID"] = user;
            builder["Password"] = pw;
            builder["Initial Catalog"] = initialCatalog;
            builder["Timeout"] = timeout;

            ConnStr = builder.ConnectionString;
        }
        public string ConnStr { get; set; }
        public DbConnection GetOpenConn()
        {
            var conn = new SqlConnection(ConnStr);

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
