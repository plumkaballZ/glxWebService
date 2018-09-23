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
        private PakkelabelsApiClient _apiClinet;

        public xPakkelabelsController()
        {
            _apiClinet = new PakkelabelsApiClient();
        }


        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public async Task<string> Get()
        {
            var str = await _apiClinet.GetLogin();
            var st2 = await _apiClinet.GetGlsDropPoints();

            return str;
        }

        //[HttpGet]
        //[EnableCors("AllowAllOrigins")]
        //public string Get()
        //{
        //    _apiClinet.test();
        //    return "service_running_x4";
        //}



    }
}
