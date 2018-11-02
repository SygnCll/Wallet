using System;
using Wallet.Collection.Infrastructure.Enums;

namespace Wallet.Collection.Domain.DataModel
{
    public partial class AccountType : Entity<AccountType, int>
    {
        protected AccountType()
        {
        }

        public virtual string Code { get; protected set; }

        public virtual AccountTypeEnum Type { get; protected set; }

        public virtual int CurrenyCode { get; protected set; }
    }
}
