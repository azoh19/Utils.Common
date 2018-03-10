#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.Structs.Parsers
{
    [PublicAPI]
    public sealed class DateTimeParser : IStructParser<DateTime>
    {
        public static DateTime? Parse(string value) => DateTime.TryParse(value, out var result) ? result : (DateTime?)null;

        public static DateTime ParseOrDefault(string value, DateTime @default = default(DateTime)) => Parse(value) ?? @default;

        #region Implementation of IStructParser<DateTime>

        DateTime IStructParser<DateTime>.ParseOrDefault(string value, DateTime @default) => ParseOrDefault(value, @default);

        DateTime? IStructParser<DateTime>.Parse(string value) => Parse(value);

        #endregion
    }
}
