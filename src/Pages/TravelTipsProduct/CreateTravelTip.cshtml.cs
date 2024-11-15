using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages.TravelTipsProduct
{
    /// <summary>
    /// Model for the CreateTravelTip page.  Uses input data to add a new travel tip to the database.
    /// </summary>
    public class CreateTravelTipModel : PageModel
    {
        // Accesses travel tip data from the database
        public JsonFileTravelTipService TravelTipService { get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public CreateTravelTipModel(JsonFileTravelTipService travelTipService)
        {
            TravelTipService = travelTipService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public TravelTipsModel TravelTipsModel { get; set; }

        /// <summary>
        /// REST Get request initializes the data
        /// </summary>
        public void OnGet()
        {
            TravelTipsModel = TravelTipService.CreateData();
        }
    }
}
