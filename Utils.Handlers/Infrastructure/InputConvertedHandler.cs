#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Infrastructure
{
    [PublicAPI]
    internal class InputConvertedHandler<TConverter, THandler, THandlerInput, TInput, TOutput> : IHandler<TInput, TOutput>
        where TConverter : class, IInputConverter<THandler, THandlerInput, TInput, TOutput>
        where THandler : class, IHandler<THandlerInput, TOutput>
    {
        private TConverter _innerConverter;
        private THandler   _innerHandler;

        public InputConvertedHandler([NotNull] TConverter innerConverter, [NotNull] THandler innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        #region IHandler<TInput,TOutput> Members

        public TOutput Run(TInput input) => _innerConverter.Convert(_innerHandler, input);

        #endregion
    }
}
