using System.Collections.Generic;
using TitleAnalyzer.Domain.Entities;

namespace TitleAnalyzer.Domain.Abstract
{
    /// <summary>
    /// Struct for page location
    /// </summary>
    public struct Location
    {
        /// <summary>
        /// Latitude
        /// </summary>
        public double latitude;
        /// <summary>

        /// Longitude
        /// </summary>
        public double longitude;
    }

    /// <summary>
    /// Page repository interface
    /// </summary>
    public interface IPageRepository
    {
        /// <summary>
        /// Page collection
        /// </summary>
        IList<Page> Pages { get;}

        /// <summary>
        /// Load collection by location
        /// </summary>
        void Load(Location location);
    }
}
