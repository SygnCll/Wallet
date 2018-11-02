namespace Wallet.Collection.Domain.DataModel
{
    public partial class Money
    {
        public Money()
        {
        }

        public virtual long Amount { get; protected set; }
        public virtual int CurrencyCode { get; protected set; }
    }
}
