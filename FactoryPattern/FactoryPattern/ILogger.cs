using System.Collections.Generic;
using System.Text;

namespace FactoryPattern
{
    public interface ILogger
    {
        public void Log(string message);
        public LoggerType loggerType { get; }
    }
}
