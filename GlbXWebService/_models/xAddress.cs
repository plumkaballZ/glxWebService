using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService._models
{
    public class xAddress
    {
        public string uid;
        public string id;
        public string firstname;
        public string lastname;
        public string full_name;
        public string address1;
        public string address2;
        public string city;
        public string zipcode;
        public string phone;
        public string company;
        public string alternative_phone;
        public string countryId;
        public string stateId;
        public string state_name;
        public string state_text;

        public xAddress()
        {

        }
        public xAddress(xAddressAttributes atr)
        {
            address1 = atr.address1;
            address2 = atr.address2;
            city = atr.city;
            zipcode = atr.zipcode.ToString();
            firstname = atr.firstname;
            lastname = atr.lastname;
            phone = atr.phone;
            full_name = "";
            stateId = atr.state_id;
            countryId = atr.country_id;
        }

        public xAddress initDummy(string firstName)
        {
            id = "1";
            firstname = firstName;
            lastname = "zinrock";
            full_name = firstName;

            address1 = "blommevænget 114";
            address2 = "asdf";

            city = "Odder";
            zipcode = "8300";
            uid = Guid.NewGuid().ToString();

            return this;
        }

    
    }
}
