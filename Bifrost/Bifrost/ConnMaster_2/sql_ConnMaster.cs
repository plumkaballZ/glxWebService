using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Bifrost.ConnMaster_2
{
    public class sql_ConnMaster<T> : _baseConnMaster<T>
    {
        public override string ConnString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override _baseConn _conn { get; set; }

   

        public override void ExecuteSP(ConnMaster2Paramz paramz)
        {
            //using (var conn = _conn.GetOpenConn())
            //    conn.Execute(param.SpName, DpsFromParaDic(param.ParamDic), commandType: CommandType.StoredProcedure);
        }

    }
}
