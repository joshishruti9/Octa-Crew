using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages.Product
{

    /// <summary>
    /// Model for the Create page.  Uses input data to add a new city to the database.
    /// </summary>
    public class CreateModel : PageModel
    {

        // Accesses city data from database
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="productService">Set to ProductService</param>
        public CreateModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show, bind to it for the post
        [BindProperty]
        public ProductModel Product { get; set; }

        /// <summary>
        /// REST Get request initializes the data
        /// </summary>
        public void OnGet()
        {
            Product = ProductService.CreateData();
        }

        /// <summary>
        /// REST Post request saves the filled in data to the database
        /// </summary>
        /// <returns>The result of the Post request</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // the set of cities in the database
            var dataSet = ProductService.GetAllData();

            dataSet = dataSet.Append(Product);

            ProductService.SaveData(dataSet);

            return RedirectToPage("./IndexPage");
        }
    }
}