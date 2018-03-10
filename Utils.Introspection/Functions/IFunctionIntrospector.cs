#region Using

using System;
using JetBrains.Annotations;

#endregion

namespace Utils.Introspection.Functions
{
    [PublicAPI]
    public interface IFunctionIntrospector<in T>
    {
        [NotNull]
        Func<T, object> GetAccessFunc([NotNull] string name);

        [CanBeNull]
        Func<T, object> TryGetAccessFunc([NotNull] string name);
    }
}
