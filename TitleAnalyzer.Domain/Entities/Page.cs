using System.Collections.Generic;

namespace TitleAnalyzer.Domain.Entities
{
    /// <summary>
    /// Page from Wikipedia
    /// </summary>
    public class Page
    {
        /// <summary>
        /// Page ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Page title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Image collection
        /// </summary>
        public IList<Image> Images { get; set; }
    }
}
