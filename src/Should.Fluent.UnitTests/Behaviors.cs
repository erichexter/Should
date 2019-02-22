using System;
using Machine.Specifications;
using Should.Core.Exceptions;
using Xunit;

namespace Should.Fluent.UnitTests
{
    [Behaviors]
    public class Throws<T> where T : AssertException
    {
        protected static Exception exception;

        It should_throw_assert_exception_of_expected_type = () =>
        {
            Assert.NotNull(exception);
            Assert.IsType<T>(exception);
        };
    }

    [Behaviors]
    public class DoesNotThrow
    {
        protected static Exception exception;
        It should_throw_not_equal_exception = () => Assert.Null(exception);
    }
}