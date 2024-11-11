
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;

using Moq;

using ContosoCrafts.WebSite.Services;
using NUnit.Framework.Internal;

namespace UnitTests
{
    /// <summary>
    /// Helper to hold the web start settings
    ///
    /// HttpClient
    /// 
    /// Action Contect
    /// 
    /// The View Data and Teamp Data
    /// 
    /// The Product Service
    /// </summary>
    public static class TestHelper
    {
        // Mock web host environment to be used for testing
        public static Mock<IWebHostEnvironment> MockWebHostEnvironment;

        // Interface for creating IUrlHelper instances
        public static IUrlHelperFactory UrlHelperFactory;

        // Context with all HTTP-specific information about and HTTP request
        public static DefaultHttpContext HttpContextDefault;

        // Holds information about the web host environment
        public static IWebHostEnvironment WebHostEnvironment;

        // Stores model state information
        public static ModelStateDictionary ModelState;

        // Context for action being performed
        public static ActionContext ActionContext;

        // Used for creation of a new ViewDataDictionary
        public static EmptyModelMetadataProvider ModelMetadataProvider;
        
        // Used to pass data between controller and view
        public static ViewDataDictionary ViewData;

        // Stores temporary data that persists only from one request to the next
        public static TempDataDictionary TempData;

        // Context associated with a Razor page request
        public static PageContext PageContext;

        // Service to manage interactions with the cities database
        public static JsonFileProductService ProductService;

        // Service to manage interactions with the travel tips database
        public static JsonFileTravelTipService TravelTipService;

        /// <summary>
        /// Default Constructor
        /// </summary>
        static TestHelper()
        {
            MockWebHostEnvironment = new Mock<IWebHostEnvironment>();
            MockWebHostEnvironment.Setup(m => m.EnvironmentName).Returns("Hosting:UnitTestEnvironment");
            MockWebHostEnvironment.Setup(m => m.WebRootPath).Returns(TestFixture.DataWebRootPath);
            MockWebHostEnvironment.Setup(m => m.ContentRootPath).Returns(TestFixture.DataContentRootPath);

            HttpContextDefault = new DefaultHttpContext()
            {
                TraceIdentifier = "trace",
            };
            HttpContextDefault.HttpContext.TraceIdentifier = "trace";

            ModelState = new ModelStateDictionary();

            ActionContext = new ActionContext(HttpContextDefault, HttpContextDefault.GetRouteData(), new PageActionDescriptor(), ModelState);

            ModelMetadataProvider = new EmptyModelMetadataProvider();
            ViewData = new ViewDataDictionary(ModelMetadataProvider, ModelState);
            TempData = new TempDataDictionary(HttpContextDefault, Mock.Of<ITempDataProvider>());

            PageContext = new PageContext(ActionContext)
            {
                ViewData = ViewData,
                HttpContext = HttpContextDefault
            };

            ProductService = new JsonFileProductService(MockWebHostEnvironment.Object);

            // Service to manage interactions with the cities database
            JsonFileProductService productService;

            productService = new JsonFileProductService(TestHelper.MockWebHostEnvironment.Object);

            TravelTipService = new JsonFileTravelTipService(MockWebHostEnvironment.Object);

            // Service to manage interactions with the travel tips database
            JsonFileTravelTipService travelTipService;

            travelTipService = new JsonFileTravelTipService(TestHelper.MockWebHostEnvironment.Object);
        }
    }
}