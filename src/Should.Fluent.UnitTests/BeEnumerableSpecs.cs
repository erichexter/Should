using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Should.Fluent.Model;
using It = Machine.Specifications.It;

namespace Should.Fluent.UnitTests
{
    public class be_enumerable_test_base : test_base<IEnumerable<string>>
    {
        protected static BeBase<IEnumerable<string>> be;
        Establish context = () => target = new List<string>(new[] { "foo" });
    }

    public class should_be_enumerable_contex : be_enumerable_test_base
    {
        Establish context = () => be = new ShouldEnumerable<string>(target, mockAssertProvider.Object).Be;
    }

    public class should_not_be_enumerable_context : be_enumerable_test_base
    {
        Establish context = () => be = new ShouldEnumerable<string>(target, mockAssertProvider.Object).Not.Be;
    }

    public class when_calling_empty : should_be_enumerable_contex
    {
        Because of = () => result = be.Empty();
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
        It should_call_areequal = () => Called(x => x.AreEqual(0, target.Count()));
    }

    public class when_calling_not_empty : should_not_be_enumerable_context
    {
        Because of = () => result = be.Empty();
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
        It should_call_iarenotequal = () => Called(x => x.AreNotEqual(0, target.Count()));
    }

    public class when_calling_enumerable_null : should_be_enumerable_contex
    {
        Because of = () => result = be.Null();
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
        It should_call_isnull = () => Called(x => x.IsNull(target));
    }

    public class when_calling_enumerable_not_null : should_not_be_enumerable_context
    {
        Because of = () => result = be.Null();
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
        It should_call_isnotnull = () => Called(x => x.IsNotNull(target));
    }
}