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

        // Google API key used to embed Map to page
        public static readonly string APIKey = "AIzaSyA0PCl4rxWU8CKfKQcPxPZELqmm0D0xh_I";

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService">Set to ProductService</param>
        public MapModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // the model from which to pull the city name
        public ProductModel Product;

        /// <summary>
        /// REST get request
        /// </summary>
        /// <param name="id">ID of the city to be shown</param>
        /// <returns>Redirect to the index page if city is not found or a PageResult otherwise</returns>
        public IActionResult OnGet(string id)
        {
            Product = ReadData(id);

            if (Product == null)
            {
                return RedirectToPage("/Error", new { message = "City was not found" });
            }

            return Page();
        }

        /// <summary>
        /// Return the city matching a given ID
        /// </summary>
        /// <param name="id">The city ID</param>
        /// <returns>ProductModel object for the given city, or null if not found</returns>
        public ProductModel ReadData(string id)
        {
            return ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(id));
        }

    }

}
