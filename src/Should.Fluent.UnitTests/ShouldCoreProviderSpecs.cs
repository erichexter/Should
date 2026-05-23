using System;
using NUnit.Framework;
using Should.Core;
using Should.Core.Exceptions;

namespace Should.Fluent.UnitTests
{
    public class assert_provider_context
    {
        protected static ShouldCoreAssertProvider provider;
        protected static Exception exception;

        [SetUp]
        public virtual void SetUp()
        {
            provider = new ShouldCoreAssertProvider();
            exception = null;
        }

        protected static void Try(Action assertAction)
        {
            try
            {
                assertAction();
                exception = null;
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }
    }

    [TestFixture]
    public class when_assert_are_equal_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreEqual(1, 1));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_are_equal_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreEqual(1, 2));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(EqualException), exception);
        }
    }

    [TestFixture]
    public class when_assert_are_not_equal_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreNotEqual(1, 2));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_are_not_equal_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreNotEqual(1, 1));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(NotEqualException), exception);
        }
    }

    [TestFixture]
    public class when_assert_doubles_are_equal_within_tolerance_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreEqual(1.001, 1, 0.001));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_doubles_are_equal_within_tolerance_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreEqual(1.0011, 1, 0.001));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(EqualException), exception);
        }
    }

    [TestFixture]
    public class when_assert_doubles_are_not_equal_within_tolerance_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreNotEqual(1.0011, 1, 0.001));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_doubles_are_not_equal_within_tolerance_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreNotEqual(1.001, 1, 0.001));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(NotEqualException), exception);
        }
    }

    public class beahves_like_date_equality_spec : assert_provider_context
    {
        protected static DateTime expected = new DateTime(2000, 1, 1, 1, 35, 0);
        protected static DateTime actual = expected.AddMinutes(5);
    }

    [TestFixture]
    public class when_assert_dates_are_equal_within_tolerance_passes : beahves_like_date_equality_spec
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreEqual(expected, actual, TimeSpan.FromMinutes(5)));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_dates_are_equal_within_tolerance_fails : beahves_like_date_equality_spec
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreEqual(expected, actual, TimeSpan.FromMinutes(4)));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(EqualException), exception);
        }
    }

    [TestFixture]
    public class when_assert_dates_are_not_equal_within_tolerance_passes : beahves_like_date_equality_spec
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreNotEqual(expected, actual, TimeSpan.FromMinutes(4)));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_dates_are_not_equal_within_tolerance_fails : beahves_like_date_equality_spec
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreNotEqual(expected, actual, TimeSpan.FromMinutes(5)));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(NotEqualException), exception);
        }
    }

    [TestFixture]
    public class when_assert_dates_are_equal_with_precision_passes : beahves_like_date_equality_spec
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreEqual(expected, actual, DatePrecision.Hour));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_dates_are_equal_with_precision_fails : beahves_like_date_equality_spec
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreEqual(expected, actual, DatePrecision.Minute));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(EqualException), exception);
        }
    }

    [TestFixture]
    public class when_assert_dates_are_not_equal_with_precision_passes : beahves_like_date_equality_spec
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreNotEqual(expected, actual, DatePrecision.Minute));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_dates_are_not_equal_with_precision_fails : beahves_like_date_equality_spec
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreNotEqual(expected, actual, DatePrecision.Hour));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(NotEqualException), exception);
        }
    }

    [TestFixture]
    public class when_assert_not_null_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsNotNull(1));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_not_null_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsNotNull(null));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(NotNullException), exception);
        }
    }

    [TestFixture]
    public class when_assert_null_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsNull(null));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_null_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsNull(1));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(NullException), exception);
        }
    }

    [TestFixture]
    public class when_assert_true_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsTrue(true));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_true_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsTrue(false));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(TrueException), exception);
        }
    }

    [TestFixture]
    public class when_assert_false_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsFalse(false));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_false_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsFalse(true));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(FalseException), exception);
        }
    }

    [TestFixture]
    public class when_assert_fail : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.Fail("message"));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(AssertException), exception);
        }
    }

    [TestFixture]
    public class when_assert_contains_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.Contains(1, new[] { 1 }));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_contains_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.Contains(1, new[] { 2 }));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(ContainsException), exception);
        }
    }

    [TestFixture]
    public class when_assert_not_contains_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.NotContains(1, new[] { 2 }));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_not_contains_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.NotContains(1, new[] { 1 }));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(DoesNotContainException), exception);
        }
    }

    [TestFixture]
    public class when_assert_greater_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.GreaterThan(2, 1));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_greater_than_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.GreaterThan(1, 2));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(GreaterThanException), exception);
        }
    }

    [TestFixture]
    public class when_assert_greater_than_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.GreaterThan(2, 1));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_greater_than_with_comparer_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.GreaterThan("A", "a", StringComparer.Ordinal));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(GreaterThanException), exception);
        }
    }

    [TestFixture]
    public class when_assert_greater_than_with_comparer_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.GreaterThan("a", "A", StringComparer.Ordinal));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_greater_than_or_equal_to_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.GreaterThanOrEqual(1, 2));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(GreaterThanOrEqualException), exception);
        }
    }

    [TestFixture]
    public class when_assert_greater_than_or_equal_to_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.GreaterThanOrEqual(1, 1));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_greater_than_or_equal_to_with_comparer_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.GreaterThanOrEqual("A", "a", StringComparer.Ordinal));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(GreaterThanOrEqualException), exception);
        }
    }

    [TestFixture]
    public class when_assert_greater_than_or_equal_to_with_comparer_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.GreaterThanOrEqual("a", "A", StringComparer.OrdinalIgnoreCase));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_less_than_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.LessThan(2, 1));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(LessThanException), exception);
        }
    }

    [TestFixture]
    public class when_assert_less_than_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.LessThan(1, 2));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_less_than_with_comparer_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.LessThan("a", "A", StringComparer.Ordinal));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(LessThanException), exception);
        }
    }

    [TestFixture]
    public class when_assert_less_than_with_comparer_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.LessThan("A", "a", StringComparer.Ordinal));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_less_than_or_equal_to_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.LessThanOrEqual(2, 1));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(LessThanOrEqualException), exception);
        }
    }

    [TestFixture]
    public class when_assert_less_than_or_equal_to_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.LessThanOrEqual(1, 1));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_less_than_or_equal_to_with_comparer_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.LessThanOrEqual("a", "A", StringComparer.Ordinal));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(LessThanOrEqualException), exception);
        }
    }

    [TestFixture]
    public class when_assert_less_than_or_equal_to_with_comparer_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.LessThanOrEqual("a", "A", StringComparer.OrdinalIgnoreCase));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_not_greater_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.GreaterThan(1, 1));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(GreaterThanException), exception);
        }
    }

    [TestFixture]
    public class when_assert_greater_or_equal_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.GreaterThanOrEqual(1, 1));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_not_greater_or_equal_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.GreaterThanOrEqual(1, 2));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(GreaterThanOrEqualException), exception);
        }
    }

    public class sameness_test : assert_provider_context
    {
        protected static Foo foo1;
        protected static Foo foo2;
    }

    public class same_context : sameness_test
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            foo1 = new Foo("foo");
            foo2 = foo1;
        }
    }

    public class not_same_context : sameness_test
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            foo1 = new Foo("foo");
            foo2 = new Foo("foo");
        }
    }

    [TestFixture]
    public class when_assert_are_same_passes : same_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreSame(foo1, foo2));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_not_are_same_fails : not_same_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreSame(foo1, foo2));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(SameException), exception);
        }
    }

    [TestFixture]
    public class when_assert_are_not_same_passes : not_same_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreNotSame(foo1, foo2));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_not_are_not_same_fails : same_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.AreNotSame(foo1, foo2));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(NotSameException), exception);
        }
    }

    [TestFixture]
    public class when_assert_is_substring_of_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsSubstringOf("test", "te"));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_is_substring_of_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsSubstringOf("test", "xx"));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(ContainsException), exception);
        }
    }

    [TestFixture]
    public class when_assert_is_instance_of_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsInstanceOfType(new Foo("foo"), typeof(Foo)));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_is_instance_of_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsInstanceOfType(new Foo("foo"), typeof(string)));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(IsTypeException), exception);
        }
    }

    [TestFixture]
    public class when_assert_is_not_instance_of_passes : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsNotInstanceOfType(new Foo("foo"), typeof(string)));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_assert_is_not_instance_of_type_fails : assert_provider_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => provider.IsNotInstanceOfType(new Foo("foo"), typeof(Foo)));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(IsNotTypeException), exception);
        }
    }
}
