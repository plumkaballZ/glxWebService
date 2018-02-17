using Bifrost.ConnMaster;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data.Common;

namespace Bifrost 
{
    public class Class1
    {
        public Class1()
        {
            IConnMaster<MySqlConnection> mysqlConn = new ConnMaster_MySql("62.75.168.220", "Globase", "superErbz", "Jqi5fqfb");

            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@email", "asdf");
            paramDic.Add("@_password", "asdf");
            paramDic.Add("@mobile", "asdf");
            paramDic.Add("@uid", "asdf");

            mysqlConn.ExecuteSP(new ConnParamz("xUserLogin_Create", paramDic));

            IConnMaster<DbConnection> sqlConn = new ConnMaster_Sql("93.239.99.31,1433", "SolveITMasterBase", "NGG", "TheWorldIs!Enough2013", "SolveITMasterBase");
            sqlConn.ExecuteSP(new ConnParamz("asdf", paramDic));

        }
    }
}
