using Microsoft.Extensions.Logging;

namespace Common.Shared
{
    public class ConsoleLoggerFactory : ILoggerFactory
    {
        public void Dispose() { }

        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }

        public void AddProvider(ILoggerProvider provider) { }

    }
    public class ConsoleLogger : ILogger
    {
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            if (eventId.Id == 20100) // execute SQL statement
            {
                Write($"Level: {logLevel}, Event Id: {eventId.Id}");

                // only output the state or exception if it exists
                if (state != null)
                {
                    Write($", State: {state}");
                }

                if (exception != null)
                {
                    Write($", Exception: {exception.Message}");
                }
                WriteLine();
            }
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Trace or LogLevel.Information or LogLevel.None => false,
                _ => true,
            };
            ;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null!;
        }
    }

}
