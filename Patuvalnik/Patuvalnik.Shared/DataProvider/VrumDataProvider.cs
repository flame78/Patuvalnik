using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace Patuvalnik.REST
{
    using Newtonsoft.Json;
    using Patuvalnik.Models;

    public class VrumDataProvider
    {
        private const string ReqUri = "http://api.vrumapp.com/api/v1/trips/{0}.json?page=1";
        //      private const string ReqUri = "http://api.vrumapp.com/api/v1/trips/from/1.json";  http://api.vrumapp.com/api/v1/trips/from/{0}/to/{1}.json?page=1
        public VrumDataProvider()
        {
        }

        public async Task<List<Trip>> GetInformation(int from, int to)
        {
            string reqUri = String.Empty;
            if (from == 0)
            {
                reqUri = String.Format(ReqUri,"to/{0}");
                reqUri = String.Format(reqUri, to);
            }
            else if (to == 0)
            {
                reqUri = String.Format(ReqUri, "from/{0}");
                reqUri = String.Format(reqUri, from); 
            }
            else
            {
                reqUri = String.Format(ReqUri, "from/{0}/to/{1}");
                reqUri = String.Format(reqUri,from, to);
            }

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add(
                "Authorization",
                "Token token=\"40b5ff1bb96522775c16f0fc2c1834b29b8736a4e8a39ddfae917c5b33229b89cdcb86ae0487fccd588513ca9b313eae1b94360c8647db272d77d45fc06d9cd1\"");

            var uri = new Uri(reqUri);

            var response = await client.GetStringAsync(uri);

            List<Trip> resultObj = JsonConvert.DeserializeObject<List<Trip>>(response);

            return resultObj;
        }
    }
}
