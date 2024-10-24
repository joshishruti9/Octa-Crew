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
    public class IndexPageModel : PageModel
    {
        // Keeps logs for IndexModel
        private readonly ILogger<IndexPageModel> _logger;

        /// <summary>
        /// Initializer constructor
        /// </summary>
        /// <param name="logger">Set to _logger</param>
        /// <param name="productService">Set to ProductService</param>
        public IndexPageModel(ILogger<IndexPageModel> logger,
            JsonFileProductService productService)
        {
            _logger = logger;
            ProductService = productService;
        }

        // Service for getting data from database
        public JsonFileProductService ProductService { get; }
        
        // List of city titles
        public IEnumerable<string> titles { get; private set; }

        // List of cities and their data
        public IEnumerable<ProductModel> Products { get; set; }

        /// <summary>
        /// Fills Products with data when page is accessed
        /// </summary>
        public void OnGet()
        {
            Products = ProductService.GetAllData();
        }
    }
}