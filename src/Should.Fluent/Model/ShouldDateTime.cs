using System;
using Should.Core;

namespace Should.Fluent.Model
{
    public class ShouldDateTime : ShouldBase<ShouldDateTime, DateTime, BeDateTime>
    {
        public ShouldDateTime(DateTime target, IAssertProvider assertProvider) : base(target, assertProvider) { }

        public DateTime Equal(DateTime expected, TimeSpan tolerance)
        {
            if (Negate)
            {
                assertProvider.AreNotEqual(expected, Target, tolerance);
            }
            else
            {
                assertProvider.AreEqual(expected, Target, tolerance);
            }
            return Target;
        }

        public DateTime Equal(DateTime expected, DatePrecision precision)
        {
            if (Negate)
            {
                assertProvider.AreNotEqual(expected, Target, precision);
            }
            else
            {
                assertProvider.AreEqual(expected, Target, precision);
            }
            return Target;
        }
    }
}