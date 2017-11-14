using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TitleAnalyzer.Domain.Entities;

namespace TitleAnalyzer.Domain.Abstract
{
    /// <summary>
    /// Similarity calculator interface
    /// </summary>
    public interface ISimilarityCalculator
    {
        /// <summary>
        /// Similarity calculation
        /// </summary>
        double Calculate(string string1, string string2);
    }

}
