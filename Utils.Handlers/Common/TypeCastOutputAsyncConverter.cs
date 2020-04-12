#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.Handlers.Converters;
using Utils.Tasks;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class TypeCastOutputAsyncConverter<TInput, TOutput, TNewOutput> : IOutputAsyncConverter<TInput, TOutput, TNewOutput>
        where TOutput : TNewOutput
    {
        #region IOutputAsyncConverter<TInput,TOutput,TNewOutput> Members

        public Task<TNewOutput> ConvertAsync(IAsyncHandler<TInput, TOutput> handler, TInput input) => handler.HandleAsync(input).Then(res => (TNewOutput)res);

        #endregion
    }
}
