using System;
using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class DoesNotThrowTests
    {
        [Fact]
        public void CorrectExceptionType()
        {
            DoesNotThrowException ex =
                Assert.Throws<DoesNotThrowException>(
                    () => Assert.DoesNotThrow(
                        () => { throw new NotImplementedException("Exception Message"); }));

            Assert.Equal("Assert.DoesNotThrow() failure", ex.UserMessage);
            Assert.Equal("(No exception)", ex.Expected);
            Assert.Equal("System.NotImplementedException: Exception Message", ex.Actual);
        }

        [Fact]
        public void PassingTest()
        {
            Assert.DoesNotThrow(() => { });
        }
    }
}