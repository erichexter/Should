using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Machine.Specifications;
using Xunit;
using It = Machine.Specifications.It;
using IT = Moq.It;

namespace Should.Fluent.UnitTests
{
    public class when_calling_object_should_be_null : mocked_assert_provider_context<object>
    {
        static readonly object actual = "foo";

        Because of = () => result = actual.Should().Be.Null();  
        It should_call_areequal =()=> Called(x => x.IsNull(actual));
        It result_is_actual = () => VerifyResult(actual);
        It result_is_an_object = VerifyResultType<object>;
    }

    public class when_calling_string_should_not_be_null : mocked_assert_provider_context<object>
    {
        const string actual = "foo";

        Because of = () => result = actual.Should().Not.Be.Null();
        It should_call_areequal = () => Called(x => x.IsNotNull(actual));
        It result_is_actual = () => VerifyResult(actual);
        It result_is_a_string = VerifyResultType<string>;
    }

    public class should_contain_test_base : mocked_assert_provider_context<IEnumerable<string>>
    {
        Establish context = () => target = new List<string> { "one", "two", "three", "four" };
    }

    public class when_calling_should_contain_one : should_contain_test_base
    {
        Because of = () => result = target.Should().Contain.One(x => x == "one");
        It should_not_fail = NotFail;
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
    }

    public class when_calling_should_contain_item : should_contain_test_base
    {
        Because of = () => result = target.Should().Contain.Item(target.ToList()[0]);
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
    }

    public class when_calling_should_count_exactly : should_contain_test_base
    {
        Because of = () => result = target.Should().Count.Exactly(4);
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
    }

    public class when_calling_should_not_count_exactly : should_contain_test_base
    {
        Because of = () => result = target.Should().Not.Count.Exactly(3);
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
    }

    public class when_chaining : should_contain_test_base
    {
        Because of = () => result = target
            .Should().Count.Exactly(4)
            .Should().Contain.Item("two");
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
    }

    public class when_calling_should_contain_one_and_none_found : should_contain_test_base
    {
        Because of = () => result = target.Should().Contain.One("one bazillion");
        It should_call_fail = () => Called(x => x.Fail(IT.IsAny<string>(), 0));
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
    }

    public class when_calling_bool_should_be_true : mocked_assert_provider_context<bool>
    {
        Establish context = () => target = true;
        Because of = () => result = target.Should().Be.True();
        It should_call_areequal = () => Called(x => x.IsTrue(target));
        Behaves_like<result_should_be_target<bool>> yes;
    }

    public class behaves_like_nullable_bool_true : mocked_assert_provider_context<bool?>
    {
        Establish context = () => target = true;
    }

    public class when_calling_nullable_bool_should_be_true : behaves_like_nullable_bool_true
    {
        Because of = () => result = target.Should().Be.True();
        It should_call_areequal =()=> Called(x => x.IsTrue(target.Value));
        Behaves_like<result_should_be_target<bool?>> yes;
    }

    public class when_calling_nullable_bool_should_not_be_null : behaves_like_nullable_bool_true
    {
        Because of = () => result = target.Should().Not.Be.Null();
        It should_call_areequal = () => Called(x => x.IsNotNull(target));
        Behaves_like<result_should_be_target<bool?>> yes;
    }

    public class when_calling_guid_should_be_empty : mocked_assert_provider_context<Guid>
    {
        Establish context = () => target = Guid.Empty;
        Because of = () => result = target.Should().Be.Empty();
        It should_call_areequal = () => Called(x => x.AreEqual(Guid.Empty, target));
        Behaves_like<result_should_be_target<Guid>> yes;
    }

    public class when_calling_guid_should_not_be_empty : mocked_assert_provider_context<Guid>
    {
        Establish context = () => target = Guid.NewGuid();
        Because of = () => result = target.Should().Not.Be.Empty();
        It should_call_areequal = () => Called(x => x.AreNotEqual(Guid.Empty, target));
        Behaves_like<result_should_be_target<Guid>> yes;
    }

    public class when_calling_string_should_be_covertable_to : mocked_assert_provider_context
    {
        static string actual;
        static Guid result;
        Establish context = () => actual = Guid.NewGuid().ToString();
        Because of = () => result = actual.Should().Be.ConvertableTo<Guid>();
        It result_is_actual_converted = () =>
        {
            var converter = TypeDescriptor.GetConverter(typeof(Guid));
            var expected = (Guid)converter.ConvertFrom(actual);
            Assert.Equal(result, expected);
        };
        It should_not_fail = NotFail;
    }

    public class when_calling_string_should_not_be_covertable_to : mocked_assert_provider_context
    {
        const string actual = "foo";
        static int result;
        Because of = () => result = actual.Should().Not.Be.ConvertableTo<int>();
        It result_is_default = () => Assert.Equal(result, 0);
        It should_not_fail = NotFail;
    }
}