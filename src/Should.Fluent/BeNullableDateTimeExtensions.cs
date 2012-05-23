using System;
using System.Collections.Generic;
using Should.Fluent.Model;

namespace Should.Fluent
{
    public static class BeNullableDateTimeExtensions
    {
        public static DateTime? Null(this IBe<DateTime?> be)
        {
            return Check.IsNull(be.Should);
        }

        public static DateTime? Today(this IBe<DateTime?> be)
        {
            Action<DateTime?, IAssertProvider> positiveCase = (t, a) =>
            {
                if (t.HasValue == false)
                {
                    a.Fail("Expected TODAY but was NULL.");
                }
                else
                {
                    a.AreEqual(DateTime.Today, t.Value.Date);                    
                }
            };
            Action<DateTime?, IAssertProvider> negativeCase = (t, a) =>
            {
                if (t.HasValue)
                {
                    a.AreNotEqual(DateTime.Today, t.Value.Date);
                }
            };
            return be.Should.Apply(positiveCase, negativeCase);
        }

        public static DateTime? GreaterThan(this IBe<DateTime?> be, DateTime? value)
        {
            return Check.GreaterThan(be.Should, value);
        }

        public static DateTime? GreaterThan(this IBe<DateTime?> be, DateTime? value, IComparer<DateTime?> comparer)
        {
            return Check.GreaterThan(be.Should, value, comparer);
        }

        public static DateTime? GreaterThanOrEqualTo(this IBe<DateTime?> be, DateTime? value)
        {
            return Check.GreaterThanOrEqual(be.Should, value);
        }

        public static DateTime? GreaterThanOrEqualTo(this IBe<DateTime?> be, DateTime? value, IComparer<DateTime?> comparer)
        {
            return Check.GreaterThanOrEqual(be.Should, value, comparer);
        }

        public static DateTime? LessThan(this IBe<DateTime?> be, DateTime? value)
        {
            return Check.LessThan(be.Should, value);
        }

        public static DateTime? LessThan(this IBe<DateTime?> be, DateTime? value, IComparer<DateTime?> comparer)
        {
            return Check.LessThan(be.Should, value, comparer);
        }

        public static DateTime? LessThanOrEqualTo(this IBe<DateTime?> be, DateTime? value)
        {
            return Check.LessThanOrEqual(be.Should, value);
        }

        public static DateTime? LessThanOrEqualTo(this IBe<DateTime?> be, DateTime? value, IComparer<DateTime?> comparer)
        {
            return Check.LessThanOrEqual(be.Should, value, comparer);
        }
    }
}