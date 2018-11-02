using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Collection.Domain.Resource
{
    public static class ResponseMessages
    {
        private static readonly ResourceManager resourceManager = new ResourceManager("Wallet.Collection.Domain.Resource.ResponseMessage", Assembly.GetExecutingAssembly());
        
        public static string Get(string name, string languageCode)
        {
            return resourceManager.GetString(name, CultureInfo.CreateSpecificCulture(languageCode ?? ConfigurationManager.AppSettings["DefaultLanguageCode"]));
        }
    }
}
