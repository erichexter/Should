using Machine.Specifications;
using Should.Fluent.Model;
using It = Machine.Specifications.It;

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
        Establish context = () => be = get_should(true).Be;
    }

    public class should_not_be_nullable_bool_context : be_nullable_bool_test_base
    {
        Establish context = () => be = get_should(true).Not.Be;
    }

    public class when_calling_nullable_bool_is_null : should_be_nullable_bool_context
    {
        Because of = () => result = be.Null();
        Behaves_like<result_should_be_target<bool?>> yes;
        It should_assert_isnull = () => Called(x => x.IsNull(target));
    }

    public class when_calling_nullable_bool_is_not_null : should_not_be_nullable_bool_context
    {
        Because of = () => result = be.Null();
        Behaves_like<result_should_be_target<bool?>> yes;
        It should_assert_isnotnull = () => Called(x => x.IsNotNull(target));
    }

    public class when_calling_nullable_true : should_be_nullable_bool_context
    {
        Because of = () => result = be.True();
        Behaves_like<result_should_be_target<bool?>> yes;
        It should_assert_istrue = () => Called(x => x.IsTrue(target.Value));
    }

    public class when_calling_nullable_not_true : should_not_be_nullable_bool_context
    {
        Because of = () => result = be.True();
        Behaves_like<result_should_be_target<bool?>> yes;
        It should_assert_isfalse = () => Called(x => x.IsFalse(target.Value));
    }

    public class when_calling_nullable_false : should_be_nullable_bool_context
    {
        Because of = () => result = be.False();
        Behaves_like<result_should_be_target<bool?>> yes;
        It should_assert_isfalse = () => Called(x => x.IsFalse(target.Value));
        It should_not_fail = NotFail;
    }

    public class when_calling_nullable_not_false : should_not_be_nullable_bool_context
    {
        Because of = () => result = be.False();
        Behaves_like<result_should_be_target<bool?>> yes;
        It should_assert_istrue = () => Called(x => x.IsTrue(target.Value));
        It should_not_fail = NotFail;
    }

    public class when_calling_nullable_true_with_null : should_be_nullable_bool_context
    {
        Establish context = () => be = get_should(null).Be;
        Because of = () => result = be.True();
        It should_fail = () => Fail("Expected TRUE but was NULL.");
    }

    public class when_calling_nullable_false_with_null : be_nullable_bool_test_base
    {
        Establish context = () => be = get_should(null).Be;
        Because of = () => result = be.False();
        It should_fail = () => Fail("Expected FALSE but was NULL.");
    }
}