using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xAddrsController : Controller
    {
        public xAddrsController()
        {


        }
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string email)
        {
            List<xAddr> addrs = new List<xAddr>();
            addrs.Add(new xAddr().initDummy());
            addrs.Add(new xAddr().initDummy());
            addrs.Add(new xAddr().initDummy());
            addrs.Add(new xAddr().initDummy());
            return Json(addrs);
        }
    }

    public class xAddr
    {
        public xAddr()
        {

        }

        public xAddr initDummy()
        {
            id = "1";
            firstname = "erbz";
            lastname = "asdf";
            full_name = "erbz asdf";

            address1 = "blommevænget 114";
            address2 = "asdf";

            return this;
        }

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
