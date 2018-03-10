#region Using

using System;
using System.Linq.Expressions;
using JetBrains.Annotations;

#endregion

namespace Utils.Introspection.Expressions
{
    [PublicAPI]
    public interface IExpressionIntrospector<T>
    {
        [NotNull]
        Expression<Func<T, object>> GetAccessExpression([NotNull] string name);

        [CanBeNull]
        Expression<Func<T, object>> TryGetAccessExpression([NotNull] string name);
    }
}
