using GlbXWebService._repo;
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
            //if (_xOrderRepo.Check(email))
            //    _xOrderRepo.CreateOrder(email);

            return Json(new xOrder().InitDummy());
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post([FromBody]GlxUserRequest req)
        {
            _xOrderRepo.CreateOrder(req.glxUser.email);
            //if (_xOrderRepo.Check(email))
               

            return Json(new xOrder().InitDummy());
        }
    }

    public class xOrder
    {
        public xOrder InitDummy()
        {
            id = 1;
            number = "R335381310";
            item_total = "0.0";
            total = "0.0";
            ship_total = "0.0";
            state = "cart";
            line_items = new List<xOrderLine>();

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

        public List<xOrderLine> line_items;
    }
    public class xOrderLine
    {
        public int id;
        public int quantity;
        public int price;
        public int single_display_amount;
        public int total;
        public int display_amount;
        public int variant_id;
    }

}
