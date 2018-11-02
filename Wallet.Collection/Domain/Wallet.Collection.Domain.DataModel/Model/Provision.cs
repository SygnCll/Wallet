using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Collection.Domain.DataModel
{
    public partial class Provision : Entity<Provision, long>
    {
        public Provision()
        {
            //Transactions = new HashSet<Transaction>();
        }

        public virtual string ExternalProvision { get; protected set; }
        public virtual long UserId { get; protected set; }

        [ForeignKey("UserId")]
        public virtual User User { get; protected set; }


        public virtual ICollection<Transaction> Transactions { get; protected set; }
    }
}
