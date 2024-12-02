using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{

    /// <summary>
    /// Model for Privacy page
    /// </summary>
    public class PrivacyModel : PageModel
    {
        // Logs information, errors, etc. for Privacy page

        private readonly ILogger<PrivacyModel> _logger;

        /// <summary>
        /// Constructor initializes _logger
        /// </summary>
        /// <param name="logger">Set to _logger</param>
        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Called when the page is accessed
        /// </summary>
        public void OnGet()
        {

        }

    }

}