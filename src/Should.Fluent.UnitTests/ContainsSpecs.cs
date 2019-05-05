using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using Should.Fluent.Model;
using It = Machine.Specifications.It;

namespace Should.Fluent.UnitTests
{
    public class contain_test_base : test_base<IEnumerable<string>>
    {
        protected static Contain<string> contains;

        Establish context = () =>
        {
            target = new List<string>(new[] { "foo", "bar", "foo" });
        };
    }

    public class should_contain_context : contain_test_base
    {
        Establish context = () => 
            contains = new ShouldEnumerable<string>(target, mockAssertProvider.Object).Contain;
        
    }

    public class should_not_contain_context : contain_test_base
    {
        Establish context = () =>
            contains = new ShouldEnumerable<string>(target, mockAssertProvider.Object).Not.Contain;
    }

    public class when_calling_any : should_contain_context
    {
        Because of = () => result = contains.Any(x => x == target.ToList()[0]);
        It should_not_fail = NotFail;
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
    }

    public class when_calling_not_any : should_not_contain_context
    {
        Because of = () => result = contains.Any(x => x == "i'm not there");
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
        It should_not_fail = NotFail;
    }

    public class when_calling_one : should_contain_context
    {
        Because of = () => result = contains.One(x => x == target.ToList()[1]);
        It should_not_fail = NotFail;
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
    }

    public class when_calling_not_one : should_not_contain_context
    {
        Because of = () => result = contains.One(x => x == "i'm not there");
        It should_not_fail = NotFail;
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
    }

    public class when_calling_one_with_value : should_contain_context
    {
        Because of = () => result = contains.One(target.ToList()[1]);
        It should_not_fail = NotFail;
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
    }

    public class when_calling_not_one_with_value : should_not_contain_context
    {
        Because of = () => result = contains.One("i'm not there");
        It should_not_fail = NotFail;
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
    }

    public class when_calling_item : should_contain_context
    {
        Because of = () => result = contains.Item(target.ToList()[1]);
        It should_not_fail = NotFail;
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
    }

    public class when_calling_not_item : should_not_contain_context
    {
        Because of = () => result = contains.Item("i'm not there");
        It should_not_fail = NotFail;
        Behaves_like<result_should_be_target<IEnumerable<string>>> yes;
    }

    public static class EnumerableExtensions
    {
        public static ArrayList ToArrayList(this IEnumerable e)
        {
            var result = new ArrayList();
            var enumerator = e.GetEnumerator();
            while (enumerator.MoveNext())
            {
                result.Add(enumerator.Current);
            }
            return result;
        }
    }
}