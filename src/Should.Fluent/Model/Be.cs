using System;
using System.Collections.Generic;

namespace Should.Fluent.Model
{
    public class Be<T> : BeBase<T>
    {
        public Be(IShould<T> should) : base(should) { }

        public T Null()
        {
            return Check.IsNull(should);
        }

        public T SameAs(T expected)
        {
            return should.Apply(
                (t, a) => a.AreSame(expected, t),
                (t, a) => a.AreNotSame(expected, t));
        }

        public T OfType<TExpectedType>()
        {
            return OfType(typeof(TExpectedType));
        }

        public T OfType(Type expectedType)
        {
            return should.Apply(
                (t, a) => a.IsInstanceOfType(t, expectedType),
                (t, a) => a.IsNotInstanceOfType(t, expectedType));
        }

        public T AssignableFrom<TExpected>()
        {
            return AssignableFrom(typeof (TExpected));
        }

        public T AssignableFrom(Type expectedType)
        {
            return should.Apply(
                (t, a) => a.AssignableFrom(t, expectedType),
                (t, a) => a.NotAssignableFrom(t, expectedType));
        }

        public T InRange(T low, T high)
        {
            return should.Apply(
                (t, a) => a.InRange(t, low, high),
                (t, a) => a.NotInRange(t, low, high));
        }

        public T GreaterThan(T value)
        {
            return Check.GreaterThan(should, value);
        }

        public T GreaterThan(T value, IComparer<T> comparer)
        {
            return Check.GreaterThan(should, value, comparer);
        }

        public T GreaterThanOrEqualTo(T value)
        {
            return Check.GreaterThanOrEqual(should, value);
        }

        public T GreaterThanOrEqualTo(T value, IComparer<T> comparer)
        {
            return Check.GreaterThanOrEqual(should, value, comparer);
        }

        public T LessThan(T value)
        {
            return Check.LessThan(should, value);
        }

        public T LessThan(T value, IComparer<T> comparer)
        {
            return Check.LessThan(should, value, comparer);
        }

        public T LessThanOrEqualTo(T value)
        {
            return Check.LessThanOrEqual(should, value);
        }

        public T LessThanOrEqualTo(T value, IComparer<T> comparer)
        {
            return Check.LessThanOrEqual(should, value, comparer);
        }
    }
}