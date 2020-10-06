#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.Strings
{
    [PublicAPI]
    public static class StringExtensions
    {
        public static string RemoveStart([NotNull] this string str, [NotNull] string startSubstring)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(startSubstring) || !str.StartsWith(startSubstring, StringComparison.Ordinal))
                return str;

            return str.Substring(startSubstring.Length);
        }

        public static string RemoveEnd([NotNull] this string str, [NotNull] string endSubstring)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(endSubstring) || !str.EndsWith(endSubstring, StringComparison.Ordinal))
                return str;

            return str.Substring(0, str.Length - endSubstring.Length);
        }

        public static string CutToLength([NotNull] this string str, int length)
        {
            if ((length <= 0) || string.IsNullOrEmpty(str))
                return "";

            return str.Length < length ? str : str.Substring(0, length);
        }
    }
}
