#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.Structs.Parsers
{
    [PublicAPI]
    public sealed class DateTimeOffsetParser : IStructParser<DateTimeOffset>
    {
        public static DateTimeOffset? Parse(string value) => DateTimeOffset.TryParse(value, out var result) ? result : (DateTimeOffset?)null;

        public static DateTimeOffset ParseOrDefault(string value, DateTimeOffset @default = default) => Parse(value) ?? @default;

        #region Implementation of IStructParser<DateTimeOffset>

        DateTimeOffset IStructParser<DateTimeOffset>.ParseOrDefault(string value, DateTimeOffset @default) => ParseOrDefault(value, @default);

        DateTimeOffset? IStructParser<DateTimeOffset>.Parse(string value) => Parse(value);

        #endregion
    }
}
