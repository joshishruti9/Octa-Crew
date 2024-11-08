using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ContosoCrafts.WebSite.Models
{
	/// <summary>
	/// Model for ImageURL class to validate URLs for images
	/// </summary>
	public class ImageURLModel
	{
		// URL attribute for pointing to an image
		// Validated by Url and RegularExpression
		[JsonPropertyName("url")]
		[Required(ErrorMessage = "URL is required")]
		[Url(ErrorMessage = "Please enter a valid URL")]
		[RegularExpression(
			@".*\.(jpg|jpeg|png|gif|bmp|svg|webp)$",
			ErrorMessage = "The URL must point to an image file" +
			" (.jpg, .jpeg, .png, .gif, .bmp, .svg, or .webp)"
		)]
		public string URL { get; set; }
	}
}