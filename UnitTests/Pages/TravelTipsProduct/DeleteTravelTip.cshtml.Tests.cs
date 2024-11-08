using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using System.Linq;
using ContosoCrafts.WebSite.Models;
using ContosoCrafts.WebSite.Pages.TravelTipsProduct;

namespace UnitTests.Pages.TravelTipsProduct
{
    /// <summary>
    /// Unit testing class for the delete page model for travel tips
    /// </summary>
    class DeleteTravelTip
    {
		#region TestSetup

		// page model for the CRUDi travel tips delete page
		public static DeleteTravelTipModel pageModel;

		/// <summary>
		/// Called before each test is called.
		/// Sets up necessary test context or variables
		/// </summary>
		[SetUp]
        public void Setup()
        {
            pageModel = new DeleteTravelTipModel(TestHelper.TravelTipService);
        }

		#endregion TestSetup
	}
}
