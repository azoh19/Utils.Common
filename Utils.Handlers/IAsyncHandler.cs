#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Handlers
{
    [PublicAPI]
    public interface IAsyncHandler<in TInput, TOutput>
    {
        Task<TOutput> HandleAsync(TInput input);
    }
}
