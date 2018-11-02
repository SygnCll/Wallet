using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Collections.Generic;
using Wallet.Collection.Domain.DataModel;

namespace Wallet.Collection.Domain.Contract
{
    public class DomainUserResponseDTO : DomainResponseDTOBase
    {
        public User User { get; set; } 

        public long UserId { get; set; }
    }
}
