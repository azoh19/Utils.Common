#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.StructParsers
{
    [PublicAPI]
    public static class EnumParser
    {
        public static TEnum? Parse<TEnum>(string value) where TEnum : struct
            => Enum.TryParse(value, true, out TEnum result) ? result : (TEnum?)null;

        public static TEnum ParseOrDefault<TEnum>(string value, TEnum @default = default) where TEnum : struct
            => Parse<TEnum>(value) ?? @default;
    }

    [PublicAPI]
    public class EnumParser<TEnum> : IStructParser<TEnum> where TEnum : struct
    {
        TEnum? IStructParser<TEnum>.Parse(string value)
            => EnumParser.Parse<TEnum>(value);

        TEnum IStructParser<TEnum>.ParseOrDefault(string value, TEnum @default)
            => EnumParser.ParseOrDefault(value, @default);
    }
}
