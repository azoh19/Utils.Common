#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.StructParsers
{
    [PublicAPI]
    public sealed class BoolParser : IStructParser<bool>
    {
        bool IStructParser<bool>.ParseOrDefault(string value, bool @default)
            => ParseOrDefault(value, @default);

        bool? IStructParser<bool>.Parse(string value)
            => Parse(value);

        public static bool? Parse(string value)
            => bool.TryParse(value, out var result) ? result : (bool?)null;

        public static bool ParseOrDefault(string value, bool @default = default)
            => Parse(value) ?? @default;
    }
}
