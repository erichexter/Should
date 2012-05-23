using System;
using System.Collections;
using Should.Core.Exceptions;
using Xunit;
using Assert = Should.Core.Assertions.Assert;

namespace Should.Facts.Core
{
    public class SingleFacts
    {
        public class NonGenericEnumerable
        {
            [Fact]
            public void SingleWithNullCollectionThrows()
            {
                Assert.Throws<ArgumentNullException>(() => Assert.Single(null));
            }

            [Fact]
            public void SingleWithEmptyCollectionThrows()
            {
                ArrayList collection = new ArrayList();

                Exception ex = Record.Exception(() => Assert.Single(collection));

                Assert.IsType<SingleException>(ex);
                Assert.Equal("The collection contained 0 elements instead of 1.", ex.Message);
            }

            [Fact]
            public void SingleWithMultiItemCollectionThrows()
            {
                ArrayList collection = new ArrayList { "Hello", "World" };

                Exception ex = Record.Exception(() => Assert.Single(collection));

                Assert.IsType<SingleException>(ex);
                Assert.Equal("The collection contained 2 elements instead of 1.", ex.Message);
            }

            [Fact]
            public void SingleWithSingleItemCollectionDoesNotThrow()
            {
                ArrayList collection = new ArrayList { "Hello" };

                Exception ex = Record.Exception(() => Assert.Single(collection));

                Assert.Null(ex);
            }

            [Fact]
            public void SingleWithSingleItemCollectionReturnsTheItem()
            {
                ArrayList collection = new ArrayList { "Hello" };

                object result = Assert.Single(collection);

                Assert.Equal("Hello", result);
            }
        }

        public class GenericEnumerable
        {
            [Fact]
            public void SingleWithNullCollectionThrows()
            {
                Assert.Throws<ArgumentNullException>(() => Assert.Single<object>(null));
            }

            [Fact]
            public void SingleWithEmptyCollectionThrows()
            {
                object[] collection = new object[0];

                Exception ex = Record.Exception(() => Assert.Single(collection));

                Assert.IsType<SingleException>(ex);
                Assert.Equal("The collection contained 0 elements instead of 1.", ex.Message);
            }

            [Fact]
            public void SingleWithMultiItemCollectionThrows()
            {
                string[] collection = new[] { "Hello", "World!" };

                Exception ex = Record.Exception(() => Assert.Single(collection));

                Assert.IsType<SingleException>(ex);
                Assert.Equal("The collection contained 2 elements instead of 1.", ex.Message);
            }

            [Fact]
            public void SingleWithSingleItemCollectionDoesNotThrow()
            {
                string[] collection = new[] { "Hello" };

                Exception ex = Record.Exception(() => Assert.Single(collection));

                Assert.Null(ex);
            }

            [Fact]
            public void SingleWithSingleItemCollectionReturnsTheItem()
            {
                string[] collection = new[] { "Hello" };

                string result = Assert.Single(collection);

                Assert.Equal("Hello", result);
            }
        }
    }
}