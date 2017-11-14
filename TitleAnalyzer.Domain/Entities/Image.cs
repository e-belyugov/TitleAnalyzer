namespace TitleAnalyzer.Domain.Entities
{
    /// <summary>
    /// Image from Wikipedia
    /// </summary>
    public class Image
    {
        /// <summary>
        /// Page ID
        /// </summary>
        public int PageID { get; set; }

        /// <summary>
        /// Image title
        /// </summary>
        public string Title { get; set; }
    }
}
