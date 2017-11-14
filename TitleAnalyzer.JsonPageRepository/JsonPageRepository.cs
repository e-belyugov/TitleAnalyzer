using System;
using TitleAnalyzer.Domain.Abstract;
using TitleAnalyzer.Domain.Entities;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace TitleAnalyzer.JsonPageRepository
{
    /// <summary>
    /// Page repository from Json source
    /// </summary>
    public class JsonPageRepository : IPageRepository
    {
        private IList<Page> _pages = new List<Page>();

        /// <summary>
        /// Page collection
        /// </summary>
        public IList<Page> Pages
        {
            get
            {
                return _pages;
            }
        }

        /// <summary>
        /// Loading pages
        /// </summary>
        public void Load(Location location)
        {
            // Coonecting to Wikipedia API (query for pages)
            WebClient client = new WebClient();
            string url = "https://en.wikipedia.org/w/api.php?action=query&list=geosearch&gsradius=10000&gscoord="
                + location.latitude.ToString("0.######", System.Globalization.CultureInfo.InvariantCulture) + "|"
                + location.longitude.ToString("0.######", System.Globalization.CultureInfo.InvariantCulture) + "&gslimit=50&format=json";
            string json = client.DownloadString(url);

            // Parse Json for pages
            JObject o = JObject.Parse(json);
            var doc = (JContainer)o["query"]["geosearch"];

            // Settings for resolving page properties
            var mapPage = new Dictionary<Type, Dictionary<string, string>>
            {
                { 
                    typeof(Page), 
                    new Dictionary<string, string>
                    {
                        {"ID", "pageid"},
                        {"Title", "title"}                    
                    }
                }
            };
            var settingsPage = new JsonSerializerSettings
            {
                ContractResolver = new DynamicMappingResolver(mapPage)
            };

            // Deserializing page collection
            _pages.Clear();
            _pages = JsonConvert.DeserializeObject<List<Page>>(doc.ToString(), settingsPage);

            // Settings for resolving image properties
            var mapImage = new Dictionary<Type, Dictionary<string, string>>
            {
                { 
                    typeof(Image), 
                    new Dictionary<string, string>
                    {
                        {"Title", "title"}                    
                    }
                }
            };
            var settingsImage = new JsonSerializerSettings
            {
                ContractResolver = new DynamicMappingResolver(mapImage)
            };

            // Getting images for pages
            foreach (var page in _pages)
            {
                // Coonecting to Wikipedia API (query for images)
                url = "https://en.wikipedia.org/w/api.php?action=query&prop=images&pageids=" + page.ID + "&format=json";
                json = client.DownloadString(url);

                // Parse Json for images
                o = JObject.Parse(json);
                doc = (JContainer)o["query"]["pages"][page.ID.ToString()]["images"];

                // Deserializing image collection
                page.Images = new List<Image>();
                if (doc != null)
                {
                    page.Images = JsonConvert.DeserializeObject<List<Image>>(doc.ToString(), settingsPage);
                }

                // Setting page ID for images
                foreach (var image in page.Images)
                {
                    image.PageID = page.ID;
                }
            }
        }
    }
}
