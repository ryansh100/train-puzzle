namespace train_puzzle.Entities {
    /// <summary>
    /// A class to represent a train line between two cities.
    /// </summary>
    public class TrainLine {
        /// <summary>
        /// Gets or set the Id of TrainLine
        /// </summary>
        public string Id { get; set; }
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
    }
}