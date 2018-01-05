using Bifrost.ConnMaster;
using GlbXWebService.Controllers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService._repo
{
    public class xOrderRepo : _baseRepo
    {
        public xOrderRepo()
        {
        }
        public bool Check(string email)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@email", email);
            return Conn.GetSingle<int>("xOrder_Check", paramDic) == 1 ? true : false;
        }
        public Guid CreateOrder(string userUid)
        {
            Guid orderUid = Guid.NewGuid();

            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@userUid", userUid);
            paramDic.Add("@orderUid", orderUid.ToString());

            Conn.ExecuteSP("xOrder_Create", paramDic);

            return orderUid;
        }
        public xOrder GetCurrentOrder(string email)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@email", email);

            return Conn.GetSingle<xOrder>("xOrder_GetCurrent", paramDic);
        }
        public List<xOrder> GetOrders()
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            return Conn.GetList<xOrder>("", paramDic).ToList();
        }
    }
}
