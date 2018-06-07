using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using train_puzzle.Entities;

namespace train_puzzle.Services {
    class TrainLineService {
        private Dictionary<string, TrainLine> Collection { get; set; }

        public IEnumerable<TrainLine> TrainLines {
            get {
                return Collection.Select(pair => pair.Value);
            }
        }

        public void Add(TrainLine line) {
            if (!Collection.ContainsKey(line.Id)) {
                Collection.Add(line.Id, line);
            } else {
                // TODO: Should emit warning/error.
                return;
            }
        }

        /// <summary>
        /// Will parse a string with one or more comma separated train lines.
        /// </summary>
        /// <param name="inputString">The string of input</param>
        /// <return>A List of TrainLines</return>
        public static IEnumerable<TrainLine> Parse(string inputString) {
            // Accept in comma deliminated
            var results = new List<TrainLine>();
            foreach(var chunk in inputString.Split(',')) {
                var instance = new TrainLine();
                var trimmed = chunk.Trim();
                // assign the string as a unique ID
                instance.Id = trimmed;

                // Assume origin is always represented by single alphabetical character
                instance.Origin = trimmed.Substring(0,1);

                // Assume destination is always represented by single alphabetical character
                instance.Destination = trimmed.Substring(1,1);

                // Assume remainder of input string is the distance in positive numeric string value
                var distanceString = trimmed.Substring(2);
                instance.Distance = float.Parse(distanceString, CultureInfo.CurrentUICulture);

                // Add line to parse results
                results.Add(instance);
            }

            return results;
        }
    }
}