using Should.Core.Exceptions;
using Xunit;

namespace Should.Facts
{
    public class StringAssertionExtensions_Facts
    {
        [Fact]
        public void ShouldContain_expectedSubString_returns_the_index_of_the_occurence()
        {
            int i = "foobar".ShouldContain("bar");

            Assert.Equal(3, i);
        }

        [Fact]
        public void ShouldStartWith_expectedSubString_passes_when_the_sut_starts_with_the_expectedSubString()
        {
            "foobar".ShouldStartWith("foo");
        }

        [Fact]
        public void ShouldStartWith_expectedSubString_fails_with_diagnostics_when_the_sut_does_not_start_with_the_expectedSubString()
        {
            var ex = Assert.Throws<StartsWithException>(() =>
            {
                "foobar".ShouldStartWith("car");
            });

            Assert.Equal("Assert.StartsWith() failure: 'car' not found at the beginning of 'foobar'", ex.Message);
        }
    }
}
