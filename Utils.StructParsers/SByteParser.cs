#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.StructParsers
{
    [PublicAPI]
    public sealed class SByteParser : IStructParser<sbyte>
    {
        sbyte IStructParser<sbyte>.ParseOrDefault(string value, sbyte @default)
            => ParseOrDefault(value, @default);

        sbyte? IStructParser<sbyte>.Parse(string value)
            => Parse(value);

        public static sbyte? Parse(string value)
            => sbyte.TryParse(value, out var result) ? result : (sbyte?)null;

        public static sbyte ParseOrDefault(string value, sbyte @default = default)
            => Parse(value) ?? @default;
    }
}
