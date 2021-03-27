#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IFullAsyncConverter<out TInput, TOutput, in TNewInput, TNewOutput>
    {
        [ItemCanBeNull]
        Task<TNewOutput> ConvertAsync(IAsyncHandler<TInput, TOutput> handler, TNewInput input);
    }
}
