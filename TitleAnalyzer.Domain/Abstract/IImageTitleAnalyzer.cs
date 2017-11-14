using System.Collections.Generic;
using TitleAnalyzer.Domain.Entities;

namespace TitleAnalyzer.Domain.Abstract
{
    /// <summary>
    /// Image title analyzer interface
    /// </summary>
    public interface IImageTitleAnalyzer
    {
        /// <summary>
        /// Page repository to analyse
        /// </summary>
        IPageRepository PageRepository { get; set; }

        /// <summary>
        /// Similarity calculator
        /// </summary>
        ISimilarityCalculator SimilarityCalculator { get; set; }

        /// <summary>
        /// Similarity calculation
        /// </summary>
        IList<TitleSimilarity> GetSimilarities();
    }
}
