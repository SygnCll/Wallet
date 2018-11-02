using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Collection.Domain.DataModel
{
    public partial class Money
    {
        public Money(long amount, short currencyCode)
        {
            this.Amount = amount;
            this.CurrencyCode = currencyCode;
        }

        public virtual void Increase(long amount)
        {
            this.Amount += amount;
        }

        public virtual void Decrease(long amount)
        {
            this.Amount -= amount;
        }

        public virtual void SetMoney(long amount, short currencyCode)
        {
            this.Amount = amount;
            this.CurrencyCode = currencyCode;
        }

        public virtual bool IsEqual(Money money)
        {
            return this.Amount == money.Amount && this.CurrencyCode == money.CurrencyCode;
        }
    }
}
