namespace train_puzzle.Entities {
    /// <summary>
    /// A class with the standard output results reported for current
    /// </summary>
    public class RouteReport {
        /// <summary>
        /// Gets or sets Output 1.
        /// A-B-C distance
        /// </summary>
        public string Output1 { get; set; }

        /// <summary>
        /// Gets or sets Output 2.
        /// A-D distance
        /// </summary>
        public string Output2 { get; set; }

        /// <summary>
        /// Gets or sets Output 3.
        /// A-D-C distance
        /// </summary>
        public string Output3 { get; set; }

        /// <summary>
        /// Gets or sets Output 4.
        /// A-E-B-C-D distance
        /// </summary>
        public string Output4 { get; set; }

        /// <summary>
        /// Gets or sets Output 5.
        /// A-E-D distance
        /// </summary>
        public string Output5 { get; set; }

        /// <summary>
        /// Gets or sets Output 6.
        /// Number of routes from C to C with 3 or less stops
        /// </summary>
        public int Output6 { get; set; }

        /// <summary>
        /// Gets or sets Output 7.
        /// Routes from A to C that make exactly 4 stops
        /// </summary>
        public int Output7 { get; set; }

        /// <summary>
        /// Gets or sets Output 8.
        /// Shortest Route from A to C
        /// </summary>
        public float Output8 { get; set; }

        /// <summary>
        /// Gets or sets Output 9.
        /// Shortest Route from C to C
        /// </summary>
        public float Output9 { get; set; }

        /// <summary>
        /// Gets or sets Output 10.
        /// Routes from city C to city C that travel less than 30.
        /// </summary>
        public int Output10 { get; set; }

    }
}