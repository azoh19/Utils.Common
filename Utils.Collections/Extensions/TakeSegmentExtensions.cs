#region Using

using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Utils.Collections.Segments;

#endregion

namespace Utils.Collections.Extensions
{
    [PublicAPI]
    public static class TakeSegmentExtensions
    {
        public static IReadOnlyList<T> TakeSegment<T>(this T[] source, int offset, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new ArraySegment<T>(source, offset, count);
        }

        public static IReadOnlyList<T> TakeSegment<T>(this IReadOnlyList<T> source, int offset, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            return new ListSegment<T>(source, offset, count);
        }
    }
}
