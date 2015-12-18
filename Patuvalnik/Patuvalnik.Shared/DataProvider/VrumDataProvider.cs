namespace Patuvalnik.REST
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Windows.Web.Http;

    using Newtonsoft.Json;

    using Patuvalnik.Contracts;
    using Patuvalnik.Models;

    public class VrumDataProvider : IDataProvider
    {
        private const string ReqUri = "http://api.vrumapp.com/api/v1/{0}";

        private readonly HttpClient client;

        public VrumDataProvider()
        {
            this.client = new HttpClient();
            this.client.DefaultRequestHeaders.Add(
                "Authorization",
                "Token token=\"40b5ff1bb96522775c16f0fc2c1834b29b8736a4e8a39ddfae917c5b33229b89cdcb86ae0487fccd588513ca9b313eae1b94360c8647db272d77d45fc06d9cd1\"");
        }

        public async Task<List<Trip>> GetTrips(int from, int to)
        {
            string reqUri = String.Empty;
            if (from == 0)
            {
                reqUri = String.Format(ReqUri, "trips/to/{0}.json?page=1");
                reqUri = String.Format(reqUri, to);
            }
            else if (to == 0)
            {
                reqUri = String.Format(ReqUri, "trips/from/{0}.json?page=1");
                reqUri = String.Format(reqUri, from);
            }
            else
            {
                reqUri = String.Format(ReqUri, "trips/from/{0}/to/{1}.json?page=1");
                reqUri = String.Format(reqUri, from, to);
            }

            var uri = new Uri(reqUri);

            var response = await this.client.GetStringAsync(uri);

            var resultObj = JsonConvert.DeserializeObject<List<Trip>>(response);

            return resultObj;
        }

        public async Task<List<City>> GetCities()
        {
            string reqUri = String.Empty;
            reqUri = String.Format(ReqUri, "cities.json");

            var uri = new Uri(reqUri);

            var response = await this.client.GetStringAsync(uri);

            var resultObj = JsonConvert.DeserializeObject<List<City>>(response);

            return resultObj;
        }
    }
}