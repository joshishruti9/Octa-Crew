using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.TravelTipsProduct;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Pages.TravelTipsProduct
{
    /// <summary>
    /// Unit testing class for the delete page model for travel tips
    /// </summary>
    class DeleteTravelTip
    {
		#region TestSetup

		// page model for the CRUDi travel tips delete page
		public static DeleteTravelTipModel pageModel;

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
            pageModel = new DeleteTravelTipModel(TravelTipService);
        }

		#endregion TestSetup

		#region ReadData

		/// <summary>
		/// Test for correct output when null id is passed
		/// </summary>
		[Test]
		public void ReadData_Null_Id_Default_Should_Return_Null()
		{
			// Arrange

			// Act

			// the model matching the id
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

			// the model matching the id
			var result = pageModel.ReadData("invalid_id");

			// Assert
			Assert.AreEqual(null, result);
		}

		/// <summary>
		/// Test for correct output when a valid id is passed
		/// </summary>
		[Test]
		public void ReadData_Valid_Id_Default_Should_Return_Tip()
		{
			// Arrange

			// Act

			// the model matching the id
			var result = pageModel.ReadData("1");

			// Assert
			Assert.AreEqual("1", result.Id);
		}

		#endregion ReadData

		#region OnGet

		/// <summary>
		/// Test that no travel tip is assigned when null id is passed
		/// </summary>
		[Test]
		public void OnGet_Null_Id_Default_Should_Return_Null()
		{
			// Arrange

			// Act
			pageModel.OnGet(null);

			// Assert
			Assert.AreEqual(null, pageModel.TravelTip);
		}

		/// <summary>
		/// Test that no product is assigned when invalid id is passed
		/// </summary>
		[Test]
		public void OnGet_Invalid_Id_Default_Should_Return_Null()
		{
			// Arrange

			// Act
			pageModel.OnGet("invalid_id");

			// Assert
			Assert.AreEqual(null, pageModel.TravelTip);
		}

		/// <summary>
		/// Test that correct product is assigned when valid id is passed
		/// </summary>
		[Test]
		public void OnGet_Valid_Id_Default_Should_Return_Null()
		{
			// Arrange

			// the expected TravelTipsModel assigned to the DeleteTravelTip page
			var expected = TestHelper.TravelTipService.GetAllData().First(x => x.Id == "1");

			// Act
			pageModel.OnGet("1");

			// Assert
			Assert.AreEqual(expected.Id, pageModel.TravelTip.Id);
			Assert.AreEqual(expected.Title, pageModel.TravelTip.Title);
			Assert.AreEqual(expected.Description, pageModel.TravelTip.Description);
		}

		#endregion OnGet

		#region OnPost

		/// <summary>
		/// Test that delete refreshes the page when there is a model error
		/// </summary>
		[Test]
		public void OnPost_Invalid_Model_State_Should_Redirect_To_Travel_Tips()
		{
			// Arrange
			pageModel.TravelTip = new TravelTipsModel
			{
				Id = "1"
			};
			pageModel.ModelState.AddModelError("Id", "Error");

			// Act
			var result = pageModel.OnPost() as PageResult;

			// Assert
			Assert.AreEqual(typeof(PageResult), result.GetType());
		}

		/// <summary>
		/// Test that travel is successfully deleted when model state is valid
		/// and that user is redirected to travel tips page
		/// </summary>
		[Test]
		public void OnPost_Valid_Model_State_Should_Redirect_To_Travel_Tips()
		{
			// Arrange

			// retrieve all the records in the travel tips database
			var data = TravelTipService.GetAllData();

			pageModel.TravelTip = new TravelTipsModel
			{
				Id = "1"
			};

			// Act
			var result = pageModel.OnPost() as RedirectToPageResult;

			// attempt to retrieve the deleted travel tip
			var newData = TravelTipService.GetAllData().FirstOrDefault(x => x.Id == "1");

			// Reset
			TravelTipService.SaveData(data);

			// Assert
			Assert.AreEqual(true, result != null);
			Assert.AreEqual("./TravelTips", result.PageName);
			Assert.AreEqual(null, newData);
		}

		#endregion OnPost
	}
}
