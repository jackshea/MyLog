using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YezhStudio.Base;

namespace MyLogConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //test1();
            test2();
            //test3();

            Console.ReadLine();
        }

        private static void test1()
        {
            var commonMsgFormater = new CommonMsgFormater();
            Logger logger = LogManager.CreatLogger();
            LogManager.AddListener(new ConsoleOutput(commonMsgFormater));
            LogManager.AddListener(new FileOutput(@"D:/logger.txt", commonMsgFormater));
            LogManager.AddEnableCategory("All");
            LogManager.Start();
            logger.Level = LogLevel.Warn;

            logger.Info("信息");
            logger.Debug("调试");
            logger.Warn("警告");
            logger.Error("错误");
            logger.Fatal("致命错误");

            logger.Level = LogLevel.Warn;
            logger.Info("信息2");
            logger.Debug("调试2");
            logger.Warn("警告2");
            logger.Error("错误2");
            logger.Fatal("致命错误2");

            logger.Level = LogLevel.All;
            logger.Info("信息1", "cate1");
            logger.Info("信息2", "cate1");
            logger.Info("信息3", "cate2");
            logger.Info("信息4", "cate2");

            LogManager.AddEnableCategory("All");
            logger.Info("信息1", "cate1");
            logger.Info("信息2", "cate1");
            logger.Info("信息3", "cate2");
            logger.Info("信息4", "cate2");
            LogManager.RemoveEnableCategory("All");

            LogManager.AddEnableCategory("cate1");
            logger.Info("信息1", "cate1");
            logger.Info("信息2", "cate1");
            logger.Info("信息3", "cate2");
            logger.Info("信息4", "cate2");
            LogManager.RemoveEnableCategory("cate1");

            for (int i = 0; i < 10; i++)
            {
                logger.Warn(i.ToString());
            }
        }

        private static void test2()
        {
            var commonMsgFormater = new CommonMsgFormater();
            Logger logger = LogManager.CreatLogger();
            LogManager.AddListener(new ConsoleOutput(commonMsgFormater));
            LogManager.AddListener(new FileOutput(@"D:/MyLog.txt", commonMsgFormater));
            LogManager.AddEnableCategory("All");
            LogManager.Start();
            logger.Level = LogLevel.Warn;

            logger.Info("信息");
            logger.Debug("调试");
            logger.Warn("警告");
            logger.Error("错误");
            logger.Fatal("致命错误");

            List<Logger> loggers = new List<Logger>();
            for (int i = 0; i < 10; i++)
            {
                loggers.Add(LogManager.CreatLogger());
            }

            for (int i = 0; i < 10000; i++)
            {
                foreach (Logger logger1 in loggers)
                {
                    logger1.Warn(i.ToString());
                }
            }
        }

        private static void test3()
        {
            var commonMsgFormater = new CommonMsgFormater();
            LogManager.AddListener(new ConsoleOutput(commonMsgFormater));
            LogManager.AddListener(new FileOutput(@"D:/MyLog.txt", commonMsgFormater));
            LogManager.AddEnableCategory("All");
            LogManager.Start();

            for (int j = 0; j < 500; j++)
            {
                new Thread(() =>
               {
                   Logger logger = LogManager.CreatLogger();
                   logger.Level = LogLevel.Debug;

                   for (int i = 0; i < 1000; i++)
                   {
                       logger.Debug(i.ToString());
                       Thread.Sleep(10);
                   }
               }).Start();
            }
        }

    }
}
