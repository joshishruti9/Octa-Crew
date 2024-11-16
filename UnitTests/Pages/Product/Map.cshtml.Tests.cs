using NUnit.Framework;
using ContosoCrafts.WebSite.Pages.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Unit testing class for Map page model
    /// </summary>
    class MapTests
    {
        #region TestSetup

        // Page model for the Map page
        public static MapModel pageModel;

        /// <summary>
        /// Called before each test is called.
        /// Sets up necessary test context or variables
        /// </summary>
        [SetUp]
        public void Setup()
        {
            pageModel = new MapModel(TestHelper.ProductService);
        }

        #endregion TestSetup
    }
}
