using Machine.Specifications;
using Should.Fluent.Model;

namespace Should.Fluent.UnitTests
{
    public class be_double_test_base : test_base<double>
    {
        protected static BeBase<double> be;
    }

    public class should_be_double_context : be_double_test_base
    {
        Establish context = () => be = new Should<double, BeBase<double>>(target, mockAssertProvider.Object).Be;
    }

    public class should_not_be_double_context : be_double_test_base
    {
        Establish context = () => be = new Should<double, BeBase<double>>(target, mockAssertProvider.Object).Not.Be;
    }

    public class when_calling_double_positive : should_be_double_context
    {
        Because of = () => result = be.Positive();
        Behaves_like<result_should_be_target<double>> yes;
        It should_assert_greater_than = () => Called(x => x.GreaterThan<double>(target, 0));
    }

    public class when_calling_double_not_positive : should_not_be_double_context
    {
        Because of = () => result = be.Positive();
        Behaves_like<result_should_be_target<double>> yes;
        It should_assert_lessorequal = () => Called(x => x.LessThanOrEqual<double>(target, 0));
    }

    public class when_calling_double_negative : should_be_double_context
    {
        Because of = () => result = be.Negative();
        Behaves_like<result_should_be_target<double>> yes;
        It should_assert_greater = () => Called(x => x.LessThan<double>(target, 0));
    }

    public class when_calling_double_not_negative : should_not_be_double_context
    {
        Because of = () => result = be.Negative();
        Behaves_like<result_should_be_target<double>> yes;
        It should_assert_lessorequal = () => Called(x => x.GreaterThanOrEqual<double>(target, 0));
    }
}