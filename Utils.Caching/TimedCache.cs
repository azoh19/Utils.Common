#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.Caching
{
    [PublicAPI]
    public class TimedCache<TData>
    {
        private readonly TimeSpan _cachePeriod;

        private readonly object _lock = new object();

        private TData _data;

        private DateTime _nextRefresh = DateTime.MinValue;

        public TimedCache(TimeSpan cachePeriod)
        {
            _cachePeriod = cachePeriod;
        }

        [CanBeNull]
        public TData Get([NotNull] Func<TData> refresh)
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

        public void Clear() => _nextRefresh = DateTime.MinValue;
    }
}
