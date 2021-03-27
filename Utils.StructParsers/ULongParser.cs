#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.StructParsers
{
    [PublicAPI]
    public sealed class ULongParser : IStructParser<ulong>
    {
        ulong IStructParser<ulong>.ParseOrDefault(string value, ulong @default)
            => ParseOrDefault(value, @default);

        ulong? IStructParser<ulong>.Parse(string value)
            => Parse(value);

        public static ulong? Parse(string value)
            => ulong.TryParse(value, out var result) ? result : (ulong?)null;

        public static ulong ParseOrDefault(string value, ulong @default = default)
            => Parse(value) ?? @default;
    }
}
