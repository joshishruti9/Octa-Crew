using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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

		/// <summary>
		/// Gets a list of travel tips from the database
		/// </summary>
		/// <returns>List of TravelTipsModels containing city data</returns>
		public IEnumerable<TravelTipsModel> GetAllData()
		{
			using (var jsonFileReader = File.OpenText(JsonFileName))
			{
				return JsonSerializer.Deserialize<TravelTipsModel[]>(jsonFileReader.ReadToEnd(),
					new JsonSerializerOptions
					{
						PropertyNameCaseInsensitive = true
					});
			}
		}

		/// <summary>
		/// Stores the list of travel tips in the database
		/// </summary>
		public void SaveData(IEnumerable<TravelTipsModel> travelTips)
		{

			using (var outputStream = File.Create(JsonFileName))
			{
				JsonSerializer.Serialize<IEnumerable<TravelTipsModel>>(
					new Utf8JsonWriter(outputStream, new JsonWriterOptions
					{
						SkipValidation = true,
						Indented = true
					}),
					travelTips
				);
			}
		}

	}
}