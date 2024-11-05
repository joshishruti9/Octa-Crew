using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages.Product
{
    /// <summary>
    /// Model for the Update page allows user to update values in the database
    /// </summary>
    public class UpdateModel : PageModel
    {
        // Data #middletier
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService">Set to ProductService</param>
        public UpdateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        /// <summary>
        /// The data which is to show, is to be binded for the post method
        /// </summary>
        /// 
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// Handles HTTP GET requests to retrieve a product by its ID.
        /// Finds the first product in the data source that matches the given ID
        /// and assigns it to the Product property. If no match is found, Product will be null.
        /// </summary>
        /// <param name="id">The city id taken from the update page</param>
        public void OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));
        }

        /// <summary>
        /// Post the model back to the page. The model is in the class variable.
        /// </summary>
        public IActionResult OnPost()
        {
            if (ModelState.IsValid==false)
            {
                return Page();
            }

            ProductService.UpdateData(Product);
            return RedirectToPage("./Index");
        }
    }
}