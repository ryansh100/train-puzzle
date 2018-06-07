using System.Globalization;

namespace train_puzzle.Entities {
    /// <summary>
    /// A class to represent a train line between two cities.
    /// </summary>
    public class TrainLine {
        /// <summary>
        /// Gets or sets the origin of the train line.
        /// </summary>
        public string Origin { get; set; }

        /// <summary>
        /// Gets or sets the destination of the train line.
        /// </summary>
        public string Destination { get; set; }

        /// <summary>
        /// Gets or sets the distance between origin and destination
        /// </summary>
        public float Distance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputString"></param>
        public static TrainLine Parse(string inputString) {
            var instance = new TrainLine();
            // Assume origin is always represented by single alphabetical character
            instance.Origin = inputString.Substring(0,1);

            // Assume destination is always represented by single alphabetical character
            instance.Destination = inputString.Substring(1,1);

            // Assume remainder of input string is the distance in positive numeric string value
            var distanceString = inputString.Substring(2);
            instance.Distance = float.Parse(distanceString, CultureInfo.CurrentUICulture);

            return instance;
        }
    }
}