using System; 

namespace Wallet.Collection.Infrastructure.Contract
{
    public interface IGateLogger
    {
        void LogForIncoming(Guid trackId, string remoteEndPoint, string methodName, string requestMessage, string responseMessage, string duration);
        void LogForOutgoing(Guid trackId, string remoteEndPoint, string methodName, string requestMessage, string responseMessage, string duration);
    }
}
