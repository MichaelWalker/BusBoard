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
    }
}