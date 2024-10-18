using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections;
using System.Linq;

namespace ContosoCrafts.WebSite.Pages
{
    public class ReadModel : PageModel
    {
        public JsonFileProductService ProductService { get; }

        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="productService"></param>
        public ReadModel(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        // The data to show
        public ProductModel Product;

        /// <summary>
        /// REST get request
        /// </summary>
        /// <param name="id"></param>
        public void OnGet(string id)
        {
            Product = ReadData(id);
        }

        /// <summary>
        /// Return the city matching a given ID
        /// </summary>
        /// <param name="id">The city ID</param>
        /// <returns></returns>
        private ProductModel ReadData(string id)
        {
            return ProductService.GetProducts().FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}
