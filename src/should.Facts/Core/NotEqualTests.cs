using System;
using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class NotEqualTests
    {
        [Fact]
        public void NotEqualFailsString()
        {
            try
            {
                Assert.NotEqual("actual", "actual");
            }
            catch (NotEqualException exception)
            {
                Assert.Equal("Assert.NotEqual() Failure", exception.UserMessage);
            }
        }

        [Fact]
        public void NotEqualWithCustomComparer()
        {
            string expected = "TestString";
            string actual = "testString";

            Assert.False(actual == expected);
            Assert.Equal(expected, actual, StringComparer.CurrentCultureIgnoreCase);
            Assert.NotEqual(expected, actual, StringComparer.CurrentCulture);
        }

        [Fact]
        public void ValuesNotEqual()
        {
            Assert.NotEqual("bob", "jim");
        }
    }
}