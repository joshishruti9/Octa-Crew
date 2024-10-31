using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoCrafts.WebSite.Pages
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

		/// <summary>
		/// Called when the page is accessed
		/// </summary>
		public void OnGet()
        {
        }
    }
}
