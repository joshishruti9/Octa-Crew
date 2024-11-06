using System.Linq;

using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages
{
    /// <summary>
    /// Unit testing class for Cities page model
    /// </summary>
    public class CitiesTests
    {
        #region TestSetup

        // page model for the Cites page
        public  CitiesModel pageModel;

        /// <summary>
        /// Called before each test is called.
        /// Sets up necessary test context or variables
        /// </summary>
        [SetUp]
        public void Setup()
        {
            pageModel = new CitiesModel(TestHelper.ProductService);
        }

        #endregion TestSetup

        #region OnGet

        [Test]
        public void OnGet_Valid_Default_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }

        #endregion OnGet
    }
}
