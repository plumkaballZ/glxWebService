using GlbXWebService._repo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xAddressesController : Controller
    {
        private xAddressRepo _adrRepo = new xAddressRepo();

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string email)
        {
            return Json(_adrRepo.GetAll(email));
        }
    }

    public class xAddressAttr
    {
        public string address1;
        public string address2;
        public string city;
        public string country_id;
        public string firstname;
        public string lastname;
        public string phone;
        public string state_id;
        public string zipcode;
        public string email;
        public string uid;
    }

    public class xAddress
    {
        public xAddress()
        {

        }
        public xAddress(xAddressAttr atr)
        {
            address1 = atr.address1;
            address2 = atr.address2;
            city = atr.city;
            zipcode = atr.zipcode.ToString();
            firstname = atr.firstname;
            lastname = atr.lastname;
            phone = atr.phone;
            full_name = "";
        }

        public xAddress initDummy(string firstName)
        {
            id = "1";
            firstname = firstName;
            lastname = "zinrock";
            full_name = firstName;

            address1 = "blommevænget 114";
            address2 = "asdf";

            city = "Odder";
            zipcode = "8300";
            uid = Guid.NewGuid().ToString();

            return this;
        }

        public string uid;
        public string id;
        public string firstname;
        public string lastname;
        public string full_name;
        public string address1;
        public string address2;
        public string city;
        public string zipcode;
        public string phone;
        public string company;
        public string alternative_phone;
        public string country_id;
        public string state_id;
        public string state_name;
        public string state_text;
    }
}
