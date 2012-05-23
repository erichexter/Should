using System;
using Xunit;
using Assert = Should.Core.Assertions.Assert;
using Should.Core.Exceptions;

namespace Should.Facts.Core
{
    public class GreaterThanTests
    {
        DateTime today = DateTime.Today;
        DateTime tomorrow = DateTime.Today.AddDays(1);

        [Fact]
        public void Two_is_greater_than_one_should_pass()
        {
            Assert.GreaterThan(2, 1);
        }

        [Fact]
        public void One_is_not_greater_than_two_should_fail()
        {
            Assert.Throws<GreaterThanException>(() => Assert.GreaterThan(1, 2));
        }

        [Fact]
        public void Tomorrow_is_greater_than_today_should_pass()
        {
            Assert.GreaterThan(tomorrow, today);
        }

        [Fact]
        public void Today_is_not_greater_than_tomorrow_should_fail()
        {
            Assert.Throws<GreaterThanException>(() => Assert.GreaterThan(today, tomorrow));
        }

        [Fact]
        public void b_is_greater_than_a_should_pass()
        {
            Assert.GreaterThan("b", "a");
        }

        [Fact]
        public void a_is_not_greater_than_b_should_fail()
        {
            Assert.Throws<GreaterThanException>(() => Assert.GreaterThan("a", "b"));
        }

        [Fact]
        public void a_is_greater_than_A_using_case_sensitive_ordinal_comparer_should_pass()
        {
            Assert.GreaterThan("a", "A", StringComparer.Ordinal);
        }

        [Fact]
        public void a_is_not_greater_than_A_using_case_insensitive_ordinal_comparer_should_fail()
        {
            Assert.Throws<GreaterThanException>(() => Assert.GreaterThan("a", "A", StringComparer.OrdinalIgnoreCase));
        }

    }
}