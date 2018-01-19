using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xOrdersController : Controller
    {
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string email)
        {
            List<xOrder> orders = new List<xOrder>();
            return Json(orders);
        }

        [EnableCors("AllowAllOrigins")]
        [Route("GetOrderDetail")]
        public JsonResult GetOrderDetail(string email, string orderNumber)
        {
            if (email != null)
                return Json(new xOrder().InitDummy());

            return Json(new ReqRes() { nope = true });
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post()
        {
            return Json(new xOrder().InitDummy());
        }
    }
}
