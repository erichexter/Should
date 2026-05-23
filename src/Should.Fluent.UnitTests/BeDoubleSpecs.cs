using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class be_double_test_base : test_base<double>
    {
        protected static BeBase<double> be;
    }

    public class should_be_double_context : be_double_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new Should<double, BeBase<double>>(target, mockAssertProvider.Object).Be;
        }
    }

    public class should_not_be_double_context : be_double_test_base
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            be = new Should<double, BeBase<double>>(target, mockAssertProvider.Object).Not.Be;
        }
    }

    [TestFixture]
    public class when_calling_double_positive : should_be_double_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Positive();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_greater_than()
        {
            Called(x => x.GreaterThan<double>(target, 0));
        }
    }

    [TestFixture]
    public class when_calling_double_not_positive : should_not_be_double_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Positive();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_lessorequal()
        {
            Called(x => x.LessThanOrEqual<double>(target, 0));
        }
    }

    [TestFixture]
    public class when_calling_double_negative : should_be_double_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Negative();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_greater()
        {
            Called(x => x.LessThan<double>(target, 0));
        }
    }

    [TestFixture]
    public class when_calling_double_not_negative : should_not_be_double_context
    {
        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            result = be.Negative();
        }

        [Test]
        public void should_return_self()
        {
            Assert.AreEqual(target, result);
        }

        [Test]
        public void should_assert_lessorequal()
        {
            Called(x => x.GreaterThanOrEqual<double>(target, 0));
        }
    }
}
