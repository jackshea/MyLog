using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YezhStudio.Base;

public class UnityOutput : IOutput
{
    public IFormater MsgFormater { get; set; }

    public UnityOutput()
    {
        MsgFormater = new CommonMsgFormater();
    }

    public void Output(string message, string category, LogLevel logLevel)
    {
        string formatMsg = MsgFormater.FormatString(message, category, logLevel);
        if (logLevel == LogLevel.Warn)
        {
            Debug.LogWarning(formatMsg);
        }
        else if (logLevel == LogLevel.Error || logLevel == LogLevel.Fatal)
        {
            Debug.LogError(formatMsg);
        }
        else
        {
            Debug.Log(formatMsg);
        }
    }
}
