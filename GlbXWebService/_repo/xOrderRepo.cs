using Bifrost.ConnMaster;
using GlbXWebService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;

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


            return Conn.GetSingle<int>(new ConnParamz("xOrder_Check", paramDic)) == 1 ? true : false;
        }
        public bool CheckNoUser(string ip)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@ip", ip);

            return Conn.GetSingle<int>(new ConnParamz("xOrder_CheckNoUser", paramDic)) == 1 ? true : false;
        }

        public Guid CreateOrder(string userUid)
        {
            Guid orderUid = Guid.NewGuid();

            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@userUid", userUid);
            paramDic.Add("@orderUid", orderUid.ToString());

            Conn.ExecuteSP(new ConnParamz("xOrder_Create", paramDic));

            return orderUid;
        }
        public Guid CreateOrderNoUser(string ip)
        {
            Guid orderUid = Guid.NewGuid();

            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@ip", ip);
            paramDic.Add("@orderUid", orderUid.ToString());



            Conn.ExecuteSP(new ConnParamz("xOrder_CreateNoUser", paramDic));

            return orderUid;
        }
        internal xOrder GetCurrentOrderNoUser(string ip)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@ip", ip);

            return Conn.GetSingle<xOrder>(new ConnParamz("xOrder_GetCurrentNoUser", paramDic));
        }

        public xOrder GetCurrentOrder(string email)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@email", email);


            return Conn.GetSingle<xOrder>(new ConnParamz("xOrder_GetCurrent", paramDic));
        }
        public List<xOrder> GetAll(string email)
        {

            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@email", email);
            return Conn.GetList<xOrder>((new ConnParamz("xOrder_GetAll", paramDic))).ToList();
        }
    }
}
