namespace ContosoCrafts.WebSite.Models
{
	/// <summary>
	/// Model representing a travel tip
	/// </summary>
	public class TravelTipsModel
	{
		// Id of the tip
		public int Id { get; set; }
		
		// Title of tip
		public string Title { get; set; }

		// Description of tip
		public string Description { get; set; }
	}
}