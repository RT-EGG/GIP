using System;
using System.Collections.Generic;

namespace GIP
{
    public enum LogLevel
    {
        Information,
        Warning,
        Error,
        Exception,
        Dialogue
    }

    public class LogData
    {
        public LogData(LogLevel inLevel, string inMessage)
        {
            Level = inLevel;
            Message = inMessage;
        }

        public DateTime Time
        { get; } = DateTime.Now;

        public LogLevel Level
        { get; } = LogLevel.Information;

        public string Message
        { get; } = "";
    }

    public class LogExceptionData : LogData
    {
        public LogExceptionData(Exception inException)
            : this (inException, ToString(inException))
        { }

        public LogExceptionData(Exception inException, string inMessage)
            : base (LogLevel.Exception, inMessage)
        {
            BaseException = inException;
            return;
        }

        public Exception BaseException
        { get; } = null;

        public static string ToString(Exception inException)
        {
            return $"{inException.GetType().Name}: {inException.Message}{Environment.NewLine}{inException.StackTrace}";
        }
    }

    public interface ILogger
    {
        void NewSession(string inName);
        void PushLog(object inSource, LogData inData);
    }

    public class LoggerCollection : List<ILogger>, ILogger
    {
        public void NewSession(string inName)
            => ForEach(l => l.NewSession(inName));
        public void PushLog(object inSource, LogData inData)
            => ForEach(l => l.PushLog(inSource, inData));
    }

    public static class Logger
    {
        public static LoggerCollection DefaultLogger
        { get; } = new LoggerCollection();
    }
}
