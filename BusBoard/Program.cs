using System;
using System.Collections.Generic;
using System.Linq;
using static System.Decimal;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var transportApiClient = new TransportApiClient();
            var postcodeApiClient = new PostcodeApiClient();
            
            var postcode = GetPostcodeFromUser();
            var postcodeDetails = postcodeApiClient.GetPostcodeDetails(postcode);
            var nearbyBusStopCodes =
                transportApiClient.GetNearestStopCodes(postcodeDetails.Latitude, postcodeDetails.Longitude);

            foreach (var stopCode in nearbyBusStopCodes.Take(2))
            {
                var departures = transportApiClient.GetBusDeparturesForStop(stopCode);
                PrintNextBuses(departures);
            }
        }

        private static void PrintNextBuses(BusDepartureResponse departures)
        {
            Console.WriteLine($"\n\nNext buses at {departures.Name}");
            foreach (var departure in departures.Departures.All.Take(5))
            {
                Console.WriteLine($"Line: {departure.Line}, To: {departure.Direction}, Leaving at: {departure.ExpectedDepartureTime}");
            }
        }

        private static string GetPostcodeFromUser()
        {
            Console.WriteLine("Please enter your postcode:");
            return Console.ReadLine();
        }
    }
}