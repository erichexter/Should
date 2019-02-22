using System;
using Machine.Specifications;
using Should.Fluent.Model;
using It = Machine.Specifications.It;

namespace Should.Fluent.UnitTests
{
    public class be_guid_test_base : test_base<Guid>
    {
        protected static BeBase<Guid> be;
    }

    public class should_be_guid_context : be_guid_test_base
    {
        Establish context = () => be = new Should<Guid, BeBase<Guid>>(target, mockAssertProvider.Object).Be;
    }

    public class should_not_be_guid_context : be_guid_test_base
    {
        Establish context = () => be = new Should<Guid, BeBase<Guid>>(target, mockAssertProvider.Object).Not.Be;
    }

    public class when_calling_guid_empty : should_be_guid_context
    {
        Because of = () => result = be.Empty();
        Behaves_like<result_should_be_target<Guid>> yes;
        It should_assert_areequal = () => Called(x => x.AreEqual(Guid.Empty, target));
    }

    public class when_calling_guid_not_empty : should_not_be_guid_context
    {
        Because of = () => result = be.Empty();
        Behaves_like<result_should_be_target<Guid>> yes;
        It should_assert_arenotequal = () => Called(x => x.AreNotEqual(Guid.Empty, target));
    }
}