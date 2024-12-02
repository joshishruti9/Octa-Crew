using ContosoCrafts.WebSite.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ContosoCrafts.WebSite
{
    /// <summary>
    ///     Configures services and request pipeline.
    /// </summary>
    public class Startup
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="configuration">
        ///     IConfiguration object with configuration settings
        /// </param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // Configuration settings
        public IConfiguration Configuration { get; }

        /// <summary>
        ///     This method gets called by the runtime.
        ///     Use this method to add services to the container.
        /// </summary>
        /// <param name="services">
        ///     Service descriptors for dependency injection
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient();
            services.AddControllers();
            services.AddTransient<JsonFileProductService>();
            services.AddTransient<JsonFileTravelTipService>();
        }

        /// <summary>
        ///     This method gets called by the runtime.
        ///     Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">
        ///     Application builder used to configure the middleware pipeline
        /// </param>
        /// <param name="env">
        ///     Hosting environment
        /// </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // If in Development, provide a detailed error page for debugging
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // In Production, so use an error handling page that is more user-friendly
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days.
                // You may want to change this for production scenarios,
                // see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();

                // endpoints.MapGet("/products", (context) => 
                // {
                //     var products = app.ApplicationServices.GetService<JsonFileProductService>().GetProducts();
                //     var json = JsonSerializer.Serialize<IEnumerable<Product>>(products);
                //     return context.Response.WriteAsync(json);
                // });
            });
        }
    }
}