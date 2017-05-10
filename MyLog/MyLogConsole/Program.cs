using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YeZhStudio.Base;

namespace MyLogConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            MyLog.AddListener(new ConsoleLog());
            MyLog.AddListener(new FileLog());
            MyLog.Error("aa", "bb");
            MyLog.Debug("debug");
            MyLog.Info("Info");

            for (int i = 0; i < 10000; i++)
            {
                MyLog.Warn(i.ToString());
            }

            Console.ReadLine();
        }
    }
}
