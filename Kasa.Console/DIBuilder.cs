using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kasa.Console
{
    internal class BuildDi
    {
        public BuildDi()
        {

        }

        public static IServiceProvider BuildDepencyProvider(IConfiguration config)
        {
            return new ServiceCollection()
                  //Add DI Classes here
                  //.AddTransient<Person>()
                  .AddLogging(loggingBuilder =>
                  {
                     // configure Logging with NLog
                     loggingBuilder.ClearProviders();
                              loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                              loggingBuilder.AddNLog(config);
                  })
                  .BuildServiceProvider();
        }
    }
}
