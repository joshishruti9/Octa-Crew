using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using ContosoCrafts.WebSite.Pages;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;

namespace UnitTests.Pages
{
    /// <summary>
    /// Unit test class for the Create page model
    /// </summary>
    public class CreateTests
    {
        #region TestSetup

        // page model for the CRUDi Create page
        static CreateModel pageModel;

        /// <summary>
        /// Called before each test is called.
        /// Sets up necessary test context or variables
        /// </summary>
        [SetUp]
        public void Setup()
        {
            pageModel = new CreateModel(TestHelper.ProductService);
        }

        #endregion

        #region OnGet

        [Test]
        public void OnGet_Valid_Default_Should_Set_Default_Values()
        {
            // Arrange
            var data = TestHelper.ProductService.CreateData();

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(true, data.Images.SequenceEqual(pageModel.Product.Images));
            Assert.AreEqual(data.Title, pageModel.Product.Title);
            Assert.AreEqual(data.Description, pageModel.Product.Description);
            Assert.AreEqual(pageModel.Product.BestSeason, pageModel.Product.BestSeason);
            Assert.AreEqual(data.Currency, pageModel.Product.Currency);
            Assert.AreEqual(data.TimeZone, pageModel.Product.TimeZone);
            Assert.AreEqual(true, data.Attractions.SequenceEqual(pageModel.Product.Attractions));
            Assert.AreEqual(data.Cost, pageModel.Product.Cost);
            Assert.AreEqual(data.TravelTime, pageModel.Product.TravelTime);
            Assert.AreEqual(data.Ratings, pageModel.Product.Ratings);
        }

        #endregion OnGet
    }
}
