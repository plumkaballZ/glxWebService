using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService._models
{
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
        public string item_total
        {

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

        public string deliveryCode;
        public string shippingId;
    }
}
