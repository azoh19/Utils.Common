#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IOutputConverter<TInput, in TOutput, out TNewOutput>
    {
        [CanBeNull]
        TNewOutput Convert([NotNull] IHandler<TInput, TOutput> handler, [NotNull] TInput output);
    }
}
