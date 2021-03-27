#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.StructParsers
{
    [PublicAPI]
    public sealed class IntParser : IStructParser<int>
    {
        int IStructParser<int>.ParseOrDefault(string value, int @default)
            => ParseOrDefault(value, @default);

        int? IStructParser<int>.Parse(string value)
            => Parse(value);

        public static int? Parse(string value)
            => int.TryParse(value, out var result) ? result : (int?)null;

        public static int ParseOrDefault(string value, int @default = default)
            => Parse(value) ?? @default;
    }
}
