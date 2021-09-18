using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ShoppingCart
{
    /// <summary>
    /// Entry point for application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Creates the application with the command line arguments.
        /// </summary>
        /// <param name="args">The command line arguments used to launch the application.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Creates and configures the host builder.
        /// </summary>
        /// <param name="args">The command line arguments used to launch the application.</param>
        /// <returns>The host builder after configuration.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
