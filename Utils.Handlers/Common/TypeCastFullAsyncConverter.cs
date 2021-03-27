#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class TypeCastFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput> : IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>
        where TNewInput : TInput
        where TOutput : TNewOutput
    {
        public Task<TNewOutput> ConvertAsync(IAsyncHandler<TInput, TOutput> handler, TNewInput input)
            => handler.HandleAsync(input).ContinueWith(t => (TNewOutput)t.Result);
    }
}
