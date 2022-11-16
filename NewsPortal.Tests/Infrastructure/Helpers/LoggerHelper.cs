using Microsoft.Extensions.Logging;

namespace NewsPortal.Tests.Infrastructure.Helpers
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
