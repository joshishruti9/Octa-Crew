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
        /// When the error page is requested, RequestId is set
        /// </summary>
        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}