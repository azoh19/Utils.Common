#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.StructParsers
{
    [PublicAPI]
    public sealed class FloatParser : IStructParser<float>
    {
        float IStructParser<float>.ParseOrDefault(string value, float @default)
            => ParseOrDefault(value, @default);

        float? IStructParser<float>.Parse(string value)
            => Parse(value);

        public static float? Parse(string value)
            => float.TryParse(value, out var result) ? result : (float?)null;

        public static float ParseOrDefault(string value, float @default = default)
            => Parse(value) ?? @default;
    }
}
