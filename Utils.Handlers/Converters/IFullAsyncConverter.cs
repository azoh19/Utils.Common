#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IFullAsyncConverter<out TInput, TOutput, in TNewInput, TNewOutput>
    {
        [NotNull]
        [ItemCanBeNull]
        Task<TNewOutput> ConvertAsync([NotNull] IAsyncHandler<TInput, TOutput> handler, [NotNull] TNewInput output);
    }
}
