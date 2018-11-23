using GlbXWebService._logics;
using GlbXWebService._models;
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
        public async Task<string> Get(string token, string expires_at)
        {
            var str = "empy";

            if (token == "n")
                str = await _apiClinet.GetLogin();

            return str;
        }

        [EnableCors("AllowAllOrigins")]
        [Route("GetFreightRates")]
        public async Task<string> GetFreightRates(string token, string country)
        {
            var str = "empty";
            str = await _apiClinet.GetFreightRatesByCountry(country);
            return str;
        }

    }
}
