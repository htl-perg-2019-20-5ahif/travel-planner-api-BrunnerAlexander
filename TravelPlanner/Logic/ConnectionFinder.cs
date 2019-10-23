using Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class ConnectionFinder
    {
        private readonly IEnumerable<Travel> routes;

        public ConnectionFinder(IEnumerable<Travel> routes)
        {
            this.routes = routes;
        }

        public ResultTravel FindConnection(string from, string to, string start)
        {
            if (from == "Linz" && to == "Linz") return null;

            if (from == "Linz" || to == "Linz")
            {
                IEnumerable<Trip> trips;
                if (from == "Linz")
                {
                    trips = routes.FirstOrDefault(r => r.City == to).FromLinz;
                }
                else
                {
                    trips = routes.FirstOrDefault(r => r.City == from).ToLinz;
                }

                var res = trips.FirstOrDefault(t => t.Leave.CompareTo(start) >= 0);
                if(res != null)
                {
                    return new ResultTravel
                    {
                        depart = from,
                        departureTime = res.Leave,
                        arrive = to,
                        arrivalTime = res.Arrive
                    };
                }
            }
            

            return null;
        }

    }
}
