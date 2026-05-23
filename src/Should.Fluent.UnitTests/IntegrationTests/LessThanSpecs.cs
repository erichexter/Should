using System;
using NUnit.Framework;
using Should.Core.Exceptions;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests.IntegrationTests
{
    [TestFixture]
    public class when_should_be_less_than_fails : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => 2.Should().Be.LessThan(1));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(LessThanException), exception);
        }
    }

    [TestFixture]
    public class when_should_be_less_than_passes : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => 1.Should().Be.LessThan(2));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_should_be_less_than_with_comparer_fails : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => "a".Should().Be.LessThan("A", StringComparer.Ordinal));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(LessThanException), exception);
        }
    }

    [TestFixture]
    public class when_should_be_less_than_with_comparer_passes : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => "A".Should().Be.LessThan("b", StringComparer.OrdinalIgnoreCase));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_should_be_less_than_or_equal_to_fails : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => 2.Should().Be.LessThanOrEqualTo(1));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(LessThanOrEqualException), exception);
        }
    }

    [TestFixture]
    public class when_should_be_less_than_or_equal_to_passes : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => 1.Should().Be.LessThanOrEqualTo(1));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_should_be_less_than_or_equal_to_with_comparer_fails : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => "a".Should().Be.LessThanOrEqualTo("A", StringComparer.Ordinal));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(LessThanOrEqualException), exception);
        }
    }

    [TestFixture]
    public class when_should_be_less_than_or_equal_to_with_comparer_passes : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => "A".Should().Be.LessThanOrEqualTo("a", StringComparer.OrdinalIgnoreCase));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }
}
