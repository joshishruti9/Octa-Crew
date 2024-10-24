using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Model for cities page
    /// </summary>
    public class IndexModel : PageModel
    {
        // Keeps logs for IndexModel
        private readonly ILogger<IndexModel> _logger;

        /// <summary>
        /// Initializer constructor
        /// </summary>
        /// <param name="logger">Set to _logger</param>
        /// <param name="productService">Set to ProductService</param>
        public IndexModel(ILogger<IndexModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
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
            Products = ProductService.GetProducts();
        }
    }
}