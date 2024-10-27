using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

using ContosoCrafts.WebSite.Models;

using Microsoft.AspNetCore.Hosting;

namespace ContosoCrafts.WebSite.Services
{
   /// <summary>
   /// Service class with methods for managing city data
   /// </summary>
    public class JsonFileProductService
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="webHostEnvironment">Hosting environment used</param>
        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        // Web hosting environment used
        public IWebHostEnvironment WebHostEnvironment { get; }

        // Full path to JSON file database
        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json"); }
        }

        /// <summary>
        /// Gets a list of cities with their data from the database
        /// </summary>
        /// <returns>List of ProductModels containing city data</returns>
        public IEnumerable<ProductModel> GetProducts()
        {
            using(var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Gets a list of cities with their data from the database
        /// </summary>
        /// <returns>List of ProductModels containing city data</returns>
        public IEnumerable<ProductModel> GetAllData()
        {
            using (var jsonFileReader = File.OpenText(JsonFileName))
            {
                return JsonSerializer.Deserialize<ProductModel[]>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
            }
        }

        /// <summary>
        /// Adds a rating to the given city by its ID.
        /// If the city doesn't have any ratings yet, it initializes the ratings array for that city.
        /// If the city already has ratings, it adds the new rating to the array that already exists.
        /// </summary>
        /// <param name="productId">ID of city being rated</param>
        /// <param name="rating">Rating to be added to the city</param>
        /// <returns>True if database is successfully updated, false otherwise</returns>
        public bool AddRating(string productId, int rating)
        {
            // List of all cities
            var products = GetProducts();

            // If the city does not already have a ratings array, initialize one for it
            if(products.First(x => x.Id == productId).Ratings == null)
            {
                products.First(x => x.Id == productId).Ratings = new int[] { };
            }
            // The city does have a ratings array, so add the new rating to the array
            // Get the ratings array for the city
            var ratings = products.First(x => x.Id == productId).Ratings.ToList();
            ratings.Add(rating);
            products.First(x => x.Id == productId).Ratings = ratings.ToArray();
          
            using(var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<ProductModel>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }), 
                    products
                );
            }

            return true;
        }
    }
}