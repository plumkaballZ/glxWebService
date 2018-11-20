using GlbXWebService._repo;
using GlbXWebService._services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xAddressesController : Controller
    {
        private xAddressService _service = new xAddressService();

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string email)
        {
            return Json(_service.GetAll(email));
        }
    }
}
