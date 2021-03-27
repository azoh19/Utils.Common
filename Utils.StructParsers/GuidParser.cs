#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.StructParsers
{
    [PublicAPI]
    public sealed class GuidParser : IStructParser<Guid>
    {
        Guid IStructParser<Guid>.ParseOrDefault(string value, Guid @default)
            => ParseOrDefault(value, @default);

        Guid? IStructParser<Guid>.Parse(string value)
            => Parse(value);

        public static Guid? Parse(string value)
            => Guid.TryParse(value, out var result) ? result : (Guid?)null;

        public static Guid ParseOrDefault(string value, Guid @default = default)
            => Parse(value) ?? @default;
    }
}
