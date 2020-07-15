using System;
using System.Linq;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read in the stopcode from the user
            
            // make an API call
            
            // print some stuff out.
            
            
            var transportApiClient = new TransportApiClient();

            var stopCode = GetStopCodeFromUser();

            var departures = transportApiClient.GetBusDeparturesForStop(stopCode);

            PrintNextBuses(departures);
        }

        private static void PrintNextBuses(BusDepartureResponse departures)
        {
            Console.WriteLine($"\n\nNext buses at {departures.Name}");
            foreach (var departure in departures.Departures.All.Take(5))
            {
                Console.WriteLine($"Line: {departure.Line}, To: {departure.Direction}, Leaving at: {departure.ExpectedDepartureTime}");
            }
        }

        private static string GetStopCodeFromUser()
        {
            Console.WriteLine("Please enter the bus stop code:");
            return Console.ReadLine();
        }
    }
}