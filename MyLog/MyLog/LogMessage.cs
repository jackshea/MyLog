using System;

namespace YezhStudio.Base
{
    public class LogMessage
    {
        public string Message { get; }
        public DateTime Time { get; }
        public LogLevel LogLevel { get; }
        public string Category { get; }

        public LogMessage(string message, LogLevel logLevel, DateTime dt, string category = null)
        {
            Message = message;
            LogLevel = logLevel;
            Time = dt;
            Category = category;
        }
    }
}