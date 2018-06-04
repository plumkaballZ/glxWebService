using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService.Controllers
{
    [Route("api/[controller]")]
    public class xPaymentModeController : Controller
    {
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get()
        {
            PaymentSuper super = new PaymentSuper();
            List<PaymentMode> payment_methods = new List<PaymentMode>();
            //payment_methods.Add(new PaymentMode(1, "Credit Card", "Bogus payment gateway."));
            payment_methods.Add(new PaymentMode(2, "PayPal", "Pay with PayPal"));

            super.payment_methods = payment_methods;

            return Json(super);
        }
    }

    public class PaymentSuper
    {
        public List<PaymentMode> payment_methods = new List<PaymentMode>();
        public List<Payment> attributes = new List<Payment>();
    }

    public class PaymentMode
    {
        public int id;
        public string name;
        public string description;
        public string method_type;
        public PaymentMode(int id, string name, string desc)
        {
            this.id = id;
            this.name = name;
            description = desc;
        }
    }
    public class Payment
    {
        string id;
        string source_type;
        string source_id;
        string display_amount;
        string response_code;
        string state;
        string avs_response;
        string created_at;
        string updated_at;

    }
}
