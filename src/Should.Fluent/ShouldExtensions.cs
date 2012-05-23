using System;
using System.Collections.Generic;
using Should.Fluent.Model;

namespace Should.Fluent
{
    public static class ShouldExtensions
    {
        private static readonly IAssertProvider defaultAssertProvider;
        
        static ShouldExtensions()
        {
            defaultAssertProvider = new ShouldCoreAssertProvider();
            AssertProvider = defaultAssertProvider;
        }

        public static IAssertProvider AssertProvider { get; set; }

        public static void ResetAssertProvider()
        {
            AssertProvider = defaultAssertProvider;
        }

        public static Should<object, Be<object>> Should(this object o)
        {
            return new Should<object, Be<object>>(o, AssertProvider);
        }

        //TODO: This overload will only be chosen when both generic params are specified.  This is because constraints are not used in overload resolution.  Find some way to provide an overload that will strongly types the target when it is of a type not specifically covered by another overload.
        public static Should<T, Be<T>> Should<T, U>(this U o) where U : T
        {
            return new Should<T, Be<T>>(o, AssertProvider);
        }

        public static ShouldEnumerable<T> Should<T>(this IEnumerable<T> e)
        {
            return new ShouldEnumerable<T>(e, AssertProvider);
        }

        public static ShouldDictionary<TKey, TValue> Should<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> d)
        {
            return new ShouldDictionary<TKey, TValue>(d, AssertProvider);
        }

        public static Should<bool, BeBase<bool>> Should(this bool b)
        {
            return new Should<bool, BeBase<bool>>(b, AssertProvider);
        }

        public static Should<bool?, BeBase<bool?>> Should(this bool? b)
        {
            return new Should<bool?, BeBase<bool?>>(b, AssertProvider);
        }

        public static Should<DateTime, BeBase<DateTime>> Should(this DateTime d)
        {
            return new Should<DateTime, BeBase<DateTime>>(d, AssertProvider);
        }

        public static Should<DateTime?, BeBase<DateTime?>> Should(this DateTime? d)
        {
            return new Should<DateTime?, BeBase<DateTime?>>(d, AssertProvider);
        }

        public static Should<string, BeBase<string>> Should(this string s)
        {
            return new Should<string, BeBase<string>>(s, AssertProvider);
        }

        public static Should<double, BeBase<double>> Should(this double s)
        {
            return new Should<double, BeBase<double>>(s, AssertProvider);
        }

        public static Should<Guid, BeBase<Guid>> Should(this Guid g)
        {
            return new Should<Guid, BeBase<Guid>>(g, AssertProvider);
        }
    }
}