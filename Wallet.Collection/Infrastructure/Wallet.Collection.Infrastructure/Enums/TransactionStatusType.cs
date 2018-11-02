namespace Wallet.Collection.Infrastructure.Enums
{
    public enum TransactionStatusType : int
    {
        Success = 1,
        Failure = 0,
        Retry = -1,
        Cancel = -2
    }
}
