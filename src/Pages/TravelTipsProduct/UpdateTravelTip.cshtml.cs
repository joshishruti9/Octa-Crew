using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.TravelTipsProduct
{
    /// <summary>
    /// Model for the Update Travel Tip page allows user to update values for a travel tip in the travel tips database
    /// </summary>
    public class UpdateTravelTipModel : PageModel
    {
        // Data middletier
        public JsonFileTravelTipService TravelTipService { get; }
        
        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="travelTipService">Service for working with database</param>
        public UpdateTravelTipModel(JsonFileTravelTipService travelTipService)
        {
            TravelTipService = travelTipService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public TravelTipsModel TravelTip { get; set; }

        /// <summary>
        /// Called when the page is accessed
        /// </summary>
        public void OnGet()
        {
        }
    }
}