using System;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Wallet.Collection.Infrastructure.Helpers
{
    public class CustomJsonTextWriter : JsonTextWriter
    {
        public CustomJsonTextWriter(TextWriter textWriter) : base(textWriter) { }

        public int CurrentDepth { get; private set; }

        public override void WriteStartObject()
        {
            CurrentDepth++;
            base.WriteStartObject();
        }

        public override void WriteEndObject()
        {
            CurrentDepth--;
            base.WriteEndObject();
        }
    }

    public class CustomJsonContractResolver : DefaultContractResolver
    {
        private readonly Func<bool> _includeProperty;

        public CustomJsonContractResolver(Func<bool> includeProperty)
        {
            _includeProperty = includeProperty;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            var shouldSerialize = property.ShouldSerialize;
            property.ShouldSerialize = obj => _includeProperty() &&
                                              (shouldSerialize == null ||
                                               shouldSerialize(obj));
            return property;
        }

        private bool IsMemberDynamicProxyMixin(MemberInfo memberInfo)
        {
            return memberInfo.Name == "__interceptors";
        }

        private bool IsMemberIsCollection(MemberInfo memberInfo, Type objectType)
        {
            if (memberInfo.MemberType == MemberTypes.Property)
            {
                bool isIEnumerable = null != ((PropertyInfo)memberInfo).PropertyType.GetInterface("IEnumerable`1");
                bool isICollection = ((PropertyInfo)memberInfo).PropertyType.Name.Equals("ICollection`1");
                bool isDictionary = ((PropertyInfo)memberInfo).PropertyType.Name.Equals("Dictionary`2");
                bool isArray = memberInfo.GetType().IsArray;
                bool isString = ((PropertyInfo)memberInfo).PropertyType.Name.Equals("String");
                if (isString)
                    return false;
                if (isIEnumerable || isICollection || isArray || isDictionary)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
