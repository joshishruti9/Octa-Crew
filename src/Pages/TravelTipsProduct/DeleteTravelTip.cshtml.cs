using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;


namespace ContosoCrafts.WebSite.Pages.TravelTipsProduct
{
    public class DeleteTravelTipModel : PageModel
    {
        public JsonFileTravelTipService TravelTipService { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="travelTipService">Set to TravelTipService</param>
        public DeleteTravelTipModel(JsonFileTravelTipService travelTipService)
        {
            TravelTipService = travelTipService; 
        }

    }
}
