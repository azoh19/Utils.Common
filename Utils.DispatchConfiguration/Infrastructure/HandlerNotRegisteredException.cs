#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.DispatchConfiguration.Infrastructure
{
    [PublicAPI]
    public sealed class HandlerNotRegisteredException<TInput, TOutput> : Exception
    {
        public HandlerNotRegisteredException()
            : base($"Handler for types {typeof(TInput).Name}/{typeof(TOutput)} is not registered")
        { }
    }
}
