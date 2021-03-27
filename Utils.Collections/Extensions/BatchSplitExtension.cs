#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.Collections.Extensions
{
    [PublicAPI]
    public static class BatchSplitExtension
    {
        [ItemNotNull]
        public static IEnumerable<IReadOnlyList<T>> BatchSplit<T>(this IEnumerable<T> source, int batchSize)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (batchSize <= 0)
                throw new ArgumentException("Invalid batch size: " + batchSize, nameof(batchSize));

            switch (source)
            {
                case T[] array:    return ArrayIterator(array, batchSize);
                case List<T> list: return ListIterator(list, batchSize);
                default:           return Iterator(source, batchSize);
            }
        }

        private static IEnumerable<IReadOnlyList<T>> ArrayIterator<T>(T[] source, int batchSize)
        {
            var n = source.Length / batchSize;

            for (var i = 0; i < n; i++)
                yield return source.TakeSegment(i * batchSize, batchSize);

            var rest = source.Length - n * batchSize;

            if (rest > 0)
                yield return source.TakeSegment(n * batchSize, rest);
        }

        private static IEnumerable<IReadOnlyList<T>> ListIterator<T>(List<T> source, int batchSize)
        {
            var n = source.Count / batchSize;

            for (var i = 0; i < n; i++)
                yield return source.TakeSegment(i * batchSize, batchSize);

            var rest = source.Count - n * batchSize;

            if (rest > 0)
                yield return source.TakeSegment(n * batchSize, rest);
        }

        private static IEnumerable<IReadOnlyList<T>> Iterator<T>(IEnumerable<T> source, int batchSize)
        {
            var enumerator = source.GetEnumerator();

            while (enumerator.MoveNext())
                yield return new Batch<T>(enumerator, batchSize);
        }

        private sealed class Batch<T> : IReadOnlyList<T>
        {
            private readonly T[] _data;

            public Batch(IEnumerator<T> enumerator, int capacity)
            {
                _data    = new T[capacity];
                _data[0] = enumerator.Current;

                for (Count = 1; (Count < capacity) && enumerator.MoveNext(); Count++)
                    _data[Count] = enumerator.Current;

                if (Count < capacity)
                    Array.Resize(ref _data, Count);
            }

            public int Count { get; }

            public T this[int index] => _data[index];

            public IEnumerator<T> GetEnumerator()
                => ((IEnumerable<T>)_data).GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator()
                => _data.GetEnumerator();
        }
    }
}
