#region Using

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;

#endregion

namespace Utils.PropertyResolvers
{
    [PublicAPI]
    public sealed class PropertyResolver<T> : IPropertyResolver<T>
    {
        static PropertyResolver()
        {
            foreach (var property in typeof(T).GetProperties().Where(p => p.CanRead))
            {
                var parameter       = Expression.Parameter(typeof(T), "obj");
                var member          = Expression.Property(parameter, property);
                var convert         = Expression.Convert(member, typeof(object));
                var convertedLambda = Expression.Lambda<Func<T, object?>>(convert, parameter);
                var typedLambda     = Expression.Lambda(member, parameter);

                Expr[property.Name]  = convertedLambda;
                Func[property.Name]  = convertedLambda.Compile();
                Typed[property.Name] = (typedLambda, property.PropertyType);
            }
        }

        private static Dictionary<string, Func<T, object?>> Func { get; }
            = new Dictionary<string, Func<T, object?>>();

        private static Dictionary<string, Expression<Func<T, object?>>> Expr { get; }
            = new Dictionary<string, Expression<Func<T, object?>>>();

        // ReSharper disable once StaticMemberInGenericType
        private static Dictionary<string, (Expression, Type)> Typed { get; }
            = new Dictionary<string, (Expression, Type)>();

        public object? Read(T @object, string name)
            => GetFunc(name).Invoke(@object);

        public IEnumerable<(string name, object? value)> ReadAll(T @object)
            => Func.Select(kv => (kv.Key, GetFunc(kv.Key).Invoke(@object)));

        public Expression<Func<T, object?>> GetExpression(string name)
            => TryGetExpression(name) ?? throw NotFoundError(name);

        public Expression<Func<T, object?>>? TryGetExpression(string name)
            => Expr.TryGetValue(name, out var func) ? func : null;

        public (Expression, Type) GetExpressionAndType(string name)
            => TryGetExpressionAndType(name) ?? throw NotFoundError(name);

        public (Expression, Type)? TryGetExpressionAndType(string name)
            => Typed.TryGetValue(name, out var func) ? func : ((Expression, Type)?)null;

        public Func<T, object?> GetFunc(string name)
            => TryGetFunc(name) ?? throw NotFoundError(name);

        public Func<T, object?>? TryGetFunc(string name)
            => Func.TryGetValue(name, out var func) ? func : null;

        private Exception NotFoundError(string name)
            => new InvalidOperationException($"'{name}' is not a property of '{typeof(T).Name}'");
    }
}
