

using System;
using Machine.Specifications;
using NUnit.Framework;
using Should.Core.Exceptions;

namespace Should.Fluent.UnitTests
{
    [Behaviors]
    public class Throws<T> where T : AssertException
    {
        protected static Exception exception;

        It should_throw_assert_exception_of_expected_type = () =>
        {
            Assert.IsNotNull(exception);
            Assert.IsInstanceOf<T>( exception);
        };
    }

    [Behaviors]
    public class DoesNotThrow
    {
        protected static Exception exception;
        It should_throw_not_equal_exception = () => Assert.IsNull(exception);
    }
}