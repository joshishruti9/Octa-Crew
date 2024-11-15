using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.TravelTipsProduct;
using ContosoCrafts.WebSite.Services;
using NUnit.Framework;

namespace UnitTests.Pages.TravelTipsProduct
{
    /// <summary>
    /// Unit testing class for the create page model for travel tips
    /// </summary>
    class CreateTravelTipTests
    {
        #region TestSetup

        // page model for the CRUDi CreateTravelTip page
        public static CreateTravelTipModel pageModel;

        // TravelTipsModel object with default values filled in
        public static TravelTipsModel defaultModel;

        // mock service for the travel tips database
        public static JsonFileTravelTipService TravelTipService;

        /// <summary>
		/// Called before each test is called.
		/// Sets up necessary test context or variables
		/// </summary>
        [SetUp]
        public void Setup()
        {
            TravelTipService = TestHelper.TravelTipService;
            pageModel = new CreateTravelTipModel(TravelTipService);
            defaultModel = new TravelTipsModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = null,
                Description = null
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test that OnGet correctly sets the page's pageModel values to the defaults
        /// </summary>
        [Test]
        public void OnGet_Valid_Default_Should_Set_Default_Values()
        {
            // Arrange
            var data = defaultModel;

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual(data.Title, defaultModel.Title);
            Assert.AreEqual(data.Description, defaultModel.Description);
        }

        #endregion OnGet
    }
}
