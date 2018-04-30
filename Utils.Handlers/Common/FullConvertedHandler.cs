#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class FullConvertedHandler<TInput, TOutput, TNewInput, TNewOutput> : IHandler<TNewInput, TNewOutput>
    {
        private IFullConverter<TInput, TOutput, TNewInput, TNewOutput> _innerFullConverter;
        private IHandler<TInput, TOutput>                              _innerHandler;

        public FullConvertedHandler([NotNull] IFullConverter<TInput, TOutput, TNewInput, TNewOutput> innerFullConverter,
                                    [NotNull] IHandler<TInput, TOutput>                              innerHandler)
        {
            _innerFullConverter = innerFullConverter ?? throw new ArgumentNullException(nameof(innerFullConverter));
            _innerHandler       = innerHandler       ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        #region IHandler<TNewInput,TNewOutput> Members

        public TNewOutput Run(TNewInput input) => _innerFullConverter.Convert(_innerHandler, input);

        #endregion
    }
}
