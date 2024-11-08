﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.TravelTipsProduct;

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

		/// <summary>
		/// Called before each test is called.
		/// Sets up necessary test context or variables
		/// </summary>
		[SetUp]
        public void Setup()
        {
            pageModel = new DeleteTravelTipModel(TestHelper.TravelTipService);
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
			Assert.AreEqual(null, pageModel.TravelTips);
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
			Assert.AreEqual(null, pageModel.TravelTips);
		}

		/// <summary>
		/// Test that correct product is assigned when valid id is passed
		/// </summary>
		[Test]
		public void OnGet_Valid_Id_Default_Should_Return_Null()
		{
			// Arrange

			// Act
			pageModel.OnGet("1");

			// the expected TravelTipsModel assigned to the DeleteTravelTip page
			var expected = TestHelper.TravelTipService.GetAllData().First(x => x.Id == "1");

			// Assert
			Assert.AreEqual(expected.Id, pageModel.TravelTips.Id);
			Assert.AreEqual(expected.Title, pageModel.TravelTips.Title);
			Assert.AreEqual(expected.Description, pageModel.TravelTips.Description);
		}

		#endregion OnGet
	}
}
