#region Using

using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class InputConvertedAsyncHandler<TInput, TOutput, TNewInput> : IAsyncHandler<TNewInput, TOutput>
    {
        private readonly IInputAsyncConverter<TInput, TOutput, TNewInput> _innerConverter;
        private readonly IAsyncHandler<TInput, TOutput> _innerHandler;

        public InputConvertedAsyncHandler(IInputAsyncConverter<TInput, TOutput, TNewInput> innerConverter,
                                          IAsyncHandler<TInput, TOutput> innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        public Task<TOutput> HandleAsync(TNewInput input)
            => _innerConverter.ConvertAsync(_innerHandler, input);
    }
}
