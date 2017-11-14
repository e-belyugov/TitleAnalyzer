using System.Collections.Generic;
using System.IO;
using TitleAnalyzer.Domain.Abstract;
using TitleAnalyzer.Domain.Entities;
using System.Linq;

namespace TitleAnalyzer.MyAnalyzer
{
    /// <summary>
    /// My specific image title analyzer
    /// </summary>
    public class MyAnalyzer : IImageTitleAnalyzer
    {
        // Private fields
        private IPageRepository _repo;
        private IList<Image> _images = new List<Image>();
        private IList<TitleSimilarity> _similarities = new List<TitleSimilarity>();
        private ISimilarityCalculator _calculator;

        /// <summary>
        /// Page collection to analyze
        /// </summary>
        public IPageRepository PageRepository
        {
            get
            {
                return _repo;
            }
            set
            {
                _repo = PageRepository;
            }
        }

        /// <summary>
        /// Similarity Calculator
        /// </summary>
        public ISimilarityCalculator SimilarityCalculator
        {
            get
            {
                return _calculator;
            }
            set
            {
                _calculator = SimilarityCalculator;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MyAnalyzer(IPageRepository pageRepository, ISimilarityCalculator similarityCalculator)
        {
            _repo = pageRepository;
            _calculator = similarityCalculator;
        }

        /// <summary>
        /// Clearing title of not meaningful substrings
        /// </summary>
        private string ClearTitle(string title)
        {
            title = title.Replace("File:", "").Replace("\"", "");
            title = Path.GetFileNameWithoutExtension(title);
            return title;
        }

        /// <summary>
        /// Similarity calculation
        /// </summary>
        public IList<TitleSimilarity> GetSimilarities()
        {
            // Creating global image list
            _images.Clear();
            foreach (var page in _repo.Pages)
            {
                if (page.Images != null)
                {
                    foreach (var image in page.Images)
                    {
                        bool containsImage = _images.Any(item => item.Title == image.Title); // Images with identical titles are not so interesting (miss them)
                        if (!containsImage) _images.Add(image);
                    }
                }
            }

            // Calculating and saving similarities
            _similarities.Clear();
            int count = _images.Count;
            for (int i = 0; i < count; i++)
            {
                for (int j = i + 1; j < count; j++)
                {
                    TitleSimilarity similarity = new TitleSimilarity();
                    similarity.Title1 = ClearTitle(_images[i].Title);
                    similarity.Title2 = ClearTitle(_images[j].Title);

                    // Calculating similarity for two image titles
                    similarity.Value = _calculator.Calculate(similarity.Title1, similarity.Title2);
 
                    _similarities.Add(similarity);
                }
            }

            // Sorting similarities
            List<TitleSimilarity> _similaritiesSorted = _similarities.OrderBy(o => o.Value).ToList();

            return _similaritiesSorted;
        }
    }
}
