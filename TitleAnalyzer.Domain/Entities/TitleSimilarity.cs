namespace TitleAnalyzer.Domain.Entities
{
    /// <summary>
    /// Title similarity
    /// </summary>
    public class TitleSimilarity
    {
        /// <summary>
        /// Similarity Value
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// First title to compare
        /// </summary>
        public string Title1 { get; set; }

        /// <summary>
        /// Second title to compare
        /// </summary>
        public string Title2 { get; set; }
    }
}
