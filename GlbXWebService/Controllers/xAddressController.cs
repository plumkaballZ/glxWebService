using GlbXWebService._repo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xAddressController : Controller
    {
        private xAddressRepo _adrRepo = new xAddressRepo();

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string id)
        {
            return Json(new xAddress().initDummy("asdf"));
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post([FromBody]GlxUserRequest req)
        {
            var adr = _adrRepo.Create(req.ship_address_attributes, string.IsNullOrEmpty(req.glxUser.email) ? req.Order.email : req.glxUser.email);

            req.Order.ship_address = adr;
            req.Order.bill_address = adr;

            return Json(req.Order);
        }

    }
}
