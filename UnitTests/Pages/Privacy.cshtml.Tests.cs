using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages
{
    public class PrivacyTests
    {
        #region TestSetup

        // page model for the Privacy page
        public static PrivacyModel pageModel;

        [SetUp]
        public void TestInitialize()
        {
            // mock of the logger for pageModel
            var MockLoggerDirect = Mock.Of<ILogger<PrivacyModel>>();

            pageModel = new PrivacyModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.That(pageModel.ModelState.IsValid, Is.EqualTo(true));
        }

        #endregion OnGet
    }
}