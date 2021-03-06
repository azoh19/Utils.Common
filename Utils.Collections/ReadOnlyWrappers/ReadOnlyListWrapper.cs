#region Using

using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.Collections.ReadOnlyWrappers
{
    [PublicAPI]
    public class ReadOnlyListWrapper<T> : ReadOnlyCollectionWrapper<T>, IReadOnlyList<T>
    {
        private readonly IList<T> _source;

        public ReadOnlyListWrapper(IList<T> source)
            : base(source)
        {
            _source = source;
        }

        public T this[int index] => _source[index];
    }
}
