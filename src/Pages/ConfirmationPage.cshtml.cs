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
        /// <summary>
        /// Initializer constructor
        /// </summary>
        /// <param name="productService">Set to ProductService</param>
        public ConfirmationPageModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // Service for getting data from database
        public JsonFileProductService ProductService { get; }

   
        // The data to show
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST get request
        /// </summary>
        /// <param name="id">ID of the city to be displayed</param>!
        public void OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
