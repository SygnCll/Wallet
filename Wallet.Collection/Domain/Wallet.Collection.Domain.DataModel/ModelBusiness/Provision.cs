using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Collection.Domain.DataModel
{
    public partial class Provision 
    {
        public Provision(string externalProvision,User user)
        {
            this.ExternalProvision = externalProvision;
            this.User = user;
        }
    }
}
