
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.TravelTipsProduct;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using System;
using System.Data;
using System.Linq;

namespace UnitTests.Pages.TravelTipsProduct
{
	
	/// <summary>
	/// Unit testing class for Update page model for Travel Tips
	/// </summary>
	public class UpdateTravelTipTests
	{
		#region TestSetup

		// Model for Update page for TravelTip
		public static UpdateTravelTipModel pageModel;

		// Service for accessing and modifying data in database
		public JsonFileTravelTipService TravelTipService;

		/// <summary>
		/// Called before each test is called.
		/// Sets up necessary test context or variables
		/// </summary>
		[SetUp]
		public void Setup()
		{
			// Use a mock or test helper for TravelTipService
			TravelTipService = TestHelper.TravelTipService;
			pageModel = new UpdateTravelTipModel(TravelTipService)
			{
				TravelTip = new TravelTipsModel()
			};
		}

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test that no travel tip is assigned and RedirectToPageResult is returned
        /// when null id is passed
        /// </summary>
        [Test]
		public void OnGet_Null_Id_Default_Should_Return_Null()
		{
			// Arrange
			
			// Act
			var result = pageModel.OnGet(null);

            // Reset

            // Assert
            Assert.AreEqual(null, pageModel.TravelTip);
            Assert.AreEqual(typeof(RedirectToPageResult), result.GetType());
            Assert.AreEqual("./TravelTips", (result as RedirectToPageResult).PageName);
        }

        /// <summary>
        /// Test that no travel tip is assigned and RedirectToPageResult is returned
        /// when invalid id is passed
        /// </summary>
        [Test]
        public void OnGet_Invalid_Id_Default_Should_Return_Null()
        {
            // Arrange

            // Act
            var result = pageModel.OnGet("invalid_id");

            // Reset

            // Assert
            Assert.AreEqual(null, pageModel.TravelTip);
            Assert.AreEqual(typeof(RedirectToPageResult), result.GetType());
            Assert.AreEqual("./TravelTips", (result as RedirectToPageResult).PageName);
        }

        /// <summary>
        /// Test that correct travel tip is assigned when valid id is passed
        /// and that the page is returned
        /// </summary>
        [Test]
		public void OnGet_Valid_Id_Default_Should_Assign_TravelTip()
		{
			// Arrange
			var data = TravelTipService.CreateData();
			TravelTipService.SaveData(TravelTipService.GetAllData().Append(data));

			// Act
			var result = pageModel.OnGet(data.Id);

			// Reset

			// Assert
			Assert.AreEqual(data.Id, pageModel.TravelTip.Id);
            Assert.AreEqual(typeof(PageResult), result.GetType());
        }

		#endregion OnGet

		#region OnPost

		/// <summary>
		/// Test OnPost method to ensure it redirects to Index when ModelState is valid.
		/// (Index has not yet been created, so for now we are testing for a redirect to ./TravelTips.
		/// When Index has been created, update this test.)
		/// </summary>
		[Test]
		public void OnPost_ValidModelState_Should_RedirectTo_Index()
        {
			// Arrange
			pageModel.TravelTip = new TravelTipsModel
			{ 
				Id = System.Guid.NewGuid().ToString(),
				Title = "Test Travel Tip" 
			};

			// Act
			var result = pageModel.OnPost() as RedirectToPageResult;

			// Reset

			// Assert
			Assert.AreEqual("./TravelTips", result.PageName);
		}

		/// <summary>
		/// Test OnPost method when ModelState is invalid, should return PageResult
		/// </summary>
		[Test]
		public void OnPost_Invalid_ModelState_Should_Return_PageResult()
		{
			// Arrange
			pageModel.ModelState.AddModelError("error", "Model state is invalid");

			// Act
			var result = pageModel.OnPost() as PageResult;

			// Reset

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual(typeof(PageResult), result.GetType());
		}

		#endregion OnPost
	}
}