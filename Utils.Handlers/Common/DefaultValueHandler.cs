#region Using

using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class DefaultValueHandler<TInput, TOutput> : IHandler<TInput, TOutput>
    {
        private readonly TOutput _value;

        public DefaultValueHandler(TOutput value = default(TOutput))
        {
            _value = value;
        }

        #region IHandler<TInput,TOutput> Members

        public TOutput Run(TInput input) => _value;

        #endregion
    }
}
