using GlbXWebService._logics;
using GlbXWebService._models;
using GlbXWebService._repo;
using GlbXWebService._services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xOrderController : Controller
    {


        private xOrderService _xOrderService = new xOrderService();

        private xOrderRepo _xOrderRepo;
        private xUserRepo _xUserRepo;


        public xOrderController()
        {
            _xOrderRepo = new xOrderRepo();
            _xUserRepo = new xUserRepo();
        }

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string email)
        {
            Guid bla = new Guid();

            if (Guid.TryParse(email, out bla))
            {
                var ip = email;
                if (_xOrderRepo.CheckNoUser(ip)) return Json(_xOrderRepo.GetCurrentOrderNoUser(ip));
            }
            else
            {
                if (_xOrderRepo.Check(email)) return Json(_xOrderRepo.GetCurrentOrder(email));
            }

            return Json(new ReqRes() { nope = true });
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post([FromBody]GlxUserRequest req)
        {
            var loingUid = _xUserRepo.Login(req.glxUser.email, req.glxUser.password);
            var ip = req.glxUser.ip;

            if (loingUid == null)
            {
                if (!_xOrderRepo.CheckNoUser(ip))
                {
                    _xOrderRepo.CreateOrderNoUser(ip);
                    return Json(_xOrderRepo.GetCurrentOrderNoUser(ip));
                }
            }
            else
            {
                var userUid = _xUserRepo.GetSignle(loingUid).uid;

                if (!_xOrderRepo.Check(req.glxUser.email))
                {
                    if (_xOrderRepo.Check_ip(ip))
                    {
                        _xOrderRepo.updateOrder_ip(userUid, ip);
                    }
                    else
                    {
                        _xOrderRepo.CreateOrder(userUid, ip);
                    }

                    return Json(_xOrderRepo.GetCurrentOrder(req.glxUser.email));
                }
            }

            return Json(new xOrder().InitDummy());
        }

        [EnableCors("AllowAllOrigins")]
        [Route("UpdateOrder")]
        public JsonResult UpdateOrder([FromBody]GlxUserRequest req)
        {
            var res = _xOrderService.HandleUpdateOrder(req);
            return Json(req.Order);
        }
    }

}
