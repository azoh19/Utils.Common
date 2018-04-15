#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class ConvertedHandler<TInput, TOutput, TNewInput, TNewOutput> : IHandler<TNewInput, TNewOutput>
    {
        private IConverter<TInput, TOutput, TNewInput, TNewOutput> _innerConverter;
        private IHandler<TInput, TOutput>                          _innerHandler;

        public ConvertedHandler([NotNull] IConverter<TInput, TOutput, TNewInput, TNewOutput> innerConverter,
                                [NotNull] IHandler<TInput, TOutput>                          innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        #region IHandler<TNewInput,TNewOutput> Members

        public TNewOutput Run(TNewInput input) => _innerConverter.Convert(_innerHandler, input);

        #endregion
    }
}
