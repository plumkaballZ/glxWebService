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
    public class xOrdersController : Controller
    {
        private xOrderRepo _xOrderRepo;
        private xAddressRepo _xAddrRepo;

        public xOrdersController()
        {
            _xOrderRepo = new xOrderRepo();
            _xAddrRepo = new xAddressRepo();
        }

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string email, string ip)
        {   
            return Json(_xOrderRepo.GetAll(email, ip));;
        }

        [EnableCors("AllowAllOrigins")]
        [Route("GetOrderDetail")]
        public JsonResult GetOrderDetail(string email, string orderNumber)
        {
            if (email != null)
            {
                xOrder order = _xOrderRepo.Get(email, orderNumber);
                order.ship_address = _xAddrRepo.Get(order.addressUid);
                return Json(order);
            }

            return Json(new ReqRes() { nope = true });
        }

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        [Route("GetOrdersLvl99")]
        public JsonResult GetOrdersLvl99(string email)
        {
            return Json(_xOrderRepo.GetAll_lvl99()); 
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post()
        {
            return Json(new xOrder().InitDummy());
        }
    }
}
