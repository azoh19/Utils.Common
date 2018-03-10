#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

#endregion

namespace Utils.Collections.Extensions
{
    [PublicAPI]
    public static class ShuffleExtensions
    {
        private static readonly Random DefaultRng = new Random((int)DateTime.Now.Ticks);

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) => source.Shuffle(DefaultRng);

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (rng == null)
                throw new ArgumentNullException(nameof(rng));

            return source.ShuffleIterator(rng);
        }

        private static IEnumerable<T> ShuffleIterator<T>(this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();

            for (var i = 0; i < buffer.Count; i++)
            {
                var j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }
    }
}
