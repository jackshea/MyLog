using System;
using System.Collections.Generic;

namespace YeZhStudio.Base
{
    public class BaseLog : ILog
    {
        private readonly List<ILog> _listeners = new List<ILog>();

        public LogLevel LogLevel { get; set; }

        private bool IsDebugEnabled => LogLevel <= LogLevel.Debug;
        private bool IsInfoEnabled => LogLevel <= LogLevel.Info;
        private bool IsWarnEnabled => LogLevel <= LogLevel.Warn;
        private bool IsErrorEnabled => LogLevel <= LogLevel.Error;
        private bool IsFatalEnabled => LogLevel <= LogLevel.Fatal;

        #region ILog Members

        public void Debug(string message)
        {
            if (!IsDebugEnabled)
                return;

            foreach (var listener in _listeners)
                listener.Debug(listener.FormatMessage(message));
        }

        public void Info(string message)
        {
            if (!IsInfoEnabled)
                return;

            foreach (var listener in _listeners)
                listener.Info(listener.FormatMessage(message));
        }

        public void Warn(string message)
        {
            if (!IsWarnEnabled)
                return;

            foreach (var listener in _listeners)
                listener.Warn(listener.FormatMessage(message));
        }

        public void Error(string message)
        {
            if (!IsErrorEnabled)
                return;

            foreach (var listener in _listeners)
                listener.Error(listener.FormatMessage(message));
        }

        public void Fatal(string message)
        {
            if (!IsFatalEnabled)
                return;

            foreach (var listener in _listeners)
                listener.Fatal(listener.FormatMessage(message));
        }

        public string FormatMessage(string message)
        {
            return message;
        }

        #endregion

        public void AddListener(ILog iLog)
        {
            _listeners.Add(iLog);
        }

        public void RemoveListener(ILog iLog)
        {
            _listeners.Remove(iLog);
        }
    }
}