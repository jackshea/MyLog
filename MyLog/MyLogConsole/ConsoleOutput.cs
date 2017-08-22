using System;
using YezhStudio.Base;

namespace MyLogConsole
{
    public class ConsoleOutput : IOutput
    {
        public IFormater MsgFormater { get; set; }

        public ConsoleOutput(IFormater iFormater)
        {
            MsgFormater = iFormater;
        }
        
        public void Output(LogMessage logMessage)
        {
            string formatMsg = MsgFormater.FormatString(logMessage);
            Console.WriteLine(formatMsg);
        }
    }
}