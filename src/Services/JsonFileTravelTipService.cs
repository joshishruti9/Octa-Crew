using ContosoCrafts.WebSite.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            // create a StreamReader object to read the cities into an array
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
		/// Creates a TravelTipsModel object to be used for creation of a new tip in the database
		/// </summary>
		/// <returns>TravelTipsModel object with default values filled in</returns>
		public TravelTipsModel CreateData()
		{
			// Create a new tip with default attributes
			var data = new TravelTipsModel()
			{
				Id = System.Guid.NewGuid().ToString(),
				Title = "Enter Tip Name",
				Description = "Enter Tip Description",
			};

			return data;
		}

		/// <summary>
		/// Update all the fields of a tip in the database
		/// </summary>
		/// <param name="data">The new data values</param>
		/// <returns></returns>

		public TravelTipsModel UpdateData(TravelTipsModel data)
		{
			// the cities in the database
			var travelTips = GetAllData();

			// the tip in the database matching the data parameter's Id
			var travelTipData = travelTips.FirstOrDefault(x => x.Id.Equals(data.Id));

			if (travelTipData == null)
			{
				return null;
			}

			// Update the data to the new passed in values
			travelTipData.Title = data.Title;
			travelTipData.Description = data.Description?.Trim();

			SaveData(travelTips);

			return travelTipData;
		}

		/// <summary>
		/// Delete all the fields of a travel tip from the database 
		/// </summary>
		/// <param name="id">The id of the travel tip that needs to be deleted</param>
		/// <returns>Updated travel tips data</returns>
		public TravelTipsModel DeleteData(string id)
		{
			// Get the current set
			var dataSet = GetAllData();

			// Get the travel tip matching the given id
			var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

			// Retrieve all travel tips from the database where the id does not match the given id
			var newDataSet = dataSet.Where(m => m.Id.Equals(id) == false);

			SaveData(newDataSet);

			return data;
		}

		/// <summary>
		/// Stores the list of travel tips in the database
		/// </summary>
		public void SaveData(IEnumerable<TravelTipsModel> travelTips)
		{
            // use a FileStream object to write the products to the database
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