using NUnit.Framework;
using System.Linq;
using ContosoCrafts.WebSite.Pages.TravelTipsProduct;

namespace UnitTests.Pages.TravelTipsProduct
{
    /// <summary>
    /// Unit testing class for TravelTips page model
    /// </summary>
    public class TravelTipsTests
    {
        #region TestSetup

        // page model for the travel tips page
        public static TravelTipsPageModel pageModel;

        /// <summary>
        /// Called before each test is called.
        /// Sets up necessary test context or variables
        /// </summary>
        [SetUp]
        public void Setup()
        {
            pageModel = new TravelTipsPageModel(TestHelper.TravelTipService);
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test that OnGet populates the list of Travel Tips when the database contains valid data
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Have_Valid_State()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(true, pageModel.TravelTips.ToList().Any());
        }

        #endregion OnGet
    }
}