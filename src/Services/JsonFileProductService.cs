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
        public IEnumerable<ProductModel> GetAllData()
        {
            // create a StreamReader object to read the cities into an array
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
        /// Creates a ProductModel object to be used for creation of a new city in the database
        /// </summary>
        /// <returns>ProductModel object with default values filled in</returns>
        public ProductModel CreateData()
        {
            // Create a new city
            var data = new ProductModel()
            {
                Id = System.Guid.NewGuid().ToString(),
                Images = new string[3],
                Title = null,
                Description = null,
                BestSeason = null,
                Currency = null,
                TimeZone = null,
                Attractions = new string[3],
                Cost = 0,
                TravelTime = 0.0,
                Ratings = null
            };

            return data;
        }

        /// <summary>
        /// Add a new product to the database, ensuring the title is unique.
        /// </summary>
        /// <param name="data">The product data to add</param>
        /// <returns>A message indicating success or failure</returns>
        public string AddProduct(ProductModel data)
        {
            var products = GetAllData().ToList();

            // Check for duplicate title
            if (products.Any(p => p.Title.Equals(data.Title, StringComparison.OrdinalIgnoreCase)))
            {
                return "Error: A product with this title already exists.";
            }

            // Assign a new ID if not already set
            data.Id ??= Guid.NewGuid().ToString();

            products.Add(data);
            SaveData(products);

            return "Product added successfully.";
        }

        /// <summary>
        /// Update all the fields of a city in the database
        /// </summary>
        /// <param name="data">The new data values</param>
        /// <returns></returns>

        public ProductModel UpdateData(ProductModel data)
        {
            var products = GetAllData().ToList();

            // Check if the title already exists for a different product
            if (products.Any(p => p.Title.Equals(data.Title, StringComparison.OrdinalIgnoreCase) && !p.Id.Equals(data.Id)))
            {
                return null; // Indicate failure due to duplicate title
            }

            // the city in the database matching the data parameter's Id
            var productData = products.FirstOrDefault(x => x.Id.Equals(data.Id));

            if (productData == null)
            {
                return null;
            }

            // Update the data to the new passed in values
            productData.Title = data.Title;
            productData.Description = data.Description?.Trim();
            productData.Images = data.Images;
            productData.TimeZone = data.TimeZone;

            productData.BestSeason = data.BestSeason;
            productData.Currency = data.Currency;

            productData.Attractions = data.Attractions;
            productData.Cost = data.Cost;
            productData.TravelTime = data.TravelTime;

            SaveData(products);

            return productData;
        }
        
        /// <summary>
        /// Stores the list of cities and their associated data in the database
        /// </summary>
        public void SaveData(IEnumerable<ProductModel> products)
        {
            // use a FileStream object to write the products to the database
            using (var outputStream = File.Create(JsonFileName))
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
        }

        /// <summary>
        /// Delete all the fields of a city from the database 
        /// </summary>
        /// <param name="id">The id of the city that needs to be deleted</param>
        /// <returns>Updated products data</returns>
        public ProductModel DeleteData(string id)
        {
            // Get the current set, and append the new record to it
            var dataSet = GetAllData();

            // the city with id matching the id parameter
            var data = dataSet.FirstOrDefault(m => m.Id.Equals(id));

            // the set of cities not matching the id parameter
            var newDataSet = GetAllData().Where(m => m.Id.Equals(id) == false);

            SaveData(newDataSet);

            return data;
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
            // If the ID of the city is invalid, return

            if (string.IsNullOrEmpty(productId))
            {
                return false;
            }

            // List of all cities
            var products = GetAllData();

            // Look up the city, if it does not exist, return
            var data = products.FirstOrDefault(x => x.Id.Equals(productId));
            if (data == null)
            {
                return false;
            }

            // Check Rating for boundaries, do not allow ratings below 0
            if (rating < 0)
            {
                return false;
            }

            // Check Rating for boundaries, do not allow ratings above 5
            if (rating > 5)
            {
                return false;
            }

            // If the city does not already have a ratings array, initialize one for it
            if (products.First(x => x.Id == productId).Ratings == null)
            {
                products.First(x => x.Id == productId).Ratings = new int[] { };
            }

            // The city does have a ratings array, so add the new rating to the array
            // Get the ratings array for the city

            // the current list of ratings for the city with id matching productId
            var ratings = products.First(x => x.Id == productId).Ratings.ToList();

            ratings.Add(rating);
            products.First(x => x.Id == productId).Ratings = ratings.ToArray();
          
            SaveData( products );

            return true;
        }
    }
}