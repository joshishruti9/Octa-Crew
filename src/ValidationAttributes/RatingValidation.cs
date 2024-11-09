using System.ComponentModel.DataAnnotations;

namespace ContosoCrafts.WebSite.ValidationAttributes
{
    /// <summary>
    /// Custom validation attribute for Ratings
    /// </summary>
    public class RatingValidation
    {
        /// <summary>
        /// Method for validating range of ratings in Ratings
        /// </summary>
        /// <param name="Ratings">Integer array to be validated</param>
        /// <returns>Success if Ratings are between 1 and 5, ValidationResult if any Rating is not within this range</returns>
        public static ValidationResult RatingValidate(int[] Ratings)
        {            
            if (Ratings == null)
            {
                return ValidationResult.Success;
            }
            
            for (int i = 0; i < Ratings.Length; i++)
            {
                if (Ratings[i] < 1)
                {
                    return new ValidationResult($"Rating #{i + 1} must be at least 1");
                }

                if (Ratings[i] > 5)
                {
                    return new ValidationResult($"Rating #{i + 1} must be at most 5");
                }
            }

            return ValidationResult.Success;
        }
    }
}