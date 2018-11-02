using System;
using System.ComponentModel.DataAnnotations.Schema;
using Wallet.Collection.Infrastructure.Enums;

namespace Wallet.Collection.Domain.DataModel
{
    public partial class Transaction : Entity<Transaction, long>
    {
        public Transaction()
        {

        }

        public virtual long AccountId { get; protected set; }
        public virtual long ProvisionId { get; protected set; }
        public virtual TransactionStatusType TransactionStatus { get; protected set; }
        public virtual DateTime TransactionDateTime { get; protected set; }
        public virtual DateTime? AcceptanceDateTime { get; protected set; }
        public virtual BalanceType BalanceType { get; protected set; }
        public virtual Money Money { get; protected set; }


        [ForeignKey("AccountId")]
        public virtual Account Account { get; protected set; }

        [ForeignKey("ProvisionId")]
        public virtual Provision Provision { get; protected set; }
    }
}