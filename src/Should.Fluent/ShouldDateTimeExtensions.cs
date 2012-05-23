using System;
using Should.Core;
using Should.Fluent.Model;

namespace Should.Fluent
{
    public static class ShouldDateTimeExtensions
    {
        public static DateTime Equal(this IShould<DateTime> should, DateTime expected, TimeSpan tolerance)
        {
            return should.Apply(
                (t, a) => a.AreEqual(expected, t, tolerance),
                (t, a) => a.AreNotEqual(expected, t, tolerance)
            );
        }

        public static DateTime Equal(this IShould<DateTime> should, DateTime expected, DatePrecision precision)
        {
            return should.Apply(
                (t, a) => a.AreEqual(expected, t, precision),
                (t, a) => a.AreNotEqual(expected, t, precision)
            );
        }
    }
}