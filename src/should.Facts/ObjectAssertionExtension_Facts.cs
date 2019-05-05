﻿using System;
using Should.Core.Exceptions;
using Xunit;
using System.Collections;

namespace Should.Facts
{
    public class ObjectAssertionExtensionFacts
    {
        [Fact]
        public void ShouldNotBeNull_accepts_a_message_to_describe_failure()
        {
            String s = null;

            var ex = Assert.Throws<NotNullException>(() =>
            {
                s.ShouldNotBeNull("custom failure message");
            });

            Assert.Equal("custom failure message", ex.Message);
        }

        [Fact]
        public void ShouldNotBeNull_returns_a_strongly_typed_sut_to_support_optional_chaining()
        {
            String s = "foo";

            var sut = s.ShouldNotBeNull();

            Assert.IsAssignableFrom<String>(sut);
        }

        [Fact]
        public void ShouldNotBeNull_with_message_returns_a_strongly_typed_sut_to_support_optional_chaining()
        {
            String s = "foo";

            var sut = s.ShouldNotBeNull("custom failure message");

            Assert.IsAssignableFrom<String>(sut);
        }

        [Fact]
        public void ShouldEqual_accepts_a_message_to_describe_failure()
        {
            String s = "foo";

            var ex = Assert.Throws<EqualException>(() =>
            {
                s.ShouldEqual("bar", "custom failure message");
            });

            Assert.Equal("custom failure message\r\nPosition: First difference is at position 0\r\nExpected: bar\r\nActual:   foo", ex.Message);
        }

        [Fact]
        public void ShouldImplement_accepts_a_custom_failure_message()
        {
            String s = "foo";

            var ex = Assert.Throws<IsAssignableFromException>(() => 
            {
                s.ShouldImplement<IList>("custom failure message");
            });

            Assert.Equal("custom failure message\r\nExpected: System.Collections.IList\r\nActual:   System.String", ex.Message);
        }
    }
}
