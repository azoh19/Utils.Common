#region Using

using System;
using System.Collections.Generic;
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
    public class Introspector<T> : IAccessor<T>, IFunctionIntrospector<T>, IExpressionIntrospector<T>
    {
        public Introspector()
        {
            Fill();
        }

        protected Dictionary<string, Func<T, object>>             Functions   { get; } = new Dictionary<string, Func<T, object>>();
        protected Dictionary<string, Expression<Func<T, object>>> Expressions { get; } = new Dictionary<string, Expression<Func<T, object>>>();

        #region IAccessor<T> Members

        public object Read(T @object, string name) => GetAccessFunc(name).Invoke(@object);

        public IEnumerable<(string name, object value)> ReadAll(T @object) => Functions.Select(kv => (kv.Key, GetAccessFunc(kv.Key).Invoke(@object)));

        #endregion

        #region IExpressionIntrospector<T> Members

        public Expression<Func<T, object>> GetAccessExpression(string name) => TryGetAccessExpression(name) ?? throw NotFoundError(name);

        public Expression<Func<T, object>> TryGetAccessExpression(string name) => Expressions.TryGetValue(name, out var func) ? func : null;

        #endregion

        #region IFunctionIntrospector<T> Members

        public Func<T, object> GetAccessFunc(string name) => TryGetAccessFunc(name) ?? throw NotFoundError(name);

        public Func<T, object> TryGetAccessFunc(string name) => Functions.TryGetValue(name, out var func) ? func : null;

        #endregion

        private void Fill()
        {
            foreach (var property in typeof(T).GetProperties().Where(p => p.CanRead))
            {
                var parameter = Expression.Parameter(typeof(T), "obj");
                var member    = Expression.Property(parameter, property);
                var convert   = Expression.Convert(member, typeof(object));
                var lmbdda    = Expression.Lambda<Func<T, object>>(convert, parameter);

                Expressions[property.Name] = lmbdda;
                Functions[property.Name]   = lmbdda.Compile();
            }
        }

        private Exception NotFoundError(string name) => new InvalidOperationException($"'{name}' is not a property of '{typeof(T).Name}'");
    }
}
