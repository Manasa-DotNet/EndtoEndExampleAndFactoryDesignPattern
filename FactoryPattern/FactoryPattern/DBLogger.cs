using System;

namespace FactoryPattern
{
    public class DBLogger : ILogger
    {
        private readonly LoggerType _loggerType;
        public DBLogger()
        {
            _loggerType = LoggerType.DB;
        }
        public LoggerType loggerType { get => _loggerType; }

        public void Log(string message)
        {
            Console.WriteLine($"Writing to DB: {message}");
        }
    }
}
