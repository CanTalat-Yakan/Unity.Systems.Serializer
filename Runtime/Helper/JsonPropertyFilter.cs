using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace UnityEssentials
{
    /// <summary>
    /// Contract resolver that filters UnityEngine.Object properties that shouldn't be serialized.
    /// </summary>
    public sealed class SerializerJsonPropertyFilter : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            if (typeof(UnityEngine.Object).IsAssignableFrom(type))
                properties = properties
                    .Where(p => p.PropertyName != "name" && p.PropertyName != "hideFlags")
                    .ToList();
            return properties;
        }
    }
}
