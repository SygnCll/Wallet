namespace Wallet.Collection.Infrastructure.Contract
{
    public interface ICurrencyProvider
    {
        Currency GetCurrency(int isoNumericCode);
        Currency GetCurrency(string Iso3LetterCode);
    }
}
