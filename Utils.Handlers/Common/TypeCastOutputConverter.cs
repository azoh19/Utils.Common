﻿#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class TypeCastOutputConverter<TInput, TOutput, TNewOutput> : IOutputConverter<TInput, TOutput, TNewOutput>
        where TOutput : TNewOutput
    {
        #region IOutputConverter<TInput,TOutput,TNewOutput> Members

        public TNewOutput Convert(IHandler<TInput, TOutput> handler, TInput input) => handler.Run(input);

        #endregion
    }
}
