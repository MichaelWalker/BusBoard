using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace BusBoard
{
    public class TransportApiClient
    {
        private RestClient client;

        public TransportApiClient()
        {
            client = new RestClient("https://transportapi.com/");
        }

        public BusDepartureResponse GetBusDeparturesForStop(string stopcode)
        {
            var request = new RestRequest("v3/uk/bus/stop/{stopcode}/live.json")
                .AddUrlSegment("stopcode", stopcode)
                .AddQueryParameter("app_id", "3d4e7caf")
                .AddQueryParameter("app_key", "d6e85b063f40ecaa367a39324004c466")
                .AddQueryParameter("group", "no")
                .AddQueryParameter("nextbuses", "yes");

            var response = client.Get<BusDepartureResponse>(request);
            return response.Data;
        }

        public List<string> GetNearestStopCodes(double latitude, double longitude)
        {
            var request = new RestRequest("v3/uk/places.json")
                .AddQueryParameter("lat", latitude.ToString())
                .AddQueryParameter("lon", longitude.ToString())
                .AddQueryParameter("type", "bus_stop")
                .AddQueryParameter("app_id", "3d4e7caf")
                .AddQueryParameter("app_key", "d6e85b063f40ecaa367a39324004c466");

            var response = client.Get<NearestBusStopsResponse>(request);
            var nearestStopResponse = response.Data;

            return nearestStopResponse.Member
                .Select(busStop => busStop.Atcocode)
                .ToList();
        }
    }
}