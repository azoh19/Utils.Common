#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.AbstractDI
{
    [PublicAPI]
    public interface IResolver
    {
        TDependency Resolve<TDependency>() where TDependency : class;

        object Resolve(Type type);

        TDependency? TryResolve<TDependency>() where TDependency : class;

        object? TryResolve(Type type);
    }
}
