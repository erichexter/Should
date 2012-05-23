using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class NotNullTests
    {
        [Fact]
        public void NotNull()
        {
            Assert.NotNull(new object());
        }

        [Fact]
        public void NotNullThrowsException()
        {
            Assert.Throws<NotNullException>(() => Assert.NotNull(null));
        }
    }
}