#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Structs.Parsers
{
    [PublicAPI]
    public sealed class DoubleParser : IStructParser<double>
    {
        public static double? Parse(string value) => double.TryParse(value, out var result) ? result : (double?)null;

        public static double ParseOrDefault(string value, double @default = default(double)) => Parse(value) ?? @default;

        #region Implementation of IStructParser<double>

        double IStructParser<double>.ParseOrDefault(string value, double @default) => ParseOrDefault(value, @default);

        double? IStructParser<double>.Parse(string value) => Parse(value);

        #endregion
    }
}
