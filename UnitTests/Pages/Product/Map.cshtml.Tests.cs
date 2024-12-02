using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bunit.Extensions;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Unit testing class for Map page model
    /// </summary>
    class MapTests
    {
        #region TestSetup

        // Page model for the Map page
        public static MapModel pageModel;

        /// <summary>
        /// Called before each test is called.
        /// Sets up necessary test context or variables
        /// </summary>
        [SetUp]
        public void Setup()
        {
            pageModel = new MapModel(TestHelper.ProductService);
        }

        #endregion TestSetup

        #region ReadData

        /// <summary>
        /// Test for correct output when null id is passed
        /// </summary>
        [Test]
        public void ReadData_Invalid_Null_Id_Should_Return_Null()
        {
            // Arrange

            // Act
            var result = pageModel.ReadData(null);

            // Assert
            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// Test for correct output when invalid id is passed
        /// </summary>
        [Test]
        public void ReadData_Invalid_Id_Default_Should_Return_Null()
        {
            // Arrange

            // Act
            var result = pageModel.ReadData("unitedstates");

            // Assert
            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// Test for correct output when a valid id is passed
        /// </summary>
        [Test]
        public void ReadData_Valid_Id_Default_Should_Return_City()
        {
            // Arrange

            // Act
            var result = pageModel.ReadData("paris");

            // Assert
            Assert.AreEqual("paris", result.Id);
        }

        #endregion ReadData

        #region OnGet

        /// <summary>
        /// Test that no product is assigned and RedirectToPageResult is returned
        /// when null id is passed
        /// </summary>
        [Test]
        public void OnGet_Invalid_Null_Id_Should_Redirect_To_Error_Page()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet(null);

            // Assert
            Assert.AreEqual(null, pageModel.Product);
            Assert.AreEqual(typeof(RedirectToPageResult), result.GetType());
            Assert.AreEqual("/Error", (result as RedirectToPageResult).PageName);
        }

        /// <summary>
        /// Test that no product is assigned and RedirectToPageResult is returned
        /// when invalid id is passed
        /// </summary>
        [Test]
        public void OnGet_Invalid_Invalid_Id_Should_Redirect_To_Error_Page()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("unitedstates");

            // Assert
            Assert.AreEqual(null, pageModel.Product);
            Assert.AreEqual(typeof(RedirectToPageResult), result.GetType());
            Assert.AreEqual("/Error", (result as RedirectToPageResult).PageName);
        }

        /// <summary>
        /// Test that correct product is assigned when valid id is passed
        /// and that the page is returned
        /// </summary>
        [Test]
        public void OnGet_Valid_Id_Default_Should_Return_City()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("paris");

            // Assert
            Assert.IsNotNull(pageModel.Product);
            Assert.AreEqual("Paris", pageModel.Product.Title);
            Assert.AreEqual(typeof(PageResult), result.GetType());
        }

        #endregion OnGet

        #region APIKey

        /// <summary>
        /// Test that the APIKey class variable is not null or empty
        /// </summary>
        [Test]
        public void APIKey_Valid_Default_Should_Not_Be_Empty()
        {
            // Arrange

            // Act
            var result = MapModel.APIKey;

            // Assert
            Assert.AreEqual(false, result.IsNullOrEmpty());
        }

        #endregion APIKey
    }
}