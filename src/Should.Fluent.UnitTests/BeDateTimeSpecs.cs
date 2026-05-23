using System;
using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class be_datetime_test_base : test_base<DateTime>
    {
        protected static BeBase<DateTime> be;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = DateTime.Now;
        }
    }

    public class should_be_datetime_context : be_datetime_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new Should<DateTime, BeBase<DateTime>>(target, mockAssertProvider.Object).Be;
        }
    }

    public class should_not_be_datetime_context : be_datetime_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new Should<DateTime, BeBase<DateTime>>(target, mockAssertProvider.Object).Not.Be;
        }
    }

    [TestFixture]
    public class when_calling_today : should_be_datetime_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Today();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_call_areequal()
        {
            Called(x => x.AreEqual(DateTime.Today, target.Date));
        }
    }

    [TestFixture]
    public class when_calling_not_today : should_not_be_datetime_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Today();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_call_arenotequal()
        {
            Called(x => x.AreNotEqual(DateTime.Today, target.Date));
        }
    }
}
