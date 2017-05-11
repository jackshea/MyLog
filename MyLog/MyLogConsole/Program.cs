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

            MyLog.Info("信息");
            MyLog.Debug("调试");
            MyLog.Warn("警告");
            MyLog.Error("错误");
            MyLog.Fatal("致命错误");

            MyLog.Level = LogLevel.Warn;
            MyLog.Info("信息2");
            MyLog.Debug("调试2");
            MyLog.Warn("警告2");
            MyLog.Error("错误2");
            MyLog.Fatal("致命错误2");

            MyLog.Level = LogLevel.All;
            MyLog.Info("信息1", "cate1");
            MyLog.Info("信息2", "cate1");
            MyLog.Info("信息3", "cate2");
            MyLog.Info("信息4", "cate2");

            MyLog.AddEnableCategory("All");
            MyLog.Info("信息1", "cate1");
            MyLog.Info("信息2", "cate1");
            MyLog.Info("信息3", "cate2");
            MyLog.Info("信息4", "cate2");
            MyLog.RemoveEnableCategory("All");

            MyLog.AddEnableCategory("cate1");
            MyLog.Info("信息1", "cate1");
            MyLog.Info("信息2", "cate1");
            MyLog.Info("信息3", "cate2");
            MyLog.Info("信息4", "cate2");
            MyLog.RemoveEnableCategory("cate1");

            for (int i = 0; i < 10; i++)
            {
                MyLog.Warn(i.ToString());
            }

            Console.ReadLine();
        }
    }
}
