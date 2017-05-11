namespace YezhStudio.Base
{
    public class CommonMsgFormater : IFormater
    {
        public string FormatString(string message, string category, LogLevel logLevel)
        {
            var logLevelName = logLevel.ToString().ToUpper();
            if (string.IsNullOrEmpty(category))
                category = "Default";

            return string.Format("[{2,-5}] [{1,-8}]: \"{0}\"", message, category, logLevelName);
        }
    }
}