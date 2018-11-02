using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Collection.Infrastructure.Contract;

namespace Wallet.Collection.Infrastructure.Helpers
{
    public class CurrencyProvider : ICurrencyProvider
    {
        private static List<Currency> Currencies;

        public CurrencyProvider()
        {
            Currencies = new List<Currency>
            {
                new Currency { Name = "Euro", Iso3LetterCode = "EUR", IsoNumericCode = 978, Symbol = "€‏", Culture = "fr-FR" },
                new Currency { Name = "US Dollar", Iso3LetterCode = "USD", IsoNumericCode = 840, Symbol = "$", Culture = "en-US" },
                new Currency { Name = "Turkish Lira", Iso3LetterCode = "TRY", IsoNumericCode = 949, Symbol = "TL‏", Culture = "tr-TR" }
            };
        }

        public Currency GetCurrency(int isoNumericCode)
        {
            Currency currency = Currencies.SingleOrDefault(c => c.IsoNumericCode == isoNumericCode);

            if (currency == null)
            {
                throw new ArgumentOutOfRangeException("IsoNumericCode", isoNumericCode, "The value isn't a valid ISO 4217 numeric currency code.");
            }
            return currency;
        }

        public Currency GetCurrency(string Iso3LetterCode)
        {
            Currency currency = Currencies.SingleOrDefault(c => c.Iso3LetterCode == Iso3LetterCode);
            if (currency == null)
            {
                throw new ArgumentException("Unknown currency code : " + Iso3LetterCode);
            }
            return currency;
        }
    }
}