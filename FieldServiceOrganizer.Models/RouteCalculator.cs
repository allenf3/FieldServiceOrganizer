using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Models
{
    public class RouteCalculator
    {
        Tuple<int, int>[,] AdjacencyMatrix;
        List<Location> Location;
        int MinTimeInSeconds;
        int MinDistanceInFeet;

        public RouteCalculator(List<Location> locations)
        {
            Location homeBase = new Location() { City = "Collinsville", State = "Illinois" };

            List<Location> homeBasePlusLocations = new();
            homeBasePlusLocations.Add(homeBase);

            if (locations != null)
            {
                foreach (var location in locations)
                {
                    homeBasePlusLocations.Add(location);  // Home base is always at element 0
                }
            }

            AdjacencyMatrix = new Tuple<int, int>[homeBasePlusLocations.Count, homeBasePlusLocations.Count];
            for (int i = 0; i < homeBasePlusLocations.Count; i++)
            {
                for (int j = 0; j < homeBasePlusLocations.Count; j++)
                {
                    if (i >= j)
                    {
                        AdjacencyMatrix[i, j] = GetDistanceInFeetAndTimeInSeconds(homeBasePlusLocations[i], homeBasePlusLocations[j]);
                    }
                    else
                    {
                        AdjacencyMatrix[i, j] = null;
                    }
                }
            }
        }

        public Tuple<int, int> GetDistanceInFeetAndTimeInSeconds(Location from, Location to)
        {
            // Dummy data returned for now
            // TODO get real data from map API
            int timeInSeconds = new Random().Next(7200);
            int distanceInFeet = timeInSeconds * 70;
            return new Tuple<int, int>(timeInSeconds, distanceInFeet);
        }
    }
}

