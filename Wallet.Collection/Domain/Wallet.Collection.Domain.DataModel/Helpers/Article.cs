using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Collection.Domain.DataModel.Helpers
{
    public class Article : EntityBase
    {
        public virtual User User { get; set; }
    }
}
