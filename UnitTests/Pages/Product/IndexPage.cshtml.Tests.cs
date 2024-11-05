using NUnit.Framework;
using System.Linq;
using Microsoft.Extensions.Logging;
using Moq;
using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product
{

    public class IndexPageTests
    {
        // Database MiddleTier
        #region TestSetup
        public static IndexPageModel pageModel;
        /// <summary>
        /// Initialize of Test
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            var MockLoggerDirect = Mock.Of<ILogger<IndexPageModel>>();
            pageModel = new IndexPageModel(MockLoggerDirect, TestHelper.ProductService)
            {
            };
        }

        #endregion TestSetup

        /// <summary>
        /// Checking whether product user want is there in result or not.
        /// </summary>
        #region OnGet
        [Test]
        public void OnGet_Valid_Should_Return_Products()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Assert 
            // How many are there?
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            // Are there any in existence?
            Assert.AreEqual(true, pageModel.Products.ToList().Any());
        }
        #endregion OnGet
    }
}
