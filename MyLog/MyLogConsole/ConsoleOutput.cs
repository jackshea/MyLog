using System;
using YezhStudio.Base;

namespace MyLogConsole
{
    public class ConsoleOutput : IOutput
    {
        private readonly DateTime _initTime;
        public IFormater MsgFormater { get; set; }

        public ConsoleOutput(IFormater iFormater)
        {
            _initTime = DateTime.Now;
            MsgFormater = iFormater;
        }
        
        public void Output(string message, string category, LogLevel logLevel)
        {
            string formatMsg = MsgFormater.FormatString(message, category, logLevel);
            formatMsg = string.Format("[{1,4}] {0}", formatMsg, (int)(DateTime.Now - _initTime).TotalMilliseconds);
            Console.WriteLine(formatMsg);
        }
    }
}