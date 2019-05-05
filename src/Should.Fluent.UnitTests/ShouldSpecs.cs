using Machine.Specifications;
using Should.Fluent.Model;
using Xunit;
using It = Machine.Specifications.It;

namespace Should.Fluent.UnitTests
{
    public class should_context : test_base<string>
    {
        protected static Should<string, BeBase<string>> should;

        Establish context = () =>
        {
            target = "foo";
            should = new Should<string, BeBase<string>>(target, mockAssertProvider.Object);
        };
    }

    public class when_calling_equal : should_context
    {
        const string expected = "foo";
        Because of = () => result = should.Equal(expected);
        It result_should_equal_target = () => Assert.Equal(target, result);
        It should_assert_Equal = () => Called(x => x.AreEqual(expected, target));
    }

    public class when_calling_not_equal : should_context
    {
        const string expected = "bar";
        Because of = () => result = should.Not.Equal(expected);
        It result_should_equal_target = () => Assert.Equal(target, result);
        It should_assert_arenotequal = () => Called(x => x.AreNotEqual(expected, target));
    }

    public class should_string_context : test_base
    {
        protected static Should<string, BeBase<string>> should;
        protected static string target = "foo";
        protected static string result;
        Establish context = () => should = new Should<string, BeBase<string>>(target, mockAssertProvider.Object);
    }

    public class when_calling_starts_with : should_string_context
    {
        const string expected = "f";
        Because of = () => result = should.StartWith(expected);
        It result_should_equal_target = () => Assert.Equal(target, result);
        It should_not_fail = NotFail;
    }

    public class when_calling_starts_with_fail : should_string_context
    {
        const string expected = "x";
        Because of = () => result = should.StartWith(expected);
        It should_fail = () => Fail("Expected string '{0}' to start with '{1}', but it did not.", target, expected);
    }

    public class when_calling_not_starts_with : should_string_context
    {
        const string expected = "x";
        Because of = () => result = should.Not.StartWith(expected);
        It result_should_equal_target = () => Assert.Equal(target, result);
        It should_not_fail = NotFail;
    }

    public class when_calling_not_starts_with_fail : should_string_context
    {
        const string expected = "f";
        Because of = () => result = should.Not.StartWith(expected);
        It should_fail= () => Fail("Expected string '{0}' to not start with '{1}', but it did.", target, expected);
    }

    public class when_calling_end_with : should_string_context
    {
        const string expected = "o";
        Because of = () => result = should.EndWith(expected);
        It result_should_equal_target = () => Assert.Equal(target, result);
        It should_not_fail = NotFail;
    }

    public class when_calling_ends_with_fail : should_string_context
    {
        const string expected = "x";
        Because of = () => result = should.EndWith(expected);
        It should_fail = () => Fail("Expected string '{0}' to end with '{1}', but it did not.", target, expected);
    }

    public class when_calling_not_ends_with : should_string_context
    {
        const string expected = "x";
        Because of = () => result = should.Not.EndWith(expected);
        It result_should_equal_target = () => Assert.Equal(target, result);
        It should_not_fail = NotFail;
    }

    public class when_calling_not_ends_with_fail : should_string_context
    {
        const string expected = "o";
        Because of = () => result = should.Not.EndWith(expected);
        It should_fail = () => Fail("Expected string '{0}' to not end with '{1}', but it did.", target, expected);
    }

    public class when_calling_contain : should_string_context
    {
        const string expected = "oo";
        Because of = () => result = should.Contain(expected);
        It should_assert_issubstringof = () => Called(x => x.IsSubstringOf(target, expected));
        It result_should_equal_target = () => Assert.Equal(target, result);
        It should_not_fail = NotFail;
    }

    public class when_calling_not_contain : should_string_context
    {
        protected static string expected = "x";
        Because of = () => result = should.Not.Contain(expected);
        It should_not_assert_issubstringof = () => NotCalled(x => x.IsSubstringOf(target, expected));
        It result_should_equal_target = () => Assert.Equal(target, result);
        It should_not_fail = NotFail;
    }

    public class when_calling_not_contain_fails : should_string_context
    {
        protected static string expected = "oo";
        Because of = () => result = should.Not.Contain(expected);
        It should_fail = () => Fail("Expected string '{0}' to not contain '{1}', but it did.", target, expected);
    }
}