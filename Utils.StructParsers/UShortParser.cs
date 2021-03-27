#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.StructParsers
{
    [PublicAPI]
    public sealed class UShortParser : IStructParser<ushort>
    {
        ushort IStructParser<ushort>.ParseOrDefault(string value, ushort @default)
            => ParseOrDefault(value, @default);

        ushort? IStructParser<ushort>.Parse(string value)
            => Parse(value);

        public static ushort? Parse(string value)
            => ushort.TryParse(value, out var result) ? result : (ushort?)null;

        public static ushort ParseOrDefault(string value, ushort @default = default)
            => Parse(value) ?? @default;
    }
}
