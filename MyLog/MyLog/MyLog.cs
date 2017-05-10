namespace YeZhStudio.Base
{
    public class MyLog
    {
        private static readonly BaseLog _instance = new BaseLog();

        public static void Debug(string message, string category = null)
        {
            _instance.Debug(FormatString(message, category, LogLevel.Debug));
        }

        public static void Info(string message, string category = null)
        {
            _instance.Info(FormatString(message, category, LogLevel.Info));
        }

        public static void Warn(string message, string category = null)
        {
            _instance.Warn(FormatString(message, category, LogLevel.Warn));
        }

        public static void Error(string message, string category = null)
        {
            _instance.Error(FormatString(message, category, LogLevel.Error));
        }

        public static void Fatal(string message, string category = null)
        {
            _instance.Fatal(FormatString(message, category, LogLevel.Fatal));
        }

        public static void AddListener(ILog iLog)
        {
            _instance.AddListener(iLog);
        }

        public static void RemoveListener(ILog iLog)
        {
            _instance.RemoveListener(iLog);
        }

        private static string FormatString(string message, string category, LogLevel logLevel)
        {
            var logLevelName = logLevel.ToString().ToUpper();
            if (string.IsNullOrEmpty(category))
                category = "Default";
            return string.Format("[{2,-5}] [{1,-8}]: \"{0}\"", message, category, logLevelName);
        }
    }
}