using ContosoCrafts.WebSite.Controllers;
using ContosoCrafts.WebSite.Pages.Product;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;

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

        public JsonFileProductService ProductService;
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


    }

}
