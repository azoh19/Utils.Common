#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class TypeCastInputAsyncConverter<TInput, TOutput, TNewInput> : IInputAsyncConverter<TInput, TOutput, TNewInput>
        where TNewInput : TInput
    {
        public Task<TOutput> ConvertAsync(IAsyncHandler<TInput, TOutput> handler, TNewInput input)
            => handler.HandleAsync(input);
    }
}
