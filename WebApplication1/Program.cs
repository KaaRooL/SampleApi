using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebApplication1
{
    public class Program
    {
        public static Task Main(string[] args) => CreateHostBuilder(args).Build().RunAsync();

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args).ConfigureAppConfiguration(options =>
                    {
                        // options.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                        options.AddEnvironmentVariables(prefix: "SampleApi__");
                    })
                    .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}