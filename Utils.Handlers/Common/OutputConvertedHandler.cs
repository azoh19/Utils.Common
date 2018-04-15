#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class OutputConvertedHandler<TInput, TOutput, TNewOutput> : IHandler<TInput, TNewOutput>
    {
        private IOutputConverter<TInput, TOutput, TNewOutput> _innerConverter;
        private IHandler<TInput, TOutput>                     _innerHandler;

        public OutputConvertedHandler([NotNull] IOutputConverter<TInput, TOutput, TNewOutput> innerConverter,
                                      [NotNull] IHandler<TInput, TOutput>                     innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        #region IHandler<TInput,TNewOutput> Members

        public TNewOutput Run(TInput input) => _innerConverter.Convert(_innerHandler, input);

        #endregion
    }
}
