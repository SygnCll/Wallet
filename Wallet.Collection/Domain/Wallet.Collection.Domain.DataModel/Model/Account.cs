using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Collection.Infrastructure.Enums;

namespace Wallet.Collection.Domain.DataModel
{
    public partial class Account : Entity<Account, long>
    {
        public Account()
        {
            //Transactions = new HashSet<Transaction>();
        }

        public virtual string AccountNumber { get; protected set; }
        public virtual StatusType Status { get; protected set; }
        public virtual long UserId { get; protected set; }
        public virtual int AccountTypeId { get; protected set; }
        

        [ForeignKey("UserId")]
        public virtual User User { get; protected set; }

        [ForeignKey("AccountTypeId")]
        public virtual AccountType AccountType { get; protected set; }

        
        public virtual ICollection<Transaction> Transactions { get; protected set; }
    }
}
