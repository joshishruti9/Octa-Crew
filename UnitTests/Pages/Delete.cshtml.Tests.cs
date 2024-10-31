using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using ContosoCrafts.WebSite.Pages;

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
	}
}