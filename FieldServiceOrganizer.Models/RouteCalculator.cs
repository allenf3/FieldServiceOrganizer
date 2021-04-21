using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldServiceOrganizer.Models
{
    public class RouteCalculator
    {
        private readonly List<Location> _serviceStops;
        // private (int TimeInSeconds, int DistanceInFeet)[,] _adjacencyMatrix { get; set; }
        public int MinTimeInSeconds { get; private set; }
        public int DistanceInFeetOfMinTimeRoute { get; private set; }
        public Location HomeBase { get; set; }
        private List<DistanceNode> DistanceNodes { get; set; }

        public RouteCalculator(List<Location> serviceStops)
        {
            _serviceStops = serviceStops;

            // Start and end of all routes
            HomeBase = new Location() { City = "Collinsville", State = "Illinois" };

            // Populate matrix with time and distance info to and from all locations
            // _adjacencyMatrix = new (int TimeInSeconds, int DistanceInFeet)[_serviceStops.Count, _serviceStops.Count];

            foreach(var location in _serviceStops)
            {
                DistanceNodes.Add(GetTimeInSecondsAndDistanceInFeet(HomeBase, location));
            }


            // Populate upper half of matrix only (undirected graph)
            //for (int i = 0; i < _serviceStops.Count; i++)
            //{
            //    for (int j = 0; j < _serviceStops.Count; j++)
            //    {
            //        if (i < j)
            //        {
            //            _adjacencyMatrix[i, j] = GetTimeInSecondsAndDistanceInFeet(_serviceStops[i], _serviceStops[j]);
            //        }
            //        else
            //        {
            //            _adjacencyMatrix[i, j] = (0, 0);
            //        }
            //    }
            //}

            FindOptimalRouteBruteForce();
        }

        private void FindOptimalRouteBruteForce()
        {
            List<List<Location>> allPossibleRoutes = new();
            MinTimeInSeconds = int.MaxValue;
            DistanceInFeetOfMinTimeRoute = int.MaxValue;
            allPossibleRoutes = FindAllPossibleRoutes();

            foreach (var possibleRoute in allPossibleRoutes)
            {
                int currentTime = 0;
                int currentDistance = 0;

                // From HomeBase to first stop
                DistanceNode nextNode = DistanceNodes.Where(node => node.From == HomeBase && node.To == possibleRoute[0]).FirstOrDefault();
                currentTime += nextNode.TimeInSeconds;
                currentDistance += nextNode.DistanceInFeet;

                // Go to each stop
                for (int i = 1; i < possibleRoute.Count; i++)
                {
                    nextNode = DistanceNodes.Where(node => (node.From == possibleRoute[i] && node.To == possibleRoute[i + 1])
                                                                     || (node.From == possibleRoute[i+1] && node.To == possibleRoute[i]))
                                                                        .FirstOrDefault();
                    currentTime += nextNode.TimeInSeconds;
                    currentDistance += nextNode.DistanceInFeet;
                }

                // From last stop back to HomeBase
                nextNode = DistanceNodes.Where(node => node.From == HomeBase && node.To == possibleRoute[possibleRoute.Count - 1]).FirstOrDefault();
                currentTime += nextNode.TimeInSeconds;
                currentDistance += nextNode.DistanceInFeet;

                if (currentTime < MinTimeInSeconds)
                {
                    MinTimeInSeconds = currentTime;
                    DistanceInFeetOfMinTimeRoute = currentDistance;
                }
            }
        }

        private DistanceNode GetTimeInSecondsAndDistanceInFeet(Location from, Location to)
        {
            // Dummy data returned for now
            // TODO get real data from map API
            DistanceNode node = new();
            node.TimeInSeconds = new Random().Next(7200);
            node.DistanceInFeet = node.TimeInSeconds * 70;
            node.From = from;
            node.To = to;
            return node;
        }

        private List<List<Location>> FindAllPossibleRoutes()
        {
            List<List<Location>> routes = new();
            Location[] currentRoute = new Location[_serviceStops.Count];
            bool[] added = new bool[_serviceStops.Count];
            CalculateRoutes(_serviceStops, currentRoute, added, routes, 0);

            return routes;
        }

        private void CalculateRoutes(List<Location> locations,  Location[] currentRoute, bool[] added, List<List<Location>> routes, int count)
        {
            if (count == locations.Count)
            {
                routes.Add(currentRoute.ToList());
            }
            else
            {
                for (int i = 0; i < locations.Count; i++)
                {
                    if(!added[i])
                    {
                        added[i] = true;
                        currentRoute[count] = locations[i];
                        CalculateRoutes(locations, currentRoute, added, routes, count + 1);
                        added[i] = false;
                    }
                }
            }
        }
    }
}

