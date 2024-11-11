using NUnit.Framework;
using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages
{
    /// <summary>
    /// Unit testing class for Index model
    /// </summary>
    public class IndexTests
    {
        #region TestSetup

        // page model for the Index page
        public static IndexModel pageModel;

        /// <summary>
        /// Called before each test is called.
        /// Sets up necessary test context or variables
        /// </summary>
        [SetUp]
        public void Setup()
        {
            pageModel = new IndexModel();
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
            Assert.That(pageModel.ModelState.IsValid, Is.EqualTo(true));
        }

        #endregion OnGet
    }
}