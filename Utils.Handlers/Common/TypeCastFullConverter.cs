#region Using

using JetBrains.Annotations;
using Utils.Handlers.Converters;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class TypeCastFullConverter<TInput, TOutput, TNewInput, TNewOutput> : IFullConverter<TInput, TOutput, TNewInput, TNewOutput>
        where TNewInput : TInput
        where TOutput : TNewOutput
    {
        public TNewOutput Convert(IHandler<TInput, TOutput> handler, TNewInput input)
            => handler.Handle(input);
    }
}
