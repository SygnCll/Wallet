namespace Wallet.Collection.Infrastructure.Contract
{
    public class Currency
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Iso3LetterCode { get; set; }
        public int IsoNumericCode { get; set; }
        public string Culture { get; set; }
    }
}
