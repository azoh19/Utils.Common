#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IConverter<in THandler, THandlerInput, THandlerOutput, in TInput, out TOutput>
        where THandler : IHandler<THandlerInput, THandlerOutput>
    {
        [CanBeNull]
        TOutput Convert([NotNull] THandler handler, [NotNull] TInput output);
    }
}
