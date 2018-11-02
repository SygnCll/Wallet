using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Collection.Domain.Contract
{
    public class DomainRequestDTOBase
    {
        public DomainRequestDTOBase()
        {
        }

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

    }
}
