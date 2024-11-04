using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Models
{
	/// <summary>
	/// Unit testing class for ProductModel
	/// </summary>
	public class ProductModelTests
    {
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
			Assert.AreEqual(result, 0);
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

		#endregion
	}
}
