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
        [NotNull]
        [ItemNotNull]
        public static IEnumerable<T> Wrap<T>([CanBeNull] this T obj) => obj == null ? Enumerable.Empty<T>() : new[] { obj };

        [NotNull]
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>([NotNull] this IEnumerable<TSource>    source,
                                                                     [NotNull]      Func<TSource, TKey>     selector,
                                                                     [CanBeNull]    IEqualityComparer<TKey> comparer = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return DistinctByIterator(source, selector, comparer ?? EqualityComparer<TKey>.Default);
        }

        private static IEnumerable<TSource> DistinctByIterator<TSource, TKey>(IEnumerable<TSource>    source,
                                                                              Func<TSource, TKey>     selector,
                                                                              IEqualityComparer<TKey> comparer)
        {
            var set = new HashSet<TKey>(comparer);
            return source.Where(e => set.Add(selector(e)));
        }

        [NotNull]
        [ItemNotNull]
        public static IEnumerable<T> SkipNulls<T>([NotNull] [ItemCanBeNull] this IEnumerable<T> source) where T : class => source.Where(e => e != null);

        [NotNull]
        public static IEnumerable<T> SkipNulls<T>([NotNull] [ItemCanBeNull] this IEnumerable<T?> source) where T : struct
            => source.Where(item => item.HasValue).Select(item => item.Value);
    }
}
