#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.StructParsers
{
    [PublicAPI]
    public sealed class LongParser : IStructParser<long>
    {
        long IStructParser<long>.ParseOrDefault(string value, long @default)
            => ParseOrDefault(value, @default);

        long? IStructParser<long>.Parse(string value)
            => Parse(value);

        public static long? Parse(string value)
            => long.TryParse(value, out var result) ? result : (long?)null;

        public static long ParseOrDefault(string value, long @default = default)
            => Parse(value) ?? @default;
    }
}
