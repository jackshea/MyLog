using System;
using System.IO;
using YezhStudio.Base;

namespace MyLogConsole
{
    public class FileOutput : IOutput
    {
        public IFormater MsgFormater { get; set; }
        private StreamWriter sw;

        public FileOutput(string filePath, IFormater iFormater)
        {
            MsgFormater = iFormater;
            sw = new StreamWriter(filePath);
            sw.AutoFlush = true;
        }

        public void Output(LogMessage logMessage)
        {
            string formatMsg = MsgFormater.FormatString(logMessage);
            sw.WriteLine(formatMsg);
        }
    }
}