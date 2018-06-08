using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using train_puzzle.Entities;

namespace train_puzzle.Services {
    /// <summary>
    /// A Class that handles unique Train Lines
    /// </summary>
    public class TrainLineService : ITrainLineService {
        private Dictionary<string, TrainLine> Collection;

        /// <summary>
        /// Constructor for TrainLineService
        /// </summary>
        public TrainLineService() {
            Collection = new Dictionary<string, TrainLine>();
        }

        /// <summary>
        /// Get a list of TrainLines registered
        /// </summary>
        /// <returns>A list of Train Lines</returns>
        public IEnumerable<TrainLine> GetTrainLines() {
            return Collection.Select(pair => pair.Value);
        }

        /// <summary>
        /// Get a Train Line by Id in AA0 format
        /// </summary>
        /// <param name="id">The id of train line</param>
        /// <returns>The Train Lines</returns>
        public TrainLine GetTrainLine(string id) {
            var value = default(TrainLine);
            Collection.TryGetValue(id, out value);
            return value;
        }

        /// <summary>
        /// Delete a Train Line by Id in AA0 format
        /// </summary>
        /// <param name="id">The id of train line</param>
        /// <returns>void</returns>
        public void DeleteTrainLine(string id) {
            Collection.Remove(id);
        }

        /// <summary>
        /// Get a list of TrainLines registered filtered by predicate
        /// </summary>
        /// <param name="predicate">Filter Predicate</param>
        /// <returns>A list of Train Lines</returns>
        public IEnumerable<TrainLine> FilterTrainLines(Func<TrainLine, bool> predicate) {
            return GetTrainLines()
                .Where(predicate);
        }

        /// <summary>
        /// Add a train line. Verifies that train line does not exist already
        /// </summary>
        /// <param name="line">The TrainLine to add</param>
        /// <returns>Void</returns>
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
        public IEnumerable<TrainLine> Parse(string inputString) {
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