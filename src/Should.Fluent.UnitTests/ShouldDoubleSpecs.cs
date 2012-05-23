using Machine.Specifications;
using NUnit.Framework;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class should_double_context : test_base<double>
    {
        protected static Should<double, BeBase<double>> should;

        Establish context = () =>
        {
            target = 5;
            should = new Should<double, BeBase<double>>(target, mockAssertProvider.Object);
        };
    }

    public class when_calling_double_equal : should_double_context
    {
        const double expected = 5.001;
        const double tolerance = 0.001;
        Because of = () => result = should.Equal(expected, tolerance);
        It result_should_equal_target = () => Assert.AreEqual(target, result);
        It should_assert_areequal = () => Called(x => x.AreEqual(expected, target, tolerance));
    }

    public class when_calling_double_not_equal : should_double_context
    {
        const double expected = 5.001;
        const double tolerance = 0.001;
        Because of = () => result = should.Not.Equal(expected, tolerance);
        It result_should_equal_target = () => Assert.AreEqual(target, result);
        It should_assert_areequal = () => Called(x => x.AreNotEqual(expected, target, tolerance));
    }
}