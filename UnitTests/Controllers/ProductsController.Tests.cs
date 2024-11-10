using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

using static ContosoCrafts.WebSite.Controllers.ProductsController;
using System.Linq;

namespace UnitTests.Controllers
{
    /// <summary>
    /// Unit test class for the Products Controller
    /// </summary>
    public class ProductsControllerTests
    {
        #region TestSetup

        // the service handling city data
        public JsonFileProductService ProductService;

        // the controller managing API calls on cities database
        public ProductsController ProductsController;

        /// <summary>
        /// Called before each test is called.
        /// Sets up necessary test context or variables
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Use a mock or test helper for ProductService
            ProductService = TestHelper.ProductService;
            ProductsController = new ProductsController(ProductService);
        }

        #endregion TestSetup

        #region Get

        /// <summary>
        /// Test that Get correctly gets all Product from database
        /// </summary>
        [Test]
        public void Get_Valid_Request_Should_Return_AllProducts()
        {
            //Arrange
            var actualProducts = ProductService.GetAllData();
            // Act
            var result = ProductsController.Get();

            // Assert  
            Assert.AreEqual(result.ToList().Count, actualProducts.ToList().Count);
        }
        #endregion Get

        #region Patch

        /// <summary>
        /// Test that Patch send ok response after adding rating to product
        /// </summary>
        [Test]
        public void Patch_Valid_Request_Should_Return_HTTP_Status_Ok()
        {
            //Arrange 
            RatingRequest ratingRequest = new RatingRequest();
            ratingRequest.ProductId = "Paris";
            ratingRequest.Rating = 5;

            // Act
            var result = ProductsController.Patch(ratingRequest);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(typeof(OkResult), result.GetType());
        }
        #endregion Patch
    }

}