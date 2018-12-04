using Dapper;
using GlbXWebService.ConnMaster.help;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService.ConnMaster.ext
{
    public static class call_ConnectionMaster
    {
        public static void ExecuteSP(this IConnectionMaster<MySqlConnection> connMaster, ConnectionMasterParameters param)
        {
            using (var conn = connMaster.GetOpenConn())
                conn.Execute(param.SpName, DpsFromParaDic(param.ParamDic), commandType: CommandType.StoredProcedure);

        }
        public static void ExecuteSP(this IConnectionMaster<DbConnection> connMaster, ConnectionMasterParameters param)
        {
            using (var conn = connMaster.GetOpenConn())
                conn.Execute(param.SpName, DpsFromParaDic(param.ParamDic), commandType: CommandType.StoredProcedure);

        }

        public static T GetSingle<T>(this IConnectionMaster<MySqlConnection> connMaster, ConnectionMasterParameters param)
        {
            T item;

            using (var con = connMaster.GetOpenConn())
            {
                item = con.Query<T>(param.SpName, DpsFromParaDic(param.ParamDic) as object, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return item;
            }
        }
        public static T GetSingle<T>(this IConnectionMaster<DbConnection> connMaster, ConnectionMasterParameters param)
        {
            T item;

            using (var con = connMaster.GetOpenConn())
            {
                item = con.Query<T>(param.SpName, DpsFromParaDic(param.ParamDic) as object, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return item;
            }
        }

        public static IEnumerable<T> GetList<T>(this IConnectionMaster<MySqlConnection> connMaster, ConnectionMasterParameters param)
        {
            IEnumerable<T> items;

            using (var con = connMaster.GetOpenConn())
            {
                items = con.Query<T>(param.SpName, DpsFromParaDic(param.ParamDic), commandType: CommandType.StoredProcedure);
                return items;
            }
        }
        public static IEnumerable<T> GetList<T>(this IConnectionMaster<DbConnection> connMaster, ConnectionMasterParameters param)
        {
            IEnumerable<T> items;

            using (var con = connMaster.GetOpenConn())
            {
                items = con.Query<T>(param.SpName, DpsFromParaDic(param.ParamDic), commandType: CommandType.StoredProcedure);
                return items;
            }
        }

        //utils
        private static DynamicParameters DpsFromParaDic(Dictionary<string, object> paramDic)
        {
            DynamicParameters dps = new DynamicParameters();

            if (paramDic != null)
                foreach (var para in paramDic)
                    dps.Add(para.Key[0] == '@' ? para.Key : "læs" +
                        "@" + para.Key, para.Value);

            return dps;
        }
    }
}
