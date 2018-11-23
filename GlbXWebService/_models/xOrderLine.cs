using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService._models
{
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
}
