#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Structs.Parsers
{
    [PublicAPI]
    public interface IStructParser<T> where T : struct
    {
        [CanBeNull]
        T? Parse([CanBeNull] string value);

        T ParseOrDefault([CanBeNull] string value, T @default);
    }
}
