using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;
using Bunit;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using Bunit.Extensions;
using ContosoCrafts.WebSite.Enums;

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

            // Get the First star item, it should not be checked
            var starButton = page.Find(".fa.fa-star");

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

            // Get the Last starred item
            starButton = page.Find(".fa.fa-star.checked");

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

            // Get the First star item, it should be checked
            var starButton = page.Find(".fa.fa-star.checked");

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

            // Get the Last starred item
            starButton = page.Find(".fa.fa-star.checked");

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
        /// Selecting All Seasons in season dropdown should not filter out any productModels
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
        /// Selecting Spring in season dropdown should filter out productModels whose best season is not
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
        /// Selecting Summer in season dropdown should filter out productModels whose best season is not
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
        /// Selecting Fall in season dropdown should filter out productModels whose best season is not
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
        /// Selecting Winter in season dropdown should filter out productModels whose best season is not
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
        /// Changing BestSeason filter to null value should not filter out productModels
        /// </summary>
        [Test]
        public void OnSeasonFilterChange_Null_Should_Not_Filter_Cities()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Act

            // Set a null value in dropdown
            var dropdown = page.Find("select.seasonDropDown");
            dropdown.Change(null as string);

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
        /// Changing BestSeason filter to blank value should not filter out productModels
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
        /// Changing BestSeason filter to invalid value should not filter out productModels
        /// </summary>
        [Test]
        public void OnSeasonFilterChange_Invalid_Value_Should_Not_Filter_Cities()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Act

            // Set an invalid value in dropdown
            var dropdown = page.Find("select.seasonDropDown");
            dropdown.Change("5");

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
        /// Typing a city name and pressing enter should filter productModels by title
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

        /// <summary>
        /// Typing a maximum cost and pressing enter should filter productModels by cost
        /// </summary>
        [Test]
        public void GetFilteredProducts_Filter_By_Cost_Should_Return_Matching_Cities()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Act

            // Set the maximum cost to 1790
            var searchBox = page.Find("input[placeholder='Enter Maximum Cost...']");
            searchBox.Change("1790");

            // Get the rendered markup
            var pageMarkup = page.Markup;

            // Reset

            // Assert

            // Check that Bangkok appears in the results
            Assert.AreEqual(true, pageMarkup.Contains("card_bangkok"));

            // Check that Prague does not appear because its cost is too high
            Assert.AreEqual(false, pageMarkup.Contains("card_prague"));
        }

        /// <summary>
        /// Typing a maximum travel time and pressing enter should filter productModels by travel time
        /// </summary>
        [Test]
        public void GetFilteredProducts_Filter_By_TravelTime_Should_Return_Matching_Cities()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Act

            // Set the maximum travel time to 5.1
            var searchBox = page.Find("input[placeholder='Enter Maximum Travel Time...']");
            searchBox.Change("5");

            // Get the rendered markup
            var pageMarkup = page.Markup;

            // Reset

            // Assert

            // Check that Vancouver appears in the results
            Assert.AreEqual(true, pageMarkup.Contains("card_vancouver"));

            // Check that New York appears in the results
            Assert.AreEqual(true, pageMarkup.Contains("card_new-york-city"));

            // Check that Montreal does not appear because its travel time is too high
            Assert.AreEqual(false, pageMarkup.Contains("card-montreal"));
        }

        /// <summary>
        /// Setting maximum travel time to null should return all products
        /// </summary>
        [Test]
        public void GetFilteredProducts_Filter_By_TravelTime_Null_Should_Return_All_Cities()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Act

            // Set the maximum travel time to null
            var searchBox = page.Find("input[placeholder='Enter Maximum Travel Time...']");
            searchBox.Change(null as string);

            // Get the rendered markup
            var pageMarkup = page.Markup;

            // Reset

            // Assert

            // Check for cities with lowest and highest travel times
            // to ensure the entire range of travel times is being returned

            // Check that Vancouver appears in the results (lowest travel time)
            Assert.AreEqual(true, pageMarkup.Contains("card_vancouver"));

            // Check that Cape Town appears (highest travel time)
            Assert.AreEqual(true, pageMarkup.Contains("card_cape-town"));
        }

        /// <summary>
        /// Setting maximum travel time to zero should return all products
        /// </summary>
        [Test]
        public void GetFilteredProducts_Filter_By_TravelTime_Zero_Should_Return_All_Cities()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // Render the ProductList component
            var page = RenderComponent<ProductList>();

            // Act

            // Set the maximum travel time to null
            var searchBox = page.Find("input[placeholder='Enter Maximum Travel Time...']");
            searchBox.Change("0");

            // Get the rendered markup
            var pageMarkup = page.Markup;

            // Reset

            // Assert

            // Check for cities with lowest and highest travel times
            // to ensure the entire range of travel times is being returned

            // Check that Vancouver appears in the results (lowest travel time)
            Assert.AreEqual(true, pageMarkup.Contains("card_vancouver"));

            // Check that Cape Town appears (highest travel time)
            Assert.AreEqual(true, pageMarkup.Contains("card_cape-town"));
        }

        #endregion Filter

        #region GetSortedProducts

        /// <summary>
        /// Test that cities appear in expected order after sorting by rating
        /// </summary>
        [Test]
        public void GetSortedProducts_Valid_Rating_Selected_Should_Return_Cities_Sorted_By_Rating()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // The HTML page
            var page = RenderComponent<ProductList>();

            // Find the select element for the sorting option dropdown
            var select = page.Find("#sorting-dropdown");

            // Act

            // Select Rating from the dropdown
            select.Change(SortingEnum.Rating.DisplayName());

            // The list of cards representing each city
            var products = page.FindAll(".card-rows div.card");

            // The list of all ProductModel objects represented in the database
            var productModels = TestHelper.ProductService.GetAllData();

            // The highest average rating in the database
            int highestRating = productModels.Max(x => x.GetCityRating());

            // The lowest average rating in the database
            int lowestRating = productModels.Min(x => x.GetCityRating());

            // Find the productModels with the highest rating
            var highestRated = productModels.Where(x => x.GetCityRating() == highestRating);

            // Find the productModels with the lowest rating
            var lowestRated = productModels.Where(x => x.GetCityRating() == lowestRating);

            // Find the city among the highest rated productModels matching the first card rendered on the page
            var highestId = highestRated.Where(x => products.First().Id.Contains(x.Id));

            // Find the city among the lowest rated productModels matching the last card rendered on the page
            var lowestId = lowestRated.Where(x => products.Last().Id.Contains(x.Id));

            // Assert
            Assert.AreEqual(false, highestId.IsNullOrEmpty());
            Assert.AreEqual(false, lowestId.IsNullOrEmpty());
        }

        /// <summary>
        /// Test that cities appear in expected order after sorting by travel time
        /// </summary>
        [Test]
        public void GetSortedProducts_Valid_TravelTime_Selected_Should_Return_Cities_Sorted_By_Travel_Time()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // The HTML page
            var page = RenderComponent<ProductList>();

            // Find the select element for the sorting option dropdown
            var select = page.Find("#sorting-dropdown");

            // Act

            // Select Travel Time from the dropdown
            select.Change(SortingEnum.TravelTime);

            // The list of cards representing each city
            var products = page.FindAll(".card-rows div.card");

            // The list of all ProductModel objects represented in the database
            var productModels = TestHelper.ProductService.GetAllData();

            // The highest travel time in the database
            double longestTravelTime = productModels.Max(x => x.TravelTime);

            // The lowest travel time in the database
            double shortestTravelTime = productModels.Min(x => x.TravelTime);

            // Find the productModels with the longest travel time
            var farthestCities = productModels.Where(x => x.TravelTime == longestTravelTime);

            // Find the productModels with the shortest travel time
            var closestCities = productModels.Where(x => x.TravelTime == shortestTravelTime);

            // Find the city among the highest travel time productModels matching the last card rendered on the page
            var farthestId = farthestCities.Where(x => products.Last().Id.Contains(x.Id));

            // Find the city among the lowest travel time productModels matching the first card rendered on the page
            var closestId = closestCities.Where(x => products.First().Id.Contains(x.Id));

            // Assert
            Assert.AreEqual(false, farthestId.IsNullOrEmpty());
            Assert.AreEqual(false, closestId.IsNullOrEmpty());
        }

        /// <summary>
        /// Test that cities appear in expected order after sorting by cost
        /// </summary>
        [Test]
        public void GetSortedProducts_Valid_Cost_Selected_Should_Return_Cities_Sorted_By_Cost()
        {
            // Arrange
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // The HTML page
            var page = RenderComponent<ProductList>();

            // Find the select element for the sorting option dropdown
            var select = page.Find("#sorting-dropdown");

            // Act

            // Select Cost from the dropdown
            select.Change(SortingEnum.Cost);

            // The list of cards representing each city
            var products = page.FindAll(".card-rows div.card");

            // The list of all ProductModel objects represented in the database
            var productModels = TestHelper.ProductService.GetAllData();

            // The highest cost in the database
            int highestCost = productModels.Max(x => x.Cost);

            // The lowest cost in the database
            int lowestCost = productModels.Min(x => x.Cost);

            // Find the productModels with the highest cost
            var mostExpensiveCities = productModels.Where(x => x.Cost == highestCost);

            // Find the productModels with the lowest cost
            var cheapestCities = productModels.Where(x => x.Cost == lowestCost);

            // Find the city among the highest cost productModels matching the last card rendered on the page
            var mostExpensiveId = mostExpensiveCities.Where(x => products.Last().Id.Contains(x.Id));

            // Find the city among the lowest cost productModels matching the first card rendered on the page
            var cheapestId = cheapestCities.Where(x => products.First().Id.Contains(x.Id));

            // Assert
            Assert.AreEqual(false, mostExpensiveId.IsNullOrEmpty());
            Assert.AreEqual(false, cheapestId.IsNullOrEmpty());
        }

        #endregion GetSortedProducts

        #region SwipeImage

        /// <summary>
        /// Selecting the right button for a valid city image should show next image
        /// </summary>
        [Test]
        public void MoveRight_Valid_Should_Return_Next_Image()
        {
            // Arrange
            var previousSlideIndex = 0;
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // The HTML page
            var page = RenderComponent<ProductList>();

            // Button to test clicking
            var id = "ExploreMoreButton_paris";

            // Find the Buttons (explore more)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Click on the button
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Find the carousel's right button
            var rightButton = page.Find(".carousel-button.carousel-button-right");

            // Find the carousel track element before clicking the button
            var carouselTrack = page.Find(".carousel-track");

            // Assert the initial style before clicking the button
            var initialTransform = carouselTrack.GetAttribute("style");
            Assert.AreEqual("transform: translateX(-0%);", initialTransform);

            // Act: Click the right button to move to the second image
            rightButton.Click();

            // Assert the style has changed to "translateX(-100%)" after clicking the right button
            var updatedTransform = carouselTrack.GetAttribute("style");
            Assert.AreEqual("transform: translateX(-100%);", updatedTransform);

        }

        /// <summary>
        /// Selecting the left button for a valid city image should show previous image
        /// </summary>
        [Test]
        public void MoveLeft_Valid_Should_Return_Previous_Image()
        {
            // Arrange
            var previousSlideIndex = 0;
            Services.AddSingleton<JsonFileProductService>(TestHelper.ProductService);

            // The HTML page
            var page = RenderComponent<ProductList>();

            // Button to test clicking
            var id = "ExploreMoreButton_paris";

            // Find the Buttons (explore more)
            var buttonList = page.FindAll("Button");

            // Find the one that matches the ID looking for and click it
            var button = buttonList.First(m => m.OuterHtml.Contains(id));

            // Click on the button
            button.Click();

            // Get the markup to use for the assert
            var pageMarkup = page.Markup;

            // Find the carousel's right button
            var leftButton = page.Find(".carousel-button.carousel-button-left");

            // Find the carousel track element before clicking the button
            var carouselTrack = page.Find(".carousel-track");

            // Assert the initial style before clicking the button
            var initialTransform = carouselTrack.GetAttribute("style");
            Assert.AreEqual("transform: translateX(-0%);", initialTransform);

            // Act: Click the right button to move to the second image
            leftButton.Click();

            // Assert the style has changed to "translateX(-100%)" after clicking the right button
            var updatedTransform = carouselTrack.GetAttribute("style");
            Assert.AreEqual("transform: translateX(-200%);", updatedTransform);

        }

        #endregion SwipeImage
    }
}