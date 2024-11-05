using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitTests.Pages
{
	/// <summary>
	/// Unit testing class for Delete page model
	/// </summary>
	public class DeleteTests
	{

        #region TestSetup

        public static DeleteModel pageModel;
        public JsonFileProductService ProductService;

        /// <summary>
        /// Called before each test is called.
        /// Sets up necessary test context or variables
        /// </summary>
        [SetUp]
        public void Setup()
        {
            // Use a mock or test helper for ProductService
            ProductService = TestHelper.ProductService;
            pageModel = new DeleteModel(ProductService);
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test that no product is assigned when null id is passed
        /// </summary>
        [Test]
        public void OnGet_Null_Id_Default_Should_Return_Null()
        {
            // Act
            pageModel.OnGet(null);

            // Assert
            Assert.IsNull(pageModel.Product);
        }

        /// <summary>
        /// Test that no product is assigned when invalid id is passed
        /// </summary>
        [Test]
        public void OnGet_Invalid_Id_Default_Should_Return_Null()
        {
            // Act
            pageModel.OnGet("nonexistent-id");

            // Assert
            Assert.IsNull(pageModel.Product);
        }

        /// <summary>
        /// Test that correct product is assigned when valid id is passed
        /// </summary>
        [Test]
        public void OnGet_Valid_Id_Default_Should_Assign_Product()
        {
            // Act
            pageModel.OnGet("paris");

            // Assert
            Assert.IsNotNull(pageModel.Product);
            Assert.AreEqual("Paris", pageModel.Product.Title);
        }

        #endregion OnGet

        #region OnPost

        /// <summary>
        /// Test OnPost method to ensure it redirects to Index when ModelState is valid.
        /// </summary>
        [Test]
        public void OnPost_Valid_Model_State_Should_RedirectToIndex()
        {
            // Arrange
            pageModel.Product = new ProductModel { Id = "Paris", Title = "Paris(Test)" };

            // Act
            var result = pageModel.OnPost("Paris");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToPageResult>(result);

            var redirectResult = result as RedirectToPageResult;
            Assert.AreEqual("./IndexPage", redirectResult.PageName);
        }

        #endregion OnPost

    }
}