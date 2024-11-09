
using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UnitTests.Models
{
	/// <summary>
	/// Unit testing class for TravelTipsModel
	/// </summary>
	public class TravelTipsModelTests
	{
		#region TestSetup

		// Travel tips model for testing
		static TravelTipsModel travelTipsModel;

		[SetUp]
		public void SetUp()
		{
			travelTipsModel = new TravelTipsModel()
			{
				Id = "11",
				Title = "Default title",
				Description = "Default description"
			};
		}

		#endregion TestSetup

		#region Id

		[Test]
		public void Get_Valid_Id_Should_Return_Id()
		{
			// Arrange

			// Act
			var result = travelTipsModel.Id;

			// Reset

			// Assert
			Assert.AreEqual("11", result);
		}

		#endregion Id

		#region Title

		[Test]
		public void Get_Valid_Title_Should_Return_Title()
		{
			// Arrange

			// Act
			var result = travelTipsModel.Title;

			// Reset

			// Assert
			Assert.AreEqual("Default title", result);
		}

		/// <summary>
		/// Test that a null title is not validated
		/// </summary>
		[Test]
		public void Get_Invalid_Title_Null_Should_Not_Validate()
		{
			// Arrange

			// the initial title
			var oldTitle = travelTipsModel.Title;

			travelTipsModel.Title = null;

			// Act
			ValidationContext valContext = new ValidationContext(travelTipsModel);
			var validationResults = new List<ValidationResult>();
			var result = Validator.TryValidateObject(travelTipsModel, new ValidationContext(travelTipsModel), validationResults);

			// Reset
			travelTipsModel.Title = oldTitle;

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual(validationResults.First().ErrorMessage, "Title should not be empty");
		}

		/// <summary>
		/// Test that an empty string title is not validated
		/// </summary>
		[Test]
		public void Get_Invalid_Title_Empty_Should_Not_Validate()
		{
			// Arrange

			// the initial title
			var oldTitle = travelTipsModel.Title;

			travelTipsModel.Title = "";

			// Act
			ValidationContext valContext = new ValidationContext(travelTipsModel);
			var validationResults = new List<ValidationResult>();
			var result = Validator.TryValidateObject(travelTipsModel, new ValidationContext(travelTipsModel), validationResults);

			// Reset
			travelTipsModel.Title = oldTitle;

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual(validationResults.First().ErrorMessage, "Title should not be empty");
		}

		#endregion Title

		#region Description

		[Test]
		public void Get_Valid_Description_Should_Return_Description()
		{
			// Arrange

			// Act
			var result = travelTipsModel.Description;

			// Reset

			// Assert
			Assert.AreEqual("Default description", result);
		}

		#endregion Description
	}
}