using GlbXWebService._models;
using GlbXWebService._repo;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
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
        private IHttpContextAccessor _accessor;

        public xOrderController(IHttpContextAccessor accessor)
        {
            _xOrderRepo = new xOrderRepo();
            _xUserRepo = new xUserRepo();
            _accessor = accessor;
        }

        [HttpGet]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Get(string email)
        {
            Guid bla = new Guid();

            if (Guid.TryParse(email, out bla))
            {
                var ip = email;
                if (_xOrderRepo.CheckNoUser(ip)) return Json(_xOrderRepo.GetCurrentOrderNoUser(ip));
            }
            else
            {
                if (_xOrderRepo.Check(email)) return Json(_xOrderRepo.GetCurrentOrder(email));
            }

            return Json(new ReqRes() { nope = true });
        }

        [HttpPost]
        [EnableCors("AllowAllOrigins")]
        public JsonResult Post([FromBody]GlxUserRequest req)
        {
            var loingUid = _xUserRepo.Login(req.glxUser.email, req.glxUser.password);
            var ip = req.glxUser.ip;

            if (loingUid == null)
            {
                if (!_xOrderRepo.CheckNoUser(ip))
                {
                    _xOrderRepo.CreateOrderNoUser(ip);
                    return Json(_xOrderRepo.GetCurrentOrderNoUser(ip));
                }
            } 
            else
            {
                var userUid = _xUserRepo.GetSignle(loingUid).uid;

                if (!_xOrderRepo.Check(req.glxUser.email))
                {
                    if (_xOrderRepo.Check_ip(ip))
                    {
                        _xOrderRepo.updateOrder_ip(userUid, ip);
                    }
                    else
                    {
                        _xOrderRepo.CreateOrder(userUid, ip);
                    }

                    return Json(_xOrderRepo.GetCurrentOrder(req.glxUser.email));
                }                  
            }

            return Json(new xOrder().InitDummy());
        }

        [EnableCors("AllowAllOrigins")]
        [Route("UpdateOrder")]
        public JsonResult UpdateOrder([FromBody]GlxUserRequest req)
        {
            if (req.Order != null)
            {
                if (req.Order.special_instructions == "updatePayment")
                    _xOrderRepo.SetPaymentDone(req.Order.id, req.Order.ship_address.uid, req.Order.ship_total);

                if (req.Order.special_instructions == "updateShipment")
                    _xOrderRepo.SetShipmentSent(req.Order.id, req.Order.ship_address.uid);

                if (req.Order.special_instructions == "addLineItem")
                {
                    foreach (var orderLine in req.Order.line_items)
                        _xOrderRepo.CreateOrderLine(req.Order.id, orderLine);
                }
                if (req.Order.special_instructions == "deleteLineItem")
                {
                    foreach (var orderLine in req.Order.line_items)
                    {
                        if (orderLine.delStr == "true")
                        {
                            _xOrderRepo.DeleteOrderLine(req.Order.id, orderLine);
                        }
                    }
                }
            }

            return Json(req.Order);
        }
    }


    public class xOrder
    {
        public xOrder InitDummy()
        {
            //R335381310
            number = "R335381310";

            shipment_state = 1.ToString();
            payment_state = 1.ToString();



            line_items = new List<xOrderLine>();
            total_quantity = line_items.Count();

            bill_address = new xAddress().initDummy("asdf");
            ship_address = new xAddress().initDummy("asdf");

            return this;
        }
        public xOrder()
        {
            line_items = new List<xOrderLine>();
            total_quantity = line_items.Count();
            bill_address = new xAddress();
            ship_address = new xAddress();

        }
        public string addressUid { get; set; }
        public string id { get; set; }
        public string number { get; set; }
        public string item_total {

            get
            {
                int item_total = 0;

                foreach (var lineItem in line_items)
                    item_total += lineItem.quantity;

                return item_total.ToString();
            }
        }
        public string total
        {
            get
            {
                int total = 0;

                foreach (var lineItem in line_items)
                    total += (lineItem.price * lineItem.quantity);


                return total.ToString();
            }

        }
        public int ship_total { get; set; }
        public string state { get; set; }
        public string adjustment_total { get; set; }
        public string user_id { get; set; }
        public DateTime created_at { get; set; }
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

        public xAddress bill_address { get; set; }
        public xAddress ship_address { get; set; }
        public void addLineItem() { }

    }
    public class xOrderLine
    {
        public xOrderLine initDummy()
        {
            id = 1;
            quantity = 1;
            price = 300;
            single_display_amount = 300;
            display_amount = 299;
            variant_id = 777;

            image_url = "/assets/api/prods/imgs/prod_10_small.png";
            variant = new Variant();


            return this;
        }

        public int id;
        public int quantity;
        public int price;
        public int single_display_amount;
        public int total { get { return price * quantity; } }
        public int display_amount;
        public int variant_id;
        public string image_url;
        public string delStr;

        public string color;
        public string size;

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
