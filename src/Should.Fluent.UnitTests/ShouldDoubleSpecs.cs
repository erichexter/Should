using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class should_double_context : test_base<double>
    {
        protected static Should<double, BeBase<double>> should;

        [SetUp]
        public override void SetUp()
        {
            base.SetUp();
            target = 5;
            should = new Should<double, BeBase<double>>(target, mockAssertProvider.Object);
        }
    }

    [TestFixture]
    public class when_calling_double_equal : should_double_context
    {
        const double expected = 5.001;
        const double tolerance = 0.001;

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
    public class when_calling_double_not_equal : should_double_context
    {
        const double expected = 5.001;
        const double tolerance = 0.001;

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
}
