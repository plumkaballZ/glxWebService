using GlbXWebService._models;
using GlbXWebService._repo;
using GlbXWebService._services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xAddressController : Controller
    {
        private xAddressService _service = new xAddressService();

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string id)
        {
            return Json(_service.Get(id));
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post([FromBody]GlxUserRequest req)
        {
            //var adr = string.IsNullOrEmpty(req.ship_address_attributes.uid) ? _service.Create(req.ship_address_attributes, string.IsNullOrEmpty(req.glxUser.email) ? req.Order.email : req.glxUser.email) : _service.Update(req.ship_address_attributes);

            var res = new xAddress();

            if (_service.CanCreateNewAddress(req.ship_address_attributes.uid))
            {
                var email = _service.GetEmailFromRequest(req);
                res = _service.Create(req.ship_address_attributes, email);
            }
            else
                res = _service.Update(req.ship_address_attributes);

            req.Order.ship_address = res;
            req.Order.bill_address = res;

            return Json(req.Order);
        }

        [EnableCors("AllowAllOrigins")]
        [Route("Delete")]
        public JsonResult Delete([FromBody]GlxUserRequest req)
        {
            var res = _service.Delete(req.ship_address_attributes.uid);
            return Json(req.Order);
        }

    }
}
