#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IInputAsyncConverter<out TInput, TOutput, in TNewInput>
    {
        [NotNull]
        [ItemCanBeNull]
        Task<TOutput> ConvertAsync([NotNull] IAsyncHandler<TInput, TOutput> handler, [NotNull] TNewInput output);
    }
}
