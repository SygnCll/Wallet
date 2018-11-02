using System;
using NLog;
using Wallet.Collection.Infrastructure.Enums; 
using Wallet.Collection.Infrastructure.Contract;

namespace Wallet.Collection.Infrastructure
{
    public class NLogLogger : Contract.ILogger
    {
        public TrackInfo TrackInfo { get; set; }
        

        public void Log(Guid trackId, string message, string logName, LogType logType)
        {
            this.Log(trackId, message, logName, logType, null);
        }

        public void Log(Guid trackId, string message, string logName, LogType logType, Exception exception)
        {
            LogLevel logLevel =  LogTypeToNlogLevel(logType);
            string logDescription = GetLogName(logName, logType);

            LogEventInfo logEventInfo = new LogEventInfo(logLevel, logDescription, null, message, null, exception);

            this.Log(logEventInfo);
        }

        public void Log(Guid trackId, string message, string logName, LogType logType, string remoteEndPoint, string methodName, string requestMessage, string responseMessage, string duration)
        {
            LogLevel logLevel = LogTypeToNlogLevel(logType);

            LogEventInfo logEventInfo = new LogEventInfo(logLevel, logName, null);
            logEventInfo.Properties.Add("TrackId", trackId);
            logEventInfo.Properties.Add("HostAddress", remoteEndPoint);
            logEventInfo.Properties.Add("MethodName", methodName);
            logEventInfo.Properties.Add("RequestMessage", requestMessage);
            logEventInfo.Properties.Add("ResponseMessage", responseMessage);
            logEventInfo.Properties.Add("Duration", duration);

            this.Log(logEventInfo);
        }

        public void Log(Guid trackId, string message, string logName, LogType logType, Exception exception, string remoteEndPoint, string methodName, string requestMessage, string responseMessage, string duration)
        {
            LogLevel logLevel = LogTypeToNlogLevel(logType);

            LogEventInfo logEventInfo = new LogEventInfo(logLevel, "Error" , message);
            logEventInfo.Properties.Add("TrackId", trackId);
            logEventInfo.Properties.Add("HostAddress", remoteEndPoint);
            logEventInfo.Properties.Add("MethodName", methodName);
            logEventInfo.Properties.Add("RequestMessage", requestMessage);
            logEventInfo.Properties.Add("ResponseMessage", responseMessage);
            logEventInfo.Properties.Add("Duration", duration);
            logEventInfo.Exception = exception;

            this.Log(logEventInfo);
        }



        public void Log(LogEventInfo logEventInfo)
        {
            Logger logger = LogManager.GetLogger(logEventInfo.LoggerName);

            if (logEventInfo.Level.Equals(LogLevel.Error))
            {
                if (logger.IsErrorEnabled)
                {
                    logger.Log(logEventInfo);
                }
            }
            else if (logEventInfo.Level.Equals(LogLevel.Info))
            {
                if (logger.IsInfoEnabled)
                {
                    logger.Log(logEventInfo);
                }
            }
            else if (logEventInfo.Level.Equals(LogLevel.Warn))
            {
                if (logger.IsWarnEnabled)
                {
                    logger.Log(logEventInfo);
                }
            }
            else
            {
                if (logger.IsDebugEnabled)
                {
                    logger.Log(logEventInfo);
                }
            }
        }


        #region Private Methods

        private LogLevel LogTypeToNlogLevel(LogType logType)
        {
            switch (logType)
            {
                case LogType.Error:
                    return LogLevel.Error;
                case LogType.Information:
                    return LogLevel.Info;
                case LogType.Warning:
                    return LogLevel.Warn;
                default:
                    return LogLevel.Debug;
            }
        }

        private string GetLogName(string logName, LogType logType)
        {
            if (logName == string.Empty)
            {
                switch (logType)
                {
                    case LogType.Error:
                        return "Error";
                    case LogType.Warning:
                        return "Warning";
                    case LogType.Debug:
                        return "Debug";
                    case LogType.Information:
                        return "Info";
                }
            }

            return logName;
        }


        #endregion
    }
}
