using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class be_bool_test_base : test_base<bool>
    {
        protected static BeBase<bool> be;
    }

    public class should_be_bool_context : be_bool_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new Should<bool, BeBase<bool>>(target, mockAssertProvider.Object).Be;
        }
    }

    public class should_not_be_bool_context : be_bool_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new Should<bool, BeBase<bool>>(target, mockAssertProvider.Object).Not.Be;
        }
    }

    [TestFixture]
    public class when_calling_true : should_be_bool_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.True();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_istrue()
        {
            Called(x => x.IsTrue(target));
        }
    }

    [TestFixture]
    public class when_calling_not_true : should_not_be_bool_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.True();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_isfalse()
        {
            Called(x => x.IsFalse(target));
        }
    }

    [TestFixture]
    public class when_calling_false : should_be_bool_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.False();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_isfalse()
        {
            Called(x => x.IsFalse(target));
        }
    }

    [TestFixture]
    public class when_calling_not_false : should_not_be_bool_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.False();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_istrue()
        {
            Called(x => x.IsTrue(target));
        }
    }
}
