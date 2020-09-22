#region Using

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.Caching
{
    [PublicAPI]
    public class TimedKeyValueCache<TKey, TValue>
    {
        private readonly TimeSpan _cachePeriod;

        private readonly ConcurrentDictionary<TKey, TimedCache<TValue>> _storage;

        public TimedKeyValueCache(TimeSpan cachePeriod, IEqualityComparer<TKey> comparer = null)
        {
            _cachePeriod = cachePeriod;

            _storage = new ConcurrentDictionary<TKey, TimedCache<TValue>>(comparer ?? EqualityComparer<TKey>.Default);
        }

        public TValue GetValue(TKey key, Func<TValue> refresh)
        {
            var cache = _storage.GetOrAdd(key, _ => new TimedCache<TValue>(_cachePeriod));

            return cache.Get(refresh);
        }

        public void Clear(TKey key)
        {
            _storage.TryRemove(key, out _);
        }

        public void ClearAll()
        {
            _storage.Clear();
        }
    }
}
