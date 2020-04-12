#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Structs.Parsers
{
    [PublicAPI]
    public sealed class ShortParser : IStructParser<short>
    {
        public static short? Parse(string value) => short.TryParse(value, out var result) ? result : (short?)null;

        public static short ParseOrDefault(string value, short @default = default) => Parse(value) ?? @default;

        #region Implementation of IStructParser<short>

        short IStructParser<short>.ParseOrDefault(string value, short @default) => ParseOrDefault(value, @default);

        short? IStructParser<short>.Parse(string value) => Parse(value);

        #endregion
    }
}
