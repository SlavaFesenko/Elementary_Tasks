using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Configuration.Json;
using NLog;

namespace CommonThings
{
    public class Logger<TService> where TService : class
    {

        public static IServiceProvider BuildDi(IConfiguration config)
        {
            return new ServiceCollection()
               .AddTransient<TService>() // Runner is the custom class
               .AddLogging(loggingBuilder =>
               {
                   // configure Logging with NLog
                   loggingBuilder.ClearProviders();
                   loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                   loggingBuilder.AddNLog(config);
               })
               .BuildServiceProvider();
        }

        public static IServiceProvider HelperForLogging()
        {
            IServiceProvider provider = null;

            var config = new ConfigurationBuilder()

        .SetBasePath(System.IO.Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

            LogManager.Configuration = new NLogLoggingConfiguration(config.GetSection("NLog"));

            provider = BuildDi(config);

            return provider;

        }
    }
}
