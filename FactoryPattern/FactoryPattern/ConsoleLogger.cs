using System;

namespace FactoryPattern
{
    public class ConsoleLogger : ILogger
    {
        private readonly LoggerType _loggerType;
        public ConsoleLogger()
        {
            _loggerType = LoggerType.Console;
        }
        public LoggerType loggerType { get => _loggerType; }

        public void Log(string message)
        {
            Console.WriteLine($"Writing to Console: {message}");
        }
    }
}
