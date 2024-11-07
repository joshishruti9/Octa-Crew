using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

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
        /// Called when the page is accessed.
        /// REST Get request loads the data
        /// </summary>
        public void OnGet(string id)
        {
            TravelTip = TravelTipService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }

        /// <summary>
        /// Post the model back to the page.
        /// The model is in the class variable.
        /// </summary>
        /// <returns>
        /// Redirects to the main travel tips page if valid
        /// (we will change this later to redirect to index page once index page is created).
        /// If not valid, returns Page()
        /// </returns>
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                TravelTipService.UpdateData(TravelTip);

                // Change to ./IndexPage when Index page is created
                return RedirectToPage("./TravelTips");
            }

            return Page();
        }
    }
}