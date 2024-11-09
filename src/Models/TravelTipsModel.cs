using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.Models
{
	/// <summary>
	/// Model representing a travel tip
	/// </summary>
	public class TravelTipsModel
	{
		// Id of the tip
		public string Id { get; set; }

		// Title of tip
		[Required(ErrorMessage = "Title must not be empty")]
		[StringLength (maximumLength: 100, 
			ErrorMessage = "The Title should have a length less than {1} characters")]
		public string Title { get; set; }

		// Description of tip
		public string Description { get; set; }
	}
}