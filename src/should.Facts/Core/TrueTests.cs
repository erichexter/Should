using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class TrueTests
    {
        [Fact]
        public void AssertTrue()
        {
            Assert.True(true);
        }

        [Fact]
        public void AssertTrueThrowsExceptionWhenFalse()
        {
            TrueException exception = Assert.Throws<TrueException>(() => Assert.True(false));

            Assert.Equal("Assert.True() Failure", exception.UserMessage);
        }
    }
}