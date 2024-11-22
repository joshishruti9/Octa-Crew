namespace ContosoCrafts.WebSite.Enums
{
    /// <summary>
    /// Enum to determine sorting method
    /// </summary>
    public enum SortingEnum
    {
        Undefined = 0,
        Rating = 10
    }

    public static class SortingEnumExtensions
    {
        public static string DisplayName(this SortingEnum data)
        {
            return data switch
            {
                SortingEnum.Rating => "Rating",

                // Default, Undefined
                _ => "Sort by..."
            };
        }
    }
}
