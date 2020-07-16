
namespace BusBoard
{
    public class PostcodeApiResponse
    {
        public PostcodeDetails Result { get; set; }
    }

    public class PostcodeDetails
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}