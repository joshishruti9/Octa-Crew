using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text.Json;
using ContosoCrafts.WebSite.Models;

namespace ContosoCrafts.WebSite.ValidationAttributes
{
    /// <summary>
    /// Validation attribute to ensure the city title is unique by reading directly from products.json.
    /// </summary>
    public class UniqueCityTitleAttribute : ValidationAttribute
    {
        private const string ProductsJsonPath = "wwwroot\\data\\products.json"; // Path to your products.json file

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var title = value as string;



            // Read and parse the products.json file
            List<ProductModel> products;


            var jsonData = File.ReadAllText(ProductsJsonPath);
            products = JsonSerializer.Deserialize<List<ProductModel>>(jsonData);



            // Check if the title already exists in the data (case-sensitive comparison)
            if (products.Any(p => p.Title.Equals(title, StringComparison.OrdinalIgnoreCase)))// Case-sensitive comparison
            {
                return new ValidationResult($"The city title '{title}' already exists. Please choose a different title.");
            }

            return ValidationResult.Success;
        }
    }
}
