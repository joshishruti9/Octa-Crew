using System.Text.Json;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
    // enum to restrict values in BestSeason
    public enum Season
    {
        Spring,
        Summer,
        Fall,
        Winter
    }

    public class ProductModel
    {
        public string Id { get; set; }

        [JsonPropertyName("img")]
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Season BestSeason { get; set; }
        public string Currency { get; set; }
        public string TimeZone { get; set; }
        public string[] Attractions { get; set; }
        public int[] Ratings { get; set; }

        public override string ToString() => JsonSerializer.Serialize<ProductModel>(this);

 
    }
}