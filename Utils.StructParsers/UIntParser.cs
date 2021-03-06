﻿#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.StructParsers
{
    [PublicAPI]
    public sealed class UIntParser : IStructParser<uint>
    {
        uint IStructParser<uint>.ParseOrDefault(string value, uint @default)
            => ParseOrDefault(value, @default);

        uint? IStructParser<uint>.Parse(string value)
            => Parse(value);

        public static uint? Parse(string value)
            => uint.TryParse(value, out var result) ? result : (uint?)null;

        public static uint ParseOrDefault(string value, uint @default = default)
            => Parse(value) ?? @default;
    }
}
