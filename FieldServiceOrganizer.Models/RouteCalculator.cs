using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Models
{
    public class RouteCalculator
    {
        List<LocationPair> LocationPairs;
        int MinTimeInSeconds;
        int MinDistanceInFeet;

        public RouteCalculator(List<Location> locations, Location homeBase)
        {
            if(locations.Count < 6)
            {
                LocationPairs = new();
                for(int i = 0; i < locations.Count; i++)
                {
                    for(int j = i + 1; j < locations.Count; j++)
                    {
                        LocationPair lp = new(locations[i], locations[j]);
                        LocationPairs.Add(lp);
                    }
                }
            }
        }
    }

    public class LocationPair
    {
        public Location From { get; init; }
        public Location To { get; init; }
        public int DistanceInFeet { get; set; }
        public int TimeInSeconds { get; set; }

        public LocationPair(Location from, Location to)
        {
            From = from;
            To = to;
            GetTimeInSeconds();
            GetDistanceInFeet();
        }

        public void GetDistanceInFeet()
        {
            DistanceInFeet = TimeInSeconds * 70;
        }

        public void GetTimeInSeconds()
        {
            TimeInSeconds = new Random().Next(7200);
        }
    }
}
