using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;


namespace ContosoCrafts.WebSite.Pages.TravelTipsProduct
{
    public class DeleteTravelTipModel : PageModel
    {
        // accesses travel tips data from the database
        public JsonFileTravelTipService TravelTipService { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="travelTipService">Set to TravelTipService</param>
        public DeleteTravelTipModel(JsonFileTravelTipService travelTipService)
        {
            TravelTipService = travelTipService; 
        }

        // the data to show
        [BindProperty]
        public TravelTipsModel TravelTip { get; set; }

        /// <summary>
        /// REST GET request
        /// </summary>
        /// <param name="id">The id of the travel tip to delete</param>
        public void OnGet(string id)
        {
            TravelTip = ReadData(id);
        }

        /// <summary>
        /// Return the travel tip matching a given ID
        /// </summary>
        /// <param name="id">The travel tip ID</param>
        /// <returns>TravelTipsModel object for the given city, or null if not found</returns>
        public TravelTipsModel ReadData(string id)
        {
            return TravelTipService.GetAllData().FirstOrDefault(x => x.Id.Equals(id));
        }

		/// <summary>
        /// Delete the data for this travel tip
        /// </summary>
		public IActionResult OnPost()
		{
            if (!ModelState.IsValid)
            {
    			return Page();
            }

            TravelTipService.DeleteData(TravelTip.Id);
            return RedirectToPage("./TravelTips");
		}
	}
}
