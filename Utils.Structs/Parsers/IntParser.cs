#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Structs.Parsers
{
    [PublicAPI]
    public sealed class IntParser : IStructParser<int>
    {
        public static int? Parse(string value) => int.TryParse(value, out var result) ? result : (int?)null;

        public static int ParseOrDefault(string value, int @default = default(int)) => Parse(value) ?? @default;

        #region Implementation of IStructParser<int>

        int IStructParser<int>.ParseOrDefault(string value, int @default) => ParseOrDefault(value, @default);

        int? IStructParser<int>.Parse(string value) => Parse(value);

        #endregion
    }
}
