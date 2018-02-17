
using GlbXWebService.ConnMaster.ext;
using GlbXWebService.ConnMaster.help;
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
        public Guid CreateOrderLine(string orderId)
        {
            Guid orderLineUid = Guid.NewGuid();

            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@orderId", orderId);
            paramDic.Add("@orderLineUid", orderLineUid.ToString());

            Conn.ExecuteSP(new ConnParamz("xOrderLine_Create", paramDic));

            return orderLineUid;
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
        public xOrder Get(string email, string orderId)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@email", email);
            paramDic.Add("@orderId", orderId);

            xOrder order = Conn.GetSingle<xOrder>((new ConnParamz("xOrder_Get", paramDic)));

            if (order != null)
                order.line_items.Add(Conn.GetSingle<xOrderLine>(new ConnParamz("xOrder_GetLine", paramDic)));

            return order;
        }
 
    }
}
