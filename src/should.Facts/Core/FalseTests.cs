using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class FalseTests
    {
        [Fact]
        public void AssertFalse()
        {
            Assert.False(false);
        }

        [Fact]
        public void AssertFalseThrowsExceptionWhenTrue()
        {
            try
            {
                Assert.False(true);
            }
            catch (AssertException exception)
            {
                Assert.Equal("Assert.False() Failure", exception.UserMessage);
            }
        }
    }
}