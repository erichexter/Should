using System;
using NUnit.Framework;
using Should.Core.Exceptions;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests.IntegrationTests
{
    [TestFixture]
    public class when_should_be_greater_than_fails : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => 1.Should().Be.GreaterThan(2));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(GreaterThanException), exception);
        }
    }

    [TestFixture]
    public class when_should_be_greater_than_passes : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => 2.Should().Be.GreaterThan(1));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_should_be_greater_than_with_comparer_fails : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => "A".Should().Be.GreaterThan("a", StringComparer.Ordinal));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(GreaterThanException), exception);
        }
    }

    [TestFixture]
    public class when_should_be_greater_than_with_comparer_passes : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => "b".Should().Be.GreaterThan("A", StringComparer.OrdinalIgnoreCase));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_should_be_greater_than_or_equal_to_fails : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => 1.Should().Be.GreaterThanOrEqualTo(2));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(GreaterThanOrEqualException), exception);
        }
    }

    [TestFixture]
    public class when_should_be_greater_than_or_equal_to_passes : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => 1.Should().Be.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }

    [TestFixture]
    public class when_should_be_greater_than_or_equal_to_with_comparer_fails : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => "A".Should().Be.GreaterThanOrEqualTo("a", StringComparer.Ordinal));
        }

        [Test]
        public void should_throw_assert_exception_of_expected_type()
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf(typeof(GreaterThanOrEqualException), exception);
        }
    }

    [TestFixture]
    public class when_should_be_greater_than_or_equal_to_with_comparer_passes : integration_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            Try(() => "a".Should().Be.GreaterThanOrEqualTo("A", StringComparer.OrdinalIgnoreCase));
        }

        [Test]
        public void should_not_throw()
        {
            Assert.IsNull(exception);
        }
    }
}
