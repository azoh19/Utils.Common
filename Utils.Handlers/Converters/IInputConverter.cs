#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IInputConverter<in THandler, THandlerInput, in TInput, out TOutput>
        where THandler : IHandler<THandlerInput, TOutput>
    {
        [CanBeNull]
        TOutput Convert([NotNull] THandler handler, [NotNull] TInput output);
    }
}
