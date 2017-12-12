using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService._repo
{
    public class _baseRepo
    {
        public DBConnection _dbCon;
        public _baseRepo()
        {
            _dbCon = DBConnection.Instance();
            _dbCon.DatabaseName = "Globase";
        }
        public Guid CreateNewEntity()
        {
            Guid entityUid = Guid.NewGuid();

            if (_dbCon.IsConnect())
            {
                string query = "insert into _entity(_createDate, _uid, _systemUid) VALUES(NOW(), '" + entityUid.ToString() + "', '7107fa34-ee4b-4018-9f91-f3c1c0012600')";

                var cmd = new MySqlCommand(query, _dbCon.Connection);
                cmd.ExecuteReader();

                return entityUid;
            }

            return new Guid();
        }
    }
}
