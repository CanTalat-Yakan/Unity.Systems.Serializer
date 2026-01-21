using System;

namespace UnityEssentials
{
    [Serializable]
    public sealed class SerializerEnvelope<T>
    {
        public string Type;
        public string Name;
        public int SchemaVersion;
        public string UpdatedUtc;
        public T Values;

        public static SerializerEnvelope<T> Create(string name, int schemaVersion, T Values)
        {
            return new SerializerEnvelope<T>
            {
                Type = typeof(T).Name,
                Name = name,
                SchemaVersion = schemaVersion,
                UpdatedUtc = DateTime.UtcNow.ToString("O"),
                Values = Values
            };
        }
    }
}