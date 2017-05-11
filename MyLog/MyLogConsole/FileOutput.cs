using System;
using System.IO;
using YezhStudio.Base;

namespace MyLogConsole
{
    public class FileOutput : IOutput
    {
        private readonly DateTime _initTime;
        public IFormater MsgFormater { get; set; }
        private StreamWriter sw;

        public FileOutput(string filePath, IFormater iFormater)
        {
            _initTime = DateTime.Now;
            MsgFormater = iFormater;
            sw = new StreamWriter(filePath);
            sw.AutoFlush = true;
        }

        public void Output(string message, string category, LogLevel logLevel)
        {
            string formatMsg = MsgFormater.FormatString(message, category, logLevel);
            formatMsg = string.Format("[{1,4}] {0}", formatMsg, (int)(DateTime.Now - _initTime).TotalMilliseconds);
            sw.WriteLine(formatMsg);
        }
    }
}