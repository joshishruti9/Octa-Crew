using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace ContosoCrafts.WebSite.Pages
{
    /// <summary>
    /// Model for handling the error page and displaying error information
    /// </summary>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public class ErrorModel : PageModel
    {
        // ID for HTTP request
        public string RequestId { get; set; }

        /// <summary>
        /// Only shows the request ID if it exists (is not null or empty)
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        // The message to be displayed
        public string ErrorMessage { get; set; }

        // Records logs
        private readonly ILogger<ErrorModel> _logger;

        /// <summary>
        /// Initializer constructor
        /// </summary>
        /// <param name="logger">Logs error information</param>
        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// When the error page is requested, RequestId and ErrorMessage are set
        /// </summary>
        public void OnGet(string message = null)
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            ErrorMessage = message;
        }
    }
}