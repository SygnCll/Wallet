using System;

namespace Wallet.Collection.Domain.DataModel
{
    public class EntityBase
    {
        public virtual DateTime CreatedOn { get; set; }
        public virtual long CreatedBy { get; set; }
    }
}
