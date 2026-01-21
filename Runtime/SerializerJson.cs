using Newtonsoft.Json;

namespace UnityEssentials
{
    /// <summary>
    /// Central place for Json.NET settings and helpers.
    /// </summary>
    public static class SerializerJson
    {
        public static JsonSerializerSettings DefaultSerializerSettings => new()
        {
            Formatting = Formatting.Indented,
            ContractResolver = new SerializerJsonPropertyFilter(),
            Converters = { new SerializerJsonColorConverter() },
        };

        public static string Serialize<T>(T value) =>
            JsonConvert.SerializeObject(value, DefaultSerializerSettings);

        public static T Deserialize<T>(string json) =>
            JsonConvert.DeserializeObject<T>(json, DefaultSerializerSettings);
    }
}