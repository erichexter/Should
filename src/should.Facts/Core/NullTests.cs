using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class NullTests
    {
        [Fact]
        public void Null()
        {
            Assert.Null(null);
        }

        [Fact]
        public void NullThrowsExceptionWhenNotNull()
        {
            try
            {
                Assert.Null(new object());
            }
            catch (AssertException exception)
            {
                Assert.Equal("Assert.Null() Failure", exception.UserMessage);
            }
        }
    }
}