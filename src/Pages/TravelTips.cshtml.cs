using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages
{
	/// <summary>
	/// Model for TravelTips page
	/// </summary>
	public class TravelTipsModel : PageModel
	{
		// Service for getting data from database
		public JsonFileTravelTipService TravelTipService { get; }

		/// <summary>
		/// Called when the page is accessed
		/// </summary>
		public void OnGet()
		{

		}
	}
}
