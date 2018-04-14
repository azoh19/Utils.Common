#region Using

using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Infrastructure
{
    [PublicAPI]
    internal class InputConvertedAsyncHandler<TConverter, THandler, THandlerInput, TInput, TOutput> : IAsyncHandler<TInput, TOutput>
        where TConverter : class, IInputAsyncConverter<THandler, THandlerInput, TInput, TOutput>
        where THandler : class, IAsyncHandler<THandlerInput, TOutput>
    {
        private TConverter _innerConverter;
        private THandler   _innerHandler;

        public InputConvertedAsyncHandler([NotNull] TConverter innerConverter, [NotNull] THandler innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        #region IAsyncHandler<TInput,TOutput> Members

        public Task<TOutput> RunAsync(TInput input) => _innerConverter.ConvertAsync(_innerHandler, input);

        #endregion
    }
}
