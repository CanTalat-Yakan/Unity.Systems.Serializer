using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace UnityEssentials
{
    public static class SerializerUtility
    {
        public static string GetPath<T>(string fileName, string extension = "json")
        {
            var baseDir = Path.Combine(Application.dataPath, "..", "Resources");
            return Path.Combine(baseDir, $"{Sanitize(fileName)}.{extension}");
        }

        public static string Sanitize(string name)
        {
            foreach (var c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return string.IsNullOrWhiteSpace(name) ? "Default" : name.Trim();
        }

        public static string GetLastSegment(string path)
        {
            if (string.IsNullOrEmpty(path)) return string.Empty;
            var idx = path.LastIndexOf('/');
            return idx >= 0 ? path[(idx + 1)..] : path;
        }

        public static string GetGroupPath(string key)
        {
            if (string.IsNullOrEmpty(key)) return string.Empty;
            var idx = key.LastIndexOf('/');
            return idx >= 0 ? key[..idx] : string.Empty;
        }

        public static string LabelizePathSegment(string segment)
        {
            if (string.IsNullOrWhiteSpace(segment)) return string.Empty;

            // Replace underscores/dashes with spaces, then insert spaces between camel-case boundaries.
            segment = segment.Trim().Replace('_', ' ').Replace('-', ' ');

            var chars = new List<char>(segment.Length * 2);
            char prev = '\0';
            for (var i = 0; i < segment.Length; i++)
            {
                var c = segment[i];
                if (i > 0 && char.IsLetter(c) && char.IsUpper(c) && char.IsLetter(prev) && char.IsLower(prev))
                    chars.Add(' ');
                chars.Add(c);
                prev = c;
            }

            // Normalize multiple spaces.
            var normalized = new string(chars.ToArray());
            while (normalized.Contains("  "))
                normalized = normalized.Replace("  ", " ");

            return normalized;
        }
    }
}