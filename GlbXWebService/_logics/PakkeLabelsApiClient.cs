using Flurl.Http;
using GlbXWebService._models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GlbXWebService._logics
{
    public class PakkelabelsToken
    {
        public string token;
        public string expires_at;

        public string Token { get { return token; } }
        public string ExpiresAt { get { return expires_at; } }
    }

    public class PakkelabelsApiClient
    {
        private PakkelabelsToken _token;

        private string _urlV1 = "https://app.pakkelabels.dk/api/public/v1/";
        private string _urlV2 = "https://app.pakkelabels.dk/api/public/v2/";

        public async Task<string> GetLogin()
        {
            var responseString = await "https://app.pakkelabels.dk/api/public/v2/users/login"
                .PostUrlEncodedAsync(new { api_user = "0930aeb1-1412-4260-9f19-63fb1d010720", api_key = "1031bb73-6770-46eb-9960-6b1ab31d322e" })
                .ReceiveString();

            _token = JsonConvert.DeserializeObject<PakkelabelsToken>(responseString);

            return responseString;
        }


        public async Task<string> CreateImportedShipment(xAddress addr, string receiverEmail, string orderId, string deliveryCode, string shippingId)
        {
            //get token :)
            var responseString = await "https://app.pakkelabels.dk/api/public/v2/users/login"
            .PostUrlEncodedAsync(new { api_user = "0930aeb1-1412-4260-9f19-63fb1d010720", api_key = "1031bb73-6770-46eb-9960-6b1ab31d322e" })
            .ReceiveString();

            _token = JsonConvert.DeserializeObject<PakkelabelsToken>(responseString);

            return await PostRequest("https://app.pakkelabels.dk/api/public/v2/shipments/imported_shipment", new
            {
                token = _token.token,
                order_id = orderId,
                shipping_agent = deliveryCode,
                shipping_product_id = shippingId,
                weight = "1000",

                receiver_name = addr.firstname,
                receiver_address1 = addr.address1,
                receiver_zipcode = addr.zipcode,
                receiver_city = addr.city,
                receiver_country = addr.countryId,
                receiver_mobile = addr.phone,
                receiver_email = receiverEmail,

                sender_email = "Anthony301293@gmail.com",
                sender_name = "Anthony Shevlin",
                sender_address1 = "Favrgaardsvej 77",
                sender_zipcode = "8300",
                sender_country = "DK",
                sender_city = "Odder",
                services = "11, 12"
            });
        }
        public async Task<string> GetGlsDropPoints()
        {
            return await GetRequest("https://app.pakkelabels.dk/api/public/v2/shipments/gls_droppoints",
                new
                {
                    token = _token.Token,
                    zipcode = "8300",
                    street = "Blommevænget",
                    number = "114"
                });
        }
        public async Task<string> GetFreightRatesByCountry(string country)
        {
            var responseString = await "https://app.pakkelabels.dk/api/public/v2/users/login"
                .PostUrlEncodedAsync(new { api_user = "0930aeb1-1412-4260-9f19-63fb1d010720", api_key = "1031bb73-6770-46eb-9960-6b1ab31d322e" })
                .ReceiveString();

            _token = JsonConvert.DeserializeObject<PakkelabelsToken>(responseString);

            return await GetRequest("https://app.pakkelabels.dk/api/public/v2/shipments/freight_rates", new { token = _token.token, country = country });
        }
        public async Task<string> GetBalance()
        {
            return await GetRequest("https://app.pakkelabels.dk/api/public/v2/users/balance", new { token = _token.Token });
        }

        public async Task<string> GetRequest(string url, object data)
        {
            string res = "empty";

            try
            {
                res = await url.SendJsonAsync(HttpMethod.Get, data).ReceiveString();
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }
        public async Task<string> PostRequest(string url, object data)
        {
            string res = "empty";

            try
            {
                res = await url.SendJsonAsync(HttpMethod.Post, data).ReceiveString();
            }
            catch (Exception ex)
            {
                throw;
            }

            return res;
        }
    }
}
