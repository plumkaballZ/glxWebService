using Flurl.Http;
using GlbXWebService._logics;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xPakkelabelsController : Controller
    {
        private PakkeLabelsApiClient _apiClinet;

        public xPakkelabelsController()
        {
            _apiClinet = new PakkeLabelsApiClient();
        }

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public string Get()
        {

            _apiClinet.test();

            return "service_running_x4";
        }

    }
}
