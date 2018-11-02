using System.ComponentModel.DataAnnotations.Schema;

namespace Wallet.Collection.Domain.DataModel
{
    using Wallet.Collection.Infrastructure.Enums;

    public partial class AccountActivities : Entity<AccountActivities, long>
    {
        public AccountActivities()
        {
            Money = new Money();
        }

        public virtual long ProvisionId { get; protected set; }
        public virtual long TransactionId { get; protected set; }
        public virtual long AccountId { get; protected set; }
        public virtual Money Money { get; protected set; }
        public virtual BalanceType BalanceType { get; protected set; }


        [ForeignKey("ProvisionId")]
        public virtual Provision Provision { get; protected set; }
        [ForeignKey("TransactionId")]
        public virtual Transaction Transaction { get; protected set; }
        [ForeignKey("AccountId")]
        public virtual Account Account { get; protected set; }
    }
}