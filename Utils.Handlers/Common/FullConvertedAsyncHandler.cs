#region Using

using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class FullConvertedAsyncHandler<TInput, TOutput, TNewInput, TNewOutput> : IAsyncHandler<TNewInput, TNewOutput>
    {
        private readonly IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput> _innerConverter;
        private readonly IAsyncHandler<TInput, TOutput> _innerHandler;

        public FullConvertedAsyncHandler(IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput> innerConverter,
                                         IAsyncHandler<TInput, TOutput> innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        public Task<TNewOutput> HandleAsync(TNewInput input)
            => _innerConverter.ConvertAsync(_innerHandler, input);
    }
}
