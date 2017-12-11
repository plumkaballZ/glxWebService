using Microsoft.AspNetCore.Cors;
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
        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get()
        {
            List<xOrder> orders = new List<xOrder>();
            orders.Add(new xOrder().InitDummy());
            return Json(orders);
        }
    }
    public class xOrder
    {
        public xOrder InitDummy()
        {
            id = 1;
            number = "1";
            item_total = "1";
            total = "1";
            ship_total = "1";

            return this;
        }
        public int id { get; set; }
        public string number { get; set; }
        public string item_total { get; set; }
        public string total { get; set; }
        public string ship_total { get; set; }
        public string state { get; set; }
        public string adjustment_total { get; set; }
        public string user_id { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string completed_at { get; set; }
        public string payment_total { get; set; }
        public string shipment_state { get; set; }
        public string payment_state { get; set; }
        public string email { get; set; }
        public string special_instructions { get; set; }
        public string channel { get; set; }
        public string included_tax_total { get; set; }
        public string additional_tax_total { get; set; }
        public string display_included_tax_total { get; set; }
        public string display_additional_tax_total { get; set; }
        public string tax_total { get; set; }
        public string currency { get; set; }
        public string considered_risky { get; set; }
        public string canceler_id { get; set; }
        public string total_quantity { get; set; }
        public string token { get; set; }
    }

}
