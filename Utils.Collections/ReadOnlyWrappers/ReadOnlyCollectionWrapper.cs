#region Using

using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.Collections.ReadOnlyWrappers
{
    [PublicAPI]
    public class ReadOnlyCollectionWrapper<T> : IReadOnlyCollection<T>
    {
        private readonly ICollection<T> _source;

        public ReadOnlyCollectionWrapper([NotNull] ICollection<T> source)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
        }

        #region IReadOnlyCollection<T> Members

        #region Implementation of IReadOnlyCollection<out T>

        public int Count => _source.Count;

        #endregion

        #endregion

        #region Implementation of IEnumerable

        public IEnumerator<T> GetEnumerator() => _source.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
