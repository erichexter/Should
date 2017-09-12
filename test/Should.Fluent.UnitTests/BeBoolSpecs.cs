using Machine.Specifications;
using Should.Fluent.Model;
using It=Machine.Specifications.It;

namespace Should.Fluent.UnitTests
{
    public class be_bool_test_base : test_base<bool>
    {
        protected static BeBase<bool> be;
    }

    public class should_be_bool_context : be_bool_test_base
    {
        Establish context = () => be = new Should<bool, BeBase<bool>>(target, mockAssertProvider.Object).Be;
    }

    public class should_not_be_bool_context : be_bool_test_base
    {
        Establish context = () => be = new Should<bool, BeBase<bool>>(target, mockAssertProvider.Object).Not.Be;
    }

    public class when_calling_true : should_be_bool_context
    {
        Because of = () => result = be.True();
        Behaves_like<result_should_be_target<bool>> yes;
        It should_assert_istrue = () => Called(x => x.IsTrue(target));
    }

    public class when_calling_not_true : should_not_be_bool_context
    {
        Because of = () => result = be.True();
        Behaves_like<result_should_be_target<bool>> yes;
        It should_assert_isfalse = () => Called(x => x.IsFalse(target));
    }

    public class when_calling_false : should_be_bool_context
    {
        Because of = () => result = be.False();
        Behaves_like<result_should_be_target<bool>> yes;
        It should_assert_isfalse = () => Called(x => x.IsFalse(target));
    }

    public class when_calling_not_false : should_not_be_bool_context
    {
        Because of = () => result = be.False();
        Behaves_like<result_should_be_target<bool>> yes;
        It should_assert_istrue = () => Called(x => x.IsTrue(target));
    }
}