using System;
using System.Collections.Generic;
using System.Threading;

namespace YezhStudio.Base
{
    public class LogManager
    {
        private static List<Logger> loggers = new List<Logger>();
        private static Queue<LogMessage> msgQueue = new Queue<LogMessage>();
        private static readonly List<IOutput> listeners = new List<IOutput>();
        private static Thread outputThread;
        private static readonly HashSet<string> enableCategories = new HashSet<string>();

        static LogManager()
        {
            outputThread = new Thread(output);
        }

        public static Logger CreatLogger()
        {
            lock (loggers)
            {
                var logger = new Logger();
                loggers.Add(logger);
                return logger;
            }
        }

        public static void RemoveLogger(Logger logger)
        {
            lock (loggers)
            {
                loggers.Remove(logger);
            }
        }

        public static void Start()
        {
            outputThread.Start();
        }

        public static void Stop()
        {
            outputThread.Abort();
        }

        public static void AddListener(IOutput iOutput)
        {
            listeners.Add(iOutput);
        }

        public static void RemoveListener(IOutput iOutput)
        {
            listeners.Remove(iOutput);
        }

        public static void AddEnableCategory(string category)
        {
            enableCategories.Add(category);
        }

        public static void RemoveEnableCategory(string category)
        {
            enableCategories.Remove(category);
        }

        private static void output()
        {
            while (true)
            {
                lock (loggers)
                {
                    foreach (Logger logger in loggers)
                    {
                        lock (logger)
                        {
                            while (logger.HasLog())
                            {
                                msgQueue.Enqueue(logger.GetLog());
                            }
                        }
                    }
                }

                while (msgQueue.Count > 0)
                {
                    output(msgQueue.Dequeue());
                }

                Thread.Sleep(100);
            }
        }

        private static void output(LogMessage logMessage)
        {
            if (logMessage == null)
            {
                return;
            }
            var category = logMessage.Category;
            if (string.IsNullOrEmpty(category))
            {
                category = "Default";
            }

            if (!enableCategories.Contains("All") && !enableCategories.Contains(category))
            {
                return;
            }

            foreach (IOutput listener in listeners)
            {
                listener.Output(logMessage);
            }
        }

    }
}