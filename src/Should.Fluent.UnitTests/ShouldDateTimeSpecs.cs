using System;
using NUnit.Framework;
using Should.Core;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class should_datetime_mocked_context : test_base<DateTime>
    {
        protected static Should<DateTime, BeBase<DateTime>> should;
        protected static DateTime expected = new DateTime(1);
        protected static TimeSpan tolerance = TimeSpan.FromTicks(1);
        protected static DatePrecision precision = DatePrecision.Hour;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = new DateTime(1);
            should = new Should<DateTime, BeBase<DateTime>>(target, mockAssertProvider.Object);
        }
    }

    [TestFixture]
    public class when_calling_datetime_equal_with_tolerance : should_datetime_mocked_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.Equal(expected, tolerance);
        }

        [Test]
        public void result_should_equal_target()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_areequal()
        {
            Called(x => x.AreEqual(expected, target, tolerance));
        }
    }

    [TestFixture]
    public class when_calling_datetime_not_equal_with_tolerance : should_datetime_mocked_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.Not.Equal(expected, tolerance);
        }

        [Test]
        public void result_should_equal_target()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_areequal()
        {
            Called(x => x.AreNotEqual(expected, target, tolerance));
        }
    }

    [TestFixture]
    public class when_calling_datetime_equal_with_precision : should_datetime_mocked_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.Equal(expected, precision);
        }

        [Test]
        public void result_should_equal_target()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_areequal()
        {
            Called(x => x.AreEqual(expected, target, precision));
        }
    }

    [TestFixture]
    public class when_calling_datetime_with_not_equal_with_precision : should_datetime_mocked_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = should.Not.Equal(expected, precision);
        }

        [Test]
        public void result_should_equal_target()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_areequal()
        {
            Called(x => x.AreNotEqual(expected, target, precision));
        }
    }
}
