using ContosoCrafts.WebSite.ValidationAttributes;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        [Required(ErrorMessage = "Image URLs are required")]
        [MinLength(3, ErrorMessage = "3 Image URLs are required")]
        [MaxLength(3, ErrorMessage = "No more than 3 Image URLs are allowed")]
        [CustomValidation(
            typeof(ImageURLValidation),
            nameof(ImageURLValidation.ImageURLValidate)
        )]
        public string[] Images { get; set; }

        // Name of the city
        [Required(ErrorMessage = "Title is required")]
        [StringLength(
            maximumLength: 33, MinimumLength = 1, ErrorMessage = "The Title should have a length of more than {2} and less than {1}"
        )]
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

        // The dollar amount a typical 1-week visit would cost in this city
        public int Cost { get; set; }
        
        // The time it takes to travel to the city from Seattle in hours
        public double TravelTime { get; set; }

        /// <summary>
        /// Represents the ProductModel as a json string
        /// </summary>
        /// <returns>A JSON string representation of ProductModel</returns>
        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

        /// <summary>
        /// Gets the average rating of the city
        /// </summary>
        /// <returns>The average of all the ratings added to the city</returns>
        public int GetCityRating()
        {
            if (Ratings == null)
            {
                return 0;
            }

            return Ratings.Sum() / Ratings.Count();
        }
    }
}