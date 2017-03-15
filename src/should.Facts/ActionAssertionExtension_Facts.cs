using System;
using Xunit;

namespace Should.Facts
{
    public class ActionAssertionExtensionFacts
    {
        private static object ThrowMethod()
        {
            throw new ArgumentException("Bad value.", "badParamName");
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

        [Fact]
        public void ShouldThrow_passes_if_ArgumentException_parameter_name_matches()
        {
            Action action = () => ThrowMethod();
            action.ShouldThrow<ArgumentException>("badParamName");
        }

        [Fact]
        public void ShouldThrow_fails_if_ArgumentException_parameter_name_does_not_match()
        {
            Action action = () => ThrowMethod();
            Assert.Throws(
                typeof(Should.Core.Exceptions.EqualException),
                () => action.ShouldThrow<ArgumentException>("differentParamName"));
        }
    }
}