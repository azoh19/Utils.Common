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
        private readonly IInputConverter<TInput, TOutput, TNewInput> _innerConverter;
        private readonly IHandler<TInput, TOutput> _innerHandler;

        public InputConvertedHandler(IInputConverter<TInput, TOutput, TNewInput> innerConverter,
                                     IHandler<TInput, TOutput> innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        public TOutput Handle(TNewInput input)
            => _innerConverter.Convert(_innerHandler, input);
    }
}
