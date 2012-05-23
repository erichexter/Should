using System;
using System.Collections.Generic;
using Should.Fluent.Model;

namespace Should.Fluent
{
    public static class BeGuidExtensions
    {
        public static Guid Empty(this IBe<Guid> be)
        {
            return be.Should.Apply(
                (t, a) => a.AreEqual(Guid.Empty, t),
                (t, a) => a.AreNotEqual(Guid.Empty, t));
        }

        public static Guid GreaterThan(this IBe<Guid> be, Guid value)
        {
            return Check.GreaterThan(be.Should, value);
        }

        public static Guid GreaterThan(this IBe<Guid> be, Guid value, IComparer<Guid> comparer)
        {
            return Check.GreaterThan(be.Should, value, comparer);
        }

        public static Guid GreaterThanOrEqualTo(this IBe<Guid> be, Guid value)
        {
            return Check.GreaterThanOrEqual(be.Should, value);
        }

        public static Guid GreaterThanOrEqualTo(this IBe<Guid> be, Guid value, IComparer<Guid> comparer)
        {
            return Check.GreaterThanOrEqual(be.Should, value, comparer);
        }

        public static Guid LessThan(this IBe<Guid> be, Guid value)
        {
            return Check.LessThan(be.Should, value);
        }

        public static Guid LessThan(this IBe<Guid> be, Guid value, IComparer<Guid> comparer)
        {
            return Check.LessThan(be.Should, value, comparer);
        }

        public static Guid LessThanOrEqualTo(this IBe<Guid> be, Guid value)
        {
            return Check.LessThanOrEqual(be.Should, value);
        }

        public static Guid LessThanOrEqualTo(this IBe<Guid> be, Guid value, IComparer<Guid> comparer)
        {
            return Check.LessThanOrEqual(be.Should, value, comparer);
        }
    }
}