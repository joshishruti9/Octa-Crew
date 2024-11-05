using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace ContosoCrafts.WebSite.Services
{
	/// <summary>
	/// Service class with methods for managing Travel Tips data
	/// </summary>
	public class JsonFileTravelTipService
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="webHostEnvironment">Hosting environment used</param>
		public JsonFileTravelTipService(IWebHostEnvironment webHostEnvironment)
		{
			WebHostEnvironment = webHostEnvironment;
		}


		// Web hosting environment used
		public IWebHostEnvironment WebHostEnvironment { get; }

		// Full path to JSON file database
		private string JsonFileName
		{
			get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "TravelTips.json"); }
		}

	}
}