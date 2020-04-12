#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class DefaultValueHandler<TInput, TOutput> : IHandler<TInput, TOutput>
    {
        private readonly TOutput _value;

        public DefaultValueHandler(TOutput value = default)
        {
            _value = value;
        }

        #region IHandler<TInput,TOutput> Members

        public TOutput Handle(TInput input) => _value;

        #endregion
    }
}
