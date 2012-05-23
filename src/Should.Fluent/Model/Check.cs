using System;
using System.Collections.Generic;

namespace Should.Fluent.Model
{
    internal class Check
    {
        public static TTarget IsNull<TTarget>(IShould<TTarget> should)
        {
            return should.Apply(
                (t, a) => a.IsNull(t),
                (t, a) => a.IsNotNull(t));
        }

        public static TTarget GreaterThan<TTarget>(IShould<TTarget> should, TTarget value)
        {
            return should.Apply(
                (t, a) => a.GreaterThan(t, value),
                (t, a) => a.LessThanOrEqual(t, value));
        }

        public static TTarget GreaterThan<TTarget>(IShould<TTarget> should, TTarget value, IComparer<TTarget> comparer)
        {
            return should.Apply(
                (t, a) => a.GreaterThan(t, value, comparer),
                (t, a) => a.LessThanOrEqual(t, value,comparer));
        }

        public static TTarget GreaterThanOrEqual<TTarget>(IShould<TTarget> should, TTarget value)
        {
            return should.Apply(
                (t, a) => a.GreaterThanOrEqual(t, value),
                (t, a) => a.LessThan(t, value));
        }

        public static TTarget GreaterThanOrEqual<TTarget>(IShould<TTarget> should, TTarget value, IComparer<TTarget> comparer)
        {
            return should.Apply(
                (t, a) => a.GreaterThanOrEqual(t, value, comparer),
                (t, a) => a.LessThan(t, value, comparer));
        }

        public static TTarget LessThan<TTarget>(IShould<TTarget> should, TTarget value)
        {
            return should.Apply(
                (t, a) => a.LessThan(t, value),
                (t, a) => a.GreaterThanOrEqual(t, value));
        }

        public static TTarget LessThan<TTarget>(IShould<TTarget> should, TTarget value, IComparer<TTarget> comparer)
        {
            return should.Apply(
                (t, a) => a.LessThan(t, value, comparer),
                (t, a) => a.GreaterThanOrEqual(t, value, comparer));
        }

        public static TTarget LessThanOrEqual<TTarget>(IShould<TTarget> should, TTarget value)
        {
            return should.Apply(
                (t, a) => a.LessThanOrEqual(t, value),
                (t, a) => a.GreaterThan(t, value));
        }

        public static TTarget LessThanOrEqual<TTarget>(IShould<TTarget> should, TTarget value, IComparer<TTarget> comparer)
        {
            return should.Apply(
                (t, a) => a.LessThanOrEqual(t, value, comparer),
                (t, a) => a.GreaterThan(t, value, comparer));
        }
    }
}