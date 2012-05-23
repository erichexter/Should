using System;
using System.Collections.Generic;
using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class ContainsTests
    {
        [Fact]
        public void CanFindNullInContainer()
        {
            List<object> list = new List<object> { 16, null, "Hi there" };

            Assert.Contains(null, list);
        }

        [Fact]
        public void CanSearchForSubstrings()
        {
            Assert.Contains("wor", "Hello, world!");
        }

        [Fact]
        public void CanSearchForSubstringsCaseInsensitive()
        {
            Assert.Contains("WORLD", "Hello, world!", StringComparison.InvariantCultureIgnoreCase);
        }

        [Fact]
        public void CanUseComparer()
        {
            List<int> list = new List<int> { 42 };

            Assert.Contains(43, list, new MyComparer());
        }

        [Fact]
        public void ItemInContainer()
        {
            List<int> list = new List<int> { 42 };

            Assert.Contains(42, list);
        }

        [Fact]
        public void ItemNotInContainer()
        {
            List<int> list = new List<int>();

            ContainsException ex = Assert.Throws<ContainsException>(() => Assert.Contains(42, list));

            Assert.Equal("Assert.Contains() failure: Not found: 42", ex.Message);
        }

        [Fact]
        public void NullsAllowedInContainer()
        {
            List<object> list = new List<object> { null, 16, "Hi there" };

            Assert.Contains("Hi there", list);
        }

        [Fact]
        public void SubstringContainsIsCaseSensitiveByDefault()
        {
            Assert.Throws<ContainsException>(() => Assert.Contains("WORLD", "Hello, world!"));
        }

        [Fact]
        public void SubstringNotFound()
        {
            Assert.Throws<ContainsException>(() => Assert.Contains("hey", "Hello, world!"));
        }

        class MyComparer : IEqualityComparer<int>
        {
            public bool Equals(int x, int y)
            {
                return true;
            }

            public int GetHashCode(int obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}