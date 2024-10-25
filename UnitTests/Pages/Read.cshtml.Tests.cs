using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Hosting;
using Moq;

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



        #endregion Onget
    }
}
