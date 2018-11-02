using System;
using System.Runtime.Serialization;

namespace Wallet.Collection.ApplicationService.Contract
{
    [DataContract]
    [Serializable]
    public class ResponseHeader
    {
        [DataMember]
        public string ResponseCode { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
