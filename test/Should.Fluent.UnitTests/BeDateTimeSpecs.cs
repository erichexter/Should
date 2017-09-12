using System;
using Machine.Specifications;
using Should.Fluent.Model;
using It=Machine.Specifications.It;

namespace Should.Fluent.UnitTests
{
    public class be_datetime_test_base : test_base<DateTime>
    {
        protected static BeBase<DateTime> be;
        Establish context = () => target = DateTime.Now;
    }

    public class should_be_datetime_context : be_datetime_test_base
    {
        Establish context = () => be = new Should<DateTime, BeBase<DateTime>>(target, mockAssertProvider.Object).Be;
    }

    public class should_not_be_datetime_context : be_datetime_test_base
    {
        Establish context = () => be = new Should<DateTime, BeBase<DateTime>>(target, mockAssertProvider.Object).Not.Be;
    }

    public class when_calling_today : should_be_datetime_context
    {
        Because of = () => result = be.Today();
        Behaves_like<result_should_be_target<DateTime>> yes;
        It should_call_areequal = () => Called(x => x.AreEqual(DateTime.Today, target.Date));
    }

    public class when_calling_not_today : should_not_be_datetime_context
    {
        Because of = () => result = be.Today();
        Behaves_like<result_should_be_target<DateTime>> yes;
        It should_call_arenotequal = () => Called(x => x.AreNotEqual(DateTime.Today, target.Date));
    }
}