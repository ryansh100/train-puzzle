using System.Collections.Generic;
using train_puzzle.Entities;

namespace train_puzzle.Services {
    public interface ITrainLineService
    {
        /// <summary>
        /// Can parse an input string into a list of train lines
        /// </summary>
        /// <param name="inputString">A single or comma separated list of city/distance notation train lines</param>
        /// <returns>A list of Train Lines</returns>
        IEnumerable<TrainLine> Parse(string inputString);
    }
}