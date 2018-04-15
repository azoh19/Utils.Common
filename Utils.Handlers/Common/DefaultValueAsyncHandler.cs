#region Using

using System.Threading.Tasks;
using JetBrains.Annotations;

#endregion

namespace Utils.Handlers.Common
{
    [PublicAPI]
    public sealed class DefaultValueAsyncHandler<TInput, TOutput> : IAsyncHandler<TInput, TOutput>
    {
        private readonly TOutput _value;

        public DefaultValueAsyncHandler(TOutput value = default(TOutput))
        {
            _value = value;
        }

        #region IAsyncHandler<TInput,TOutput> Members

        public Task<TOutput> RunAsync(TInput input) => Task.FromResult(_value);

        #endregion
    }
}
