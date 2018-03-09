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

        public ReadOnlyListWrapper([NotNull] IList<T> source)
            : base(source)
        {
            _source = source;
        }

        #region IReadOnlyList<T> Members

        #region Implementation of IReadOnlyList<out T>

        public T this[int index] => _source[index];

        #endregion

        #endregion
    }
}
