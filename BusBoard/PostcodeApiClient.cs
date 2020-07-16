using RestSharp;

namespace BusBoard
{
    public class PostcodeApiClient
    {
        private RestClient _client;

        public PostcodeApiClient()
        {
            _client = new RestClient("https://api.postcodes.io");
        }

        public PostcodeDetails GetPostcodeDetails(string postcode)
        {
            var request = new RestRequest("postcodes/{postcode}")
                .AddUrlSegment("postcode", postcode);

            var response = _client.Get<PostcodeApiResponse>(request);
            var postcodeApiResponse = response.Data;
            return postcodeApiResponse.Result;
        }
    }
}