﻿using GlbXWebService._repo;
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
        private xUserRepo _xUserRepo;

        public xUserController()
        {
            _xUserRepo = new xUserRepo();
        }

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string email, string password)
        {
            if (_xUserRepo.CheckLogin(email))
            {
                var refUid = _xUserRepo.Login(email, password);
                return refUid == null ? Json(new ReqRes() { error = true, msg ="wrong password" }) : Json(_xUserRepo.GetSignle(refUid));
            }

            return Json(new ReqRes() { error = true, msg = "cannot find you :(" });
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post([FromBody]GlxUserRequest req)
        {
            if (!_xUserRepo.CheckLogin(req.glxUser.email))
            {
                var loginUid = _xUserRepo.CreateLogin(req.glxUser);
                _xUserRepo.Create(loginUid);

                return Json(new xUser(req.glxUser));
            }

            return Json(new ReqRes() { error = true, msg = "user already exsists" });
        }
    }
    public class GlxUserRequest
    {
        public GlxUser glxUser { get; set; }
    }

    public class GlxUser
    {
        public string mobile { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string password_confirmation { get; set; }
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

        public string id { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string bill_address_id { get; set; }
        public string ship_address_id { get; set; }
    }
    class ReqRes
    {
        public bool error;
        public string msg;
    }
}