using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class be_string_test_base : test_base<string>
    {
        protected static IBe<string> be;
    }

    public class should_be_string_context : be_string_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new Should<string, BeBase<string>>(target, mockAssertProvider.Object).Be;
        }
    }

    public class should_not_be_string_context : be_string_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new Should<string, BeBase<string>>(target, mockAssertProvider.Object).Not.Be;
        }
    }

    [TestFixture]
    public class when_calling_string_null : should_be_string_context
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
    public class when_calling_string_not_null : should_not_be_string_context
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
    public class when_calling_string_empty : should_be_string_context
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
            Called(x => x.AreEqual(string.Empty, target));
        }
    }

    [TestFixture]
    public class when_calling_string_not_empty : should_not_be_string_context
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
            Called(x => x.AreNotEqual(string.Empty, target));
        }
    }

    [TestFixture]
    public class when_calling_string_nullorempty : should_be_string_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.NullOrEmpty();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_istrue()
        {
            Called(x => x.IsTrue(string.IsNullOrEmpty(target)));
        }
    }

    [TestFixture]
    public class when_calling_string_not_nullorempty : should_not_be_string_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.NullOrEmpty();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_arenotequal()
        {
            Called(x => x.IsFalse(string.IsNullOrEmpty(target)));
        }
    }
}
