using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Bifrost.ConnMaster
{
    public class ConnParamz
    {
        private string _spName;
        public string SpName { get { return _spName; } }

        private Dictionary<string, object> _paramDic;
        public Dictionary<string, object> ParamDic { get { return _paramDic; } }

        public ConnParamz(string spName, Dictionary<string, object> paramDic)
        {
            _spName = spName;
            _paramDic = paramDic;
        }
    }
    public abstract class ConnExecuter<T>
    {
        public abstract T GetSingle(ConnParamz paramz);
    }
    public class Conn_Sql<T> : ConnExecuter<T>
    {
        IConnMaster<DbConnection> sqlConn;

        public override T GetSingle(ConnParamz paramz)
        {
            return sqlConn.GetSingle<T>(paramz);
        }
    }
    public class Conn_MySql<T> : ConnExecuter<T>
    {
        IConnMaster<MySqlConnection> mysqlConn;

        public override T GetSingle(ConnParamz paramz)
        {
            throw new NotImplementedException();
        }
    }
}
