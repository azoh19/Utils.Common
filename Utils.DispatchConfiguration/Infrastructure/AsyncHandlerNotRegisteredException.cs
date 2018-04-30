#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    [PublicAPI]
    public sealed class AsyncHandlerNotRegisteredException<TInput, TOutput> : Exception
    {
        public AsyncHandlerNotRegisteredException()
            : base($"Async handler for types {typeof(TInput).Name}/{typeof(TOutput)} is not registered")
        { }
    }
}
