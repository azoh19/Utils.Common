#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Utils.Collections.Extensions
{
    [PublicAPI]
    public static class CommonExtensions
    {
        public static IEnumerable<T> Wrap<T>([CanBeNull] this T obj)
            => obj == null ? Enumerable.Empty<T>() : new[] { obj };

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source,
                                                                     Func<TSource, TKey> selector,
                                                                     IEqualityComparer<TKey>? comparer = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return DistinctByIterator(source, selector, comparer ?? EqualityComparer<TKey>.Default);
        }

        private static IEnumerable<TSource> DistinctByIterator<TSource, TKey>(IEnumerable<TSource> source,
                                                                              Func<TSource, TKey> selector,
                                                                              IEqualityComparer<TKey> comparer)
        {
            var set = new HashSet<TKey>(comparer);
            return source.Where(e => set.Add(selector(e)));
        }

        // ReSharper disable once RedundantEnumerableCastCall
        public static IEnumerable<T> SkipNulls<T>([ItemCanBeNull] this IEnumerable<T?> source) where T : class
            => source.OfType<T>();

        public static IEnumerable<T> SkipNulls<T>([ItemCanBeNull] this IEnumerable<T?> source) where T : struct
            => source.Where(item => item.HasValue).Select(item => item!.Value);
    }
}
