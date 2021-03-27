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
        private readonly IFullConverter<TInput, TOutput, TNewInput, TNewOutput> _innerFullConverter;
        private readonly IHandler<TInput, TOutput> _innerHandler;

        public FullConvertedHandler(IFullConverter<TInput, TOutput, TNewInput, TNewOutput> innerFullConverter,
                                    IHandler<TInput, TOutput> innerHandler)
        {
            _innerFullConverter = innerFullConverter ?? throw new ArgumentNullException(nameof(innerFullConverter));
            _innerHandler       = innerHandler       ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        public TNewOutput Handle(TNewInput input)
            => _innerFullConverter.Convert(_innerHandler, input);
    }
}
