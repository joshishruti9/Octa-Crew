﻿using System.Collections.Generic;
using System.Linq;
using ContosoCrafts.WebSite.Enums;
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;


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
            var data = TestHelper.ProductService.GetAllData().First();

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
            var data = TestHelper.ProductService.GetAllData().First();

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
            var data = TestHelper.ProductService.GetAllData().First(e => e.Ratings == null);

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);

            // Get the city on which AddRating was just applied
            var dataNewList = TestHelper.ProductService.GetAllData().First(e => e.Id == data.Id);

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
            var data = TestHelper.ProductService.GetAllData().First();

            // The number of ratings before adding a new rating
            var countOriginal = data.Ratings.Length;

            // Act
            var result = TestHelper.ProductService.AddRating(data.Id, 5);

            // Get the city on which AddRating was just applied
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.AreEqual(result, true);
            Assert.AreEqual(countOriginal + 1, dataNewList.Ratings.Length);
            Assert.AreEqual(5, dataNewList.Ratings.Last());
        }

        #endregion AddRating[Test]

        #region CreateData

        /// <summary>
        /// Test that CreateData returns a ProductModel object with the expected default values
        /// </summary>
        [Test]
        public void CreateData_Valid_Default_Should_Return_Default_Fields()
        {
            // Arrange
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Images = new string[3],
                Title = null,
                Description = null,
                BestSeason = SeasonEnum.Unknown,
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

        #region UpdateData

        /// <summary>
        /// Test UpdateData method when product exists in the data source
        /// </summary>
        [Test]
        public void UpdateData_Valid_ExistingProduct_Should_Return_UpdatedProduct()
        {
            // Arrange

            // The initial city
            var existingProduct = TestHelper.ProductService.GetAllData().First();

            // ProductModel used to update the database
            var updatedProduct = new ProductModel
            {
                Id = existingProduct.Id,
                Title = "Updated Title",
                Description = "Updated Description",
                Images = new List<string> { "updated-image.jpg" }.ToArray(),
                TimeZone = "PST",
                BestSeason = SeasonEnum.Winter,
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
                Assert.That(result.BestSeason, Is.EqualTo(SeasonEnum.Winter));
                Assert.That(result.Currency, Is.EqualTo("USD"));
                Assert.That(result.Attractions, Is.EqualTo(new List<string> { "Attraction1", "Attraction2" }));
            });
        }

        /// <summary>
        /// Test that UpdateData returns null if the city is not in the database
        /// </summary>
        [Test]
        public void UpdateData_Product_NotFound_Test_Should_Return_Null()
        {
            // Arrange

            // Product whose ID doesn't exist in the database
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

        /// <summary>
        /// Test that description is successfully updated when the description contains only whitespace
        /// </summary>
        [Test]
        public void UpdateData_Valid_All_WhiteSpace_Description_Should_Update_Description()
        {
            // Arrange
            // The initial city
            var existingProduct = TestHelper.ProductService.GetAllData().First();

            // ProductModel used to update the database
            var updatedProduct = new ProductModel
            {
                Id = existingProduct.Id,
                Title = "Updated Title",
                Description = " "
            };

            // Act
            var result = TestHelper.ProductService.UpdateData(updatedProduct);

            // Assert
            Assert.AreEqual(true, result != null);
            Assert.AreEqual("", result.Description);
        }

        /// <summary>
        /// Test that UpdateData will update the description without leading or trailing white space
        /// </summary>
        [Test]
        public void UpdateData_Valid_Description_Should_Return_TrimmedDescription()
        {
            // Arrange

            // The initial city
            var existingProduct = TestHelper.ProductService.GetAllData().First();

            // ProductModel used to update the database
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

        /// <summary>
        /// Test that the description is updated without errors when a null description is used
        /// </summary>
        [Test]
        public void UpdateData_Valid_Null_Description_Should_Keep_Description_Null()
        {
            // Arrange

            // The initial city
            var existingProduct = TestHelper.ProductService.GetAllData().First();

            // ProductModel used to update the database
            var updatedProduct = new ProductModel
            {
                Id = existingProduct.Id,
                Title = "Updated Title",
                Description = null
            };

            // Act
            var result = TestHelper.ProductService.UpdateData(updatedProduct);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Description, Is.EqualTo(null));
        }

        #endregion UpdateData

        #region AddComment

        [Test]
        /// <summary>
        /// Comment gets added when for valid product
        /// </summary>
        public void AddComment_Valid_Product_Should_Add_Comment()
        {
            // Arrange
            var comment = "Great Place to visit";

            // Get the first data item
            var data = TestHelper.ProductService.GetAllData().First();

            //Act
            var result = TestHelper.ProductService.AddComment(data.Id, comment);

            // Get the city on which AddComment was just applied
            var dataNewList = TestHelper.ProductService.GetAllData().First();

            // Assert
            Assert.That(result, Is.True);
            Assert.That(dataNewList.CommentList, Contains.Item(comment));
        }

        [Test]
        public void AddComment_Valid_Duplicate_Comment_Should_Return_Add_Comment()
        {
          
            // Arrange
            var comment = "Great Place to visit";

            // Get the first data item
            var data = TestHelper.ProductService.GetAllData().Last();

            // Act
            var firstComment = TestHelper.ProductService.AddComment(data.Id, comment);
            var result = TestHelper.ProductService.AddComment(data.Id, comment);

            // Get the city on which AddComment was just applied
            var dataNewList = TestHelper.ProductService.GetAllData().Last();

            // Assert
            //Added 2 comments
            Assert.That(dataNewList.CommentList.Count, Is.EqualTo(2));
        }

        #endregion AddComment



    }
}