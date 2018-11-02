using System;
using System.Runtime.Serialization;
using Wallet.Collection.Infrastructure.Enums;

namespace Wallet.Collection.Domain.Contract
{
    [Serializable]
    [DataContract]
    public class DomainResponseDTOBase
    {
        public DomainResponseDTOBase() : this(ServiceResponseCode.RM0000.ToString(), 0)
        {
        }

        public DomainResponseDTOBase(string responseCode)
        {
            this.ResponseCode = responseCode.ToString(); ;
        }

        public DomainResponseDTOBase(string responseCode, int status)
        {
            this.ResponseCode = responseCode.ToString();
            this.Status = status;
        }

        [DataMember]
        public string ResponseCode { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}