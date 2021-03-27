#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Converters
{
    [PublicAPI]
    public interface IInputAsyncConverter<out TInput, TOutput, in TNewInput>
    {
        [ItemCanBeNull]
        Task<TOutput> ConvertAsync(IAsyncHandler<TInput, TOutput> handler, TNewInput output);
    }
}
