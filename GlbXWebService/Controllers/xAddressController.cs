using GlbXWebService._repo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xAddressController : Controller
    {
        private xAddressRepo _adrRepo = new xAddressRepo();

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string id)
        {
            return Json(_adrRepo.Get(id));
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post([FromBody]GlxUserRequest req)
        {
            var adr = string.IsNullOrEmpty(req.ship_address_attributes.uid) ?
                _adrRepo.Create(req.ship_address_attributes, string.IsNullOrEmpty(req.glxUser.email) ? req.Order.email
                : req.glxUser.email) : _adrRepo.update(req.ship_address_attributes);

            req.Order.ship_address = adr;
            req.Order.bill_address = adr;

            return Json(req.Order);
        }

    }
}
