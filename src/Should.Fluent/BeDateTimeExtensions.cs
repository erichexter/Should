using System;
using System.Collections.Generic;
using Should.Fluent.Model;

namespace Should.Fluent
{
    public static class BeDateTimeExtensions
    {
        public static DateTime Today(this IBe<DateTime> be)
        {
            return be.Should.Apply(
                (t, a) => a.AreEqual(DateTime.Today, t.Date),
                (t, a) => a.AreNotEqual(DateTime.Today, t.Date));
        }

        public static DateTime GreaterThan(this IBe<DateTime> be, DateTime value)
        {
            return Check.GreaterThan(be.Should, value);
        }

        public static DateTime GreaterThan(this IBe<DateTime> be, DateTime value, IComparer<DateTime> comparer)
        {
            return Check.GreaterThan(be.Should, value, comparer);
        }

        public static DateTime GreaterThanOrEqualTo(this IBe<DateTime> be, DateTime value)
        {
            return Check.GreaterThanOrEqual(be.Should, value);
        }

        public static DateTime GreaterThanOrEqualTo(this IBe<DateTime> be, DateTime value, IComparer<DateTime> comparer)
        {
            return Check.GreaterThanOrEqual(be.Should, value, comparer);
        }

        public static DateTime LessThan(this IBe<DateTime> be, DateTime value)
        {
            return Check.LessThan(be.Should, value);
        }

        public static DateTime LessThan(this IBe<DateTime> be, DateTime value, IComparer<DateTime> comparer)
        {
            return Check.LessThan(be.Should, value, comparer);
        }

        public static DateTime LessThanOrEqualTo(this IBe<DateTime> be, DateTime value)
        {
            return Check.LessThanOrEqual(be.Should, value);
        }

        public static DateTime LessThanOrEqualTo(this IBe<DateTime> be, DateTime value, IComparer<DateTime> comparer)
        {
            return Check.LessThanOrEqual(be.Should, value, comparer);
        }
    }
}