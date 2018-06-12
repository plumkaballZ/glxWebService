
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
        public bool Check_ip(string ip)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@ip", ip);

            return Conn.GetSingle<int>(new ConnParamz("xOrder_Check_Ip", paramDic)) == 1 ? true : false;
        }

        public bool updateOrder_ip(string userUid, string ip)
        {
   
            Dictionary<string, object> paramDic = new Dictionary<string, object>();  

            paramDic.Add("@userUid", userUid);
            paramDic.Add("@ip", ip);

            Conn.ExecuteSP(new ConnParamz("xOrder_Update_Ip", paramDic));

            return true;
        }
        public Guid CreateOrder(string userUid, string ip)
        {
            Guid orderUid = Guid.NewGuid();

            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@userUid", userUid);
            paramDic.Add("@orderUid", orderUid.ToString());
            paramDic.Add("@ip", ip);

            Conn.ExecuteSP(new ConnParamz("xOrder_Create", paramDic));

            return orderUid;
        }

        public Guid CreateOrderLine(string orderId, xOrderLine line)
        {
            Guid orderLineUid = Guid.NewGuid();

            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@orderId", orderId);
            paramDic.Add("@orderLineUid", orderLineUid.ToString());

            paramDic.Add("@prodUid", line.variant_id);
            paramDic.Add("@price", line.display_amount);
            paramDic.Add("@quant", line.quantity);


            Conn.ExecuteSP(new ConnParamz("xOrderLine_Create", paramDic));

            return orderLineUid;
        }

        public bool DeleteOrderLine(string orderId, xOrderLine line)
        {
            Guid orderLineUid = Guid.NewGuid();

            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@orderId", orderId);
            paramDic.Add("@prodUid", line.id);

            Conn.ExecuteSP(new ConnParamz("xOrderLine_Delete", paramDic));

            return true;
        }
        public bool SetPaymentDone(string orderId, string addressUid)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@orderId", orderId);
            paramDic.Add("@addressUid", addressUid);

            Conn.ExecuteSP(new ConnParamz("xOrder_SetPaymentDone", paramDic));

            return true;
        }
        public bool SetShipmentSent(string orderId, string addressUid)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            paramDic.Add("@orderId", orderId);
            paramDic.Add("@addressUid", addressUid);

            Conn.ExecuteSP(new ConnParamz("xOrder_SetShipmentSent", paramDic));

            return true;
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

            var currOrder = Conn.GetSingle<xOrder>(new ConnParamz("xOrder_GetCurrentNoUser", paramDic));

            if (currOrder.id != null)
            {
                Dictionary<string, object> paramDic2 = new Dictionary<string, object>();
                paramDic2.Add("@email", currOrder.email);
                paramDic2.Add("@orderId", currOrder.id);
                currOrder.line_items = Conn.GetList<xOrderLine>((new ConnParamz("xOrder_GetLine", paramDic2))).ToList();
            }

            

            return currOrder;
        }

        public xOrder GetCurrentOrder(string email)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@email", email);

            var currOrder = Conn.GetSingle<xOrder>(new ConnParamz("xOrder_GetCurrent", paramDic));

            if (currOrder.id != null)
            {
                Dictionary<string, object> paramDic2 = new Dictionary<string, object>();
                paramDic2.Add("@email", email);
                paramDic2.Add("@orderId", currOrder.id);
                currOrder.line_items = Conn.GetList<xOrderLine>((new ConnParamz("xOrder_GetLine", paramDic2))).ToList();
            }

         

            return currOrder;
        }
        public List<xOrder> GetAll(string email)
        {

            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@email", email);
            return Conn.GetList<xOrder>((new ConnParamz("xOrder_GetAll", paramDic))).ToList();
        }
        public List<xOrder> GetAll_lvl99()
        {
            List<xOrder> orderz = Conn.GetList<xOrder>((new ConnParamz("xOrder_GetAll_lvl99", new Dictionary<string, object>()))).ToList();

            foreach (xOrder order in orderz)
            {
                Dictionary<string, object> paramDic = new Dictionary<string, object>();
                paramDic.Add("@email", order.email);
                paramDic.Add("@orderId", order.id);
                order.line_items = Conn.GetList<xOrderLine>((new ConnParamz("xOrder_GetLine", paramDic))).ToList();
            }

            return orderz;

        }
        public xOrder Get(string email, string orderId)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@email", email);
            paramDic.Add("@orderId", orderId);

            xOrder order = Conn.GetSingle<xOrder>((new ConnParamz("xOrder_Get", paramDic)));

            if (order != null)
                order.line_items = Conn.GetList<xOrderLine>((new ConnParamz("xOrder_GetLine", paramDic))).ToList();

            return order;
        }
 
    }
}
