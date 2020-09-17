#region Using

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using JetBrains.Annotations;
using Utils.Introspection.Accesors;
using Utils.Introspection.Expressions;
using Utils.Introspection.Functions;

#endregion

namespace Utils.Introspection
{
    [PublicAPI]
    public sealed class Introspector<T> : IAccessor<T>,
                                          IFunctionIntrospector<T>,
                                          IExpressionIntrospector<T>,
                                          ITypedExpressionIntrospector<T>
    {
        static Introspector()
        {
            foreach (var property in typeof(T).GetProperties().Where(p => p.CanRead))
            {
                var parameter       = Expression.Parameter(typeof(T), "obj");
                var member          = Expression.Property(parameter, property);
                var convert         = Expression.Convert(member, typeof(object));
                var convertedLambda = Expression.Lambda<Func<T, object>>(convert, parameter);
                var typedLambda     = Expression.Lambda(member, parameter);

                Expr[property.Name]  = convertedLambda;
                Func[property.Name]  = convertedLambda.Compile();
                Typed[property.Name] = (typedLambda, property.PropertyType);
            }
        }

        private static Dictionary<string, Func<T, object>> Func { get; }
            = new Dictionary<string, Func<T, object>>();

        private static Dictionary<string, Expression<Func<T, object>>> Expr { get; }
            = new Dictionary<string, Expression<Func<T, object>>>();

        [SuppressMessage("ReSharper", "StaticMemberInGenericType", Justification = "Intentional, the property is used to store data per type")]
        private static Dictionary<string, (Expression, Type)> Typed { get; }
            = new Dictionary<string, (Expression, Type)>();

        #region IAccessor<T> Members

        public object Read(T @object, string name) => GetAccessFunc(name).Invoke(@object);

        public IEnumerable<(string name, object value)> ReadAll(T @object) => Func.Select(kv => (kv.Key, GetAccessFunc(kv.Key).Invoke(@object)));

        #endregion

        #region IExpressionIntrospector<T> Members

        public Expression<Func<T, object>> GetAccessExpression(string name) => TryGetAccessExpression(name) ?? throw NotFoundError(name);

        public Expression<Func<T, object>> TryGetAccessExpression(string name) => Expr.TryGetValue(name, out var func) ? func : null;

        #endregion

        #region ITypedExpressionIntrospector<T> Members

        public (Expression, Type) GetTypedAccessExpression(string name) => TryGetTypedAccessExpression(name) ?? throw NotFoundError(name);

        public (Expression, Type)? TryGetTypedAccessExpression(string name) => Typed.TryGetValue(name, out var func) ? func : ((Expression, Type)?)null;

        #endregion

        #region IFunctionIntrospector<T> Members

        public Func<T, object> GetAccessFunc(string name) => TryGetAccessFunc(name) ?? throw NotFoundError(name);

        public Func<T, object> TryGetAccessFunc(string name) => Func.TryGetValue(name, out var func) ? func : null;

        #endregion

        private Exception NotFoundError(string name) => new InvalidOperationException($"'{name}' is not a property of '{typeof(T).Name}'");
    }
}
