#region Using

using System;
using System.Text;
using JetBrains.Annotations;

#endregion

namespace Utils.Strings
{
    [PublicAPI]
    public sealed class PlaceholderSubstitution
    {
        private Func<string, string> SubstititeKey { get; }
        private StringComparison     Comparison    { get; }

        private string Prefix  { get; }
        private string Postfix { get; }

        private int PrefixLength  => Prefix.Length;
        private int PostfixLength => Postfix.Length;

        public PlaceholderSubstitution([NotNull] Func<string, string> substititeKey,
                                       [NotNull] string               prefix     = "{",
                                       [NotNull] string               postfix    = "}",
                                       StringComparison               comparison = StringComparison.OrdinalIgnoreCase)
        {
            SubstititeKey = substititeKey ?? throw new ArgumentNullException(nameof(substititeKey));
            Prefix        = prefix        ?? throw new ArgumentNullException(nameof(prefix));
            Postfix       = postfix       ?? throw new ArgumentNullException(nameof(postfix));
            Comparison    = comparison;
        }

        [Pure]
        [CanBeNull]
        public string Process([CanBeNull] string source)
        {
            if (source == null)
                return null;

            var currentPosition = 0;
            var currentTagStart = source.IndexOf(Prefix, Comparison);

            if (currentTagStart < 0) // prefix not found, nothig to replace, return source as is
                return source;

            var sourceLength = source.Length;

            var sb = new StringBuilder();

            while (currentTagStart > 0)
            {
                var currentTagEnd = source.IndexOf(Postfix, currentTagStart, Comparison);

                if (currentTagEnd < 0) // prefix found, but postfix not found
                    return sb.Append(source, currentPosition, sourceLength - currentPosition).ToString();

                var keyStart = currentTagStart + PrefixLength;
                var key      = source.Substring(keyStart, currentTagEnd - keyStart).Trim();

                var value = SubstititeKey(key);

                if (value != null) // if substitution found, replace placeholder
                    sb.Append(source, currentPosition, currentTagStart - currentPosition).Append(value);
                else
                    sb.Append(source, currentPosition, currentTagEnd + PostfixLength - currentPosition);

                currentPosition = currentTagEnd + PostfixLength;

                if (currentPosition >= sourceLength) // if end of string, all done
                    return sb.ToString();

                currentTagStart = source.IndexOf(Prefix, currentPosition, Comparison);
            }

            if (currentPosition < source.Length) // append rest of string
                sb.Append(source, currentPosition, sourceLength - currentPosition);

            return sb.ToString();
        }
    }
}
