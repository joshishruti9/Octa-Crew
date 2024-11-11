using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Unit testing class for Update page model
    /// </summary>
    public class UpdateTests
    {
        #region TestSetup

        // page model for the Update page 
        public static UpdateModel pageModel;

        // service for managing interactions with the cities database
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
            pageModel = new UpdateModel(ProductService)
            {
                Product = new ProductModel()
            };
        }

        #endregion TestSetup

        #region ReadData

        /// <summary>
        /// Test for correct output when null id is passed
        /// </summary>


        /// <summary>
        /// Test for correct output when invalid id is passed
        /// </summary>

        /// <summary>
        /// Test for correct output when a valid id is passed
        /// </summary>

        #endregion ReadData

        #region OnGet

        /// <summary>
        /// Test that no product is assigned and RedirectToPageResult is returned
        /// when null id is passed
        /// </summary>
        [Test]
        public void OnGet_Null_Id_Default_Should_Return_Null()
        {
            // Act
            var result = pageModel.OnGet(null);

            // Assert
            Assert.AreEqual(null, pageModel.Product);
            Assert.AreEqual(typeof(RedirectToPageResult), result.GetType());
            Assert.AreEqual("./IndexPage", (result as RedirectToPageResult).PageName);
        }

        /// <summary>
        /// Test that no product is assigned and RedirectToPageResult is returned
        /// when invalid id is passed
        /// </summary>
        [Test]
        public void OnGet_Invalid_Id_Default_Should_Return_Null()
        {
            // Arrange 

            // Act
            var result = pageModel.OnGet("nonexistent-id");

            // Assert
            Assert.AreEqual(null, pageModel.Product);
            Assert.AreEqual(typeof(RedirectToPageResult), result.GetType());
            Assert.AreEqual("./IndexPage", (result as RedirectToPageResult).PageName);
        }

        /// <summary>
        /// Test that correct product is assigned when valid id is passed
        /// and that the page is returned
        /// </summary>
        [Test]
        public void OnGet_Valid_Id_Default_Should_Assign_Product()
        {
            // Act
            var result = pageModel.OnGet("paris");

            // Assert
            Assert.IsNotNull(pageModel.Product);
            Assert.AreEqual("Paris", pageModel.Product.Title);
            Assert.AreEqual(typeof(PageResult), result.GetType());
        }

        #endregion OnGet

        #region OnPost


        /// <summary>
        /// Test OnPost method to ensure it redirects to Index when ModelState is valid.
        /// </summary>
        [Test]
        public void OnPost_ValidModelState_Should_RedirectTo_Index()
        {
            // Arrange
            pageModel.Product = new ProductModel { Id = "Paris", Title = "Paris(Test)" };

            // Act
            var result = pageModel.OnPost();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<RedirectToPageResult>(result);

            // attempt to cast the value returned by OnPost to a RedirectToPageResult
            var redirectResult = result as RedirectToPageResult;

            Assert.AreEqual("./Read", redirectResult.PageName);
        }

        /// <summary>
        /// Test OnPost method when ModelState is invalid, should return PageResult
        /// </summary>
        [Test]

        /// <summary>
        /// Test OnPost method when ModelState is invalid
        /// </summary>

        public void OnPost_Invalid_ModelState_Should_Return_PageResult()
        {
            // Arrange
            pageModel.ModelState.AddModelError("error", "Model state is invalid");

            // Act
            var result = pageModel.OnPost() as PageResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<PageResult>(result);
        }

        #endregion OnPost
    }
}
