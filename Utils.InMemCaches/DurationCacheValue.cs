#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.InMemCaches
{
    [PublicAPI]
    public class DurationCacheValue<TData> where TData : class
    {
        private readonly TimeSpan _cachePeriod;

        private readonly object _lock = new object();

        private TData? _data;

        private DateTime _nextRefresh = DateTime.MinValue;

        public DurationCacheValue(TimeSpan cachePeriod)
        {
            _cachePeriod = cachePeriod;
        }

        public TData? Get(Func<TData> refresh)
        {
            var now = DateTime.UtcNow;

            if (_nextRefresh > now)
                return _data;

            lock (_lock)
            {
                if (_nextRefresh > now)
                    return _data;

                _data = refresh();

                _nextRefresh = now + _cachePeriod;
            }

            return _data;
        }

        public void Clear()
            => _nextRefresh = DateTime.MinValue;
    }
}
