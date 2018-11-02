using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Wallet.Collection.Infrastructure.Contract;

namespace Wallet.Collection.Infrastructure.Helpers
{
    public class JsonSerialization : IJsonSerializer
    {
        /// <summary>
        /// object tipli sınıfı json string döner
        /// </summary>
        public string JsonSerialize(dynamic source, int maxDepth, int nullValueHandling = 0)
        {
            if (source == null)
                return string.Empty;

            using (var strWriter = new StringWriter())
            {
                using (var jsonWriter = new CustomJsonTextWriter(strWriter))
                {
                    Func<bool> include = () => jsonWriter.CurrentDepth <= maxDepth;
                    var resolver = new CustomJsonContractResolver(include);
                    var serializer = new JsonSerializer
                    {
                        NullValueHandling = (NullValueHandling)nullValueHandling,
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                        ContractResolver = resolver
                    };
                    serializer.Serialize(jsonWriter, source);
                }
                return strWriter.ToString();
            }
        }

        /// <summary>
        /// object tipli sınıfı json string döner
        /// </summary>
        public string JsonSerialize(dynamic source, bool applyFormatting = true)
        {
            if (source == null)
                return string.Empty;

            return JsonConvert.SerializeObject(source, applyFormatting ? Formatting.Indented : Formatting.None);
        }

        /// <summary>
        /// json string object çevirir
        /// </summary>
        public T JsonDeserialize<T>(string source, int nullValueHandling = 0)
        {
            if (source == string.Empty)
            {
                return default(T);
            }

            return JsonConvert.DeserializeObject<T>(source, new JsonSerializerSettings { NullValueHandling = (NullValueHandling)nullValueHandling, TypeNameHandling = TypeNameHandling.All });
        }
    }
}
