using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using Serilog;
using Serilog.Events;

namespace Hahn.ApplicatonProcess.May2020.Web
{
    public class Program
    {
        public static int Main(string[] args)
        {
            // Create the Serilog logger, and configure the sinks
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.RollingFile("ApplicatonProcess-log-{Date}.txt")
                .CreateLogger();

            // Wrap creating and running the host in a try-catch block
            try
            {
                Log.Information("Starting host");
                CreateHostBuilder(args).Build().Run();
                Log.CloseAndFlush();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog() // <- Add this line
                .ConfigureLogging(logging =>
                    logging.AddFilter("Microsoft", LogLevel.Information)
                        .AddFilter("System", LogLevel.Error))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
