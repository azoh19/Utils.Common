#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IFullConverter<out TInput, in TOutput, in TNewInput, out TNewOutput>
    {
        [CanBeNull]
        TNewOutput Convert(IHandler<TInput, TOutput> handler, TNewInput input);
    }
}
