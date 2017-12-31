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
            return Json(new xOrder().InitDummy());
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post()
        {
            return Json(new xOrder().InitDummy());
        }
    }
}
