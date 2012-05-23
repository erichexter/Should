using System;
using Machine.Specifications;
using Should.Fluent.Model;
using It=Machine.Specifications.It;

namespace Should.Fluent.UnitTests
{
    public class be_test_base : test_base<string>
    {
        protected static Be<string> be;
        Establish context = () => target = "foo";
    }

    public class should_be_context : be_test_base
    {
        Establish context = () => be = new Should<string, Be<string>>(target, mockAssertProvider.Object).Be;
    }

    public class should_not_be_context : be_test_base
    {
        Establish context = () => be = new Should<string, Be<string>>(target, mockAssertProvider.Object).Not.Be;
    }

    public class when_calling_null : should_be_context
    {
        Because of = () => result = be.Null();
        Behaves_like<result_should_be_target<string>> yes;
        It should_call_isnull = () => Called(x => x.IsNull(target));
    }

    public class when_calling_not_null : should_not_be_context
    {
        Because of = () => result = be.Null();
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_isnotnull = () => Called(x => x.IsNotNull(target));
    }

    public class when_calling_generic_oftype : should_be_context
    {
        Because of = () => result = be.OfType<string>();
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_isinstanceoftype= () => Called(x => x.IsInstanceOfType(target, typeof(string)));
    }

    public class when_calling_not_generic_oftype : should_not_be_context
    {
        Because of = () => result = be.OfType<string>();
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_isnotinstanceoftype = () => Called(x => x.IsNotInstanceOfType(target, typeof(string)));
    }

    public class when_calling_oftype : should_be_context
    {
        Because of = () => result = be.OfType(typeof(string));
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_isinstanceoftype = () => Called(x => x.IsInstanceOfType(target, typeof(string)));
    }

    public class when_calling_not_oftype : should_not_be_context
    {
        Because of = () => result = be.OfType(typeof(string));
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_isnotinstanceoftype = () => Called(x => x.IsNotInstanceOfType(target, typeof(string)));
    }

    public class when_calling_sameas : should_be_context
    {
        Because of = () => result = be.SameAs(target);
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_isinstanceoftype = () => Called(x => x.AreSame(target, target));
    }

    public class when_calling_not_sameas : should_not_be_context
    {
        static string expected = "not same";
        Because of = () => result = be.SameAs(expected);
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_isnotinstanceoftype = () => Called(x => x.AreNotSame(expected, target));
    }

    public class when_calling_inrange : should_be_context
    {
        static string low = "a";
        static string high = "b";
        Because of = () => result = be.InRange(low, high);
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_inrange= () => Called(x => x.InRange(target, low, high));
    }

    public class when_calling_not_inrange : should_not_be_context
    {
        static string low = "a";
        static string high = "z";
        Because of = () => result = be.InRange(low, high);
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_inrange = () => Called(x => x.NotInRange(target, low, high));
    }

    public class when_calling_assignablefrom : should_be_context
    {
        static Type expectedType = typeof(object);
        Because of = () => result = be.AssignableFrom(expectedType);
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_inrange = () => Called(x => x.AssignableFrom(target, expectedType));
    }

    public class when_calling_not_assignablefrom : should_not_be_context
    {
        static Type expectedType = typeof(object);
        Because of = () => result = be.AssignableFrom(expectedType);
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_inrange = () => Called(x => x.NotAssignableFrom(target, expectedType));
    }

    public class when_calling_assignablefrom_generic : should_be_context
    {
        Because of = () => result = be.AssignableFrom<object>();
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_inrange = () => Called(x => x.AssignableFrom(target, typeof(object)));
    }

    public class when_calling_not_assignablefrom_generic : should_not_be_context
    {
        Because of = () => result = be.AssignableFrom<object>();
        Behaves_like<result_should_be_target<string>> yes;
        It should_assert_inrange = () => Called(x => x.NotAssignableFrom(target, typeof(object)));
    }
}