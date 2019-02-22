using System;
using Machine.Specifications;
using Should.Fluent.Model;
using It = Machine.Specifications.It;

namespace Should.Fluent.UnitTests
{
    public class be_nullable_datetime_test_base : test_base<DateTime?>
    {
        protected static BeBase<DateTime?> be;

        protected static Should<DateTime?, BeBase<DateTime?>> get_should(DateTime? theTarget)
        {
            target = theTarget;
            return new Should<DateTime?, BeBase<DateTime?>>(target, mockAssertProvider.Object);
        }
    }

    public class should_be_nullable_datetime_context : be_nullable_datetime_test_base
    {
        Establish context = () => be = get_should(DateTime.Now).Be;
    }

    public class should_not_be_nullable_datetime : be_nullable_datetime_test_base
    {
        Establish context = () => be = get_should(DateTime.Now).Not.Be;
    }

    public class when_calling_nullable_datatime_is_null : should_be_nullable_datetime_context
    {
        Because of = () => result = be.Null();
        Behaves_like<result_should_be_target<DateTime?>> yes;
        It should_assert_isnull = () => Called(x => x.IsNull(target));
    }

    public class when_calling_nullable_datetime_is_not_null : should_not_be_nullable_datetime
    {
        Because of = () => result = be.Null();
        Behaves_like<result_should_be_target<DateTime?>> yes;
        It should_assert_isnotnull = () => Called(x => x.IsNotNull(target));
    }

    public class when_calling_nullable_today : should_be_nullable_datetime_context
    {
        Because of = () => result = be.Today();
        It should_not_fail = NotFail;
        Behaves_like<result_should_be_target<DateTime?>> yes;
        It should_call_areequal = () => Called(x => x.AreEqual(DateTime.Today, target.Value.Date));
    }

    public class when_calling_nullable_not_today : should_not_be_nullable_datetime
    {
        Because of = () => result = be.Today();
        It should_not_fail = NotFail;
        Behaves_like<result_should_be_target<DateTime?>> yes;
        It should_call_arenotequal = () => Called(x => x.AreNotEqual(DateTime.Today, target.Value.Date));
    }

    public class when_calling_nullable_today_with_null : be_nullable_datetime_test_base
    {
        Establish context = () => be = get_should(null).Be;
        Because of = () => result = be.Today();
        It should_fail = () => Fail("Expected TODAY but was NULL.");
    }
}