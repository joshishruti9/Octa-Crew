
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

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
	}
}
