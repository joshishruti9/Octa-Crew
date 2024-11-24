namespace ContosoCrafts.WebSite.Enums
{
    /// <summary>
    /// Enum to determine sorting method
    /// </summary>
    public enum SortingEnum
    {
        Undefined = 0,
        Rating = 10,
        TravelTime = 20,
        Cost = 30
    }

    /// <summary>
    /// Extension to SortingEnum for displaying custom text for each value
    /// </summary>
    public static class SortingEnumExtensions
    {
        /// <summary>
        /// Converts enum value to custom string
        /// </summary>
        /// <param name="data">The enum value to display</param>
        /// <returns>String representation of the enum value</returns>
        public static string DisplayName(this SortingEnum data)
        {
            return data switch
            {
                SortingEnum.Rating => "Rating",
                SortingEnum.TravelTime => "Travel Time",
                SortingEnum.Cost => "Cost",

                // Default, Undefined
                _ => "Sort by..."
            };
        }
    }
}
