
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

			ValidationContext valContext = new ValidationContext(travelTipsModel);
			var validationResults = new List<ValidationResult>();
			
			// Act
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

			ValidationContext valContext = new ValidationContext(travelTipsModel);
			var validationResults = new List<ValidationResult>();
			
			// Act
			var result = Validator.TryValidateObject(travelTipsModel, new ValidationContext(travelTipsModel), validationResults);

			// Reset
			travelTipsModel.Title = oldTitle;

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual(validationResults.First().ErrorMessage, "Title should not be empty");
		}

		/// <summary>
		/// Test that a title with over the maximum number of characters is not validated
		/// </summary>
		[Test]
		public void Get_Invalid_Title_Too_Long_Should_Not_Validate()
		{
			// Arrange
			
			// initial title
			var oldTitle = travelTipsModel.Title;

			travelTipsModel.Title = new string('a', 101);

			var validationResults = new List<ValidationResult>();

			// Act
			var result = Validator.TryValidateObject(travelTipsModel, new ValidationContext(travelTipsModel), validationResults, true);

			// Reset
			travelTipsModel.Title = oldTitle;

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("The Title should have a length less than 100 characters", validationResults.First().ErrorMessage);
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

		/// <summary>
		/// Test that a null description is not validated
		/// </summary>
		[Test]
		public void Get_Invalid_Description_Null_Should_Not_Validate()
		{
			// Arrange

			// the initial description
			var oldDescription = travelTipsModel.Description;

			travelTipsModel.Description = null;

			ValidationContext valContext = new ValidationContext(travelTipsModel);
			var validationResults = new List<ValidationResult>();

			// Act
			var result = Validator.TryValidateObject(travelTipsModel, new ValidationContext(travelTipsModel), validationResults, true);

			// Reset
			travelTipsModel.Description = oldDescription;

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual(validationResults.First().ErrorMessage, "Description should not be empty");
		}

		/// <summary>
		/// Test that an empty string description is not validated
		/// </summary>
		[Test]
		public void Get_Invalid_Description_Empty_Should_Not_Validate()
		{
			// Arrange

			// the initial description
			var oldDescription = travelTipsModel.Description;

			travelTipsModel.Description = "";

			ValidationContext valContext = new ValidationContext(travelTipsModel);
			var validationResults = new List<ValidationResult>();

			// Act
			var result = Validator.TryValidateObject(travelTipsModel, new ValidationContext(travelTipsModel), validationResults, true);

			// Reset
			travelTipsModel.Description = oldDescription;

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual(validationResults.First().ErrorMessage, "Description should not be empty");
		}

		/// <summary>
		/// Test that a description with over the maximum number of characters is not validated
		/// </summary>
		[Test]
		public void Get_Invalid_Description_Too_Long_Should_Not_Validate()
		{
			// Arrange

			// initial description
			var oldDescription = travelTipsModel.Title;

			travelTipsModel.Description = new string('a', 5001);

			var validationResults = new List<ValidationResult>();

			// Act
			var result = Validator.TryValidateObject(travelTipsModel, new ValidationContext(travelTipsModel), validationResults, true);

			// Reset
			travelTipsModel.Description = oldDescription;

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("The Description should have a length less than 5000 characters", validationResults.First().ErrorMessage);
		}

		#endregion Description
	}
}