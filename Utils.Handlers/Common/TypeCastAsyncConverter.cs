#region Using

using System.Threading.Tasks;
using Utils.Handlers.Converters;
using Utils.Tasks;

#endregion

namespace Utils.Handlers.Common
{
    public sealed class TypeCastAsyncConverter<TInput, TOutput, TNewInput, TNewOutput> : IAsyncConverter<TInput, TOutput, TNewInput, TNewOutput>
        where TNewInput : TInput
        where TOutput : TNewOutput
    {
        #region IAsyncConverter<TInput,TOutput,TNewInput,TNewOutput> Members

        public Task<TNewOutput> ConvertAsync(IAsyncHandler<TInput, TOutput> handler, TNewInput input) => handler.RunAsync(input).Then(res => (TNewOutput)res);

        #endregion
    }

    public sealed class TypeCastInputAsyncConverter<TInput, TOutput, TNewInput> : IInputAsyncConverter<TInput, TOutput, TNewInput>
        where TNewInput : TInput
    {
        #region IInputAsyncConverter<TInput,TOutput,TNewInput> Members

        public Task<TOutput> ConvertAsync(IAsyncHandler<TInput, TOutput> handler, TNewInput input) => handler.RunAsync(input);

        #endregion
    }

    public sealed class TypeCastOutputAsyncConverter<TInput, TOutput, TNewOutput> : IOutputAsyncConverter<TInput, TOutput, TNewOutput>
        where TOutput : TNewOutput
    {
        #region IOutputAsyncConverter<TInput,TOutput,TNewOutput> Members

        public Task<TNewOutput> ConvertAsync(IAsyncHandler<TInput, TOutput> handler, TInput input) => handler.RunAsync(input).Then(res => (TNewOutput)res);

        #endregion
    }
}
