using System.Linq;
using System.Threading;
using System.Configuration;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Wallet.Collection.Infrastructure.Helpers
{
    public static class RegexOperations
    {
        public static List<Regex> Regexes
        {
            get
            {
                var ctx = Thread.GetData(Thread.GetNamedDataSlot("Regexes")) as List<Regex>;
                if (ctx == null)
                {
                    ctx = new List<Regex>();
                    Thread.SetData(Thread.GetNamedDataSlot("Regexes"), ctx);
                }

                return ctx;
            }

            set
            {
                Thread.SetData(Thread.GetNamedDataSlot("Regexes"), value);
            }
        }

        public static string AlterMessage(string message)
        {
            foreach (Regex regex in Regexes.ToList())
            {
                message = Regex.Replace(message,
                    regex.ToString(),
                    delegate (Match m)
                    {
                        string[] a = m.Groups[0].Value.Split('=');
                        string b = m.Groups[1].Value.Trim();
                        return a[0].Trim() + "=\"********\"";
                    },
                RegexOptions.Compiled);
            }

            return message;
        }

        private static string[] GetMaskFilters()
        {
            string maskedAttributes = ConfigurationManager.AppSettings["MaskList"];
            if (maskedAttributes == null)
            {
                return null;
            }

            return maskedAttributes.Split(';');
        }

        public static void BuildRegexes()
        {
            string[] maskedAttributes = GetMaskFilters();
            if (maskedAttributes != null)
            {
                if (Regexes != null && Regexes.Count < maskedAttributes.Count())
                {
                    foreach (string maskedAttribute in maskedAttributes.ToList())
                    {
                        Regexes.Add(new Regex(maskedAttribute.Trim() + "\\s*=\".*?\"", RegexOptions.Compiled));
                    }
                }
            }
        }
    }
}
