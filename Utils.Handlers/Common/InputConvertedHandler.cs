#region Using

using System;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class InputConvertedHandler<TInput, TOutput, TNewInput> : IHandler<TNewInput, TOutput>
    {
        private IInputConverter<TInput, TOutput, TNewInput> _innerConverter;
        private IHandler<TInput, TOutput>                   _innerHandler;

        public InputConvertedHandler([NotNull] IInputConverter<TInput, TOutput, TNewInput> innerConverter,
                                     [NotNull] IHandler<TInput, TOutput>                   innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        #region IHandler<TNewInput,TOutput> Members

        public TOutput Handle(TNewInput input) => _innerConverter.Convert(_innerHandler, input);

        #endregion
    }
}
