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

        public DefaultValueAsyncHandler(TOutput value)
        {
            _value = value;
        }

        public Task<TOutput> HandleAsync(TInput input)
            => Task.FromResult(_value);
    }
}
