//using System;
//using Machine.Specifications;
//using NUnit.Framework;
//using Should.Core;
//using Should.Core.Exceptions;
//
//namespace Should.Fluent.UnitTests
//{
//    public class assert_provider_context
//    {
//        protected static ShouldCoreAssertProvider provider;
//        protected static Exception exception;
//
//        private Establish context = () => provider = new ShouldCoreAssertProvider();
//
//        protected static void Try(Action assertAction)
//        {
//            exception = Catch.Exception(assertAction);
//        }
//    }
//
//    public class when_assert_are_equal_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.AreEqual(1, 1));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_are_equal_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.AreEqual(1, 2));
//        private Behaves_like<Throws<EqualException>> yes;
//    }
//
//    public class when_assert_are_not_equal_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.AreNotEqual(1, 2));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_are_not_equal_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.AreNotEqual(1, 1));
//        private Behaves_like<Throws<NotEqualException>> yes;
//    }
//
//    public class when_assert_doubles_are_equal_within_tolerance_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.AreEqual(1.001, 1, 0.001));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_doubles_are_equal_within_tolerance_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.AreEqual(1.0011, 1, 0.001));
//        private Behaves_like<Throws<EqualException>> yes;
//    }
//
//    public class when_assert_doubles_are_not_equal_within_tolerance_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.AreNotEqual(1.0011, 1, 0.001));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_doubles_are_not_equal_within_tolerance_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.AreNotEqual(1.001, 1, 0.001));
//        private Behaves_like<Throws<NotEqualException>> yes;
//    }
//
//    public class beahves_like_date_equality_spec : assert_provider_context
//    {
//        protected static DateTime expected = new DateTime(2000, 1, 1, 1, 35, 0);
//        protected static DateTime actual = expected.AddMinutes(5);
//    }
//
//    public class when_assert_dates_are_equal_within_tolerance_passes : beahves_like_date_equality_spec
//    {
//        private Because of = () => Try(() => provider.AreEqual(expected, actual, TimeSpan.FromMinutes(5)));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_dates_are_equal_within_tolerance_fails : beahves_like_date_equality_spec
//    {
//        private Because of = () => Try(() => provider.AreEqual(expected, actual, TimeSpan.FromMinutes(4)));
//        private Behaves_like<Throws<EqualException>> yes;
//    }
//
//    public class when_assert_dates_are_not_equal_within_tolerance_passes : beahves_like_date_equality_spec
//    {
//        private Because of = () => Try(() => provider.AreNotEqual(expected, actual, TimeSpan.FromMinutes(4)));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_dates_are_not_equal_within_tolerance_fails : beahves_like_date_equality_spec
//    {
//        private Because of = () => Try(() => provider.AreNotEqual(expected, actual, TimeSpan.FromMinutes(5)));
//        private Behaves_like<Throws<NotEqualException>> yes;
//    }
//
//    public class when_assert_dates_are_equal_with_precision_passes : beahves_like_date_equality_spec
//    {
//        private Because of = () => Try(() => provider.AreEqual(expected, actual, DatePrecision.Hour));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_dates_are_equal_with_precision_fails : beahves_like_date_equality_spec
//    {
//        private Because of = () => Try(() => provider.AreEqual(expected, actual, DatePrecision.Minute));
//        private Behaves_like<Throws<EqualException>> yes;
//    }
//
//    public class when_assert_dates_are_not_equal_with_precision_passes : beahves_like_date_equality_spec
//    {
//        private Because of = () => Try(() => provider.AreNotEqual(expected, actual, DatePrecision.Minute));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_dates_are_not_equal_with_precision_fails : beahves_like_date_equality_spec
//    {
//        private Because of = () => Try(() => provider.AreNotEqual(expected, actual, DatePrecision.Hour));
//        private Behaves_like<Throws<NotEqualException>> yes;
//    }
//
//    public class when_assert_not_null_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsNotNull(1));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_not_null_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsNotNull(null));
//        private Behaves_like<Throws<NotNullException>> yes;
//    }
//
//    public class when_assert_null_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsNull(null));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_null_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsNull(1));
//        private Behaves_like<Throws<NullException>> yes;
//    }
//
//    public class when_assert_true_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsTrue(true));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_true_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsTrue(false));
//        private Behaves_like<Throws<TrueException>> yes;
//    }
//
//    public class when_assert_false_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsFalse(false));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_false_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsFalse(true));
//        private Behaves_like<Throws<FalseException>> yes;
//    }
//
//    public class when_assert_fail : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.Fail("message"));
//        private Behaves_like<Throws<AssertException>> yes;
//    }
//
//    public class when_assert_contains_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.Contains(1, new[] {1}));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_contains_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.Contains(1, new[] {2}));
//        private Behaves_like<Throws<ContainsException>> yes;
//    }
//
//    public class when_assert_not_contains_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.NotContains(1, new[] {2}));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_not_contains_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.NotContains(1, new[] {1}));
//        private Behaves_like<Throws<DoesNotContainException>> yes;
//    }
//
//    public class when_assert_greater_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.GreaterThan(2, 1));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_greater_than_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.GreaterThan(1, 2));
//        private Behaves_like<Throws<GreaterThanException>> yes;
//    }
//
//    public class when_assert_greater_than_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.GreaterThan(2, 1));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_greater_than_with_comparer_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.GreaterThan("A", "a", StringComparer.Ordinal));
//        private Behaves_like<Throws<GreaterThanException>> yes;
//    }
//
//    public class when_assert_greater_than_with_comparer_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.GreaterThan("a", "A", StringComparer.Ordinal));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_greater_than_or_equal_to_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.GreaterThanOrEqual(1, 2));
//        private Behaves_like<Throws<GreaterThanOrEqualException>> yes;
//    }
//
//    public class when_assert_greater_than_or_equal_to_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.GreaterThanOrEqual(1, 1));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_greater_than_or_equal_to_with_comparer_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.GreaterThanOrEqual("A", "a", StringComparer.Ordinal));
//        private Behaves_like<Throws<GreaterThanOrEqualException>> yes;
//    }
//
//    public class when_assert_greater_than_or_equal_to_with_comparer_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.GreaterThanOrEqual("a", "A", StringComparer.OrdinalIgnoreCase));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_less_than_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.LessThan(2, 1));
//        private Behaves_like<Throws<LessThanException>> yes;
//    }
//
//    public class when_assert_less_than_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.LessThan(1, 2));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_less_than_with_comparer_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.LessThan("a", "A", StringComparer.Ordinal));
//        private Behaves_like<Throws<LessThanException>> yes;
//    }
//
//    public class when_assert_less_than_with_comparer_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.LessThan("A", "a", StringComparer.Ordinal));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_less_than_or_equal_to_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.LessThanOrEqual(2, 1));
//        private Behaves_like<Throws<LessThanOrEqualException>> yes;
//    }
//
//    public class when_assert_less_than_or_equal_to_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.LessThanOrEqual(1, 1));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_less_than_or_equal_to_with_comparer_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.LessThanOrEqual("a", "A", StringComparer.Ordinal));
//        private Behaves_like<Throws<LessThanOrEqualException>> yes;
//    }
//
//    public class when_assert_less_than_or_equal_to_with_comparer_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.LessThanOrEqual("a", "A", StringComparer.OrdinalIgnoreCase));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_not_greater_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.GreaterThan(1, 1));
//        private Behaves_like<Throws<GreaterThanException>> yes;
//    }
//
//    public class when_assert_greater_or_equal_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.GreaterThanOrEqual(1, 1));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_not_greater_or_equal_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.GreaterThanOrEqual(1, 2));
//        private Behaves_like<Throws<GreaterThanOrEqualException>> yes;
//    }
//
//    public class sameness_test : assert_provider_context
//    {
//        protected static Foo foo1;
//        protected static Foo foo2;
//    }
//
//    public class same_context : sameness_test
//    {
//        private Establish context = () =>
//        {
//            foo1 = new Foo("foo");
//            foo2 = foo1;
//        };
//    }
//
//    public class not_same_context : sameness_test
//    {
//        private Establish context = () =>
//        {
//            foo1 = new Foo("foo");
//            foo2 = new Foo("foo");
//        };
//    }
//
//    public class when_assert_are_same_passes : same_context
//    {
//        private Because of = () => Try(() => provider.AreSame(foo1, foo2));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_not_are_same_fails : not_same_context
//    {
//        private Because of = () => Try(() => provider.AreSame(foo1, foo2));
//        private Behaves_like<Throws<SameException>> yes;
//    }
//
//    public class when_assert_are_not_same_passes : not_same_context
//    {
//        private Because of = () => Try(() => provider.AreNotSame(foo1, foo2));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_not_are_not_same_fails : same_context
//    {
//        private Because of = () => Try(() => provider.AreNotSame(foo1, foo2));
//        private Behaves_like<Throws<NotSameException>> yes;
//    }
//
//    public class when_assert_is_substring_of_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsSubstringOf("test", "te"));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_is_substring_of_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsSubstringOf("test", "xx"));
//        private Behaves_like<Throws<ContainsException>> yes;
//    }
//
//    public class when_assert_is_instance_of_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsInstanceOfType(new Foo("foo"), typeof (Foo)));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_is_instance_of_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsInstanceOfType(new Foo("foo"), typeof (string)));
//        private Behaves_like<Throws<IsTypeException>> yes;
//    }
//
//    public class when_assert_is_not_instance_of_passes : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsNotInstanceOfType(new Foo("foo"), typeof (string)));
//        private Behaves_like<DoesNotThrow> yes;
//    }
//
//    public class when_assert_is_not_instance_of_type_fails : assert_provider_context
//    {
//        private Because of = () => Try(() => provider.IsNotInstanceOfType(new Foo("foo"), typeof (Foo)));
//        private Behaves_like<Throws<IsNotTypeException>> yes;
//    }
//}