#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Infrastructure
{
    [PublicAPI]
    internal class ConvertedHandler<TConverter, THandler, THandlerInput, THandlerOutput, TInput, TOutput> : IHandler<TInput, TOutput>
        where TConverter : class, IConverter<THandler, THandlerInput, THandlerOutput, TInput, TOutput>
        where THandler : class, IHandler<THandlerInput, THandlerOutput>
    {
        private TConverter _innerConverter;
        private THandler   _innerHandler;

        public ConvertedHandler([NotNull] TConverter innerConverter, [NotNull] THandler innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        #region IHandler<TInput,TOutput> Members

        public TOutput Run(TInput input) => _innerConverter.Convert(_innerHandler, input);

        #endregion
    }
}
