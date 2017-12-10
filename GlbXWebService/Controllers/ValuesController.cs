using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return "TheGlobalX_WebService_Running";
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post([FromBody]GlxUserRequest req)
        {
            xUser _xUser = new xUser(req.glxUser.email);
            return Json(_xUser);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
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
