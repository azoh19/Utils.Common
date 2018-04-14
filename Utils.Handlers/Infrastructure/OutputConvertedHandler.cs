#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Infrastructure
{
    [PublicAPI]
    public class OutputConvertedHandler<TConverter, THandler, THandlerOutput, TInput, TOutput> : IHandler<TInput, TOutput>
        where TConverter : class, IOutputConverter<THandler, THandlerOutput, TInput, TOutput>
        where THandler : class, IHandler<TInput, THandlerOutput>
    {
        private TConverter _innerConverter;
        private THandler   _innerHandler;

        public OutputConvertedHandler([NotNull] TConverter innerConverter, [NotNull] THandler innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        #region IHandler<TInput,TOutput> Members

        public TOutput Run(TInput input) => _innerConverter.Convert(_innerHandler, input);

        #endregion
    }
}
