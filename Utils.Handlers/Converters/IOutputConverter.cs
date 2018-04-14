#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IOutputConverter<in THandler, THandlerOutput, in TInput, out TOutput>
        where THandler : IHandler<TInput, THandlerOutput>
    {
        [CanBeNull]
        TOutput Convert([NotNull] THandler handler, [NotNull] TInput output);
    }
}
