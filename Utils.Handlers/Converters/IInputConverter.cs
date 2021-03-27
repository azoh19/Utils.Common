#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IInputConverter<out TInput, TOutput, in TNewInput>
    {
        [CanBeNull]
        TOutput Convert(IHandler<TInput, TOutput> handler, TNewInput input);
    }
}
