using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Confirmation Model for Delete Confirmation page
    /// </summary>
    public class ConfirmationPageModel : PageModel
    {
        // Service for getting data from database
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Initializer constructor
        /// </summary>
        /// <param name="productService">Set to ProductService</param>
        public ConfirmationPageModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

    }
}
