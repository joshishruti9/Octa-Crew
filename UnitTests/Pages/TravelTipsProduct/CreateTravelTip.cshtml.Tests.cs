using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContosoCrafts.WebSite.Pages.TravelTipsProduct;
using ContosoCrafts.WebSite.Services;
using NUnit.Framework;

namespace UnitTests.Pages.TravelTipsProduct
{
    /// <summary>
    /// Unit testing class for the create page model for travel tips
    /// </summary>
    class CreateTravelTipTests
    {
        #region TestSetup

        // page model for the CRUDi travel tips delete page
        public static CreateTravelTipModel pageModel;

        // mock service for the travel tips database
        public static JsonFileTravelTipService TravelTipService;

        /// <summary>
		/// Called before each test is called.
		/// Sets up necessary test context or variables
		/// </summary>
        [SetUp]
        public void Setup()
        {
            TravelTipService = TestHelper.TravelTipService;
            pageModel = new CreateTravelTipModel(TravelTipService);
        }

        #endregion TestSetup
    }
}
