#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class DefaultValueHandler<TInput, TOutput> : IHandler<TInput, TOutput>
    {
        private readonly TOutput _value;

        public DefaultValueHandler(TOutput value)
        {
            _value = value;
        }

        public TOutput Handle(TInput input)
            => _value;
    }
}
