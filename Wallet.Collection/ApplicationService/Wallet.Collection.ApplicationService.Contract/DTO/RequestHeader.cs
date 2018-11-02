using System;
using System.Runtime.Serialization;

namespace Wallet.Collection.ApplicationService.Contract
{
    [DataContract]
    [Serializable]
    public class RequestHeader
    {
        [DataMember]
        public Guid TrackId { get; set; }

        [DataMember]
        public string SessionId { get; set; }

        [DataMember]
        public string LanguageCode { get; set; }

        [DataMember]
        public string HostAddress { get; set; }

        [DataMember]
        public string HostName { get; set; }

        [DataMember]
        public long UserId { get; set; }
    }
}
