using System;
using System.Linq.Expressions;
using Machine.Specifications;
using Should.Fluent.Model;
using It=Machine.Specifications.It;
using IT = Moq.It;

namespace Should.Fluent.UnitTests
{
    public class be_methodcallexpression_test_base : test_base<MethodCallExpression>
    {
        protected static BeBase<MethodCallExpression> be;

        Establish context = () =>
        {
            Expression<Func<MethodCallExpressionFake, bool>> exp = x => x.Test1("test", 1);
            target = (MethodCallExpression)exp.Body;
        };
    }

    public class should_be_methodcallexpression_context : be_methodcallexpression_test_base
    {
        Establish context = () => be = new Should<MethodCallExpression, BeBase<MethodCallExpression>>(target, mockAssertProvider.Object).Be;
    }

    public class should_not_be_methodcallexpression_context : be_methodcallexpression_test_base
    {
        Establish context = () => be = new Should<MethodCallExpression, BeBase<MethodCallExpression>>(target, mockAssertProvider.Object).Not.Be;
    }

    public class when_calling_methodcallexpression_equal_on_same_method_with_same_parameters : should_be_methodcallexpression_context
    {
        Because of = () =>
        {
            Expression<Func<MethodCallExpressionFake, bool>> exp = x => x.Test1("test", 1);
            result = be.Equal((MethodCallExpression) exp.Body);
        };
        Behaves_like<result_should_be_target<MethodCallExpression>> yes;
        It should_not_assert_fail = () => NotCalled(x => x.Fail(IT.IsAny<string>()));
    }

    public class when_calling_methodcallexpression_not_equal_on_same_method_with_same_parameters : should_not_be_methodcallexpression_context
    {
        Because of = () =>
        {
            Expression<Func<MethodCallExpressionFake, bool>> exp = x => x.Test1("test", 1);
            result = be.Equal((MethodCallExpression)exp.Body);
        };
        Behaves_like<result_should_be_target<MethodCallExpression>> yes;
        It should_assert_fail = () => Called(x => x.Fail(IT.IsAny<string>()));
    }

    public class when_calling_methodcallexpression_equal_on_same_method_with_different_parameters : should_be_methodcallexpression_context
    {
        Because of = () =>
        {
            Expression<Func<MethodCallExpressionFake, bool>> exp = x => x.Test1("different", 1);
            result = be.Equal((MethodCallExpression)exp.Body);
        };
        It should_assert_fail = () => Called(x => x.Fail(IT.IsAny<string>()));
    }

    public class when_calling_methodcallexpression_not_equal_on_same_method_with_different_parameters : should_not_be_methodcallexpression_context
    {
        Because of = () =>
        {
            Expression<Func<MethodCallExpressionFake, bool>> exp = x => x.Test1("different", 1);
            result = be.Equal((MethodCallExpression)exp.Body);
        };
        It should_not_assert_fail = () => NotCalled(x => x.Fail(IT.IsAny<string>()));
    }

    public class when_calling_methodcallexpression_equal_on_different_method_with_same_parameters : should_be_methodcallexpression_context
    {
        Because of = () =>
        {
            Expression<Func<MethodCallExpressionFake, bool>> exp = x => x.Test2("test", 1);
            result = be.Equal((MethodCallExpression)exp.Body);
        };
        It should_assert_fail = () => Called(x => x.Fail(IT.IsAny<string>()));
    }

    public class when_calling_methodcallexpression_not_equal_on_different_method_with_same_parameters : should_not_be_methodcallexpression_context
    {
        Because of = () =>
        {
            Expression<Func<MethodCallExpressionFake, bool>> exp = x => x.Test2("test", 1);
            result = be.Equal((MethodCallExpression)exp.Body);
        };
        It should_not_assert_fail = () => NotCalled(x => x.Fail(IT.IsAny<string>()));
    }

    public class when_calling_methodcallexpression_equal_on_identical_method_with_same_parameters_but_from_different_class : should_be_methodcallexpression_context
    {
        Because of = () =>
        {
            Expression<Func<MethodCallExpressionFake2, bool>> exp = x => x.Test1("test", 1);
            result = be.Equal((MethodCallExpression)exp.Body);
        };
        It should_assert_fail = () => Called(x => x.Fail(IT.IsAny<string>()));
    }

    public class when_calling_methodcallexpression_not_equal_on_identical_method_with_same_parameters_but_from_different_class : should_not_be_methodcallexpression_context
    {
        Because of = () =>
        {
            Expression<Func<MethodCallExpressionFake2, bool>> exp = x => x.Test1("test", 1);
            result = be.Equal((MethodCallExpression)exp.Body);
        };
        It should_not_assert_fail = () => NotCalled(x => x.Fail(IT.IsAny<string>()));
    }

    public class when_calling_methodcallexpression_equal_on_same_method_with_same_generic_parameters : test_base<MethodCallExpression>
    {
        protected static BeBase<MethodCallExpression> be;

        Establish context = () =>
        {
            Expression<Func<MethodCallExpressionFake, bool>> exp = x => x.Test3<bool>();
            target = (MethodCallExpression)exp.Body;
            be = new Should<MethodCallExpression, BeBase<MethodCallExpression>>(target, mockAssertProvider.Object).Be;
        };

        Because of = () =>
        {
            Expression<Func<MethodCallExpressionFake, bool>> exp = x => x.Test3<bool>();
            result = be.Equal((MethodCallExpression)exp.Body);
        };
        It should_not_assert_fail = () => NotCalled(x => x.Fail(IT.IsAny<string>()));
    }

    public class when_calling_methodcallexpression_equal_on_same_method_with_different_generic_parameters : test_base<MethodCallExpression>
    {
        protected static BeBase<MethodCallExpression> be;

        Establish context = () =>
        {
            Expression<Func<MethodCallExpressionFake, bool>> exp = x => x.Test3<int>();
            target = (MethodCallExpression)exp.Body;
            be = new Should<MethodCallExpression, BeBase<MethodCallExpression>>(target, mockAssertProvider.Object).Be;
        };

        Because of = () =>
        {
            Expression<Func<MethodCallExpressionFake, bool>> exp = x => x.Test3<bool>();
            result = be.Equal((MethodCallExpression)exp.Body);
        };
        It should_assert_fail = () => Called(x => x.Fail(IT.IsAny<string>()));
    }

    public class MethodCallExpressionFake
    {
        public bool Test1<T>(T foo, int bar)
        {
            return true;
        }

        public bool Test2(string foo, int bar)
        {
            return true;
        }

        public bool Test3<T>()
        {
            return true;
        }
    }

    public class MethodCallExpressionFake2
    {
        public bool Test1(string foo, int bar)
        {
            return true;
        }
    }
}