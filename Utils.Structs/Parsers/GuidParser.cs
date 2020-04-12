#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.Structs.Parsers
{
    [PublicAPI]
    public sealed class GuidParser : IStructParser<Guid>
    {
        public static Guid? Parse(string value) => Guid.TryParse(value, out var result) ? result : (Guid?)null;

        public static Guid ParseOrDefault(string value, Guid @default = default) => Parse(value) ?? @default;

        #region Implementation of IStructParser<Guid>

        Guid IStructParser<Guid>.ParseOrDefault(string value, Guid @default) => ParseOrDefault(value, @default);

        Guid? IStructParser<Guid>.Parse(string value) => Parse(value);

        #endregion
    }
}
