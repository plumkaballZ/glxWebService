using GlbXWebService._models;
using GlbXWebService._repo;
using GlbXWebService.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService._services
{
    public class xAddressService
    {
        private xAddressRepo _repo = new xAddressRepo();

        public xAddress Get(string uid)
        {
            var get = _repo.Get(uid);
            return get;
        }
        public List<xAddress> GetAll(string email)
        {
            var all = _repo.GetAll(email);
            return all;
        }
        public xAddress Update(xAddressAttributes addAttr)
        {
            return _repo.Update(addAttr);
        }
        public xAddress Create(xAddressAttributes addAttr, string email)
        {
            return _repo.Create(addAttr, email);
        }
        public string GetEmailFromRequest(GlxUserRequest req)
        {
           return string.IsNullOrEmpty(req.glxUser.email) ? req.Order.email : req.glxUser.email;
        }
        public bool CanCreateNewAddress(string uid)
        {
            if (string.IsNullOrEmpty(uid))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
