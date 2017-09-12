using Machine.Specifications;
using NUnit.Framework;

namespace Should.Fluent.UnitTests
{
    [Behaviors]
    public class result_should_be_target<T>
    {
        protected static T result;
        protected static T target;
        It result_should_equal_target = () => Assert.AreEqual(target, result);
    }
}