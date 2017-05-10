using System;
using YeZhStudio.Base;

namespace MyLogConsole
{
    public class ConsoleLog : ILog
    {
        private readonly DateTime _initTime;
        #region ILog Members

        public ConsoleLog()
        {
            _initTime = DateTime.Now;
        }

        public void Debug(string message)
        {
            Console.WriteLine(message);
        }

        public void Info(string message)
        {
            Console.WriteLine(message);
        }

        public void Warn(string message)
        {
            Console.WriteLine(message);
        }

        public void Error(string message)
        {
            Console.WriteLine(message);
        }

        public void Fatal(string message)
        {
            Console.WriteLine(message);
        }

        public string FormatMessage(string rawMessage)
        {
            return string.Format("[{1,4}] {0}", rawMessage, (int)(DateTime.Now - _initTime).TotalMilliseconds);
        }

        #endregion
    }
}