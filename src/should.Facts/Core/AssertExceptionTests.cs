using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class AssertExceptionTests
    {
        [Fact]
        public void PreservesUserMessage()
        {
            AssertException ex = new AssertException("UserMessage");

            Assert.Equal("UserMessage", ex.UserMessage);
        }

        [Fact]
        public void UserMessageIsTheMessage()
        {
            AssertException ex = new AssertException("UserMessage");

            Assert.Equal(ex.UserMessage, ex.Message);
        }
    }
}