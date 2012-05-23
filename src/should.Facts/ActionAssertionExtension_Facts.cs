using System;
using Xunit;

namespace Should.Facts
{
    public class ActionAssertionExtensionFacts
    {
        private static object ThrowMethod()
        {
            throw new ArgumentException();
        }

        [Fact]
        public void ShouldThrow_passes_if_expected_exception_is_thrown()
        {
            Action action = () => ThrowMethod();
            action.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void ShouldThrow_fails_if_a_different_exception_is_thrown()
        {
            Action action = () => ThrowMethod();
            Assert.Throws(
                typeof(Should.Core.Exceptions.ThrowsException),
                () => action.ShouldThrow<ApplicationException>());
        }
    }
}