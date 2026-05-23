using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class be_nullable_bool_test_base : test_base<bool?>
    {
        protected static BeBase<bool?> be;

        protected static Should<bool?, BeBase<bool?>> get_should(bool? theTarget)
        {
            target = theTarget;
            return new Should<bool?, BeBase<bool?>>(target, mockAssertProvider.Object);
        }
    }

    public class should_be_nullable_bool_context : be_nullable_bool_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = get_should(true).Be;
        }
    }

    public class should_not_be_nullable_bool_context : be_nullable_bool_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = get_should(true).Not.Be;
        }
    }

    [TestFixture]
    public class when_calling_nullable_bool_is_null : should_be_nullable_bool_context
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
    public class when_calling_nullable_bool_is_not_null : should_not_be_nullable_bool_context
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
    public class when_calling_nullable_true : should_be_nullable_bool_context
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
            Called(x => x.IsTrue(target.Value));
        }
    }

    [TestFixture]
    public class when_calling_nullable_not_true : should_not_be_nullable_bool_context
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
            Called(x => x.IsFalse(target.Value));
        }
    }

    [TestFixture]
    public class when_calling_nullable_false : should_be_nullable_bool_context
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
            Called(x => x.IsFalse(target.Value));
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }
    }

    [TestFixture]
    public class when_calling_nullable_not_false : should_not_be_nullable_bool_context
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
            Called(x => x.IsTrue(target.Value));
        }

        [Test]
        public void should_not_fail()
        {
            NotFail();
        }
    }

    [TestFixture]
    public class when_calling_nullable_true_with_null : should_be_nullable_bool_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = get_should(null).Be;
            result = be.True();
        }

        [Test]
        public void should_fail()
        {
            Fail("Expected TRUE but was NULL.");
        }
    }

    [TestFixture]
    public class when_calling_nullable_false_with_null : be_nullable_bool_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = get_should(null).Be;
            result = be.False();
        }

        [Test]
        public void should_fail()
        {
            Fail("Expected FALSE but was NULL.");
        }
    }
}
