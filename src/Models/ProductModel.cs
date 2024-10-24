using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    /// <summary>
    /// enum to restrict values in BestSeason
    /// </summary>
    public enum Season
    {
        Spring = 0,
        Summer = 1,
        Fall = 2,
        Winter = 3
    }

    /// <summary>
    /// Model representing a city
    /// </summary>
    public class ProductModel
    {
        // ID for the city
        public string Id { get; set; }

        // Array of image URLs for the city
        [JsonPropertyName("imgs")]
        public string[] Images { get; set; }
        
        // Name of the city
        public string Title { get; set; }
        
        // Description about the city
        public string Description { get; set; }
        
        // Best season to visit city (spring, summer, fall, or winter)
        public Season? BestSeason { get; set; }
        
        // Which currency is used in the city
        public string Currency { get; set; }
        
        // Which time zone the city is in (format is GMT+/-X)
        public string TimeZone { get; set; }
        
        // List of the top attractions in the city
        public string[] Attractions { get; set; }
        
        // Ratings added by users for how nice the city is to visit
        public int[] Ratings { get; set; }

        /// <summary>
        /// Represents the ProductModel as a json string
        /// </summary>
        /// <returns>A JSON string representation of ProductModel</returns>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

 
    }
}