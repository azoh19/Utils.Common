#region Using

using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.Collections.Extensions
{
    [PublicAPI]
    public static class DictionaryExtensions
    {
        public static TValue? GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue? @default = default)
            where TValue : struct
            => dictionary.TryGetValue(key, out var value) ? value : @default;

        public static TValue? GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue? @default = default)
            where TValue : class
            => dictionary.TryGetValue(key, out var value) ? value : @default;
    }
}
