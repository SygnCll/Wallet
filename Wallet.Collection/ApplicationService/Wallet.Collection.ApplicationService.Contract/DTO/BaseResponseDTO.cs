using System;
using System.Runtime.Serialization;

namespace Wallet.Collection.ApplicationService.Contract
{
    using Wallet.Collection.Infrastructure.Enums;

    [Serializable]
    [DataContract]
    public class BaseResponseDTO
    {
        public BaseResponseDTO() : this(ServiceResponseCode.RM0000.ToString(), 0)
        {
            this.Header = new ResponseHeader();
        }

        public BaseResponseDTO(string responseCode)
        {
            this.Header = new ResponseHeader();
            this.Header.ResponseCode = responseCode.ToString();
        }

        public BaseResponseDTO(string responseCode, int status)
        {
            this.Header = new ResponseHeader();
            this.Header.ResponseCode = responseCode.ToString();
            this.Header.Status = status;
        }


        [DataMember]
        public ResponseHeader Header { get; set; }
    }
}