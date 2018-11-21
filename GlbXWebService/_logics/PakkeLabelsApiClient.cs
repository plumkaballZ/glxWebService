using Flurl.Http;
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

        public async Task<string> CreateTestShipment()
        {
            var responseString = await "https://app.pakkelabels.dk/api/public/v2/users/login"
               .PostUrlEncodedAsync(new { api_user = "0930aeb1-1412-4260-9f19-63fb1d010720", api_key = "1031bb73-6770-46eb-9960-6b1ab31d322e" })
               .ReceiveString();

            _token = JsonConvert.DeserializeObject<PakkelabelsToken>(responseString);

            return await PostRequest("https://app.pakkelabels.dk/api/public/v2/shipments/imported_shipment", new
            {
                token = _token.token,
                shipping_agent = "pdk",
                shipping_product_id = "51",
                weight = "1000",

                receiver_name = "Ervin Færgemand",
                receiver_address1 = "Blommevænget 114",
                receiver_zipcode = "8300",
                receiver_city = "Odder",
                receiver_country = "DK",
                receiver_mobile = "12345678",
                receiver_email = "test@test.dk",

                sender_email = "test@test.dk",
                sender_name = "Shevlin",
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
