using System.Collections.Generic;

namespace BusBoard
{
    public class NearestBusStopsResponse
    {
        public List<BusStop> Member { get; set; }
    }

    public class BusStop
    {
        public string Atcocode { get; set; }
    }
}