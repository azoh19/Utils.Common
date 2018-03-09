#region Using

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Utils.Collections.ReadOnlyWrappers;

#endregion

namespace Utils.Collections.Extensions
{
    [PublicAPI]
    public static class AsReadOnlyExtensions
    {
        [NotNull]
        public static IReadOnlyCollection<T> AsReadOnly<T>([NotNull] this ICollection<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source as IReadOnlyCollection<T> ?? new ReadOnlyCollectionWrapper<T>(source);
        }

        [NotNull]
        public static IReadOnlyCollection<T> AsReadOnlyStrict<T>([NotNull] this ICollection<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new ReadOnlyCollectionWrapper<T>(source);
        }

        [NotNull]
        public static IReadOnlyList<T> AsReadOnly<T>([NotNull] this IList<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source as IReadOnlyList<T> ?? new ReadOnlyListWrapper<T>(source);
        }

        [NotNull]
        public static IReadOnlyList<T> AsReadOnlyStrict<T>([NotNull] this IList<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new ReadOnlyListWrapper<T>(source);
        }

        [NotNull]
        public static IReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source as IReadOnlyDictionary<TKey, TValue> ?? new ReadOnlyDictionaryWrapper<TKey, TValue>(source);
        }

        [NotNull]
        public static IReadOnlyDictionary<TKey, TValue> AsReadOnlyStrict<TKey, TValue>([NotNull] this IDictionary<TKey, TValue> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new ReadOnlyDictionaryWrapper<TKey, TValue>(source);
        }
    }
}
