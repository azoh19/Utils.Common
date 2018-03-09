#region Using

using System;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.Collections.ReadOnlyWrappers
{
    [PublicAPI]
    public class ReadOnlyDictionaryWrapper<TKey, TValue> : ReadOnlyCollectionWrapper<KeyValuePair<TKey, TValue>>,
                                                           IReadOnlyDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> _source;

        public ReadOnlyDictionaryWrapper([NotNull] IDictionary<TKey, TValue> source)
            : base(source)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
        }

        #region Implementation of IReadOnlyDictionary<TKey,TValue>

        public bool ContainsKey(TKey key) => _source.ContainsKey(key);

        public bool TryGetValue(TKey key, out TValue value) => _source.TryGetValue(key, out value);

        public TValue this[TKey key] => _source[key];

        public IEnumerable<TKey> Keys => _source.Keys;

        public IEnumerable<TValue> Values => _source.Values;

        #endregion
    }
}
