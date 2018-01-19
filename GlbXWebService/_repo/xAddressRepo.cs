using Bifrost.ConnMaster;
using GlbXWebService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService._repo
{
    public class xAddressRepo : _baseRepo
    {

        public xAddress Create(xAddressAttr addAttr, string email)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();

            var adrUid = Guid.NewGuid();

            paramDic.Add("@address1", addAttr.address1);
            paramDic.Add("@address2", addAttr.address2);
            paramDic.Add("@city", addAttr.city);
            paramDic.Add("@zipcode", addAttr.zipcode);
            paramDic.Add("@firstName", addAttr.firstname);
            paramDic.Add("@lastName", addAttr.lastname);
            paramDic.Add("@phone", addAttr.phone);
            paramDic.Add("@email", email);
            paramDic.Add("@uid", adrUid);

            Conn.ExecuteSP("xAddress_Create", paramDic);

            var adr = new xAddress(addAttr);
            adr.uid = adrUid.ToString();

            return adr;
        }
        public List<xAddress> GetAll(string email)
        {
            Dictionary<string, object> paramDic = new Dictionary<string, object>();
            paramDic.Add("@email", email);

            return Conn.GetList<xAddress>("xAddress_GetAll", paramDic).ToList();
        }
    }


}
