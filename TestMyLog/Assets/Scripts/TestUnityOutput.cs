using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YezhStudio.Base;

public class TestUnityOutput : MonoBehaviour
{
    public void Awake()
    {

    }

    public void Start()
    {
        MyLog.AddListener(new UnityOutput());

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
    }
}
