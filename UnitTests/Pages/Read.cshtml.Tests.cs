using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;

namespace UnitTests.Pages
{

    public class ReadTests
    {
        #region TestSetup

        // Page model for the CRUDi Read page
        public static ReadModel pageModel;

        /// <summary>
        /// Called before each test is called.
        /// Sets up necessary test context or variables
        /// </summary>
        [SetUp]
        public void Setup()
        {
            pageModel = new ReadModel(TestHelper.ProductService);
        }

        #endregion TestSetup

        #region ReadData

        /// <summary>
        /// Test for correct output when null id is passed
        /// </summary>
        [Test]
        public void ReadData_Null_Id_Default_Should_Return_Null()
        {
            // Arrange

            // Act
            var result = pageModel.ReadData(null);

            // Assert
            Assert.AreEqual(null, result);
        }

        /// <summary>
        /// Test for correct output when invalid id is passed
        /// </summary>
        [Test]
        public void ReadData_Invalid_Id_Default_Should_Return_Null()
        {
            // Arrange

            // Act
            var result = pageModel.ReadData("unitedstates");

            // Assert
            Assert.AreEqual(null, result);
        }
        
        /// <summary>
        /// Test for correct output when a valid id is passed
        /// </summary>
        [Test]
        public void ReadData_Valid_Id_Default_Should_Return_City()
        {
            // Arrange

            // Act
            var result = pageModel.ReadData("paris");

            // Assert
            Assert.AreEqual("paris", result.Id);
        }

        #endregion ReadData

        #region OnGet

        /// <summary>
        /// Test that no product is assigned when null id is passed
        /// </summary>
        [Test]
        public void OnGet_Null_Id_Default_Should_Return_Null()
        {
            // Arrange

            // Act
            pageModel.OnGet(null);

            // Assert
            Assert.AreEqual(null, pageModel.Product);
        }

        /// <summary>
        /// Test that no product is assigned when invalid id is passed
        /// </summary>
        [Test]
        public void OnGet_Invalid_Id_Default_Should_Return_Null()
        {
            // Arrange

            // Act
            pageModel.OnGet("unitedstates");

            // Assert
            Assert.AreEqual(null, pageModel.Product);
        }

        /// <summary>
        /// Test that correct product is assigned when valid id is passed
        /// </summary>
        [Test]
        public void OnGet_Valid_Id_Default_Should_Return_Null()
        {
            // Arrange

            // Act
            pageModel.OnGet("paris");

            // Assert
            Assert.AreEqual("Paris", pageModel.Product.Title);
        }

        #endregion Onget
    }
}
