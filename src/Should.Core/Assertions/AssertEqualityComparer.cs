using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Should.Core.Assertions
{
    internal class AssertEqualityComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T x, T y)
        {
#if NETFX_CORE || NETSTANDARD1_6
            var type = typeof(T).GetTypeInfo();
#else
            var type = typeof(T);
#endif

            // Null?
#if NETSTANDARD1_6
            if (!type.IsValueType || (type.IsGenericType && type.GetGenericTypeDefinition().GetTypeInfo().IsAssignableFrom(typeof(Nullable<>))))
#else
            if (!type.IsValueType || (type.IsGenericType && type.GetGenericTypeDefinition().IsAssignableFrom(typeof(Nullable<>))))
#endif
            {
                if (Object.Equals(x, default(T)))
                    return Object.Equals(y, default(T));

                if (Object.Equals(y, default(T)))
                    return false;
            }

            //x implements IEquitable<T> and is assignable from y?
#if NETSTANDARD1_6
            var xIsAssignableFromY = x.GetType().GetTypeInfo().IsAssignableFrom(y.GetType());
#else
            var xIsAssignableFromY = x.GetType().IsAssignableFrom(y.GetType());
#endif
            if (xIsAssignableFromY && x is IEquatable<T>)
                return ((IEquatable<T>)x).Equals(y);

            //y implements IEquitable<T> and is assignable from x?
#if NETSTANDARD1_6
            var yIsAssignableFromX = y.GetType().GetTypeInfo().IsAssignableFrom(x.GetType());
#else
            var yIsAssignableFromX = y.GetType().IsAssignableFrom(x.GetType());
#endif
            if (yIsAssignableFromX && y is IEquatable<T>)
                return ((IEquatable<T>)y).Equals(x);

            // Enumerable?
            IEnumerable enumerableX = x as IEnumerable;
            IEnumerable enumerableY = y as IEnumerable;

            if (enumerableX != null && enumerableY != null)
            {
                return new EnumerableEqualityComparer().Equals(enumerableX, enumerableY);
            }

            // Last case, rely on Object.Equals
            return Object.Equals(x, y);
        }

        public int GetHashCode(T obj)
        {
            throw new NotImplementedException();
        }
    }
}