using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Xml;

namespace YezhStudio.Base
{
    public class Logger
    {
        public Logger()
        {
            Level = LogLevel.All;
        }

        public LogLevel Level { get; set; }

        public void Debug(string message, string category = null)
        {
            var logLevel = LogLevel.Debug;
            if (!checkLevel(logLevel))
            {
                return;
            }

            addLog(message, logLevel, category);
        }

        public void Info(string message, string category = null)
        {
            var logLevel = LogLevel.Info;
            if (!checkLevel(logLevel))
            {
                return;
            }

            addLog(message, logLevel, category);
        }

        public void Warn(string message, string category = null)
        {
            var logLevel = LogLevel.Warn;
            if (!checkLevel(logLevel))
            {
                return;
            }

            addLog(message, logLevel, category);
        }

        public void Error(string message, string category = null)
        {
            var logLevel = LogLevel.Error;
            if (!checkLevel(logLevel))
            {
                return;
            }

            addLog(message, logLevel, category);
        }

        public void Fatal(string message, string category = null)
        {
            var logLevel = LogLevel.Fatal;
            if (!checkLevel(logLevel))
            {
                return;
            }

            addLog(message, logLevel, category);
        }

        public LogMessage GetLog()
        {
            return msgQueue.Dequeue();
        }

        public bool HasLog()
        {
            return msgQueue.Count > 0;
        }

        private Queue<LogMessage> msgQueue = new Queue<LogMessage>();

        private bool checkLevel(LogLevel level)
        {
            return level >= Level;
        }

        private void addLog(string message, LogLevel logLevel, string category = null)
        {
            var logMessage = new LogMessage(message, logLevel, DateTime.Now, category);
            msgQueue.Enqueue(logMessage);
        }
    }
}