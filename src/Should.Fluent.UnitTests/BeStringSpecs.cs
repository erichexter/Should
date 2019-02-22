using Machine.Specifications;
using Should.Fluent.Model;
using It = Machine.Specifications.It;

namespace Should.Fluent.UnitTests
{
    public class be_string_test_base : test_base<string>
    {
        protected static IBe<string> be;
    }

    public class should_be_string_context : be_string_test_base
    {
        Establish context = () => be = new Should<string, BeBase<string>>(target, mockAssertProvider.Object).Be;
    }

    public class should_not_be_string_context : be_string_test_base
    {
        Establish context = () => be = new Should<string, BeBase<string>>(target, mockAssertProvider.Object).Not.Be;
    }

    public class when_calling_string_null : should_be_string_context
    {
        Because of = () => result = be.Null();
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_isnull = () => Called(x => x.IsNull(target));
    }

    public class when_calling_string_not_null : should_not_be_string_context
    {
        Because of = () => result = be.Null();
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_isnotnull = () => Called(x => x.IsNotNull(target));
    }

    public class when_calling_string_empty : should_be_string_context
    {
        Because of = () => result = be.Empty();
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_areequal = () => Called(x => x.AreEqual(string.Empty, target));
    }

    public class when_calling_string_not_empty : should_not_be_string_context
    {
        Because of = () => result = be.Empty();
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_arenotequal = () => Called(x => x.AreNotEqual(string.Empty, target));
    }

    public class when_calling_string_nullorempty : should_be_string_context
    {
        Because of = () => result = be.NullOrEmpty();
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_istrue = () => Called(x => x.IsTrue(string.IsNullOrEmpty(target)));
    }

    public class when_calling_string_not_nullorempty : should_not_be_string_context
    {
        Because of = () => result = be.NullOrEmpty();
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_arenotequal = () => Called(x => x.IsFalse(string.IsNullOrEmpty(target)));
    }
   
}