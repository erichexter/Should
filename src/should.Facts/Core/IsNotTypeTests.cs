using System;
using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class IsNotTypeTests
    {
        [Fact]
        public void IsNotType()
        {
            InvalidCastException expected = new InvalidCastException();
            Assert.IsNotType(typeof(Exception), expected);
            Assert.IsNotType<Exception>(expected);
        }

        [Fact]
        public void IsNotTypeThrowsExceptionWhenWrongType()
        {
            AssertException exception =
                Assert.Throws<IsNotTypeException>(() => Assert.IsNotType<InvalidCastException>(new InvalidCastException()));

            Assert.Equal("Assert.IsNotType() Failure", exception.UserMessage);
        }
    }
}