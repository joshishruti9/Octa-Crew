using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.TravelTipsProduct;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        #region OnPost

        /// <summary>
        /// Test that a city is not added to the database if the ModelState is invalid
        /// </summary>
        [Test]
        public void OnPost_InValid_Invalid_ModelState_Should_Not_Add_Travel_Tip()
        {
            // Arrange
            pageModel.ModelState.AddModelError("Title", "Invalid title");

            // number of travel tips in the database before calling OnPost
            var countOriginal = TravelTipService.GetAllData().Count();

            // Act
            var result = pageModel.OnPost();

            // Assert
            Assert.AreEqual(true, result.GetType().Equals(typeof(PageResult)));
            Assert.AreEqual(countOriginal, TravelTipService.GetAllData().Count());
        }


        /// <summary>
        /// Test that OnPost successfully adds a city to the database when custom 
        /// values are passed in.
        /// </summary>
        [Test]
        public void OnPost_Valid_Custom_Should_Add_Travel_Tip()
        {
            // Arrange
            pageModel.PageModel = new TravelTipsModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Title = "New Title",
                Description = "New Description"
            };

            // the TravelTipsModel for the page
            var data = pageModel.PageModel;

            // travel tips in the database before calling OnPost
            var dataOriginalList = TravelTipService.GetAllData();

            // Act
            var result = pageModel.OnPost();

            // the travel tips in the database after calling OnPost
            var dataNewList = TravelTipService.GetAllData();

            // the new travel tip added by OnPost
            var newTravelTip = TravelTipService.GetAllData().First(x => x.Id.Equals(data.Id));

            // Reset
            TravelTipService.SaveData(dataOriginalList);

            // Assert
            Assert.AreEqual(dataOriginalList.Count() + 1, dataNewList.Count());
            Assert.AreEqual(true, data.ToString().Equals(newTravelTip.ToString()));
            Assert.AreEqual(true, TestHelper.ModelState.IsValid);
            Assert.AreEqual("./TravelTips", (result as RedirectToPageResult).PageName);
        }

        #endregion OnPost
    }
}
