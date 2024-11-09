using ContosoCrafts.WebSite.Models;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UnitTests.Models
{
	/// <summary>
	/// Unit testing class for ProductModel
	/// </summary>
	public class ProductModelTests
    {
        #region Images

        /// <summary>
        /// Setting Product with all valid attributes should be successul
        /// </summary>
        [Test]
        public void Set_ProductModel_Valid_Should_Be_Validated()
        {
            // Arrange
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Images = new string[]
                {
                    "https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
                    "https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg",
                    "https://images.pexels.com/photos/161901/paris-sunset-france-monument-161901.jpeg",
                },
                Title = "Enter City Name",
                Description = "Enter City Description",
                BestSeason = null,
                Currency = "CUR",
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
            var validationResults = new List<ValidationResult>();

            // Act
            bool result = Validator.TryValidateObject(
                data, new ValidationContext(data), validationResults, true
            );

            // Reset

            // Assert
            Assert.AreEqual(true, result);
            Assert.AreEqual(0, validationResults.Count);
        }

        /// <summary>
        /// Setting Images to null should cause a validation error
        /// </summary>
        [Test]
		public void Set_Images_Invalid_Null_Should_Not_Be_Validated()
		{
			// Arrange
			var data = new ProductModel()
			{
				Id = System.Guid.NewGuid().ToString(),
				Images = null,
				Title = "Enter City Name",
				Description = "Enter City Description",
				BestSeason = null,
				Currency = "CUR",
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
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("Image URLs are required", validationResults[0].ErrorMessage);
		}

		/// <summary>
		/// Setting Images to empty array should cause a validation error
		/// </summary>
		[Test]
		public void Set_Images_Invalid_Empty_Array_Should_Not_Be_Validated()
		{
			// Arrange
			var data = new ProductModel()
			{
				Id = System.Guid.NewGuid().ToString(),
				Images = new string[0],
				Title = "Enter City Name",
				Description = "Enter City Description",
				BestSeason = null,
				Currency = "CUR",
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
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("3 Image URLs are required", validationResults[0].ErrorMessage);
		}

		/// <summary>
		/// Setting less than 3 Images should cause a validation error
		/// </summary>
		[Test]
		public void Set_Images_Invalid_Less_Than_3_Should_Not_Be_Validated()
		{
			// Arrange
			var data = new ProductModel()
			{
				Id = System.Guid.NewGuid().ToString(),
				Images = new string[]
				{
					"https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
					"https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg"
				},
				Title = "Enter City Name",
				Description = "Enter City Description",
				BestSeason = null,
				Currency = "CUR",
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
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("3 Image URLs are required", validationResults[0].ErrorMessage);
		}

		/// <summary>
		/// Setting more than 3 Images should cause a validation error
		/// </summary>
		[Test]
		public void Set_Images_Invalid_Greater_Than_3_Should_Not_Be_Validated()
		{
			// Arrange
			var data = new ProductModel()
			{
				Id = System.Guid.NewGuid().ToString(),
				Images = new string[]
				{
					"https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
					"https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg",
					"https://images.pexels.com/photos/161901/paris-sunset-france-monument-161901.jpeg",
					"https://images.pexels.com/photos/753639/pexels-photo-753639.jpeg"
				},
				Title = "Enter City Name",
				Description = "Enter City Description",
				BestSeason = null,
				Currency = "CUR",
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
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("No more than 3 Image URLs are allowed", validationResults[0].ErrorMessage);
		}

		/// <summary>
		/// Setting null element in Images should cause a validation error
		/// </summary>
		[Test]
		public void Set_Images_Invalid_Null_Element_Should_Not_Be_Validated()
		{
			// Arrange
			var data = new ProductModel()
			{
				Id = System.Guid.NewGuid().ToString(),
				Images = new string[]
				{
					"https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
					"https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg",
					null,
				},
				Title = "Enter City Name",
				Description = "Enter City Description",
				BestSeason = null,
				Currency = "CUR",
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
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("Image #3 URL is null", validationResults[0].ErrorMessage);
		}

		/// <summary>
		/// Setting empty string in Images should cause a validation error
		/// </summary>
		[Test]
		public void Set_Images_Invalid_Empty_String_Should_Not_Be_Validated()
		{
			// Arrange
			var data = new ProductModel()
			{
				Id = System.Guid.NewGuid().ToString(),
				Images = new string[]
				{
					"https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
					"https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg",
					"",
				},
				Title = "Enter City Name",
				Description = "Enter City Description",
				BestSeason = null,
				Currency = "CUR",
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
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("Image #3 URL is empty", validationResults[0].ErrorMessage);
		}

		/// <summary>
		/// Setting invalid URL in Images should cause a validation error
		/// </summary>
		[Test]
		public void Set_Images_Invalid_URL_Should_Not_Be_Validated()
		{
			// Arrange
			var data = new ProductModel()
			{
				Id = System.Guid.NewGuid().ToString(),
				Images = new string[]
				{
					"https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
					"https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg",
					"invalid-url",
				},
				Title = "Enter City Name",
				Description = "Enter City Description",
				BestSeason = null,
				Currency = "CUR",
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
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("Image #3 URL is not valid", validationResults[0].ErrorMessage);
		}

		/// <summary>
		/// Setting URL that does not have image extension in Images should cause a validation error
		/// </summary>
		[Test]
		public void Set_Images_Invalid_URL_Not_Image_Should_Not_Be_Validated()
		{
			// Arrange
			var data = new ProductModel()
			{
				Id = System.Guid.NewGuid().ToString(),
				Images = new string[]
				{
					"https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
					"https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg",
                    "https://www.wikipedia.org/",
				},
				Title = "Enter City Name",
				Description = "Enter City Description",
				BestSeason = null,
				Currency = "CUR",
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
			var validationResults = new List<ValidationResult>();

			// Act
			bool result = Validator.TryValidateObject(
				data, new ValidationContext(data), validationResults, true
			);

			// Reset

			// Assert
			Assert.AreEqual(false, result);
			Assert.AreEqual("Image #3 URL does not end in image extension", validationResults[0].ErrorMessage);
		}

        #endregion Images

        #region Title

        /// <summary>
        /// Setting Title to null should cause a validation error
        /// </summary>
        [Test]
        public void Set_Title_Invalid_Null_Should_Cause_Validation_Error()
        {
            // Arrange
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Images = new string[]
                {
                    "https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
                    "https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg",
                    "https://images.pexels.com/photos/161901/paris-sunset-france-monument-161901.jpeg",
                },
                Title = null,
                Description = "Enter City Description",
                BestSeason = null,
                Currency = "CUR",
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
            var validationResults = new List<ValidationResult>();

            // Act
            bool result = Validator.TryValidateObject(
                data, new ValidationContext(data), validationResults, true
            );

            // Reset

            // Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual("Title is required", validationResults[0].ErrorMessage);
        }

        /// <summary>
        /// Setting Title to empty string should cause a validation error
        /// </summary>
        [Test]
        public void Set_Title_Invalid_Empty_String_Should_Cause_Validation_Error()
        {
            // Arrange
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Images = new string[]
                {
                    "https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
                    "https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg",
                    "https://images.pexels.com/photos/161901/paris-sunset-france-monument-161901.jpeg",
                },
                Title = "",
                Description = "Enter City Description",
                BestSeason = null,
                Currency = "CUR",
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
            var validationResults = new List<ValidationResult>();

            // Act
            bool result = Validator.TryValidateObject(
                data, new ValidationContext(data), validationResults, true
            );

            // Reset

            // Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual("Title is required", validationResults[0].ErrorMessage);
        }

        /// <summary>
        /// Setting Title to string exceeding maximum length should cause a validation error
        /// </summary>
        [Test]
        public void Set_Title_Invalid_String_Too_Long_Should_Cause_Validation_Error()
        {
            // Arrange
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Images = new string[]
                {
                    "https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
                    "https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg",
                    "https://images.pexels.com/photos/161901/paris-sunset-france-monument-161901.jpeg",
                },
                Title = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA",
                Description = "Enter City Description",
                BestSeason = null,
                Currency = "CUR",
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
            var validationResults = new List<ValidationResult>();

            // Act
            bool result = Validator.TryValidateObject(
                data, new ValidationContext(data), validationResults, true
            );

            // Reset

            // Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual("The Title should have a length of more than 1 and less than 33", validationResults[0].ErrorMessage);
        }

        #endregion Title

        #region Description

        /// <summary>
        /// Setting Description to string exceeding maximum length should cause a validation error
        /// </summary>
        [Test]
        public void Set_Description_Invalid_String_Too_Long_Should_Cause_Validation_Error()
        {
            // Arrange
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Images = new string[]
                {
                    "https://images.pexels.com/photos/1308940/pexels-photo-1308940.jpeg",
                    "https://images.pexels.com/photos/2363/france-landmark-lights-night.jpg",
                    "https://images.pexels.com/photos/161901/paris-sunset-france-monument-161901.jpeg",
                },
                Title = "Enter City Name",
                Description = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor. Aenean massa. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec quam felis, ultricies nec, pellentesque eu, pretium quis, sem. Nulla consequat massa quis enim. Donec pede justo, fringilla vel, aliquet nec, vulputate eget, arcu. In enim justo, rhoncus ut, imperdiet a, venenatis vitae, justo. Nullam dictum felis eu pede mollis pretium. Integer tincidunt. Cras dapibus. Vivamus elementum semper nisi. Aenean vulputate eleifend tellus. Aenean leo ligula, porttitor eu, consequat vitae, eleifend ac, enim. Aliquam lorem ante, dapibus in, viverra quis, feugiat a, tellus. Phasellus viverra nulla ut metus varius laoreet. Quisque rutrum. Aenean imperdiet. Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc, quis gravida magna mi a libero. Fusce vulputate eleifend sapien. Vestibulum purus quam, scelerisque ut, mollis sed, nonummy id, metus. Nullam accumsan lorem in dui. Cras ultricies mi eu turpis hendrerit fringilla. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; In ac dui quis mi consectetuer lacinia. Nam pretium turpis et arcu. Duis arcu tortor, suscipit eget, imperdiet nec, imperdiet iaculis, ipsum. Sed aliquam ultrices mauris. Integer ante arcu, accumsan a, consectetuer eget, posuere ut, mauris. Praesent adipiscing. Phasellus ullamcorper ipsum rutrum nunc. Nunc nonummy metus. Vestibulum volutpat pretium libero. Cras id dui. Aenean ut eros et nisl sagittis vestibulum. Nullam nulla eros, ultricies sit amet, nonummy id, imperdiet feugiat, pede. Sed lectus. Donec mollis hendrerit risus. Phasellus nec sem in justo pellentesque facilisis. Etiam imperdiet imperdiet orci. Nunc nec neque. Phasellus leo dolor, tempus non, auctor et, hendrerit quis, nisi. Curabitur ligula sapien, tincidunt non, euismod vitae, posuere imperdiet, leo. Maecenas malesuada. Praesent congue erat at massa. Sed cursus turpis vitae tortor. Donec posuere vulputate arcu. Phasellus accumsan cursus velit. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Sed aliquam, nisi quis porttitor congue, elit erat euismod orci, ac placerat dolor lectus quis orci. Phasellus consectetuer vestibulum elit. Aenean tellus metus, bibendum sed, posuere ac, mattis non, nunc. Vestibulum fringilla pede sit amet augue. In turpis. Pellentesque posuere. Praesent turpis. Aenean posuere, tortor sed cursus feugiat, nunc augue blandit nunc, eu sollicitudin urna dolor sagittis lacus. Donec elit libero, sodales nec, volutpat a, suscipit non, turpis. Nullam sagittis. Suspendisse pulvinar, augue ac venenatis condimentum, sem libero volutpat nibh, nec pellentesque velit pede quis nunc. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Fusce id purus. Ut varius tincidunt libero. Phasellus dolor. Maecenas vestibulum mollis diam. Pellentesque ut neque. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. In dui magna, posuere eget, vestibulum et, tempor auctor, justo. In ac felis quis tortor malesuada pretium. Pellentesque auctor neque nec urna. Proin sapien ipsum, porta a, auctor quis, euismod ut, mi. Aenean viverra rhoncus pede. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Ut non enim eleifend felis pretium feugiat. Vivamus quis mi. Phasellus a est. Phasellus magna. In hac habitasse platea dictumst. Curabitur at lacus ac velit ornare lobortis. Curabitur a felis in nunc fringilla tristique. Morbi mattis ullamcorper velit. Phasellus gravida semper nisi. Nullam vel sem. Pellentesque libero tortor, tincidunt et, tincidunt eget, semper nec, quam. Sed hendrerit. Morbi ac felis. Nunc egestas, augue at pellentesque laoreet, felis eros vehicula leo, at malesuada velit leo quis pede. Donec interdum, metus et hendrerit aliquet, dolor diam sagittis ligula, eget egestas libero turpis vel mi. Nunc nulla. Fusce risus nisl, viverra et, tempor et, pretium in, sapien. Donec venenatis vulputate lorem. Morbi nec metus. Phasellus blandit leo ut odio. Maecenas ullamcorper, dui et placerat feugiat, eros pede varius nisi, condimentum viverra felis nunc et lorem. Sed magna purus, fermentum eu, tincidunt eu, varius ut, felis. In auctor lobortis lacus. Quisque libero metus, condimentum nec, tempor a, commodo mollis, magna. Vestibulum ullamcorper mauris at ligula",
                BestSeason = null,
                Currency = "CUR",
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
            var validationResults = new List<ValidationResult>();

            // Act
            bool result = Validator.TryValidateObject(
                data, new ValidationContext(data), validationResults, true
            );

            // Reset

            // Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual("The Description should have a length of less than 5000", validationResults[0].ErrorMessage);
        }

        #endregion Description

        #region GetCityRating

        /// <summary>
        /// Test that a call of GetCityRating() on a city with no ratings should return 0
        /// </summary>
        [Test]
		public void GetCityRating_Invalid_Test_Ratings_Null_Should_Return_0_True()
		{
			// Arrange
			var data = new ProductModel();

			// Act
			var result = data.GetCityRating();

			// Reset

			// Assert
			Assert.AreEqual(0, result);
		}

		/// <summary>
		/// Test that a call of GetCityRating() on a city with only one rating should return its
		/// average rating
		/// </summary>
		[Test]
		public void GetCityRating_Valid_Test_Single_Rating_Should_Return_Rating_True()
		{
			// Arrange
			var data = new ProductModel()
			{
				// Fill city with valid Rating
				Ratings = new[] { 1 }
			};

			// Act
			var result = data.GetCityRating();

			// Reset

			// Assert
			Assert.AreEqual(1, result);
		}

		/// <summary>
		/// Test that a call of GetCityRating() on a city with ratings should return its average rating
		/// </summary>
		[Test]
		public void GetCityRating_Valid_Test_Multiple_Ratings_Should_Return_Average_Rating_True()
		{
			// Arrange
			var data = new ProductModel()
			{
				// Fill city with valid Ratings
				Ratings = new[] { 2, 1, 4, 2, 5, 4, 2, 5, 3 }
			};

			// Act
			var result = data.GetCityRating();

			// Reset

			// Assert
			Assert.AreEqual(3, result);
		}

		#endregion GetCityRating
	}
}