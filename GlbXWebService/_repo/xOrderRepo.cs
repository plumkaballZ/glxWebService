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
        public bool CheckNoUser(string ip)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@ip", ip);
            return Conn.GetSingle<int>("xOrder_CheckNoUser", paramDic) == 1 ? true : false;
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
        public Guid CreateOrderNoUser(string ip)
        {
            Guid orderUid = Guid.NewGuid();

            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@ip", ip);
            paramDic.Add("@orderUid", orderUid.ToString());

            Conn.ExecuteSP("xOrder_CreateNoUser", paramDic);

            return orderUid;
        }
        internal xOrder GetCurrentOrderNoUser(string ip)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@ip", ip);

            return Conn.GetSingle<xOrder>("xOrder_GetCurrentNoUser", paramDic);
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
