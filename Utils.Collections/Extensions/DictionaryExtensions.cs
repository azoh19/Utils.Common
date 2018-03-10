#region Using

using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.Collections.Extensions
{
    [PublicAPI]
    public static class DictionaryExtensions
    {
        [CanBeNull]
        public static TValue GetOrDefault<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> dictionary, TKey key, TValue @default = default(TValue))
            => dictionary.TryGetValue(key, out var value) ? value : @default;

        [CanBeNull]
        public static TValue? GetOrNull<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> dictionary, TKey key) where TValue : struct
            => dictionary.TryGetValue(key, out var value) ? value : (TValue?)null;

        [CanBeNull]
        public static TValue GetOrDefault<TKey, TValue>([NotNull] this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key, TValue @default = default(TValue))
            => dictionary.TryGetValue(key, out var value) ? value : @default;

        [CanBeNull]
        public static TValue? GetOrNull<TKey, TValue>([NotNull] this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key) where TValue : struct
            => dictionary.TryGetValue(key, out var value) ? value : (TValue?)null;
    }
}
