#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Structs.Parsers
{
    [PublicAPI]
    public sealed class FloatParser : IStructParser<float>
    {
        public static float? Parse(string value) => float.TryParse(value, out var result) ? result : (float?)null;

        public static float ParseOrDefault(string value, float @default = default(float)) => Parse(value) ?? @default;

        #region Implementation of IStructParser<float>

        float IStructParser<float>.ParseOrDefault(string value, float @default) => ParseOrDefault(value, @default);

        float? IStructParser<float>.Parse(string value) => Parse(value);

        #endregion
    }
}
