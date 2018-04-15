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
        private IOutputAsyncConverter<TInput, TOutput, TNewOutput> _innerConverter;
        private IAsyncHandler<TInput, TOutput>                     _innerHandler;

        public OutputConvertedAsyncHandler([NotNull] IOutputAsyncConverter<TInput, TOutput, TNewOutput> innerConverter,
                                           [NotNull] IAsyncHandler<TInput, TOutput>                     innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        #region IAsyncHandler<TInput,TNewOutput> Members

        public Task<TNewOutput> RunAsync(TInput input) => _innerConverter.ConvertAsync(_innerHandler, input);

        #endregion
    }
}
