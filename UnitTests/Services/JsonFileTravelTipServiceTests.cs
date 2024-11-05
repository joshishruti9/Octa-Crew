
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Services
{
	/// <summary>
	/// Unit testing class for JsonFileTravelTipService
	/// </summary>
	public class JsonFileTravelTipServiceTests
	{
		#region CreateData

		/// <summary>
		/// Test that CreateData returns a TravelTipsModel object with the expected default values
		/// </summary>
		[Test]
		public void CreateData_Valid_Default_Should_Return_Default_Fields()
		{
			// Arrange
			var data = new TravelTipsModel
			{
				Id = System.Guid.NewGuid().ToString(),
				Title = "Enter Tip Name",
				Description = "Enter Tip Description",
			};

			// Act
			var result = TestHelper.TravelTipService.CreateData();

			// Assert
			Assert.AreEqual(data.Title, result.Title);
			Assert.AreEqual(data.Description, result.Description);
		}

		#endregion CreateData

		#region UpdateData

		/// <summary>
		/// Test UpdateData method when tip exists in the data source
		/// </summary>
		[Test]
		public void UpdateData_Should_Update_Existing_TravelTip()
		{
			// Arrange
			var existingTravelTip = TestHelper.TravelTipService.GetAllData().First();
			var updatedTravelTip = new TravelTipsModel
			{
				Id = existingTravelTip.Id,
				Title = "Updated Title",
				Description = "Updated Description",
			};

			// Act
			var result = TestHelper.TravelTipService.UpdateData(updatedTravelTip);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.AreEqual("Updated Title", result.Title);
			Assert.AreEqual("Updated Description", result.Description);
		}

		#endregion UpdateData
	}
}
