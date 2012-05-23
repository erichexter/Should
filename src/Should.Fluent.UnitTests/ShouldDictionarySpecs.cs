using System.Collections.Generic;
using Machine.Specifications;
using NUnit.Framework;
using Should.Fluent.Model;
using It=Machine.Specifications.It;

namespace Should.Fluent.UnitTests
{
    public class should_dictionary_context : test_base
    {
        protected static ShouldDictionary<int, int> should;
        protected static IDictionary<int, int> target;

        Establish context = () =>
        {
            target = new Dictionary<int, int>();
            should = new ShouldDictionary<int, int>(target, mockAssertProvider.Object);
        };
    }

    public class when_getting_count : should_dictionary_context
    {
        static Count<KeyValuePair<int, int>> result;

        Establish context = () => target.Add(1, 1);
        Because of = () => result = should.Count;
        It count_should_not_be_null = () => Assert.IsNotNull(result);
    }

    public class when_getting_contain : should_dictionary_context
    {
        static Contain<KeyValuePair<int, int>> result;

        Establish context = () => target.Add(1, 1);
        Because of = () => result = should.Contain;
        It contain_should_not_be_null = () => Assert.IsNotNull(result);
    }

    public class when_calling_contains_key : should_dictionary_context
    {
        protected static IEnumerable<KeyValuePair<int, int>> result;

        Establish context = () => target.Add(1, 1);
        Because of = () => result = should.ContainKey(1);
        It should_not_fail = NotFail;
        It result_is_same_as_target = () => Assert.AreSame(target, result);
    }

    public class when_calling_not_contains_key : should_dictionary_context
    {
        protected static IEnumerable<KeyValuePair<int, int>> result;

        Establish context = () => target.Add(1, 1);
        Because of = () => result = should.Not.ContainKey(2);
        It should_not_fail = NotFail;
        It result_is_same_as_target = () => Assert.AreSame(target, result);
    }

    public class when_calling_contains_key_but_not_contains : should_dictionary_context
    {
        protected static IEnumerable<KeyValuePair<int, int>> result;

        Establish context = () => target.Add(1, 1);
        Because of = () => result = should.ContainKey(2);
        It result_is_same_as_target = () => Assert.AreSame(target, result);
        It should_fail = () => Fail("Expected dictionary to contain key '{0}' but it does not.", 2);
    }
}