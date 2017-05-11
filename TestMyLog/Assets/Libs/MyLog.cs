using System.Collections.Generic;

namespace YezhStudio.Base
{
    public class MyLog : IOutput
    {
        private static readonly MyLog instance = new MyLog();

        private MyLog()
        {

        }

        private static readonly List<IOutput> listeners = new List<IOutput>();
        public static LogLevel Level { get; set; }

        public static void Debug(string message, string category = null)
        {
            if (Level > LogLevel.Debug)
            {
                return;
            }
            instance.Output(message, category, LogLevel.Debug);
        }

        public static void Info(string message, string category = null)
        {
            if (Level > LogLevel.Info)
            {
                return;
            }
            instance.Output(message, category, LogLevel.Info);
        }

        public static void Warn(string message, string category = null)
        {
            if (Level > LogLevel.Warn)
            {
                return;
            }
            instance.Output(message, category, LogLevel.Warn);
        }

        public static void Error(string message, string category = null)
        {
            if (Level > LogLevel.Error)
            {
                return;
            }
            instance.Output(message, category, LogLevel.Error);
        }

        public static void Fatal(string message, string category = null)
        {
            if (Level > LogLevel.Fatal)
            {
                return;
            }
            instance.Output(message, category, LogLevel.Fatal);
        }

        public static void Assert(bool condition, string failureMessage)
        {
            if (!condition)
            {
                Error(failureMessage, "Assert");
            }
        }

        public static void AddListener(IOutput iOutput)
        {
            listeners.Add(iOutput);
        }

        public static void RemoveListener(IOutput iOutput)
        {
            listeners.Remove(iOutput);
        }

        public void Output(string message, string category, LogLevel logLevel)
        {
            foreach (IOutput listener in listeners)
            {
                listener.Output(message, category, logLevel);
            }
        }
    }
}