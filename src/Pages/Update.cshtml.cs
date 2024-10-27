using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages
{
    public class UpdateModel : PageModel
    {
        // Accesses city data from database
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService">Set to ProductService</param>
        public UpdateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

         // The data to show
        public ProductModel Product;

        /// <summary>
        /// REST get request
        /// </summary>
        /// <param name="id">ID of the city to be displayed</param>
        public void OnGet(string id)
        {
            Product = ReadData(id);
        }

        /// <summary>
        /// Return the city matching a given ID
        /// </summary>
        /// <param name="id">The city ID</param>
        /// <returns>ProductModel object for the given city, or null if not found</returns>
        public ProductModel ReadData(string id)
        {
            return ProductService.GetProducts().First(x => x.Id.Equals(id));
        }
    }
}
