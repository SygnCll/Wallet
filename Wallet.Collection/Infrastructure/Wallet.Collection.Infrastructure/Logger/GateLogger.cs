using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Wallet.Collection.Infrastructure
{
    using Wallet.Collection.Infrastructure.Helpers;
    using Wallet.Collection.Infrastructure.Contract;
    using Wallet.Collection.Infrastructure.Enums;

    public class GateLogger : IGateLogger
    {
        private const string LOGGER_NAME = "GateLogger";
        private ILogger Logger;
        
        public GateLogger(ILogger logger)
        {
            RegexOperations.BuildRegexes();
            this.Logger = logger;
        }

        public void LogForIncoming(Guid trackId, string remoteEndPoint, string methodName, string requestMessage, string responseMessage, string duration)
        {
            try
            {
                requestMessage = RegexOperations.AlterMessage(requestMessage);
                responseMessage = RegexOperations.AlterMessage(responseMessage);

                this.Logger.Log(trackId, "Incoming", LOGGER_NAME, LogType.Information, remoteEndPoint, methodName, requestMessage, responseMessage, duration);
            }
            catch (Exception ex)
            {
                this.Logger.Log(trackId, "Exception: Incoming ", LOGGER_NAME, LogType.Error, ex);
            }
        }

        public void LogForOutgoing(Guid trackId, string remoteEndPoint, string methodName, string requestMessage, string responseMessage, string duration)
        {
            try
            {
                requestMessage = RegexOperations.AlterMessage(requestMessage);
                responseMessage = RegexOperations.AlterMessage(responseMessage);

                this.Logger.Log(trackId, "Outgoing", LOGGER_NAME, LogType.Information, remoteEndPoint, methodName, requestMessage, responseMessage, duration);
            }
            catch (Exception ex)
            {
                this.Logger.Log(trackId, "Exception: Outgoing ", LOGGER_NAME, LogType.Error, ex);
            }
        }
    }
}
