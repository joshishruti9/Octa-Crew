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
            var id = "ExploreMoreButton_paris";

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
            var id = "ExploreMoreButton_rome";

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
    }
}