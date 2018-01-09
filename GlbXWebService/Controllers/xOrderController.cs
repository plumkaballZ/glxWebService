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
            if (email != null)
                return _xOrderRepo.Check(email) ? Json(_xOrderRepo.GetCurrentOrder(email)) : Json(new ReqRes() { nope = true });
            return Json(new ReqRes() { nope = true });
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post([FromBody]GlxUserRequest req)
        {
            var loingUid = _xUserRepo.Login(req.glxUser.email, req.glxUser.password);

            if (loingUid != null)
            {
                var userUid = _xUserRepo.GetSignle(loingUid).uid;

                if (!_xOrderRepo.Check(req.glxUser.email))
                {
                    _xOrderRepo.CreateOrder(userUid);
                    return Json(_xOrderRepo.GetCurrentOrder(req.glxUser.email));
                }

            }

            return Json(new xOrder().InitDummy());
        }

        [EnableCors("AllowAllOrigins")]
        [Route("UpdateOrder")]
        public JsonResult UpdateOrder([FromBody]GlxUserRequest req)
        {
            return Json(new xOrder().InitDummy());
        }
    }


    public class xOrder
    {
        public xOrder InitDummy()
        {
            id = "1";
            number = "R335381310";
            item_total = "0.0";
            total = "20.00";
            ship_total = "0.0";
            state = "cart";
            currency = "eur";

            created_at = DateTime.Now.ToString();

            line_items = new List<xOrderLine>();

            line_items.Add(new xOrderLine().initDummy());
            total_quantity = line_items.Count();

            bill_address = new xAddr().initDummy();
            ship_address = new xAddr().initDummy();

            return this;
        }
        public xOrder()
        {
            line_items = new List<xOrderLine>();
            total_quantity = line_items.Count();

        }
        public string id { get; set; }
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
        public int total_quantity { get; set; }
        public string token { get; set; }

        public List<xOrderLine> line_items;

        public xAddr bill_address { get; set; }
        public xAddr ship_address { get; set; }

    }
    public class xOrderLine
    {
        public xOrderLine initDummy()
        {
            id = 1;
            quantity = 1;
            price = 1;
            single_display_amount = 1;
            total = 1;
            display_amount = 1;
            variant_id = 1;

            image_url = "/assets/api/prods/imgs/prod_10_small.png";
            variant = new Variant();


            return this;
        }
        public int id;
        public int quantity;
        public int price;
        public int single_display_amount;
        public int total;
        public int display_amount;
        public int variant_id;
        public string image_url;

        public Variant variant;

    }

    public class Variant
    {
        public int id;
        public string name;
        public string sku;
        public string price;
        public string weight;
        public string height;
        public string width;
        public string depth;
        public bool is_master;
        public string slug;
        public string description;
        public bool track_inventory;
        public string cost_price;
        public string option_values;
        public int total_on_hand;
        public string display_price;
        public string options_text;
        public bool in_stock;
        public bool is_backorderable;
        public bool is_destroyed;
        public string images;

        public Variant()
        {
            id = 1;
            name = "CardHolderX";
        }
    }


}
