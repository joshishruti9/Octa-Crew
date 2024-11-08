﻿
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitTests.Models
{
	/// <summary>
	/// Tests for ImageURLModel class and its validation for the URL attribute
	/// </summary>
	public class ImageURLModelTests
	{
		#region URL

		/// <summary>
		/// Checks that setting the URL attribute to null causes a validation error
		/// </summary>
		[Test]
		public void Set_URL_Invalid_Null_Should_Return_Error()
		{
			// Arrange
			var data = new ImageURLModel
			{
				URL = null
			};
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual(true, validationResults.Exists(
				vr => vr.ErrorMessage == "URL is required"
			));
		}

		#endregion URL
	}
}