using System;
using System.IO;
using YeZhStudio.Base;

namespace MyLogConsole
{
    public class FileLog : ILog
    {
        private readonly DateTime _initTime;
        private StreamWriter sw;

        public FileLog()
        {
            _initTime = DateTime.Now;
            sw = new StreamWriter(@"D:/log.txt");
            sw.AutoFlush = true;
        }

        public void Debug(string message)
        {
            sw.WriteLine(message);
        }

        public void Info(string message)
        {
            sw.WriteLine(message);
        }

        public void Warn(string message)
        {
            sw.WriteLine(message);
        }

        public void Error(string message)
        {
            sw.WriteLine(message);
        }

        public void Fatal(string message)
        {
            sw.WriteLine(message);
        }

        public string FormatMessage(string rawMessage)
        {
            return string.Format("[{1,4}] {0}", rawMessage, (int)(DateTime.Now - _initTime).TotalMilliseconds);
        }
    }
}