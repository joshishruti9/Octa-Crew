using System.Diagnostics;

using Microsoft.Extensions.Logging;

using NUnit.Framework;

using Moq;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages.Error
{
    /// <summary>
    /// Unit testing class for Error page model
    /// </summary>
    public class ErrorTests
    {
        #region TestSetup

        // page model for the Error page
        public static ErrorModel pageModel;

        /// <summary>
        /// Called before each test is called.
        /// Sets up necessary test context or variables
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {

            // mock of the ErrorModel logger
            var MockLoggerDirect = Mock.Of<ILogger<ErrorModel>>();

            pageModel = new ErrorModel(MockLoggerDirect)
            {
                PageContext = TestHelper.PageContext,
                TempData = TestHelper.TempData,
            };
        }

        #endregion TestSetup

        #region OnGet

        /// <summary>
        /// Test that OnGet with valid data generates a valid page model and stores the correct RequestId
        /// </summary>
        [Test]
        public void OnGet_Valid_Activity_Set_Should_Return_RequestId()
        {
            // Arrange

            // stores the current operation being performed
            Activity activity = new Activity("activity");

            activity.Start();

            // Act
            pageModel.OnGet();

            // Reset
            activity.Stop();

            // Assert
            Assert.That(pageModel.ModelState.IsValid, Is.EqualTo(true));
            Assert.That(pageModel.RequestId, Is.EqualTo(activity.Id));
        }

        /// <summary>
        /// Test that OnGet with invalid data generates the correct identifier for the trace logs
        /// </summary>
        [Test]
        public void OnGet_InValid_Activity_Null_Should_Return_TraceIdentifier()
        {
            // Arrange

            // Act
            pageModel.OnGet();

            // Reset

            // Assert
            Assert.That(pageModel.ModelState.IsValid, Is.EqualTo(true));
            Assert.That(pageModel.RequestId, Is.EqualTo("trace"));
            Assert.That(pageModel.ShowRequestId, Is.EqualTo(true));
        }

        /// <summary>
        /// Test that OnGet with a status code of 404 sets the error message to "Page Not Found"
        /// </summary>
        [Test]
        public void OnGet_Status_Code_404_Should_Set_Error_Message_To_Page_Not_Found()
        {
            // Arrange

            // Act
            pageModel.OnGet(statusCode: 404);

            // Reset

            // Assert
            Assert.AreEqual(true, pageModel.ModelState.IsValid);
            Assert.AreEqual("Page Not Found", pageModel.ErrorMessage);
        }

        #endregion OnGet
    }
}