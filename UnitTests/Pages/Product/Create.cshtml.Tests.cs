using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using ContosoCrafts.WebSite.Pages.Product;

namespace UnitTests.Pages.Product
{
    /// <summary>
    /// Unit test class for the Create page model
    /// </summary>
    public class CreateTests
    {
        #region TestSetup

        // page model for the CRUDi Create page
        static CreateModel pageModel;

        // the ProductModel with default values filled in
        static ProductModel defaultModel;

        /// <summary>
        /// Called before each test is called.
        /// Sets up necessary test context or variables
        /// </summary>
        [SetUp]
        public void Setup()
        {
            pageModel = new CreateModel(TestHelper.ProductService);
            defaultModel = new ProductModel()
            {
                Id = Guid.NewGuid().ToString(),
                Images = new string[3]
                {
                    "Enter URL",
                    "Enter URL",
                    "Enter URL"
                },
                Title = "Enter City Name",
                Description = "Enter City Description",
                BestSeason = null,
                Currency = "Enter Currency",
                TimeZone = "Enter Time Zone",
                Attractions = new string[3]
                {
                    "Enter an Attraction",
                    "Enter an Attraction",
                    "Enter an Attraction"
                },
                Cost = 0,
                TravelTime = 0.0,
                Ratings = null
            };
        }

        #endregion

        #region OnGet

        /// <summary>
        /// Test that OnGet correctly sets the page's Product values to the defaults
        /// </summary>
        [Test]
        public void OnGet_Valid_Default_Should_Set_Default_Values()
        {
            // Arrange
            var data = defaultModel;

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

        #region OnPost

        /// <summary>
        /// Test that a city is not added to the database if the ModelState is invalid
        /// </summary>
        [Test]
        public void OnPost_InValid_Invalid_ModelState_Should_Not_Add_City()
        {
            // Arrange
            pageModel.ModelState.AddModelError("Title", "Invalid title");

            // number of cities in the database before calling OnPost
            var countOriginal = TestHelper.ProductService.GetAllData().Count();

            // Act
            var result = pageModel.OnPost();

            // Assert
            Assert.AreEqual(true, result.GetType().Equals(typeof(PageResult)));
            Assert.AreEqual(countOriginal, TestHelper.ProductService.GetAllData().Count());
        }

        /// <summary>
        /// Test that OnPost successfully adds a city to the database when the 
        /// default values are passed in.
        /// </summary>
        [Test]
        public void OnPost_Valid_Default_Should_Add_City()
        {
            // Arrange
            pageModel.Product = defaultModel;

            // the ProductModel for the page
            var data = pageModel.Product;

            // number of cities in the database before calling OnPost
            var countOriginal = TestHelper.ProductService.GetAllData().Count();

            // Act
            var result = pageModel.OnPost();

            // the cities in the database after calling OnPost
            var dataNewList = TestHelper.ProductService.GetAllData();

            // the new city added by OnPost
            var newProduct = TestHelper.ProductService.GetAllData().First(x => x.Id.Equals(data.Id));

            // Assert
            Assert.AreEqual(countOriginal + 1, dataNewList.Count());
            Assert.AreEqual(true, data.ToString().Equals(newProduct.ToString()));
            Assert.AreEqual(true, TestHelper.ModelState.IsValid);
            Assert.AreEqual("./Index", (result as RedirectToPageResult).PageName);
        }

        /// <summary>
        /// Test that OnPost successfully adds a city to the database when custom 
        /// values are passed in.
        /// </summary>
        [Test]
        public void OnPost_Valid_Custom_Should_Add_City()
        {
            // Arrange
            pageModel.Product = new ProductModel()
            {
                Id = Guid.NewGuid().ToString(),
                Title = "Custom City",
                Description = "Custom Description",
                BestSeason = Season.Spring,
                Currency = "Dollar",
                TimeZone = "PDT",
                Attractions = new string[3]
                {
                    "Attraction 1",
                    "Attraction 2",
                    "Attraction 3"
                },
                Cost = 2000,
                TravelTime = 9.5,
                Ratings = null
            };
            // ProductModel for the page
            var data = pageModel.Product;

            // number of cities in the database before calling OnPost
            var countOriginal = TestHelper.ProductService.GetAllData().Count();

            // Act
            var result = pageModel.OnPost();

            // the cities in the database after calling OnPost
            var dataNewList = TestHelper.ProductService.GetAllData();

            // the new city added by OnPost
            var newProduct = TestHelper.ProductService.GetAllData().First(x => x.Id.Equals(data.Id));

            // Assert
            Assert.AreEqual(countOriginal + 1, dataNewList.Count());
            Assert.AreEqual(true, data.ToString().Equals(newProduct.ToString()));
            Assert.AreEqual(true, TestHelper.ModelState.IsValid);
            Assert.AreEqual("./Index", (result as RedirectToPageResult).PageName);
        }

        #endregion OnPost
    }
}
