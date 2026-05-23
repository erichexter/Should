using NUnit.Framework;

namespace Should.Fluent.UnitTests
{
    // Shared behavior base - not a test fixture itself.
    // Classes that previously used Behaves_like<result_should_be_target<T>> should inline
    // a should_return_self test that calls Assert.AreEqual(target, result).
    public class result_should_be_target<T>
    {
        protected static T target;
        protected static T result;
    }
}
