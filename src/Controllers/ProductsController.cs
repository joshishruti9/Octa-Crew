using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace ContosoCrafts.WebSite.Controllers
{
    /// <summary>
    ///     API controller for operations on products
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        /// <summary>
        ///     Initializes a new instance of ProductsController class
        /// </summary>
        /// <param name="productService">Service that handles data operations</param>
        public ProductsController(JsonFileProductService productService)
        {
            // Set ProductService equal to the productService provided
            ProductService = productService;
        }

        /// <summary>
        ///     Gets the instance of the JsonFileProductService to interact with data
        /// </summary>
        public JsonFileProductService ProductService { get; }

        /// <summary>
        ///     Gets all data from database
        /// </summary>
        /// <returns>
        ///     A collection of ProductModel objects representing all data in database
        /// </returns>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return ProductService.GetAllData();
        }

        /// <summary>
        ///     Updates the rating for a specified city
        /// </summary>
        /// <param name="request">
        ///     The rating request containing the product ID and the new rating to be applied
        /// </param>
        /// <returns>Returns OK if the rating was successfully added</returns>
        [HttpPatch]
        public ActionResult Patch([FromBody] RatingRequest request)
        {
            ProductService.AddRating(request.ProductId, request.Rating);
            
            return Ok();
        }

        /// <summary>
        /// Represents the data required for a rating update request
        /// </summary>
        public class RatingRequest
        {
            /// <summary>
            /// Gets or sets the ID of the city to be rated
            /// </summary>
            public string ProductId { get; set; }

            /// <summary>
            /// Gets or sets the rating value to be added to the city
            /// </summary>
            public int Rating { get; set; }
        }
    }
}