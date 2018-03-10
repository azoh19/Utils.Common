#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Structs.Parsers
{
    [PublicAPI]
    public sealed class ByteParser : IStructParser<byte>
    {
        public static byte? Parse(string value) => byte.TryParse(value, out var result) ? result : (byte?)null;

        public static byte ParseOrDefault(string value, byte @default = default(byte)) => Parse(value) ?? @default;

        #region Implementation of IStructParser<byte>

        byte IStructParser<byte>.ParseOrDefault(string value, byte @default) => ParseOrDefault(value, @default);

        byte? IStructParser<byte>.Parse(string value) => Parse(value);

        #endregion
    }
}
