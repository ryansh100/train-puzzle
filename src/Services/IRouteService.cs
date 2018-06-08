using System;
using System.Collections.Generic;
using train_puzzle.Entities;

namespace train_puzzle {
    public interface IRouteService
    {
        /// <summary>
        /// Gets the distance between a series of cities.
        /// </summary>
        /// <param name="cities">An array of cities represented by A - E</param>
        /// <returns>The cummulative distance of route</returns>
        float GetDistance(params string[] cities);

        /// <summary>
        /// Get the shortest route from an origin to a destination
        /// </summary>
        /// <param name="origin">The origin city</param>
        /// <param name="destination">The destination city</param>
        /// <returns>The shortest route</returns>
        Route GetShortestRoute(string origin, string destination);

        /// <summary>
        /// Provides route list with stop bounds
        /// </summary>
        /// <param name="origin">The origin city</param>
        /// <param name="destination">The destination city</param>
        /// <param name="maximumStops">The max number of stops to make</param>
        /// <param name="minimumStops">The minimum number of stops to make</param>
        /// <returns>A list of route possibilities</returns>
        IEnumerable<Route> GetRoutesByStops(string origin, string destination, int maximumStops, int minimumStops = 1);

        /// <summary>
        /// Provides route list with stop bounds
        /// </summary>
        /// <param name="origin">The origin city</param>
        /// <param name="destination">The destination city</param>
        /// <param name="maximumDistance">The max distance to traval on route</param>
        /// <returns>A list of route possibilities</returns>
        IEnumerable<Route> GetRoutesByMaxDistance(string origin, string destination, float maximumDistance);

        /// <summary>
        /// Provides route list with function to determine if the route is valid
        /// </summary>
        /// <param name="origin">The origin city</param>
        /// <param name="destination">The destination city</param>
        /// <param name="walkTest">A test to evaluate if the route is valid</param>
        /// <returns>A list of route possibilities</returns>
        IEnumerable<Route> GetRoutes(string origin, string destination, Func<Route, bool> walkTest);
    }
}