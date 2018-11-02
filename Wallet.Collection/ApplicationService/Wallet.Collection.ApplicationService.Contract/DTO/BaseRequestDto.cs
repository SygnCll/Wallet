using System;
using System.Runtime.Serialization;

namespace Wallet.Collection.ApplicationService.Contract
{
    using Wallet.Collection.Infrastructure.Enums;

    [DataContract]
    [Serializable]
    public abstract class BaseRequestDto
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
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }



        //[DataMember]
        //public RequestHeader Header { get; set; }
        
        //public BaseRequestDto()
        //{
        //    this.Header = new RequestHeader();
        //}
    }
}