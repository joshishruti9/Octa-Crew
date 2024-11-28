using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Unit testing class for Read page model
    /// </summary>
    public class ReadTests
    {
        #region TestSetup

        // Page model for the CRUDi Read page
        public static ReadModel pageModel;

        /// <summary>
        /// Called before each test is called.
        /// Sets up necessary test context or variables
        /// </summary>
        [SetUp]
        public void Setup()
        {
            pageModel = new ReadModel(TestHelper.ProductService);
        }

        #endregion TestSetup

        #region ReadData

        /// <summary>
        /// Test for correct output when null id is passed
        /// </summary>
        [Test]
        public void ReadData_NullId_Default_Should_Return_Null()
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
        public void OnGet_Null_Id_Default_Should_Return_Null()
        {
            // Arrange

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
            var result = pageModel.OnGet("unitedstates");

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
        public void OnGet_Valid_Id_Default_Should_Return_Null()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("paris");

            // Assert
            Assert.IsNotNull(pageModel.Product);
            Assert.AreEqual("Paris", pageModel.Product.Title);
            Assert.AreEqual(typeof(PageResult), result.GetType());
        }

        #endregion Onget
    }
}