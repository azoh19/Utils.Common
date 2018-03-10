#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Structs.Parsers
{
    [PublicAPI]
    public sealed class ULongParser : IStructParser<ulong>
    {
        public static ulong? Parse(string value) => ulong.TryParse(value, out var result) ? result : (ulong?)null;

        public static ulong ParseOrDefault(string value, ulong @default = default(ulong)) => Parse(value) ?? @default;

        #region Implementation of IStructParser<ulong>

        ulong IStructParser<ulong>.ParseOrDefault(string value, ulong @default) => ParseOrDefault(value, @default);

        ulong? IStructParser<ulong>.Parse(string value) => Parse(value);

        #endregion
    }
}
