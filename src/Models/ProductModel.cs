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
        [StringLength(
            maximumLength: 5000, ErrorMessage = "The Description should have a length of less than {1}"
        )]
        public string Description { get; set; }

        // Best season to visit city (spring, summer, fall, or winter)
        public Season? BestSeason { get; set; }

        // Which currency is used in the city
        [StringLength(
            maximumLength: 3,
            MinimumLength = 3,
            ErrorMessage = "The Currency should have a length of 3"
        )]
        [RegularExpression(@"[A-Z]+$", ErrorMessage = "Currency must be in all caps")]
        public string Currency { get; set; }

        // Which time zone the city is in (format is GMT+/-X)
        [StringLength(
            maximumLength: 6,
            MinimumLength = 5,
            ErrorMessage = "Time zone must be in format \"GMT+/-__\""
        )]
        [RegularExpression(@"GMT[+-][0-9]+$", ErrorMessage = "Time zone must be in format \"GMT+/-__\"")]
        public string TimeZone { get; set; }

        // List of the top attractions in the city
        [MaxLength(10, ErrorMessage = "No more than 10 Attractions are allowed")]
        public string[] Attractions { get; set; }

        // Ratings added by users for how nice the city is to visit
        [CustomValidation(
            typeof(RatingValidation),
            nameof(RatingValidation.RatingValidate)
        )]
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