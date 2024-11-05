
using ContosoCrafts.WebSite.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
	/// <summary>
	/// Unit testing class for TravelTipsModel
	/// </summary>
	public class TravelTipsModelTests
	{
		#region TestSetup

		// Travel tips model for testing
		static TravelTipsModel travelTipsModel;

		[SetUp]
		public void SetUp()
		{
			travelTipsModel = new TravelTipsModel()
			{
				Title = "Default title",
				Description = "Default description"
			};
		}

		#endregion TestSetup
	}
}