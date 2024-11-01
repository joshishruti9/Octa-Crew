using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Model for cities page
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Initializer constructor
        /// </summary>
        /// <param name="productService">Set to ProductService</param>
        public IndexModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // Service for getting data from database
        public JsonFileProductService ProductService { get; }
        
        // List of cities and their data
        public IEnumerable<ProductModel> Products { get; private set; }

        /// <summary>
        /// Fills Products with data when page is accessed
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}