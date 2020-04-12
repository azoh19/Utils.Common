#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Structs.Parsers
{
    [PublicAPI]
    public sealed class DecimalParser : IStructParser<decimal>
    {
        public static decimal? Parse(string value) => decimal.TryParse(value, out var result) ? result : (decimal?)null;

        public static decimal ParseOrDefault(string value, decimal @default = default) => Parse(value) ?? @default;

        #region Implementation of IStructParser<decimal>

        decimal IStructParser<decimal>.ParseOrDefault(string value, decimal @default) => ParseOrDefault(value, @default);

        decimal? IStructParser<decimal>.Parse(string value) => Parse(value);

        #endregion
    }
}
