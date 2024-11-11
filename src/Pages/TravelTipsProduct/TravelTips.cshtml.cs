using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ContosoCrafts.WebSite.Pages.TravelTipsProduct
{
    /// <summary>
    /// Model for TravelTips page
    /// </summary>
    public class TravelTipsPageModel : PageModel
    {
        /// <summary>
        /// Initializer constructor
        /// </summary>
        /// <param name="travelTipService">Set to TravelTipService</param>
        public TravelTipsPageModel(JsonFileTravelTipService travelTipService)
        {
            TravelTipService = travelTipService;
        }

        // Service for getting data from database
        public JsonFileTravelTipService TravelTipService { get; }

        // List of tips
        public IEnumerable<TravelTipsModel> TravelTips { get; private set; }

        /// <summary>
        /// Called when the page is accessed.
        /// Fills TravelTips with data.
        /// </summary>
        public void OnGet()
        {
            TravelTips = TravelTipService.GetAllData();
        }
    }
}