#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.Collections.Segments
{
    [PublicAPI]
    public struct ListSegment<T> : IReadOnlyList<T>
    {
        private IReadOnlyList<T> Source { get; }

        private int Offset { get; }

        public ListSegment(IReadOnlyList<T> source, int offset, int count)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset), $@"""{nameof(offset)}"" is less than zero");

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count), $@"""{nameof(count)}"" is less than zero");

            if (offset > source.Count)
                throw new ArgumentOutOfRangeException(nameof(offset), $@"""{nameof(offset)}"" is greater than collection size");

            if (offset + count > source.Count)
                throw new ArgumentException($@"""{nameof(offset)}+{nameof(count)}"" is greater than collection size");

            Source = source;
            Offset = offset;
            Count  = count;
        }

        public int Count { get; }

        public T this[int index]
        {
            get
            {
                if ((index < 0) || (index >= Count))
                    throw new ArgumentOutOfRangeException(nameof(index));

                return Source[Offset + index];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = Offset; i < Offset + Count; i++)
                yield return Source[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
