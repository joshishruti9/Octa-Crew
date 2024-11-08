
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.TravelTipsProduct;
using ContosoCrafts.WebSite.Services;
using NUnit.Framework;

namespace UnitTests.Pages.TravelTipsProduct
{
	
	/// <summary>
	/// Unit testing class for Update page model for Travel Tips
	/// </summary>
	public class UpdateTravelTipTests
	{
		#region TestSetup

		// Model for Update page for TravelTip
		public static UpdateTravelTipModel pageModel;

		// Service for accessing and modifying data in database
		public JsonFileTravelTipService TravelTipService;

		/// <summary>
		/// Called before each test is called.
		/// Sets up necessary test context or variables
		/// </summary>
		[SetUp]
		public void Setup()
		{
			// Use a mock or test helper for TravelTipService
			TravelTipService = TestHelper.TravelTipService;
			pageModel = new UpdateTravelTipModel(TravelTipService)
			{
				TravelTip = new TravelTipsModel()
			};
		}

		#endregion TestSetup

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

			// Reset

			// Assert
			Assert.IsNull(pageModel.TravelTip);
		}

		#endregion OnGet
	}
}