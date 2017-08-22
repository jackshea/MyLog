using System;

namespace YezhStudio.Base
{
    public class CommonMsgFormater : IFormater
    {
        private readonly DateTime initTime;
        public CommonMsgFormater()
        {
            initTime = DateTime.Now;
        }

        public string FormatString(LogMessage logMessage)
        {
            string category = logMessage.Category;
            var logLevelName = logMessage.LogLevel.ToString().ToUpper();
            if (string.IsNullOrEmpty(category))
                category = "Default";

            return string.Format("[{3,5}|{2,-5}|{1,-8}]: \"{0}\"", logMessage.Message, category, logLevelName, (logMessage.Time - initTime).TotalMilliseconds);
        }
    }
}