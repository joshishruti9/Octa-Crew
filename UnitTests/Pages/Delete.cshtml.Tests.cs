using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Pages;
using System.Diagnostics;

namespace UnitTests.Pages
{
	/// <summary>
	/// Unit testing class for Delete page model
	/// </summary>
	public class DeleteTests
	{
		#region TestSetup

		public static DeleteModel pageModel;
		public JsonFileProductService ProductService;

		/// <summary>
		/// Called before each test is called.
		/// Sets up necessary test context or variables
		/// </summary>
		[SetUp]
		public void Setup()
		{
			// Use a mock or test helper for ProductService
			ProductService = TestHelper.ProductService;
			pageModel = new DeleteModel(ProductService);
		}

		#endregion TestSetup

		#region OnGet
		[Test]
		public void OnGet_Valid_Activity_Set_Should_Have_Valid_State()
		{
			// Arrange

			// Act
			pageModel.OnGet("paris");

			// Reset

			// Assert
			Assert.That(pageModel.ModelState.IsValid, Is.EqualTo(true));
		}

		#endregion OnGet
	}
}