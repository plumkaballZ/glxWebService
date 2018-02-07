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

        public xOrdersController()
        {
            _xOrderRepo = new xOrderRepo();
        }

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string email)
        {
            //List<xOrder> orders = _xOrderRepo.GetAll(email);

            List<xOrder> orders = _xOrderRepo.GetAll(email);
            orders[0].created_at = DateTime.Now.ToString();

            return Json(_xOrderRepo.GetAll(email));;
        }

        [EnableCors("AllowAllOrigins")]
        [Route("GetOrderDetail")]
        public JsonResult GetOrderDetail(string email, string orderNumber)
        {
            if (email != null)
                return Json(_xOrderRepo.Get(email, orderNumber));

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
