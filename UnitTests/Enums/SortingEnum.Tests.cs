using ContosoCrafts.WebSite.Enums;
using NUnit.Framework;

namespace UnitTests.Enums
{
    /// <summary>
	/// Unit testing class for SortingEnum
	/// </summary>
    public class SortingEnumTests
    {
        #region DisplayName

        /// <summary>
        /// Test that DisplayName returns the correct result when the SortingEnum has not been set
        /// </summary>
        [Test]
        public void DisplayName_Valid_No_Selection_Should_Return_Sort_Prompt()
        {
            // Arrange
            var data = new SortingEnum();

            // Act
            var result = data.DisplayName();

            // Assert
            Assert.AreEqual(true, result.Equals("Sort by..."));
        }

        /// <summary>
        /// Test that DisplayName returns the correct result when the SortingEnum has been set to "Undefined"
        /// </summary>
        [Test]
        public void DisplayName_Valid_Undefined_Selected_Should_Return_Sort_Prompt()
        {
            // Arrange
            var data = SortingEnum.Undefined;

            // Act
            var result = data.DisplayName();

            // Assert
            Assert.AreEqual(true, result.Equals("Sort by..."));
        }

        /// <summary>
        /// Test that DisplayName returns the correct result when the SortingEnum has been set to "Rating"
        /// </summary>
        [Test]
        public void DisplayName_Valid_Rating_Selected_Should_Return_Rating()
        {
            // Arrange
            var data = SortingEnum.Rating;

            // Act
            var result = data.DisplayName();

            // Assert
            Assert.AreEqual(true, result.Equals("Rating"));
        }

        /// <summary>
        /// Test that DisplayName returns the correct result when the SortingEnum has been set to "TravelTime"
        /// </summary>
        [Test]
        public void DisplayName_Valid_TravelTime_Selected_Should_Return_Travel_Time()
        {
            // Arrange
            var data = SortingEnum.TravelTime;

            // Act
            var result = data.DisplayName();

            // Assert
            Assert.AreEqual(true, result.Equals("Travel Time"));
        }

        /// <summary>
        /// Test that DisplayName returns the correct result when the SortingEnum has been set to "Cost"
        /// </summary>
        [Test]
        public void DisplayName_Valid_Cost_Selected_Should_Return_Cost()
        {
            // Arrange
            var data = SortingEnum.Cost;

            // Act
            var result = data.DisplayName();

            // Assert
            Assert.AreEqual(true, result.Equals("Cost"));
        }

        #endregion DisplayName
    }
}
