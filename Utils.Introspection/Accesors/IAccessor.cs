#region Using

using System.Collections.Generic;
using JetBrains.Annotations;

#endregion

namespace Utils.Introspection.Accesors
{
    [PublicAPI]
    public interface IAccessor<in T>
    {
        object Read(T @object, string name);

        IEnumerable<(string name, object value)> ReadAll(T @object);
    }
}
