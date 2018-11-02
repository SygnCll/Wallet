using System;

using Wallet.Collection.Infrastructure.Enums;

namespace Wallet.Collection.Infrastructure.Contract
{
    public interface ILogger
    {
        TrackInfo TrackInfo { get; set; }


        void Log(Guid trackId, string message, string logName, LogType logType);

        void Log(Guid trackId, string message, string logName, LogType logType, Exception exception);

        void Log(Guid trackId, string message, string logName, LogType logType,
                 string remoteEndPoint, string methodName, string requestMessage, string responseMessage, string duration);
        void Log(Guid trackId, string message, string logName, LogType logType, Exception exception,
                 string remoteEndPoint, string methodName, string requestMessage, string responseMessage, string duration);
    }

    public class TrackInfo
    {
        public string TrackId { get; set; }
        public string HostName { get; set; }
        public string IpAddress { get; set; }
    }
}
