using System;
using Xunit;

namespace FactoryPattern.Tests
{
    public class LoggerFactoryTest
    {
        [Fact]
        public void Test_FileLoggerShouldBeReturned()
        {
            var ilogger = LoggerFactory.GetLogger(LoggerType.File);
            ilogger.Log("Logging to File");

            Assert.IsType<FileLogger>(ilogger);
            Assert.Equal(LoggerType.File,ilogger.loggerType);
        }

        [Fact]
        public void Test_ConsoleLoggerShouldBeReturned()
        {
            var ilogger = LoggerFactory.GetLogger(LoggerType.Console);
            ilogger.Log("Logging to Console");

            Assert.IsType<ConsoleLogger>(ilogger);
            Assert.Equal(LoggerType.Console, ilogger.loggerType);
        }

        [Fact]
        public void Test_DBLoggerShouldBeReturned()
        {
            var ilogger = LoggerFactory.GetLogger(LoggerType.DB);
            ilogger.Log("Logging to DB");

            Assert.IsType<DBLogger>(ilogger);
            Assert.Equal(LoggerType.DB, ilogger.loggerType);
        }
    }
}
