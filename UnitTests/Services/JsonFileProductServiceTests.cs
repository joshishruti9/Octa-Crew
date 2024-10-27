using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages;
using NUnit.Framework;

namespace UnitTests.Services
{
    /// <summary>
    /// Unit testing class for JsonFileProductService
    /// </summary>
    public class JsonFileProductServiceTests
    {

        #region AddRating

        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_InValid_Product_Does_Not_Exist_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("invalid_id", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_Negative_Rating_Should_Return_False()
        {
            // Arrange

            // Get the first data item
            var data = TestHelper.ProductService.GetProducts().First();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, -1);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_Rating_Above_5_Should_Return_False()
        {
            // Arrange

            // Get the first data item
            var data = TestHelper.ProductService.GetProducts().First();

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 6);

            // Assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void AddRating_Valid_Product_Rating_Null_Should_Return_True()
        {
            // Arrange

            // Attempt to get the first null data item
            var data = TestHelper.ProductService.GetProducts().First(e => e.Ratings == null);

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetProducts().First(e => e.Id == data.Id);

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(5, dataNewList.Ratings[0]);
        }

        [Test]
        public void AddRating_Valid_Product_Rating_5_Should_Return_True()
        {
            // Arrange

            // Get the First data item
            var data = TestHelper.ProductService.GetProducts().First();
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);
            var dataNewList = TestHelper.ProductService.GetProducts().First();

            // Assert
            Assert.AreEqual(result, true);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        #endregion AddRating
    }
}
