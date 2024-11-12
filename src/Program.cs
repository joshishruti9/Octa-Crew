using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    /// <summary>
    /// Entry point, starts the web host and configures services
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point, creates and runs the web host
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates a host builder, configures default settings and specifies the startup class
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        /// <returns>IHostBuilder instance configured for the application</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}