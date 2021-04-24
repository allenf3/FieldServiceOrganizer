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
        public List<Location> FastestRoute { get; private set; }
        public int MinTimeInSeconds { get; private set; }
        public int DistanceInFeetOfMinTimeRoute { get; private set; }
        public Location HomeBase { get; private set; }
        private List<DistanceNode> DistanceNodes { get; set; }

        public RouteCalculator(List<Location> serviceStops)
        {
            _serviceStops = serviceStops;
            DistanceNodes = new();

            // Start and end of all routes
            HomeBase = new Location() { City = "Collinsville", State = "Illinois" };

            // HomeBase to all locations
            foreach(var location in _serviceStops)
            {
                DistanceNodes.Add(GetTimeInSecondsAndDistanceInFeet(HomeBase, location));
            }

            // Create DistanceNode for all edges
            for (int i = 0; i < _serviceStops.Count; i++)
            {
                for (int j = 0; j < _serviceStops.Count; j++)
                {
                    if (j > i) // not same service location or value already calculated
                    {
                        DistanceNodes.Add(GetTimeInSecondsAndDistanceInFeet(_serviceStops[i], _serviceStops[j]));
                    }
                }
            }

            FindOptimalRouteBruteForce();
        }

        private void FindOptimalRouteBruteForce()
        {
            List<List<Location>> allPossibleRoutes = new();
            MinTimeInSeconds = int.MaxValue;
            DistanceInFeetOfMinTimeRoute = int.MaxValue;
            allPossibleRoutes = FindAllPossibleRoutes();

            foreach (var currentRoute in allPossibleRoutes)
            {
                int currentTime = 0;
                int currentDistance = 0;

                // From HomeBase to first stop
                DistanceNode nextNode = DistanceNodes.Where(node => node.From == HomeBase && node.To == currentRoute[0]).FirstOrDefault();
                currentTime += nextNode.TimeInSeconds;
                currentDistance += nextNode.DistanceInFeet;

                // Go to each stop
                for (int i = 0; i < currentRoute.Count - 1; i++)
                {
                    nextNode = DistanceNodes.Where(node => (node.From == currentRoute[i] && node.To == currentRoute[i + 1])
                                                                     || (node.From == currentRoute[i+1] && node.To == currentRoute[i]))
                                                                        .FirstOrDefault();
                    currentTime += nextNode.TimeInSeconds;
                    currentDistance += nextNode.DistanceInFeet;
                }

                // From last stop back to HomeBase
                nextNode = DistanceNodes.Where(node => node.From == HomeBase && node.To == currentRoute[currentRoute.Count - 1]).FirstOrDefault();
                currentTime += nextNode.TimeInSeconds;
                currentDistance += nextNode.DistanceInFeet;

                if (currentTime < MinTimeInSeconds)
                {
                    MinTimeInSeconds = currentTime;
                    DistanceInFeetOfMinTimeRoute = currentDistance;
                    FastestRoute = currentRoute;
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

        public DistanceNode FindRelatedDistanceNode(Location from, Location to)
        {
            DistanceNode dn = DistanceNodes.Where(node => (node.From == from && node.To == to) || (node.From == to && node.To == from))
                                           .FirstOrDefault();

            return dn;
        }
    }
}

