#region Using

using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class OutputConvertedAsyncHandler<TInput, TOutput, TNewOutput> : IAsyncHandler<TInput, TNewOutput>
    {
        private readonly IOutputAsyncConverter<TInput, TOutput, TNewOutput> _innerConverter;
        private readonly IAsyncHandler<TInput, TOutput> _innerHandler;

        public OutputConvertedAsyncHandler(IOutputAsyncConverter<TInput, TOutput, TNewOutput> innerConverter,
                                           IAsyncHandler<TInput, TOutput> innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        public Task<TNewOutput> HandleAsync(TInput input)
            => _innerConverter.ConvertAsync(_innerHandler, input);
    }
}
