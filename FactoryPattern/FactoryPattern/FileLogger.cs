using System;

namespace FactoryPattern
{
    public class FileLogger : ILogger
    {
        private readonly LoggerType _loggerType;
        public FileLogger()
        {
            _loggerType = LoggerType.File;
        }
        public LoggerType loggerType { get => _loggerType; }

        public void Log(string message)
        {
            Console.WriteLine($"Writing to File: {message}");
        }
    }
}
