using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

using ContosoCrafts.WebSite.Components;
using ContosoCrafts.WebSite.Services;
using Bunit;
using System.Linq;

namespace UnitTests.Components
{
    public class ProductListTests : BunitTestContext
    {
        #region TestSetup

        [SetUp]
        public void TestInitialize()
        {
        }

        #endregion TestSetup

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

    }
}