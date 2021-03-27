#region Using

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.InMemCaches
{
    [PublicAPI]
    public class DurationCache<TKey, TValue> where TKey : notnull where TValue : class
    {
        private readonly TimeSpan _cachePeriod;

        private readonly ConcurrentDictionary<TKey, DurationCacheValue<TValue>> _storage;

        public DurationCache(TimeSpan cachePeriod, IEqualityComparer<TKey>? comparer = null)
        {
            _cachePeriod = cachePeriod;

            _storage = new ConcurrentDictionary<TKey, DurationCacheValue<TValue>>(comparer ?? EqualityComparer<TKey>.Default);
        }

        public TValue? GetValue(TKey key, Func<TValue> refresh)
        {
            var cache = _storage.GetOrAdd(key, _ => new DurationCacheValue<TValue>(_cachePeriod));

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
