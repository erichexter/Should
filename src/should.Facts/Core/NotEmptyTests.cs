using System.Collections.Generic;
using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class NotEmptyTests
    {
        [Fact]
        public void ContainerIsEmpty()
        {
            List<int> list = new List<int>();

            NotEmptyException ex =
                Assert.Throws<NotEmptyException>(() => Assert.NotEmpty(list));

            Assert.Equal("Assert.NotEmpty() failure", ex.Message);
        }

        [Fact]
        public void ContainerIsNotEmpty()
        {
            List<int> list = new List<int>();
            list.Add(42);

            Assert.NotEmpty(list);
        }
    }
}