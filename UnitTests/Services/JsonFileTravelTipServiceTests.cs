
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Services
{
	/// <summary>
	/// Unit testing class for JsonFileTravelTipService
	/// </summary>
	public class JsonFileTravelTipServiceTests
	{
		#region CreateData

		/// <summary>
		/// Test that CreateData returns a TravelTipsModel object with the expected default values
		/// </summary>
		[Test]
		public void CreateData_Valid_Default_Should_Return_Default_Fields()
		{
			// Arrange
			var data = new TravelTipsModel
			{
				Id = System.Guid.NewGuid().ToString(),
				Title = null,
				Description = null,
			};

			// Act
			var result = TestHelper.TravelTipService.CreateData();

			// Assert
			Assert.AreEqual(data.Title, result.Title);
			Assert.AreEqual(data.Description, result.Description);
		}

		#endregion CreateData

		#region UpdateData

		/// <summary>
		/// Test UpdateData method when tip exists in the data source
		/// </summary>
		[Test]
		public void UpdateData_Valid_ExistingTravelTip_Should_Return_UpdatedTravelTip()
        {
			// Arrange

			// the initial travel tip
			var existingTravelTip = TestHelper.TravelTipService.GetAllData().First();

			// TravelTipModel used to update the travel tip in the database
			var updatedTravelTip = new TravelTipsModel
			{
				Id = existingTravelTip.Id,
				Title = "Updated Title",
				Description = "Updated Description",
			};

			// Act
			var result = TestHelper.TravelTipService.UpdateData(updatedTravelTip);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.AreEqual("Updated Title", result.Title);
			Assert.AreEqual("Updated Description", result.Description);
		}

		/// <summary>
		/// Test UpdateData method when tip does not exist in the data source
		/// </summary>
		[Test]
		public void UpdateData_Should_Return_Null_If_TravelTip_Not_Found()
		{
			// Arrange
			var data = new TravelTipsModel
			{
				Id = System.Guid.NewGuid().ToString(),
				Title = "Non-existent Travel Tip",
				Description = "Non-existent Description"
			};

			// Act
			var result = TestHelper.TravelTipService.UpdateData(data);

			// Assert
			Assert.AreEqual(null, result);
		}

		/// <summary>
		/// Test UpdateData method when description has extra spaces
		/// </summary>
		[Test]
		public void UpdateData_Valid_Description_Should_Return_TrimmedDescription()
        {
			// Arrange
			var data = new TravelTipsModel
			{
				Id = TestHelper.TravelTipService.GetAllData().First().Id,
				Title = "Updated Title",
				Description = "  Updated Description with extra spaces  "
			};

			// Act
			var result = TestHelper.TravelTipService.UpdateData(data);

			// Assert
			Assert.That(result, Is.Not.Null);
			Assert.AreEqual("Updated Description with extra spaces", result.Description);
		}

		/// <summary>
		/// Test that description is successfully updated when the description contains only whitespace
		/// </summary>
		[Test]
		public void UpdateData_Valid_All_WhiteSpace_Description_Should_Update_Description()
		{
			// Arrange
			
			// the initial travel tip
			var existingProduct = TestHelper.TravelTipService.GetAllData().First();

			// TravelTipModel used to update the travel tip in the database
			var updatedTravelTip = new TravelTipsModel
			{
				Id = existingProduct.Id,
				Title = "Updated Title",
				Description = " "
			};

			// Act
			var result = TestHelper.TravelTipService.UpdateData(updatedTravelTip);

			// Assert
			Assert.AreEqual(true, result != null);
			Assert.AreEqual("", result.Description);
		}

        /// <summary>
        /// Test that the description is updated without errors when a null description is used
        /// </summary>
        [Test]
        public void UpdateData_Valid_Null_Description_Should_Keep_Description_Null()
        {
            // Arrange

            // the initial travel tip
            var existingProduct = TestHelper.TravelTipService.GetAllData().First();

            // TravelTipModel used to update the travel tip in the database
            var updatedTravelTip = new TravelTipsModel
            {
                Id = existingProduct.Id,
                Title = "Updated Title",
                Description = null
            };

            // Act
            var result = TestHelper.TravelTipService.UpdateData(updatedTravelTip);

            // Assert
            Assert.AreEqual(true, result != null);
            Assert.AreEqual(null, result.Description);
        }

        #endregion UpdateData

        #region DeleteData

        /// <summary>
        /// Test that DeleteData returns null if a null id is passed
        /// </summary>
        [Test]
		public void DeleteData_Null_Id_Default_Should_Return_Null()
		{
			// Arrange

			// Act
			var result = TestHelper.TravelTipService.DeleteData(null);

			// Assert
			Assert.AreEqual(null, result);
		}

		/// <summary>
		/// Test that DeleteData returns null if an invalid id is passed
		/// </summary>
		[Test]
		public void DeleteData_Invalid_Id_Default_Should_Return_Null()
		{
			// Arrange

			// Act
			var result = TestHelper.TravelTipService.DeleteData("invalid_id");

			// Assert
			Assert.AreEqual(null, result);
		}

		/// <summary>
		/// Test that DeleteData successfully deletes the travel tip matching a valid id
		/// and returns the TravelTipsModel object associated with that record
		/// </summary>
		[Test]
		public void DeleteData_Valid_Id_Default_Should_Return_Deleted_Tip()
		{
			// Arrange

			// the first travel tip retrieved the database
			var data = TestHelper.TravelTipService.GetAllData().First();

			// the id of the retrieved travel tip
			var id = data.Id;

			// Act

			// delete the first travel tip from the database
			var result = TestHelper.TravelTipService.DeleteData(id);

			// Assert
			Assert.AreEqual(null, TestHelper.TravelTipService.GetAllData().FirstOrDefault(x => x.Id == id));
			Assert.AreEqual(data.Id, result.Id);
			Assert.AreEqual(data.Title, result.Title);
			Assert.AreEqual(data.Description, result.Description);
		}

		#endregion DeleteData
	}
}