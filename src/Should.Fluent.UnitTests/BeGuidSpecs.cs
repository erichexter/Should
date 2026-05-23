using System;
using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class be_guid_test_base : test_base<Guid>
    {
        protected static BeBase<Guid> be;
    }

    public class should_be_guid_context : be_guid_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new Should<Guid, BeBase<Guid>>(target, mockAssertProvider.Object).Be;
        }
    }

    public class should_not_be_guid_context : be_guid_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new Should<Guid, BeBase<Guid>>(target, mockAssertProvider.Object).Not.Be;
        }
    }

    [TestFixture]
    public class when_calling_guid_empty : should_be_guid_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Empty();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_areequal()
        {
            Called(x => x.AreEqual(Guid.Empty, target));
        }
    }

    [TestFixture]
    public class when_calling_guid_not_empty : should_not_be_guid_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Empty();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_arenotequal()
        {
            Called(x => x.AreNotEqual(Guid.Empty, target));
        }
    }
}
