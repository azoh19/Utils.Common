#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.Handlers.Converters;
using Utils.Tasks;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class TypeCastFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput> : IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>
        where TNewInput : TInput
        where TOutput : TNewOutput
    {
        #region IAsyncConverter<TInput,TOutput,TNewInput,TNewOutput> Members

        public Task<TNewOutput> ConvertAsync(IAsyncHandler<TInput, TOutput> handler, TNewInput input) => handler.RunAsync(input).Then(res => (TNewOutput)res);

        #endregion
    }
}
