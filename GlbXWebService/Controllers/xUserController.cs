using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xUserController : Controller
    {
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get()
        {
            List<xUser> xUsers = new List<xUser>();
            return Json(xUsers);
        }
        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post([FromBody]GlxUserRequest req)
        {
            xUser _xUser = new xUser(req.glxUser.email);
            return Json(_xUser);
        }
    }
    public class GlxUserRequest
    {
        public GlxUser glxUser { get; set; }
    }

    public class GlxUser
    {
        public string email { get; set; }
        public string password { get; set; }
        public string password_confirmation { get; set; }
    }
    public class xUser
    {
        public xUser(string email)
        {
            id = "Erbz";
            this.email = email;
            created_at = DateTime.Now.ToString();
            updated_at = "-";
            bill_address_id = "1";
            ship_address_id = "2";
        }
        public string id { get; set; }
        public string email { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string bill_address_id { get; set; }
        public string ship_address_id { get; set; }
    }
}
