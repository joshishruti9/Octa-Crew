using System.Collections.Generic;
using System.IO;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using UnitTests.Pages;


namespace UnitTests.Services
{
    /// <summary>
    /// Unit testing class for JsonFileProductService
    /// </summary>
    public class JsonFileProductServiceTests
    {

        #region AddRating

        /// <summary>
        /// Test AddRating returns false when null product is passed
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Null_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating(null, 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test AddRating returns false when an empty product id is passed
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Empty_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test AddRating returns false when a product id not in the database is passed
        /// </summary>
        [Test]
        public void AddRating_InValid_Product_Does_Not_Exist_Should_Return_False()
        {
            // Arrange

            // Act
            var result = TestHelper.ProductService.AddRating("invalid_id", 1);

            // Assert
            Assert.AreEqual(false, result);
        }

        /// <summary>
        /// Test AddRating returns false when attempting to add a negative rating
        /// </summary>
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

        /// <summary>
        /// Test AddRating returns false when attempting to add a rating > 5
        /// </summary>
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

        /// <summary>
        /// Test AddRating successfully updates the database and returns true when ratings list is null
        /// </summary>
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

        /// <summary>
        /// Test AddRating successfully updates the database and returns true when ratings list is non-empty
        /// </summary>
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

        #endregion AddRating[Test]

        #region CreateData

        [Test]
        public void CreateData_Valid_Default_Should_Return_Default_Fields()
        {
            // Arrange
            var data = new ProductModel
            {
                Id = null,
                Images = new string[3],
                Title = null,
                Description = null,
                BestSeason = null,
                Currency = null,
                TimeZone = null,
                Attractions = new string[3],
                Cost = 0,
                TravelTime = 0.0,
                Ratings = null
            };

            // Act
            var result = TestHelper.ProductService.CreateData();

            // Assert
            Assert.AreEqual(true, data.Images.SequenceEqual(result.Images));
            Assert.AreEqual(data.Title, result.Title);
            Assert.AreEqual(data.Description, result.Description);
            Assert.AreEqual(result.BestSeason, result.BestSeason);
            Assert.AreEqual(data.Currency, result.Currency);
            Assert.AreEqual(data.TimeZone, result.TimeZone);
            Assert.AreEqual(true, data.Attractions.SequenceEqual(result.Attractions));
            Assert.AreEqual(data.Cost, result.Cost);
            Assert.AreEqual(data.TravelTime, result.TravelTime);
            Assert.AreEqual(data.Ratings, result.Ratings);
        }

        #endregion CreateData

        /// <summary>
        /// Test UpdateData method when product exists in the data source
        /// </summary>
        #region UpdateData

        [Test]
        public void UpdateData_Should_Update_Existing_Product()
        {
            // Arrange
            var existingProduct = TestHelper.ProductService.GetAllData().First();
            var updatedProduct = new ProductModel
            {
                Id = existingProduct.Id,
                Title = "Updated Title",
                Description = "Updated Description",
                Images = new List<string> { "updated-image.jpg" }.ToArray(),
                TimeZone = "PST",
                BestSeason = Season.Winter,
                Currency = "USD",
                Attractions = new List<string> { "Attraction1", "Attraction2" }.ToArray()
            };

            // Act
            var result = TestHelper.ProductService.UpdateData(updatedProduct);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result.Title, Is.EqualTo("Updated Title"));
                Assert.That(result.Description, Is.EqualTo("Updated Description"));
                Assert.That(result.Images, Is.EqualTo(new List<string> { "updated-image.jpg" }));
                Assert.That(result.TimeZone, Is.EqualTo("PST"));
                Assert.That(result.BestSeason, Is.EqualTo(Season.Winter));
                Assert.That(result.Currency, Is.EqualTo("USD"));
                Assert.That(result.Attractions, Is.EqualTo(new List<string> { "Attraction1", "Attraction2" }));
            });
        }

        [Test]
        public void UpdateData_Should_Return_Null_If_Product_Not_Found()
        {
            // Arrange
            var nonExistentProduct = new ProductModel
            {
                Id = "999",  // Assuming this ID does not exist
                Title = "Non-existent Product",
                Description = "Non-existent Description"
            };

            // Act
            var result = TestHelper.ProductService.UpdateData(nonExistentProduct);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void UpdateData_Should_Trim_Description()
        {
            // Arrange
            var existingProduct = TestHelper.ProductService.GetAllData().First();
            var updatedProduct = new ProductModel
            {
                Id = existingProduct.Id,
                Title = "Updated Title",
                Description = "  Updated Description with extra spaces  "
            };

            // Act
            var result = TestHelper.ProductService.UpdateData(updatedProduct);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Description, Is.EqualTo("Updated Description with extra spaces"));
        }

        #endregion UpdateData




    }
}
