#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.StructParsers
{
    [PublicAPI]
    public sealed class ShortParser : IStructParser<short>
    {
        short IStructParser<short>.ParseOrDefault(string value, short @default)
            => ParseOrDefault(value, @default);

        short? IStructParser<short>.Parse(string value)
            => Parse(value);

        public static short? Parse(string value)
            => short.TryParse(value, out var result) ? result : (short?)null;

        public static short ParseOrDefault(string value, short @default = default)
            => Parse(value) ?? @default;
    }
}
