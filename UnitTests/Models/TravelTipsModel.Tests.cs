
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

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