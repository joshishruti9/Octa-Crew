using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;
using Bunit;
using System.Linq;

namespace UnitTests.Components
{
    /// <summary>
    /// Unit test class for the Products Controller
    /// </summary>
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        /// <summary>
        /// Setup for ProductListTests
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

        #region Content

        /// <summary>
        /// ProductList should have a working page that does not contain material from original
        /// site
        /// </summary>
        [Test]
        public void ProductList_Valid_Default_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Act
            var page = RenderComponent<ProductList>();

            // Get the Cards returned
            var result = page.Markup;

            // Assert
            Assert.AreEqual(false, result.Contains("The Quantified Cactus: An Easy Plant Soil Moisture Sensor"));
        }

        /// <summary>
        /// Selecting the Explore More button for a valid city should open popup
        /// </summary>
        [Test]
        public void SelectProduct_Valid_ID_paris_Should_Return_Content()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Button to test clicking
            var id = "ExploreMoreButton_paris";

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Find the Buttons (explore more)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Act
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Reset

            // Assert
            Assert.AreEqual(true, pageMarkup.Contains(
                "Full of iconic monuments, world class art, and delicious cuisine, Paris is a must see city.  As one of the fashion capitals of the world, Paris offers the chance to shop at some of the biggest designers or in countless boutiques.  The city blends history and modernity, offering endless opportunities to explore, from sidewalk cafes to picturesque neighborhoods.  You won’t run out of things to do in Paris."
            ));
        }

        #endregion Content

        #region SubmitRating

        /// <summary>
        /// Adding a rating to an unrated city should update vote count and rating
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Click_Unstarred_Should_Increment_Count_And_Check_Star()
        {
            /*
             * This test tests that the SubmitRating will change the vote as well as the Star
             * checked.
             * Because the star check is a calculation of the ratings, using a record that has no
             * stars and checking one makes it clear what was changed.
             * 
             * The test needs to open the page,
             * Then open the popup on the card,
             * Then record the state of the count and star check status,
             * Then check a star,
             * Then check again the state of the count and star check status.
             */

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Button for city to rate
            var id = "ExploreMoreButton_rome";

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Find the Buttons (Explore More)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements,
            // element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];

            // String for vote count
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the First star item from the list, it should not be checked
            var starButton = starButtonList.First(m =>
                string.IsNullOrEmpty(m.ClassName) == false
                && m.ClassName.Contains("fa fa-star")
            );

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];

            // String for vote count
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last starred item from the list
            starButton = starButtonList.First(m =>
                string.IsNullOrEmpty(m.ClassName) == false
                && m.ClassName.Contains("fa fa-star checked")
            );

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Reset

            // Assert

            // Confirm that the record had no votes to start, and 1 vote after
            Assert.AreEqual(true, preVoteCountString.Contains("Be the first to vote!"));
            Assert.AreEqual(true, postVoteCountString.Contains("1 Vote"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }

        /// <summary>
        /// Adding a rating to an already rated city should update vote count and rating
        /// </summary>
        [Test]
        public void SubmitRating_Valid_ID_Click_Starred_Should_Increment_Count()
        {
            /*
             * This test tests that the SubmitRating will change the vote count for an already rated city.
             * 
             * The test needs to open the page,
             * Then open the popup on the card,
             * Then record the state of the count,
             * Then check a star,
             * Then check again the state of the count.
             */

            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Button for city to rate
            var id = "ExploreMoreButton_paris";

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Find the Buttons (Explore More)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));
            button.Click();

            // Get the markup of the page post the Click action
            var buttonMarkup = page.Markup;

            // Get the Star Buttons
            var starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements,
            // element 2 is the string for the count
            var preVoteCountSpan = starButtonList[1];

            // String for vote count
            var preVoteCountString = preVoteCountSpan.OuterHtml;

            // Get the First star item from the list, it should be checked
            var starButton = starButtonList.First(m =>
                string.IsNullOrEmpty(m.ClassName) == false
                && m.ClassName.Contains("fa fa-star checked")
            );

            // Save the html for it to compare after the click
            var preStarChange = starButton.OuterHtml;

            // Act

            // Click the star button
            starButton.Click();

            // Get the markup to use for the assert
            buttonMarkup = page.Markup;

            // Get the Star Buttons
            starButtonList = page.FindAll("span");

            // Get the Vote Count, the List should have 7 elements, element 2 is the string for the count
            var postVoteCountSpan = starButtonList[1];

            // String for vote count
            var postVoteCountString = postVoteCountSpan.OuterHtml;

            // Get the Last starred item from the list
            starButton = starButtonList.First(m =>
                string.IsNullOrEmpty(m.ClassName) == false
                && m.ClassName.Contains("fa fa-star checked")
            );

            // Save the html for it to compare after the click
            var postStarChange = starButton.OuterHtml;

            // Reset

            // Assert

            // Confirm that the record had 6 votes to start, and 7 votes after
            Assert.AreEqual(true, preVoteCountString.Contains("6 Votes"));
            Assert.AreEqual(true, postVoteCountString.Contains("7 Votes"));
            Assert.AreEqual(false, preVoteCountString.Equals(postVoteCountString));
        }

        #endregion SubmitRating

        #region Filter

        /// <summary>
        /// Selecting All Seasons in season dropdown should not filter out any cities
        /// </summary>
        [Test]
        public void OnSeasonFilterChange_All_Seasons_Should_Return_All_Cities()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Act

            // Find the season dropdown
            var dropdown = page.Find("select.seasonDropDown");

            // Select "All Seasons" from the dropdown
            dropdown.Change("0");

            // Get the page markup
            var pageMarkup = page.Markup;

            // Reset

            // Assert
            // Check that at least one city for each season appears

            // Check that the Tokyo card appears (spring)
            Assert.AreEqual(true, pageMarkup.Contains("card_tokyo"));

            // Check that the London card appears (summer)
            Assert.AreEqual(true, pageMarkup.Contains("card_london"));

            // Check that the Paris card appears
            Assert.AreEqual(true, pageMarkup.Contains("card_paris"));

            // Check that the Dubai card appears
            Assert.AreEqual(true, pageMarkup.Contains("card_dubai"));
        }

        /// <summary>
        /// Selecting Spring in season dropdown should filter out cities whose best season is not
        /// spring
        /// </summary>
        [Test]
        public void OnSeasonFilterChange_Spring_Should_Filter_By_Season()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Act

            // Find the season dropdown
            var dropdown = page.Find("select.seasonDropDown");

            // Select "Spring" from the dropdown
            dropdown.Change("1");

            // Get the page markup
            var pageMarkup = page.Markup;

            // Reset

            // Assert

            // Check that the Tokyo card appears
            Assert.AreEqual(true, pageMarkup.Contains("card_tokyo"));

            // Check that the Paris card does not appear
            Assert.AreEqual(false, pageMarkup.Contains("card_paris"));
        }

        /// <summary>
        /// Selecting Summer in season dropdown should filter out cities whose best season is not
        /// summer
        /// </summary>
        [Test]
        public void OnSeasonFilterChange_Summer_Should_Filter_By_Season()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Act

            // Find the season dropdown
            var dropdown = page.Find("select.seasonDropDown");

            // Select "Summer" from the dropdown
            dropdown.Change("2");

            // Get the page markup
            var pageMarkup = page.Markup;

            // Reset

            // Assert

            // Check that the London card appears
            Assert.AreEqual(true, pageMarkup.Contains("card_london"));

            // Check that the Paris card does not appear
            Assert.AreEqual(false, pageMarkup.Contains("card_paris"));
        }

        /// <summary>
        /// Selecting Fall in season dropdown should filter out cities whose best season is not
        /// fall
        /// </summary>
        [Test]
        public void OnSeasonFilterChange_Fall_Should_Filter_By_Season()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Act

            // Find the season dropdown
            var dropdown = page.Find("select.seasonDropDown");

            // Select "Fall" from the dropdown
            dropdown.Change("3");

            // Get the page markup
            var pageMarkup = page.Markup;

            // Reset

            // Assert

            // Check that the Paris card appears
            Assert.AreEqual(true, pageMarkup.Contains("card_paris"));

            // Check that the London card does not appear
            Assert.AreEqual(false, pageMarkup.Contains("card_london"));
        }

        /// <summary>
        /// Selecting Winter in season dropdown should filter out cities whose best season is not
        /// winter
        /// </summary>
        [Test]
        public void OnSeasonFilterChange_Winter_Should_Filter_By_Season()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Act

            // Find the season dropdown
            var dropdown = page.Find("select.seasonDropDown");

            // Select "Winter" from the dropdown
            dropdown.Change("4");

            // Get the page markup
            var pageMarkup = page.Markup;

            // Reset

            // Assert

            // Check that the Dubai card appears
            Assert.AreEqual(true, pageMarkup.Contains("card_dubai"));

            // Check that the London card does not appear
            Assert.AreEqual(false, pageMarkup.Contains("card_london"));
        }

        /// <summary>
        /// Changing BestSeason filter to blank value should not filter out cities
        /// </summary>
        [Test]
        public void OnSeasonFilterChange_Blank_Should_Not_Filter_Cities()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Act

            // Set a blank value in dropdown
            var dropdown = page.Find("select.seasonDropDown");
            dropdown.Change("");

            // Get the page markup after calling
            var pageMarkup = page.Markup;

            // Reset

            // Assert

            // Check that at least one city for each season appears

            // Check that the Tokyo card appears (spring)
            Assert.AreEqual(true, pageMarkup.Contains("card_tokyo"));

            // Check that the London card appears (summer)
            Assert.AreEqual(true, pageMarkup.Contains("card_london"));

            // Check that the Paris card appears
            Assert.AreEqual(true, pageMarkup.Contains("card_paris"));

            // Check that the Dubai card appears
            Assert.AreEqual(true, pageMarkup.Contains("card_dubai"));
        }

        /// <summary>
        /// Typing a city name and pressing enter should filter cities by title
        /// </summary>
        [Test]
        public void GetFilteredProducts_Search_By_Title_Should_Return_Matching_Cities()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Act

            // Set the search text to "Tokyo"
            var searchBox = page.Find("input[placeholder='Search by Title...']");
            searchBox.Change("Tokyo");

            // Get the rendered markup
            var pageMarkup = page.Markup;

            // Reset

            // Assert

            // Check that Tokyo appears in the results
            Assert.AreEqual(true, pageMarkup.Contains("card_tokyo"));

            // Check that Paris does not appear because it doesn't match the title
            Assert.AreEqual(false, pageMarkup.Contains("card_paris"));
        }

        #endregion Filter
    }
}