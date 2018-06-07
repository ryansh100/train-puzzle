using System.Collections.Generic;
using System.Linq;

namespace train_puzzle.Entities {
    /// <summary>
    /// A class to represent a route between one or more cities.
    /// </summary>
    public class Route {
        /// <summary>
        /// Gets or sets the origin of the train line.
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Gets or sets the destination of the train line.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the lines used to connect cities
        /// </summary>
        public IEnumerable<TrainLine> Lines { get; set; }

        /// <summary>
        /// Gets the Cummulative Distance of the route
        /// </summary>
        public float Distance {
            get {
                return Lines.Sum(l => l.Distance);
            }
        }

        /// <summary>
        /// Evaluates if the current route is valid
        /// </summary>
        /// <returns>Whether or not the route passes validation</returns>
        public bool ValidateLines() {
            // Ensure that starts in the correct city
            var startingPoint = Lines.FirstOrDefault();
            if (startingPoint == null || startingPoint.Origin != Origin) {
                return false;
            }

            // Ensure that the route ends in the correct city
            var endingPoint = Lines.LastOrDefault();
            if (endingPoint == null || endingPoint.Destination != Destination) {
                return false;
            }

            // Ensure that lines connect
            var lastDestination = string.Empty;
            foreach(var line in Lines) {
                // Invalidate if not at starting point and last destination 
                // does not equal current origin
                if (lastDestination != string.Empty && lastDestination != line.Origin) {
                    return false;
                }
                lastDestination = line.Destination;
            }

            return true;
        }
    }
}