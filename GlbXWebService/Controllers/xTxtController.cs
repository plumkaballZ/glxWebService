using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xTxtController : Controller
    {

        private IHostingEnvironment _env;
        public xTxtController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get()
        {
            var txt = System.IO.File.ReadAllLines(_env.ContentRootPath + "\\txt\\prodDetail.json");
            return new JsonResult(txt);
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post()
        {
            return Json("asdf");
        }
    }
}
