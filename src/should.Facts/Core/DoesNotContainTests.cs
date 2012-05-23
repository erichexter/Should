using System;
using System.Collections.Generic;
using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class DoesNotContainTests
    {
        [Fact]
        public void CanSearchForNullInContainer()
        {
            List<object> list = new List<object> { 16, "Hi there" };

            Assert.DoesNotContain(null, list);
        }

        [Fact]
        public void CanSearchForSubstrings()
        {
            Assert.DoesNotContain("hey", "Hello, world!");
        }

        [Fact]
        public void CanSearchForSubstringsCaseInsensitive()
        {
            Assert.Throws<DoesNotContainException>(
                () => Assert.DoesNotContain("WORLD", "Hello, world!", StringComparison.InvariantCultureIgnoreCase));
        }

        [Fact]
        public void CanUseComparer()
        {
            List<int> list = new List<int>();
            list.Add(42);

            Assert.DoesNotContain(42, list, new MyComparer());
        }

        [Fact]
        public void ItemInContainer()
        {
            List<int> list = new List<int> { 42 };

            DoesNotContainException ex =
                Assert.Throws<DoesNotContainException>(() => Assert.DoesNotContain(42, list));

            Assert.Equal("Assert.DoesNotContain() failure: Found: 42", ex.Message);
        }

        [Fact]
        public void ItemNotInContainer()
        {
            List<int> list = new List<int>();

            Assert.DoesNotContain(42, list);
        }

        [Fact]
        public void NullsAllowedInContainer()
        {
            List<object> list = new List<object> { null, 16, "Hi there" };

            Assert.DoesNotContain(42, list);
        }

        [Fact]
        public void SubstringDoesNotContainIsCaseSensitiveByDefault()
        {
            Assert.DoesNotContain("WORLD", "Hello, world!");
        }

        [Fact]
        public void SubstringFound()
        {
            Assert.Throws<DoesNotContainException>(() => Assert.DoesNotContain("world", "Hello, world!"));
        }

        class MyComparer : IEqualityComparer<int>
        {
            public bool Equals(int x, int y)
            {
                return false;
            }

            public int GetHashCode(int obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}