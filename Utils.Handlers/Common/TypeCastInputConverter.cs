#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class TypeCastInputConverter<TInput, TOutput, TNewInput> : IInputConverter<TInput, TOutput, TNewInput>
        where TNewInput : TInput
    {
        #region IInputConverter<TInput,TOutput,TNewInput> Members

        public TOutput Convert(IHandler<TInput, TOutput> handler, TNewInput input) => handler.Run(input);

        #endregion
    }
}
