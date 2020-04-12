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
        private IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput> _innerConverter;
        private IAsyncHandler<TInput, TOutput>                              _innerHandler;

        public FullConvertedAsyncHandler([NotNull] IFullAsyncConverter<TInput, TOutput, TNewInput, TNewOutput> innerConverter,
                                         [NotNull] IAsyncHandler<TInput, TOutput>                              innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        #region IAsyncHandler<TNewInput,TNewOutput> Members

        public Task<TNewOutput> HandleAsync(TNewInput input) => _innerConverter.ConvertAsync(_innerHandler, input);

        #endregion
    }
}
