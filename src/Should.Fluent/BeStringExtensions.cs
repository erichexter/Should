using System;
using System.Collections.Generic;
using System.ComponentModel;
using Should.Fluent.Model;

namespace Should.Fluent
{
    public static class BeStringExtensions
    {
        public static string Null(this IBe<string> be)
        {
            return Check.IsNull(be.Should);
        }

        public static string Empty(this IBe<string> be)
        {
            return be.Should.Apply(
                (t, a) => a.AreEqual(string.Empty, t),
                (t, a) => a.AreNotEqual(string.Empty, t));
        }

        public static string NullOrEmpty(this IBe<string> be)
        {
            return be.Should.Apply(
                (t, a) => a.IsTrue(string.IsNullOrEmpty(t)),
                (t, a) => a.IsFalse(string.IsNullOrEmpty(t)));
        }

#if !NETFX_CORE && !NETSTANDARD1_6
        public static T ConvertableTo<T>(this IBe<string> be)
        {
            Func<string, IAssertProvider, object> positiveCase = (t, a) =>
            {
                try
                {
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    return (T)converter.ConvertFrom(t);
                }
                catch (Exception ex)
                {
                    a.Fail("Could not convert '{0}' to {1}.  {3}", t, typeof(T), ex.ToString());
                }
                return default(T);
            };
            Func<string, IAssertProvider, object> negativeCase = (t, a) =>
            {
                try
                {
                    TypeDescriptor.GetConverter(typeof(T));
                    a.Fail("Could convert '{0}' to {1}.  Expected not covertable.", t, typeof(T));
                }
                catch { }
                return default(T);
            };
            return (T)be.Should.Apply(positiveCase, negativeCase);
        }
#endif

        public static string GreaterThan(this IBe<string> be, string value)
        {
            return Check.GreaterThan(be.Should, value);
        }

        public static string GreaterThan(this IBe<string> be, string value, IComparer<string> comparer)
        {
            return Check.GreaterThan(be.Should, value, comparer);
        }

        public static string GreaterThanOrEqualTo(this IBe<string> be, string value)
        {
            return Check.GreaterThanOrEqual(be.Should, value);
        }

        public static string GreaterThanOrEqualTo(this IBe<string> be, string value, IComparer<string> comparer)
        {
            return Check.GreaterThanOrEqual(be.Should, value, comparer);
        }

        public static string LessThan(this IBe<string> be, string value)
        {
            return Check.LessThan(be.Should, value);
        }

        public static string LessThan(this IBe<string> be, string value, IComparer<string> comparer)
        {
            return Check.LessThan(be.Should, value, comparer);
        }

        public static string LessThanOrEqualTo(this IBe<string> be, string value)
        {
            return Check.LessThanOrEqual(be.Should, value);
        }

        public static string LessThanOrEqualTo(this IBe<string> be, string value, IComparer<string> comparer)
        {
            return Check.LessThanOrEqual(be.Should, value, comparer);
        }
    }
 }