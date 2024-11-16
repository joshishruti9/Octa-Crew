using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Model for the Map page.
    /// </summary>
    public class MapModel : PageModel
    {
        // Accesses city data from database
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService">Set to ProductService</param>
        public MapModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public void OnGet()
        {

        }
    }
}
