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
            paramDic.Add("@_email", email);

            var num = Conn.GetSingle<int>("xOrder_Check", paramDic);

            return true;
        }
        public Guid CreateOrder(string email)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@_email", email);

            Conn.ExecuteSP("xOrder_Create", paramDic);

            return Guid.Empty;
        }
        public xOrder GetCurrentOrder()
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            return Conn.GetSingle<xOrder>("", paramDic);
        }
        public List<xOrder> GetOrders()
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            return Conn.GetList<xOrder>("", paramDic).ToList();
        }
    }
}
