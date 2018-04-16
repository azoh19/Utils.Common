﻿#region Using

using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class InputConvertedAsyncHandler<TInput, TOutput, TNewInput> : IAsyncHandler<TNewInput, TOutput>
    {
        private IInputAsyncConverter<TInput, TOutput, TNewInput> _innerConverter;
        private IAsyncHandler<TInput, TOutput>                   _innerHandler;

        public InputConvertedAsyncHandler([NotNull] IInputAsyncConverter<TInput, TOutput, TNewInput> innerConverter,
                                          [NotNull] IAsyncHandler<TInput, TOutput>                   innerHandler)
        {
            _innerConverter = innerConverter ?? throw new ArgumentNullException(nameof(innerConverter));
            _innerHandler   = innerHandler   ?? throw new ArgumentNullException(nameof(innerHandler));
        }

        #region IAsyncHandler<TNewInput,TOutput> Members

        public Task<TOutput> RunAsync(TNewInput input) => _innerConverter.ConvertAsync(_innerHandler, input);

        #endregion
    }
}