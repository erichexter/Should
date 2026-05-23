using System;
using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class be_nullable_datetime_test_base : test_base<DateTime?>
    {
        protected static BeBase<DateTime?> be;

        protected static Should<DateTime?, BeBase<DateTime?>> get_should(DateTime? theTarget)
        {
            target = theTarget;
            return new Should<DateTime?, BeBase<DateTime?>>(target, mockAssertProvider.Object);
        }
    }

    public class should_be_nullable_datetime_context : be_nullable_datetime_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = get_should(DateTime.Now).Be;
        }
    }

    public class should_not_be_nullable_datetime : be_nullable_datetime_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = get_should(DateTime.Now).Not.Be;
        }
    }

    [TestFixture]
    public class when_calling_nullable_datatime_is_null : should_be_nullable_datetime_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Null();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_isnull()
        {
            Called(x => x.IsNull(target));
        }
    }

    [TestFixture]
    public class when_calling_nullable_datetime_is_not_null : should_not_be_nullable_datetime
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Null();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_isnotnull()
        {
            Called(x => x.IsNotNull(target));
        }
    }

    [TestFixture]
    public class when_calling_nullable_today : should_be_nullable_datetime_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Today();
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.AreEqual(DateTime.Today, target.Value.Date));
        }
    }

    [TestFixture]
    public class when_calling_nullable_not_today : should_not_be_nullable_datetime
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Today();
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_call_arenotequal()
        {
            Called(x => x.AreNotEqual(DateTime.Today, target.Value.Date));
        }
    }

    [TestFixture]
    public class when_calling_nullable_today_with_null : be_nullable_datetime_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = get_should(null).Be;
            result = be.Today();
        }

        [Test]
        public void should_fail()
        {
            Fail("Expected TODAY but was NULL.");
        }
    }
}
