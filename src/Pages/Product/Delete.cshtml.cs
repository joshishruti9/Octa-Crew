using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages.Product
{

    /// <summary>
    /// Model for Delete CRUDi page
    /// </summary>
    public class DeleteModel : PageModel
    {

        // Data #middletier
        public JsonFileProductService ProductService { get; }

        /// <summary> Default Constructor </summary>
        public DeleteModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// Called when the page is accessed
        /// </summary>
        /// <param name="id">id of the city</param>
        /// <returns>Redirect to the index page if city is not found or a PageResult otherwise</returns>
        public IActionResult OnGet(string id)
        {
            Product = ProductService.GetAllData().FirstOrDefault(m => m.Id.Equals(id));

            if (Product == null)
            {
                return RedirectToPage("/Error", new { message = "City was not found" });
            }

            return Page();
        }

        /// <summary> Delete the data for given id</summary>
        public IActionResult OnPost(string id)
        {
            if (ModelState.IsValid)
            {
                ProductService.DeleteData(id);
                return RedirectToPage("./IndexPage");
            }

            return Page();

        }

    }

}