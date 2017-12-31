using Bifrost.ConnMaster;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService._repo
{
    public class _baseRepo
    {
        private IConnMaster<MySqlConnection> _conn;
        public IConnMaster<MySqlConnection> Conn
        {
            get { return _conn; }
        }
        public _baseRepo()
        {
            _conn = new ConnMaster_MySql("62.75.168.220", "Globase", "superErbz", "Jqi5fqfb");
        }
    }
}
