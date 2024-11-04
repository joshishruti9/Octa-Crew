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

		#endregion
	}
}
