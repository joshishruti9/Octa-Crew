using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;
using System.Linq;

namespace UnitTests.Pages
{
	/// <summary>
	/// Unit testing class for TravelTips page model
	/// </summary>
	public class TravelTipsTests
	{
		#region TestSetup

		public static TravelTipsPageModel pageModel;

		/// <summary>
		/// Called before each test is called.
		/// Sets up necessary test context or variables
		/// </summary>
		[SetUp]
		public void Setup()
		{
			pageModel = new TravelTipsPageModel(TestHelper.TravelTipService);
		}

		#endregion TestSetup

		#region OnGet
		[Test]
		public void OnGet_Valid_Activity_Set_Should_Have_Valid_State()
		{
			// Arrange

			// Act
			pageModel.OnGet();

			// Reset

			// Assert
			Assert.AreEqual(true, pageModel.ModelState.IsValid);
			Assert.AreEqual(true, pageModel.TravelTips.ToList().Any());
		}

		#endregion OnGet
	}
}