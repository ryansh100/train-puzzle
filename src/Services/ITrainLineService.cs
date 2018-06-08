using System;
using System.Collections.Generic;
using train_puzzle.Entities;

namespace train_puzzle.Services {
    public interface ITrainLineService
    {
        /// <summary>
        /// Get a list of TrainLines registered
        /// </summary>
        /// <returns>A list of Train Lines</returns>
        IEnumerable<TrainLine> GetTrainLines();

        /// <summary>
        /// Get a Train Line by Id in AA0 format
        /// </summary>
        /// <param name="id">The id of train line</param>
        /// <returns>The Train Lines</returns>
        TrainLine GetTrainLine(string id);

        /// <summary>
        /// Delete a Train Line by Id in AA0 format
        /// </summary>
        /// <param name="id">The id of train line</param>
        /// <returns>void</returns>

        void DeleteTrainLine(string id);

        /// <summary>
        /// Get a list of TrainLines registered filtered by predicate
        /// </summary>
        /// <param name="predicate">Filter Predicate</param>
        /// <returns>A list of Train Lines</returns>
        IEnumerable<TrainLine> FilterTrainLines(Func<TrainLine, bool> predicate);

        /// <summary>
        /// Add a train line. Verifies that train line does not exist already
        /// </summary>
        /// <param name="line">The TrainLine to add</param>
        /// <returns>Void</returns>
        void Add(TrainLine line);

        /// <summary>
        /// Can parse an input string into a list of train lines
        /// </summary>
        /// <param name="inputString">A single or comma separated list of city/distance notation train lines</param>
        /// <returns>A list of Train Lines</returns>
        IEnumerable<TrainLine> Parse(string inputString);
    }
}