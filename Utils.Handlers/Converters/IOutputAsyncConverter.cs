#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IOutputAsyncConverter<TInput, TOutput, TNewOutput>
    {
        [ItemCanBeNull]
        Task<TNewOutput> ConvertAsync(IAsyncHandler<TInput, TOutput> handler, TInput output);
    }
}
