namespace FactoryPattern
{
    public class LoggerFactory
    {
        public static ILogger GetLogger(LoggerType loggerType)
        {
            switch (loggerType)
            {
                case LoggerType.File:
                    return new FileLogger();
                case LoggerType.DB:
                    return new DBLogger();
                case LoggerType.Console:
                    return new ConsoleLogger();
            }
            return new ConsoleLogger();
        }
    }
}
