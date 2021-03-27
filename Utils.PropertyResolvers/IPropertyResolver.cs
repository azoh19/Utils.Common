#region Using

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using JetBrains.Annotations;

#endregion

namespace Utils.PropertyResolvers
{
    [PublicAPI]
    public interface IPropertyResolver<T>
    {
        object? Read(T @object, string name);

        IEnumerable<(string name, object? value)> ReadAll(T @object);

        Func<T, object?> GetFunc(string name);

        Func<T, object?>? TryGetFunc(string name);

        Expression<Func<T, object?>> GetExpression(string name);

        Expression<Func<T, object?>>? TryGetExpression(string name);

        (Expression, Type) GetExpressionAndType(string name);

        (Expression, Type)? TryGetExpressionAndType(string name);
    }
}
