using System;
using System.Diagnostics;
using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class TraceAssertTests
    {
        [Fact]
        public void TraceAssertFailureWithFullDetails()
        {
            TraceAssertException ex = Assert.Throws<TraceAssertException>(() => Trace.Assert(false, "message", "detailed message"));

            Assert.Equal("message", ex.AssertMessage);
            Assert.Equal("detailed message", ex.AssertDetailedMessage);
            Assert.Equal("Debug.Assert() Failure : message" + Environment.NewLine + "Detailed Message:" + Environment.NewLine + "detailed message", ex.Message);
        }

        [Fact]
        public void TraceAssertFailureWithNoDetailedMessage()
        {
            TraceAssertException ex = Assert.Throws<TraceAssertException>(() => Trace.Assert(false, "message"));

            Assert.Equal("message", ex.AssertMessage);
            Assert.Equal("", ex.AssertDetailedMessage);
            Assert.Equal("Debug.Assert() Failure : message", ex.Message);
        }

        [Fact]
        public void TraceAssertFailureWithNoMessage()
        {
            TraceAssertException ex = Assert.Throws<TraceAssertException>(() => Trace.Assert(false));

            Assert.Equal("", ex.AssertMessage);
            Assert.Equal("", ex.AssertDetailedMessage);
            Assert.Equal("Debug.Assert() Failure", ex.Message);
        }
    }
}