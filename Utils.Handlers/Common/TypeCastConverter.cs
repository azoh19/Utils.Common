#region Using

using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    public sealed class TypeCastConverter<TInput, TOutput, TNewInput, TNewOutput> : IConverter<TInput, TOutput, TNewInput, TNewOutput>
        where TNewInput : TInput
        where TOutput : TNewOutput
    {
        #region IConverter<TInput,TOutput,TNewInput,TNewOutput> Members

        public TNewOutput Convert(IHandler<TInput, TOutput> handler, TNewInput input) => handler.Run(input);

        #endregion
    }
}
