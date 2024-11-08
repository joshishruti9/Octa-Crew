using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.ValidationAttributes
{
	/// <summary>
	/// Custom validation attribute for Images
	/// </summary>
	public class ImageURLValidation
	{
		/// <summary>
		/// Method for validating URLs in Images
		/// </summary>
		/// <param name="URLs">Array of URLs to be validated</param>
		/// <returns>Success if URLs are valid, ValidationResult if any URL is not valid</returns>
		public static ValidationResult ImageURLValidate(string[] URLs)
		{
			// Checks if URL is valid
			UrlAttribute urlCheck = new UrlAttribute();

			// Checks if URL ends in valid image extension
			RegularExpressionAttribute regEx = new RegularExpressionAttribute(
				@".*\.(jpg|jpeg|png|gif|bmp|svg|webp)$"
			);

			for (int i = 0; i < URLs.Length; i++)
			{
				if (URLs[i] == null)
				{
					return new ValidationResult("URL is null");
				}

				if (URLs[i].Length == 0)
				{
					return new ValidationResult("URL is empty");
				}

				if (urlCheck.IsValid(URLs[i]) == false)
				{
					return new ValidationResult("URL is not valid");
				}

				if (regEx.IsValid(URLs[i]) == false)
				{
					return new ValidationResult("URL does not end in image extension");
				}
			}

			return ValidationResult.Success;
		}
	}
}