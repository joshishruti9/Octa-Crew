using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitTests.Models
{
	/// <summary>
	/// Unit testing class for ProductModel
	/// </summary>
	public class ProductModelTests
    {
		#region Images

		/// <summary>
		/// Setting Images to null should cause a validation error
		/// </summary>
		[Test]
		public void Set_Images_Invalid_Null_Should_Not_Be_Validated()
		{
			// Arrange
			var data = new ProductModel()
			{
				Id = System.Guid.NewGuid().ToString(),
				Images = null,
				Title = "Enter City Name",
				Description = "Enter City Description",
				BestSeason = null,
				Currency = "Enter Currency",
				TimeZone = "Enter Time Zone",
				Attractions = new string[3]
				{
					"Enter an Attraction",
					"Enter an Attraction",
					"Enter an Attraction"
				},
				Cost = 0,
				TravelTime = 0.0,
				Ratings = null
			};
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("Image URLs are required", validationResults[0].ErrorMessage);
		}

		/// <summary>
		/// Setting Images to empty array should cause a validation error
		/// </summary>
		[Test]
		public void Set_Images_Invalid_Empty_Array_Should_Not_Be_Validated()
		{
			// Arrange
			var data = new ProductModel()
			{
				Id = System.Guid.NewGuid().ToString(),
				Images = new string[0],
				Title = "Enter City Name",
				Description = "Enter City Description",
				BestSeason = null,
				Currency = "Enter Currency",
				TimeZone = "Enter Time Zone",
				Attractions = new string[3]
				{
					"Enter an Attraction",
					"Enter an Attraction",
					"Enter an Attraction"
				},
				Cost = 0,
				TravelTime = 0.0,
				Ratings = null
			};
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("3 Image URLs are required", validationResults[0].ErrorMessage);
		}

		/// <summary>
		/// Setting less than 3 Images should cause a validation error
		/// </summary>
		[Test]
		public void Set_Images_Invalid_Less_Than_3_Should_Not_Be_Validated()
		{
			// Arrange
			var data = new ProductModel()
			{
				Id = System.Guid.NewGuid().ToString(),
				Images = new string[]
				{
					"https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
					"https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg"
				},
				Title = "Enter City Name",
				Description = "Enter City Description",
				BestSeason = null,
				Currency = "Enter Currency",
				TimeZone = "Enter Time Zone",
				Attractions = new string[3]
				{
					"Enter an Attraction",
					"Enter an Attraction",
					"Enter an Attraction"
				},
				Cost = 0,
				TravelTime = 0.0,
				Ratings = null
			};
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("3 Image URLs are required", validationResults[0].ErrorMessage);
		}

		/// <summary>
		/// Setting more than 3 Images should cause a validation error
		/// </summary>
		[Test]
		public void Set_Images_Invalid_Greater_Than_3_Should_Not_Be_Validated()
		{
			// Arrange
			var data = new ProductModel()
			{
				Images = new string[]
				{
					"https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
					"https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg",
					"https://images.pexels.com/photos/161901/paris-sunset-france-monument-161901.jpeg",
					"https://images.pexels.com/photos/753639/pexels-photo-753639.jpeg"
				}
			};
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("No more than 3 Image URLs are allowed", validationResults[0].ErrorMessage);
		}

		/// <summary>
		/// Setting valid array of 3 Images should be successul
		/// </summary>
		[Test]
		public void Set_Images_Valid_Should_Be_Validated()
		{
			// Arrange
			var data = new ProductModel()
			{
				Images = new string[]
				{
					"https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
					"https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg",
					"https://images.pexels.com/photos/161901/paris-sunset-france-monument-161901.jpeg"
				}
			};
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(true, result);
			Assert.AreEqual(0, validationResults.Count);
		}

		#endregion Images

		#region GetCityRating

		/// <summary>
		/// Test that a call of GetCityRating() on a city with no ratings should return 0
		/// </summary>
		[Test]
		public void GetCityRating_Invalid_Test_Ratings_Null_Should_Return_0_True()
		{
			// Arrange
			var data = new ProductModel();

			// Act
			var result = data.GetCityRating();

			// Reset

			// Assert
			Assert.AreEqual(0, result);
		}

		/// <summary>
		/// Test that a call of GetCityRating() on a city with only one rating should return its
		/// average rating
		/// </summary>
		[Test]
		public void GetCityRating_Valid_Test_Single_Rating_Should_Return_Rating_True()
		{
			// Arrange
			var data = new ProductModel()
			{
				// Fill city with valid Rating
				Ratings = new[] { 1 }
			};

			// Act
			var result = data.GetCityRating();

			// Reset

			// Assert
			Assert.AreEqual(1, result);
		}

		/// <summary>
		/// Test that a call of GetCityRating() on a city with ratings should return its average rating
		/// </summary>
		[Test]
		public void GetCityRating_Valid_Test_Multiple_Ratings_Should_Return_Average_Rating_True()
		{
			// Arrange
			var data = new ProductModel()
			{
				// Fill city with valid Ratings
				Ratings = new[] { 2, 1, 4, 2, 5, 4, 2, 5, 3 }
			};

			// Act
			var result = data.GetCityRating();

			// Reset

			// Assert
			Assert.AreEqual(3, result);
		}

		#endregion GetCityRating
	}
}