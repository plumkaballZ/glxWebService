using System;
using GlbXWebService._models;
using GlbXWebService._repo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xUserController : Controller
    {
        private xUserRepo _xUserRepo;
        private IHttpContextAccessor _accessor;

        public xUserController(IHttpContextAccessor accessor)
        {
            _xUserRepo = new xUserRepo();
            _accessor = accessor;
        }

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string email, string password)
        {
            if (_xUserRepo.CheckLogin(email))
            {
                var refUid = _xUserRepo.Login(email, password);
                return refUid == null ? Json(new ReqRes() { error = true, msg = "wrong password" }) : Json(_xUserRepo.GetSignle(refUid));
            }

            return Json(new ReqRes() { error = true, msg = "cannot find you :(" });
        }
        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post([FromBody]GlxUserRequest req)
        {
            if (!_xUserRepo.CheckLogin(req.glxUser.email))
            {
                req.glxUser.ip = req.glxUser.ip;
                var loginUid = _xUserRepo.CreateLogin(req.glxUser);
                _xUserRepo.Create(loginUid);

                return Json(new xUser(req.glxUser));
            }

            return Json(new ReqRes() { error = true, msg = "user already exsists" });
        }
        [EnableCors("AllowAllOrigins")]
        [Route("UpdateUser")]
        public JsonResult UpdateUser([FromBody]GlxUserRequest req)
        {
            return Json(_xUserRepo.Update(req.xUser));
        }
    }
    public class GlxUserRequest
    {
        public GlxUser glxUser { get; set; }
        public xOrder Order { get; set; }
        public xUser xUser { get; set; }
        public xAddressAttributes bill_address_attributes { get; set; }
        public xAddressAttributes ship_address_attributes { get; set; }
        public string jsonStr { get; set; }
    }

    public class GlxUser
    {
        public string mobile { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string password_confirmation { get; set; }
        public string ip { get; set; }
    }
    public class xUser
    {
        public xUser(GlxUser glxUser)
        {
            email = glxUser.email;
            mobile = glxUser.mobile;
        }
        public xUser()
        {
        }
        public string uid { get; set; }
        public string id { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string bill_address_id { get; set; }
        public string ship_address_id { get; set; }
        public int lvl { get; set; }
    }
    class ReqRes
    {
        public bool error;
        public bool nope;
        public string msg;
    }
}
