#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.Strings
{
    [PublicAPI]
    public static class StringExtensions
    {
        public static string RemoveStart(this string? str, string? startSubstring, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(startSubstring) || !str.StartsWith(startSubstring, comparison))
                return str ?? "";

            return str.Substring(startSubstring.Length);
        }

        public static string RemoveEnd(this string? str, string? endSubstring, StringComparison comparison = StringComparison.Ordinal)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(endSubstring) || !str.EndsWith(endSubstring, comparison))
                return str ?? "";

            return str.Substring(0, str.Length - endSubstring.Length);
        }

        public static string CutToLength(this string? str, int length)
        {
            if ((length <= 0) || string.IsNullOrEmpty(str))
                return "";

            return str.Length < length ? str : str.Substring(0, length);
        }
    }
}
