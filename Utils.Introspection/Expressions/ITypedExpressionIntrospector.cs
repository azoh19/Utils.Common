#region Using

using System;
using System.Linq.Expressions;
using JetBrains.Annotations;

#endregion

namespace Utils.Introspection.Expressions
{
    [PublicAPI]
    public interface ITypedExpressionIntrospector<T>
    {
        (Expression, Type) GetTypedAccessExpression([NotNull] string name);

        [CanBeNull]
        (Expression, Type)? TryGetTypedAccessExpression([NotNull] string name);
    }
}
