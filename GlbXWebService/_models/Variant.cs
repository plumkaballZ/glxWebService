using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService._models
{
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
