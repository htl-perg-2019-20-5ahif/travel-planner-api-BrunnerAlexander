using System;
using System.Collections.Generic;
using System.Text;

namespace Logic.Models
{
    public class Travel
    {
        public string City { get; set; }
        public Trip[] ToLinz { get; set; }
        public Trip[] FromLinz { get; set; }
    }

    public class Trip
    {
        public string Leave { get; set; }
        public string Arrive { get; set; }
    }

    public class ResultTravel
    {
        public string depart { get; set; }
        public string departureTime { get; set; }
        public string arrive { get; set; }
        public string arrivalTime { get; set; }
    }
}
