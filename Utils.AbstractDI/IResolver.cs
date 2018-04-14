#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.AbstractDI
{
    [PublicAPI]
    public interface IResolver
    {
        [NotNull]
        TDependency Resolve<TDependency>();

        [NotNull]
        object Resolve([NotNull] Type type);

        [CanBeNull]
        TDependency TryResolve<TDependency>();

        [CanBeNull]
        object TryResolve([NotNull] Type type);
    }
}
