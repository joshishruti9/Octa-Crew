using NUnit.Framework;
using System.Linq;
using ContosoCrafts.WebSite.Pages;
using Microsoft.Extensions.Logging;
using Moq;

namespace UnitTests.Pages
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
    }
}
