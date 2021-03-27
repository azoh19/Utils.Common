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
        private readonly IOutputConverter<TInput, TOutput, TNewOutput> _innerConverter;
        private readonly IHandler<TInput, TOutput> _innerHandler;

        public OutputConvertedHandler(IOutputConverter<TInput, TOutput, TNewOutput> innerConverter,
                                      IHandler<TInput, TOutput> innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        public TNewOutput Handle(TInput input)
            => _innerConverter.Convert(_innerHandler, input);
    }
}
