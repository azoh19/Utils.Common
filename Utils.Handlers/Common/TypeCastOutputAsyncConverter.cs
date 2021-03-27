#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class TypeCastOutputAsyncConverter<TInput, TOutput, TNewOutput> : IOutputAsyncConverter<TInput, TOutput, TNewOutput>
        where TOutput : TNewOutput
    {
        public Task<TNewOutput> ConvertAsync(IAsyncHandler<TInput, TOutput> handler, TInput input)
            => handler.HandleAsync(input).ContinueWith(t => (TNewOutput)t.Result);
    }
}
