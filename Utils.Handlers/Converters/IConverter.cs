#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IConverter<out TInput, in TOutput, in TNewInput, out TNewOutput>
    {
        [CanBeNull]
        TNewOutput Convert([NotNull] IHandler<TInput, TOutput> handler, [NotNull] TNewInput output);
    }
}
