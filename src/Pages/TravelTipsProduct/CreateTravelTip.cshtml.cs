using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

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
        public TravelTipsModel PageModel { get; set; }

        /// <summary>
        /// REST Get request initializes the data
        /// </summary>
        public void OnGet()
        {
            PageModel = TravelTipService.CreateData();
        }

        /// <summary>
        /// REST Post request saves the filled in data to the database
        /// </summary>
        /// <returns>The result of the Post request</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // the set of travel tips in the database
            var dataSet = TravelTipService.GetAllData();

            dataSet.Append(PageModel);

            TravelTipService.SaveData(dataSet);

            return RedirectToPage("./TravelTips");
        }
    }
}
