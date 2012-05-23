using System;
using Should.Core;
using Should.Core.Exceptions;
using Xunit;

namespace Should.Facts
{
    public class DateAssertionExtension_Facts
    {
        [Fact]
        public void ShouldEqual_succeeds_when_numbers_are_within_tolerance()
        {
            var actual = new DateTime(2000, 1, 1, 1, 30, 0);
            var expected = actual.AddMinutes(5);
            actual.ShouldEqual(expected, TimeSpan.FromMinutes(5));
        }

        [Fact]
        public void ShouldEqual_fails_when_numbers_are_outside_tolerance()
        {
            var actual = new DateTime(2000, 1, 1, 1, 30, 0);
            var expected = actual.AddMinutes(5);
            Assert.Throws<EqualException>(() => actual.ShouldEqual(expected, TimeSpan.FromMinutes(4)));
        }

        [Fact]
        public void ShouldNotEqual_fails_when_numbers_are_within_tolerance()
        {
            var actual = new DateTime(2000, 1, 1, 1, 30, 0);
            var expected = actual.AddMinutes(5);
            Assert.Throws<NotEqualException>(() => actual.ShouldNotEqual(expected, TimeSpan.FromMinutes(5)));
        }

        [Fact]
        public void ShouldNotEqual_succeeds_when_numbers_are_outside_tolerance()
        {
            var actual = new DateTime(2000, 1, 1, 1, 30, 0);
            var expected = actual.AddMinutes(5);
            actual.ShouldNotEqual(expected, TimeSpan.FromMinutes(4));
        }

        [Fact]
        public void ShouldEqual_succeeds_when_numbers_are_within_precision()
        {
            var actual = new DateTime(2000, 1, 1, 1, 30, 0);
            var expected = actual.AddMinutes(5);
            actual.ShouldEqual(expected, DatePrecision.Hour);
        }

        [Fact]
        public void ShouldEqual_fails_when_numbers_are_outside_precision()
        {
            var actual = new DateTime(2000, 1, 1, 1, 30, 0);
            var expected = actual.AddMinutes(5);
            Assert.Throws<EqualException>(() => actual.ShouldEqual(expected, DatePrecision.Minute));
        }

        [Fact]
        public void ShouldNotEqual_fails_when_numbers_are_within_precision()
        {
            var actual = new DateTime(2000, 1, 1, 1, 30, 0);
            var expected = actual.AddMinutes(5);
            Assert.Throws<NotEqualException>(() => actual.ShouldNotEqual(expected, DatePrecision.Hour));
        }

        [Fact]
        public void ShouldNotEqual_succeeds_when_numbers_are_outside_precision()
        {
            var actual = new DateTime(2000, 1, 1, 1, 30, 0);
            var expected = actual.AddMinutes(5);
            actual.ShouldNotEqual(expected, DatePrecision.Minute);
        }
    }
}
