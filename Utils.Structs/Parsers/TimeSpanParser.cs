#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.Structs.Parsers
{
    [PublicAPI]
    public sealed class TimeSpanParser : IStructParser<TimeSpan>
    {
        public static TimeSpan? Parse(string value) => TimeSpan.TryParse(value, out var result) ? result : (TimeSpan?)null;

        public static TimeSpan ParseOrDefault(string value, TimeSpan @default = default(TimeSpan)) => Parse(value) ?? @default;

        #region Implementation of IStructParser<TimeSpan>

        TimeSpan IStructParser<TimeSpan>.ParseOrDefault(string value, TimeSpan @default) => ParseOrDefault(value, @default);

        TimeSpan? IStructParser<TimeSpan>.Parse(string value) => Parse(value);

        #endregion
    }
}
