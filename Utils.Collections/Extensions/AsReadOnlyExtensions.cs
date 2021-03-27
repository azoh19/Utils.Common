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
        public static IReadOnlyCollection<T> AsReadOnly<T>(this ICollection<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source as IReadOnlyCollection<T> ?? new ReadOnlyCollectionWrapper<T>(source);
        }

        public static IReadOnlyCollection<T> ToReadOnly<T>(this ICollection<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new ReadOnlyCollectionWrapper<T>(source);
        }

        public static IReadOnlyList<T> AsReadOnly<T>(this IList<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source as IReadOnlyList<T> ?? new ReadOnlyListWrapper<T>(source);
        }

        public static IReadOnlyList<T> ToReadOnly<T>(this IList<T> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new ReadOnlyListWrapper<T>(source);
        }

        public static IReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return source as IReadOnlyDictionary<TKey, TValue> ?? new ReadOnlyDictionaryWrapper<TKey, TValue>(source);
        }

        public static IReadOnlyDictionary<TKey, TValue> ToReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new ReadOnlyDictionaryWrapper<TKey, TValue>(source);
        }
    }
}
