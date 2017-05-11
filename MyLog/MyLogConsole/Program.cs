using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YezhStudio.Base;

namespace MyLogConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var commonMsgFormater = new CommonMsgFormater();
            MyLog.AddListener(new ConsoleOutput(commonMsgFormater));
            MyLog.AddListener(new FileOutput(@"D:/MyLog.txt", commonMsgFormater));
            MyLog.Level = LogLevel.Warn;

            MyLog.Error("aa", "bb");
            MyLog.Debug("debug");
            MyLog.Info("Info");


            for (int i = 0; i < 10; i++)
            {
                MyLog.Warn(i.ToString());
            }

            Console.ReadLine();
        }
    }
}
