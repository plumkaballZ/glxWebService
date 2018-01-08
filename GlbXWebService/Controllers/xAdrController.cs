using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xAdrController : Controller
    {
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string id)
        {
            return Json(new xAddr().initDummy());
        }
    }
}
