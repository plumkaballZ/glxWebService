using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace GlbXWebService._logics
{
    public class PakkeLabelsApiClient
    {
        private string _urlV1 = "https://app.pakkelabels.dk/api/public/v1/";
        private string _urlV2 = "https://app.pakkelabels.dk/api/public/v2/";
       


        public void test()
        {
            ((Action)(async () =>
            {
                var responseString = await "https://app.pakkelabels.dk/api/public/v2/users/login"
                .PostUrlEncodedAsync(new { api_user = "0930aeb1-1412-4260-9f19-63fb1d010720", api_key = "1031bb73-6770-46eb-9960-6b1ab31d322e" })
                .ReceiveString();

                Debug.WriteLine(responseString);

            }))();
        }
    }
}
