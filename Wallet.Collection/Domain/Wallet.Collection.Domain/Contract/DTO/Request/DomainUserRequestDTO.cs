using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Collection.Domain.Contract
{
    public class DomainUserRequestDTO : DomainRequestDTOBase
    {
        public string Email { get; set; }
        public string NewPassword { get; set; }
    }
}
