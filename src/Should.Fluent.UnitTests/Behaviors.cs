using System;
using NUnit.Framework;
using Should.Core.Exceptions;

namespace Should.Fluent.UnitTests
{
    // Shared behavior helpers - not test fixtures themselves.
    // Classes that previously used Behaves_like<Throws<T>> should inline:
    //   [Test] public void should_throw_assert_exception_of_expected_type() { Assert.IsNotNull(exception); Assert.IsInstanceOf(typeof(T), exception); }
    // Classes that previously used Behaves_like<DoesNotThrow> should inline:
    //   [Test] public void should_not_throw() { Assert.IsNull(exception); }
    public class Throws<T> where T : AssertException
    {
        protected static Exception exception;
    }

    public class DoesNotThrow
    {
        protected static Exception exception;
    }
}
