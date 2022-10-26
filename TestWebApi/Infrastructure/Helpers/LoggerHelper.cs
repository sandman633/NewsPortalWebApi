using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebApi.Infrastructure.Helpers
{
    public class LoggerHelper
    {
        public static ILogger<T> GetLogger<T>()
        {
            return LoggerFactory.Create(loggingBuilder => loggingBuilder
                            .SetMinimumLevel(LogLevel.Trace)
                            .AddConsole()).CreateLogger<T>();
        }
    }
}
