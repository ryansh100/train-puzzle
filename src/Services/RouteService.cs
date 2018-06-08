using System;
using System.Collections.Generic;
using System.Linq;
using train_puzzle.Entities;

namespace train_puzzle.Services {
    public class RouteService : IRouteService {
        private readonly ITrainLineService trainLineSvc;

        public RouteService(ITrainLineService trainLineSvc) {
            this.trainLineSvc = trainLineSvc;
        }

        /// <summary>        
        /// Gets the distance between a series of cities.
        /// </summary>
        /// <param name="cities">An array of cities represented by A - E</param>
        /// <returns>The cummulative distance of route</returns>
        public float GetDistance(params string[] cities) {
            this.trainLineSvc.GetTrainLines();

            float distance = 0;
            var lastCity = default(string);
            foreach(var city in cities) {
                // Bail early on entry point
                if (lastCity == null) {
                    lastCity = city;
                    continue;
                }

                // Can Safely assume a single match
                var match = trainLineSvc
                    .FilterTrainLines(line => {
                        return line.Origin == lastCity && line.Destination == city;
                    })
                    .FirstOrDefault();

                if(match == null) {
                    throw new System.Exception("NO SUCH ROUTE");
                }

                // Add to cummulative distance
                distance += match.Distance;

                // Prep next iteration
                lastCity = city;
            }

            return distance;
        }

        /// <summary>
        /// Get the shortest route from an origin to a destination
        /// </summary>
        /// <param name="origin">The origin city</param>
        /// <param name="destination">The destination city</param>
        /// <returns>The shortest route</returns>
        public Route GetShortestRoute(string origin, string destination) {
            return GetRoutes(origin, destination, route => {
                    var ids = route.Lines.Select(line => line.Id);
                    var noRepeatLines = ids.Distinct().Count() == ids.Count();

                    return noRepeatLines;
                })
                .OrderBy(route => route.Distance)
                .FirstOrDefault();
        }

        /// <summary>
        /// Provides route list with stop bounds
        /// </summary>
        /// <param name="origin">The origin city</param>
        /// <param name="destination">The destination city</param>
        /// <param name="maximumStops">The max number of stops to make</param>
        /// <param name="minimumStops">The minimum number of stops to make</param>
        /// <returns>A list of route possibilities</returns>
        public IEnumerable<Route> GetRoutesByStops(string origin, string destination, int maximumStops, int minimumStops = 1) {
            return GetRoutes(origin, destination, route => route.Lines.Count() <= maximumStops)
                .Where(route => route.Lines.Count() >= minimumStops);
        }

        /// <summary>
        /// Provides route list with distance limit
        /// </summary>
        /// <param name="origin">The origin city</param>
        /// <param name="destination">The destination city</param>
        /// <param name="maximumDistance">The max distance of routes</param>
        /// <returns>A list of route possibilities</returns>
        public IEnumerable<Route> GetRoutesByMaxDistance(string origin, string destination, float maximumDistance) {
            return GetRoutes(origin, destination, route => route.Distance < maximumDistance);
        }

        /// <summary>
        /// Provides route list
        /// </summary>
        /// <param name="Origin"></param>
        /// <param name="Destination"></param>
        /// <param name="walkTest"></param>
        /// <returns></returns>
        public IEnumerable<Route> GetRoutes(string origin, string destination, Func<Route, bool> walkTest) {
            var entries = new List<Route>();
            var options = trainLineSvc.FilterTrainLines(line => line.Origin == origin);
            var stable = options.ToList();

            foreach(var option in stable) {
                var route = new Route
                {
                    Origin = option.Origin,
                    Destination = option.Destination,
                    Lines = new List<TrainLine>
                    {
                        option
                    }
                };

                if (walkTest(route)) {
                    entries.Add(route);
                }
            }

            return GetRoutes(entries, walkTest)
                .Where(route => route.Destination == destination);
        }

        private IEnumerable<Route> GetRoutes(IEnumerable<Route> routes, Func<Route, bool> walkTest) {
            return routes.SelectMany(route => {
                return GetRoutes(route, walkTest);
            });
        }

        private IEnumerable<Route> GetRoutes(Route route, Func<Route, bool> walkTest) {
            // Include original route
            var entries = new List<Route>();

            var options = trainLineSvc.FilterTrainLines(line => line.Origin == route.Destination);
            foreach(var option in options) {
                var childRoute = new Route
                {
                    Origin = route.Origin,
                    Destination = option.Destination,
                    Lines = route.Lines.Concat(
                        new List<TrainLine>
                        {
                            option
                        })
                };

                if (walkTest(childRoute)) {
                    entries.Add(childRoute);
                }
            }

            return GetRoutes(entries, walkTest)
                    .Append(route);
        }
    }
}